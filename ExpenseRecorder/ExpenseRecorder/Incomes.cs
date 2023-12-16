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
    public partial class Incomes : Form
    {
        public Incomes()
        {
            InitializeComponent();
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void addExpensesBtn_Click(object sender, EventArgs e)
        {
            Expenses expenses = new Expenses();
            expenses.Show();
            this.Hide();
        }

        private void viewExpensesBtn_Click(object sender, EventArgs e)
        {
            viewExpenses viewExpenses = new viewExpenses();
            viewExpenses.Show();
            this.Hide();

        }

        private void viewIncomeBtn_Click(object sender, EventArgs e)
        {
            viewIncome viewIncome = new viewIncome();
            viewIncome.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FinanceDb;Integrated Security=True;Pooling=False");
        private void Clear()
        {
            incomeNameTb.Text = "";
            IncomeAmtTb.Text = "";
            IncomeDescTb.Text = "";
            IncomeCategoryCb.SelectedIndex = 0;
        }


        private void saveIncomeBtn_Click_1(object sender, EventArgs e)
        {
            if (incomeNameTb.Text == "" || IncomeCategoryCb.SelectedIndex == -1 || IncomeAmtTb.Text == "" || IncomeDescTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into IncomeTable(IncName,IncCategory,IncDate,IncAmount,IncDesc, IncUser) values(@IN, @IC, @ID, @IA, @IDESC, @IU)", Con);
                    cmd.Parameters.AddWithValue("@IN", incomeNameTb.Text);
                    cmd.Parameters.AddWithValue("@IC", IncomeCategoryCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID", IncomeDate.Value.Date);
                    cmd.Parameters.AddWithValue("@IA", IncomeAmtTb.Text);
                    cmd.Parameters.AddWithValue("@IDESC", IncomeDescTb.Text);
                    cmd.Parameters.AddWithValue("@IU", Login.User);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Income Added Successfully.");
                    Con.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
