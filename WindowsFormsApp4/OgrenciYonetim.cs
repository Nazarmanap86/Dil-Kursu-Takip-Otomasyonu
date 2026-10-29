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
    public partial class OgrenciYonetim : Form
    {
        public OgrenciYonetim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\OneDrive\Belgeler\KursDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void OgrenciYonetim_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from ogrenciTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            YönetimDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        int ogrKey;
        private void button3_Click(object sender, EventArgs e)
        {
            if (AdSoyadTb.Text == "" || TelefonTb.Text == "" || CinsiyetCb.Text == "" || AdresTb.Text == "" || ResimTb.Text == "")
            {
                MessageBox.Show("Silinecek Öğrenciyi Seçiniz");
            }
            else
            {
                try
                {
                    ogrKey = Convert.ToInt32(YönetimDGV.SelectedRows[0].Cells[0].Value.ToString());
                    baglanti.Open();
                    String query = ";delete from ogrenciTbl where ogrenciId=" + ogrKey + "";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ögreci Başarıyla Silindi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void YönetimDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrKey = Convert.ToInt32(YönetimDGV.SelectedRows[0].Cells[0].Value.ToString());
            AdSoyadTb.Text = YönetimDGV.SelectedRows[0].Cells[1].Value.ToString();
            TelefonTb.Text = YönetimDGV.SelectedRows[0].Cells[2].Value.ToString();
            TarihDtp.Text = YönetimDGV.SelectedRows[0].Cells[3].Value.ToString();
            CinsiyetCb.Text = YönetimDGV.SelectedRows[0].Cells[4].Value.ToString();
            ResimTb.Text = YönetimDGV.SelectedRows[0].Cells[5].Value.ToString();
            AdresTb.Text = YönetimDGV.SelectedRows[0].Cells[6].Value.ToString();
            YönetimPb.ImageLocation = YönetimDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AdSoyadTb.Text == "" || TelefonTb.Text == "" || CinsiyetCb.Text == "" || AdresTb.Text == "" || ResimTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update ogrenciTbl set AdSoyad='"+AdSoyadTb.Text+"',Telefon='"+TelefonTb.Text+"',DogumTrh='"+TarihDtp.Text+"',Cinsiyet='"+CinsiyetCb.Text+"',Resim='"+ResimTb.Text+"',Adres='"+AdresTb.Text+"'where ogrenciId="+ogrKey+";";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ögrenci Başarıyla Güncellendi");
                    baglanti.Close();
                    uyeler();
                } catch (Exception Ex)
                { 
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            YönetimPb.ImageLocation = openFileDialog1.FileName;
            ResimTb.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            AdresTb.Text = "";
            ResimTb.Text = "";
            CinsiyetCb.Text = "";
            YönetimPb.ImageLocation = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from OgrenciTbl  where AdSoyad like '%"+FilterTb.Text+"%'", baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            YönetimDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
