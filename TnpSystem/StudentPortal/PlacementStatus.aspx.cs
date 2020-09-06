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
    public partial class WebForm3 : System.Web.UI.Page
    {
        bool placed_on_campus = false;
        string student_full_name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }


                //Assignining datasoursce to company name list
                string CS1 = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con1 = new SqlConnection(CS1);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from company_details";
                cmd.Connection = con1;
                con1.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con1.Close();
                CompanyNameList.DataTextField = ds.Tables[0].Columns["compname"].ToString();
                CompanyNameList.DataValueField = ds.Tables[0].Columns["compid"].ToString();
                CompanyNameList.DataSource = ds.Tables[0]; 
                CompanyNameList.DataBind();
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
            if(cs.Tables[0].Rows.Count != 0) { 
            Session["deptnumstud"] = cs.Tables[0].Rows[0]["deptno"].ToString();
            }


            //here we go for checking if Already Placed
            SqlCommand placementstatus = new SqlCommand();
            placementstatus.CommandText = "Select * from placements where id = @uid";
            placementstatus.Parameters.AddWithValue("@uid", Session["userid"].ToString());

            placementstatus.Connection = con;
            con.Open();

            DataSet ps = new DataSet();
            SqlDataAdapter dps = new SqlDataAdapter(placementstatus);
            dps.Fill(ps);

            con.Close();

            //Checking Conditions

            if (!(cs.Tables[0].Rows.Count != 0 && cs.Tables[0].Rows[0][5].ToString().Equals("true")))
            {
                PlacementStatusLabel.Text = "Submit the registration form access this feature ";

                PlacementCompNameLabel.Visible = false;
                CompanyNameList.Visible = false;
                OnOffCampusLabel.Visible = false;
                OnOffCampusList.Visible = false;
                PlacementPackageLabel.Visible = false;
                PlacementPackage.Visible = false;
                BatchYearLabel.Visible = false;
                BatchYearListList.Visible = false;
                UpdatePlacementSubmit.Visible = false;
                AddAnother.Visible = false;

                ErrorLabel.Text = "Form not submitted";
            }

            else if (ps.Tables[0].Rows.Count != 0 && ps.Tables[0].Rows[0]["addmore"].Equals("false"))
            {
                PlacementStatusLabel.Text = "Well done! You have already been placed";

                PlacementCompNameLabel.Visible = false;
                CompanyNameList.Visible = false;
                OnOffCampusLabel.Visible = false;
                OnOffCampusList.Visible = false;
                PlacementPackageLabel.Visible = false;
                PlacementPackage.Visible = false;
                BatchYearLabel.Visible = false;
                BatchYearListList.Visible = false;
                UpdatePlacementSubmit.Visible = false;
                AddAnother.Visible = true;


                SuccessLabel.Text = "You have been placed!! ;)";
            }
            else
            {

                PlacementStatusLabel.Text = "Update your placement status here";

                PlacementCompNameLabel.Visible = true;
                CompanyNameList.Visible = true;
                OnOffCampusLabel.Visible = true;
                OnOffCampusList.Visible = true;
                PlacementPackageLabel.Visible = true;
                PlacementPackage.Visible = true;
                BatchYearLabel.Visible = true;
                BatchYearListList.Visible = true;
                UpdatePlacementSubmit.Visible = true;
                AddAnother.Visible = false;

                SuccessLabel.Text = "";
                ErrorLabel.Text = "";

            }


        }

        protected void UpdatePlacementSubmit_Click(object sender, EventArgs e)
        {
            if(CompanyNameList.SelectedIndex == 0)
            {
                ErrorLabel.Text = "Select Compamy name";
            }
            else if (BatchYearListList.SelectedIndex == 0)
            {
                ErrorLabel.Text = "Select Batch Year";
            }
            else if (OnOffCampusList.SelectedIndex == 0)
            {
                ErrorLabel.Text = "Select whether on campus or off campus";
            }
            else if (PlacementPackage.Text.Equals("0"))
            {
                ErrorLabel.Text = "Enter valid package in LPA";
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);

                //Fetching Student Name
                SqlCommand fetchname = new SqlCommand();
                fetchname.CommandText = "select * from personal_details where pid = @uid";
                fetchname.Parameters.AddWithValue("@uid", Session["userid"].ToString());

                fetchname.Connection = con;
                con.Open();
                DataSet personalset = new DataSet();
                SqlDataAdapter personalsetadap = new SqlDataAdapter(fetchname);
                personalsetadap.Fill(personalset);
                
                con.Close();
                if(personalset.Tables[0].Rows.Count != 0)
                {
                    student_full_name = personalset.Tables[0].Rows[0]["full_name"].ToString();
                }


                //Inserting into placements
                SqlCommand insertplacements = new SqlCommand();
                insertplacements.CommandText = "insert into placements values(@id,@deptno,@cmpid,@pckg,@campus,@batchyear,@addmore,@name)";
                insertplacements.Parameters.AddWithValue("@id", Session["userid"].ToString());
                insertplacements.Parameters.AddWithValue("@deptno", Session["deptnumstud"].ToString());
                insertplacements.Parameters.AddWithValue("@cmpid", CompanyNameList.SelectedValue.ToString());
                insertplacements.Parameters.AddWithValue("@pckg", PlacementPackage.Text);
                insertplacements.Parameters.AddWithValue("@campus", OnOffCampusList.SelectedItem.ToString());
                insertplacements.Parameters.AddWithValue("@batchyear", BatchYearListList.SelectedItem.ToString());
                insertplacements.Parameters.AddWithValue("@addmore","false");
                insertplacements.Parameters.AddWithValue("@name", student_full_name);

                insertplacements.Connection = con;
                con.Open();
                insertplacements.ExecuteNonQuery();
                con.Close();

                //Updating all the addanother for same user
                SqlCommand addanother = new SqlCommand();
                addanother.CommandText = "update placements set addmore = @addbool where id = @uid";
                addanother.Parameters.AddWithValue("@uid", Session["userid"].ToString());
                addanother.Parameters.AddWithValue("@addbool", "false");

                addanother.Connection = con;
                con.Open();
                addanother.ExecuteNonQuery();
                con.Close();

                ErrorLabel.Text = "";
                Response.Redirect("PlacementStatus.aspx");
            }
        }

        protected void BatchYearListList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnOffCampusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlacementSubmit.Enabled = true;
            //here we go for checking if Already Placed on campus then error

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            SqlCommand placementstatus = new SqlCommand();
            placementstatus.CommandText = "Select * from placements where id = @uid AND onoffcampus = @onoff";
            placementstatus.Parameters.AddWithValue("@uid", Session["userid"].ToString());
            placementstatus.Parameters.AddWithValue("@onoff","On Campus");

            placementstatus.Connection = con;
            con.Open();
            DataSet ps = new DataSet();
            SqlDataAdapter dps = new SqlDataAdapter(placementstatus);
            dps.Fill(ps);

            con.Close();

            if(ps.Tables[0].Rows.Count != 0 && OnOffCampusList.SelectedIndex == 1)
            {
                ErrorLabelOnCampus.Text = "    Whoa!! You have already been placed on-campus.You can't be placed more than once. ;(";
                UpdatePlacementSubmit.Enabled = false;
            }
            else
            {

                ErrorLabelOnCampus.Text = "";
                UpdatePlacementSubmit.Enabled = true;

            }
        }

        protected void CompanyNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void AddAnother_Click(object sender, EventArgs e)
        {

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            SqlCommand addanother = new SqlCommand();
            addanother.CommandText = "update placements set addmore = @addbool where id = @uid";
            addanother.Parameters.AddWithValue("@uid", Session["userid"].ToString());
            addanother.Parameters.AddWithValue("@addbool", "true");

            addanother.Connection = con;
            con.Open();
            addanother.ExecuteNonQuery();
            con.Close();
            Response.Redirect("PlacementStatus.aspx");
        }
    }
}