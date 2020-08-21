namespace WindowsFormsApplication1
{
    partial class UserUpdate
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
            this.components = new System.ComponentModel.Container();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.gbPassword = new System.Windows.Forms.GroupBox();
            this.tbPassqord = new System.Windows.Forms.TextBox();
            this.gbRegistrationDate = new System.Windows.Forms.GroupBox();
            this.dtpRegistrationDate = new System.Windows.Forms.DateTimePicker();
            this.btOK = new System.Windows.Forms.Button();
            this.epLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbLogin.SuspendLayout();
            this.gbPassword.SuspendLayout();
            this.gbRegistrationDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.tbLogin);
            this.gbLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLogin.Location = new System.Drawing.Point(0, 0);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(258, 44);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Логин";
            // 
            // tbLogin
            // 
            this.tbLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbLogin.Location = new System.Drawing.Point(3, 16);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(228, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // gbPassword
            // 
            this.gbPassword.Controls.Add(this.tbPassqord);
            this.gbPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPassword.Location = new System.Drawing.Point(0, 44);
            this.gbPassword.Name = "gbPassword";
            this.gbPassword.Size = new System.Drawing.Size(258, 44);
            this.gbPassword.TabIndex = 1;
            this.gbPassword.TabStop = false;
            this.gbPassword.Text = "Пароль";
            // 
            // tbPassqord
            // 
            this.tbPassqord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassqord.Location = new System.Drawing.Point(3, 16);
            this.tbPassqord.Name = "tbPassqord";
            this.tbPassqord.Size = new System.Drawing.Size(252, 20);
            this.tbPassqord.TabIndex = 0;
            this.tbPassqord.TextChanged += new System.EventHandler(this.tbPassqord_TextChanged);
            // 
            // gbRegistrationDate
            // 
            this.gbRegistrationDate.Controls.Add(this.dtpRegistrationDate);
            this.gbRegistrationDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRegistrationDate.Location = new System.Drawing.Point(0, 88);
            this.gbRegistrationDate.Name = "gbRegistrationDate";
            this.gbRegistrationDate.Size = new System.Drawing.Size(258, 44);
            this.gbRegistrationDate.TabIndex = 3;
            this.gbRegistrationDate.TabStop = false;
            this.gbRegistrationDate.Text = "Дата регистрации";
            // 
            // dtpRegistrationDate
            // 
            this.dtpRegistrationDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpRegistrationDate.Location = new System.Drawing.Point(3, 16);
            this.dtpRegistrationDate.Name = "dtpRegistrationDate";
            this.dtpRegistrationDate.Size = new System.Drawing.Size(252, 20);
            this.dtpRegistrationDate.TabIndex = 0;
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOK.Location = new System.Drawing.Point(0, 132);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(258, 36);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "btOK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // epLogin
            // 
            this.epLogin.ContainerControl = this;
            // 
            // UserUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 168);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.gbRegistrationDate);
            this.Controls.Add(this.gbPassword);
            this.Controls.Add(this.gbLogin);
            this.Name = "UserUpdate";
            this.RightToLeftLayout = true;
            this.Text = "Пользователь";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbPassword.ResumeLayout(false);
            this.gbPassword.PerformLayout();
            this.gbRegistrationDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.GroupBox gbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassqord;
        private System.Windows.Forms.GroupBox gbRegistrationDate;
        private System.Windows.Forms.DateTimePicker dtpRegistrationDate;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ErrorProvider epLogin;
    }
}