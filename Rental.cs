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
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=UMAR\SQLEXPRESS;Initial Catalog=CarRental;Integrated Security=True");
        private void populate()
        {
            con.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void fillcombo()
        {
            con.Open();
            string query = "select RegNum from CarTb where Available = '"+ "YES" + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource= dt;
            con.Close();
        }
        private void fillCustomer()
        {
            con.Open();
            string query = "select CustID from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustID", typeof(int));
            dt.Load(rdr);
            CustCb.ValueMember = "CustID";
            CustCb.DataSource = dt;
            con.Close();
        }
        private void fetchCustName()
        {
            con.Open();
            string query = "select * from CustomerTbl where CustID = "+CustCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            con.Close();

        }
        private void updateonRent()
        {
            con.Open();
            string query = "update CarTb set Available='" + "NO" + "' where RegNum = '"+CarRegCb.SelectedValue.ToString()+"'; ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void updateonRentDelete()
        {
            con.Open();
            string query = "update CarTb set Available='" + "YES" + "' where RegNum = '" + CarRegCb.SelectedValue.ToString() + "'; ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void CarRegCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            populate();
            fillcombo();
            fillCustomer();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || AddressTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into RentalTbl values('" + IdTb.Text + "','" + CarRegCb.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + this.RentDate.Text + "', '"+this.ReturnDate.Text+"','"+FeeTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Rented Successfully");
                    con.Close();
                    updateonRent();
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
                    string query = "delete from RentalTbl WHERE RentId='" + IdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Deleted Successfully");
                    con.Close();
                    updateonRentDelete();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void RentDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentDVG.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCb.SelectedValue = RentDVG.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentDVG.SelectedRows[0].Cells[2].Value.ToString();
            FeeTb.Text = RentDVG.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FeeTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ReturnDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RentDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void CustNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void IdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
