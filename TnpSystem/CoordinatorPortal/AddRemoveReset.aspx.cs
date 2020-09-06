using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem.CoordinatorPortal
{
    public partial class AddRemoveReset : System.Web.UI.Page
    {
        string dept_num_co;
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
            if (!IsPostBack) { 
            AddUserEmail.Visible = false;
            RemoveUserSubmit.Visible = false;
            AddUserSubmit.Visible = false;
            UserId.Visible = false;
            EmailLabel.Visible = false;
            PRNLabel.Visible = false;
            }

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            //Select department of coordinator
            SqlCommand selectdeptcmd = new SqlCommand();
            selectdeptcmd.CommandText = "Select * from coordinator where id = @coid";
            selectdeptcmd.Parameters.AddWithValue("@coid", Session["userid"].ToString());
            selectdeptcmd.Connection = con;
            con.Open();

            DataSet dsco = new DataSet();
            SqlDataAdapter daco = new SqlDataAdapter(selectdeptcmd);
            daco.Fill(dsco);
            con.Close();
            dept_num_co = dsco.Tables[0].Rows[0]["deptno"].ToString();


        }

        protected void RemoveUserSubmit_Click(object sender, EventArgs e)
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
                    //Check Department of registered student
                    SqlCommand selectcmd = new SqlCommand();
                    selectcmd.CommandText = "Select * from student_details where id = @uid AND deptno = @codeptno";

                    selectcmd.Parameters.AddWithValue("@uid",uid);
                    selectcmd.Parameters.AddWithValue("@codeptno", dept_num_co);
                    selectcmd.Connection = con;
                  

                    DataSet ds1 = new DataSet();

                    SqlDataAdapter da1 = new SqlDataAdapter(selectcmd);
                    da1.Fill(ds1);
                  
                    //If user registered and department matches then
                    if(ds1.Tables[0].Rows.Count != 0) {

                        deletecmdforeign.CommandText = "delete from tblForgotPasswordRequests where id = @uid";
                        deletecmdforeign.ExecuteNonQuery();
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
                        ErrorLabel.Text = "";
                    }
                    else
                    {
                        ErrorLabel.Text = "User is not registered or not of your department";
                    }

                }
                con.Close();
                UserId.Text = "";
                if (ErrorLabel.Text.ToString().Equals("")) { 
                SuccessLabel.Text = "User Removed Successfully";
                }
               // Response.Redirect("AddRemoveReset.aspx");
            }
        }

        protected void AddUserSubmit_Click(object sender, EventArgs e)
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
            if (loginSuccessful)
            {
                ErrorLabel.Text = "User you entered already exist";
            }
            else
            {
                string passwordtemp = uid,passwordfinal;
                if (passwordtemp.Length >= 6)
                {
                    string passwordinitial = passwordtemp.Substring((passwordtemp.Length - 6));
                    passwordfinal = passwordinitial;
                }
                else
                {
                    string passwordinitial = passwordtemp.Substring(0);
                    passwordfinal = passwordinitial;

                }
                //Adding new student
                string email = AddUserEmail.Text.ToString();
                SqlCommand insertcmd = new SqlCommand();
                insertcmd.CommandText = "insert into usertnp values(@uid,@pswd,@type,@email,@uid)";
                insertcmd.Parameters.AddWithValue("@uid", uid);
                insertcmd.Parameters.AddWithValue("@pswd", passwordfinal);
                insertcmd.Parameters.AddWithValue("@type","student");
                insertcmd.Parameters.AddWithValue("@email", email);

                //Command for inserting in other tables
                SqlCommand insertcmdforeign = new SqlCommand();
                insertcmdforeign.Parameters.AddWithValue("@uid", uid);
                //Inserting in usertnp
                insertcmd.Connection = con;
                insertcmdforeign.Connection = con;
                con.Open();
                insertcmd.ExecuteNonQuery();
                //Execution of foreign
                    insertcmdforeign.CommandText = "insert into notification_details(notid) values(@uid)";
                    insertcmdforeign.ExecuteNonQuery();
                    insertcmdforeign.CommandText = "insert into document_details(docid) values(@uid)";
                    insertcmdforeign.ExecuteNonQuery();
                con.Close();
                SuccessLabel.Text = "User Added Successfully";
                ErrorLabel.Text = "";
              //  Response.Redirect("AddRemoveReset.aspx");
            }

        }
        

        protected void ActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ActionType.SelectedIndex == 0)
            {
                ErrorLabel.Text = "Please Select an action";
                AddUserEmail.Visible = false;
                RemoveUserSubmit.Visible = false;
                AddUserSubmit.Visible = false;
                UserId.Visible = false;
                EmailLabel.Visible = false;
                PRNLabel.Visible = false;

            }
            else if(ActionType.SelectedIndex == 1)
            {
                ErrorLabel.Text = "";
                SuccessLabel.Text = "";
                AddUserEmail.Visible = true;
                RemoveUserSubmit.Visible = false;
                AddUserSubmit.Visible = true;
                UserId.Visible = true;

                EmailLabel.Visible = true;
                PRNLabel.Visible = true;
            }
            else
            {

                ErrorLabel.Text = "";
                SuccessLabel.Text = "";
                AddUserEmail.Visible = false;
                RemoveUserSubmit.Visible = true;
                AddUserSubmit.Visible = false;
                UserId.Visible = true;

                EmailLabel.Visible = false;
                PRNLabel.Visible = true;

            }
        }
    }
}