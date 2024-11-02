namespace Game_Winform_Thuong
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.txtScore = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.bullet = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.boss = new System.Windows.Forms.PictureBox();
            this.progressBarBoss = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boss)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // txtScore
            // 
            this.txtScore.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtScore.Location = new System.Drawing.Point(757, 9);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(35, 29);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "0";
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblGameOver
            // 
            this.lblGameOver.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblGameOver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGameOver.Location = new System.Drawing.Point(12, 252);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(780, 140);
            this.lblGameOver.TabIndex = 3;
            this.lblGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGameOver.Visible = false;
            // 
            // player
            // 
            this.player.BackgroundImage = global::Game_Winform_Thuong.Properties.Resources.purple;
            this.player.Image = global::Game_Winform_Thuong.Properties.Resources.player2;
            this.player.Location = new System.Drawing.Point(343, 578);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(112, 75);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // bullet
            // 
            this.bullet.Image = global::Game_Winform_Thuong.Properties.Resources.bullet;
            this.bullet.Location = new System.Drawing.Point(473, 304);
            this.bullet.Name = "bullet";
            this.bullet.Size = new System.Drawing.Size(7, 27);
            this.bullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bullet.TabIndex = 0;
            this.bullet.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Game_Winform_Thuong.Properties.Resources.purple;
            this.pictureBox3.Image = global::Game_Winform_Thuong.Properties.Resources._5;
            this.pictureBox3.Location = new System.Drawing.Point(633, 55);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(97, 84);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Game_Winform_Thuong.Properties.Resources.purple;
            this.pictureBox2.Image = global::Game_Winform_Thuong.Properties.Resources._4;
            this.pictureBox2.Location = new System.Drawing.Point(367, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 84);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Game_Winform_Thuong.Properties.Resources.purple;
            this.pictureBox1.Image = global::Game_Winform_Thuong.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(88, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // boss
            // 
            this.boss.BackgroundImage = global::Game_Winform_Thuong.Properties.Resources.purple;
            this.boss.Image = global::Game_Winform_Thuong.Properties.Resources._6;
            this.boss.Location = new System.Drawing.Point(282, 9);
            this.boss.Name = "boss";
            this.boss.Size = new System.Drawing.Size(275, 183);
            this.boss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.boss.TabIndex = 4;
            this.boss.TabStop = false;
            // 
            // progressBarBoss
            // 
            this.progressBarBoss.Location = new System.Drawing.Point(226, 84);
            this.progressBarBoss.Name = "progressBarBoss";
            this.progressBarBoss.Size = new System.Drawing.Size(100, 23);
            this.progressBarBoss.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::Game_Winform_Thuong.Properties.Resources.purple;
            this.ClientSize = new System.Drawing.Size(800, 674);
            this.Controls.Add(this.progressBarBoss);
            this.Controls.Add(this.boss);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.player);
            this.Controls.Add(this.bullet);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtScore);
            this.Name = "Form2";
            this.Text = "Space";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox bullet;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.PictureBox boss;
        private System.Windows.Forms.ProgressBar progressBarBoss;
    }
}
