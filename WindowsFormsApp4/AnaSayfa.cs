using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
            panelDesign();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideMenu();
            Kayıt kyt = new Kayıt();
            kyt.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panelDesign()
        {
            panel_ogrenciMenü.Visible = false;
            panel_kursMenü.Visible = false;
            panel_puanMenü.Visible = false;
        }
        private void HideMenu()
        {
            if (panel_ogrenciMenü.Visible == true)
                panel_ogrenciMenü.Visible = false;
            if (panel_kursMenü.Visible == true)
                panel_kursMenü.Visible = false;
            if (panel_puanMenü.Visible == true)
                panel_puanMenü.Visible = false;
        }
        private void ShowMenü(Panel menü)
        {
            if (menü.Visible == false)
            {
                HideMenu();
                menü.Visible = true;
            }
            else
            {
                menü.Visible = false;
            }
        }

        private void button_ogrenci_Click(object sender, EventArgs e)
        {
            ShowMenü(panel_ogrenciMenü);
        }

        private void button_ogrenciYönetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            OgrenciYonetim ogry = new OgrenciYonetim();
            ogry.Show();
            this.Hide(); 
        }

        private void button_ogrenciİçerik_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void button_ogrenciYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
            ogrenciYazdır yzd = new ogrenciYazdır();
            yzd.Show();
            this.Hide();
        }

        private void button1_Kurs_Click(object sender, EventArgs e)
        {
            ShowMenü(panel_kursMenü);
        }

        private void button_kurskayıt_Click(object sender, EventArgs e)
        {
            HideMenu();
            YeniKurs yeni = new YeniKurs();
            yeni.Show();
            this.Hide();
        }

        private void button_kursYönetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            KayıtYönetim kyönetim = new KayıtYönetim();
            kyönetim.Show();
            this.Hide();
        }

        private void button_kursYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ShowMenü(panel_puanMenü);
        }

        private void button_yenipuan_Click(object sender, EventArgs e)
        {
            HideMenu();
            YeniPuan yeni = new YeniPuan();
            yeni.Show();
            this.Hide();
        }

        private void button_puanYönetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            PuanYönetim pyönetim = new PuanYönetim();
            pyönetim.Show();
            this.Hide();
        }

        private void button_puanYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
            PuanYazdır pyazdır = new PuanYazdır();
            pyazdır.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_cıkış_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}

