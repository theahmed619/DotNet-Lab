using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Management_System
{
    public partial class Register : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "All fields are required.";
                lblMessage.CssClass = "text-danger";
            }
            else
            {
                SqlConnection con = new SqlConnection(conStr);
                try
                {
                    string query = "insert into students(name,email,password) values(@name,@email,@password)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        // TODO: Save to database
                        lblMessage.Text = "Registration successful!";
                        lblMessage.CssClass = "text-success";

                        // Clear fields (optional)
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtPassword.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "Registration Failed!";
                        lblMessage.CssClass = "text-danger";
                    }
                   
                }
                catch(Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {

                }
            }
        }
    }
}