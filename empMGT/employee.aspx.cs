using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace empMGT
{
    public partial class employee : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LV8TTKU\SQLEXPRESS;Initial Catalog=emply;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayEmployees();
            }
        }       

        protected void CreateBtn_Click1(object sender, EventArgs e)
        {

            try
            {
                String sqlQuery = "EXEC Create_Employee @SSN, @fullnames, @dept, @salary, @Indexi";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@SSN", empIdBox.Text);
                cmd.Parameters.AddWithValue("@fullnames", fullnameBox.Text);
                cmd.Parameters.AddWithValue("@dept", emailBox.Text);
                cmd.Parameters.AddWithValue("@salary", salaryBox.Text.ToString());
                cmd.Parameters.AddWithValue("@Indexi", phoneBox.Text);

                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected >= 1)
                {
                    MessageLbl.Text = "Account created.";
                    displayEmployees(); // call display to refresh
                }
                else
                {
                    MessageLbl.Text = "Account not created.";
                }

                // close connection
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageLbl.Text = "There's a problem: " + ex.Message.ToString();
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (empIdBox.Text.Trim().Length >= 1)
            {
                try
                {
                    String sqlQuery = "EXEC delete_employee @SSN";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    cmd.Parameters.AddWithValue("@SSN", empIdBox.Text);

                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected >= 1)
                    {
                        MessageLbl.Text = "Employee deleted successfully.";

                        displayEmployees(); // call display to refresh
                    }
                    else
                    {
                        MessageLbl.Text = "Employee not delete";
                    }

                    // close connection
                    con.Close();

                }
                catch (SqlException ex)
                {
                    MessageLbl.Text = "There's a problem: " + ex.Message.ToString();
                }
            }
            else
            {
                MessageLbl.Text = "Please select an employee to delete";
            }
        }

        public void displayEmployees()
        {
            try
            {
                String sqlQuery = "SELECT SSN, fullnames, dept, salary, Indexi FROM Employee";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                GridViewList.DataSource = dt;
                GridViewList.DataBind();

                // close connection
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageLbl.Text = "Theres a problem displaying employees: " + ex.Message.ToString();
            }
        }

        // 
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string SSN = e.CommandArgument as string;
                populateInputs(SSN);
            }
        }

        // populate the inputs method
        public void populateInputs(String SSN)
        {
            try
            {
                String sqlQuery = "SELECT SSN, fullnames, dept, salary, Indexi  FROM Employee WHERE SSN=@SSN";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@SSN", SSN);

                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                // read from selected values
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    empIdBox.Text = rdr.GetValue(0).ToString();
                    fullnameBox.Text = rdr.GetValue(1).ToString();
                    emailBox.Text = rdr.GetValue(2).ToString();
                    salaryBox.Text = rdr.GetValue(3).ToString();
                    phoneBox.Text = rdr.GetValue(4).ToString();
                }

                // close connection
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageLbl.Text = "There's a problem: " + ex.Message.ToString();
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (empIdBox.Text.Trim().Length >= 1)
            {
                try
                {
                    String sqlQuery = "EXEC Update_EmployeeBonus @Indexi";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                                      
                    cmd.Parameters.AddWithValue("@Indexi", phoneBox.Text);

                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected >= 1)
                    {
                        MessageLbl.Text = "Employee updated successfully.";

                        displayEmployees(); // call display to refresh
                    }
                    else
                    {
                        MessageLbl.Text = "Employee not updated";
                    }

                    // close connection
                    con.Close();

                }
                catch (SqlException ex)
                {
                    MessageLbl.Text = "There's a problem: " + ex.Message.ToString();
                }
            }
            else
            {
                MessageLbl.Text = "Please select an employee to update";
            }
        }
       

        protected void GridViewList_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
    }
