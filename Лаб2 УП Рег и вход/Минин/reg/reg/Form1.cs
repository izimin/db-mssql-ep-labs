using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace reg
{
    public partial class RegForm : Form
    {
        String sConnStr = new SqlConnectionStringBuilder
        {
            DataSource = @".",
            InitialCatalog = "users_bd",
            IntegratedSecurity = true
        }.ConnectionString;

        public RegForm()
        {
            InitializeComponent();
            btOk.Enabled = false;
            this.MaximizeBox = false;
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (tvLogin.TextLength > 0 && tvPassword.TextLength > 0)
            {
                using (SqlConnection sConn = new SqlConnection(sConnStr))
                {
                    sConn.Open();
                    SqlCommand sCommand = new SqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"INSERT INTO Users(login, password, date, salt)
                                            VALUES (@currentLogin, @currentPassword, @currentDate, @currentSalt)"
                    };
                    string salt = createSalt();
                    sCommand.Parameters.AddWithValue("currentLogin", tvLogin.Text);
                    sCommand.Parameters.AddWithValue("currentPassword", createHash(tvPassword.Text + salt));
                    sCommand.Parameters.AddWithValue("currentDate", DateTime.Today);
                    sCommand.Parameters.AddWithValue("currentSalt", salt);

                    if (sCommand.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Вы зарегистрированы");
                        btOk.Enabled = false;
                        tvPassword.Text = "";
                        tvLogin.Text = "";
                    }
                }
            }
        }

        private string createSalt()
        {
            int length = 20;
            StringBuilder builder = new StringBuilder();
            // RNGCryptoServiceProvider
            Random random = new Random();
            char ch;
            for (int i = 0; i < length; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        private string createHash(string text)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

        private void tvLogin_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection sConn = new SqlConnection(sConnStr))
            {
                sConn.Open();
                SqlCommand sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT COUNT(*) ID FROM Users WHERE login = @currentLogin"
                };
                sCommand.Parameters.AddWithValue("@currentLogin", tvLogin.Text);
                if ((int)sCommand.ExecuteScalar() > 0)
                {
                    errorProvider.SetError(tvLogin, "Логин занят");
                    btOk.Enabled = false;
                }
                else
                {
                    errorProvider.SetError(tvLogin, "");
                    CheckData();
                }
            }
        }

        private void tvPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(tvPassword, "");
            CheckData();
        }

        private void CheckData()
        {
            if (tvPassword.TextLength > 0 && tvLogin.TextLength > 0 && 
                errorProvider.GetError(tvLogin) == "" && errorProvider.GetError(tvPassword) == "")
                btOk.Enabled = true;
            else
                btOk.Enabled = false;
        }
    }
}
