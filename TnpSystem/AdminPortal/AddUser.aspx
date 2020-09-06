<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="TnpSystem.AdminPortal.AddUser" %>

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


</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <nav class="navbar navbar-default top-navbar" role="navigation">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="AdminHome.aspx">TNP Portal (Admin Login)</a>
            </div>

            <ul class="nav navbar-top-links navbar-right">
			 <!-- /.dropdown -->
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">
                        <i class="fa fa-user fa-fw"></i> <i class="fa fa-caret-down"></i>
                    </a>
                    <ul class="dropdown-menu dropdown-user">
                        <li><a href="../ForgotPassword.aspx"><i class="fa fa-sign-out fa-fw"></i>Change Password</a>
                        </li>
                        <li><a href="../Login.aspx"><i class="fa fa-sign-out fa-fw"></i> Logout</a>
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
                        <a  href="AdminHome.aspx"><i class="fa fa-dashboard"></i> My Profile</a>
                    </li>
                    <li>
                        <a class="active-menu" href="AddUser.aspx"><i class="fa fa-edit"></i> Add User</a>
                    </li>
                    
                    <li>
                        <a href="RemoveUser.aspx"><i class="fa fa-edit"></i> Remove User </a>
                    </li>
                    
                    <li>
                        <a href="ViewUserAdmin.aspx"><i class="fa fa-desktop"></i> Generate Reports </a>
                    </li>
                </ul>

            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div id="page-inner">


                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-header">
                            Add User <small>Add a Student or a Co-ordinator</small>
                        </h1>
                    </div>
                </div>
                <div class="form-group">
                    <label>User PRN/ID</label>
          <asp:TextBox class="form-control" placeholder="Enter PRN/ID" ID="AddUserId" runat="server" required="" OnTextChanged="AddUserId_TextChanged" AutoPostBack="True" Width="30%"></asp:TextBox>
                    </div>
                <div class="form-group">
                         <label for="disabledSelect">Password</label>
                        <asp:TextBox class="form-control" id="AddUserPassword" runat="server" type="text" placeholder="Auto-generated" disabled="" OnTextChanged="AddUserPassword_TextChanged" Width="30%"></asp:TextBox>
                 </div>
                
                <div class="form-group">
                    <label>E-mail-ID</label>
                    <asp:TextBox class="form-control" placeholder="Enter E-mail" ID="AddUserEmail" runat="server" Width="30%"></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
         ErrorMessage="Please enter a valid email" ControlToValidate="AddUserEmail"
         Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="True"
         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                         </asp:RegularExpressionValidator>
                </div>
                
                <div class="form-group">
                    </div>
                
                                        <div class="form-group">
                                            <label>Type</label>
                                            <br />

                                            <asp:DropDownList ID="AddUserType" runat="server" Width="30%" Height="90%" require="" AutoPostBack="True" OnSelectedIndexChanged="AddUserType_SelectedIndexChanged">
                                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                <asp:ListItem Value="student">Student</asp:ListItem>
                                                <asp:ListItem Value="coordinator">Co-ordinator</asp:ListItem>
                                                <asp:ListItem Value="admin">Admin</asp:ListItem>

                                            </asp:DropDownList>
                                            
                                        </div>
                                    
                                <div class="form-group">
                                    <label style="font-size: large">Department <sup>*</sup></label>
                                    <br />

                                    <asp:DropDownList ID="AddUserDepartment" runat="server" Width="30%" Height="310%" require="" AutoPostBack="False">
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
				<footer><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="AddUserSubmit" type="submit" CssClass="myButton" runat="server" align="center" Text="Add User" Width="25%" OnClick="AddUserSubmit_Click" ></asp:Button>
                    </p>
                    <p>
                        <asp:Label ID="USerExistLabel" runat="server" Width="30%" ForeColor="Red"></asp:Label>
                        <asp:Label ID="UserAddedLabel" runat="server" Width="30%" ForeColor="Green"></asp:Label>
                    </p>


                    <p>All right reserved.</p></footer>
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
