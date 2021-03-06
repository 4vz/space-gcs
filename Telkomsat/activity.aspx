﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activity.aspx.cs" Inherits="Telkomsat.activity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log Aktivitas</title>
    <link href="./assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="./assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="./assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="./assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="./assets/css/style.min.css" rel="stylesheet" />
    <link href="./Style2.css" rel="stylesheet" />
    <link href="./Style1.css?version2" rel="stylesheet" />
    <link href="./stylepagination.css?version=2" rel="stylesheet" />
    <link rel="stylesheet" href="./assets/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"/>
    <link rel="stylesheet" href="./assets/bower_components/select2/dist/css/select2.min.css"/>

    <link rel="stylesheet" href="./assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"/>
    <link rel="stylesheet" href="./assets/mylibrary/jquery-ui.css" />
    <link rel="stylesheet" href="./assets/mylibrary/bootstrap.min.css" />
    <link rel="stylesheet" href="./assets/mylibrary/fontgoogle.css" />
    <style>
        ul, ol {
            margin-top:10px;
            margin-bottom:0px;
        }

        ul{
            padding-left: 25px;
        }

        li{
            padding-bottom:10px;
        }
        .skin-blue .sidebar-menu>li:hover>a, .skin-blue .sidebar-menu>li.active>a, .skin-blue .sidebar-menu>li.menu-open>a{
            background-color:transparent;
            color:cornflowerblue;
        }
        .skin-blue .sidebar-menu>li>.treeview-menu{
            background-color:transparent;
            color:cornflowerblue;
        }
        .skin-blue .sidebar-menu .treeview-menu>li>a{
            color:cornflowerblue;
        }
        .skin-blue .sidebar-menu .treeview-menu>li.active>a, .skin-blue .sidebar-menu .treeview-menu>li>a:hover{
            color:dodgerblue;
        }
        .sidebar-menu>li>a{
            padding:6px;
        }
        .treeview-menu>li>a{
            padding-top:0px;
            padding-right:0px;
            padding-bottom:0px;
        }
    </style>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
</head>
<body class="hold-transition skin-blue layout-top-nav">
    <form id="form1" runat="server">
        <div class="wrapper">
              <header class="main-header">
                <nav class="navbar navbar-static-top">
        
                  <div class="container">
                    <div class="navbar-header">
                      <a href="../dashboard2.aspx" class="navbar-brand"> <b>Telkomsat</b></a>
                      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse">
                        <i class="fa fa-bars"></i>
                      </button>
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
                        <asp:DataList runat="server" id="dtContact1" Width="100%"> 
                            <ItemTemplate>
                                    <div class="widget-user-image">
                                        <asp:Image ID="Image5" alt="User Avatar" runat="server" class="img-circle" Width="55px" Height="55px" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : Eval("foto") %>'/>
                                    </div>
                            </ItemTemplate>

                        </asp:DataList>

                            <p><a href="../profile.aspx" style="color:white">
                              Edit Profile
                              <small>2019</small>
                                </a>
                            </p>
                          </li>
                          <!-- Menu Body -->
              
                          <!-- Menu Footer-->
                          <li class="user-footer">
                            <div class="pull-right">
                                <asp:Button ID="btn" runat="server" Text="Sign Out" CssClass="btn btn-default"/>
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
            <div class="content-wrapper" style="background-color:#ecf0f5">
                <div class="container">
    <!-- Content Header (Page header) -->
            <section class="content-header">
              <h1>
                Log Aktivitas
              </h1>
              <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> Dashboard</a></li>
                <li class="active">Log Aktivitas</li>
              </ol>
            </section>
         <section class="content">
            <div class="row">
            <div class="col-md-3" style="padding-top:0px">


                <div class="box box-solid">
                <div class="box-header with-border">
                    <h3 class="box-title">Kategori</h3>

                    <div class="box-tools">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                    </button>
                    </div>
                </div>
                <div class="box-body no-padding">
                    <ul class="nav nav-pills nav-stacked">
                        <li id="lichhk" runat="server"><a href="#"><i class="fa fa-check"></i> Checklist Harkat
                            <span class="badge bg-red-active pull-right" runat="server" id="Span4">
                            <asp:Label ID="lblchhk" runat="server" Text=""></asp:Label></span></a></li>
                        <li id="lichme" runat="server"><a href="#"><i class="fa fa-close"></i> Checklist ME
                            <span class="badge bg-red-active pull-right" runat="server" id="spnnotif">
                            <asp:Label ID="lblchme" runat="server" Text=""></asp:Label></span></a></li>
                        <li id="limthk" runat="server"><a href="#"><i class="fa fa-star"></i> Logbook
                            <span class="badge bg-red-active pull-right" runat="server" id="Span1">
                            <asp:Label ID="lblmthk" runat="server" Text=""></asp:Label></span></a></li>
                        <li id="limtme" runat="server"><a href="#"><i class="fa fa-check-square"></i> Approval
                            <span class="badge bg-red-active pull-right" runat="server" id="Span2">
                            <asp:Label ID="lblmtme" runat="server" Text=""></asp:Label></span></a></li>
                    </ul>
                </div>
                <!-- /.box-body -->
                </div>
                <!-- /. box -->
                </div>
                        <div class="col-md-7 connectedSortable">
                            <div class="box box-danger" style="min-height:90%;">
                                <div class="box-header">
                                    <span runat="server" style="text-align:center; font-size:16px; font-weight:bold" id="spmonth"></span>
                                </div>
                                <div class="box-body">
                                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                                </div>
                            </div>
                        </div>
             <div class="col-md-2">
                 <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>  
             </div>
                    </div>
    <!-- /.row -->
        </section>
        </div>
                
                <!-- /.col -->
              </div>
              <!-- /.row -->
            
            <!-- /.content -->
          </div>
          <!-- /.content-wrapper -->
          <footer class="main-footer">
            <div class="pull-right hidden-xs">
              <b>Version</b> 2.4.0
            </div>
            <strong>Copyright 2019-2020 <a href="gcs.telkom.space/dashboard.aspx">GCS Telkomsat</a>.</strong> 
          </footer>

        <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <script src="../assets/bower_components/PACE/pace.min.js"></script>
        <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
        <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
        <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
        <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
        <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
        <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
        <script src="../assets/mylibrary/jquery.table2excel.min.js"></script>
        <script type="text/javascript" src="../assets/mylibrary/js.js"></script>

    </form>
</body>
</html>
