<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormNotSubmitted.aspx.cs" Inherits="TnpSystem.StudentPortal.FormNotSubmitted" %>

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
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' /></head>
<body><form id="form1" runat="server">
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
                        <a href="StudentHome.aspx"><i class="fa fa-dashboard"></i> Notification Desk</a>
                    </li>
                    <li>
                        <a href="PlacementStatus.aspx"><i class="fa fa-desktop"></i> Placement Status</a>
                    </li>
                    
                    <li>
                        <a class="active-menu" href="FormSubmitted.aspx"><i class="fa fa-edit"></i> Form Submision </a>
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
        <div id="page-wrapper" >
            <div id="page-inner">
			 <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-header">
                            Form Submission
                        </h1>
                    </div>
                </div> 
                 <!-- /. ROW  -->
				 
				
			<div class="row">

			  <div class="col-md-12">
			<div class="panel panel-default">
				<div class="panel-heading">
				 Your form submission status: 
				</div>        
							  
							<div class="panel-body"> 
								<div class="alert-danger">
									<strong>Required!</strong> You have not submitted the form to be eligible for placement drive.
								</div>
							</div>
				</div>
			</div>						
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
