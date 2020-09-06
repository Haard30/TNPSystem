using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;

namespace TnpSystem.StudentPortal
{
    public partial class MarksheetUpload : System.Web.UI.Page
    {
        // string deptno;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] == null)
            {
                Response.Redirect("../Login.aspx");
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
                Response.Redirect("FormNotSubmitted.aspx");
            }

            else
            {
                //Getting student department name
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select * from department_details where ( deptno = ( select deptno from student_details where id = @uid ) )";
                cmd.Parameters.AddWithValue("@uid", Session["userid"].ToString());

                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Session["studdeptna"] = ds.Tables[0].Rows[0]["dname"];
                }
            }
        }

        protected void UploadAllSubmit_Click(object sender, EventArgs e)
        {
            string studdeptna = Session["studdeptna"].ToString();
            string prn = Session["userid"].ToString();

            //prn directory check
            if (!Directory.Exists(Server.MapPath("~/TNPSystemDocs/" + studdeptna + "/" + prn)))
            {
                Directory.CreateDirectory(Server.MapPath("~/TNPSystemDocs/" + studdeptna + "/" + prn));
            }

            string x, xii, sem1, sem2, sem3, sem4, sem5, sem6, resume, diploma;


            //Gee=tting file names to check extension
            x = XMarksheet.PostedFile.FileName;
            xii = XiiMarksheet.PostedFile.FileName;
            sem1 = Sem1Marksheet.PostedFile.FileName;
            sem2 = Sem2Marksheet.PostedFile.FileName;
            sem3 = Sem3Marksheet.PostedFile.FileName;
            sem4 = Sem4Marksheet.PostedFile.FileName;
            sem5 = Sem5Marksheet.PostedFile.FileName;
            sem6 = Sem6Marksheet.PostedFile.FileName;
            diploma = diplomamarksheet.PostedFile.FileName;
            resume = ResumeUpload.PostedFile.FileName;

            if (!(Path.GetExtension(x).Equals(".jpg") && Path.GetExtension(xii).Equals(".jpg")
                && Path.GetExtension(sem1).Equals(".jpg") && Path.GetExtension(sem2).Equals(".jpg")
                && Path.GetExtension(sem3).Equals(".jpg") && Path.GetExtension(sem4).Equals(".jpg")
                && Path.GetExtension(sem5).Equals(".jpg") && Path.GetExtension(sem6).Equals(".jpg")
                && Path.GetExtension(resume).Equals(".pdf")))
            {
                ErrorLabel.Text = "Only jpg for marksheets and pdf for resume are supported!! ;(";
                SuccessLabel.Text = "";
            }
            else if (!(XiiMarksheet.HasFile || diplomamarksheet.HasFile))
            {

                ErrorLabel.Text = "Please upload atleast one from XII or Diploma";
                SuccessLabel.Text = "";

            }
            else
            {
                //General path for file saving
                string path = "~/TNPSystemDocs/" + studdeptna + "/" + prn + "/";

                //Deleting Files if they already exists
                if (File.Exists((Server.MapPath(path + "" + "x.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "x.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "xii.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "xii.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "diploma.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "diploma.jpg")));
                }

                if (File.Exists((Server.MapPath(path + "" + "sem1.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "sem1.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "sem2.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "sem2.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "sem3.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "sem3.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "sem4.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "sem4.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "sem5.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "sem5.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "sem6.jpg"))))
                {
                    File.Delete((Server.MapPath(path + "" + "sem6.jpg")));
                }
                if (File.Exists((Server.MapPath(path + "" + "resume.pdf"))))
                {
                    File.Delete((Server.MapPath(path + "" + "resume.pdf")));
                }



                //Saving Files
                XMarksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "x.jpg"));
                if (XiiMarksheet.HasFile)
                {
                    XiiMarksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "xii.jpg"));
                }
                else
                {
                    diplomamarksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "diploma.jpg"));
                }

                Sem1Marksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "sem1.jpg"));
                Sem2Marksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "sem2.jpg"));
                Sem3Marksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "sem3.jpg"));
                Sem4Marksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "sem4.jpg"));
                Sem5Marksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "sem5.jpg"));
                Sem6Marksheet.PostedFile.SaveAs(Server.MapPath(path + "" + "sem6.jpg"));
                ResumeUpload.PostedFile.SaveAs(Server.MapPath(path + "" + "resume.pdf"));

                //Saving in Database
                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update document_details set x=@x, xii=@xii, diploma=@diplo, sem1=@s1, sem2=@s2, sem3=@s3, sem4=@s4, sem5=@s5, sem6=@s6, resume=@res where docid=@uid";
                cmd.Parameters.AddWithValue("@uid", prn);
                string temppath = path + "x.jpg";
              cmd.Parameters.AddWithValue("@x", temppath);
                temppath = path + "xii.jpg";
                cmd.Parameters.AddWithValue("@xii", temppath);
                temppath = path + "diploma.jpg";
                cmd.Parameters.AddWithValue("@diplo", temppath);
                temppath = path + "sem1.jpg";
                cmd.Parameters.AddWithValue("@s1", temppath);
                temppath = path + "sem2.jpg";
                cmd.Parameters.AddWithValue("@s2", temppath);
                temppath = path + "sem3.jpg";
                cmd.Parameters.AddWithValue("@s3", temppath);
                temppath = path + "sem4.jpg";
                cmd.Parameters.AddWithValue("@s4", temppath);
                temppath = path + "sem5.jpg";
                cmd.Parameters.AddWithValue("@s5", temppath);
                temppath = path + "sem6.jpg";
                cmd.Parameters.AddWithValue("@s6", temppath);
                temppath = path + "resume.pdf";
                cmd.Parameters.AddWithValue("@res", temppath); 
                
   cmd.Connection = con;
   con.Open();
   cmd.ExecuteNonQuery();
   con.Close();


   ErrorLabel.Text = "";
   SuccessLabel.Text = "All Files have been successfully uploaded";
}

}
}
}
 