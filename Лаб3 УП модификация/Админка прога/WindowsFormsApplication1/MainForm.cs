using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        readonly string _sConnStr = new SqlConnectionStringBuilder
        {
            DataSource = "ZIMINS\\ZIMINS",
            InitialCatalog = "UsersBD",
            IntegratedSecurity = true
        }.ConnectionString;

        public MainForm()
        {
            InitializeComponent();
            InitializeLvUsers();
        }

        private void InitializeLvUsers()
        {
            lvUsers.Columns.Add("Логин");
            lvUsers.Columns.Add("Пароль");
            lvUsers.Columns.Add("Дата регистрации");
            using (var sConn = new SqlConnection(_sConnStr))
            {
                sConn.Open();
                var sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT login, password, registerDate
                                    FROM Users"
                };

                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        (string) reader["login"],
                        (string) reader["password"],
                        ((DateTime) reader["registerDate"]).ToLongDateString()
                    })
                    { Tag = (DateTime)reader["registerDate"] };

                    lvUsers.Items.Add(lvi);
                }
                lvUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserUpdate frmUserInsert = new UserUpdate(UserUpdate.State.Insert, _sConnStr);
            if (frmUserInsert.ShowDialog() == DialogResult.OK)
            {
                using (var sConn = new SqlConnection(_sConnStr))
                {
                    sConn.Open();
                    var sCommand = new SqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"INSERT INTO Users (login, password, salt, registerDate)
                                        VALUES (@Login, @Password, @Salt, @RegistrationDate)"
                    };

                    var salt = GenerateSalt();
                    var password = CalcHash(frmUserInsert.Passwprd + salt);
                    var login = frmUserInsert.Login;

                    sCommand.Parameters.AddWithValue("@Login", login);
                    sCommand.Parameters.AddWithValue("@Password", password);
                    sCommand.Parameters.AddWithValue("@Salt", salt);
                    sCommand.Parameters.AddWithValue("@RegistrationDate", frmUserInsert.RegistrationDate);   
                                     
                    string curLogin = (string)sCommand.ExecuteScalar();

                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        frmUserInsert.Login,
                        password,
                        frmUserInsert.RegistrationDate.ToLongDateString()
                    })
                    { Tag = frmUserInsert.RegistrationDate };
                    lvUsers.Items.Add(lvi);
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sConn = new SqlConnection(_sConnStr))
            {
                sConn.Open();
                var sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"DELETE FROM Users WHERE login = @Login"
                };
                foreach (ListViewItem selectedItem in lvUsers.SelectedItems)
                {
                    sCommand.Parameters.Clear();
                    sCommand.Parameters.AddWithValue("@Login", selectedItem.SubItems[0].Text);
                    sCommand.ExecuteNonQuery();
                    lvUsers.Items.Remove(selectedItem);
                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserUpdate frmUserUpdate = new UserUpdate(UserUpdate.State.Update, _sConnStr);
            foreach (ListViewItem selectedItem in lvUsers.SelectedItems)
            {
                var oldLogin = selectedItem.SubItems[0].Text;

                frmUserUpdate.Login = oldLogin;
                frmUserUpdate.Passwprd = "";
                frmUserUpdate.RegistrationDate = (DateTime)selectedItem.Tag;
                frmUserUpdate.BtOk = true;
                            
                string password = "";

                if (frmUserUpdate.ShowDialog() == DialogResult.OK)
                {
                    using (var sConn = new SqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        SqlCommand sCommand;

                        if (frmUserUpdate.Passwprd == "")
                        {
                            sCommand = new SqlCommand
                            {
                                Connection = sConn,
                                CommandText = @"UPDATE Users SET login = @Login, registerDate = @RegistrationDate
                                               WHERE  login = @oldLogin"
                            };                  
                        }
                        else
                        {
                            sCommand = new SqlCommand
                            {
                                Connection = sConn,
                                CommandText = @"UPDATE Users SET login = @Login, password = @Password, 
                                                                 salt = @Salt,  registerDate = @RegistrationDate
                                               WHERE  login = @oldLogin"
                            };
                            var salt = GenerateSalt();
                            password = CalcHash(frmUserUpdate.Passwprd + salt);

                            sCommand.Parameters.AddWithValue("@Password", password);
                            sCommand.Parameters.AddWithValue("@Salt", salt);
                        }
                        sCommand.Parameters.AddWithValue("@oldLogin", oldLogin);
                        sCommand.Parameters.AddWithValue("@Login", frmUserUpdate.Login);
                        sCommand.Parameters.AddWithValue("@RegistrationDate", frmUserUpdate.RegistrationDate);

                        sCommand.ExecuteNonQuery();

                        selectedItem.SubItems[0].Text = frmUserUpdate.Login;
                        if (password != "") selectedItem.SubItems[1].Text = password;
                        selectedItem.SubItems[2].Text = frmUserUpdate.RegistrationDate.ToLongDateString();
                        lvUsers.Tag = frmUserUpdate.RegistrationDate;
                    }
                }
            }
        }

        private string GenerateSalt()
        {
            int saltSize = 20;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[saltSize];
            rng.GetBytes(buff);
            return BitConverter.ToString(buff).Replace("-", "");
        }

        private string CalcHash(string text)
        {
            using (SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(SHA1.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

    }
}
