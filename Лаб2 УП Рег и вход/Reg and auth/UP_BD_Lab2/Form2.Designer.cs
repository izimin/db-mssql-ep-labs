namespace UP_BD_Lab2
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btLog_in = new System.Windows.Forms.Button();
            this.gbPassword = new System.Windows.Forms.GroupBox();
            this.passShow = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.gbPassword.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLog_in
            // 
            this.btLog_in.Location = new System.Drawing.Point(73, 141);
            this.btLog_in.Name = "btLog_in";
            this.btLog_in.Size = new System.Drawing.Size(135, 23);
            this.btLog_in.TabIndex = 5;
            this.btLog_in.Text = "Войти";
            this.btLog_in.UseVisualStyleBackColor = true;
            this.btLog_in.Click += new System.EventHandler(this.btLog_in_Click);
            // 
            // gbPassword
            // 
            this.gbPassword.Controls.Add(this.passShow);
            this.gbPassword.Controls.Add(this.tbPassword);
            this.gbPassword.Location = new System.Drawing.Point(12, 69);
            this.gbPassword.Name = "gbPassword";
            this.gbPassword.Size = new System.Drawing.Size(260, 66);
            this.gbPassword.TabIndex = 4;
            this.gbPassword.TabStop = false;
            this.gbPassword.Text = "Пароль";
            // 
            // passShow
            // 
            this.passShow.AutoSize = true;
            this.passShow.Location = new System.Drawing.Point(7, 43);
            this.passShow.Name = "passShow";
            this.passShow.Size = new System.Drawing.Size(114, 17);
            this.passShow.TabIndex = 3;
            this.passShow.Text = "Показать пароль";
            this.passShow.UseVisualStyleBackColor = true;
            this.passShow.CheckedChanged += new System.EventHandler(this.passShow_CheckedChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(7, 20);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(231, 20);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.tbLogin);
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(260, 51);
            this.gbLogin.TabIndex = 3;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Логин";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(7, 20);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(231, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 176);
            this.Controls.Add(this.btLog_in);
            this.Controls.Add(this.gbPassword);
            this.Controls.Add(this.gbLogin);
            this.Name = "AuthForm";
            this.Text = "Вход";
            this.gbPassword.ResumeLayout(false);
            this.gbPassword.PerformLayout();
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btLog_in;
        private System.Windows.Forms.GroupBox gbPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.CheckBox passShow;
    }
}