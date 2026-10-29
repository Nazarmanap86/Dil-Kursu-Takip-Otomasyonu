using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KullaniciAdiTb.Text == "" || SifreTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else if (KullaniciAdiTb.Text == "Admin" && SifreTb.Text == "1234")
            {
                Anasayfa ana = new Anasayfa();
                ana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
        }
    }
}
