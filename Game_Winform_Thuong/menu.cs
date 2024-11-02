using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Media;

namespace Game_Winform_Thuong
{
    public partial class menu : Form
    {
        private SoundPlayer buttonSound;
        public menu()
        {
            InitializeComponent();
            buttonSound = new SoundPlayer("Sounds/button.wav");
            this.FormClosing += new FormClosingEventHandler(Menu_FormClosing); // Đăng ký sự kiện FormClosing
        }
        private void PlaySound(SoundPlayer sound)
        {
            sound.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlaySound(buttonSound);
            Form1 level1Form = new Form1();
            level1Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlaySound(buttonSound);
            Form3 fm3 = new Form3();
            fm3.Show();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xóa bảng điểm khi đóng form menu
            DeleteScores();
        }

        private void DeleteScores()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SJKPVQV; Initial Catalog=diemso; User Id=sa; Password=sa; TrustServerCertificate=True"))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM GameScores"; // Xóa tất cả điểm số
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting scores: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlaySound(buttonSound);
            Close();
        }
    }
}
