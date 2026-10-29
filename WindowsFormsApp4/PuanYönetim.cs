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
    public partial class PuanYönetim : Form
    {
        public PuanYönetim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\OneDrive\Belgeler\KursDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void PuanYönetim_Load(object sender, EventArgs e)
        {
            Puanlar();
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
        int PId;
        private void button3_Click(object sender, EventArgs e)
        {
            if (OgrenciIdTb.Text == "" || PuanTb.Text == "" || KursSecCb.Text == "" || AciklamaTb.Text == "")
            {
                MessageBox.Show("Silinecek Puanı Seçiniz");
            }
            else
            {
                try
                {
                    PId = Convert.ToInt32(puanDgv.SelectedRows[0].Cells[0].Value.ToString());
                    baglanti.Open();
                    string query = "delete from PuanTbl where puanId=" + PId+"";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Puan Başarıyla Silindi");
                    baglanti.Close();
                    Puanlar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void puanDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PId = Convert.ToInt32(puanDgv.SelectedRows[0].Cells[0].Value.ToString());
            OgrenciIdTb.Text = puanDgv.SelectedRows[0].Cells[1].Value.ToString();
            PuanTb.Text = puanDgv.SelectedRows[0].Cells[2].Value.ToString();
            KursSecCb.Text = puanDgv.SelectedRows[0].Cells[3].Value.ToString();
            AciklamaTb.Text = puanDgv.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (OgrenciIdTb.Text == "" || PuanTb.Text == "" || KursSecCb.Text == "" || AciklamaTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update PuanTbl set OgrenciId="+OgrenciIdTb.Text+",Puan='"+PuanTb.Text+"',Kurs='" + KursSecCb.Text + "',Aciklama='" + AciklamaTb.Text + "' where puanId=" + PId + "";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Puan Başarıyla Güncellendi");
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
            OgrenciIdTb.Text = "";
            PuanTb.Text = "";
            KursSecCb.Text = "";
            AciklamaTb.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from PuanTbl  where OgrenciId like '%" + FilterTb.Text + "%'", baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            puanDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Puanlar();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }
    }
}
