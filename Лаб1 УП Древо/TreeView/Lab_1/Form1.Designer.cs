namespace Lab_1
{
    partial class MainForm
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
            this.tvAuto = new System.Windows.Forms.TreeView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // tvAuto
            // 
            this.tvAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAuto.Location = new System.Drawing.Point(0, 0);
            this.tvAuto.Name = "tvAuto";
            this.tvAuto.Size = new System.Drawing.Size(284, 262);
            this.tvAuto.TabIndex = 0;
            this.tvAuto.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvAuto_BeforeCollapse);
            this.tvAuto.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvAuto_AfterExpand);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tvAuto);
            this.Name = "MainForm";
            this.Text = "Древовидное представление ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvAuto;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

