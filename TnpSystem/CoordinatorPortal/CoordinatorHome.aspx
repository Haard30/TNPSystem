<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoordinatorHome.aspx.cs" Inherits="TnpSystem.CoordinatorPortal.CoordinatorHome" %>

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
                            <a class="active-menu" href="CoordinatorHome.aspx"><i class="fa fa-dashboard"></i>My Profile</a>
                        </li>
                        <li>
                            <a href="SendNotifications.aspx"><i class="fa fa-edit"></i>Sort And Send Notifications</a>
                        </li>

                        <li>
                            <a href="AddRemoveReset.aspx"><i class="fa fa-edit"></i>Add/Remove Student </a>
                        </li>

                        <li>
                            <a href="VerifyStudent.aspx"><i class="fa fa-desktop"></i>View student</a>
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
                            <h1 class="page-header">My Profile
                            </h1>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="disabledSelect">My Id :</label>
                        <asp:TextBox class="form-control" ID="CoordiProfileId" runat="server" type="text" placeholder="Auto-generated" disabled="" Width="30%" OnTextChanged="AdminProfileId_TextChanged"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox class="form-control" placeholder="Enter Name" ID="CoordiProfileName" runat="server" Width="30%" OnTextChanged="AdminProfileName_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>E-mail-ID</label>
                        <asp:TextBox class="form-control" placeholder="Enter E-mail" ID="CoordiProfileEmail" runat="server" Width="30%" OnTextChanged="AdminProfileEmail_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Please enter a valid email" ControlToValidate="CoordiProfileEmail"
                            Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="True"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                    </div>




                    <footer>
                        <p>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="AdminProfileUpdate" CssClass="myButton" type="submit" runat="server" align="center" Text="Update Profile" Width="25%" OnClick="AdminProfileUpdate_Click"></asp:Button>
                        </p>
                        <p>&nbsp;</p>
                        <asp:Label ID="UpdateCoordiActionFail" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>

                        <asp:Label ID="UpdateCoordiActionSuccess" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>

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
