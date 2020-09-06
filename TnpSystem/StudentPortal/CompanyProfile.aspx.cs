using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem.StudentPortal
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");

            if (!IsPostBack)
            {
                CompProfile.Text = "";
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

        protected void CompanyNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displaying Company name details
            string selected_value = CompanyNameList.SelectedValue.ToString();

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from company_details where compid = @comid";
            cmd.Parameters.AddWithValue("@comid",selected_value);
            cmd.Connection = con;
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            string company_details = "Company Name : " + ds.Tables[0].Rows[0]["compname"].ToString() + " <br><br> Company Description :<br>"+ ds.Tables[0].Rows[0]["compdesc"].ToString();
            CompProfile.Text = company_details;

        }
    }
}