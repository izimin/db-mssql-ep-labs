using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            string sControl = new SqlConnectionStringBuilder()
            {
                DataSource = "ILYA-PC\\ZIMINS",  // Имя сервера
                IntegratedSecurity = true,       // Корректно законнектились в виндовс
                InitialCatalog = "Автомобили"    // Задаём имя БД
            }.ConnectionString;

            // Создаём подключение 
            using (SqlConnection sConn = new SqlConnection(sControl))
            {
                sConn.Open();           // Открываем подключение к базе данных
                                        // Создаём команду 
                SqlCommand sCommand = new SqlCommand
                {
                    Connection = sConn,               // Подключение 
                    CommandText = @"SELECT Страна_производитель AS 'country', Название_марки AS 'nameMark', Название_модели  AS 'nameModel', Страны_производители.id AS 'idCountry', Марки_автомобилей.id AS 'idMark'
                                    FROM Страны_производители LEFT OUTER JOIN Марки_автомобилей ON Страны_производители.id = idСтраны_производителя
                                    LEFT OUTER JOIN Модели_автомобилей ON Марки_автомобилей.id = idМарки_автомобиля
                                    ORDER BY country, idCountry, nameMark, idMark, NEWID()"
                };

                SqlDataReader reader = sCommand.ExecuteReader();
                TreeNode lastCountryNode = new TreeNode();
                TreeNode lastNameMark = new TreeNode();
                int lastCountryId = -1;
                int lastIdMark = -1;

                while (reader.Read())
                {
                    string country = (string)reader["country"];
                    int idCountry = (int)reader["idCountry"];
                    if (idCountry != lastCountryId)
                    {
                        lastCountryNode = tvAuto.Nodes.Add(country);
                        lastCountryId = idCountry;
                    }

                    if (reader["nameMark"] is DBNull) continue;
                    string nameMark = (string)reader["nameMark"];
                    int idMark = (int)reader["idMark"];

                    if (idMark != lastIdMark)
                    {
                        lastNameMark = lastCountryNode.Nodes.Add(nameMark);
                        lastIdMark = idMark;
                    }

                    if (reader["nameModel"] is DBNull) continue;
                    string  nameModel = (string)reader["nameModel"];

                    lastNameMark.Nodes.Add(nameModel);
                }
            }
        }

        private void tvAuto_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level != 0) return;
            e.Node.Text = e.Node.Text.Split(' ')[0];
        }

        private void tvAuto_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level != 0) return;
            int count = 0;
            foreach (TreeNode elem in e.Node.Nodes)
            {
                if (elem.Nodes.Count > 0) count++;
            }
            e.Node.Text += " - " + count + "/" + (e.Node.Nodes.Count - count);
        }
    }
}