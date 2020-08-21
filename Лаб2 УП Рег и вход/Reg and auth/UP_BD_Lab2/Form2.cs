using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace UP_BD_Lab2
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            btLog_in.Enabled = false;
            passShow.Checked = true;
            tbLogin.Text = RegForm.login;
            tbPassword.Text = RegForm.pass;
        }

        String sConnStr = new SqlConnectionStringBuilder()
        {
            DataSource = "ILYA-PC\\ZIMINS",
            InitialCatalog = "UsersBD",
            IntegratedSecurity = true
        }.ConnectionString;

        private void btLog_in_Click(object sender, EventArgs e)
        {

            using (SqlConnection sConn = new SqlConnection(sConnStr))
            {
                sConn.Open();
                SqlCommand sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT password, salt 
                                    FROM Users 
                                    WHERE login = @curLogin"
                };
                sCommand.Parameters.AddWithValue("@curLogin", tbLogin.Text);

                SqlDataReader reader = sCommand.ExecuteReader();
                if (reader.Read())
                {
                    string passwordHash = (string)reader["password"];
                    string salt = (string)reader["salt"];
                    if (passwordHash == CalcHash(tbPassword.Text + salt))
                    {
                        MessageBox.Show("Вход выполнен");
                        btLog_in.Enabled = false;
                        tbPassword.Text = "";
                        tbLogin.Text = "";
                    }
                    else MessageBox.Show("Неверный пароль");
                }
                else MessageBox.Show("Пользователь с таким логином не найден");
            }
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            SwitchButton();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            SwitchButton();
        }

        private string CalcHash(string text)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }
        
        private void SwitchButton()
        {
            if (tbPassword.TextLength > 0 && tbLogin.TextLength > 0)    
                btLog_in.Enabled = true;
            else btLog_in.Enabled = false;
        }

        private void passShow_CheckedChanged(object sender, EventArgs e)
        {
            if (passShow.Checked == true)
                tbPassword.UseSystemPasswordChar = false;
            else
                tbPassword.UseSystemPasswordChar = true;
        }
    }
}
