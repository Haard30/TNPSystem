using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string deptno;
        string compid;
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
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            
            //here we go for checking if form submitted
            SqlCommand checksubmitted = new SqlCommand();
            checksubmitted.CommandText = "Select * from student_details where id = @uid";
            checksubmitted.Parameters.AddWithValue("@uid", Session["userid"].ToString());

            checksubmitted.Connection = con;
            con.Open();
            DataSet cs = new DataSet();
            

            SqlDataAdapter dcs = new SqlDataAdapter(checksubmitted);
            dcs.Fill(cs);
            con.Close();
            if (!(cs.Tables[0].Rows.Count != 0 && cs.Tables[0].Rows[0][5].ToString().Equals("true")))
            {
                StudentNot1.Text = "Submit the registration form to be eligible for placememnts ";

                StudApply.Visible = false;
                StudPass.Visible = false;
            }

            //If submitted then
            else { 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from notification_details where notid = @uid";
            cmd.Parameters.AddWithValue("@uid", Session["userid"]);
            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();


                //Checking if already applied in application table
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "Select * from application_details where id = @uid and compid = @cid";
                cmd1.Parameters.AddWithValue("@uid", Session["userid"]);
                if (ds.Tables[0].Rows[0]["current_company_id"].ToString().Equals("passed") || ds.Tables[0].Rows[0]["current_company_id"].ToString().Equals("applied")) { 
                cmd1.Parameters.AddWithValue("@cid",99999);
                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cid", ds.Tables[0].Rows[0]["current_company_id"]);
                }
                cmd1.Connection = con;
                con.Open();

                DataSet ds1 = new DataSet();

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1);
                con.Close();




                deptno = ds.Tables[0].Rows[0]["deptno"].ToString();
            compid = ds.Tables[0].Rows[0]["current_company_id"].ToString();
            StudentNot1.Text = ds.Tables[0].Rows[0]["notification_text_1"].ToString();
            if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0]["current_company_id"].ToString().Equals("passed", StringComparison.OrdinalIgnoreCase))
            {
                StudApply.Visible = false;
                StudPass.Visible = false;
                StudActionLabel.Text = "You have decided to pass this company";
            }
            else if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0]["current_company_id"].ToString().Equals("applied", StringComparison.OrdinalIgnoreCase)
                    || ds1.Tables[0].Rows.Count !=0)
            {

                StudApply.Visible = false;
                StudPass.Visible = false;
                StudActionLabel.Text = "You have already applied this company";
            }
            else if(StudentNot1.Text.ToString().Equals("", StringComparison.OrdinalIgnoreCase))
            {
                StudentNot1.Text = "No new Notifications at present";

                StudApply.Visible = false;
                StudPass.Visible = false;
            }
            else
            {

                    //here we go for checking if Already Placed on campus then error
                    
                    SqlCommand placementstatus = new SqlCommand();
                    placementstatus.CommandText = "Select * from placements where id = @uid AND onoffcampus = @onoff";
                    placementstatus.Parameters.AddWithValue("@uid", Session["userid"].ToString());
                    placementstatus.Parameters.AddWithValue("@onoff", "On Campus");

                    placementstatus.Connection = con;
                    con.Open();
                    DataSet ps = new DataSet();
                    SqlDataAdapter dps = new SqlDataAdapter(placementstatus);
                    dps.Fill(ps);

                    con.Close();

                    if (ps.Tables[0].Rows.Count != 0)
                    {

                        StudApply.Visible = false;
                        StudPass.Visible = false;
                        StudActionLabel.Text = "You have already been placed On Campus";
                    }
                    else
                    {

                        StudApply.Visible = true;
                        StudPass.Visible = true;
                    }
            }

            }
        }

        protected void StudApply_Click(object sender, EventArgs e)
        {

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            //Update current_company_id in notification
            SqlCommand updatecompidcmd = new SqlCommand();
            updatecompidcmd.CommandText = "update notification_details set current_company_id = @compid where notid = @nid";
            updatecompidcmd.Parameters.AddWithValue("@compid","applied");
            updatecompidcmd.Parameters.AddWithValue("@nid", Session["userid"].ToString());
            updatecompidcmd.Connection = con;
            con.Open();
            updatecompidcmd.ExecuteNonQuery();
            con.Close();


            StudApply.Visible = false;
            StudPass.Visible = false;
            StudActionLabel.Text = "You have applied to this company";

            //Insert into application_details
            SqlCommand insertappcmd = new SqlCommand();
            insertappcmd.CommandText = "insert into application_details values(@id,@deptno,@compid)";
            insertappcmd.Parameters.AddWithValue("@id",Session["userid"].ToString());
            insertappcmd.Parameters.AddWithValue("@deptno",deptno);
            insertappcmd.Parameters.AddWithValue("@compid",compid);
            insertappcmd.Connection = con;
            con.Open();
            insertappcmd.ExecuteNonQuery();
            con.Close();
        }

        protected void StudPass_Click(object sender, EventArgs e)
        {

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            //Update current_company_id in notification
            SqlCommand updatecompidcmd = new SqlCommand();
            updatecompidcmd.CommandText = "update notification_details set current_company_id = @compid where notid = @nid";
            updatecompidcmd.Parameters.AddWithValue("@compid", "passed");
            updatecompidcmd.Parameters.AddWithValue("@nid", Session["userid"].ToString());
            updatecompidcmd.Connection = con;
            con.Open();
            updatecompidcmd.ExecuteNonQuery();
            con.Close();

            StudApply.Visible = false;
            StudPass.Visible = false;
            StudActionLabel.Text = "You have decided to pass this company";
        }
    }
}