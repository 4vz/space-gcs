<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Telkomsat.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="./assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="./assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="./assets/plugins/iCheck/square/red.css" rel="stylesheet" />
    <link href="./assets/css/style.min.css" rel="stylesheet" />
    <link href="Style2.css" rel="stylesheet" />
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
</head>
<body class="hold-transition login-page">
    <div class ="login-box">
        <div align="center">
            <img src="img/logotelkomsat.png" style="width:360px; height:auto"/>
        </div>
        <div class="login-box-body">
            <h5 class="login-box-msg">Masukkan Username dan Password</h5>
            <form id="form1" runat="server">
                <div class="form-group has-feedback">
                <asp:Label ID="lblGagal" class="form-control-error" runat="server" Text="   Username atau Password tidak sesuai." BackColor="#FEE2E1" Font-Size="Small" ForeColor="#993333" Visible="False" BorderStyle="None" BorderColor="#F5D2D0" Height="32px" Width="300px" ></asp:Label>
                </div>
                <div class="form-group has-feedback">
                <input class="form-control" placeholder="Username" id="inEmail" runat="server"/>
                <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
              <div class="form-group has-feedback">
                <input type="password" class="form-control" placeholder="Password" id="inPass" runat="server"/>
                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
              </div>
              <div class="row">

                <!-- /.col -->
                <div class="col-lg-12">
                    <asp:Button ID="btnLogin1" runat="server" Text="Login" OnCLick="btnLogin_Click" class="btn btn-danger btn-block btn-flat"/>
                  <!--<button type="submit" class="btn btn-danger btn-block btn-flat" id="btnLogin" onclick="btnLogin_Click" runat="server">Sign In</button>-->
                </div>
                <!-- /.col -->
              </div>     
            </form>
        </div>
    </div>
    <script src="./assets/plugins/iCheck/icheck.min.js"></script>
    <script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-red',
      radioClass: 'iradio_square-red',
      increaseArea: '20%' /* optional */
    });
  });
</script>
</body>
</html>

