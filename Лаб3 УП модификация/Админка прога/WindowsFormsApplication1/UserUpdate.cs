using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserUpdate : Form
    {
        public enum State
        {
            Insert,
            Update
        }

        string sConnStr = "";
        string oldLogin = "";
        public string Login
        {
            get { return tbLogin.Text; }
            set { tbLogin.Text = value; }
        }
        public string Passwprd
        {
            get { return tbPassqord.Text; }
            set { tbPassqord.Text = value; }

        }

        public DateTime RegistrationDate
        {
            get { return dtpRegistrationDate.Value; }
            set { dtpRegistrationDate.Value = value; }

        }

        public bool BtOk
        {
            get { return btOK.Enabled; }
            set { btOK.Enabled = value; }
        }

        public UserUpdate(State frmState, string _sConnStr)
        {
            InitializeComponent();
            sConnStr = _sConnStr;
            switch (frmState) {
                case State.Insert:

                    Text = "Новый пользователь";
                    btOK.Text = @"Добавить";
                    btOK.Enabled = false;
                    break;

                case State.Update:

                    Tag = 1;
                    Text = "Изменение данных";
                    btOK.Text = @"Изменть";
                    break;     
            }
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            if (Tag != null && (int)Tag == 1)
            {
                oldLogin = tbLogin.Text;
                Tag = 2;
                return;
            }

            using (SqlConnection sConn = new SqlConnection(sConnStr))
            {
                sConn.Open();
                SqlCommand sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT COUNT(*)  
                                    FROM Users 
                                    WHERE login = @curLogin"
                };
                sCommand.Parameters.AddWithValue("@curLogin", tbLogin.Text);
                if ((int)sCommand.ExecuteScalar() > 0 && tbLogin.Text != oldLogin)
                {
                        epLogin.SetError(tbLogin, "Логин занят");
                        btOK.Enabled = false;
                }
                else
                {
                    epLogin.SetError(tbLogin, "");
                    IsActivity();
                }
            }
        }

        private void IsActivity()
        {
            if ((tbPassqord.TextLength > 0 && tbLogin.TextLength > 0 || Tag != null && tbLogin.TextLength > 0) 
                && epLogin.GetError(tbLogin) == "")
                btOK.Enabled = true;
            else btOK.Enabled = false;
        }

        private void tbPassqord_TextChanged(object sender, EventArgs e)
        {
            IsActivity();
        }
    }
}
