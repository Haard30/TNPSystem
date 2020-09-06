<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarksheetUpload.aspx.cs" Inherits="TnpSystem.StudentPortal.MarksheetUpload" %>

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

    <style type="text/css">
        .auto-style1 {
            width: 199px;
        }
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 199px;
            height: 70px;
        }
        .auto-style4 {
            height: 70px;
        }
        .auto-style5 {
            width: 200px;
            height: 70px;
        }
    </style>

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
                        <a href="StudentHome.aspx"><i class="fa fa-dashboard"></i> Notification Desk</a>
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
                            Documents Upload <small>Marksheets and Resume</small>
                        </h1>
                       <!-- <div class="form-control"> -->
                        <table class="blueTable">
                            <tr>
                                <th class="auto-style1">Document Name</th>
                               
                                <th>Upload</th>
                                
                                <th class="auto-style2">Document Name</th>
                               
                                <th>Upload</th>
                            </tr>
                            <tr>
                                <td class="auto-style3">10th Marksheet</td>
                                <td class="auto-style4">
                                    <asp:FileUpload ID="XMarksheet" required="" height="70%" style="padding-left:15px;padding-top:15px" align="center" runat="server" /></td>
                                    <td class="auto-style5">Sem3 Marksheet</td>
                                <td class="auto-style4">
                                    <asp:FileUpload ID="Sem3Marksheet"  required=""  height="70%" style="padding-left:15px;padding-top:15px" runat="server" /></td>
                            
                            </tr>
                            <tr>
                                <td class="auto-style3">12th Marksheet</td>
                                <td>
                                    <asp:FileUpload ID="XiiMarksheet" height="70%" style="padding-left:15px;padding-top:15px" runat="server" /></td>
                                
                                <td class="auto-style4">Sem4 Marksheet</td>
                                <td>
                                    <asp:FileUpload ID="Sem4Marksheet" height="70%" style="padding-left:15px;padding-top:15px" required="" runat="server" /></td>
                            
                            </tr>
                            <tr>
                                <td class="auto-style3">Diploma Marksheet</td>
                                <td>
                                    <asp:FileUpload ID="diplomamarksheet" height="70%" style="padding-left:15px;padding-top:15px" runat="server" /></td>
                                
                                <td class="auto-style4">Sem5 Marksheet</td>
                                <td>
                                    <asp:FileUpload ID="Sem5Marksheet"  height="70%" style="padding-left:15px;padding-top:15px" required="" runat="server" /></td>
                           
                            </tr>
                            <tr>
                                <td class="auto-style3">Sem1 Marksheet</td>
                                <td>
                                    <asp:FileUpload ID="Sem1Marksheet" height="70%" style="padding-left:15px;padding-top:15px"  required="" runat="server" /></td>
                                
                                <td class="auto-style4">Sem6 Marksheet</td>
                                <td>
                                    <asp:FileUpload ID="Sem6Marksheet" height="70%" style="padding-left:15px;padding-top:15px" required="" runat="server" /></td>
                            
                            </tr>
                            <tr>
                                <td class="auto-style3">Sem2 Marksheet</td>
                                <td>
                                    <asp:FileUpload ID="Sem2Marksheet" height="70%" style="padding-left:15px;padding-top:15px" required="" runat="server" /></td>
                                
                                <td class="auto-style4">Resume</td>
                                <td>
                                    <asp:FileUpload ID="ResumeUpload" height="70%" style="padding-left:15px;padding-top:15px" required="" runat="server" /></td>
                        
                            </tr>
                            <tr >
                                <td colspan="4">
                                    <br />
                            <asp:Button ID="UploadAllSubmit" CssClass="myButton" type="submit" runat="server" style="margin-left:260px" Text="Upload All" Width="25%" OnClick="UploadAllSubmit_Click"></asp:Button>
                        <br \ /><br \ />
                        <asp:Label ID="ErrorLabel" runat="server" Width="30%" ForeColor="#CC3300" Font-Bold="True" Font-Size="Medium"></asp:Label>

                        <asp:Label ID="SuccessLabel" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>

                                </td>
                            </tr>
                        </table>
                       <!-- </div> -->
                        <div></div>
                    </div>
                    
                </div>
        
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

    </form></body>
</html>
