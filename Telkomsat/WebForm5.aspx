<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="Telkomsat.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="./assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="./assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="./assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="./assets/css/style.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css?version2" rel="stylesheet" />
    <link href="stylepagination.css?version=2" rel="stylesheet" />
    <link href="dashboard.css?version=12" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"/>
    <link rel="stylesheet" href="./assets/mylibrary/jquery-ui.css" />
    <link rel="stylesheet" href="assets/mylibrary/bootstrap.min.css" />
    <style>
        li {
          float: left;
          padding:10px;
        }
    </style>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
                <table style="border: 1px solid black">
                    <tr>
                        <td colspan="2">
                            <b>Login</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            User Name
                        </td>    
                        <td>
                            :<asp:TextBox ID="txtUserName" runat="server">
                            </asp:TextBox>
                        </td>    
                    </tr>
                    <tr>
                        <td>
                            Password
                        </td>    
                        <td>
                            :<asp:TextBox ID="txtPassword" TextMode="Password" runat="server">
                            </asp:TextBox>
                        </td>    
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkBoxRememberMe" runat="server" />remember me
                        </td>    
                        <td>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" />
                        </td>    
                    </tr>
                </table>
                <br />
                <a href="Registration/Register.aspx">Click here to register</a> 
                if you do not have a user name and password.
                </div>
        <br />
        <ul id="mycarousel" class="jcarousel-skin-tango">
            <asp:Repeater ID="rptImages" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <li>a</li>
                    <li>a</li>
                    <li>a</li>
                    <li>a</li>
                    <li>a</li>
                    <li>a</li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

        <asp:GridView ID="DataList3a" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
                BorderColor="White" BorderStyle="None" BorderWidth="0px" Visible="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <span class="fa fa-check" style="width:20px"></span>
                            <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("namafiles") %>' CommandName="Download" Text='<%# Eval("namafiles") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            </asp:GridView>
        
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

        <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <script src="../assets/bower_components/PACE/pace.min.js"></script>
        <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
        <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
        <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
        <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
        <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
        <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
        <script src="../assets/bower_components/chart.js/Chart.js"></script>
        <script type="text/javascript" src="../assets/mylibrary/js.js"></script>
    </form>
</body>
</html>
