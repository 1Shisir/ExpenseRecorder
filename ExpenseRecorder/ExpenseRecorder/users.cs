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

namespace ExpenseRecorder
{
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FinanceDb;Integrated Security=True;Pooling=False");

        private void Clear()
        {
            userNameTb.Text = "";
            userPhoneTb.Text = "";
            userAddressTb.Text = "";
            userPasswordTb.Text = "";
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            if (userNameTb.Text == "" || userPhoneTb.Text == "" || userAddressTb.Text == "" || userPasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTable(userName,userPhone,userDob,userAddress,userPassword) values(@UN, @UPH, @UDOB, @UADD, @UPASS)", Con);
                    cmd.Parameters.AddWithValue("@UN", userNameTb.Text);
                    cmd.Parameters.AddWithValue("@UPH", userPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UDOB", userDob.Value.Date);
                    cmd.Parameters.AddWithValue("@UADD", userAddressTb.Text);
                    cmd.Parameters.AddWithValue("@UPASS", userPasswordTb.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User Added Successfully.");
                    Con.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }
    }
}
