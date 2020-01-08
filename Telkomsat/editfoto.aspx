<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editfoto.aspx.cs" Inherits="Telkomsat.editfoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
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
</head>
<body class="hold-transition skin-blue layout-top-nav">
    <script src="js/jquery.min.js"></script>  
    <script src="js/jquery.Jcrop.min.js"></script>  
    <script type="text/javascript">  
        $(document).ready(function() {  
            $('#<%=cropimage1.ClientID%>').Jcrop({  
                onSelect: SelectCropArea  
            });  
        });  
  
        function SelectCropArea(c) {  
            $('#<%=coordinate_x.ClientID%>').val(parseInt(c.x));  
            $('#<%=coordinate_y.ClientID%>').val(parseInt(c.y));  
            $('#<%=coordinate_w.ClientID%>').val(parseInt(c.w));  
            $('#<%=coordinate_h.ClientID%>').val(parseInt(c.h));  
        }  
        </script>
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
             <li><a href="../dataasset/alldata.aspx">Data Asset</a></li>
              <li><a href="../logbook1/semuadata.aspx">Logbook</a></li>
              <li><a href="../knowledge/semua.aspx">Knowledge</a></li>
              <li><a href="../checklistme/harian.aspx">Checklist</a></li>
              <li><a href="../ticket/ticket.aspx">Ticket</a></li>
          </ul>
          
        </div>
        <!-- /.navbar-collapse -->
        <!-- Navbar Right Menu -->
        <div class="navbar-custom-menu">
        
        <ul class="nav navbar-nav">
            
          <!-- Messages: style can be found in dropdown.less-->
          <!-- User Account: style can be found in dropdown.less -->
          <li class="dropdown user user-menu">
            <a href="../profile.aspx" class="dropdown-toggle" data-toggle="dropdown">
              <asp:Label ID="lblProfile1" runat="server" Text="Label"></asp:Label>
            </a>
            <ul class="dropdown-menu">
              <!-- User image -->
              <li class="user-header">
                <asp:DataList runat="server" id="dtContact" Width="100%"> 
                    <ItemTemplate>
                            <div class="widget-user-image">
                                <asp:Image ID="Image5" alt="User Avatar" runat="server" class="img-circle" Width="55px" Height="55px" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : Eval("foto") %>'/>
                            </div>
                    </ItemTemplate>

                </asp:DataList>

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
        <asp:Label ID="lblStatus" runat="server" Text="Label" class="login-box-msg"></asp:Label>
      <br />
      <div>
        <asp:DataList runat="server" id="dtContact1" Width="100%">
        
        
        <ItemTemplate>
                <div class="widget-user-image">
                    <asp:Image ID="cropimage1" alt="User Avatar" runat="server" Height="300px" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : Eval("foto") %>'/>
                </div>
        </ItemTemplate>

    </asp:DataList>
          <asp:Image ID="cropimage1" alt="User Avatar" runat="server" Visible="false"/>
          <asp:Image ID="ImageCrop" alt="User Avatar" runat="server" Visible="false" Height="300px"/>
              <input type="hidden" id="coordinate_x" runat="server"/>
              <input type="hidden" id="coordinate_y" runat="server"/>
              <input type="hidden" id="coordinate_w" runat="server"/>
              <input type="hidden" id="coordinate_h" runat="server"/>
        <br />
      </div>
      <div class="form-group has-feedback">
        <asp:FileUpload ID="FileUpload1" runat="server" />
          <br />
        <asp:Button ID="ButtonPilih" OnClick="btnPilih_click" runat="server" Text="Pilih" class="btn btn-default" />
          <asp:Button ID="ButtonCrop" OnClick="btnCrop_click" runat="server" Text="Crop" class="btn btn-default" />
      <div class="row">
        <!-- /.col -->
        <div class="col-xs-4">
          <asp:Button ID="btnUpdate" OnClick="btnUpdate_click" runat="server" Text="Update" class="btn btn-primary" />
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


    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    
</body>
</html>
