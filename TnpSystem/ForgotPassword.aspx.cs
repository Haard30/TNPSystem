using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userid"] = null;
 
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spResetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserId = new SqlParameter("@UserId", LoginTextBox.Text);

                cmd.Parameters.Add(paramUserId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Convert.ToBoolean(rdr["ReturnCode"]))
                    {
                        SendPasswordResetEmail(rdr["Email"].ToString(), LoginTextBox.Text, rdr["UniqueId"].ToString());
                        Session["userid"] = LoginTextBox.Text.ToString();
                        SuccessLabel.Text =  "An email with instructions to reset your password is sent to your registered email";
                        ErrorLabel.Text = "";
                    }
                    else
                    {
                      //  lblMessage.ForeColor = System.Drawing.Color.Red;
                        ErrorLabel.Text = "User not found!";
                    }
                }
            }
        }

        private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("msutnpsystem@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost:59377/ChangePassword.aspx?uid=" + UniqueId);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>MSU TNP SYSTEM</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "msutnpsystem@gmail.com",
                Password = "test@be4"
            };

            smtpClient.EnableSsl = true;
            try { 
            smtpClient.Send(mailMessage);
            }
            catch(Exception e)
            {
                ErrorLabel.Text = "No internet conection ";
            }
        }

        protected void LoginTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}