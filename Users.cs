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

namespace CAR_REBTAL_SYSTEM_PROJECT
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection con =new SqlConnection(@"Data Source=UMAR\SQLEXPRESS;Initial Catalog=CarRental;Integrated Security=True");
        private void populate()
        {
            con.Open();
            string query = "select * from UsersTbl";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update UsersTbl set Uname='"+Uname.Text+"',Upass='"+Upass.Text+"' where id= "+Uid.Text+";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Updated");
                    con.Close();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            populate();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(Uid.Text=="" || Uname.Text=="" || Upass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    
                    string query = "insert into UsersTbl values('"+Uid.Text+"','"+Uname.Text+"','"+Upass.Text+"')";
                    SqlCommand cmd =new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfully");
                    con.Close();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            populate();
        }

        private void UserDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text= UserDVG.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = UserDVG.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = UserDVG.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from UsersTbl WHERE id="+Uid.Text+";";
                    SqlCommand cmd =new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üser Deleted Successfully");
                    con.Close();
                    populate();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main= new MainForm();
            main.Show();
        }
    }
}
