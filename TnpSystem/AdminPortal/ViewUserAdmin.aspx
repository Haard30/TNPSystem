<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserAdmin.aspx.cs" Inherits="TnpSystem.AdminPortal.ViewUserAdmin" %>

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
                        <a  href="AddUser.aspx"><i class="fa fa-edit"></i> Add User</a>
                    </li>
                    
                    <li>
                        <a href="RemoveUser.aspx"><i class="fa fa-edit"></i> Remove User </a>
                    </li>
                    
                    <li>
                        <a class="active-menu" href="ViewUserAdmin.aspx"><i class="fa fa-desktop"></i> Generate Reports </a>
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
                            Reports <small>Co-ordinators/Placements</small>
                        </h1>
                    </div>
                   
                </div>
                 <div class="form-group">
                        <label>Select Action</label><br />
                        <asp:DropDownList ID="ActionType" runat="server" Width="30%" Height="90%" require="" AutoPostBack="True" OnSelectedIndexChanged="ActionType_SelectedIndexChanged">
                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                            <asp:ListItem Value="2">Co-Ordinator Department Wise</asp:ListItem>
                            <asp:ListItem Value="3">Placement Reports Year Wise</asp:ListItem>
                            <asp:ListItem Value="4">Placement Reports Department Wise</asp:ListItem>


                        </asp:DropDownList>
                     <br />
                     <br />

                        <asp:label Id="SelectYearLabel" runat="server">Select Year</asp:label><br />
                        <asp:DropDownList ID="PlacementYearsList" runat="server" Width="30%" Height="90%" require="" AutoPostBack="True" OnSelectedIndexChanged="PlacementYearsList_SelectedIndexChanged">
                            
                        </asp:DropDownList>
                     <br />
                        <asp:label Id="SelectDeptLabel" runat="server">Select Department</asp:label><br />
                        <asp:DropDownList ID="SelectDeptList" runat="server" Width="30%" Height="90%" require="" AutoPostBack="True" OnSelectedIndexChanged="SelectDeptList_SelectedIndexChanged">
                            
                        </asp:DropDownList>

                    </div>
                    


                    <asp:Button ID="CoordiReportSubmit" type="submit" cSScLASS="myButton" runat="server" align="center" Text="Generate Report" Width="25%" OnClick="CoordiReportSubmit_Click1" OnClientClick="target='_blank';"></asp:Button>
                    <br />
                <br />
                    <asp:Button ID="YearWiseSubmit" type="submit" CssClass="myButton" runat="server" align="center" Text="Generate Report" Width="25%" OnClick="YearWiseSubmit_Click" OnClientClick="target='_blank';"></asp:Button>
                    
                <asp:Label ID="ErrorLabel" runat="server" Width="30%" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        <p>&nbsp;</p>
                        <asp:Label ID="SuccessLabel" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>

		
				<footer><p>All right reserved.</p></footer>
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
