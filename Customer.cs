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

namespace CAR_REBTAL_SYSTEM_PROJECT
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=UMAR\SQLEXPRESS;Initial Catalog=CarRental;Integrated Security=True");
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CarsDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomersDVG.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = CustomersDVG.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CustomersDVG.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomersDVG.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from CustomerTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomersDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into CustomerTbl values('" + IdTb.Text + "','" + NameTb.Text + "','"+AddressTb.Text+"','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added Successfully");
                    con.Close();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from CustomerTbl WHERE CustID='" + IdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");
                    con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update CustomerTbl set CustName='" + NameTb.Text + "',CustAdd='" + AddressTb.Text + "',Phone='" + PhoneTb.Text + "' where CustID= '" + IdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    con.Close();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            populate();
        }
    }
}
