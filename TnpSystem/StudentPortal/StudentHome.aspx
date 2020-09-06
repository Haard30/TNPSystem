<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="TnpSystem.WebForm2" %>
<meta http-equiv=“X-UA-Compatible” content=“Edge” />
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
                        <a class="active-menu" href="StudentHome.aspx"><i class="fa fa-dashboard"></i> Notification Desk</a>
                    </li>
                    <li>
                        <a href="PlacementStatus.aspx"><i class="fa fa-desktop"></i> Placement Status</a>
                    </li>
                    
                    <li>
                        <a href="Form.aspx"><i class="fa fa-edit"></i> Form Submision </a>
                    </li>


                    <li>
                        <a href="#"><i class="fa fa-sitemap"></i> Documents Upload<span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li>
                                    <a href="MarksheetUpload.aspx">Marksheets & Resume Upload</a>
                                </li>
                        </ul>
                    </li>

					<li>
					<a href="ViewStats.aspx"><i class="fa fa-bar-chart-o"></i> View Stats</a>
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
                        <h1 class="page-header">
                            Notifications <small>Upcoming companies for which you are eligible</small>
                        </h1>
                    </div>
                </div>
                <div class="alert alert-success">
                <asp:Label ID="StudentNot1" runat="server" ForeColor="Black" BorderColor="#252526" Font-Bold="True" Font-Size="Medium"></asp:Label>
	            </div>
                 <asp:Button ID="StudApply" type="submit" class="btn btn-default" runat="server" align="center" Text="Apply" BackColor="White" ForeColor="Black" Width="25%" OnClick="StudApply_Click"></asp:Button>
                <asp:Button ID="StudPass" type="submit" class="btn btn-default" runat="server" align="center" Text="Pass" BackColor="White" ForeColor="Black" Width="25%" OnClick="StudPass_Click" OnClientClick ="return confirm('Are you sure? Note: Decision once made cannot be changed');"></asp:Button>
               <div>
                <asp:Label ID="StudActionLabel" runat="server" ForeColor="Black" BorderColor="#252526" Font-Bold="True" Font-Size="Medium"></asp:Label>
	            </div>
                
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
