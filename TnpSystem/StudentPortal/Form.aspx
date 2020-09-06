<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="TnpSystem.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>TNP PORTAL</title>
    <!-- Bootstrap Styles-->
    <link href="assets/cssdash/bootstrap.css" rel="stylesheet" />
    <!-- FontAwesome Styles-->
    <link href="assets/cssdash/font-awesome.css" rel="stylesheet" />
    <!-- Morris Chart Styles-->
    <link href="assets/jsdash/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <!-- Custom Styles-->
    <link href="assets/cssdash/custom-styles.css" rel="stylesheet" />

    <!-- Next Button -->
    <link href="assets/cssdash/NextButton.css" rel="stylesheet" />

    <!-- Google Fonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <nav class="navbar navbar-default top-navbar" role="navigation">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">

                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="StudentHome.aspx">TNP Portal (Candidate Login)</a>
                </div>

                <ul class="nav navbar-top-links navbar-right">
                    <!-- /.dropdown -->
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">
                            <i class="fa fa-user fa-fw"></i><i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu dropdown-user">
                            <li><a href="../ForgotPassword.aspx"><i class="fa fa-sign-out fa-fw"></i>Change Password</a>
                            </li>

                            <li><a href="../Login.aspx"><i class="fa fa-sign-out fa-fw"></i>Logout</a>
                            </li>

                        </ul>

                    </li>
                </ul>

            </nav>
            <!--/. NAV TOP  -->
            <nav class="navbar-default navbar-side" role="navigation">
                <div class="sidebar-collapse">
                    <ul class="nav" id="main-menu">

                        <li>
                            <a href="StudentHome.aspx"><i class="fa fa-dashboard"></i>Notification Desk</a>
                        </li>
                        <li>
                            <a href="PlacementStatus.aspx"><i class="fa fa-desktop"></i>Placement Status</a>
                        </li>

                        <li>
                            <a href="Form.aspx" class="active-menu"><i class="fa fa-edit"></i>Form Submision </a>
                        </li>


                        <li>
                            <a href="#"><i class="fa fa-sitemap"></i>Documents Upload<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <a href="MarksheetUpload.aspx">Marksheets & Resume Upload</a>
                                </li>
                                

                            </ul>
                        </li>

                        <li>
                            <a href="ViewStats.aspx"><i class="fa fa-bar-chart-o"></i>View Stats</a>
                        </li>
                        <li>
                        <a href="CompanyProfile.aspx"><i class="fa fa-desktop"></i> Company Profile</a>
                    </li>
                    </ul>

                </div>

            </nav>

            <!-- /. NAV SIDE  -->
            <div id="page-wrapper">
                <div id="page-inner">
                    <div class="row">
                        <div class="col-md-12">
                            <h1 class="page-header">Registration Form <small>TNP candidate registration form.</small>
                            </h1>
                        </div>
                    </div>
                    <asp:Wizard ID="RegistrationWizard" runat="server" ActiveStepIndex="0" Height="203px" Width="1102px" OnFinishButtonClick="RegistrationWizard_FinishButtonClick" CellPadding="10" OnActiveStepChanged="RegistrationWizard_ActiveStepChanged" OnNextButtonClick="RegistrationWizard_NextButtonClick" OnSideBarButtonClick="RegistrationWizard_SideBarButtonClick">
                        <NavigationButtonStyle CssClass="buttonnext" />

                        <StartNextButtonStyle CssClass="buttonnext" />
                        <StepNextButtonStyle CssClass="buttonnext" />
                        <SideBarButtonStyle CssClass="buttonSide" />

                        <SideBarStyle CssClass="btn-group" />

                        <StepStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />

                        <WizardSteps>
                            <asp:WizardStep ID="BasicInfoStep" runat="server" Title="Basic Information">
                                <div class="form-group">
                                    <label for="disabledSelect" style="font-size: large">My PRN </label>
                                    <asp:TextBox class="form-control" ID="StudentProfileId" runat="server" type="text" placeholder="Auto-generated" disabled="" Width="60%" OnTextChanged="StudentProfileId_TextChanged"></asp:TextBox>
                                </div>
                                <p />
                                <div class="form-group">
                                    <label style="font-size: large">E-mail-ID</label>
                                    <asp:TextBox class="form-control" placeholder="Enter E-mail" ID="StudentProfileEmail" runat="server" Width="60%" AutoPostBack="False" OnTextChanged="StudentProfileEmail_TextChanged"></asp:TextBox>
                                </div>
                                <p />

                                <div class="form-group">
                                    <label style="font-size: large">Department <sup>*</sup></label>
                                    <br />

                                    <asp:DropDownList ID="StudentDepartment" runat="server" Width="60%" Height="310%" require="" AutoPostBack="False">
                                        <asp:ListItem Value="1">--Select--</asp:ListItem>
                                        <asp:ListItem Value="2">Computer Science</asp:ListItem>
                                        <asp:ListItem Value="3">Mechanical</asp:ListItem>
                                        <asp:ListItem Value="4">Electrical</asp:ListItem>
                                        <asp:ListItem Value="5">Electronics</asp:ListItem>
                                        <asp:ListItem Value="6">Chemical</asp:ListItem>
                                        <asp:ListItem Value="7">Civil</asp:ListItem>
                                        <asp:ListItem Value="8">IWM</asp:ListItem>

                                    </asp:DropDownList>

                                </div>


                                <p>
                                    <label>Fields marked with * are compulsory</label><br />
                                    <asp:Label ID="ErrorLabelGeneral" runat="server" Width="30%" ForeColor="Red"></asp:Label>
                                </p>

                            </asp:WizardStep>

                            <asp:WizardStep ID="PersonalInfoStep" runat="server" Title="Personal Information">

                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <%--Name TextBox--%>
                                                <label style="font-size: large">Full name<sup>*</sup></label>
                                                <div class="help-block">(First Name-Middle Name-Last Name)</div>
                                                <asp:TextBox class="form-control" require="" placeholder="Enter your name" ID="StudentFullName" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                            <%--Adreess TextBox--%>
                                            <p />
                                            <label style="font-size: large">Permanent address<sup>*</sup></label>
                                            <br />
                                            <asp:TextBox class="form-control" require="" TextMode="MultiLine" placeholder="Enter your address here" ID="StudentAddress" runat="server" Width="80%" Rows="4" AutoPostBack="False"></asp:TextBox>
                                            <%--Moblie Number--%>
                                            <p />
                                            <label style="font-size: large">Mobile Number<sup>*</sup></label>
                                            <br />
                                            <asp:TextBox class="form-control" placeholder="Your 10 digit cell number" ID="StudentMobileNumber" runat="server" Width="80%" AutoPostBack="False" MaxLength="10"></asp:TextBox>

                                            <%--Date of birth--%>
                                            <p />
                                            <label style="font-size: large">Date Of Birth<sup>*</sup></label>
                                            <br />
                                            <asp:Calendar ID="StudentDOB" runat="server"></asp:Calendar>




                                        </div>
                                        <!-- /.col-lg-6 (nested) -->
                                        <div class="col-lg-6">

                                            <%--Gender of student--%>

                                            <label style="font-size: large">Gender<sup>*</sup></label>
                                            <p />

                                            <asp:DropDownList ID="StudentGender" runat="server" Width="60%" Height="310%" require="" AutoPostBack="False">
                                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                <asp:ListItem Value="male">Male</asp:ListItem>
                                                <asp:ListItem Value="female">Female</asp:ListItem>
                                                <asp:ListItem Value="unknown">Unknown</asp:ListItem>


                                            </asp:DropDownList>

                                            <div class="form-group">
                                                <%--Weight of student--%>
                                                <p />
                                                <label style="font-size: large">Weight<sup>*</sup></label>
                                                <asp:TextBox type='number' max='300' class="form-control" placeholder="Weight in kg" ID="StudentWeight" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                            <%--Height of student--%>
                                            <p />
                                            <label style="font-size: large">Height<sup>*</sup></label>
                                            <asp:TextBox type='number' max='300' class="form-control" placeholder="Height in cms" ID="StudentHeight" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>

                                            <%--Left Eye of student--%>
                                            <p>
                                                <label style="font-size: large">Left Eye</label>
                                                <asp:TextBox class="form-control" placeholder="0.00" ID="StudentLeftEye" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                            </p>
                                            <%--Right Eye of student--%>
                                            <p />
                                            <label style="font-size: large">Right Eye</label>
                                            <asp:TextBox class="form-control" placeholder="0.00" ID="StudentRightEye" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <p>
                                        <label>Fields marked with * are compulsory</label><br />
                                        <asp:Label ID="ErrorLabelPersonal" runat="server" Width="30%" ForeColor="Red"></asp:Label>
                                    </p>
                                </div>
                            </asp:WizardStep>
                            <asp:WizardStep ID="AcademiInfoStep" runat="server" Title="Academic Information">
                                <%-- Wizard step to be modified--%>

                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">

                                            <%--10 Standard Board--%>
                                            <div class="form-group">
                                                <label style="font-size: large">10<sup>th </sup>standard Board<sup>*</sup></label>
                                                <asp:DropDownList ID="StudentXBoard" runat="server" Width="60%" Height="310%" require="" AutoPostBack="False">
                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="gujarat_board">Gujarat Board</asp:ListItem>
                                                    <asp:ListItem Value="cbse">CBSE</asp:ListItem>
                                                    <asp:ListItem Value="icse">ICSE</asp:ListItem>
                                                    <asp:ListItem Value="other">other state board</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <%--10 School--%>
                                            <div class="form-group">
                                                <label style="font-size: large">10<sup>th </sup>standard school<sup>*</sup></label>
                                                <asp:TextBox class="form-control" placeholder="School name" ID="StudentXSchool" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%--10 Percentage--%>
                                            <div class="form-group">
                                                <label style="font-size: large">10<sup>th </sup>standard precentage<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentXPercentage" runat="server" Width="40%" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                            <div></div>
                                            <div class="form-group">
                                                <%--Course Stream--%>
                                                <label style="font-size: large">Stream after 10<sup>th</sup><sup>*</sup></label>
                                                <br />
                                                <asp:DropDownList ID="StudentStream" runat="server" Width="60%" Height="310%" require="" AutoPostBack="False">
                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="science">Science</asp:ListItem>
                                                    <asp:ListItem Value="diploma">Diploma</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <%--12 Standard Board--%>
                                            <div class="form-group">
                                                <label style="font-size: large">12<sup>th </sup>standard Board</label>
                                                <asp:DropDownList ID="StudentXiiBoard" runat="server" Width="60%" Height="310%" require="" AutoPostBack="False">
                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="gujarat_board">Gujarat Board</asp:ListItem>
                                                    <asp:ListItem Value="cbse">CBSE</asp:ListItem>
                                                    <asp:ListItem Value="icse">ICSE</asp:ListItem>
                                                    <asp:ListItem Value="other">other state board</asp:ListItem>

                                                </asp:DropDownList>
                                            </div>
                                            <%--12 School--%>
                                            <div class="form-group">
                                                <label style="font-size: large">12<sup>th </sup>standard school</label>
                                                <asp:TextBox class="form-control" placeholder="School name" ID="StudentXiiSchool" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%--12 Percentage--%>
                                            <div class="form-group">
                                                <label style="font-size: large">12<sup>th </sup>standard precentage</label>
                                                <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentXiiPercentage" runat="server" Width="40%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%--Diploma Institute--%>
                                            <div class="form-group">
                                                <label style="font-size: large">Institute Of Diploma</label>
                                                <asp:TextBox class="form-control" placeholder="Institute name" ID="StudentDiplomaInstitute" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%--Diploma Percentage--%>
                                            <div class="form-group">
                                                <label style="font-size: large">Diploma Aggregate</label>
                                                <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentDiplomaAggregate" runat="server" Width="40%" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <!-- /.col-lg-6 (nested) -->
                                        <div class="col-lg-6">

                                            <div class="form-group">
                                                <%--Course TextBox--%>
                                                <label style="font-size: large">Graduate Course Name<sup>*</sup></label>
                                                <asp:TextBox class="form-control" placeholder="Course name" ID="StudentCourse" runat="server" Width="80%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%--Sem 1 Percentage--%>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="font-size: large">Sem 1 %<sup>*</sup></label>
                                                    <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentSem1Perc" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <%--sem 1 attempts--%>

                                                <label style="font-size: large">Attempts<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="10" min="0" placeholder="" ID="StudentSem1Att" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                            <%-- Sem 2 %--%>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="font-size: large">Sem 2 %<sup>*</sup></label>
                                                    <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentSem2Perc" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <%--sem 2 attempts--%>

                                            <div class="form-group">

                                                <label style="font-size: large">Attempts<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="10" min="0" placeholder="" ID="StudentSem2Att" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%-- Sem 3 %--%>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="font-size: large">Sem 3 %<sup>*</sup></label>
                                                    <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentSem3Perc" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <%--sem 3 attempts--%>

                                            <div class="form-group">

                                                <label style="font-size: large">Attempts<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="10" min="0" placeholder="" ID="StudentSem3Att" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%-- Sem 4 %--%>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="font-size: large">Sem 4 %<sup>*</sup></label>
                                                    <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentSem4Perc" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <%--sem 4 attempts--%>

                                            <div class="form-group">

                                                <label style="font-size: large">Attempts<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="10" min="0" placeholder="" ID="StudentSem4Att" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>


                                            <%-- Sem 5 %--%>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="font-size: large">Sem 5 %</label>
                                                    <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentSem5Perc" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <%--sem 5 attempts--%>

                                            <div class="form-group">

                                                <label style="font-size: large">Attempts<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="100" min="0" placeholder="" ID="StudentSem5Att" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%-- Sem 6 %--%>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="font-size: large">Sem 6 %<sup>*</sup></label>
                                                    <asp:TextBox class="form-control" type="number" step="0.01" max="100" min="0" placeholder="0-100" ID="StudentSem6Perc" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <%--sem 6 attempts--%>

                                            <div class="form-group">

                                                <label style="font-size: large">Attempts<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="10" min="0" placeholder="" ID="StudentSem6Att" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                            <%-- On-Going KT--%>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="font-size: large">On-Going KT<sup>*</sup></label>
                                                    <asp:TextBox class="form-control" type="number" max="100" min="0" placeholder="" ID="StudentOnGoingKt" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <%--Cleared Kt--%>

                                            <div class="form-group">

                                                <label style="font-size: large">Cleared KT<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="100" min="0" placeholder="" ID="StudentClearedKt" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                            <%--Total Avg--%>
                                            <div class="form-group">
                                                <label style="font-size: large">Overall Aggregate<sup>*</sup></label>
                                                <asp:TextBox class="form-control" type="number" max="100" step="0.01" min="0" placeholder="0-100" ID="StudentOverallAvg" runat="server" Width="60%" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <p>
                                            <label>Fields marked with * are compulsory</label><br />
                                            <asp:Label ID="ErrorLabelAcademic" runat="server" Width="30%" ForeColor="Red"></asp:Label>
                                        </p>
                                    </div>
                            </asp:WizardStep>
                            <asp:WizardStep ID="ReviewAndSub" runat="server" Title="Review And Submit">
                                <div class="form-group">
                                    <label for="disabledSelect" style="font-size: large">Terms And Conditions<sup>*</sup> </label>
                                    <br />
                                    <asp:TextBox class="termsx" TextMode="MultiLine" disabled="" Text="Terms and conditions of Training and placement cell."
                                        Width="70%" ID="TextBox2" runat="server" Rows="18" AutoPostBack="False"></asp:TextBox>
                                </div>
                                <p />
                                <div class="form-group">
                                    <asp:CheckBox ID="StudentTermsAndCond" value="agreed" Text="I Agree To The Mentioned Terms And Conditions." required="" runat="server" TextAlign="Left" />

                                </div>
                                <p>
                                    <label>Fields marked with * are compulsory</label><br />
                                    <asp:Label ID="ErrorLabel" runat="server" Width="30%" ForeColor="Red"></asp:Label>
                                </p>
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                    <footer>
                        <p>
                            All right reserved.       
                                   <!-- /. PAGE INNER  -->
                            <!-- /. PAGE WRAPPER  -->
                        </p>
                    </footer>
                </div>
            </div>


            <!-- /. WRAPPER  -->
            <!-- JS Scripts-->
            <!-- jQuery Js -->
            <script src="assets/jsdash/jquery-1.10.2.js"></script>
            <!-- Bootstrap Js -->
            <script src="assets/jsdash/bootstrap.min.js"></script>
            <!-- Metis Menu Js -->
            <script src="assets/jsdash/jquery.metisMenu.js"></script>
            <!-- Custom Js -->
            <script src="assets/jsdash/custom-scripts.js"></script>
    </form>
</body>
</html>
