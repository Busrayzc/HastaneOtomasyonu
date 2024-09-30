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
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A83NA7N\\SQLEXPRESS04;Initial Catalog = HastaneOtomasyonu;Integrated Security=True");
        private void buttonGırıs_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Giriş where KullanıcıAd=@p1 and Şifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", Ad.Text);
            komut.Parameters.AddWithValue("@p2",Sıfre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                işlemler işlem = new işlemler();
                işlem.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve şifreyi eksik veya yanlış girdiniz. Lütfen tekrar deneyiniz.");
            }
            baglanti.Close();
            
        }
    }
}
