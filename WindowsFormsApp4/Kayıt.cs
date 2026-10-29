using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\OneDrive\Belgeler\KursDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();

        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from ogrenciTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OgrenciDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            OgrenciPb.ImageLocation = openFileDialog1.FileName;
            OgrenciResimTb.Text = openFileDialog1.FileName;
        }

        private void Kayıt_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OgrenciAdTb.Text == "" || OgrenciTelefonTbl.Text == "" || OgrenciResimTb.Text == "" || OgrenciiCinsCb.Text == "" || OgrenciAdresTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    String query = "insert into OgrenciTbl values('"+OgrenciAdTb.Text+"','"+OgrenciTelefonTbl.Text+"','"+OgrendiDogumTrhPb.Text+"','"+OgrenciiCinsCb.Text+"','"+OgrenciResimTb.Text+"','"+OgrenciAdresTb.Text+"')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ögreci Başarıyla Eklendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciAdTb.Text = "";
            OgrenciTelefonTbl.Text="";
            OgrenciiCinsCb.Text = "";
            OgrenciAdresTb.Text = "";
            OgrenciResimTb.Text = "";
        }
    }
}