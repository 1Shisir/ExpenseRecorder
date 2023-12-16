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
    public partial class viewExpenses : Form
    {
        public viewExpenses()
        {
            InitializeComponent();
            DisplayExpense();
        }

        //add delete button to datagridview
        private void ExpenseDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ExpenseDGV.Columns["Delete"].Index)
            {
                int rowToDelete = ExpenseDGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (MessageBox.Show("Are you sure you want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExpenseDGV.Rows.RemoveAt(rowToDelete);
                    Con.Open();
                    string query = "delete from ExpenseTable where ExpId=" + ExpenseDGV.CurrentRow.Cells[0].Value.ToString() + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense Deleted Successfully");
                    Con.Close();
                    DisplayExpense();
                }
            }
        }
     

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void addIncomesBtn_Click(object sender, EventArgs e)
        {
            Incomes incomes = new Incomes();
            incomes.Show();
            this.Hide();
        }

        private void addExpensesBtn_Click(object sender, EventArgs e)
        {
            Expenses expenses = new Expenses();
            expenses.Show();
            this.Hide();

        }

        private void viewIncomesBtn_Click(object sender, EventArgs e)
        {
            viewIncome viewIncome = new viewIncome();
            viewIncome.Show();
            this.Hide();

        }


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FinanceDb;Integrated Security=True;Pooling=False");

        private void DisplayExpense()
        {
            Con.Open();
            string query = "select * from ExpenseTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpenseDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            //Search by name 
            Con.Open();
            string query = "select * from ExpenseTable where ExpName like '%" + searchTb.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            _ = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpenseDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void searchCategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Search by category
            Con.Open();
            string query = "select * from ExpenseTable where ExpCategory like '%" + searchCategoryCb.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            _ = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpenseDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

    }
}
