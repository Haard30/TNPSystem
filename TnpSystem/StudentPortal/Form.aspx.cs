using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TnpSystem
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public DataTable personalTable;
        public DataTable academicTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
            }
                StudentProfileId.Text = Session["userid"].ToString();
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            SqlCommand checksubmitted = new SqlCommand();
            cmd.CommandText = "Select * from usertnp where id = @uid";
            cmd.Parameters.AddWithValue("@uid", Session["userid"].ToString());
            checksubmitted.CommandText = "Select * from student_details where id = @uid";
            checksubmitted.Parameters.AddWithValue("@uid", Session["userid"].ToString());

            checksubmitted.Connection = con;
            cmd.Connection = con;
            con.Open();
            DataSet cs = new DataSet();
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dcs = new SqlDataAdapter(checksubmitted);
            da.Fill(ds);
            dcs.Fill(cs);
            con.Close();
            if (cs.Tables[0].Rows.Count != 0 && cs.Tables[0].Rows[0][5].ToString().Equals("true"))
            {
                Response.Redirect("FormSubmitted.aspx");
            }
            else { 
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                StudentProfileEmail.Text = ds.Tables[0].Rows[0][3].ToString();
                    //Personal_details data table
                     personalTable = new DataTable();
                    personalTable.Columns.Add("pid");
                    personalTable.Columns.Add("full_name");
                    personalTable.Columns.Add("address_full");
                    personalTable.Columns.Add("mobile_number");
                    personalTable.Columns.Add("dob");
                    personalTable.Columns.Add("gender");
                    personalTable.Columns.Add("height");
                    personalTable.Columns.Add("weight_kg");
                    personalTable.Columns.Add("right_eye");
                    personalTable.Columns.Add("left_eye");
                    Session["pdt"] = personalTable;

                    //Academic_details data table
                    academicTable = new DataTable();
                    academicTable.Columns.Add("aid");
                    academicTable.Columns.Add("course");
                    academicTable.Columns.Add("xboard");
                    academicTable.Columns.Add("xschool");
                    academicTable.Columns.Add("xpercentage");
                    academicTable.Columns.Add("xiiboard");
                    academicTable.Columns.Add("xiischool");
                    academicTable.Columns.Add("xiipercentage");
                    academicTable.Columns.Add("diploma_institute");
                    academicTable.Columns.Add("diploma_aggregate");
                    academicTable.Columns.Add("sem1perc");
                    academicTable.Columns.Add("sem1attempts");
                    academicTable.Columns.Add("sem2perc");
                    academicTable.Columns.Add("sem2attempts");
                    academicTable.Columns.Add("sem3perc");
                    academicTable.Columns.Add("sem3attempts");
                    academicTable.Columns.Add("sem4perc");
                    academicTable.Columns.Add("sem4attempts");
                    academicTable.Columns.Add("sem5perc");
                    academicTable.Columns.Add("sem5attempts");
                    academicTable.Columns.Add("sem6perc");
                    academicTable.Columns.Add("sem6attempts");
                    academicTable.Columns.Add("kt_ongoing");
                    academicTable.Columns.Add("kt_cleared");
                    academicTable.Columns.Add("overall_aggregate");
                    Session["adt"] = academicTable;


                }
                else
                {
                    personalTable = (DataTable) Session["pdt"];
                    academicTable = (DataTable)Session["adt"];
                }
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            }
        }

        protected void RegistrationWizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            //Adding row to personal table
            DataRow pdtRow = personalTable.NewRow();
            pdtRow["pid"] = Session["userid"];
            pdtRow["full_name"] = StudentFullName.Text;
            pdtRow["address_full"] = StudentAddress.Text;
            pdtRow["mobile_number"] = StudentMobileNumber.Text;
            pdtRow["dob"] = StudentDOB.SelectedDate.ToString();
            pdtRow["gender"] = StudentGender.SelectedValue;
            pdtRow["height"] = StudentHeight.Text;
            pdtRow["weight_kg"] = StudentWeight.Text;
            pdtRow["left_eye"] = StudentLeftEye.Text;
            pdtRow["right_eye"] = StudentRightEye.Text;
            personalTable.Rows.Add(pdtRow);

            //Adding row to academic table

            DataRow adtRow = academicTable.NewRow();
            adtRow["aid"] = Session["userid"];
            adtRow["course"] = StudentCourse.Text;
            adtRow["xboard"] = StudentXBoard.SelectedValue;
            adtRow["xschool"] = StudentXSchool.Text;
            adtRow["xpercentage"] = StudentXPercentage.Text;
                //decimal.Parse(StudentXPercentage.Text, CultureInfo.InvariantCulture.NumberFormat);
            adtRow["xiiboard"] = StudentXiiBoard.SelectedValue;
            adtRow["xiischool"] = StudentXiiSchool.Text;
            adtRow["xiipercentage"] = StudentXPercentage.Text;
            adtRow["diploma_institute"] = StudentDiplomaInstitute.Text;
            adtRow["diploma_aggregate"] = StudentDiplomaAggregate.Text;
            adtRow["sem1perc"] = StudentSem1Perc.Text;
            adtRow["sem1attempts"] =StudentSem1Att.Text;
            adtRow["sem2perc"] = StudentSem2Perc.Text;
            adtRow["sem2attempts"] = StudentSem2Att.Text;
            adtRow["sem3perc"] = StudentSem3Perc.Text;
            adtRow["sem3attempts"] = StudentSem3Att.Text;
            adtRow["sem4perc"] = StudentSem4Perc.Text;
            adtRow["sem4attempts"] = StudentSem4Att.Text;
            adtRow["sem5perc"] = StudentSem5Perc.Text;
            adtRow["sem5attempts"] = StudentSem5Att.Text;
            adtRow["sem6perc"] = StudentSem6Perc.Text;
            adtRow["sem6attempts"] = StudentSem6Att.Text;
            adtRow["kt_ongoing"] =StudentOnGoingKt.Text;
            adtRow["kt_cleared"] =StudentClearedKt.Text;
            adtRow["overall_aggregate"] =StudentOverallAvg.Text;
            academicTable.Rows.Add(adtRow);




            //Entering personal
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection connectionObject = new SqlConnection(CS);
            
            SqlCommand cmd = new SqlCommand("dbo.InsertMyDataTablePersonal");
            SqlCommand cmdacademic = new SqlCommand("dbo.InsertMyDataTableAcademicModified");
            cmd.Connection = connectionObject;
            cmdacademic.Connection = connectionObject;
            connectionObject.Open();
            //Pesonal table add command
            cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@dt", personalTable);
                tvparam.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();


            //Academic table add command
            cmdacademic.CommandType = CommandType.StoredProcedure;
            SqlParameter paramacad = cmdacademic.Parameters.AddWithValue("@dtacad", academicTable);
            paramacad.SqlDbType = SqlDbType.Structured;
            cmdacademic.ExecuteNonQuery();

            //Inserting in student_details
            SqlCommand insertcmd = new SqlCommand();
            insertcmd.CommandText = "insert into student_details values(@uid,@uid,@uid,@uid,@uid,@formsub,@deptno)";
            insertcmd.Parameters.AddWithValue("@uid", Session["userid"].ToString());
            insertcmd.Parameters.AddWithValue("@formsub","true");
            insertcmd.Parameters.AddWithValue("@deptno",StudentDepartment.SelectedValue);
            insertcmd.Connection = connectionObject;
            insertcmd.ExecuteNonQuery();

            //Updating E-mail id
            SqlCommand cmdupdateuser = new SqlCommand();
            cmdupdateuser.CommandText = "update usertnp set email = @email where id = @usid";
            cmdupdateuser.Parameters.AddWithValue("@usid", Session["userid"].ToString());
            cmdupdateuser.Parameters.AddWithValue("@email", StudentProfileEmail.Text);
            cmdupdateuser.Connection = connectionObject;
            cmdupdateuser.ExecuteNonQuery();

            //Updating Notification department number
            SqlCommand cmdupdatedept = new SqlCommand();
            cmdupdatedept.CommandText = "update notification_details set deptno = @dno where notid = @usid";
            cmdupdatedept.Parameters.AddWithValue("@usid", Session["userid"].ToString());
            cmdupdatedept.Parameters.AddWithValue("@dno", StudentDepartment.SelectedValue);
            cmdupdatedept.Connection = connectionObject;
            cmdupdatedept.ExecuteNonQuery();




            connectionObject.Close();



            Response.Redirect("FormSubmitted.aspx");
        }

        protected void StudentProfileId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void StudentProfileEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RegistrationWizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if(RegistrationWizard.ActiveStepIndex == 0)
            {
                if (StudentProfileEmail.Text == "")
                {
                    ErrorLabelGeneral.Text = "Please enter your e-mail";
                    RegistrationWizard.ActiveStepIndex = 0;
                    e.Cancel = true;
                }
                else if (StudentDepartment.SelectedIndex == 0)
                {

                    ErrorLabelGeneral.Text = "Please Select Department";
                    RegistrationWizard.ActiveStepIndex = 0;
                    e.Cancel = true;
                }
            }
            else if (RegistrationWizard.ActiveStepIndex == 1)
            {
                if (StudentFullName.Text.Equals("") || StudentGender.SelectedIndex == 0 || StudentMobileNumber.Text.Equals("")
                    || StudentHeight.Text.Equals("") || StudentWeight.Text.Equals("") || StudentAddress.Text.Equals("")
                    || StudentDOB.SelectedDate.Equals(""))
                {
                    ErrorLabelPersonal.Text = "Please complete reqired fields";
                    RegistrationWizard.ActiveStepIndex = 1;
                    e.Cancel = true;
                }
                else if ((StudentDepartment.SelectedIndex == 6 || StudentDepartment.SelectedIndex == 7 ) && (StudentLeftEye.Text.Equals("") || StudentRightEye.Text.Equals("")))
                {
                    ErrorLabelPersonal.Text = "Civil and IWM students require eye fields";
                    RegistrationWizard.ActiveStepIndex = 1;
                    e.Cancel = true;

                }

            }
            else if (RegistrationWizard.ActiveStepIndex == 2)
            {

                if ((StudentStream.SelectedValue.Equals("diploma") && (StudentXiiSchool.Text.Equals("") || StudentXSchool.Text.Equals("") || StudentXiiPercentage.Text.Equals("")))
                    || StudentXPercentage.Text.Equals("") || StudentSem1Perc.Text.Equals("") || StudentSem2Perc.Text.Equals("")
                    || StudentSem3Perc.Text.Equals("") || StudentSem4Perc.Text.Equals("") || StudentSem5Perc.Text.Equals("")
                    || StudentSem6Perc.Text.Equals("") || StudentSem1Att.Text.Equals("") || StudentSem2Att.Text.Equals("")
                    || StudentSem3Att.Text.Equals("") || StudentSem4Att.Text.Equals("") || StudentSem5Att.Text.Equals("")
                    || StudentSem6Att.Text.Equals("") || StudentOnGoingKt.Text.Equals("") || StudentOverallAvg.Text.Equals("")
                    || StudentClearedKt.Text.Equals("") || StudentCourse.Text.Equals("") ||
                    (StudentStream.SelectedValue.Equals("diploma") &&  (StudentDiplomaInstitute.Text.Equals("") || StudentDiplomaAggregate.Text.Equals(""))))
                {
                    ErrorLabelAcademic.Text = "Please complete reqired fields";
                    RegistrationWizard.ActiveStepIndex = 2;
                    e.Cancel = true;
                }
                else if (StudentXBoard.SelectedIndex == 0 || StudentXiiBoard.SelectedIndex == 0  || StudentStream.SelectedIndex == 0)
                {

                    ErrorLabelAcademic.Text = "Please Complete 10/12 board/stream Dropdown list";
                    RegistrationWizard.ActiveStepIndex = 2;
                    e.Cancel = true;

                }
            }
            else
            {
                if(StudentTermsAndCond.Checked == false)
                {
                    ErrorLabel.Text = "Please agree to the terms and conditions to complete submition";
                }
            }

        }

        protected void RegistrationWizard_ActiveStepChanged(object sender, EventArgs e)
        {

        }

        protected void RegistrationWizard_SideBarButtonClick(object sender, WizardNavigationEventArgs e)
        {

            if (RegistrationWizard.ActiveStepIndex == 0)
            {
                if (StudentProfileEmail.Text == "")
                {
                    ErrorLabelGeneral.Text = "Please complete the step before going to next";
                    RegistrationWizard.ActiveStepIndex = 0;
                     e.Cancel = true;
                }
                else if (StudentDepartment.SelectedIndex == 0)
                {

                    ErrorLabelGeneral.Text = "Please complete the step before going to next";
                    RegistrationWizard.ActiveStepIndex = 0;
                       e.Cancel = true;
                }
            }
            else if (RegistrationWizard.ActiveStepIndex == 1)
            {
                if (StudentFullName.Text.Equals("") || StudentGender.SelectedIndex == 0 || StudentMobileNumber.Text.Equals("")
                    || StudentHeight.Text.Equals("") || StudentWeight.Text.Equals("") || StudentAddress.Text.Equals("")
                    || StudentDOB.SelectedDate.Equals(""))
                {
                    ErrorLabelPersonal.Text = "Please complete reqired fields";
                    RegistrationWizard.ActiveStepIndex = 1;
                     e.Cancel = true;
                }
                else if ((StudentDepartment.SelectedIndex == 6 || StudentDepartment.SelectedIndex == 7) && (StudentLeftEye.Text.Equals("") || StudentRightEye.Text.Equals("")))
                {
                    ErrorLabelPersonal.Text = "Civil and IWM students require eye fields";
                    RegistrationWizard.ActiveStepIndex = 1;
                    e.Cancel = true;

                }

            }
            else if (RegistrationWizard.ActiveStepIndex == 2)
            {

                if ((StudentStream.SelectedValue.Equals("diploma") && (StudentXiiSchool.Text.Equals("") || StudentXSchool.Text.Equals("") || StudentXiiPercentage.Text.Equals("")))
                    || StudentXPercentage.Text.Equals("") || StudentSem1Perc.Text.Equals("") || StudentSem2Perc.Text.Equals("")
                    || StudentSem3Perc.Text.Equals("") || StudentSem4Perc.Text.Equals("") || StudentSem5Perc.Text.Equals("")
                    || StudentSem6Perc.Text.Equals("") || StudentSem1Att.Text.Equals("") || StudentSem2Att.Text.Equals("")
                    || StudentSem3Att.Text.Equals("") || StudentSem4Att.Text.Equals("") || StudentSem5Att.Text.Equals("")
                    || StudentSem6Att.Text.Equals("") || StudentOnGoingKt.Text.Equals("") || StudentOverallAvg.Text.Equals("")
                    || StudentClearedKt.Text.Equals("") || StudentCourse.Text.Equals("") ||
                    (StudentStream.SelectedValue.Equals("diploma") && (StudentDiplomaInstitute.Text.Equals("") || StudentDiplomaAggregate.Text.Equals(""))))
                {
                    ErrorLabelAcademic.Text = "Please complete reqired fields";
                    RegistrationWizard.ActiveStepIndex = 2;
                    e.Cancel = true;
                }
                else if (StudentXBoard.SelectedIndex == 0 || StudentXiiBoard.SelectedIndex == 0 || StudentStream.SelectedIndex == 0)
                {

                    ErrorLabelAcademic.Text = "Please Complete 10/12 board/stream Dropdown list";
                    RegistrationWizard.ActiveStepIndex = 2;
                    e.Cancel = true;

                }
            }
            else
            {
                if (StudentTermsAndCond.Checked == false)
                {
                    ErrorLabel.Text = "Please agree to the terms and conditions to complete submition";
                }
                else
                {
                    Response.Redirect("FormSubmitted.aspx");
                }
            }
        }
    }
}