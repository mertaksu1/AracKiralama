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
    public partial class Form4 : Form
    {
        public Form4()
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
            comboBox1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
        }
        DataTable tabloarac = new DataTable();
        private void aracgoster()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from aracbilgileri", baglanti);
            adtr.Fill(tabloarac);
            dataGridView1.DataSource = tabloarac;
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete * from aracbilgileri where plaka='" + dataGridView1.CurrentRow.Cells["plaka"].Value.ToString() +"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarı ile Gerçekleşti");
            temizle();
            tabloarac.Clear();
            aracgoster();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tabloarac.Clear();
            aracgoster();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["plaka"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["seri"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["yil"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["km"].Value.ToString();
            comboBox1.Text=dataGridView1.CurrentRow.Cells["yakit"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["renk"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["hacim"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["gfiyat"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["durum"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update aracbilgileri set marka='" + textBox2.Text+ "', seri='" + textBox3.Text + "', yil='" + textBox4.Text + "', km='" + textBox5.Text + "', yakit='" + comboBox1.Text + "', renk='" + textBox6.Text + "',hacim='" + textBox7.Text + "',gfiyat='" + textBox8.Text + "',durum='" + comboBox2.Text + "' where plaka='" + textBox1.Text+"'  ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarı ile Gerçekleşti");
            temizle();
            tabloarac.Clear();
            aracgoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
