namespace auth
{
    partial class Auth
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupAuth = new System.Windows.Forms.GroupBox();
            this.btOk = new System.Windows.Forms.Button();
            this.tvPassword = new System.Windows.Forms.TextBox();
            this.tvLogin = new System.Windows.Forms.TextBox();
            this.pass_txt = new System.Windows.Forms.Label();
            this.login_txt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupAuth
            // 
            this.groupAuth.Controls.Add(this.btOk);
            this.groupAuth.Controls.Add(this.tvPassword);
            this.groupAuth.Controls.Add(this.tvLogin);
            this.groupAuth.Controls.Add(this.pass_txt);
            this.groupAuth.Controls.Add(this.login_txt);
            this.groupAuth.Location = new System.Drawing.Point(12, 13);
            this.groupAuth.Name = "groupAuth";
            this.groupAuth.Size = new System.Drawing.Size(216, 167);
            this.groupAuth.TabIndex = 0;
            this.groupAuth.TabStop = false;
            this.groupAuth.Text = "Введите данные";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(21, 115);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(166, 23);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "Войти";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // tvPassword
            // 
            this.tvPassword.Location = new System.Drawing.Point(76, 76);
            this.tvPassword.Name = "tvPassword";
            this.tvPassword.Size = new System.Drawing.Size(111, 20);
            this.tvPassword.TabIndex = 3;
            this.tvPassword.TextChanged += new System.EventHandler(this.tvPassword_TextChanged);
            // 
            // tvLogin
            // 
            this.tvLogin.Location = new System.Drawing.Point(76, 36);
            this.tvLogin.Name = "tvLogin";
            this.tvLogin.Size = new System.Drawing.Size(111, 20);
            this.tvLogin.TabIndex = 2;
            this.tvLogin.TextChanged += new System.EventHandler(this.tvLogin_TextChanged);
            // 
            // pass_txt
            // 
            this.pass_txt.AutoSize = true;
            this.pass_txt.Location = new System.Drawing.Point(18, 76);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.Size = new System.Drawing.Size(45, 13);
            this.pass_txt.TabIndex = 1;
            this.pass_txt.Text = "Пароль";
            // 
            // login_txt
            // 
            this.login_txt.AutoSize = true;
            this.login_txt.Location = new System.Drawing.Point(18, 36);
            this.login_txt.Name = "login_txt";
            this.login_txt.Size = new System.Drawing.Size(38, 13);
            this.login_txt.TabIndex = 0;
            this.login_txt.Text = "Логин";
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 187);
            this.Controls.Add(this.groupAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Auth";
            this.Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupAuth.ResumeLayout(false);
            this.groupAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupAuth;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.TextBox tvPassword;
        private System.Windows.Forms.TextBox tvLogin;
        private System.Windows.Forms.Label pass_txt;
        private System.Windows.Forms.Label login_txt;
    }
}

