using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Management_System
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Connection String
        string conStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Prevent reloading on every postback
            {
                populateCities();
                isActive();
                LoadGrid();
                Gender();


            }
            totalEmployees();
        }

        private void Gender()
        {
            List<String> genders = new List<string>
            {
                "Male","Female"
            };
            ddlGender.DataSource = genders;
            ddlGender.DataBind();
            ddlGender.Items.Insert(0,"Select Gender");

        }

        private void isActive()
        {
            List<string> actives = new List<string>();
            actives.Add("Active");
            actives.Add("Not");
            ddlActive.DataSource = actives;
            ddlActive.DataBind();
            ddlActive.Items.Insert(0, "Select "); // Optional
        }

        private void totalEmployees()
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                string query = "select count(*) from Employees";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    lblTotal.Text = "Total Employees is " + count;
                }
                else
                {
                    lblTotal.Text = "No Employee Hired yet";
                }

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        
        }
        private void populateCities()
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                List<string> listOfCities = new List<string>();
                string query = "select * from City";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listOfCities.Add(reader.GetString(1));
                }
                ddlCity.DataSource = listOfCities;
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, "Select City"); // Optional


            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                if (!string.IsNullOrEmpty(txtId.Value))
                {
                    string query = "Select * from Employees where Id=@ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ID", txtId.Value);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtFname.Text = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                        txtLname.Text = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                        ddlCity.SelectedValue = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                        ddlActive.SelectedValue = !reader.IsDBNull(4) ? reader.GetString(4) : "";
                        ddlGender.SelectedValue = !reader.IsDBNull(5) ? reader.GetString(5) : "";

                    }
                }
                else
                {
                    lblMsg.Text = "Enter Emplyee ID";
                }

            }catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
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
                string query = @"insert into employees(FirstName, LastName, City, Status, Gender) values(@FirstName, @LastName, @City, @Status, @Gender) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", txtFname.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLname.Text);
                cmd.Parameters.AddWithValue("@City", ddlCity.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Status", ddlActive.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedItem.Value);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    lblMsg.Text = "Record Inserted Successfully";
                    totalEmployees();
                    LoadGrid();

                }
                else
                {
                    lblMsg.Text = "Insertion Failed";
                }


            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);

            try
            {
                string query = "update employees set FirstName=@Fname, LastName=@Lname, City=@City,Status=@Status, Gender=@Gender where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Fname", txtFname.Text);
                cmd.Parameters.AddWithValue("@Lname", txtLname.Text);
                cmd.Parameters.AddWithValue("@City", ddlCity.SelectedValue);
                cmd.Parameters.AddWithValue("@Status", ddlActive.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Id", txtId.Value);
                con.Open();
                int row = cmd.ExecuteNonQuery();
                
                    if (row > 0)
                    {
                        lblMsg.Text = "Updation Successfully";
                    LoadGrid();
                }
                else
                {
                    lblMsg.Text = "Updation Failed";
                }

            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);

            try
            {
                string query = "delete from employees where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", txtId.Value);
                con.Open();
                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    lblMsg.Text = "Deletion Successfully";
                    totalEmployees();
                    LoadGrid();
                }
                else
                {
                    lblMsg.Text = "Deletion Failed";
                }


            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    

        private void LoadGrid()
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                string query = "SELECT * FROM employees";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                string query = "select * from employees";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();


            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;

            }
            finally
            {
                con.Close();
            }
        }
    }
}