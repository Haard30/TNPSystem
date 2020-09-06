<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlacementStatus.aspx.cs" Inherits="TnpSystem.WebForm3" %>

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
                            <a class="active-menu" href="PlacementStatus.aspx"><i class="fa fa-desktop"></i>Placement Status</a>
                        </li>

                        <li>
                            <a href="Form.aspx"><i class="fa fa-edit"></i>Form Submision </a>
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
                            <a href="CompanyProfile.aspx"><i class="fa fa-desktop"></i>Company Profile</a>
                        </li>
                    </ul>

                </div>

            </nav>

            <!-- /. NAV SIDE  -->
            <div id="page-wrapper">
                <div id="page-inner">
                    <div class="row">
                        <div class="col-md-12">
                            <h1 class="page-header">Placement Status 
                            </h1>
                        </div>
                    </div>
                    <!-- /. ROW  -->


                    <div class="row">

                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Your current placement status: 
                                </div>

                                <div class="panel-body">
                                    <div class="alert alert-success">
                                        <asp:Label runat="server" ID="PlacementStatusLabel" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                   
                                    </div>
                                    
                            <asp:Button ID="AddAnother" type="submit" class="btn-default" runat="server" align="center" Text="Add Another" BackColor="White" ForeColor="Black" Width="25%" OnClick="AddAnother_Click"></asp:Button>
                                       
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="PlacementCompNameLabel" Font-Bold="True" Font-Size="Medium">Company Name : <sup>*</sup></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="CompanyNameList" runat="server" Width="40%" Height="40%" AutoPostBack="True" OnSelectedIndexChanged="CompanyNameList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group"><br />
                                        <asp:Label runat="server" ID="OnOffCampusLabel" Font-Bold="True" Font-Size="Medium">Select whether On/Off campus : <sup>*</sup></asp:Label>
                                        <asp:Label ID="ErrorLabelOnCampus" Font-Bold="True" runat="server" Width="60%" ForeColor="Red"></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="OnOffCampusList" runat="server" Width="40%" Height="40%" OnSelectedIndexChanged="OnOffCampusList_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                <asp:ListItem Value="2">On Campus</asp:ListItem>
                                                <asp:ListItem Value="3">Off Campus</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    
                                            <%--LPA--%>
                                            <div class="form-group">
                                        <br />      <asp:label ID="PlacementPackageLabel" Font-Bold="True" runat="server" style="font-size: large">Package : <sup>*</sup></asp:label>
                                                <asp:TextBox class="form-control" type="number" step="0.01" max="100" required="" min="0" placeholder="LPA" ID="PlacementPackage" runat="server" Width="20%" AutoPostBack="False"></asp:TextBox>
                                            </div>

                                    <div class="form-group"><br />
                                        <asp:Label runat="server" ID="BatchYearLabel" Font-Bold="True" Font-Size="Medium">Select Batch Year : <sup>*</sup></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="BatchYearListList" runat="server" Width="40%" Height="40%" OnSelectedIndexChanged="BatchYearListList_SelectedIndexChanged">
                                        <asp:ListItem Value="1">--Select--</asp:ListItem>
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

                                    <div class="form-group"><br /><br />
                            <asp:Button ID="UpdatePlacementSubmit" type="submit" CssClass="myButton" runat="server" align="center" Text="Update Placement Status" Width="25%" OnClick="UpdatePlacementSubmit_Click"></asp:Button>
                                        </div>
                                    
                        <asp:Label ID="ErrorLabel" runat="server" Width="30%" ForeColor="Red"></asp:Label>
                        <asp:Label ID="SuccessLabel" runat="server" Width="30%" ForeColor="Green"></asp:Label>
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
