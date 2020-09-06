<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRemoveReset.aspx.cs" Inherits="TnpSystem.CoordinatorPortal.AddRemoveReset" %>

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
                            <a href="SendNotifications.aspx"><i class="fa fa-edit"></i>Sort And Send Notifications</a>
                        </li>

                        <li>
                            <a class="active-menu" href="AddRemoveReset.aspx"><i class="fa fa-edit"></i>Add/Remove Student </a>
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
                            <h1 class="page-header">Add/Remove <small>| For students of your department</small>
                            </h1>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Select Action</label><br />
                        <asp:DropDownList ID="ActionType" runat="server" Width="30%" Height="90%" require="" AutoPostBack="True" OnSelectedIndexChanged="ActionType_SelectedIndexChanged">
                                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                <asp:ListItem Value="2">Add User</asp:ListItem>
                                                <asp:ListItem Value="3">Remove User</asp:ListItem>
                                                

                          </asp:DropDownList>
                                            
                        </div>
                    <div class="form-group">
                        <asp:label runat="server" ID="PRNLabel" Font-Bold="True" Font-Size="Medium">User PRN/ID</asp:label>
                        <asp:TextBox class="form-control" placeholder="Enter PRN/ID" ID="UserId" runat="server" required="" AutoPostBack="True" Width="30%"></asp:TextBox>
                    </div>
                    
                <div class="form-group">
                    <asp:label runat="server" ID="EmailLabel" Font-Bold="True" Font-Size="Medium">E-mail-ID</asp:label>
                    <asp:TextBox class="form-control" placeholder="Enter E-mail" ID="AddUserEmail" runat="server" Width="30%" required=""></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
         ErrorMessage="Please enter a valid email" ControlToValidate="AddUserEmail"
         Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="True"
         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                         </asp:RegularExpressionValidator>
                </div><br />
                    <asp:Button ID="AddUserSubmit" type="submit" CssClass="myButton" runat="server" align="center" Text="Add User"  Width="25%" OnClick="AddUserSubmit_Click"></asp:Button>
                    <br />
                    
                    <footer>
                        <p>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="RemoveUserSubmit" type="submit" CssClass="myButton" runat="server" align="center" Text="Remove User" Width="25%" OnClick="RemoveUserSubmit_Click"></asp:Button>
                            <p>&nbsp;</p>
                            <asp:Label ID="ErrorLabel" runat="server" Width="30%" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </p>
                        <p>&nbsp;</p>
                        <asp:Label ID="SuccessLabel" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>


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
