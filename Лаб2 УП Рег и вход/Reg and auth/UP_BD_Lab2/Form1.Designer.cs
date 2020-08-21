namespace UP_BD_Lab2
{
    partial class RegForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.gbPassword = new System.Windows.Forms.GroupBox();
            this.passShow = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.log_in = new System.Windows.Forms.Button();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbLogin.SuspendLayout();
            this.gbPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.tbLogin);
            this.gbLogin.Location = new System.Drawing.Point(12, 23);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(260, 51);
            this.gbLogin.TabIndex = 0;
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
            // gbPassword
            // 
            this.gbPassword.Controls.Add(this.passShow);
            this.gbPassword.Controls.Add(this.tbPassword);
            this.gbPassword.Location = new System.Drawing.Point(12, 80);
            this.gbPassword.Name = "gbPassword";
            this.gbPassword.Size = new System.Drawing.Size(260, 67);
            this.gbPassword.TabIndex = 1;
            this.gbPassword.TabStop = false;
            this.gbPassword.Text = "Пароль";
            // 
            // passShow
            // 
            this.passShow.AutoSize = true;
            this.passShow.Location = new System.Drawing.Point(7, 50);
            this.passShow.Name = "passShow";
            this.passShow.Size = new System.Drawing.Size(114, 17);
            this.passShow.TabIndex = 2;
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
            // btRegister
            // 
            this.btRegister.Location = new System.Drawing.Point(75, 153);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(135, 23);
            this.btRegister.TabIndex = 2;
            this.btRegister.Text = "Зарегистрироваться";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Уже зарегистрированны?";
            // 
            // log_in
            // 
            this.log_in.Location = new System.Drawing.Point(96, 208);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(89, 23);
            this.log_in.TabIndex = 4;
            this.log_in.Text = "Войти";
            this.log_in.UseVisualStyleBackColor = true;
            this.log_in.Click += new System.EventHandler(this.log_in_Click);
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.log_in);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.gbPassword);
            this.Controls.Add(this.gbLogin);
            this.Name = "RegForm";
            this.Text = "Регистрация";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbPassword.ResumeLayout(false);
            this.gbPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.GroupBox gbPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button log_in;
        private System.Windows.Forms.ErrorProvider epMain;
        private System.Windows.Forms.CheckBox passShow;
    }
}

