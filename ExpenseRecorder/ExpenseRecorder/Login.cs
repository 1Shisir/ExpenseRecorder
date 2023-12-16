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

namespace ExpenseRecorder
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            users Obj = new users();
            Obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FinanceDb;Integrated Security=True;Pooling=False");
        public static string User;
        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            if(userNameTb.Text == "" || userPasswordTb.Text == "")
            {
                MessageBox.Show("Please Enter Username and Password");
            }   
            else
            {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTable where userName='" + userNameTb.Text + "' and userPassword='" + userPasswordTb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            User = userNameTb.Text;
                            Dashboard Obj = new Dashboard();
                            Obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                            userNameTb.Text = "";
                            userPasswordTb.Text = "";
                        }
                        Con.Close();
            }
           
        }
    }
}
