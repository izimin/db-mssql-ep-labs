namespace Lab7_UP
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbRace = new System.Windows.Forms.GroupBox();
            this.dgvRace = new System.Windows.Forms.DataGridView();
            this.gbStage = new System.Windows.Forms.GroupBox();
            this.dgvStage = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRace)).BeginInit();
            this.gbStage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStage)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.gbRace);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbStage);
            this.splitContainer1.Size = new System.Drawing.Size(500, 352);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbRace
            // 
            this.gbRace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRace.Controls.Add(this.dgvRace);
            this.gbRace.Location = new System.Drawing.Point(0, 0);
            this.gbRace.Name = "gbRace";
            this.gbRace.Size = new System.Drawing.Size(500, 174);
            this.gbRace.TabIndex = 0;
            this.gbRace.TabStop = false;
            this.gbRace.Text = "Гонка";
            // 
            // dgvRace
            // 
            this.dgvRace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRace.Location = new System.Drawing.Point(3, 18);
            this.dgvRace.Name = "dgvRace";
            this.dgvRace.RowTemplate.Height = 24;
            this.dgvRace.Size = new System.Drawing.Size(494, 153);
            this.dgvRace.TabIndex = 0;
            this.dgvRace.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRace_CellValueChanged);
            this.dgvRace.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRace_RowValidating);
            this.dgvRace.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRace_UserDeletingRow);
            this.dgvRace.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvRace_PreviewKeyDown);
            // 
            // gbStage
            // 
            this.gbStage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStage.Controls.Add(this.dgvStage);
            this.gbStage.Location = new System.Drawing.Point(0, 3);
            this.gbStage.Name = "gbStage";
            this.gbStage.Size = new System.Drawing.Size(497, 172);
            this.gbStage.TabIndex = 0;
            this.gbStage.TabStop = false;
            this.gbStage.Text = "Этап кубка мира";
            // 
            // dgvStage
            // 
            this.dgvStage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStage.Location = new System.Drawing.Point(3, 18);
            this.dgvStage.Name = "dgvStage";
            this.dgvStage.RowTemplate.Height = 24;
            this.dgvStage.Size = new System.Drawing.Size(491, 151);
            this.dgvStage.TabIndex = 1;
            this.dgvStage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStage_CellValueChanged);
            this.dgvStage.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvStage_RowValidating);
            this.dgvStage.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvStage_UserDeletingRow);
            this.dgvStage.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvStage_PreviewKeyDown);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 352);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "ORM";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbRace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRace)).EndInit();
            this.gbStage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbRace;
        private System.Windows.Forms.DataGridView dgvRace;
        private System.Windows.Forms.GroupBox gbStage;
        private System.Windows.Forms.DataGridView dgvStage;
    }
}

