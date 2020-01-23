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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=arackirala.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void Form6_Load(object sender, EventArgs e)
        {
            OleDbDataReader oku;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "select plaka from aracbilgileri where durum='Boş'";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku[0]);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update aracbilgileri set durum='" + comboBox1.Text + "' where durum='" + comboBox2.Text + "'  ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Araç Başarı ile Kiralandı");
            comboBox1.Text = "";
            comboBox2.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
