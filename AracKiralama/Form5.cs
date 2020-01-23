using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=arackirala.mdb");
        private void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";           
        }
        DataTable tablomusteri = new DataTable();
        private void musterigoster()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from musteribilgileri", baglanti);
            adtr.Fill(tablomusteri);
            dataGridView1.DataSource = tablomusteri;
            baglanti.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tablomusteri.Clear();
            musterigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete * from musteribilgileri where tc='" + dataGridView1.CurrentRow.Cells["tc"].Value.ToString() + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarı ile Gerçekleşti");
            temizle();
            tablomusteri.Clear();
            musterigoster();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update musteribilgileri set adsoyad='" + textBox2.Text + "', telefon='" + textBox3.Text + "', adres='" + textBox4.Text + "', email='" + textBox5.Text + "' where tc='" + textBox1.Text + "'  ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarı ile Gerçekleşti");
            temizle();
            tablomusteri.Clear();
            musterigoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
