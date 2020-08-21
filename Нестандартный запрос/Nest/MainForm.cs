using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Nest
{
    
    public partial class MainForm : Form
    {
        private class Column
        {
            public string NameTable { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }

            public static Dictionary<string, string> FriendlyNames;

            public string DisplayName
            {
                get
                {
                    var qName = FullColumnName;
                    return FriendlyNames.ContainsKey(qName) ? FriendlyNames[qName] : qName;
                }
            }

            public string FullColumnName => $"[{NameTable}].[{Name}]";

            public override string ToString()
            {
                return DisplayName;
            }
        }
        static readonly string InitialCatalog = Properties.Settings.Default.ProjectInitialCatalog;

        Dictionary<string, string> sortList = new Dictionary<string, string>();
            //  Лист соедеиненных напрямую таблиц
            Dictionary<Tuple<string, string>, string> straightJoinsDict = new Dictionary<Tuple<string, string>, string>();
            // Лист с промежуточными соединениями 
            Dictionary<Tuple<string, string>, string> notStraightJoinDict = new Dictionary<Tuple<string, string>, string>();

        // Список полей
        List<Column> fields = new List<Column>();
        // Список сортируемых полей 

        // Строка подключения
        private readonly string _sConnStr = new SqlConnectionStringBuilder
        {
            // Берем параметры из конфигурационного файла
            DataSource = Properties.Settings.Default.ProjectDataSource,
            InitialCatalog = InitialCatalog,
            IntegratedSecurity = true
        }.ConnectionString;

        // Конструктор формы
        public MainForm()
        {
            InitializeComponent();
            // Инициализирует данные на форме
            InitializeData();
            dgvResult.Font = DefaultFont;
            cbxPredicate.SelectedIndex = 0;
        }

        private void InitializeData()
        {
            using (var sConn = new SqlConnection(_sConnStr))
            {
                sConn.Close();
                sConn.Open();

                // Считываем вспомогательную таблицу связей
                var sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT * FROM [_Reltable]"
                };

                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var table1 = (string) reader["Table1"];
                    var table2 = (string) reader["Table2"];
                    var relation = reader["Relations"] as string;
                    var via = reader["Via"] as string;

                    // Если соеденины не на прямую
                    if (relation == null)
                    {
                        notStraightJoinDict[Tuple.Create(table1, table2)] = via;
                        notStraightJoinDict[Tuple.Create(table2, table1)] = via;
                    }
                    else
                    {
                        straightJoinsDict[Tuple.Create(table1, table2)] = relation;
                        straightJoinsDict[Tuple.Create(table2, table1)] = relation;
                    }
                }
                reader.Close();

                // Запрос на получение данных из самой БД 
                sCommand.CommandText = @"SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE
                                        FROM INFORMATION_SCHEMA.COLUMNS
                                        WHERE TABLE_NAME 

                                            <> 'sysdiagrams' AND
                                            TABLE_NAME <> '_Reltable' AND
                                            TABLE_NAME <> '_Fields'";
                reader = sCommand.ExecuteReader();
                reader.Read();
                Column.FriendlyNames = new Dictionary<string, string>();
                // Заполняем данные о столбцах
                while (reader.Read())
                    fields.Add(new Column()
                    {
                        NameTable = (string)reader["TABLE_NAME"],               // Таблица в которой находится
                        Name = (string)reader["COLUMN_NAME"],             // Имя
                        Type = (string)reader["DATA_TYPE"]                  // Тип
                    });
                reader.Close();

                // Проверка на существование таблицы _Fields
                sCommand.CommandText = @"IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '_Fields'))
                                            SELECT 'true'
                                         ELSE SELECT 'false'";
                var isFields = bool.Parse((string)sCommand.ExecuteScalar());

                // Если такая таблица есть 
                if (isFields)
                {
                    sCommand.CommandText = @"SELECT Field_name, Table_name, Transl_fn, Catergory_name FROM _Fields";
                    reader = sCommand.ExecuteReader();

                    while (reader.Read())
                    {

                        var field = (string) reader["Field_name"];
                        var friendlyField = (string) reader["Catergory_name"];
                        
                        var table = (string) reader["Table_name"];

                        var translate = (string) reader["Transl_fn"] + " (" + friendlyField + ")";

                        var qwName = "[" + table + "].[" + field + "]";
                        Column.FriendlyNames[qwName] = translate;
                    }
                }
            }

            InitializellLists();
        }

        private void InitializellLists()
        {
            var lastTable = "";
            foreach (var field in fields)
            {
                if (field.NameTable != lastTable)
                    lbxAllFields.Items.Add("-----" + field.NameTable.ToUpper() + "------");
                lbxAllFields.Items.Add(field);
                cbxNameField.Items.Add(field);
                lastTable = field.NameTable;
            }
        }

        private List<string> GetJoinConditions(List<string> tablesForJoin, out List<string> allTables)
        {
            allTables = new List<string>();
            if (tablesForJoin.Count == 0) return null;

            var firstTable = tablesForJoin.First();

            if (tablesForJoin.Count == 1)
            {
                allTables.Add(firstTable);
                return new List<string>();
            }

            var joins = new List<string>();
            var visited = new HashSet<string> { firstTable };

            for (var i = 1; i < tablesForJoin.Count; i++)
            {
                var table = tablesForJoin[i];
                visited.Add(table);
                var tuple = Tuple.Create(firstTable, table);
                if (straightJoinsDict.ContainsKey(tuple))
                {
                    var relation = straightJoinsDict[tuple];
                    if (!joins.Contains(relation))
                        joins.Add(relation);
                }
                else
                {
                    if (!notStraightJoinDict.ContainsKey(tuple))
                        throw new Exception("Таблицы не связаны!");

                    var lol = "";
                    var midTable = notStraightJoinDict[tuple];
                    lol = straightJoinsDict.ContainsKey(Tuple.Create(tuple.Item1, midTable)) 
                        ? CreatePath(Tuple.Create(tuple.Item1, midTable), tuple.Item2) 
                        : CreatePath(Tuple.Create(tuple.Item2, midTable), tuple.Item1);

                    var transTables = lol.Split();

                    for (var j = 0; j < transTables.Length - 1; j++)
                    {
                        var t1 = transTables[j];
                        var t2 = transTables[j + 1];
                        var relation = straightJoinsDict[Tuple.Create(t1, t2)];
                        visited.Add(t2);

                        if (!joins.Contains(relation))
                        {
                            joins.Add(relation);
                        }
                    }
                }
            }

            allTables = visited.ToList();
            return joins;
        }

        string CreatePath(Tuple<string, string> tuple,  string finishTable)
        {
            var curTuple = Tuple.Create(tuple.Item2, finishTable);
            if (!notStraightJoinDict.ContainsKey(curTuple)) return tuple.Item1 + " " + tuple.Item2 + " " + finishTable;
            return tuple.Item1 + " " + CreatePath(Tuple.Create(tuple.Item2, notStraightJoinDict[curTuple]), finishTable);
        }


        // Создаем запрос
        private Tuple<SqlCommand, string> CreateQuerry()
        {
            var querry = "";

            // Если листбокс с выбранными элементами пуст 
            if (lbxSelectFields.Items.Count == 0)
            {
                throw new Exception("Не выбрано ни одно поле!");
            }

            // Создаем комманду 
            var sCommand = new SqlCommand {CommandText = "SELECT DISTINCT "};

            // Преобразуем все элементы с листа выбранных в список столбцов 
            var items = lbxSelectFields.Items.Cast<Column>().ToList();
            // 
            var columns = items.Select(t => t.FullColumnName + " as '" + t.DisplayName + "'").Distinct().ToList();
            var tables = items.Select(t => t.NameTable).Distinct().ToList();

            foreach (ListViewItem row in lvConditions.Items)
            {
                Column clmn = null;
                foreach (var item in fields)
                {
                    if (item.DisplayName == row.SubItems[0].Text)
                        clmn = item;
                }

                tables.Add(clmn.NameTable);
            }

            tables = tables.Distinct().ToList();

            // 
            var joinConditions = GetJoinConditions(tables, out var allTables);

            // Цепляем к селекту списо  к всех столбцов через запятую 
            sCommand.CommandText += string.Join(", ", columns);

            // Затем цепляем  форм со списком используемых таблиц
            sCommand.CommandText += " FROM " + string.Join(", ", allTables);

            // Список строки условия с параметром 
            var conditionsParam = new List<string>();
            // Список условий без параметров 
            var conditions = new List<string>();

            //
            // Условия
            //
            // Пробегает по всем строкам условий 
            foreach (ListViewItem row in lvConditions.Items)
            {
                // Ищем стобец во всем списке полей, соответствующий текущему полю в условии 
                Column column = null;
                foreach (var item in fields)
                    if (item.DisplayName == row.SubItems[0].Text)
                        column = item;

                // Берем критерий из строки условий
                var criterion = row.SubItems[1].Text;
                // Берем выражение из строки условий 
                object value = row.SubItems[2].Text;
                // Берем предикат из строки условий 
                var predicate = row.SubItems[3].Text;

                // Заменяем на соответствующее английское слово
                switch (predicate)
                {
                    case "ИЛИ":
                        predicate = "OR";
                        break;
                    case "И":
                        predicate = "AND";
                        break;
                }

                // Создаем перерменную параметр 
                var paramName = "@param" + lvConditions.Items.IndexOf(row);
                if (lvConditions.Items.IndexOf(row) == lvConditions.Items.Count - 1)
                    predicate = "";
                // Добавляем в список условий с параметрами  
                conditionsParam.Add($"{column.FullColumnName} {criterion} {paramName} {predicate}");
                // Добавляем в список условий без параметров 
                conditions.Add($"{column.FullColumnName} {criterion} '{value}' {predicate}");
                // В комманде придем параметру значение 
                sCommand.Parameters.AddWithValue(paramName, value);
            }

            //
            // Сортировка
            //

            //  Лист для сортировки
            var orderList = new List<string>();
            // Проходим по полям листбокса сортировки
            foreach (var item in lbxSort.Items)
            {
                var field = (Column) item;
                // sortList[field.DisplayName] = либо ASC либо DESC
                orderList.Add(field.FullColumnName + sortList[field.DisplayName]);
            }


            var allConditionsParam = new List<string>();
            var allConditions = new List<string>();
            querry = sCommand.CommandText;


            if (joinConditions.Any())
            {
                for (var i = 0; i < joinConditions.Count - 1; i++)
                    joinConditions[i] = joinConditions[i] + " AND ";

                if (conditionsParam.Any())
                    joinConditions[joinConditions.Count - 1] += " AND ";

                allConditionsParam.AddRange(joinConditions);
                allConditions.AddRange(joinConditions);
            }


            if (conditionsParam.Any())
            {
                allConditionsParam.Add("(");
                allConditions.Add("(");

                allConditionsParam.AddRange(conditionsParam);
                allConditions.AddRange(conditions);

                allConditionsParam.Add(")");
                allConditions.Add(")");
            }


            if (allConditionsParam.Any())
            {
                sCommand.CommandText += " WHERE " + string.Join(" ", allConditionsParam);
                querry += " WHERE " + string.Join(" ", allConditions);
            }

            // Если в листе для сортировки есть что нибудь, тогда добаляем ORDER BY и поля сортировки
            if (orderList.Any())
            {
                sCommand.CommandText += " ORDER BY " + string.Join(", ", orderList);
                querry += " ORDER BY " + string.Join(", ", orderList);
            }
        
        // Возвращаем готовую комманду
            return Tuple.Create(sCommand, querry);
        }

        #region Элементы со вкладки "Условие"
        //
        // Обработчик изменения выделенного элемента в комбобоксе
        //
        private void cbxNameField_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очищаем комбобокс критериев (нужно, к примеру, если после числового выбрали текстовое поле)
            cbxCriterion.Items.Clear();

            // Преобразуем имя поля к типу столбца
            var curColumn = (Column)cbxNameField.SelectedItem;
            var curType = curColumn.Type;
            // В зависимости от типа, заполняем комбобокс критериев
            switch (curType)
            {
                case "date":
                case "datetime":
                    dtpExpr.Visible = true;
                    cbxExpression.Visible = false;
                    cbxCriterion.Items.AddRange(new object[] { "<", ">", "=", "<>" });
                    break;
                case "int":
                case "real":
                case "float":
                    dtpExpr.Visible = false;
                    cbxExpression.Visible = true;
                    cbxCriterion.Items.AddRange(new object[] { "<", ">", "=", "<>" });
                    break;
                case "nvarchar":
                case "varchar":
                case "nchar":
                case "char":
                    dtpExpr.Visible = false;
                    cbxExpression.Visible = true;
                    cbxCriterion.Items.AddRange(new object[] { "=", "<>", "LIKE"});
                    break;
                default: MessageBox.Show(@"Тип данного столбца еще не обработан"); break;
            }

            using (var sConn = new SqlConnection(_sConnStr))
            {
                sConn.Open();
                var qName = curColumn.FullColumnName;
                var table = curColumn.NameTable;
                var column = curColumn.Name;

                // Берем из БД данные которые уже есть в этом столбце
                var sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT DISTINCT" + qName + " " + "FROM " + table
                };

                var reader = sCommand.ExecuteReader();
                var dataInColumns = new List<string>();

                while (reader.Read())
                {
                    var vItem = reader[column].ToString();
                    dataInColumns.Add(vItem);
                }

                // Очищаем комбобокс выражений и добавляем туда новые выражения
                cbxExpression.Items.Clear();
                cbxExpression.Items.AddRange(dataInColumns.ToArray());
            }
        }

        //
        // Добавление условия 
        //
        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            if (lvConditions.Items.Count > 0 && lvConditions.Items[lvConditions.Items.Count - 1].SubItems[3].Text == "")
            {
                MessageBox.Show(@"Нет связки между условиями!", @"Неудача");
                return;
            }

            if (cbxNameField.Text == "")
            {
                MessageBox.Show(@"Выберите имя поля!", @"Неудача");
                return;
            }

            if (cbxCriterion.Text == "")
            {
                MessageBox.Show(@"Выберите критерий!", @"Неудача");
                return;
            }

            if (cbxExpression.Text == "" )
            {
                if (dtpExpr.Visible != true)
                {
                    MessageBox.Show(@"Заполните поле ""выражение""!", @"Неудача");
                    return;
                }
                else cbxExpression.Text = dtpExpr.Value.ToShortDateString();
            }
            Column column = null;
            foreach (var item in fields)
                if (item.DisplayName == cbxNameField.Text)
                    column = item;
            if (column.Type == "int" && !Int32.TryParse(cbxExpression.Text, out var r))
            {
                MessageBox.Show(@"Поле ""выражение"" имеет неверный тип!", @"Неудача");
                return;
            }

            if ((column.Type == "real" || column.Type == "float") && !Int32.TryParse(cbxExpression.Text, out var rr))
            {
                MessageBox.Show(@"Поле ""выражение"" имеет неверный!", @"Неудача");
                return;
            }

            if (dtpExpr.Visible) cbxExpression.Text = (DateTime.Parse(dtpExpr.Text)).ToShortDateString();
            lvConditions.Items.Add(new ListViewItem(new[]
            {
                cbxNameField.Text, cbxCriterion.Text, cbxExpression.Text, cbxPredicate.Text
            }));
        }

        //
        // Удаление выделенных условий
        //
        private void btnDelCondition_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in lvConditions.SelectedItems)
                lvConditions.Items.Remove(selectedItem);
        }
        #endregion

        #region Элементы со вкладки "Поля"

        //
        // Добавление выделенных полей в выбранные 
        //
        private void btnAddField_Click(object sender, EventArgs e)
        {
            foreach (var item in lbxAllFields.SelectedItems)
            {
                if (lbxSelectFields.Items.IndexOf(item) != -1 || item.ToString()[0] == '-') continue;
                lbxSelectFields.Items.Add(item);
                lbxForSort.Items.Add(item);
            }
        }

        //
        // Удаление выделенных полей из выбранных
        //
        private void btnDeleteField_Click(object sender, EventArgs e)
        {
            var delElems = lbxSelectFields.SelectedItems;

            for (int i = 0; i < delElems.Count; i++)
            {
                lbxSort.Items.Remove(delElems[i]);
                lbxForSort.Items.Remove(delElems[i]);
                lbxSelectFields.Items.Remove(delElems[i]);
            }
        }

        //
        // Добавление всех полей в выбранные 
        //
        private void btnAllRight_Click(object sender, EventArgs e)
        {
            lbxSelectFields.Items.Clear();
            foreach (var item in lbxAllFields.Items)
            {
                if (lbxSelectFields.Items.IndexOf(item) != -1 || item.ToString()[0] == '-') continue;
                lbxSelectFields.Items.Add(item);
                lbxForSort.Items.Add(item);
            }
        }

        //
        // Удаление всех полей из выбранных
        //
        private void btnAllLeft_Click(object sender, EventArgs e)
        {
            lbxSelectFields.Items.Clear();
            lbxSort.Items.Clear();
            lbxForSort.Items.Clear();
        }
        #endregion

        #region Элементы со вкладки "Порядок"

        //
        // Добавление выделенных элементов в лист сортировки 
        //
        private void btnAddInSort_Click(object sender, EventArgs e)
        {
            foreach (var item in lbxForSort.SelectedItems)
            {
                if (lbxSort.Items.IndexOf(item) != -1) continue;
                lbxSort.Items.Add(item);
                sortList.Add(item.ToString(), " ASC ");
            }
        }

        //
        // Удаление выделенных эементов с листа сортировки 
        //
        private void btnDelFromSort_Click(object sender, EventArgs e)
        {
            var delElems = lbxSort.SelectedItems;

            for (var i = 0; i < delElems.Count; i++)
            { 
                var clmn = (Column) delElems[i];
                sortList.Remove(clmn.DisplayName);
                lbxSort.Items.Remove(delElems[i]);
            }
        }

        //
        // Добавление всех элементов на лист сортировки 
        //
        private void btnAddAllInSort_Click(object sender, EventArgs e)
        {
            sortList.Clear();
            lbxSort.Items.Clear();
            foreach (var item in lbxForSort.Items)
            {
                //if (lbxSort.Items.IndexOf(item) != -1) continue;
                lbxSort.Items.Add(item);
                sortList.Add(item.ToString(), " ASС ");
            }
        }

        //
        // Удалеине всех элементов с листа сортировки
        //
        private void btnAllDelFromSort_Click(object sender, EventArgs e)
        {
            lbxSort.Items.Clear();
            sortList.Clear();
        }

        //
        // Обработчик выделениея строки на листе сортировки
        //
        private void lbxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxSort.SelectedItem == null) return;
            // Изменяем положиение буттона 
            if (sortList[lbxSort.SelectedItem.ToString()] == " DESC ") rbmDesc.Checked = true;
            else rbmASC.Checked = true;
        }
        
        //
        // Обработчик изменения буттона возрастания 
        //
        private void rbmASC_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbmASC.Checked) return;
            foreach (var item in lbxSort.SelectedItems)
                sortList[item.ToString()] = " ASC ";
        }

        //
        // Обработчик изменения буттона убывания 
        //
        private void rbmDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbmDesc.Checked) return;
            foreach (var item in lbxSort.SelectedItems)
                sortList[item.ToString()] = " DESC ";
        }
        #endregion

        #region Общие кнопки
        //
        // Обработчик кнопки "Показать SQL"
        //
        private void btnShowSQL_Click(object sender, EventArgs e)
        {
            // Объявляем комманду
            SqlCommand sCommand = null;
            Tuple<SqlCommand, string> resTuple;
            try
            {
                // Формируем строку запроса
                resTuple = CreateQuerry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            sCommand = resTuple.Item1;
            if (sCommand == null)
            {
                MessageBox.Show(@"Не выбрано ни одно поле!");
                return;
            }

            // Выводим бокс со строкой запроса
            MessageBox.Show(resTuple.Item2);
        }

        //
        // Обраблтчик кнопки "Выполнить запрос"
        //
        private void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            using (var sConn = new SqlConnection(_sConnStr))
            {
                // Объявляем комманду
                SqlCommand sCommand;
                Tuple<SqlCommand, string> resTuple;
                try
                {
                    // Формируем строку запроса
                    resTuple = CreateQuerry();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                sCommand = resTuple.Item1;
                sCommand.Connection = sConn;

                // Показываем строку запроса  
                MessageBox.Show(resTuple.Item2);
                sConn.Open();

                // Создаем таблицу для результата 
                var table = new DataTable();
                // Заполняем из запроса 
                try
                {
                    table.Load(sCommand.ExecuteReader());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                dgvResult.DataSource = table;

                // Переходим на вкладку "Результат"
                tbcMain.SelectedTab = tbpResult;
            }
        }

        //
        // Обработчки нажатия книпки "Закрыть"
        //
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
