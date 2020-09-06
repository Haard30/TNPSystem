<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendNotifications.aspx.cs" Inherits="TnpSystem.CoordinatorPortal.SendNotifications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>TNP PORTAL</title>
    <!-- table Styles-->
    <link href="assets/cssdash/tableStyle.css" rel="stylesheet" />
    
    <!-- Bootstrap Styles-->
    <link href="assets/cssdash/bootstrap.css" rel="stylesheet" />
    <!-- FontAwesome Styles-->
    <link href="assets/cssdash/font-awesome.css" rel="stylesheet" />
    <!-- Morris Chart Styles-->
    <link href="assets/jsdash/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <!-- Custom Styles-->
    <link href="assets/cssdash/custom-styles.css" rel="stylesheet" />
    <!-- Google Fonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <!-- Next Button -->
    <link href="assets/cssdash/NextButton.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">

        <div id="wrapper">
            <nav class="navbar navbar-default top-navbar" role="navigation">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">

                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="CoordinatorHome.aspx">TNP Portal (Coordinator Login)</a>
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
                            <a href="CoordinatorHome.aspx"><i class="fa fa-dashboard"></i>My Profile</a>
                        </li>
                        <li>
                            <a class="active-menu" href="SendNotifications.aspx"><i class="fa fa-edit"></i>Sort And Send Notifications</a>
                        </li>

                        <li>
                            <a href="AddRemoveReset.aspx"><i class="fa fa-edit"></i>Add/Remove Student </a>
                        </li>

                        <li>
                            <a href="VerifyStudent.aspx"><i class="fa fa-desktop"></i>View student </a>
                        </li>

                        <li>
                            <a href="AddCompany.aspx"><i class="fa fa-desktop"></i>Add Company </a>
                        </li>
                        <li>
                            <a href="GenerateReport.aspx"><i class="fa fa-desktop"></i>Generate Report </a>
                        </li>
                    </ul>

                </div>

            </nav>
            <!-- /. NAV SIDE  -->
            <div id="page-wrapper">
                <div id="page-inner">


                    <div class="row">
                        <div class="col-md-12">
                            <h1 class="page-header">Sort And Send Notifications
                            </h1>
                        </div>
                    </div>
                    <div class="alert alert-success">
                        <asp:Label ID="ClearNotLabel" runat="server" Width="50%" ForeColor="Black" Font-Bold="True" Font-Size="Large">CLEAR NOTIFICATION</asp:Label>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-6">
                        <div class="form-group">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Click to clear previous notification </asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="ClearNot" type="submit" CssClass="myButton" runat="server" align="center" Text="Clear Notificiation" Width="50%" OnClick="ClearNot_Click"></asp:Button>
                   </div>
                        </div>
                            </div>
                    <asp:Label ID="ClearNotSuccess" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>

                    <br />
                    <br />

                    <div class="form-group">
                        <div class="alert alert-success">
                            <asp:Label ID="NewNotLabel" runat="server" Width="50%" ForeColor="Black" Font-Bold="True" Font-Size="Large">SEND NEW NOTIFICATION</asp:Label>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Company Name :<sup>*</sup></asp:Label>
                                <br />
                                <asp:DropDownList ID="CompanyNameList" runat="server" Width="70%" Height="40%" AutoPostBack="True" OnSelectedIndexChanged="CompanyNameList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>


                            <div class="form-group">
                                <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Job Profile And Salary:<sup>*</sup></asp:Label>
                                <asp:TextBox class="form-control" require="" TextMode="MultiLine" placeholder="Job Profile : Salary" ID="NotJobProfile" runat="server" Width="70%" Rows="4" AutoPostBack="False"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Location :</asp:Label>
                                <asp:TextBox class="form-control" ID="NotJobLocation" runat="server" type="text" Width="70%"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <%-- On-Going KT--%>
                            <div class="form-group">
                                <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Number of On-Going KT Allowed: <sup>*</sup></asp:Label><br />
                                <asp:TextBox class="form-control" type="number" require="" max="100" min="0" placeholder="" ID="NotOnGoingKt" runat="server" Width="25%" AutoPostBack="False"></asp:TextBox>
                            </div>


                            <%--Cleared Kt--%>

                            <div class="form-group">

                                <br />
                                <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Number of Cleared KT Allowed:<sup>*</sup></asp:Label><br />
                                <asp:TextBox class="form-control" type="number" max="100" require="" min="0" placeholder="" ID="NotClearedKt" runat="server" Width="25%" AutoPostBack="False"></asp:TextBox>

                                <%--Total Avg--%>
                                <div class="form-group">
                                    <br />
                                    <br />
                                    <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Minimum Overall Aggregate:<sup>*</sup></asp:Label><br />
                                    <asp:TextBox class="form-control" type="number" max="100" step="0.01" min="0" placeholder="0-100" ID="NotOverallAvg" runat="server" Width="25%" AutoPostBack="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                        <%--Additional Notes--%>
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium">Additinal Notes:<sup>*</sup></asp:Label>
                        <asp:TextBox class="form-control" require="" TextMode="MultiLine" placeholder="Company Visiting date, Application deadline" ID="NotAdditional" runat="server" Width="35%" Rows="4" AutoPostBack="False"></asp:TextBox>

                        <p>
                            <asp:Label ID="ErrorLabelSendNot" runat="server" Width="30%" ForeColor="Red"></asp:Label>
                            <asp:Label ID="SendNotActionSuccess" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </p>
                        
                            <asp:Button ID="SendNotSubmit" type="submit" CssClass="myButton" runat="server" align="center" Text="Send Notificiations" Width="25%" OnClick="SendNotSubmit_Click"></asp:Button>

                        </div>


                        <p>&nbsp;</p>
                        <asp:Label ID="SendNotActionFail" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>

                    <footer>
                        <label>Fields marked with * are compulsory</label><br />
                        <p>All right reserved.</p>
                    </footer>
                </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
        </div>
        <!-- /. WRAPPER  -->
        <!-- JS Scripts-->
        <!-- jQuery Js -->
        <script src="assets/jsdash/jquery-1.10.2.js"></script>
        <!-- Bootstrap Js -->
        <script src="assets/jsdash/bootstrap.min.js"></script>
        <!-- Metis Menu Js -->
        <script src="assets/jsdash/jquery.metisMenu.js"></script>
        <!-- Morris Chart Js -->
        <script src="assets/jsdash/morris/raphael-2.1.0.min.js"></script>
        <script src="assets/jsdash/morris/morris.js"></script>
        <!-- Custom Js -->
        <script src="assets/jsdash/custom-scripts.js"></script>
    </form>
</body>
</html>
