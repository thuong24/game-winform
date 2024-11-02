using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Game_Winform_Thuong
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SJKPVQV; Initial Catalog=diemso; User Id=sa; Password=sa; TrustServerCertificate=True"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Score, Level, PlayTime, PlayDate FROM GameScores";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Xóa tất cả các dòng trước khi thêm mới để tránh trùng lặp
                    dgvCustomer.Rows.Clear();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int score = reader.GetInt32(1);
                            int level = reader.GetInt32(2);
                            TimeSpan playTime = reader.GetTimeSpan(3);
                            DateTime playDate = reader.GetDateTime(4);

                            dgvCustomer.Rows.Add(id, score, level, playTime, playDate);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading scores: " + ex.Message);
                }
            }
        }

    }
}
