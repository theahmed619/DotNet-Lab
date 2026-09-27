using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoNetCrashCourse
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            totalEmployees();
        }

        private void totalEmployees()
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                string totalEmpCount = "  select  count(*) from [dbo].[Employees];";
                SqlCommand cmd = new SqlCommand(totalEmpCount, con);
                con.Open();
                int EmpCount = Convert.ToInt32(cmd.ExecuteScalar());
                if (EmpCount > 0)
                {
                    totalEmp.Text = "Total Number of Employees at Present is " + EmpCount;
                }
                else
                {
                    totalEmp.Text = "No Employee Hired yet";
                }

            }catch(Exception ex)
            {
                error.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                string addEmployeeSql = @"insert into [dbo].[Employees] (FirstName, LastName)values
               (@FirstName, @LastName )";
                SqlCommand cmd = new SqlCommand(addEmployeeSql, con);
                cmd.Parameters.AddWithValue("@FirstName", txtFname.Value);
                cmd.Parameters.AddWithValue("@LastName", txtLname.Value);
              
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    error.Text = "Inserted Successfully";
                    totalEmployees();
                }
                else
                {
                    error.Text="Insert Failed";
                }
            }
            catch(Exception ex)
            {
                error.Text = "Error: " + ex.Message;
                error.Visible = true;

            }
            finally
            {
                con.Close();
            }
        }
    }
}