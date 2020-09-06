using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (!IsPasswordResetLinkValid())
                {
                    
                    ErrorLabel.Text = "Password Reset link has expired or is invalid";
                    SuccessLabel.Text = "";
                }
            }
        }

        protected void SavePassword_Click(object sender, EventArgs e)
        {
            if (ChangeUserPassword())
            {
                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmdupdatepswd = new SqlCommand();
                cmdupdatepswd.Connection = con;
                //Update in usertnp pswchng table
                cmdupdatepswd.CommandText = "update usertnp set pschng = @boolpswd where id = @userid";
                cmdupdatepswd.Parameters.AddWithValue("@userid", UserId.Text.ToString());
                cmdupdatepswd.Parameters.AddWithValue("@boolpswd","true");
                con.Open();
                cmdupdatepswd.ExecuteNonQuery();
                con.Close();
                SuccessLabel.Text = "Password Changed Successfully!";
                ErrorLabel.Text = "";

            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Password Reset link has expired or is invalid";
                SuccessLabel.Text = "";
            }
        }

        private bool ExecuteSP(string SPName, List<SqlParameter> SPParameters)
        {
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(SPName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in SPParameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                con.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        private bool IsPasswordResetLinkValid()
        {
            List<SqlParameter> paramList = new List<SqlParameter>()
    {
        new SqlParameter()
        {
            ParameterName = "@GUID",
            Value = Request.QueryString["uid"]
        }
    };

            return ExecuteSP("spIsPasswordResetLinkValid", paramList);
        }

        private bool ChangeUserPassword()
        {
            List<SqlParameter> paramList = new List<SqlParameter>()
    {
        new SqlParameter()
        {
            ParameterName = "@GUID",
            Value = Request.QueryString["uid"]
        },
        new SqlParameter()
        {
            ParameterName = "@Password",
            Value = PasswordTextBox1.Text
            //FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordTextBox1.Text, "SHA1")
        }
    };

            return ExecuteSP("spChangePassword", paramList);
        }

        protected void PasswordTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}