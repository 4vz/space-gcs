 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileperson.aspx.cs" Inherits="Telkomsat.profileperson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="../assets/css/style.min.css" rel="stylesheet" />
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css" rel="stylesheet" />
    <link href="stylepagination.css" rel="stylesheet" />
    <link href="profile.css" rel="stylesheet" type="text/css"/>
    <link href="profile2.css?version=3" rel="stylesheet" />
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
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
                <asp:DataList runat="server" id="DataList1" Width="100%"> 
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
        
    <div class="content-wrapper">
    <div class="container">
    <div class="register-logo">
    <a href="../../index2.html"><b>Profile User</b> GCS</a>
  </div> 
    <div>
        <hr width="100%" />
    </div>
    <asp:HiddenField ID="hfContactID" runat="server" />
    <div class="register-box">
      <asp:HiddenField ID="HiddenField1" runat="server" />

    
      <asp:DataList runat="server" id="dtContact" Width="100%">
        
        
        <ItemTemplate>

            <div>
            <div class="box box-widget widget-user-2">
            <div class="widget-user-header bg-yellow">
                <div class="widget-user-image">
                    <asp:Image ID="Image5" alt="User Avatar" runat="server" class="img-circle" Height="60px" Width="60px" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : Eval("foto") %>'/>
                </div>
                <asp:Label class="widget-user-username" Text='<%# Eval("nama") %>' runat="server" Font-Size="16px" Font-Bold="true"/><br />
                <asp:Label class="widget-user-username" Text="GCS" runat="server" Font-Size="13px" Font-Bold="true"/><br />
                <br />
            </div>
            <div class="box-footer no-padding"> 
                <ul class="nav nav-stacked">
                <li style="padding-left:20px; padding-top:7px; padding-bottom:7px">Nomor HP<span class="pull-right" style="margin-right:10px;"><asp:Label ID="KATEGORILabel" runat="server" Text='<%# Eval("nomor") %>' /></span> </li>
                <li style="padding-left:20px; padding-top:7px; padding-bottom:7px">Email<span class="pull-right" style="margin-right:10px;"><asp:Label ID="WAKTULabel" runat="server" Text='<%# Eval("email") %>' /></span> </li>
                <li style="padding-left:20px; padding-top:7px; padding-bottom:7px">Tanggal Lahir<span class="pull-right" style="margin-right:10px;"><asp:Label ID="Label1" runat="server" Text='<%# Eval("ttl")==DBNull.Value ? null : ((DateTime)Eval("ttl")).ToString("dd MMM yyyy") %>' /></span> </li>
                <li style="padding-left:20px; padding-top:7px; padding-bottom:7px">Tanggal Masuk<span class="pull-right" style="margin-right:10px;"><asp:Label ID="Label2" runat="server" Text='<%# Eval("tanggal_masuk")==DBNull.Value ? null : ((DateTime)Eval("tanggal_masuk")).ToString("dd MMM yyyy") %>' /></span></li>
                </ul>
            </div>
            

                </div>
                </div>

        </ItemTemplate>

    </asp:DataList>
            </div>
    
        
    </div>
        </div>
    </form>
    </div>

    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="JavaScript.js" type="text/javascript"></script>
</body>
</html>
