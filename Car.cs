using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAR_REBTAL_SYSTEM_PROJECT
{
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=UMAR\SQLEXPRESS;Initial Catalog=CarRental;Integrated Security=True");
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from CarTb";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into CarTb values('" + RegNumTb.Text + "','" + BrandTb.Text + "','" + ModelTb.Text + "','"+AvailableCb.SelectedItem.ToString()+"','"+PriceTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Added Successfully");
                    con.Close();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            populate();
        }

        private void Car_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from CarTb WHERE RegNum='" + RegNumTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Deleted Successfully");
                    con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CarsDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegNumTb.Text = CarsDVG.SelectedRows[0].Cells[0].Value.ToString();
            BrandTb.Text = CarsDVG.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = CarsDVG.SelectedRows[0].Cells[2].Value.ToString();
            AvailableCb.SelectedItem = CarsDVG.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = CarsDVG.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update CarTb set Brand='" + BrandTb.Text + "',Model='" + ModelTb.Text + "', Available='"+AvailableCb.SelectedItem.ToString()+"',Price='"+PriceTb.Text+"' where RegNum= '" + RegNumTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Updated");
                    con.Close();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            populate();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }
       
        
    }
}
