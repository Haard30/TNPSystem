using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem.AdminPortal
{
    public partial class RemoveUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
            }
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            if (!IsPostBack)
            {
                RemoveBatch.Visible = false;
                RemoveUserSubmit.Visible = false;
                RemoveBatchSubmit.Visible = false;
                UserId.Visible = false;
                BatchYearLabel.Visible = false;
                PRNLabel.Visible = false;
            }
        }
        

        protected void RemoveUserSubmit_Click1(object sender, EventArgs e)
        {
            string uid = UserId.Text.ToString();
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from usertnp where id = @uid";
            cmd.Parameters.AddWithValue("@uid", uid);

            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
            if (!loginSuccessful)
            {
                ErrorLabel.Text = "User you entered does not exist";
            }
            else
            {
                string type = ds.Tables[0].Rows[0][2].ToString().ToUpper();
                //Command for deleting in usertnp
                SqlCommand deletecmd = new SqlCommand();
                deletecmd.CommandText = "delete from usertnp where id = @uid";
                deletecmd.Parameters.AddWithValue("@uid", uid);
                deletecmd.Connection = con;
                //Command for deleting in other tables
                SqlCommand deletecmdforeign = new SqlCommand();
                deletecmdforeign.Parameters.AddWithValue("@uid", uid);
                deletecmdforeign.Connection = con;
                con.Open();
                //Execution of foreign
                if (type.Equals("student", StringComparison.OrdinalIgnoreCase))
                {

                   // deletecmdforeign.CommandText = "delete from tblForgotPasswordRequests where id = @uid";
                   // deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from application_details  where id = @uid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from student_details  where id = @uid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmd.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from academic_details where aid = @uid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from notification_details where notid = @uid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from document_details where docid = @uid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from personal_details where pid = @uid";
                    deletecmdforeign.ExecuteNonQuery();

                }
                else if (type.Equals("coordinator", StringComparison.OrdinalIgnoreCase))
                {
                    deletecmdforeign.CommandText = "delete from coordinator  where id = @uid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmd.ExecuteNonQuery();
                }
                else if (type.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    deletecmdforeign.CommandText = "delete from admin_details  where id = @uid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmd.ExecuteNonQuery();
                }
                con.Close();
                UserId.Text = "";
                SuccessLabel.Text = "User Removed Successfully";
            }
        }

        protected void RemoveBatchSubmit_Click(object sender, EventArgs e)
        {

            string bid = RemoveBatch.Text.ToString()+"%";
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from usertnp where id like @bid";
            cmd.Parameters.AddWithValue("@bid", bid);

            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
            if (!loginSuccessful || Convert.ToInt32(RemoveBatch.Text.ToString())<2000 || Convert.ToInt32(RemoveBatch.Text.ToString()) > 2050)
            {
                ErrorLabel.Text = "No Such Batch . pleae select batch between 2000 to 2050";
            }
            else
            {
                string type = ds.Tables[0].Rows[0][2].ToString().ToUpper();
                //Command for deleting in usertnp
                SqlCommand deletecmd = new SqlCommand();
                deletecmd.CommandText = "delete from usertnp where id like @bid";
                deletecmd.Parameters.AddWithValue("@bid", bid);
                deletecmd.Connection = con;
                //Command for deleting in other tables
                SqlCommand deletecmdforeign = new SqlCommand();
                deletecmdforeign.Parameters.AddWithValue("@bid", bid);
                deletecmdforeign.Connection = con;
                con.Open();
                //Execution of foreign
                if (type.Equals("student", StringComparison.OrdinalIgnoreCase))
                {
                    deletecmdforeign.CommandText = "delete from application_details  where id like @bid";
                    deletecmdforeign.ExecuteNonQuery();
                   // deletecmdforeign.CommandText = "delete from tblForgotPasswordRequests where id like @bid";
                   // deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from student_details  where id like @bid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmd.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from academic_details where aid like @bid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from notification_details where notid like @bid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from document_details where docid like @bid";
                    deletecmdforeign.ExecuteNonQuery();
                    deletecmdforeign.CommandText = "delete from personal_details where pid like @bid";
                    deletecmdforeign.ExecuteNonQuery();


                }
                SuccessLabel.Text = "Batch Deleted";
                ErrorLabel.Text = "";
            }
        }

                protected void ActionType_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (ActionType.SelectedIndex == 0)
            {
                ErrorLabel.Text = "Please Select an action";

                RemoveBatch.Visible = false;
                RemoveUserSubmit.Visible = false;
                RemoveBatchSubmit.Visible = false;
                UserId.Visible = false;
                BatchYearLabel.Visible = false;
                PRNLabel.Visible = false;
            }
            else if (ActionType.SelectedIndex == 1)
            {
                ErrorLabel.Text = "";
                SuccessLabel.Text = "";
                RemoveBatch.Visible = false;
                RemoveUserSubmit.Visible = true;
                RemoveBatchSubmit.Visible = false;
                UserId.Visible = true;

                BatchYearLabel.Visible = false;
                PRNLabel.Visible = true;
            }
            else
            {

                ErrorLabel.Text = "";
                SuccessLabel.Text = "";
                RemoveBatch.Visible = true;
                RemoveUserSubmit.Visible = false;
                RemoveBatchSubmit.Visible = true;
                UserId.Visible = false;

                BatchYearLabel.Visible = true;
                PRNLabel.Visible = false;
            }
        }
    }
}