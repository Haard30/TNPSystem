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
    public partial class AddCompany : System.Web.UI.Page
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

        }

        protected void AddCompanySubmit_Click(object sender, EventArgs e)
        {
          //  string uid = AddUserId.Text.ToString();
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from company_details where upper(compname) = @companyname";
            cmd.Parameters.AddWithValue("companyname", AddCompanyName.Text.ToUpper());

            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
            if (loginSuccessful)
            {
                AddCompFail.Text = "Company you entered already exist";
                AddCompSuccess.Text = "";
            }
            else
            {
                SqlCommand insertcmd = new SqlCommand();
                insertcmd.CommandText = "insert into company_details(compname,compdesc) values(@companyname,@companydesc)";
                insertcmd.Parameters.AddWithValue("@companyname", AddCompanyName.Text.ToUpper());
                insertcmd.Parameters.AddWithValue("@companydesc", AddCompDesc.Text);
                insertcmd.Connection = con;
                con.Open();
                insertcmd.ExecuteNonQuery();
                con.Close();

                AddCompanyName.Text = "";
                AddCompDesc.Text = "";
                AddCompFail.Text = "";
                AddCompSuccess.Text = "Company Added Successfully";
            }
        }
    }
}