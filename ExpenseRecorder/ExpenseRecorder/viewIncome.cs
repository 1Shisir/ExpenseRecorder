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
    public partial class viewIncome : Form
    {
        public viewIncome()
        {
            InitializeComponent();
            DisplayIncome();
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            this.Hide();
        }

        private void AddExpensesBtn_Click(object sender, EventArgs e)
        {
            Expenses expenses = new();
            expenses.Show();
            this.Hide();
        }
        private void AddIncomesBtn_Click(object sender, EventArgs e)
        {
            Incomes incomes = new();
            incomes.Show();
            this.Hide();
        }

        private void Guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            this.Hide();
        }

        private void AddExpensesBtn_Click_1(object sender, EventArgs e)
        {

            Expenses expenses = new();
            expenses.Show();
            this.Hide();

        }

        private void ViewExpensesBtn_Click_1(object sender, EventArgs e)
        {
            viewExpenses viewExpenses = new();
            viewExpenses.Show();
            this.Hide();
        }


        readonly SqlConnection Con = new(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FinanceDb;Integrated Security=True;Pooling=False");

        private void DisplayIncome()
        {
            Con.Open();
            string query = "select * from IncomeTable";
            SqlDataAdapter sda = new(query, Con);
            _ = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Login login = new();
            login.Show();
            this.Hide();
        }

        private void SearchNameTb_TextChanged(object sender, EventArgs e)
        {
            //search by name

            Con.Open();
            string query = "select * from IncomeTable where IncName like '%" + searchNameTb.Text + "%'";
            SqlDataAdapter sda = new(query, Con);
            _ = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void SearchCategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //search by category

            Con.Open();
            string query = "select * from IncomeTable where IncCategory like '%" + searchCategoryCb.Text + "%'";
            SqlDataAdapter sda = new(query, Con);
            _ = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
    }
}