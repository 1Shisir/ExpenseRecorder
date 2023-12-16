using System.Data;
using System.Data.SqlClient;

namespace ExpenseRecorder
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();


            //get data from database to dashboard
           
            GreetUser();
            GetBalance();
            GetTotalIncome();
            GetTotalExpense();
            GetTotalExpenseTransactions();
            GetTotalIncomeTransactions();
            GetMaxIncome();
            GetMaxExpense();
            GetMinExpense();
            GetMinIncome();
            GetLastExpense();
            GetLastIncome();
            GetMostExpenseCategory();
            GetMostIncomeCategory();
            GetLastExpenseTransactionDate();
            GetLastIncomeTransactionDate();
           
        }


        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Incomes Obj = new();
            Obj.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Expenses Obj = new();
            Obj.Show();
            this.Hide();

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            viewIncome viewIncome = new();
            viewIncome.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            viewExpenses viewExpenses = new();
            viewExpenses.Show();
            this.Hide();
        }

        SqlConnection Con = new(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FinanceDb;Integrated Security=True;Pooling=False");

        //total Income
        private void GetTotalIncome()
        {
            Con.Open();
            SqlDataAdapter sda = new("select sum(IncAmount) from IncomeTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            totalIncome.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //last income transaction date
        private void GetLastIncomeTransactionDate()
        {
            Con.Open();
            SqlDataAdapter sda = new("select top 1 IncDate from IncomeTable order by IncId desc", Con);
            DataTable dt = new();
            sda.Fill(dt);
            LastIncomeTransactionDate.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }



        //last expense transaction date
        private void GetLastExpenseTransactionDate()
        {


            Con.Open();
            SqlDataAdapter sda = new("select top 1 ExpDate from ExpenseTable order by ExpId desc", Con);
            DataTable dt = new();
            sda.Fill(dt);
            LastExpenseTransactionDate.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }


        //balance
        private void GetBalance()
        {
            Con.Open();
            SqlDataAdapter sda = new("select sum(IncAmount) - sum(ExpAmount) from IncomeTable, ExpenseTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            BalanceAmount.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //maximum income
        private void GetMaxIncome()
        {
            Con.Open();
            SqlDataAdapter sda = new("select max(IncAmount) from IncomeTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            maxIncome.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //minimum income
        private void GetMinIncome()
        {
            Con.Open();
            SqlDataAdapter sda = new("select min(IncAmount) from IncomeTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            minIncome.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //most income category
        private void GetMostIncomeCategory()
        {
            Con.Open();
            SqlDataAdapter sda = new("select top 1 IncCategory from IncomeTable group by IncCategory order by count(*) desc", Con);
            DataTable dt = new();
            sda.Fill(dt);
            mostIncomeCategory.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        //most expense category
        private void GetMostExpenseCategory()
        {
            Con.Open();
            SqlDataAdapter sda = new("select top 1 ExpCategory from ExpenseTable group by ExpCategory order by count(*) desc", Con);
            DataTable dt = new();
            sda.Fill(dt);
            mostExpenseCategory.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        //last income
        private void GetLastIncome()
        {
            Con.Open();
            SqlDataAdapter sda = new("select top 1 IncAmount from IncomeTable order by IncId desc", Con);
            DataTable dt = new();
            sda.Fill(dt);
            LastIncome.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //last expense
        private void GetLastExpense()
        {
            Con.Open();
            SqlDataAdapter sda = new("select top 1 ExpAmount from ExpenseTable order by ExpId desc", Con);
            DataTable dt = new();
            sda.Fill(dt);
            LastExpense.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //mininum expense
        private void GetMinExpense()
        {
            Con.Open();
            SqlDataAdapter sda = new("select min(ExpAmount) from ExpenseTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            minExpense.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //maximum expense
        private void GetMaxExpense()
        {
            Con.Open();
            SqlDataAdapter sda = new("select max(ExpAmount) from ExpenseTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            maxExpense.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //no of transactions
        private void GetTotalIncomeTransactions()
        {
            Con.Open();
            SqlDataAdapter sda = new("select count(*) from IncomeTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            noOfIncTrans.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        //no of transactions expense
        private void GetTotalExpenseTransactions()
        {
            Con.Open();
            SqlDataAdapter sda = new("select count(*) from ExpenseTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            noOfExpTrans.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        //total Expense
        private void GetTotalExpense()
        {
            Con.Open();
            SqlDataAdapter sda = new("select sum(ExpAmount) from ExpenseTable", Con);
            DataTable dt = new();
            sda.Fill(dt);
            totalExpense.Text = "Rs. " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void GreetUser()
        {
            Con.Open();
            SqlDataAdapter sda = new("select * from UserTable where UserName = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2HtmlLabel2.Text = "Hello, " + dt.Rows[0][1].ToString();
            Con.Close();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Login login = new();
            login.Show();
            this.Hide();
        }
    }
}
