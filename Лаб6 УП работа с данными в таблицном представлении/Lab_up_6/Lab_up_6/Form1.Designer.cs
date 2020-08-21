namespace Lab_up_6
{
    partial class dgvFrom
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbWorldCups = new System.Windows.Forms.GroupBox();
            this.dgvCups = new System.Windows.Forms.DataGridView();
            this.gbTrack = new System.Windows.Forms.GroupBox();
            this.dgvTrack = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbWorldCups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCups)).BeginInit();
            this.gbTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbWorldCups);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbTrack);
            this.splitContainer1.Size = new System.Drawing.Size(746, 604);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbWorldCups
            // 
            this.gbWorldCups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWorldCups.Controls.Add(this.dgvCups);
            this.gbWorldCups.Location = new System.Drawing.Point(3, 3);
            this.gbWorldCups.Name = "gbWorldCups";
            this.gbWorldCups.Size = new System.Drawing.Size(740, 282);
            this.gbWorldCups.TabIndex = 0;
            this.gbWorldCups.TabStop = false;
            this.gbWorldCups.Text = "Кубки мира";
            // 
            // dgvCups
            // 
            this.dgvCups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCups.Location = new System.Drawing.Point(3, 18);
            this.dgvCups.Name = "dgvCups";
            this.dgvCups.RowTemplate.Height = 24;
            this.dgvCups.Size = new System.Drawing.Size(734, 261);
            this.dgvCups.TabIndex = 0;
            this.dgvCups.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCups_CellValueChanged);
            this.dgvCups.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCups_RowValidating);
            this.dgvCups.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCups_UserDeletingRow);
            this.dgvCups.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvCups_PreviewKeyDown);
            // 
            // gbTrack
            // 
            this.gbTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTrack.Controls.Add(this.dgvTrack);
            this.gbTrack.Location = new System.Drawing.Point(6, 3);
            this.gbTrack.Name = "gbTrack";
            this.gbTrack.Size = new System.Drawing.Size(740, 297);
            this.gbTrack.TabIndex = 0;
            this.gbTrack.TabStop = false;
            this.gbTrack.Text = "Трассы";
            // 
            // dgvTrack
            // 
            this.dgvTrack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrack.Location = new System.Drawing.Point(3, 18);
            this.dgvTrack.Name = "dgvTrack";
            this.dgvTrack.Size = new System.Drawing.Size(734, 276);
            this.dgvTrack.TabIndex = 0;
            this.dgvTrack.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrack_CellValueChanged);
            this.dgvTrack.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTrack_RowValidating);
            this.dgvTrack.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTrack_UserDeletingRow);
            this.dgvTrack.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvTrack_PreviewKeyDown);
            // 
            // dgvFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 604);
            this.Controls.Add(this.splitContainer1);
            this.Name = "dgvFrom";
            this.Text = "MyDgv";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbWorldCups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCups)).EndInit();
            this.gbTrack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbWorldCups;
        private System.Windows.Forms.GroupBox gbTrack;
        private System.Windows.Forms.DataGridView dgvTrack;
        private System.Windows.Forms.DataGridView dgvCups;
    }
}

