using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace TnpSystem
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        ReportDocument rprt = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                ErrorLabel.Text = "";
                SuccessLabel.Text = "";

            }
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            //Checking if form not submitted

            SqlCommand checkformsubmitted = new SqlCommand();
            checkformsubmitted.CommandText = " select * from department_details where ( deptno = ( select deptno from student_details where id = @uid ) )";
            checkformsubmitted.Parameters.AddWithValue("@uid", Session["userid"].ToString());

            checkformsubmitted.Connection = con;
            con.Open();

            DataSet ds_form = new DataSet();

            SqlDataAdapter da_form = new SqlDataAdapter(checkformsubmitted);
            da_form.Fill(ds_form);
            con.Close();
            if (ds_form.Tables[0].Rows.Count == 0)
            {
                ErrorLabel.Text = "Submit Form to access TNP System Features";
                PlacementStatsLabel.Visible = false;
                PlacementStatsLabelSubmit.Visible = false;

            }

            else
            {
                PlacementStatsLabel.Visible = true;
                PlacementStatsLabelSubmit.Visible = true;

                //Getting student department name
                 
                    Session["studdeptna"] = ds_form.Tables[0].Rows[0]["dname"];
                
            }


        }

        protected void PlacementStatsLabelSubmit_Click(object sender, EventArgs e)
        {

            rprt.Load(Server.MapPath("~/AdminPortal/PlacementReportDeptWise.rpt"));
            rprt.SetParameterValue("dept", Session["studdeptna"].ToString());

            rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");

            ErrorLabel.Text = "";
            SuccessLabel.Text = "Department Wise Report Generated";
        }
    }
}