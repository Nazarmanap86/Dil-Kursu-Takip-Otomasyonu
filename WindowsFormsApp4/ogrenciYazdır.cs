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
    public partial class ogrenciYazdır : Form
    {
        public ogrenciYazdır()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\OneDrive\Belgeler\KursDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void ogrenciYazdır_Load(object sender, EventArgs e)
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
            YazdırDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from OgrenciTbl  where AdSoyad like '%" + FilterTb.Text + "%'", baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            YazdırDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap objBmp = new Bitmap(this.YazdırDgv.Width, this.YazdırDgv.Height);
            YazdırDgv.DrawToBitmap(objBmp, new Rectangle(0, 0, this.YazdırDgv.Width, this.YazdırDgv.Height));
            e.Graphics.DrawImage(objBmp, 20, 150);
            e.Graphics.DrawString(label1.Text, new Font("Verdana", 20, FontStyle.Bold), Brushes.Black, new Point(300, 30));
            this.YazdırDgv.Columns["OgrenciId"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document= printDocument1;
            printPreviewDialog1.ShowDialog();

        }
    }
}
