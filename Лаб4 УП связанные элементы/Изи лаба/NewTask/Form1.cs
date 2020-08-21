using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автомобилиDataSet.Модели_автомобилей". При необходимости она может быть перемещена или удалена.
            this.модели_автомобилейTableAdapter.Fill(this.автомобилиDataSet.Модели_автомобилей);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автомобилиDataSet.Марки_автомобилей". При необходимости она может быть перемещена или удалена.
            this.марки_автомобилейTableAdapter.Fill(this.автомобилиDataSet.Марки_автомобилей);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автомобилиDataSet.Страны_производители". При необходимости она может быть перемещена или удалена.
            this.страны_производителиTableAdapter.Fill(this.автомобилиDataSet.Страны_производители);

        }
    }
}
