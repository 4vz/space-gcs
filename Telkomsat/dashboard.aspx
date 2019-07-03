<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Telkomsat.dashboard" %>

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
    <link href="stylepagination.css?version=1" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" type="text/css"/>
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
</head>
<body class="hold-transition skin-blue layout-top-nav">
<div class="wrapper">

  <header class="main-header">
    <nav class="navbar navbar-static-top">
        <form id="form1" runat="server">
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
            </form>
    </nav>
  </header>
  <!-- Full Width Column -->
  <div class="content-wrapper">
    <div class="container">
      <!-- Content Header (Page header) -->
      <section class="content-header">
        <h1>
          <img src="img/logotelkomsat2.png" height="60" alt="Alternate Text" />
        </h1>
        
      </section>

      <!-- Main content -->
      <section class="content">
      <div class="row">
          <div class="col-lg-12 col-xs-12 col-sm-12 col-md-12">
          <div class="box box-default">
                <div class="box-header with-border">
                    Gound Control System
                </div>
              <a href="profileperson.aspx">
                <div class="box-body" style="width:100%; margin:0 auto;">
                    <img src="img/capture.jpg" alt="" style="max-height:100%; max-width:100%" width="1100"/>
                </div>
               </a>
            </div>
            </div>
        </div>

      <div class="row">
        
        <!-- ./col -->
        

        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
            <a href="../asset/home.aspx" class="small-box-footer">
          <div class="small-box bg-red-active">
            <div class="inner">
              <h3>Database Asset</h3>
                <div class="icon">
                    <img src="img/download.png" alt="" width="320" height="310"/>
            </div>
            </div>
          </div>
        </a>
        </div>
                
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <a href="../logbook1/semuadata.aspx" class="small-box-footer">
          <div class="small-box bg-black">
            <div class="inner">
              <h3>Logbook</h3>
            </div>
            <div class="icon">
              <img src="img/logbook.jpg" alt="" width="320" height="310"/>
            </div>
          </div>
              </a>
        </div>
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
        <a href="../knowledge/semua.aspx" class="small-box-footer">
          <div class="small-box bg-info">
            <div class="inner">
              <h3>Knowledge</h3>
            </div>
            <div class="icon">
                <img src="img/book.png" alt="" width="320" height="310"/>
            </div>
          </div>
            </a>
        </div>
        <!-- ./col -->
      </div>
        
        
        
        <!-- /.box -->
      </section>
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
</div>
<!-- ./wrapper -->

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
