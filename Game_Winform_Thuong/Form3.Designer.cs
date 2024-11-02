namespace Game_Winform_Thuong
{
    partial class Form3
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
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToResizeRows = false;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Score,
            this.Level,
            this.PlayTime,
            this.PlayDate});
            this.dgvCustomer.Location = new System.Drawing.Point(3, 2);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.Size = new System.Drawing.Size(545, 274);
            this.dgvCustomer.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Quay lại";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // id
            // 
            this.id.HeaderText = "Mã";
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // Score
            // 
            this.Score.HeaderText = "Điểm";
            this.Score.Name = "Score";
            this.Score.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Level
            // 
            this.Level.HeaderText = "Cấp độ";
            this.Level.Name = "Level";
            // 
            // PlayTime
            // 
            this.PlayTime.HeaderText = "Thời gian";
            this.PlayTime.Name = "PlayTime";
            // 
            // PlayDate
            // 
            this.PlayDate.HeaderText = "Ngày chơi";
            this.PlayDate.Name = "PlayDate";
            this.PlayDate.Width = 150;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 319);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCustomer);
            this.Name = "Form3";
            this.Text = "Điểm số";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayDate;
    }
}