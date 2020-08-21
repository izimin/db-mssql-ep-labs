namespace Nest
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpFields = new System.Windows.Forms.TabPage();
            this.lbxSelectFields = new System.Windows.Forms.ListBox();
            this.btnAllLeft = new System.Windows.Forms.Button();
            this.btnAllRight = new System.Windows.Forms.Button();
            this.btnDeleteField = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.lbxAllFields = new System.Windows.Forms.ListBox();
            this.lblSelectFields = new System.Windows.Forms.Label();
            this.lblAllFields = new System.Windows.Forms.Label();
            this.tbpConditions = new System.Windows.Forms.TabPage();
            this.dtpExpr = new System.Windows.Forms.DateTimePicker();
            this.lvConditions = new System.Windows.Forms.ListView();
            this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCriter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColExpr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColPredicate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbxPredicate = new System.Windows.Forms.ComboBox();
            this.cbxExpression = new System.Windows.Forms.ComboBox();
            this.btnDelCondition = new System.Windows.Forms.Button();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.cbxCriterion = new System.Windows.Forms.ComboBox();
            this.cbxNameField = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpOrder = new System.Windows.Forms.TabPage();
            this.rbmDesc = new System.Windows.Forms.RadioButton();
            this.rbmASC = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lbxSort = new System.Windows.Forms.ListBox();
            this.btnAllDelFromSort = new System.Windows.Forms.Button();
            this.btnAddAllInSort = new System.Windows.Forms.Button();
            this.btnDelFromSort = new System.Windows.Forms.Button();
            this.btnAddInSort = new System.Windows.Forms.Button();
            this.lbxForSort = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbpResult = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnShowSQL = new System.Windows.Forms.Button();
            this.btnExecuteQuery = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tbpFields.SuspendLayout();
            this.tbpConditions.SuspendLayout();
            this.tbpOrder.SuspendLayout();
            this.tbpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tbpFields);
            this.tbcMain.Controls.Add(this.tbpConditions);
            this.tbcMain.Controls.Add(this.tbpOrder);
            this.tbcMain.Controls.Add(this.tbpResult);
            this.tbcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbcMain.Location = new System.Drawing.Point(13, 12);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(946, 404);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpFields
            // 
            this.tbpFields.Controls.Add(this.lbxSelectFields);
            this.tbpFields.Controls.Add(this.btnAllLeft);
            this.tbpFields.Controls.Add(this.btnAllRight);
            this.tbpFields.Controls.Add(this.btnDeleteField);
            this.tbpFields.Controls.Add(this.btnAddField);
            this.tbpFields.Controls.Add(this.lbxAllFields);
            this.tbpFields.Controls.Add(this.lblSelectFields);
            this.tbpFields.Controls.Add(this.lblAllFields);
            this.tbpFields.Location = new System.Drawing.Point(4, 40);
            this.tbpFields.Name = "tbpFields";
            this.tbpFields.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFields.Size = new System.Drawing.Size(938, 360);
            this.tbpFields.TabIndex = 0;
            this.tbpFields.Text = "Поля";
            this.tbpFields.UseVisualStyleBackColor = true;
            // 
            // lbxSelectFields
            // 
            this.lbxSelectFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxSelectFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxSelectFields.FormattingEnabled = true;
            this.lbxSelectFields.ItemHeight = 20;
            this.lbxSelectFields.Location = new System.Drawing.Point(512, 32);
            this.lbxSelectFields.Name = "lbxSelectFields";
            this.lbxSelectFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxSelectFields.Size = new System.Drawing.Size(420, 304);
            this.lbxSelectFields.TabIndex = 1;
            // 
            // btnAllLeft
            // 
            this.btnAllLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAllLeft.Location = new System.Drawing.Point(448, 220);
            this.btnAllLeft.Name = "btnAllLeft";
            this.btnAllLeft.Size = new System.Drawing.Size(58, 43);
            this.btnAllLeft.TabIndex = 2;
            this.btnAllLeft.Text = "<<";
            this.btnAllLeft.UseVisualStyleBackColor = true;
            this.btnAllLeft.Click += new System.EventHandler(this.btnAllLeft_Click);
            // 
            // btnAllRight
            // 
            this.btnAllRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAllRight.Location = new System.Drawing.Point(448, 171);
            this.btnAllRight.Name = "btnAllRight";
            this.btnAllRight.Size = new System.Drawing.Size(58, 43);
            this.btnAllRight.TabIndex = 2;
            this.btnAllRight.Text = ">>";
            this.btnAllRight.UseVisualStyleBackColor = true;
            this.btnAllRight.Click += new System.EventHandler(this.btnAllRight_Click);
            // 
            // btnDeleteField
            // 
            this.btnDeleteField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteField.Location = new System.Drawing.Point(448, 122);
            this.btnDeleteField.Name = "btnDeleteField";
            this.btnDeleteField.Size = new System.Drawing.Size(58, 43);
            this.btnDeleteField.TabIndex = 2;
            this.btnDeleteField.Text = "<";
            this.btnDeleteField.UseVisualStyleBackColor = true;
            this.btnDeleteField.Click += new System.EventHandler(this.btnDeleteField_Click);
            // 
            // btnAddField
            // 
            this.btnAddField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddField.Location = new System.Drawing.Point(448, 73);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(58, 43);
            this.btnAddField.TabIndex = 2;
            this.btnAddField.Text = ">";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // lbxAllFields
            // 
            this.lbxAllFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxAllFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxAllFields.FormattingEnabled = true;
            this.lbxAllFields.ItemHeight = 20;
            this.lbxAllFields.Location = new System.Drawing.Point(21, 32);
            this.lbxAllFields.Name = "lbxAllFields";
            this.lbxAllFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxAllFields.Size = new System.Drawing.Size(421, 304);
            this.lbxAllFields.TabIndex = 1;
            // 
            // lblSelectFields
            // 
            this.lblSelectFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectFields.AutoSize = true;
            this.lblSelectFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectFields.Location = new System.Drawing.Point(508, 3);
            this.lblSelectFields.Name = "lblSelectFields";
            this.lblSelectFields.Size = new System.Drawing.Size(164, 20);
            this.lblSelectFields.TabIndex = 0;
            this.lblSelectFields.Text = "Выбранные поля";
            // 
            // lblAllFields
            // 
            this.lblAllFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAllFields.AutoSize = true;
            this.lblAllFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllFields.Location = new System.Drawing.Point(26, 3);
            this.lblAllFields.Name = "lblAllFields";
            this.lblAllFields.Size = new System.Drawing.Size(93, 20);
            this.lblAllFields.TabIndex = 0;
            this.lblAllFields.Text = "Все поля";
            // 
            // tbpConditions
            // 
            this.tbpConditions.Controls.Add(this.dtpExpr);
            this.tbpConditions.Controls.Add(this.lvConditions);
            this.tbpConditions.Controls.Add(this.cbxPredicate);
            this.tbpConditions.Controls.Add(this.cbxExpression);
            this.tbpConditions.Controls.Add(this.btnDelCondition);
            this.tbpConditions.Controls.Add(this.btnAddCondition);
            this.tbpConditions.Controls.Add(this.cbxCriterion);
            this.tbpConditions.Controls.Add(this.cbxNameField);
            this.tbpConditions.Controls.Add(this.label7);
            this.tbpConditions.Controls.Add(this.label5);
            this.tbpConditions.Controls.Add(this.label3);
            this.tbpConditions.Controls.Add(this.label1);
            this.tbpConditions.Location = new System.Drawing.Point(4, 40);
            this.tbpConditions.Name = "tbpConditions";
            this.tbpConditions.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConditions.Size = new System.Drawing.Size(938, 360);
            this.tbpConditions.TabIndex = 1;
            this.tbpConditions.Text = "Условия";
            this.tbpConditions.UseVisualStyleBackColor = true;
            // 
            // dtpExpr
            // 
            this.dtpExpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpExpr.Location = new System.Drawing.Point(525, 278);
            this.dtpExpr.Name = "dtpExpr";
            this.dtpExpr.Size = new System.Drawing.Size(293, 27);
            this.dtpExpr.TabIndex = 4;
            this.dtpExpr.Visible = false;
            // 
            // lvConditions
            // 
            this.lvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConditions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColCriter,
            this.ColExpr,
            this.ColPredicate});
            this.lvConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvConditions.FullRowSelect = true;
            this.lvConditions.Location = new System.Drawing.Point(17, 6);
            this.lvConditions.Name = "lvConditions";
            this.lvConditions.RightToLeftLayout = true;
            this.lvConditions.Size = new System.Drawing.Size(909, 245);
            this.lvConditions.TabIndex = 3;
            this.lvConditions.UseCompatibleStateImageBehavior = false;
            this.lvConditions.View = System.Windows.Forms.View.Details;
            // 
            // ColName
            // 
            this.ColName.Text = "Имя поля";
            this.ColName.Width = 300;
            // 
            // ColCriter
            // 
            this.ColCriter.Text = "Критерий";
            // 
            // ColExpr
            // 
            this.ColExpr.Text = "Выражение";
            this.ColExpr.Width = 250;
            // 
            // ColPredicate
            // 
            this.ColPredicate.Text = "Связка";
            this.ColPredicate.Width = 70;
            // 
            // cbxPredicate
            // 
            this.cbxPredicate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPredicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxPredicate.FormattingEnabled = true;
            this.cbxPredicate.Items.AddRange(new object[] {
            "И",
            "ИЛИ"});
            this.cbxPredicate.Location = new System.Drawing.Point(824, 277);
            this.cbxPredicate.Name = "cbxPredicate";
            this.cbxPredicate.Size = new System.Drawing.Size(99, 28);
            this.cbxPredicate.TabIndex = 2;
            // 
            // cbxExpression
            // 
            this.cbxExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxExpression.FormattingEnabled = true;
            this.cbxExpression.Location = new System.Drawing.Point(525, 277);
            this.cbxExpression.Name = "cbxExpression";
            this.cbxExpression.Size = new System.Drawing.Size(293, 28);
            this.cbxExpression.TabIndex = 2;
            // 
            // btnDelCondition
            // 
            this.btnDelCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelCondition.Location = new System.Drawing.Point(778, 318);
            this.btnDelCondition.Name = "btnDelCondition";
            this.btnDelCondition.Size = new System.Drawing.Size(135, 29);
            this.btnDelCondition.TabIndex = 1;
            this.btnDelCondition.Text = "Удалить";
            this.btnDelCondition.UseVisualStyleBackColor = true;
            this.btnDelCondition.Click += new System.EventHandler(this.btnDelCondition_Click);
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCondition.Location = new System.Drawing.Point(623, 318);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(135, 29);
            this.btnAddCondition.TabIndex = 1;
            this.btnAddCondition.Text = "Добавить";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // cbxCriterion
            // 
            this.cbxCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCriterion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxCriterion.FormattingEnabled = true;
            this.cbxCriterion.Location = new System.Drawing.Point(425, 277);
            this.cbxCriterion.Name = "cbxCriterion";
            this.cbxCriterion.Size = new System.Drawing.Size(94, 28);
            this.cbxCriterion.TabIndex = 2;
            // 
            // cbxNameField
            // 
            this.cbxNameField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxNameField.FormattingEnabled = true;
            this.cbxNameField.Location = new System.Drawing.Point(17, 277);
            this.cbxNameField.Name = "cbxNameField";
            this.cbxNameField.Size = new System.Drawing.Size(402, 28);
            this.cbxNameField.TabIndex = 2;
            this.cbxNameField.SelectedIndexChanged += new System.EventHandler(this.cbxNameField_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(820, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Связка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(525, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Выражение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(421, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Критерий";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя поля";
            // 
            // tbpOrder
            // 
            this.tbpOrder.Controls.Add(this.rbmDesc);
            this.tbpOrder.Controls.Add(this.rbmASC);
            this.tbpOrder.Controls.Add(this.label6);
            this.tbpOrder.Controls.Add(this.lbxSort);
            this.tbpOrder.Controls.Add(this.btnAllDelFromSort);
            this.tbpOrder.Controls.Add(this.btnAddAllInSort);
            this.tbpOrder.Controls.Add(this.btnDelFromSort);
            this.tbpOrder.Controls.Add(this.btnAddInSort);
            this.tbpOrder.Controls.Add(this.lbxForSort);
            this.tbpOrder.Controls.Add(this.label2);
            this.tbpOrder.Controls.Add(this.label4);
            this.tbpOrder.Location = new System.Drawing.Point(4, 40);
            this.tbpOrder.Name = "tbpOrder";
            this.tbpOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOrder.Size = new System.Drawing.Size(938, 360);
            this.tbpOrder.TabIndex = 2;
            this.tbpOrder.Text = "Порядок";
            this.tbpOrder.UseVisualStyleBackColor = true;
            // 
            // rbmDesc
            // 
            this.rbmDesc.AutoSize = true;
            this.rbmDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbmDesc.Location = new System.Drawing.Point(826, 149);
            this.rbmDesc.Name = "rbmDesc";
            this.rbmDesc.Size = new System.Drawing.Size(95, 24);
            this.rbmDesc.TabIndex = 12;
            this.rbmDesc.TabStop = true;
            this.rbmDesc.Text = "убыв. ↓";
            this.rbmDesc.UseVisualStyleBackColor = true;
            this.rbmDesc.CheckedChanged += new System.EventHandler(this.rbmDesc_CheckedChanged);
            // 
            // rbmASC
            // 
            this.rbmASC.AutoSize = true;
            this.rbmASC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbmASC.Location = new System.Drawing.Point(826, 116);
            this.rbmASC.Name = "rbmASC";
            this.rbmASC.Size = new System.Drawing.Size(94, 24);
            this.rbmASC.TabIndex = 12;
            this.rbmASC.TabStop = true;
            this.rbmASC.Text = "возр. ↑";
            this.rbmASC.UseVisualStyleBackColor = true;
            this.rbmASC.CheckedChanged += new System.EventHandler(this.rbmASC_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(826, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Порядок";
            // 
            // lbxSort
            // 
            this.lbxSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxSort.FormattingEnabled = true;
            this.lbxSort.ItemHeight = 20;
            this.lbxSort.Location = new System.Drawing.Point(447, 43);
            this.lbxSort.Name = "lbxSort";
            this.lbxSort.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxSort.Size = new System.Drawing.Size(356, 304);
            this.lbxSort.TabIndex = 5;
            this.lbxSort.SelectedIndexChanged += new System.EventHandler(this.lbxSort_SelectedIndexChanged);
            // 
            // btnAllDelFromSort
            // 
            this.btnAllDelFromSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllDelFromSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAllDelFromSort.Location = new System.Drawing.Point(383, 228);
            this.btnAllDelFromSort.Name = "btnAllDelFromSort";
            this.btnAllDelFromSort.Size = new System.Drawing.Size(58, 43);
            this.btnAllDelFromSort.TabIndex = 7;
            this.btnAllDelFromSort.Text = "<<";
            this.btnAllDelFromSort.UseVisualStyleBackColor = true;
            this.btnAllDelFromSort.Click += new System.EventHandler(this.btnAllDelFromSort_Click);
            // 
            // btnAddAllInSort
            // 
            this.btnAddAllInSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddAllInSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddAllInSort.Location = new System.Drawing.Point(383, 179);
            this.btnAddAllInSort.Name = "btnAddAllInSort";
            this.btnAddAllInSort.Size = new System.Drawing.Size(58, 43);
            this.btnAddAllInSort.TabIndex = 8;
            this.btnAddAllInSort.Text = ">>";
            this.btnAddAllInSort.UseVisualStyleBackColor = true;
            this.btnAddAllInSort.Click += new System.EventHandler(this.btnAddAllInSort_Click);
            // 
            // btnDelFromSort
            // 
            this.btnDelFromSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelFromSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelFromSort.Location = new System.Drawing.Point(383, 130);
            this.btnDelFromSort.Name = "btnDelFromSort";
            this.btnDelFromSort.Size = new System.Drawing.Size(58, 43);
            this.btnDelFromSort.TabIndex = 9;
            this.btnDelFromSort.Text = "<";
            this.btnDelFromSort.UseVisualStyleBackColor = true;
            this.btnDelFromSort.Click += new System.EventHandler(this.btnDelFromSort_Click);
            // 
            // btnAddInSort
            // 
            this.btnAddInSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddInSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddInSort.Location = new System.Drawing.Point(383, 81);
            this.btnAddInSort.Name = "btnAddInSort";
            this.btnAddInSort.Size = new System.Drawing.Size(58, 43);
            this.btnAddInSort.TabIndex = 10;
            this.btnAddInSort.Text = ">";
            this.btnAddInSort.UseVisualStyleBackColor = true;
            this.btnAddInSort.Click += new System.EventHandler(this.btnAddInSort_Click);
            // 
            // lbxForSort
            // 
            this.lbxForSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxForSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxForSort.FormattingEnabled = true;
            this.lbxForSort.ItemHeight = 20;
            this.lbxForSort.Location = new System.Drawing.Point(14, 43);
            this.lbxForSort.Name = "lbxForSort";
            this.lbxForSort.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxForSort.Size = new System.Drawing.Size(363, 304);
            this.lbxForSort.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выбранные поля";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(443, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Последовательность сортировки";
            // 
            // tbpResult
            // 
            this.tbpResult.Controls.Add(this.dgvResult);
            this.tbpResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbpResult.Location = new System.Drawing.Point(4, 40);
            this.tbpResult.Name = "tbpResult";
            this.tbpResult.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResult.Size = new System.Drawing.Size(938, 360);
            this.tbpResult.TabIndex = 3;
            this.tbpResult.Text = "Результат";
            this.tbpResult.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 24;
            this.dgvResult.Size = new System.Drawing.Size(932, 354);
            this.dgvResult.TabIndex = 0;
            // 
            // btnShowSQL
            // 
            this.btnShowSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowSQL.Location = new System.Drawing.Point(465, 432);
            this.btnShowSQL.Name = "btnShowSQL";
            this.btnShowSQL.Size = new System.Drawing.Size(135, 38);
            this.btnShowSQL.TabIndex = 1;
            this.btnShowSQL.Text = "Просмотр SQL";
            this.btnShowSQL.UseVisualStyleBackColor = true;
            this.btnShowSQL.Click += new System.EventHandler(this.btnShowSQL_Click);
            // 
            // btnExecuteQuery
            // 
            this.btnExecuteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteQuery.Location = new System.Drawing.Point(624, 432);
            this.btnExecuteQuery.Name = "btnExecuteQuery";
            this.btnExecuteQuery.Size = new System.Drawing.Size(154, 38);
            this.btnExecuteQuery.TabIndex = 1;
            this.btnExecuteQuery.Text = "Выполнить запроc";
            this.btnExecuteQuery.UseVisualStyleBackColor = true;
            this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(798, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 482);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExecuteQuery);
            this.Controls.Add(this.btnShowSQL);
            this.Controls.Add(this.tbcMain);
            this.Name = "MainForm";
            this.Text = "Новый запрос";
            this.tbcMain.ResumeLayout(false);
            this.tbpFields.ResumeLayout(false);
            this.tbpFields.PerformLayout();
            this.tbpConditions.ResumeLayout(false);
            this.tbpConditions.PerformLayout();
            this.tbpOrder.ResumeLayout(false);
            this.tbpOrder.PerformLayout();
            this.tbpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpFields;
        private System.Windows.Forms.Label lblSelectFields;
        private System.Windows.Forms.Label lblAllFields;
        private System.Windows.Forms.TabPage tbpConditions;
        private System.Windows.Forms.TabPage tbpOrder;
        private System.Windows.Forms.TabPage tbpResult;
        private System.Windows.Forms.Button btnAllLeft;
        private System.Windows.Forms.Button btnAllRight;
        private System.Windows.Forms.Button btnDeleteField;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.ListBox lbxSelectFields;
        private System.Windows.Forms.ListBox lbxAllFields;
        private System.Windows.Forms.Button btnShowSQL;
        private System.Windows.Forms.Button btnExecuteQuery;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPredicate;
        private System.Windows.Forms.ComboBox cbxExpression;
        private System.Windows.Forms.Button btnDelCondition;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.ComboBox cbxCriterion;
        private System.Windows.Forms.ComboBox cbxNameField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvConditions;
        private System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader ColCriter;
        private System.Windows.Forms.ColumnHeader ColExpr;
        private System.Windows.Forms.ColumnHeader ColPredicate;
        private System.Windows.Forms.DateTimePicker dtpExpr;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.RadioButton rbmDesc;
        private System.Windows.Forms.RadioButton rbmASC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbxSort;
        private System.Windows.Forms.Button btnAllDelFromSort;
        private System.Windows.Forms.Button btnAddAllInSort;
        private System.Windows.Forms.Button btnDelFromSort;
        private System.Windows.Forms.Button btnAddInSort;
        private System.Windows.Forms.ListBox lbxForSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

