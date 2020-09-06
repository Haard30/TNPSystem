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

namespace TnpSystem.CoordinatorPortal
{
    public partial class GenerateReport : System.Web.UI.Page
    {
        string dept_na_co;
        protected void Page_Load(object sender, EventArgs e)
        {

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }

                //Assignining datasoursce to company name list
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
                CompanyNameList.DataSource = ds.Tables[0];
                CompanyNameList.DataBind();
            }


            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            if (!IsPostBack)
            {
                BatchYearLabel.Visible = false;
                BatchYearListList.Visible = false;
                PlacementCompNameLabel.Visible = false;
                CompanyNameList.Visible = false;
                GenerateReportCommon.Visible = false;

            }

            //Select department of coordinator
            SqlCommand selectdeptcmd = new SqlCommand();
            selectdeptcmd.CommandText = " select * from department_details where ( deptno = ( select deptno from coordinator where id = @coid ) )";
            selectdeptcmd.Parameters.AddWithValue("@coid", Session["userid"].ToString());
            selectdeptcmd.Connection = con;
            con.Open();

            DataSet dsco = new DataSet();
            SqlDataAdapter daco = new SqlDataAdapter(selectdeptcmd);
            daco.Fill(dsco);
            con.Close();
            dept_na_co = dsco.Tables[0].Rows[0]["dname"].ToString();
        }

        protected void ActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ActionType.SelectedIndex == 0)
            {

                BatchYearLabel.Visible = false;
                BatchYearListList.Visible = false;
                PlacementCompNameLabel.Visible = false;
                CompanyNameList.Visible = false;
                GenerateReportCommon.Visible = false;
                ErrorLabel.Text = "Please select report type";
                SuccessLabel.Text = "";

            }
           else if (ActionType.SelectedIndex == 1)
            {

                BatchYearLabel.Visible = false;
                BatchYearListList.Visible = false;
                PlacementCompNameLabel.Visible = true;
                CompanyNameList.Visible = true;
                GenerateReportCommon.Visible = true;
            }
            else if (ActionType.SelectedIndex == 2)
            {

                BatchYearLabel.Visible = true;
                BatchYearListList.Visible = true;
                PlacementCompNameLabel.Visible = false;
                CompanyNameList.Visible = false;
                GenerateReportCommon.Visible = true;
                
            }
            else
            {

                BatchYearLabel.Visible = false;
                BatchYearListList.Visible = false;
                PlacementCompNameLabel.Visible = true;
                CompanyNameList.Visible = true;
                GenerateReportCommon.Visible = true;
            }


        }

        protected void CompanyNameList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BatchYearListList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void GenerateReportCommon_Click(object sender, EventArgs e)
        {
            ReportDocument rprt = new ReportDocument();
            
            if (ActionType.SelectedIndex == 0)
            {

            }
            else if (ActionType.SelectedIndex == 1)
            {

                SuccessLabel.Text = "done";
                //rprt.Load(Server.MapPath("~/CoordinatorPortal/ApplicationReport.rpt"));
                // rprt.SetParameterValue("compname",CompanyNameList.SelectedItem.ToString());
                rprt.Load(Server.MapPath("~/CoordinatorPortal/CrystalReport1_application.rpt"));
                rprt.SetParameterValue("companyid_sel", Convert.ToInt32(CompanyNameList.SelectedValue.ToString()));

                rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");

                ErrorLabel.Text = "";

            }
            else if (ActionType.SelectedIndex == 2)
            {

                if (BatchYearListList.SelectedValue.Equals("1"))
                {
                    ErrorLabel.Text = "Please select year";
                    SuccessLabel.Text = "";

                }

                else if (BatchYearListList.SelectedIndex == 1)
                {
                    SuccessLabel.Text = "done";
                    rprt.Load(Server.MapPath("~/AdminPortal/PlacementReportDeptWise.rpt"));
                    rprt.SetParameterValue("dept", dept_na_co);

                    rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");

                    ErrorLabel.Text = "";

                }

                else
                {


                    SuccessLabel.Text = "done";
                    rprt.Load(Server.MapPath("~/CoordinatorPortal/PlacementReportYearWise.rpt"));
                    rprt.SetParameterValue("deptname", dept_na_co);
                    rprt.SetParameterValue("year", BatchYearListList.SelectedValue);
                    rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");

                    ErrorLabel.Text = "";

                }

            }
            else
            {

                SuccessLabel.Text = "done";
                rprt.Load(Server.MapPath("~/CoordinatorPortal/CompanyReport.rpt"));
                rprt.SetParameterValue("compname", CompanyNameList.SelectedItem.ToString());
                rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");

                ErrorLabel.Text = "";
            }

        }
    }
}