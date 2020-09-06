using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace TnpSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string pswd = PasswordTextBox.Text.ToString();
            string uid = LoginTextBox.Text.ToString();
          

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
          

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from usertnp where id = @uid and password = @password";
             cmd.Parameters.AddWithValue("@uid", uid);
             cmd.Parameters.AddWithValue("@password", pswd);
            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            if (loginSuccessful)
            {
                // Check if pswd changed
                string pswchng = ds.Tables[0].Rows[0][4].ToString().ToUpper();
                if (pswchng.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    Session["userid"] = ds.Tables[0].Rows[0][0].ToString();
                    string type = ds.Tables[0].Rows[0][2].ToString().ToUpper();
                    //string comp = "student";

                    if (type.Equals("student", StringComparison.OrdinalIgnoreCase))
                    {
                        Response.Redirect("StudentPortal/StudentHome.aspx");
                    }
                    else if (type.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        //Change
                        Response.Redirect("AdminPortal/AdminHome.aspx");
                    }
                    else if (type.Equals("coordinator", StringComparison.OrdinalIgnoreCase))
                    {
                        //Change
                        Response.Redirect("CoordinatorPortal/CoordinatorHome.aspx");
                    }

                }
                else
                {
                    Response.Redirect("ForgotPassword.aspx");   
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid username or password";
                //Response.Write("<h1>Invalid username or password</h1>");
            }
        }

        protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LoginTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}