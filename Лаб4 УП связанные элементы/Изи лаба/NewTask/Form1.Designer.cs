namespace NewTask
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.автомобилиDataSet = new NewTask.АвтомобилиDataSet();
            this.страныПроизводителиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.страны_производителиTableAdapter = new NewTask.АвтомобилиDataSetTableAdapters.Страны_производителиTableAdapter();
            this.fKМаркиАвтомобилейСтраныПроизводителиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.марки_автомобилейTableAdapter = new NewTask.АвтомобилиDataSetTableAdapters.Марки_автомобилейTableAdapter();
            this.fKМоделиАвтомобилейМаркиАвтомобилейBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.модели_автомобилейTableAdapter = new NewTask.АвтомобилиDataSetTableAdapters.Модели_автомобилейTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.автомобилиDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.страныПроизводителиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKМаркиАвтомобилейСтраныПроизводителиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKМоделиАвтомобилейМаркиАвтомобилейBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.страныПроизводителиBindingSource;
            this.comboBox1.DisplayMember = "Страна производитель";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(39, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Страна производитель";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.fKМаркиАвтомобилейСтраныПроизводителиBindingSource;
            this.comboBox2.DisplayMember = "Название марки";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(39, 108);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.ValueMember = "Название марки";
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.fKМоделиАвтомобилейМаркиАвтомобилейBindingSource;
            this.comboBox3.DisplayMember = "Название модели";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(39, 155);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 0;
            this.comboBox3.ValueMember = "Название модели";
            // 
            // автомобилиDataSet
            // 
            this.автомобилиDataSet.DataSetName = "АвтомобилиDataSet";
            this.автомобилиDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // страныПроизводителиBindingSource
            // 
            this.страныПроизводителиBindingSource.DataMember = "Страны производители";
            this.страныПроизводителиBindingSource.DataSource = this.автомобилиDataSet;
            // 
            // страны_производителиTableAdapter
            // 
            this.страны_производителиTableAdapter.ClearBeforeFill = true;
            // 
            // fKМаркиАвтомобилейСтраныПроизводителиBindingSource
            // 
            this.fKМаркиАвтомобилейСтраныПроизводителиBindingSource.DataMember = "FK_Марки автомобилей_Страны производители";
            this.fKМаркиАвтомобилейСтраныПроизводителиBindingSource.DataSource = this.страныПроизводителиBindingSource;
            // 
            // марки_автомобилейTableAdapter
            // 
            this.марки_автомобилейTableAdapter.ClearBeforeFill = true;
            // 
            // fKМоделиАвтомобилейМаркиАвтомобилейBindingSource
            // 
            this.fKМоделиАвтомобилейМаркиАвтомобилейBindingSource.DataMember = "FK_Модели автомобилей_Марки автомобилей";
            this.fKМоделиАвтомобилейМаркиАвтомобилейBindingSource.DataSource = this.fKМаркиАвтомобилейСтраныПроизводителиBindingSource;
            // 
            // модели_автомобилейTableAdapter
            // 
            this.модели_автомобилейTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 329);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.автомобилиDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.страныПроизводителиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKМаркиАвтомобилейСтраныПроизводителиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKМоделиАвтомобилейМаркиАвтомобилейBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private АвтомобилиDataSet автомобилиDataSet;
        private System.Windows.Forms.BindingSource страныПроизводителиBindingSource;
        private АвтомобилиDataSetTableAdapters.Страны_производителиTableAdapter страны_производителиTableAdapter;
        private System.Windows.Forms.BindingSource fKМаркиАвтомобилейСтраныПроизводителиBindingSource;
        private АвтомобилиDataSetTableAdapters.Марки_автомобилейTableAdapter марки_автомобилейTableAdapter;
        private System.Windows.Forms.BindingSource fKМоделиАвтомобилейМаркиАвтомобилейBindingSource;
        private АвтомобилиDataSetTableAdapters.Модели_автомобилейTableAdapter модели_автомобилейTableAdapter;
    }
}

