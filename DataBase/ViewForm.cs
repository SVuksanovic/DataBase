using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;
using System.IO;

namespace DataBase
{
    public partial class ViewForm : Form
    {
        
        Form1 form1;
        public string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Senho\\Documents\\book_market.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null; 
        public ViewForm(Form1 owner)
        {
            form1 = owner;
            InitializeComponent();

            /*this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;*/
        }

        private void LoadData(string st, int n)
        {
            sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] FROM " + st, sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlBuilder.GetInsertCommand();
            sqlBuilder.GetDeleteCommand();
            sqlBuilder.GetUpdateCommand();
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, st);
            dataGridView1.DataSource = dataSet.Tables[st];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[n, i] = linkCell;
            }
        }

        private void ReLoadData(string st, int n)
        {
            dataSet.Tables[st].Clear();
            sqlDataAdapter.Fill(dataSet, st);
            dataGridView1.DataSource = dataSet.Tables[st];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[n, i] = linkCell;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            form1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "authors")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("authors", 5);
            }
            else if (comboBox1.Text == "books")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("books", 10);
            }
            else if (comboBox1.Text == "books_orders")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("books_orders", 2);
            }
            else if (comboBox1.Text == "buyers")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("buyers", 9);
            }
            else if (comboBox1.Text == "ganres")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("ganres", 2);
            }
            else if (comboBox1.Text == "orders")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("orders", 5);
            }
            else if (comboBox1.Text == "providers")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("providers", 6);
            }
            else if (comboBox1.Text == "publishing_houses")
            {
                sqlConnection = new SqlConnection(conString);
                sqlConnection.Open();
                LoadData("publishing_houses", 5);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 5) && (comboBox1.Text == "authors")) {
                string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["authors"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "authors");
                    }
                }
                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["authors"].Rows[r]["id_author"] = dataGridView1.Rows[r].Cells["id_author"].Value;
                    dataSet.Tables["authors"].Rows[r]["author_username"] = dataGridView1.Rows[r].Cells["author_username"].Value;
                    dataSet.Tables["authors"].Rows[r]["author_firtsname"] = dataGridView1.Rows[r].Cells["author_firtsname"].Value;
                    dataSet.Tables["authors"].Rows[r]["author_lastname"] = dataGridView1.Rows[r].Cells["author_lastname"].Value;
                    dataSet.Tables["authors"].Rows[r]["author_birthday"] = dataGridView1.Rows[r].Cells["author_birthday"].Value;
                    sqlDataAdapter.Update(dataSet, "authors");
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                }
                ReLoadData("authors", 5);
            }
            else if ((e.ColumnIndex == 10) && (comboBox1.Text == "books"))
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["books"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "books");
                    }
                }
                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["books"].Rows[r]["id_book"] = dataGridView1.Rows[r].Cells["id_book"].Value;
                    dataSet.Tables["books"].Rows[r]["book_name"] = dataGridView1.Rows[r].Cells["book_name"].Value;
                    dataSet.Tables["books"].Rows[r]["book_publishing_year"] = dataGridView1.Rows[r].Cells["book_publishing_year"].Value;
                    dataSet.Tables["books"].Rows[r]["book_number_of_copies"] = dataGridView1.Rows[r].Cells["book_number_of_copies"].Value;
                    dataSet.Tables["books"].Rows[r]["book_price"] = dataGridView1.Rows[r].Cells["book_price"].Value;
                    dataSet.Tables["books"].Rows[r]["book_delivery_date"] = dataGridView1.Rows[r].Cells["book_delivery_date"].Value;
                    dataSet.Tables["books"].Rows[r]["id_author"] = dataGridView1.Rows[r].Cells["id_author"].Value;
                    dataSet.Tables["books"].Rows[r]["id_provider"] = dataGridView1.Rows[r].Cells["id_provider"].Value;
                    dataSet.Tables["books"].Rows[r]["id_publishing_house"] = dataGridView1.Rows[r].Cells["id_publishing_house"].Value;
                    dataSet.Tables["books"].Rows[r]["id_ganre"] = dataGridView1.Rows[r].Cells["id_ganre"].Value;
                    sqlDataAdapter.Update(dataSet, "books");
                    dataGridView1.Rows[e.RowIndex].Cells[10].Value = "Delete";
                }
                ReLoadData("books", 10);
            }
            else if ((e.ColumnIndex == 2) && (comboBox1.Text == "books_orders"))
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["books_orders"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "books_orders");
                    }
                }
                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["books_orders"].Rows[r]["id_book"] = dataGridView1.Rows[r].Cells["id_book"].Value;
                    dataSet.Tables["books_orders"].Rows[r]["id_order"] = dataGridView1.Rows[r].Cells["id_order"].Value;
                    sqlDataAdapter.Update(dataSet, "books_orders");
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Delete";
                }
                ReLoadData("books_orders", 2);
            }
            else if ((e.ColumnIndex == 9) && (comboBox1.Text == "buyers"))
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["buyers"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "buyers");
                    }
                }

                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["buyers"].Rows[r]["id_buyer"] = dataGridView1.Rows[r].Cells["id_buyer"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_surname"] = dataGridView1.Rows[r].Cells["buyer_surname"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_firstname"] = dataGridView1.Rows[r].Cells["buyer_firstname"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_lastname"] = dataGridView1.Rows[r].Cells["buyer_lastname"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_city"] = dataGridView1.Rows[r].Cells["buyer_city"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_street"] = dataGridView1.Rows[r].Cells["buyer_street"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_house"] = dataGridView1.Rows[r].Cells["buyer_house"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_apartment"] = dataGridView1.Rows[r].Cells["buyer_apartment"].Value;
                    dataSet.Tables["buyers"].Rows[r]["buyer_telephone"] = dataGridView1.Rows[r].Cells["buyer_telephone"].Value;
                    sqlDataAdapter.Update(dataSet, "buyers");
                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = "Delete";
                }
                ReLoadData("buyers", 9);
            }
            else if ((e.ColumnIndex == 2) && (comboBox1.Text == "ganres"))
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["ganres"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "ganres");
                    }
                }
                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["ganres"].Rows[r]["id_ganre"] = dataGridView1.Rows[r].Cells["id_ganre"].Value;
                    dataSet.Tables["ganres"].Rows[r]["id_ganre"] = dataGridView1.Rows[r].Cells["id_ganre"].Value;
                    sqlDataAdapter.Update(dataSet, "ganres");
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Delete";
                }
                ReLoadData("ganres", 2);
            }
            else if ((e.ColumnIndex == 5) && (comboBox1.Text == "orders"))
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["orders"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "orders");
                    }
                }
                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["orders"].Rows[r]["id_order"] = dataGridView1.Rows[r].Cells["id_order"].Value;
                    dataSet.Tables["orders"].Rows[r]["id_buyer"] = dataGridView1.Rows[r].Cells["id_buyer"].Value;
                    dataSet.Tables["orders"].Rows[r]["order_time_get"] = dataGridView1.Rows[r].Cells["order_time_get"].Value;
                    dataSet.Tables["orders"].Rows[r]["order_payment_method"] = dataGridView1.Rows[r].Cells["order_payment_method"].Value;
                    dataSet.Tables["orders"].Rows[r]["order_summary"] = dataGridView1.Rows[r].Cells["order_summary"].Value;
                    sqlDataAdapter.Update(dataSet, "orders");
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                }
                ReLoadData("orders", 5);
            }
            else if ((e.ColumnIndex == 6) && (comboBox1.Text == "providers"))
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["providers"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "providers");
                    }
                }
                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["providers"].Rows[r]["id_provider"] = dataGridView1.Rows[r].Cells["id_provider"].Value;
                    dataSet.Tables["providers"].Rows[r]["provider_name"] = dataGridView1.Rows[r].Cells["provider_name"].Value;
                    dataSet.Tables["providers"].Rows[r]["provider_city"] = dataGridView1.Rows[r].Cells["provider_city"].Value;
                    dataSet.Tables["providers"].Rows[r]["provider_street"] = dataGridView1.Rows[r].Cells["provider_street"].Value;
                    dataSet.Tables["providers"].Rows[r]["provider_num_of_house"] = dataGridView1.Rows[r].Cells["provider_num_of_house"].Value;
                    dataSet.Tables["providers"].Rows[r]["provider_telephone"] = dataGridView1.Rows[r].Cells["provider_telephone"].Value;
                    sqlDataAdapter.Update(dataSet, "providers");
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = "Delete";
                }
                ReLoadData("providers", 6);
            }
            else if ((e.ColumnIndex == 5) && (comboBox1.Text == "publishing_houses"))
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["publishing_houses"].Rows[rowIndex].Delete();
                        sqlDataAdapter.Update(dataSet, "publishing_houses");
                    }
                }
                else if (task == "Update")
                {
                    int r = e.RowIndex;
                    dataSet.Tables["publishing_houses"].Rows[r]["id_publishing_house"] = dataGridView1.Rows[r].Cells["id_publishing_house"].Value;
                    dataSet.Tables["publishing_houses"].Rows[r]["publishing_house_name"] = dataGridView1.Rows[r].Cells["publishing_house_name"].Value;
                    dataSet.Tables["publishing_houses"].Rows[r]["publishing_house_city"] = dataGridView1.Rows[r].Cells["publishing_house_city"].Value;
                    dataSet.Tables["publishing_houses"].Rows[r]["publishing_house_street"] = dataGridView1.Rows[r].Cells["publishing_house_street"].Value;
                    dataSet.Tables["publishing_houses"].Rows[r]["publishing_house_num_of_building"] = dataGridView1.Rows[r].Cells["publishing_house_num_of_building"].Value;
                    sqlDataAdapter.Update(dataSet, "publishing_houses");
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                }
                ReLoadData("publishing_houses", 5);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        } 

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                string task = "SELECT order_payment_method, ROUND(AVG(order_summary),2) AS avg_order_size FROM orders GROUP BY order_payment_method ORDER BY avg_order_size DESC;";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = task;
                con.Open();
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[2];
                for (int i = 0; i < 2; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn();
                    dataGridView1.Columns.Add(column[i]);
                }
                SqlDataReader dr = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(dr.GetName(0), dr.GetName(1));
                // в цикле построчно читаем ответ от БД
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[dataGridView1.ColumnCount - 1, rowIndex] = linkCell;
                editingRow.Cells["Command"].Value = "Update";
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new AddLine(this).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.Rows.Clear();
                string task = "SELECT id_book, book_name, book_price, CASE WHEN book_price > ROUND((SELECT AVG(book_price) FROM books), 2) +50 THEN book_price *0.85 ELSE ROUND(book_price, 2) END AS new_price FROM books ORDER BY book_price DESC";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = task;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[4];
                for (int i = 0; i < 4; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn();
                    dataGridView1.Columns.Add(column[i]);
                }
                dataGridView1.Rows.Add(dr.GetName(0), dr.GetName(1), dr.GetName(2), dr.GetName(3));
                // в цикле построчно читаем ответ от БД
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string task = "SELECT provider_name, COUNT(*) AS total_books FROM providers p JOIN books b ON p.id_provider = b.id_provider GROUP BY provider_name HAVING COUNT(*) >= 4 ORDER BY total_books DESC;";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = task;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                StreamWriter swExportWriter = new StreamWriter(@"C:\\Users\\Senho\\Documents\\Отчетность бд\\Datafile.txt");
                swExportWriter.WriteLine("Данные по магазину \"Читай-Читай!\" с 01.01.23 по 20.11.23:");
                swExportWriter.WriteLine("В магазин было поставлено следующее количество книг от разных поставщиков:");
                swExportWriter.WriteLine("Поставщик Количество книг");
                // в цикле построчно читаем ответ от БД
                while (dr.Read())
                {
                    swExportWriter.WriteLine("{0} {1}", dr[0] + "\t", dr[1]);
                }
                swExportWriter.WriteLine("Самая продаваемая книга:");
                //Добавить select по продаваемой книге
                swExportWriter.WriteLine("Выручка за этот же период:");
                //Добавть select по выручке
                swExportWriter.WriteLine("Форму утвердил Совет Директоров компании:");
                swExportWriter.WriteLine("Вуксанович С. М. Зыков В. А.");
                swExportWriter.WriteLine("Гаврюшин А. В. Борисов С. П. Ефанова К. В.");
                swExportWriter.Close();
                con.Close();
                MessageBox.Show("Файл успешно записан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string task = "SELECT provider_name, COUNT(*) AS total_books FROM providers p JOIN books b ON p.id_provider = b.id_provider GROUP BY provider_name HAVING COUNT(*) >= 4 ORDER BY total_books DESC;";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = task;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                StreamWriter swExportWriter = new StreamWriter(@"C:\\Users\\Senho\\Documents\\Отчетность бд\\Datafile.csv");
                swExportWriter.WriteLine("provider_name,total_books");
                // в цикле построчно читаем ответ от БД
                while (dr.Read())
                {
                    swExportWriter.WriteLine("{0},{1}", dr[0], dr[1]);
                }
                swExportWriter.Close();
                con.Close();
                MessageBox.Show("Файл успешно записан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
