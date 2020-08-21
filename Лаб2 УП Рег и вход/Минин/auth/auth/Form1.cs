using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace auth
{
    public partial class Auth : Form
    {
        string err_tit = "ОШИБКА";
        String sConnStr = new SqlConnectionStringBuilder
        {
            DataSource = @".",
            InitialCatalog = "users_bd",
            IntegratedSecurity = true
        }.ConnectionString;
        public Auth()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            btOk.Enabled = false;
        }

        private void tvLogin_TextChanged(object sender, EventArgs e)
        {
            ClearErr();
            CheckData();
        }

        private void tvPassword_TextChanged(object sender, EventArgs e)
        {
            ClearErr();
            CheckData();
        }

        private string createHash(string text)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            using (SqlConnection sConn = new SqlConnection(sConnStr))
            {
                sConn.Open();
                SqlCommand sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT password, salt FROM Users WHERE login = @currentLogin"
                };
                sCommand.Parameters.AddWithValue("@currentLogin", tvLogin.Text);
                SqlDataReader reader = sCommand.ExecuteReader();
                if (reader.Read())
                {
                    string hash = (string)reader["password"];
                    string salt = (string)reader["salt"];
                    if (hash == createHash(tvPassword.Text + salt))
                    {
                        MessageBox.Show("Вход выполнен", "УСПЕХ");
                        btOk.Enabled = false;
                        tvPassword.Text = "";
                        tvLogin.Text = "";
                    }
                    else
                    {
                        string error = "Неверный пароль";
                        MessageBox.Show(error, err_tit);
                        errorProvider.SetError(tvPassword, error);
                    }
                }
                else
                {
                    string error = "Пользователь с таким логином не найден";
                    MessageBox.Show(error, err_tit); 
                    errorProvider.SetError(tvLogin, error);
                }
            }
        }

        private void CheckData()
        {
            if (tvPassword.TextLength > 0 && tvLogin.TextLength > 0 &&
                errorProvider.GetError(tvLogin) == "" && errorProvider.GetError(tvPassword) == "")
                btOk.Enabled = true;
            else
                btOk.Enabled = false;
        }

        private void ClearErr()
        {
            errorProvider.SetError(tvPassword, "");
            errorProvider.SetError(tvLogin, "");
        }
    }
}
