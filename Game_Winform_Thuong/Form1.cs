using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Game_Winform_Thuong
{
    public partial class Form1 : Form
    {
        private int level = 1;
        private DateTime gameStartTime;
        bool goLeft, goRight, shooting, isGameOver;
        int score;
        int playerSpeed = 12;
        int enemySpeed;
        int bulletSpeed;
        Random rnd = new Random();
        private SoundPlayer shootSound;
        private SoundPlayer hitSound;
        private SoundPlayer winSound;
        private SoundPlayer loseSound;


        public Form1()
        {
            InitializeComponent();
            shootSound = new SoundPlayer("Sounds/shot.wav");
            hitSound = new SoundPlayer("Sounds/hit.wav");
            winSound = new SoundPlayer("Sounds/win.wav");
            loseSound = new SoundPlayer("Sounds/lose.wav");
            resetGame();
        }
        private void PlaySound(SoundPlayer sound)
        {
            sound.Play();
        }
        private void mainGameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = score.ToString();


            pictureBox1.Top += enemySpeed;
            pictureBox2.Top += enemySpeed;
            pictureBox3.Top += enemySpeed;


            if (pictureBox1.Top > 710 || pictureBox2.Top > 710 || pictureBox3.Top > 710)
            {
                gameOver();
            }



            // player movement logic starts

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left < 688)
            {
                player.Left += playerSpeed;
            }
            // player movement logic ends

            if (shooting == true)
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

            if (bullet.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                PlaySound(hitSound);
                score += 1;
                pictureBox1.Top = -450;
                pictureBox1.Left = rnd.Next(20, 600);
                shooting = false;
            }
            if (bullet.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                PlaySound(hitSound);
                score += 1;
                pictureBox2.Top = -650;
                pictureBox2.Left = rnd.Next(20, 600);
                shooting = false;
            }
            if (bullet.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                PlaySound(hitSound);
                score += 1;
                pictureBox3.Top = -750;
                pictureBox3.Left = rnd.Next(20, 600);
                shooting = false;
            }

            if (score == 5)
            {
                enemySpeed = 4;
            }
            if (score == 10)
            {
                enemySpeed = 6;
            }
            if (score == 15)
            {
                enemySpeed = 8;
            }
            if (score == 20)
            {
                winGame();
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
            if (e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;
                bullet.Top = player.Top - 30;
                bullet.Left = player.Left + (player.Width / 2);
                PlaySound(shootSound); // Phát âm thanh bắn
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            gameTimer.Start();
            gameStartTime = DateTime.Now;
            enemySpeed = 6;


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


            txtScore.Text = score.ToString();
            lblGameOver.Visible = false;  // Ẩn label khi trò chơi khởi động lại

        }
        private void winGame()
        {
            PlaySound(winSound);
            gameTimer.Stop();
            lblGameOver.Text = "Chúc mừng! Bạn đã thắng trò chơi với " + score + Environment.NewLine+ " điểm!\n Cấp độ tiếp theo";

            // Lưu điểm số vào cơ sở dữ liệu
            SaveGameScore(score);
            this.Close();
            Form2 level2Form = new Form2(); // Tạo instance của form cấp độ tiếp theo
            level2Form.Show(); // Hiển thị Form2
            //this.Hide(); // Ẩn form hiện tại (Form1)
        }

        private void gameOver()
        {
            PlaySound(loseSound);
            isGameOver = true;
            SaveGameScore(score);

            gameTimer.Stop();
            lblGameOver.Text = "Game kết thúc!!" + Environment.NewLine + "Bấm Enter để tiếp tục trò chơi.";
            lblGameOver.Visible = true;  // Hiển thị label
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
                    MessageBox.Show("Error saving score: " + ex.Message);
                }
            }
        }
    }
}
