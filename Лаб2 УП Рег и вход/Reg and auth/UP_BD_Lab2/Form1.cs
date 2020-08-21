using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace UP_BD_Lab2
{

    public partial class RegForm : Form
    {
        public static string login = "";
        public static string pass = "";
        public RegForm()
        {
            InitializeComponent();
            btRegister.Enabled = false;
            passShow.Checked = true;
        }

        String sConnStr = new SqlConnectionStringBuilder()
        {
            DataSource = "ILYA-PC\\ZIMINS",
            InitialCatalog = "UsersBD",
            IntegratedSecurity = true
        }.ConnectionString;

        private void btRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection sConn = new SqlConnection(sConnStr))
            {  
               sConn.Open();                           
               SqlCommand sCommand = new SqlCommand { 
                   Connection = sConn,                 

                   CommandText = @"INSERT INTO Users(login, password, salt, registerDate)
                                   VALUES (@curLogin, @curPassword, @curSalt, @curRegDate)"
                };
                string salt = GenerateSalt();                 
                sCommand.Parameters.AddWithValue("curLogin", tbLogin.Text);
                sCommand.Parameters.AddWithValue("curPassword", CalcHash(tbPassword.Text + salt));
                sCommand.Parameters.AddWithValue("curSalt", salt);
                sCommand.Parameters.AddWithValue("curRegDate", DateTime.Today);

                if (sCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Вы зарегистрированы");
                    btRegister.Enabled = false;
                    tbLogin.Text = "";
                    tbPassword.Text = "";
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

        private void SwitchButton()
        {
            if (tbPassword.TextLength > 0 && tbLogin.TextLength > 0 && epMain.GetError(tbLogin) == "")
                btRegister.Enabled = true;
            else btRegister.Enabled = false;
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection sConn = new SqlConnection(sConnStr))
            {
                sConn.Open();          
                SqlCommand sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT COUNT(*) ID 
                                    FROM Users 
                                    WHERE login = @curLogin"
                };
                sCommand.Parameters.AddWithValue("@curLogin", tbLogin.Text);

                if ((int)sCommand.ExecuteScalar() > 0)
                {
                    epMain.SetError(tbLogin, "Логин занят");
                    btRegister.Enabled = false;
                }
                else
                {
                    epMain.SetError(tbLogin, "");
                    SwitchButton();
                }
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            SwitchButton();
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            login = tbLogin.Text;
            pass = tbPassword.Text;
            AuthForm authForm = new AuthForm();
            authForm.Show();
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
