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


namespace sqlconnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Βάλε εδώ το Id της ταινίας";
            button1.Text = "Ψάξε την ταινία";
            button2.Text = "Πρόσθεσε μία νέα ταινία";
            button3.Text = "Πρόσθεσε την ταινία";
            button4.Text = "Διέγραψε την ταινία";
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button3.Enabled = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string strConnectionString = @"Data Source=PANOS-PC\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=True";

            SqlConnection cn = new SqlConnection(strConnectionString);
            string textboxValue = textBox1.Text;
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bάλτε μία τιμή παρακαλώ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //dataGridView1.Rows.Clear();
            }
            try
            {
                cn.Open();
                string Query = "SELECT * FROM AllMovies WHERE Id='" + textboxValue + "'; "; 
                SqlCommand DisplayTableData = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = DisplayTableData;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView2.DataSource = bSource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = false;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string strConnectionString = @"Data Source=PANOS-PC\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=True";

            SqlConnection cn = new SqlConnection(strConnectionString);
            string textboxValue2 = textBox2.Text;
            string textboxValue3 = textBox3.Text;
            string textboxValue4 = textBox4.Text;
            string textboxValue5 = textBox5.Text;
            string textboxValue6 = textBox6.Text;

            try
            {

                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.AllMovies ON;INSERT INTO AllMovies (Id, Title, Genre, ReleaseYear, Director ) VALUES (@Id, @Title, @Genre, @ReleaseYear, @Director)SET IDENTITY_INSERT dbo.AllMovies OFF");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Id", textboxValue2);
                cmd.Parameters.AddWithValue("@Title", textboxValue3);
                cmd.Parameters.AddWithValue("@Genre", textboxValue4);
                cmd.Parameters.AddWithValue("@ReleaseYear", textboxValue5);
                cmd.Parameters.AddWithValue("@Director", textboxValue6);
                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {

                MessageBox.Show("No row selected !");// show a message here to inform
            }

           if(dataGridView2.SelectedRows.Count ==1)
            {
                MessageBox.Show("selected");
            }

            string strConnectionString = @"Data Source=PANOS-PC\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=True";

            string sql = "DELETE FROM  dbo.AllMovies WHERE Id = @rowID";
            SqlConnection cn = new SqlConnection(strConnectionString);
            SqlCommand deleteRecord = new SqlCommand(sql, cn);
                // this overcomes  the out of bound error message 
                // if the selectedRow is greater than 0 then exectute the code below.
            if (dataGridView2.CurrentCell.RowIndex > 0)
                {

                    int selectedIndex = dataGridView2.SelectedRows[0].Index;
                    // gets the RowID from the first column in the grid
                    int rowID = Convert.ToInt32(dataGridView2[0, selectedIndex].Value);

                    // Add the parameter to the command collection
                    deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = rowID;
                

                // Remove the row from the grid
                dataGridView2.Rows.RemoveAt(selectedIndex);
                }

            }

        
        private void label1_Click(object sender, EventArgs e)
        {     
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        { 
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

       
    }

       
    }

