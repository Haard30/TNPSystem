<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="TnpSystem.CoordinatorPortal.GenerateReport" %>

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
                            <a   href="SendNotifications.aspx"><i class="fa fa-edit"></i>Sort And Send Notifications</a>
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
                            <a class="active-menu" href="GenerateReport.aspx"><i class="fa fa-desktop"></i>Generate Report </a>
                        </li>
                    </ul>

                </div>

            </nav>
            <!-- /. NAV SIDE  -->
            <div id="page-wrapper">
                <div id="page-inner">


                    <div class="row">
                        <div class="col-md-12">
                            <h1 class="page-header">Generate Report <small>| Report Generation</small>
                            </h1>
                        </div>
                    </div>
                    
                 <div class="form-group">
                        <label>Select Action</label><br />
                        <asp:DropDownList ID="ActionType" runat="server" Width="30%" Height="90%" require="" AutoPostBack="True" OnSelectedIndexChanged="ActionType_SelectedIndexChanged">
                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                            <asp:ListItem Value="2">Application for company</asp:ListItem>
                            <asp:ListItem Value="3">Department Placement Report Year Wise</asp:ListItem>
                            <asp:ListItem Value="4">Placement Report Company Wise</asp:ListItem>


                        </asp:DropDownList>
                     <br />
                     <br />
                     </div>

                    <div class="form-group">
                                        <asp:Label runat="server" ID="PlacementCompNameLabel" Font-Bold="True" Font-Size="Medium">Company Name : <sup>*</sup></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="CompanyNameList" runat="server" Width="40%" Height="40%" AutoPostBack="True" OnSelectedIndexChanged="CompanyNameList_SelectedIndexChanged">
                                        </asp:DropDownList>
                        <br />
                        <asp:Label runat="server" ID="BatchYearLabel" Font-Bold="True" Font-Size="Medium">Select Batch Year : <sup>*</sup></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="BatchYearListList" runat="server" Width="40%" Height="40%" AutoPostBack="True" OnSelectedIndexChanged="BatchYearListList_SelectedIndexChanged">
                                        <asp:ListItem Value="1">--Select--</asp:ListItem>
                                            <asp:ListItem Value="all">All</asp:ListItem>
                                                <asp:ListItem Value="2012">2012</asp:ListItem>
                                            <asp:ListItem Value="2013">2013</asp:ListItem>
                                            <asp:ListItem Value="2014">2014</asp:ListItem>
                                            <asp:ListItem Value="2015">2015</asp:ListItem>
                                            <asp:ListItem Value="2016">2016</asp:ListItem>
                                            <asp:ListItem Value="2017">2017</asp:ListItem>
                                            <asp:ListItem Value="2018">2018</asp:ListItem>
                                            <asp:ListItem Value="2019">2019</asp:ListItem>
                                            <asp:ListItem Value="2020">2020</asp:ListItem>
                                        </asp:DropDownList>
                     </div>

                     
                                    <div class="form-group"><br />
                                        
                                    </div>

                    <br /><br />

                    <asp:Button ID="GenerateReportCommon" type="submit" CssClass="myButton" runat="server" align="center" Text="Generate Report"  Width="25%"  OnClientClick="target='_blank';" OnClick="GenerateReportCommon_Click"></asp:Button>
                    

                    <footer>
                        <p>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                            </p>
                        <p>&nbsp;</p>
        <asp:Label ID="ErrorLabel" runat="server" Width="30%" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
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
