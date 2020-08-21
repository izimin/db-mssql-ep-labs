namespace reg
{
    partial class RegForm
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
            this.groupReg = new System.Windows.Forms.GroupBox();
            this.tvPassword = new System.Windows.Forms.TextBox();
            this.tvLogin = new System.Windows.Forms.TextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.pass_txt = new System.Windows.Forms.Label();
            this.login_txt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupReg.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupReg
            // 
            this.groupReg.Controls.Add(this.tvPassword);
            this.groupReg.Controls.Add(this.tvLogin);
            this.groupReg.Controls.Add(this.btOk);
            this.groupReg.Controls.Add(this.pass_txt);
            this.groupReg.Controls.Add(this.login_txt);
            this.groupReg.Location = new System.Drawing.Point(12, 12);
            this.groupReg.Name = "groupReg";
            this.groupReg.Size = new System.Drawing.Size(230, 148);
            this.groupReg.TabIndex = 0;
            this.groupReg.TabStop = false;
            this.groupReg.Text = "Введите данные:";
            // 
            // tvPassword
            // 
            this.tvPassword.Location = new System.Drawing.Point(80, 75);
            this.tvPassword.Name = "tvPassword";
            this.tvPassword.Size = new System.Drawing.Size(122, 20);
            this.tvPassword.TabIndex = 4;
            this.tvPassword.TextChanged += new System.EventHandler(this.tvPassword_TextChanged);
            // 
            // tvLogin
            // 
            this.tvLogin.Location = new System.Drawing.Point(80, 29);
            this.tvLogin.Name = "tvLogin";
            this.tvLogin.Size = new System.Drawing.Size(122, 20);
            this.tvLogin.TabIndex = 3;
            this.tvLogin.TextChanged += new System.EventHandler(this.tvLogin_TextChanged);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(25, 113);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(177, 23);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "Зарегистрироваться";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.ok_Click);
            // 
            // pass_txt
            // 
            this.pass_txt.AutoSize = true;
            this.pass_txt.Location = new System.Drawing.Point(22, 78);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.Size = new System.Drawing.Size(45, 13);
            this.pass_txt.TabIndex = 1;
            this.pass_txt.Text = "Пароль";
            // 
            // login_txt
            // 
            this.login_txt.AutoSize = true;
            this.login_txt.Location = new System.Drawing.Point(22, 32);
            this.login_txt.Name = "login_txt";
            this.login_txt.Size = new System.Drawing.Size(38, 13);
            this.login_txt.TabIndex = 0;
            this.login_txt.Text = "Логин";
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 168);
            this.Controls.Add(this.groupReg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegForm";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupReg.ResumeLayout(false);
            this.groupReg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupReg;
        private System.Windows.Forms.TextBox tvPassword;
        private System.Windows.Forms.TextBox tvLogin;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label pass_txt;
        private System.Windows.Forms.Label login_txt;
    }
}

