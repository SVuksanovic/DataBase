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
using MySql.Data.MySqlClient;

namespace DataBase
{
    public partial class AddLine : Form
    {
        public AddLine()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Senho\\Documents\\book_market.mdf;Integrated Security=True;Connect Timeout=30";
        ViewForm Viewform;
        public AddLine(ViewForm owner)
        {
            Viewform = owner;
            InitializeComponent();

            /*this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "authors")
            {
                label1.Text = "id_author:";
                label2.Text = "author_username:";
                label3.Text = "author_firstname:";
                label4.Text = "author_lastname:";
                label5.Text = "author_birthday:";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "books")
            {
                label1.Text = "id_book:";
                label2.Text = "book_name:";
                label3.Text = "book_publishing_year:";
                label4.Text = "book_number_of_copies:";
                label5.Text = "book_price:";
                label6.Text = "book_delivery_date:";
                label7.Text = "id_author:";
                label8.Text = "id_provider:";
                label9.Text = "id_publishing_house:";
                label10.Text = "id_ganre:";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "books_orders")
            {
                label1.Text = "id_book:";
                label2.Text = "id_order:";
                label2.Visible = true;
                label1.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "buyers")
            {
                label1.Text = "id_buyer:";
                label2.Text = "buyer_surname:";
                label3.Text = "buyer_firstname:";
                label4.Text = "buyer_lastname:";
                label5.Text = "buyer_city:";
                label6.Text = "buyer_street:";
                label7.Text = "buyer_house:";
                label8.Text = "buyer_apartmant:";
                label9.Text = "buyer_telephone:";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = false;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "ganres")
            {
                label1.Text = "id_ganre:";
                label2.Text = "ganre_name:";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = false; ;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "orders")
            {
                label1.Text = "id_order:";
                label2.Text = "id_buyer:";
                label3.Text = "order_time_get:";
                label4.Text = "order_payment_method:";
                label5.Text = "order_summary:";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "providers")
            {
                label2.Text = "id_provider:";
                label2.Text = "provider_name:";
                label3.Text = "provider_city:";
                label4.Text = "provider_street:";
                label5.Text = "provider_num_of_house:";
                label6.Text = "provider_telephone:";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "publishing_houses")
            {
                label1.Text = "id_publishing_houses:";
                label2.Text = "publishing_houses_name:";
                label3.Text = "publishing_houses_city:";
                label4.Text = "publishing_houses_street:";
                label5.Text = "publishing_houses_num_of_building:";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                button2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Viewform.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e) {

            if (comboBox1.Text == "authors")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into authors(id_author, author_username, author_firtsname," +
                      " author_lastname, author_birthday)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
            else if (comboBox1.Text == "books")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into books(id_book, book_name, book_publishing_year," +
                      " book_number_of_copies, book_price, book_delivery_date, id_author, id_provider, id_publishing_house, id_ganre)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox10.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
            else if (comboBox1.Text == "books_orders")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into books_orders(id_book, id_order)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
            else if (comboBox1.Text == "buyers")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into buyers(id_buyer, buyer_surname, buyer_firstname," +
                      " buyer_lastname, buyer_city, buyer_street, buyer_house, buyer_apartment, buyer_telephone)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
            else if (comboBox1.Text == "ganres")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into ganres(id_ganre, ganre_name)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
            else if (comboBox1.Text == "orders")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into orders(id_order, id_buyer, order_time_get," +
                      " order_payment_method, order_summary)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
            else if (comboBox1.Text == "providers")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into providers(id_provider, provider_name, provider_city," +
                      " provider_street, provider_num_of_house, provider_telephone)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
            else if (comboBox1.Text == "publishing_house")
            {
                SqlConnection con = new SqlConnection(conString);


                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into publishing_house(id_publishing_house, publishing_house_name, publishing_house_city," +
                      " publishing_house_street, publishing_house_num_of_building)" +
                      " values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }

                con.Close();
            }
        }
    }   
}
