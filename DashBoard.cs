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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=UMAR\SQLEXPRESS;Initial Catalog=CarRental;Integrated Security=True");

        private void countCars()
        {

        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTb";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CarLbl.Text = dt.Rows[0][0].ToString();

            string queCust = "SELECT count(*) from CustomerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(queCust, con);
            DataTable dtd = new DataTable();
            sda1.Fill(dtd);
            CustLbl.Text = dtd.Rows[0][0].ToString();

            string queryUser = "select Count(*) from UsersTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryUser, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserLbl.Text = dt2.Rows[0][0].ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void UserLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
