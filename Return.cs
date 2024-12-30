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
    public partial class ReturnF : Form
    {
        public ReturnF()
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
        private void populateRet()
        {
            con.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Deleteonreturn()
        {
            int rentId;
            rentId = Convert.ToInt32( RentDVG.SelectedRows[0].Cells[1].Value.ToString());
            con.Open();
            string query = "delete from RentalTbl WHERE RentId='" + rentId + "';";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            
            con.Close();
            //updateonRentDelete();
            populate();
        }
        private void Return_Load(object sender, EventArgs e)
        {
            populate();
            populateRet();
        }

        private void RentDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarRegCb.Text = RentDVG.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentDVG.SelectedRows[0].Cells[2].Value.ToString();
            ReturnDate.Text = RentDVG.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 = ReturnDate.Value.Date;
            DateTime d2 =DateTime.Now;
            TimeSpan t = d2 - d1;
            int NrofDays = Convert.ToInt32(t.TotalDays);
            if(NrofDays <=0)
            {
                DelayTb.Text = "No Delay";
                FineTb.Text = "0";
            }
            else
            {
                DelayTb.Text = "" + NrofDays;
                FineTb.Text = "" + (NrofDays * 500);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (CarIdTb.Text == "" || CustNameTb.Text == "" || FineTb.Text == ""|| DelayTb.Text==""|| DelayTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into ReturnTbl values(" + CarIdTb.Text + ",'" + CarRegCb.Text + "','"+CustNameTb.Text+"','"+this.ReturnDate.Text+"','"+DelayTb.Text+"','"+FineTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Returned");
                    con.Close();
                    //updateonRent();
                    Deleteonreturn();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            populateRet();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
