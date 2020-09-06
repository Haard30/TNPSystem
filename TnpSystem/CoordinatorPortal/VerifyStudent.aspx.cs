using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem.CoordinatorPortal
{
    public partial class VerfyStudent : System.Web.UI.Page
    {

        string filePath = "";
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
            if (!IsPostBack)
            {
                GridView1.Visible = false;
                DownloadResumeSubmit.Visible = false;
                ViewStudentReport.Visible = false;
                ErrorLabel.Text = "";
                SuccessLabel.Text = "";
                BindGridView();

            }
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            //Select department of coordinator
            SqlCommand selectdeptcmd = new SqlCommand();
            selectdeptcmd.CommandText = "Select * from coordinator where id = @coid";
            selectdeptcmd.Parameters.AddWithValue("@coid", Session["userid"].ToString());
            selectdeptcmd.Connection = con;
            con.Open();

            DataSet dsco = new DataSet();
            SqlDataAdapter daco = new SqlDataAdapter(selectdeptcmd);
            daco.Fill(dsco);
            con.Close();
            Session["codeptno"] = dsco.Tables[0].Rows[0]["deptno"].ToString();
        //    GridView1.Visible = true;

        }

        private void BindGridView()
        {

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("Select * From docname", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Friend");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void ViewUserSubmit_Click(object sender, EventArgs e)
        {

            //Checking if user exist and if is of same department

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.CommandText = "Select * from student_details where id = @uid AND deptno = @codeptno";

            selectcmd.Parameters.AddWithValue("@uid", UserId.Text.ToString());
            selectcmd.Parameters.AddWithValue("@codeptno", Session["codeptno"]);
            selectcmd.Connection = con;

            con.Open();
            DataSet ds1 = new DataSet();

            SqlDataAdapter da1 = new SqlDataAdapter(selectcmd);
            da1.Fill(ds1);

            //If user registered and department matches then
            if (ds1.Tables[0].Rows.Count != 0)
            {
                GridView1.Visible = true;
                ErrorLabel.Text = "";
                ViewStudentReport.Visible = true;
                DownloadResumeSubmit.Visible = true;
            }
            else
            {
                ViewStudentReport.Visible = false;
                GridView1.Visible = false;
                DownloadResumeSubmit.Visible = false;
                ErrorLabel.Text = "User is not registered or not of your department";
            }
            con.Close();

        }

        protected void btnView_Click(object sender, EventArgs e)
        {

            //Selecting document path

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.CommandText = "Select * from document_details where docid = @uid";

            selectcmd.Parameters.AddWithValue("@uid", UserId.Text.ToString());
            selectcmd.Connection = con;

            con.Open();

            DataSet ds1 = new DataSet();

            SqlDataAdapter da1 = new SqlDataAdapter(selectcmd);
            da1.Fill(ds1);


            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            
            if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("10th STD")) {
                filePath = ds1.Tables[0].Rows[0]["x"].ToString();
            }
            else if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("12th STD"))
            {
                filePath = ds1.Tables[0].Rows[0]["xii"].ToString();
            }
            else if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("Diploma"))
            {
                filePath = ds1.Tables[0].Rows[0]["diploma"].ToString();
            }
            else if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("Sem 1"))
            {
                filePath = ds1.Tables[0].Rows[0]["sem1"].ToString();
            }
            else if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("Sem 2"))
            {
                filePath = ds1.Tables[0].Rows[0]["sem2"].ToString();
            }
            else if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("Sem 3"))
            {
                filePath = ds1.Tables[0].Rows[0]["sem3"].ToString();
            }
            else if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("Sem 4"))
            {
                filePath = ds1.Tables[0].Rows[0]["sem4"].ToString();
            }
            else if (GridView1.DataKeys[gvrow.RowIndex].Value.ToString().Equals("Sem 5"))
            {
                filePath = ds1.Tables[0].Rows[0]["sem5"].ToString();
            }
            else
            {
                filePath = ds1.Tables[0].Rows[0]["sem6"].ToString();
            }


            Response.Write(String.Format("<script>window.open('{0}','_blank');</script>", "ViewDocs.aspx?fn=" + filePath));
        }

        protected void DownloadResumeSubmit_Click(object sender, EventArgs e)
        {

            //Selecting document path

            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.CommandText = "Select * from document_details where docid = @uid";

            selectcmd.Parameters.AddWithValue("@uid", UserId.Text.ToString());
            selectcmd.Connection = con;

            con.Open();

            DataSet ds1 = new DataSet();

            SqlDataAdapter da1 = new SqlDataAdapter(selectcmd);
            da1.Fill(ds1);


            filePath = ds1.Tables[0].Rows[0]["resume"].ToString();
            if (filePath != string.Empty)
            {
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=resume.pdf");
                byte[] data = req.DownloadData(Server.MapPath(filePath));
                response.BinaryWrite(data);
                response.End();
            }
            Response.TransmitFile(Server.MapPath(filePath));

        }

        protected void ViewStudentReport_Click(object sender, EventArgs e)
        {
            ReportDocument rprt = new ReportDocument();
            rprt.Load(Server.MapPath("~/CoordinatorPortal/ViewUserReport.rpt"));
            rprt.SetParameterValue("studid", UserId.Text.ToString());

            rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");
        }
    }
}