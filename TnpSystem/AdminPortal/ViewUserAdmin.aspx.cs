using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TnpSystem.AdminPortal
{
    public partial class ViewUserAdmin : System.Web.UI.Page
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

                CoordiReportSubmit.Visible = false;
                YearWiseSubmit.Visible = false;
                PlacementYearsList.Visible = false;
                SelectYearLabel.Visible = false;
                SelectDeptList.Visible = false;
                SelectDeptLabel.Visible = false;
                ErrorLabel.Text = "";
                SuccessLabel.Text = "";

            }
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
 }

        protected void ActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ActionType.SelectedIndex == 0)
            {
                ErrorLabel.Text = "Please select an option";
                SuccessLabel.Text = "";

                CoordiReportSubmit.Visible = false;
                YearWiseSubmit.Visible = false;
                SelectDeptLabel.Visible = false;
                PlacementYearsList.Visible = false;
                SelectYearLabel.Visible = false;
            }
            else if(ActionType.SelectedIndex == 1)
            {
                CoordiReportSubmit.Visible = true;
                YearWiseSubmit.Visible = false;
                SelectDeptLabel.Visible = false;
                PlacementYearsList.Visible = false;
                SelectYearLabel.Visible = false;
            }
            else if(ActionType.SelectedIndex == 2)
            {
                //Assgning DataSource to year list
                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select distinct batchyear from placements";
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                PlacementYearsList.DataTextField = ds.Tables[0].Columns["batchyear"].ToString();
                PlacementYearsList.DataValueField = ds.Tables[0].Columns["batchyear"].ToString();
                PlacementYearsList.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                PlacementYearsList.DataBind();

                SelectDeptLabel.Visible = false;
                PlacementYearsList.Visible = true;
                SelectYearLabel.Visible = true;
                SelectDeptList.Visible = false;
                CoordiReportSubmit.Visible = false;
                YearWiseSubmit.Visible = true;
            }
            else if (ActionType.SelectedIndex == 3)
            {

                //Assgning DataSource to department list
                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from department_details";
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                SelectDeptList.DataTextField = ds.Tables[0].Columns["dname"].ToString();
                SelectDeptList.DataValueField = ds.Tables[0].Columns["dname"].ToString();
                SelectDeptList.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                SelectDeptList.DataBind();
                SelectDeptLabel.Visible = true;
                SelectDeptList.Visible = true;
                PlacementYearsList.Visible = false;
                SelectYearLabel.Visible = false;
                CoordiReportSubmit.Visible = false;
                YearWiseSubmit.Visible = true;

            }
        }
        
        //ausdnoadnoidasx
        protected void CoordiReportSubmit_Click1(object sender, EventArgs e)
        {
                rprt.Load(Server.MapPath("~/AdminPortal/CoordiReport.rpt"));

                //bringing data

                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select department_details.dname,usertnp.id,coordinator.cname,usertnp.email from usertnp,department_details,coordinator where coordinator.id = usertnp.id and department_details.deptno = coordinator.deptno";
                //cmd.Parameters.AddWithValue("@uid", uid);

                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Coordireport");
                rprt.SetDataSource(ds);
                con.Close();
                rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Coordinator List");

                ErrorLabel.Text = "";
                SuccessLabel.Text = "Report Generated";
            

        }

        protected void YearWiseSubmit_Click(object sender, EventArgs e)
        {


            if (ActionType.SelectedIndex == 2)
            {
                rprt.Load(Server.MapPath("~/AdminPortal/PlacementReportYearWise.rpt"));
                rprt.SetParameterValue("year", PlacementYearsList.SelectedValue.ToString());

                rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");

                ErrorLabel.Text = "";
                SuccessLabel.Text = "Year Wise Report Generated Successfully";
            }
            else
            {

                rprt.Load(Server.MapPath("~/AdminPortal/PlacementReportDeptWise.rpt"));
                rprt.SetParameterValue("dept", SelectDeptList.SelectedValue.ToString());

                rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");

                ErrorLabel.Text = "";
                SuccessLabel.Text = "Department Wise Report Generated";
            }


        }

        protected void PlacementYearsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void SelectDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}