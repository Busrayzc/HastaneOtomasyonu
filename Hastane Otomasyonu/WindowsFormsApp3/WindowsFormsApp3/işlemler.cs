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
    public partial class işlemler : Form
    {
        public işlemler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A83NA7N\\SQLEXPRESS04;Initial Catalog = HastaneOtomasyonu;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            Doktor doc = new Doktor();
            doc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            poliklinik polik = new poliklinik();
            polik.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bölüm böl = new Bölüm();
            böl.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Saat s = new Saat();
            s.Show();
            this.Hide();
        }
    }
}
