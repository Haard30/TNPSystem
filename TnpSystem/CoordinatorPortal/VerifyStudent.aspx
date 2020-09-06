<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyStudent.aspx.cs" Inherits="TnpSystem.CoordinatorPortal.VerfyStudent" %>

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
                            <a class="active-menu" href="VerifyStudent.aspx"><i class="fa fa-desktop"></i>View student </a>
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
                            <h1 class="page-header">Verify Students <small>| View/Verify students of your department</small>
                            </h1>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:label runat="server" ID="PRNLabel" Font-Bold="True" Font-Size="Medium">Enter PRN</asp:label><br />
                        <asp:TextBox class="form-control" placeholder="Enter PRN/ID" ID="UserId" runat="server" required="" AutoPostBack="True" Width="30%" Height="30px"></asp:TextBox>
                    </div>
                    <br />
                    <asp:Button ID="ViewUserSubmit" type="submit" CssClass="myButton" runat="server" align="center" Text="View User" Width="25%" OnClick="ViewUserSubmit_Click"></asp:Button>
                            <p>&nbsp;</p>
                    <br />

                    <div class="form-group">
                        <asp:GridView ID="GridView1" DataKeyNames="DocName" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="631px" AutoGenerateColumns="False" Height="215px">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            <Columns>  
                <asp:BoundField  DataField="DocName" HeaderText="Document Name "/>
                          <asp:TemplateField HeaderText="View">  
                                <ItemTemplate>  
                                <asp:LinkButton ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />  
                                </ItemTemplate> 
                         </asp:TemplateField>
                                </Columns>
                        </asp:GridView>
                        </div>

                        <asp:Label ID="ErrorLabel" runat="server" Width="30%" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                    <asp:Button ID="DownloadResumeSubmit" type="submit" class="btn btn-default" runat="server" align="center" Text="Download Resume" BackColor="White" ForeColor="Black" Width="25%" OnClick="DownloadResumeSubmit_Click"></asp:Button>
                   <asp:Button ID="ViewStudentReport" type="submit" class="btn btn-default" runat="server" align="center" Text="View Student Report" BackColor="White" ForeColor="Black" Width="25%" OnClick="ViewStudentReport_Click" OnClientClick="target='_blank';"></asp:Button>
                   
                    
                    <p>&nbsp;</p>
                        <asp:Label ID="SuccessLabel" runat="server" Width="30%" ForeColor="#009933" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    
                     

                    <footer>
                        <p>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                            </p>
                        <p>&nbsp;</p>

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
