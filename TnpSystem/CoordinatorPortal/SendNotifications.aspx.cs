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
    public partial class SendNotifications : System.Web.UI.Page
    {
        string dept_num_co;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");

            if (!IsPostBack) { 
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from company_details";
            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            CompanyNameList.DataTextField = ds.Tables[0].Columns["compname"].ToString();
            CompanyNameList.DataValueField = ds.Tables[0].Columns["compid"].ToString();
            CompanyNameList.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            CompanyNameList.DataBind();
            }
        }

        protected void SendNotSubmit_Click(object sender, EventArgs e)
        {
            if(CompanyNameList.SelectedIndex == 0)
            {
                ErrorLabelSendNot.Text = "Please Select Company";
            }
            else if (NotOverallAvg.Text.Equals("0") || NotOverallAvg.Text.Equals("")||NotClearedKt.Text.Equals("")||NotOnGoingKt.Text.Equals(""))
            {
                ErrorLabelSendNot.Text = "Please Complete required fields";
            }
            else
            {
                //Code For sorting and sending notifications
                //Convert.ToInt32(TextBox1.Text);

                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                
                //Select department of coordinator
                SqlCommand selectdeptcmd = new SqlCommand();
                selectdeptcmd.CommandText = "Select * from coordinator where id = @coid";
                selectdeptcmd.Parameters.AddWithValue("@coid",Session["userid"].ToString());
                selectdeptcmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(selectdeptcmd);
                da.Fill(ds);
                con.Close();
                dept_num_co = ds.Tables[0].Rows[0]["deptno"].ToString();


                //Command for sorting
                SqlCommand selectcmd = new SqlCommand();
                selectcmd.CommandText = "Select * from academic_details where overall_aggregate >= @ovag AND kt_ongoing <= @kto AND kt_cleared <= @ktc";

                selectcmd.Parameters.AddWithValue("@ovag", Convert.ToDouble(NotOverallAvg.Text));
                selectcmd.Parameters.AddWithValue("@kto", Convert.ToInt32(NotOnGoingKt.Text));
                selectcmd.Parameters.AddWithValue("@ktc", Convert.ToInt32(NotClearedKt.Text));
                selectcmd.Connection = con;
                con.Open();

                DataSet ds1 = new DataSet();

                SqlDataAdapter da1 = new SqlDataAdapter(selectcmd);
                da1.Fill(ds1);
                con.Close();
                string notitext = "Company "+CompanyNameList.SelectedItem.ToString() + " is visiting for campus drive. <br><br> You are eligible" +
                    " for campus placements.<br><br>Job Profile : "+ NotJobProfile.Text.ToString() +"<br><br>Location: "+NotJobLocation.Text.ToString() +"<br><br>Note: "+NotAdditional.Text.ToString()+". <br><br> Click to apply or pass";
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    string id = dr["aid"].ToString();

                    //Command for updating notification_text
                    SqlCommand insertnotcmd = new SqlCommand();
                    insertnotcmd.CommandText = "update notification_details set notification_text_1 = @nottext where notid = @nid AND deptno = @codeptno";
                    insertnotcmd.Parameters.AddWithValue("@nottext", notitext);
                    insertnotcmd.Parameters.AddWithValue("@codeptno", dept_num_co);
                    insertnotcmd.Parameters.AddWithValue("@nid", id);
                    insertnotcmd.Connection = con;
                    con.Open();
                    insertnotcmd.ExecuteNonQuery();
                    con.Close();

                    //Command for updating company_id
                    SqlCommand updatecompidcmd = new SqlCommand();
                    updatecompidcmd.CommandText = "update notification_details set current_company_id = @compid where notid = @nid AND deptno = @codeptno";
                    updatecompidcmd.Parameters.AddWithValue("@compid", CompanyNameList.SelectedValue.ToString());
                    updatecompidcmd.Parameters.AddWithValue("@codeptno", dept_num_co);
                    updatecompidcmd.Parameters.AddWithValue("@nid", id);
                    updatecompidcmd.Connection = con;
                    con.Open();
                    updatecompidcmd.ExecuteNonQuery();
                    con.Close();
                }
                ErrorLabelSendNot.Text = "";
                SendNotActionSuccess.Text = "Notification sent successfully";
                ClearNotSuccess.Text = "";
            }
        }

        protected void CompanyNameList_SelectedIndexChanged(object sender, EventArgs e)
        {

            ErrorLabelSendNot.Text = "";
            SendNotActionSuccess.Text = "";
            ClearNotSuccess.Text = "";
        }

        protected void ClearNot_Click(object sender, EventArgs e)
        {

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            //Select department of coordinator
            SqlCommand selectdeptcmd = new SqlCommand();
            selectdeptcmd.CommandText = "Select * from coordinator where id = @coid";
            selectdeptcmd.Parameters.AddWithValue("@coid", Session["userid"].ToString());
            selectdeptcmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(selectdeptcmd);
            da.Fill(ds);
            con.Close();
            dept_num_co = ds.Tables[0].Rows[0]["deptno"].ToString();

            //Command for updating notification_text by clearing fields
            SqlCommand updatenotcmd = new SqlCommand();
            updatenotcmd.CommandText = "update notification_details set notification_text_1 = @nottext, current_company_id = @compid where deptno = @codeptno";
            updatenotcmd.Parameters.AddWithValue("@nottext","");
            updatenotcmd.Parameters.AddWithValue("@compid", "");
            updatenotcmd.Parameters.AddWithValue("@codeptno", dept_num_co);

            updatenotcmd.Connection = con;
            con.Open();
            updatenotcmd.ExecuteNonQuery();
            con.Close();

            ClearNotSuccess.Text = "Notifications cleared successfully";
            SendNotActionSuccess.Text = "";
            ErrorLabelSendNot.Text = "";
        }
    }
}