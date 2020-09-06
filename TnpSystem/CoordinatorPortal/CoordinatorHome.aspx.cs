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
    public partial class CoordinatorHome : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Login.aspx");


                }

                CoordiProfileId.Text = Session["userid"].ToString();
                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from coordinator where id = @uid";
                cmd.Parameters.AddWithValue("@uid", Session["userid"].ToString());

                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                CoordiProfileName.Text = ds.Tables[0].Rows[0][1].ToString();
                cmd.CommandText = "Select * from usertnp where id = @uid";
                SqlDataAdapter dada = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                CoordiProfileEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                con.Close();
            }


            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
        }

        protected void AdminProfileId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AdminProfileName_TextChanged(object sender, EventArgs e)
        {
            //nameupdate = AdminProfileName.Text.ToString();

        }

        protected void AdminProfileEmail_TextChanged(object sender, EventArgs e)
        {
            //emailupdate = AdminProfileEmail.Text.ToString();
        }

        protected void AdminProfileUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmdupdatecoordi = new SqlCommand();
            SqlCommand cmdupdateuser = new SqlCommand();
            cmdupdatecoordi.Connection = con;
            cmdupdateuser.Connection = con;
            //Update in coordinator table
            cmdupdatecoordi.CommandText = "update coordinator set cname = @aname where id = @userid";
            cmdupdatecoordi.Parameters.AddWithValue("@userid", Session["userid"].ToString());
            cmdupdatecoordi.Parameters.AddWithValue("@aname", CoordiProfileName.Text.ToString());
            //Update in user table
            cmdupdateuser.CommandText = "update usertnp set email = @email where id = @usid";
            cmdupdateuser.Parameters.AddWithValue("@usid", Session["userid"].ToString());
            cmdupdateuser.Parameters.AddWithValue("@email", CoordiProfileEmail.Text.ToString());

            con.Open();
            cmdupdatecoordi.ExecuteNonQuery();
            cmdupdateuser.ExecuteNonQuery();
            con.Close();
            UpdateCoordiActionSuccess.Text = "Profile updated Successfully";
        }
    }
}