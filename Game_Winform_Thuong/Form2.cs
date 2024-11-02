using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Game_Winform_Thuong
{
    public partial class Form2 : Form
    {
        private DateTime gameStartTime;
        private int level = 2;
        bool goLeft, goRight, shooting, isGameOver;
        int score;
        int playerSpeed = 12;
        int enemySpeed = 6;
        int bulletSpeed;
        Random rnd = new Random();

        // Boss
        int bossHealth = 20;
        bool bossMovingRight = true;
        int bossSpeed = 5;
        bool bossIsActive = false;
        int bulletBossSpeed = 8;
        List<Point> bossBullets = new List<Point>();
        Timer bossShootTimer = new Timer();

        private SoundPlayer shootSound;
        private SoundPlayer hitSound;
        private SoundPlayer winSound;
        private SoundPlayer loseSound;

        public Form2()
        {
            InitializeComponent();
            resetGame();
            bossShootTimer.Interval = 10000;
            bossShootTimer.Tick += new EventHandler(bossShootEvent);
            shootSound = new SoundPlayer("Sounds/shot.wav");
            hitSound = new SoundPlayer("Sounds/hit.wav");
            winSound = new SoundPlayer("Sounds/win.wav");
            loseSound = new SoundPlayer("Sounds/lose.wav");
        }

        private void PlaySound(SoundPlayer sound)
        {
            sound.Play();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = score.ToString();

            // Cập nhật vị trí của kẻ thù
            pictureBox1.Top += enemySpeed;
            pictureBox2.Top += enemySpeed;
            pictureBox3.Top += enemySpeed;

            if (pictureBox1.Top > 710 || pictureBox2.Top > 710 || pictureBox3.Top > 710)
            {
                gameOver();
            }

            // Logic di chuyển của người chơi
            if (goLeft && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight && player.Left < 688)
            {
                player.Left += playerSpeed;
            }

            // Logic bắn đạn
            if (shooting)
            {
                bulletSpeed = 25;
                bullet.Top -= bulletSpeed;
            }
            else
            {
                bullet.Left = -300;
                bulletSpeed = 0;
            }

            if (bullet.Top < -30)
            {
                shooting = false;
            }

            // Kiểm tra va chạm giữa đạn và kẻ thù
            CheckBulletCollision(pictureBox1);
            CheckBulletCollision(pictureBox2);
            CheckBulletCollision(pictureBox3);

            // xuất hiện boss 
            if (score == 15 && !bossIsActive)
            {
                bossIsActive = true;
                progressBarBoss.Visible = true;
                boss.Left = 300;
                bossShootTimer.Start(); // Bắt đầu bắn boss
            }

            // Cập nhật tốc độ kẻ thù dựa trên điểm số
            UpdateEnemySpeed();

            // Di chuyển boss nếu đã xuất hiện
            if (bossIsActive)
            {
                UpdateBossHealthBar();
                MoveBoss();
                CheckBulletCollisionWithBoss();
                UpdateBossBullets();
            }

            Invalidate();
        }

        private void UpdateEnemySpeed()
        {
            if (score >= 20) enemySpeed = 5;
            if (score >= 25) enemySpeed = 6;
            if (score >= 35) enemySpeed = 7;
            if (score >= 55) enemySpeed = 8;
            if (score >= 200) enemySpeed = 10;
        }

        private void MoveBoss()
        {
            if (bossMovingRight)
            {
                boss.Left += bossSpeed;
                if (boss.Left >= this.ClientSize.Width - boss.Width)
                {
                    bossMovingRight = false;
                }
            }
            else
            {
                boss.Left -= bossSpeed;
                if (boss.Left <= 0)
                {
                    bossMovingRight = true;
                }
            }
        }

        private void UpdateBossHealthBar()
        {
            progressBarBoss.Maximum = 20;
            progressBarBoss.Value = bossHealth;
            progressBarBoss.Top = boss.Top - 20;
            progressBarBoss.Left = boss.Left;
            progressBarBoss.Width = boss.Width;
            progressBarBoss.Visible = true;
        }

        private void UpdateBossBullets()
        {
            if (isGameOver) return;
            for (int i = bossBullets.Count - 1; i >= 0; i--)
            {
                
                bossBullets[i] = new Point(bossBullets[i].X, bossBullets[i].Y + bulletBossSpeed);

                
                if (new Rectangle(bossBullets[i].X, bossBullets[i].Y, 5, 15).IntersectsWith(player.Bounds))
                {
                    isGameOver = true;
                    PlaySound(loseSound);
                    MessageBox.Show("Bạn đã bị trúng đạn của boss!", "Game kết thúc");
                    gameOver();
                    return;
                }

                // Xóa đạn nếu nó vượt quá chiều cao của form
                if (bossBullets[i].Y > this.ClientSize.Height)
                {
                    bossBullets.RemoveAt(i);
                }
            }
        }

        private void CheckBulletCollisionWithBoss()
        {
            if (bullet.Bounds.IntersectsWith(boss.Bounds))
            {
                PlaySound(hitSound);
                bossHealth -= 1;
                score += 3;
                shooting = false;
                bullet.Left = -300;

                if (bossHealth <= 0)
                {
                    PlaySound(winSound);
                    MessageBox.Show("Chúc mừng! Bạn đã bắn hạ tàu vũ trụ ngoài hành tinh!", "Chiến thắng");
                    SaveGameScore(score);
                    this.Close();
                }
            }
        }

        private void CheckBulletCollision(PictureBox enemy)
        {
            if (bullet.Bounds.IntersectsWith(enemy.Bounds))
            {
                PlaySound(hitSound);
                score += 1; // Cộng 1 điểm khi bắn trúng kẻ thù
                enemy.Top = -450;
                enemy.Left = rnd.Next(20, 600);
                shooting = false;
            }
        }

        private void bossShootEvent(object sender, EventArgs e)
        {
            if (bossIsActive)
            {
                // Boss bắn 3 viên đạn
                bossBullets.Add(new Point(boss.Left, boss.Top + boss.Height)); // Viên bên trái
                bossBullets.Add(new Point(boss.Left + boss.Width / 2 - 10, boss.Top + boss.Height)); // Viên ở giữa
                bossBullets.Add(new Point(boss.Left + boss.Width - 10, boss.Top + boss.Height)); // Viên bên phải
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space && !shooting)
            {
                PlaySound(shootSound);
                shooting = true;
                bullet.Top = player.Top - 30;
                bullet.Left = player.Left + (player.Width / 2);
            }
            if (e.KeyCode == Keys.Enter && isGameOver)
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            gameTimer.Start();
            gameStartTime = DateTime.Now;
            enemySpeed = 6;

            // Reset enemy positions
            pictureBox1.Left = rnd.Next(20, 600);
            pictureBox2.Left = rnd.Next(20, 600);
            pictureBox3.Left = rnd.Next(20, 600);

            pictureBox1.Top = rnd.Next(0, 200) * -1;
            pictureBox2.Top = rnd.Next(0, 500) * -1;
            pictureBox3.Top = rnd.Next(0, 900) * -1;

            score = 0;
            bulletSpeed = 0;
            bullet.Left = -300;
            shooting = false;

            bossHealth = 20;
            bossIsActive = false;
            boss.Left = -1000; // Ẩn boss
            boss.Top = 50; // Thiết lập vị trí trên của boss
            progressBarBoss.Visible = false; // Ẩn thanh máu

            txtScore.Text = score.ToString();
            lblGameOver.Visible = false;

            bossBullets.Clear(); // Xóa tất cả đạn
            bossShootTimer.Stop(); // Dừng bắn boss
        }

        private void gameOver()
        {
            PlaySound(loseSound);
            isGameOver = true;
            gameTimer.Stop();

            SaveGameScore(score);
            lblGameOver.Text = "Game kết thúc!!" + Environment.NewLine + "Bấm Enter để tiếp tục trò chơi.";
            lblGameOver.Visible = true; // Hiển thị label
        }

        private void SaveGameScore(int score)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SJKPVQV; Initial Catalog=diemso; User Id=sa; Password=sa; TrustServerCertificate=True"))
            {
                try
                {            
                    conn.Open();
                    string playTime = (DateTime.Now - gameStartTime).ToString(@"hh\:mm\:ss");
                    string query = "INSERT INTO GameScores (Score, PlayTime, PlayDate, Level) VALUES (@score, @playTime, @playDate, @level)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@score", score);
                        cmd.Parameters.AddWithValue("@playTime", playTime);
                        cmd.Parameters.AddWithValue("@playDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Level", level);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Vẽ đạn của boss
            foreach (Point bossBullet in bossBullets)
            {
                e.Graphics.FillRectangle(Brushes.Red, bossBullet.X, bossBullet.Y, 5, 15); // Kích thước và màu sắc của viên đạn
            }
        }
    }
}
