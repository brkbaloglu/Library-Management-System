using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-BURAK; Initial Catalog=kütüphanedb; Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_1",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string kitapadi = textBox1.Text;
            string yazaradi = textBox2.Text;
            string basimyili = textBox3.Text;

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Table_1 (KitapAdi, YazarAdi, BasimYili) VALUES ('" + kitapadi +"', '" + yazaradi +"', '" + basimyili + "') ", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            listele();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Table_1 WHERE KitapAdi = ('"+t1+"')", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string kitapadi = textBox1.Text;
            string yazaradi = textBox2.Text;
            string basimyili = textBox3.Text;

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Table_1 SET KitapAdi = '"+kitapadi+ "',YazarAdi = '" + yazaradi + "',BasimYili = '" + basimyili + "' WHERE KitapAdi='"+kitapadi+"'", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}