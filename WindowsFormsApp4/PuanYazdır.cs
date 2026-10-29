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
    public partial class PuanYazdır : Form
    {
        public PuanYazdır()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\OneDrive\Belgeler\KursDb.mdf;Integrated Security=True;Connect Timeout=30");
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

        private void PuanYazdır_Load(object sender, EventArgs e)
        {
            Puanlar();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap  map = new Bitmap(puanDgv.Width, puanDgv.Height);
            puanDgv.DrawToBitmap(map, new Rectangle(0, 0, this.puanDgv.Width, this.puanDgv.Height));
            e.Graphics.DrawImage(map, 170, 150);
            e.Graphics.DrawString("Puan Listesi", new Font("verdana", 20, FontStyle.Bold), Brushes.Black, new Point(300,30));
            this.puanDgv.Columns["PuanId"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }
    }
}
