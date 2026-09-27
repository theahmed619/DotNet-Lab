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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Email and Password are required.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM students WHERE Email = @Email AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)

                {

                    Session["username"] = txtEmail.Text;
                    if (Session["username"].Equals("admin@gmail.com"))
                    {
                        Session["admin"] = txtEmail.Text;
                        Response.Redirect("Admin.aspx");
                    }
                   // Response.Redirect("Home.aspx");

                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "Login successful!";

                }


                else
                {
                    lblMessage.Text = "Invalid email or password.";
                }
            }
        }
    }
}