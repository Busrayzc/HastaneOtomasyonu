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
    public partial class Bölüm : Form
    {
        public Bölüm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A83NA7N\\SQLEXPRESS04;Initial Catalog = HastaneOtomasyonu;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {
            işlemler işlem = new işlemler();
            işlem.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into bölüm (bolumadi)values(@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bölüm Bilgileri Eklendi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From bölüm  Where bolumadi=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bölüm seçimi iptal edildi.");
        }
    }
}
