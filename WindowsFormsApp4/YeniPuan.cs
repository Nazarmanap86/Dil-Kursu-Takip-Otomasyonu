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

namespace WindowsFormsApp4
{
    public partial class YeniPuan : Form
    {
        public YeniPuan()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\OneDrive\Belgeler\KursDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void YeniPuan_Load(object sender, EventArgs e)
        {
            uyeler();
            Puanlar();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from ogrenciTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OgrenciDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void Puanlar()
        {
            baglanti.Open();
            string query = "select * from PuanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            puanDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (ogrenciIdTb.Text == "" || PuanTb.Text == "" || KursSecCb.Text == "" || AciklamaTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into PuanTbl values("+ogrenciIdTb.Text+ ",'" +PuanTb.Text+ "','" + KursSecCb.Text + "','" + AciklamaTb.Text + "')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Puan Başarıyla Eklendi");
                    baglanti.Close();
                    Puanlar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogrenciIdTb.Text = "";
            PuanTb.Text = "";
            KursSecCb.Text = "";
            AciklamaTb.Text = "";
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }
    }
}
