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
    public partial class poliklinik : Form
    {
        public poliklinik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A83NA7N\\SQLEXPRESS04;Initial Catalog = HastaneOtomasyonu;Integrated Security=True");
       
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into poliklinik (poliklinikadi, bolumnumarasi)values(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Poliklinik Eklendi.");
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            işlemler işlem = new işlemler();
            işlem.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From poliklinik  Where poliklinikadi=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", comboBox2.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Poliklinik Silindi.");
        }
    }
}
