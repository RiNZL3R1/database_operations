using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public SqlConnection bag = new SqlConnection("server=DESKTOP-371T9GD\\SQLEXPRESS; initial catalog=test ;integrated security=true;");
        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            foreach (var item in listBox1.Items)
            {
                SqlCommand komut = new SqlCommand("insert into urunler (urun) values (@ad)", bag);
                komut.Parameters.AddWithValue("@ad", item);
                bag.Open();
                komut.ExecuteNonQuery();
                bag.Close();
            }
            MessageBox.Show("veri kaydedildi");
            listBox1.Items.Clear();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from urunler ", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "select * from urunler where urun like @urun";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            da.SelectCommand.Parameters.AddWithValue("@urun", "%" + textBox2.Text + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "select * from urunler where id like @id";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            da.SelectCommand.Parameters.AddWithValue("@id", "%" + textBox3.Text + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            SqlCommand komut = new SqlCommand("select * from urunler where id=@id", bag);
            komut.Parameters.AddWithValue("@id", textBox3.Text);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox4.Text = dr["fiyat"].ToString();
            }
            bag.Close(); 

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql = "select * from urunler where id like @id";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            da.SelectCommand.Parameters.AddWithValue("@id", "%" + textBox5.Text + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            SqlCommand komut = new SqlCommand("select * from urunler where id=@id", bag);
            komut.Parameters.AddWithValue("@id", textBox5.Text);
            bag.Open();
            bag.Close();



        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from urunler where id = @id", bag);
            komut.Parameters.AddWithValue("@id ", textBox5.Text);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();

            MessageBox.Show("veri silindi");
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand("update urunler set fiyat = @fiyat where id = @id" , bag);
            update.Parameters.AddWithValue("@id", textBox3.Text);
            update.Parameters.AddWithValue("@fiyat", textBox4.Text);
            bag.Open();
            update.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("veri guncellendi");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
