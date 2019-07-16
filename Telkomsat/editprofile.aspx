<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editprofile.aspx.cs" Inherits="Telkomsat.editprofile" %>

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
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css" rel="stylesheet" />
    <link href="stylepagination.css" rel="stylesheet" />
    <link href="profile.css" rel="stylesheet" type="text/css"/>
    <link href="profile2.css" rel="stylesheet" />
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>
        $(function () {
            $("#txtttl").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                onClose: function (selectedDate) {
                    $("#txtttl").datepicker("option", "setDate", selectedDate);
                }
            });

            $("#txttanggal").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                onClose: function (selectedDate) {
                    $("#txttanggal").datepicker("option", "setDate", selectedDate);
                }

            });
        })
    </script>
    <script type="text/javascript">
        function runScript(e) {
            if (e.keyCode == 13) {
                document.getElementById('<%=btnUpdate.ClientID%>').focus();
                document.getElementById('<%=btnUpdate.ClientID%>').click(); //javascript
        }
    </script>
</head>
<body class="hold-transition skin-blue layout-top-nav">
<div class="wrapper">
    <form id="form1" runat="server">
  <header class="main-header">
    <nav class="navbar navbar-static-top">
        
      <div class="container">
        <div class="navbar-header">
          <a href="../dashboard.aspx" class="navbar-brand"> <b>Telkomsat</b></a>
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse">
            <i class="fa fa-bars"></i>
          </button>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse pull-left" id="navbar-collapse">
          <ul class="nav navbar-nav">
            <li><a href="../asset/home.aspx">Data Asset</a></li>
              <li><a href="../logbook1/semuadata.aspx">Logbook</a></li>
              <li><a href="../knowledge/semua.aspx">Knowledge</a></li>
          </ul>
          
        </div>
        <!-- /.navbar-collapse -->
        <!-- Navbar Right Menu -->
        <div class="navbar-custom-menu">
        
        <ul class="nav navbar-nav">
            
          <!-- Messages: style can be found in dropdown.less-->
          <!-- User Account: style can be found in dropdown.less -->
          <li class="dropdown user user-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <asp:Label ID="lblProfile1" runat="server" Text="Label"></asp:Label>
            </a>
            <ul class="dropdown-menu">
              <!-- User image -->
              <li class="user-header">
                <img src="img/user.jpg" class="img-circle" alt="User Image"/>

                <p><a href="../profile.aspx">
                  Edit Profile
                  <small>2019</small>
                    </a>
                </p>
              </li>
              <!-- Menu Body -->
              
              <!-- Menu Footer-->
              <li class="user-footer">
                <div class="pull-right">
                    <asp:Button ID="btn" runat="server" Text="Sign Out" OnClick="btnSignOut" CssClass="btn btn-default"/>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
          <li>
            <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
          </li>
        </ul>
      </div>
    </div>
      <!-- /.container-fluid -->
    </nav>
  </header>
  <!-- Full Width Column -->
  <div class="content-wrapper">
    <div class="container">
      <!-- Content Header (Page header) -->
      <div>
  <div class="register-logo">
    <a href="../../index2.html"><b>Edit</b> Profile</a>
  </div>
    <div>
        <hr width="100%" />
    </div>

  <div class="register-box">
    <p class="login-box-msg">Edit Nama dan Kontak Person</p>
      <div>
        <asp:Label ID="lblUpdate" runat="server" Visible="false"></asp:Label>
      </div>
      <div class="form-group has-feedback">
        <input type="text" class="form-control" placeholder="Nama Lengkap" id="txtnama" runat="server" onkeypress="return runScript(event)"/>
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="email" class="form-control" placeholder="Email" id="txtemail" runat="server" onkeypress="return runScript(event)"/>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="text" class="form-control" placeholder="Nomor HP" id="txtnomor" runat="server" onkeypress="return runScript(event)"/>
        <span class="glyphicon glyphicon-phone form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="text" class="form-control" placeholder="Tempat Lahir" id="txttempat" runat="server" onkeypress="return runScript(event)"/>
        <span class="glyphicon glyphicon-globe form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="text" class="form-control" placeholder="Tanggal Lahir" id="txtttl" runat="server" onkeypress="return runScript(event)"/>
        <span class="glyphicon glyphicon-calendar form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="text" class="form-control" placeholder="Tanggal Masuk" id="txttanggal" runat="server" onkeypress="return runScript(event)"/>
        <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <!-- /.col -->
        <div>
        <asp:Button ID="btnUpdate" OnClick="btnUpdate_click" runat="server" Text="Update" class="btn btn-primary" onkeypress="return runScript(event)" />
        </div>
        <!-- /.col -->
      </div>
  </div>
  <!-- /.form-box -->
</div>
      <!-- /.content -->
    </div>
    <!-- /.container -->
  </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="container">
      <div class="pull-right hidden-xs">
        <b>Version</b> 2.0
      </div>
      <strong>Copyright &copy; 2019 <a href="https://www.telkomsat.co.id">Telkomsat</a>.</strong> All rights
      reserved.
    </div>
    <!-- /.container -->
  </footer>
</form>
</div>
<!-- ./wrapper -->

    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
</body>
</html>
