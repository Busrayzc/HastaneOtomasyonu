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
    public partial class Saat : Form
    {
        public Saat()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A83NA7N\\SQLEXPRESS04;Initial Catalog = HastaneOtomasyonu;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into saat (tarih,saat)values(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Tarih ve saat bilgileri eklendi.");
            dateTimePicker1.Text = "";
            maskedTextBox1.Text = "";
            
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
            SqlCommand komutsil = new SqlCommand("Delete From saat Where tarih=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", dateTimePicker1.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgiler silindi.");
        }
    }
    }



