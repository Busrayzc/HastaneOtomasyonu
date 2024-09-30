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
    public partial class Doktor : Form
    {
        public Doktor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A83NA7N\\SQLEXPRESS04;Initial Catalog = HastaneOtomasyonu;Integrated Security=True");
     

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Doktor (Ad,Soyad,Alan,Cinsiyet)values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", comboBox2.Text);
            komut.ExecuteNonQuery();


            if ((textBox1.Text == "") || (textBox2.Text == "") || (comboBox1.Text == "") || (comboBox2.Text == ""))
            {
                MessageBox.Show("Bilgleri eksik girdiniz!!");
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";



            }
            else
            {
                MessageBox.Show("Doktor Bilgileri Eklendi.");
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Doktor Where Ad=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgiler silindi.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            işlemler işlem = new işlemler();
            işlem.Show();
            this.Hide();
        }



      
        private void button3_Click(object sender, EventArgs e)
        {
            this.doktorTableAdapter.Fill(this.hastaneOtomasyonuDataSet1.Doktor);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int dg = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[dg].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dg].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dg].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[dg].Cells[3].Value.ToString();
        }
    }
}
