IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Paths'
)
	DROP TABLE Paths

CREATE TABLE RawMetaData
(
	FK_TABLE_NAME nvarchar(50),
	FK_COLUMN_NAME nvarchar(50),
	REFERENCED_TABLE_NAME nvarchar(MAX),
	REFERENCED_COLUMN_NAME nvarchar(MAX)
)
GO

INSERT INTO RawMetaData(FK_TABLE_NAME, FK_COLUMN_NAME, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME)
SELECT
	KCU1.TABLE_NAME AS FK_TABLE_NAME 
    ,KCU1.COLUMN_NAME AS FK_COLUMN_NAME 
    ,KCU2.TABLE_NAME AS REFERENCED_TABLE_NAME 
    ,KCU2.COLUMN_NAME AS REFERENCED_COLUMN_NAME 
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU1
    ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG
    AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA
    AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU2
    ON KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG
    AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA
    AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME
    AND KCU2.ORDINAL_POSITION = KCU1.ORDINAL_POSITION

----------------
-- Traversing---
----------------

CREATE TABLE dbo.Node
(
    Name varchar(50) NULL
)
GO 

CREATE TABLE dbo.Edge
(
    FromNode varchar(50) NOT NULL,
    ToNode varchar(50) NOT NULL
)
GO

INSERT INTO dbo.Node(Name)
SELECT DISTINCT TABLE_NAME
	FROM INFORMATION_SCHEMA.COLUMNS
GO

INSERT INTO dbo.Edge(FromNode, ToNode)
SELECT FK_TABLE_NAME, REFERENCED_TABLE_NAME
	FROM RawMetaData
GO

INSERT INTO dbo.Edge(FromNode, ToNode)
SELECT REFERENCED_TABLE_NAME, FK_TABLE_NAME
	FROM RawMetaData
GO

CREATE PROCEDURE Breadth_First (@StartNode nvarchar(50))
AS
BEGIN
    SET NOCOUNT ON;

	CREATE TABLE #Discovered
	(
		Name nvarchar(50),
		Predecessor nvarchar(50) NULL,
		OrderDiscovered int
	)

    INSERT INTO #Discovered (Name, Predecessor, OrderDiscovered)
    VALUES (@StartNode, NULL, 0)

	-- если за последнюю итерацию не одну строку не добавили
	WHILE @@ROWCOUNT > 0
    BEGIN  
		INSERT INTO #Discovered (Name, Predecessor, OrderDiscovered)
		SELECT e.ToNode, MIN(e.FromNode), MIN(d.OrderDiscovered) + 1
		FROM #Discovered d JOIN dbo.Edge e 
			ON d.Name = e.FromNode
		WHERE e.ToNode NOT IN (SELECT Name From #Discovered)
		GROUP BY e.ToNode
    END;

	WITH BacktraceCTE(Name, OrderDiscovered, NamePath)
	AS
	(
		SELECT n.Name, d.OrderDiscovered, CAST(n.Name AS varchar(MAX))
		FROM #Discovered d JOIN dbo.Node n
			ON d.Name = n.Name
		WHERE d.Name = @StartNode
		
		UNION ALL

		SELECT n.Name, d.OrderDiscovered, cte.NamePath + ' ' + n.Name
		FROM #Discovered d JOIN BacktraceCTE cte
			ON d.Predecessor = cte.Name
		JOIN dbo.Node n ON d.Name = n.Name
	)
	
	SELECT @StartNode, Name, NamePath 
	FROM BacktraceCTE
	WHERE OrderDiscovered > 1
    
    DROP TABLE #Discovered
END
GO

-----------------------
--- BUILDING PATHS ----
-----------------------

CREATE TABLE Paths
(
	Table1 nvarchar(50),
	Table2 nvarchar(50),
	Relation nvarchar(max) NULL,
	TransPath nvarchar(max) NULL
)
GO

CREATE PROCEDURE Create_MetaData
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Paths


	INSERT INTO Paths(Table1, Table2, Relation)
	SELECT 
		FK_TABLE_NAME AS Table1,
		REFERENCED_TABLE_NAME AS Table2,
		(FK_TABLE_NAME + '.' + FK_COLUMN_NAME + 
			' = ' + REFERENCED_TABLE_NAME + '.' + REFERENCED_COLUMN_NAME) AS Relation
	FROM RawMetaData
	
	INSERT INTO Paths(Table1, Table2, Relation)
	SELECT 
		REFERENCED_TABLE_NAME AS Table1,
		FK_TABLE_NAME AS Table2,
		(REFERENCED_TABLE_NAME + '.' + REFERENCED_COLUMN_NAME + 
			' = ' + FK_TABLE_NAME + '.' + FK_COLUMN_NAME) AS Relation
	FROM RawMetaData
	
	DECLARE @TABLE_NAME NVARCHAR(50)
	DECLARE myCursor CURSOR STATIC FOR
		SELECT DISTINCT TABLE_NAME
		FROM INFORMATION_SCHEMA.COLUMNS

	OPEN myCursor
	FETCH NEXT FROM myCursor INTO @TABLE_NAME

	WHILE @@FETCH_STATUS = 0 BEGIN
		INSERT INTO Paths(Table1, Table2, TransPath)
		EXECUTE Breadth_First @TABLE_NAME

		--SELECT * FROM (EXECUTE Breadth_First @TABLE_NAME)

		FETCH NEXT FROM myCursor INTO @TABLE_NAME
	END
	CLOSE myCursor
	DEALLOCATE myCursor
END
GO


----------------
--- TESTING ----
----------------

--EXECUTE Breadth_First 'Boys'

--INSERT INTO Paths(Table1, Table2, TransPath)
--		EXECUTE Breadth_First 'Boys'

EXECUTE Create_MetaData
SELECT * FROM Paths

--EXECUTE Breadth_First 'Paints'


--SELECT * FROM Paths


--DROP PROCEDURE TEST
DROP PROCEDURE Create_MetaData
DROP PROCEDURE Breadth_First

DROP TABLE RawMetaData
--DROP TABLE Paths
DROP TABLE dbo.Edge
DROP TABLE dbo.Node