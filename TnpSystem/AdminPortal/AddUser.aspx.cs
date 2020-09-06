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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
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
        }

        protected void AddUserPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AddUserId_TextChanged(object sender, EventArgs e)
        {
            string passwordtemp = AddUserId.Text.ToString();
            if (passwordtemp.Length >= 6)
            {
                string passwordinitial = passwordtemp.Substring((passwordtemp.Length - 6));
                AddUserPassword.Text = passwordinitial;
            }
            else
            {
                string passwordinitial = passwordtemp.Substring(0);
                AddUserPassword.Text = passwordinitial;

            }
        }

        protected void AddUserSubmit_Click(object sender, EventArgs e)
        {
            string uid = AddUserId.Text.ToString();
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
                USerExistLabel.Text = "User you entered already exist";
            }
            else
            {
                if (AddUserType.SelectedIndex == 0)
                {
                    USerExistLabel.Text = "Please select a user type";
                    AddUserType.Focus();
                }
                else if (AddUserType.SelectedIndex == 2 && AddUserDepartment.SelectedIndex == 0)
                {

                    USerExistLabel.Text = "Please select a department of the coordinator";
                    AddUserDepartment.Focus();
                }
                else
                {
                    string pswd = AddUserPassword.Text.ToString();
                    string email = AddUserEmail.Text.ToString();
                    string type = AddUserType.SelectedValue.ToString();
                    SqlCommand insertcmd = new SqlCommand();
                    insertcmd.CommandText = "insert into usertnp values(@uid,@pswd,@type,@email,@uid)";
                    insertcmd.Parameters.AddWithValue("@uid", uid);
                    insertcmd.Parameters.AddWithValue("@pswd", pswd);
                    insertcmd.Parameters.AddWithValue("@type", type);
                    insertcmd.Parameters.AddWithValue("@email", email);

                    //Command for inserting in other tables
                    SqlCommand insertcmdforeign = new SqlCommand();
                    insertcmdforeign.CommandText = "insert into academic_details(aid) values(@uid)";
                    insertcmdforeign.Parameters.AddWithValue("@uid", uid);
                    insertcmdforeign.Parameters.AddWithValue("@codept", AddUserDepartment.SelectedValue.ToString());
                    insertcmdforeign.Connection = con;
                    insertcmd.Connection = con;
                    con.Open();
                    insertcmd.ExecuteNonQuery();
                    //Execution of foreign
                    if (AddUserType.SelectedIndex == 1)
                    {
                        //Academic details insert through table
                        //insertcmdforeign.ExecuteNonQuery();
                        insertcmdforeign.CommandText = "insert into notification_details(notid) values(@uid)";
                        insertcmdforeign.ExecuteNonQuery();
                        insertcmdforeign.CommandText = "insert into document_details(docid) values(@uid)";
                        insertcmdforeign.ExecuteNonQuery();
                        //Personal details insert through table
                        // insertcmdforeign.CommandText = "insert into personal_details(pid) values(@uid)";
                        //insertcmdforeign.ExecuteNonQuery();
                        //insertcmdforeign.CommandText = "insert into student_details values(@uid,@uid,@uid,@uid,@uid,@uid,@uid)";
                        //insertcmdforeign.ExecuteNonQuery();
                    }
                    else if (AddUserType.SelectedIndex == 2)
                    {
                        insertcmdforeign.CommandText = "insert into coordinator values(@uid,'',@codept)";
                        insertcmdforeign.ExecuteNonQuery();
                    }
                    else
                    {
                        insertcmdforeign.CommandText = "insert into admin_details(id) values(@uid)";
                        insertcmdforeign.ExecuteNonQuery();
                    }

                    con.Close();
                    //Clear field after adding user
                    USerExistLabel.Text = "";
                    UserAddedLabel.Text = "User Added Successfully";
                    AddUserId.Text = "";
                    AddUserEmail.Text = "";
                    AddUserPassword.Text = "";
                    AddUserType.ClearSelection();
                }
            }
            
        }

        protected void AddUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}