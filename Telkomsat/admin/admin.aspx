<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Telkomsat.admin.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>admin</title>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="../assets/css/style.min.css" rel="stylesheet" />
    <script src="../assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
</head>
<body class="skin-blue sidebar-mini" style="height:auto; min-height:100%">
<form id="form12" runat="server">
<div class="wrapper">
<header class="main-header">
    
    <!-- Logo -->
    <a href="../dashboard.aspx" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>T</b>SA</span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>Telkom </b>Satellite</span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </a>

    <div class="collapse navbar-collapse pull-left" id="navbar-collapse">
        <ul class="nav navbar-nav">
            <li><a href="../asset/home.aspx"><b>Home </b></a> </li>
        </ul>
    </div>

      <div class="navbar-custom-menu">
        
        <ul class="nav navbar-nav">
            
          <!-- Messages: style can be found in dropdown.less-->
          <!-- User Account: style can be found in dropdown.less -->
          <li class="dropdown user user-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <asp:Label ID="lblProfile" runat="server" Text="Label" CssClass="hidden-xs"></asp:Label>
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
                    <asp:Button runat="server" Text="Sign Out" class="btn btn-default btn-flat" OnClick="btnSignOut_Click" />
                   
                  
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
    </nav>
    
  </header>

<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar" style="height:auto">
       Sidebar user panel -->
      <div class="user-panel"> 
        <div class="pull-left image">
          <!--<asp:DataList runat="server" id="dtContact1" Width="100%">
        
        
        <ItemTemplate>
                <div class="widget-user-image">
                    <asp:Image ID="Image5" alt="User Avatar" runat="server" Width="45px" Height="45px" class="img-circle" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : Eval("foto") %>'/>
                </div>
        </ItemTemplate>

    </asp:DataList>-->
        </div>
        <div class="pull-left info">
            <asp:Label ID="lblProfile1" runat="server" Text="Label"></asp:Label>
          <a href="#"></a>
        </div>
      </div>
      <!-- search form -->
      <ul class="sidebar-menu">
        <li class="treeview"><a href="../asset/semuaasset.aspx">
            <i class="fa fa-database"></i><span><b>Dashboard</b></span></a></li>
      </ul>
      
      <!-- /.search form -->
      <!-- sidebar menu: : style can be found in sidebar.less -->
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">PENGELOLAAN</li>
        <li class="treeview">
          <a href="../asset/chart.aspx">
            <i class="fa fa-arrow-right"></i> <span>Pemasukan</span>
          </a>
        </li>
        <li class="treeview">
          <a href="../asset/chart.aspx">
            <i class="fa fa-arrow-left"></i> <span>Pengeluaran</span>
          </a>
        </li>
          <li class="treeview">
          <a href="../asset/chart.aspx">
            <i class="fa fa-exchange"></i> <span>Pemindahan</span>
          </a>
        </li>
        
        </ul>
        <ul class="sidebar-menu">
        <li class="header">RESEARCH</li>     
          <li class="treeview">
          <a href="../asset/chart.aspx">
            <i class="fa fa-space-shuttle"></i> <span>Chart</span>
          </a>
        </li>
        </ul>
    </section>
    <!-- /.sidebar -->
    
  </aside>
    
<div class="content-wrapper">
        <section class="content-header">
          <h1>
            Administrator
            <small>GCS</small>
          </h1>
          <ol class="breadcrumb">
            <li><asp:Label ID="lblTime" class="waktu" runat="server" Text="Label"></asp:Label> </li>
          </ol>
        </section>
            <section class="content">
                <div class="row">
                    <div class="col-lg-4 col-xs-12">
                      <!-- small box -->
                      <div class="small-box bg-aqua">
                        <div class="inner">
                          <span style="font-size:22px">1500000000</span>

                          <p>Total</p>
                        </div>
                        <div class="icon">
                          <i class="ion ion-calculator"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                      </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-4 col-xs-6">
                      <!-- small box -->
                      <div class="small-box bg-green">
                        <div class="inner">
                          <span style="font-size:22px">190.000.000<sup style="font-size: 20px">%</sup></span>

                          <p>Harkat</p>
                        </div>
                        <div class="icon">
                          <i class="ion ion-stats-bars"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                      </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-4 col-xs-6">
                      <!-- small box -->
                      <div class="small-box bg-yellow">
                        <div class="inner">
                          <span style="font-size:22px">230.000.000</span>

                          <p>Mechanical Electrical</p>
                        </div>
                        <div class="icon">
                          <i class="ion ion-android-list"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                      </div>
                    </div>
                    <!-- ./col -->
                  </div>
                <div class="row">
        <!-- Left col -->
                    <section class="col-lg-7 connectedSortable">
                      <!-- Custom tabs (Charts with tabs)-->
                      <div class="nav-tabs-custom">
                        <!-- Tabs within a box -->
                        <ul class="nav nav-tabs pull-right">
                          <li class="active"><a href="#revenue-chart" data-toggle="tab">Area</a></li>
                          <li><a href="#sales-chart" data-toggle="tab">Donut</a></li>
                          <li class="pull-left header"><i class="fa fa-money"></i> Total</li>
                        </ul>
                        <div class="tab-content no-padding">
                          <!-- Morris chart - Sales -->
                          <div class="chart tab-pane active" id="revenue-chart" style="position: relative; height: 300px;"></div>
                          <div class="chart tab-pane" id="sales-chart" style="position: relative; height: 300px;"></div>
                        </div>
                      </div>

                     <div class="box box-solid bg-teal-gradient">
                        <div class="box-header">
                            <i class="fa fa-money"></i> Pemasukan
                        </div>
                        <div class="box-body border-radius-none">
                          <!-- Morris chart - Sales -->
                          <div class="chart tab-pane active" id="income-chart" style="position: relative; height: 300px;"></div>
                        </div>
                      </div>
                        <div class="box box-solid bg-aqua-gradient">
                        <div class="box-header">
                            <i class="fa fa-money"></i> Pengeluaran
                        </div>
                        <div class="box-body border-radius-none">
                          <!-- Morris chart - Sales -->
                          <div class="chart tab-pane active" id="outcome-chart" style="position: relative; height: 300px;"></div>
                        </div>
                      </div>
                    </section>
                    <section class="col-lg-5 connectedSortable">

            <div class="box box-solid">
            <div class="box-header">
              <!-- tools box -->
              <div class="pull-right box-tools">
                <button type="button" class="btn btn-default btn-sm pull-right" data-widget="collapse"
                        data-toggle="tooltip" title="Collapse" style="margin-right: 5px;">
                  <i class="fa fa-minus"></i></button>
              </div>
              <!-- /. tools -->

              <i class="fa fa-newspaper-o"></i>

              <h3 class="box-title">
                Update Info
              </h3>
            </div>
            <div class="box-body">
              <div style="height: 250px; width: 100%;"></div>
            </div>
            <!-- /.box-body-->
            <div class="box-footer no-border">
              <div class="row">
                <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                  <div class="knob-label">Visitors</div>
                </div>
                <!-- ./col -->
                <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                  <div class="knob-label">Online</div>
                </div>
                <!-- ./col -->
                <div class="col-xs-4 text-center">
                  <div class="knob-label">Exists</div>
                </div>
                <!-- ./col -->
              </div>
              <!-- /.row -->
            </div>
          </div>


          <div class="box box-solid">
            <div class="box-header">
              <!-- tools box -->
              <div class="pull-right box-tools">
                <button type="button" class="btn btn-default btn-sm pull-right" data-widget="collapse"
                        data-toggle="tooltip" title="Collapse" style="margin-right: 5px;">
                  <i class="fa fa-minus"></i></button>
              </div>
              <!-- /. tools -->

              <i class="fa fa-map-marker"></i>

              <h3 class="box-title">
                Saldo
              </h3>
            </div>
            <div class="box-body">
              <div id="world-map" style="height: 250px; width: 100%;"></div>
            </div>
            <!-- /.box-body-->
            <div class="box-footer no-border">
              <div class="row">
                <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                  <div id="sparkline-1"></div>
                  <div class="knob-label">Visitors</div>
                </div>
                <!-- ./col -->
                <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                  <div id="sparkline-2"></div>
                  <div class="knob-label">Online</div>
                </div>
                <!-- ./col -->
                <div class="col-xs-4 text-center">
                  <div id="sparkline-3"></div>
                  <div class="knob-label">Exists</div>
                </div>
                <!-- ./col -->
              </div>
              <!-- /.row -->
            </div>
          </div>
          <!-- /.box -->

          <!-- solid sales graph -->
          
          <!-- /.box -->

          <div class="box box-default">
            <div class="box-header with-border">
              <h3 class="box-title">Browser Usage</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <div class="row">
                <div class="col-md-8">
                  <div class="chart-responsive">
                    <canvas id="pieChart" height="150"></canvas>
                  </div>
                  <!-- ./chart-responsive -->
                </div>
                <!-- /.col -->
                <div class="col-md-4">
                  <ul class="chart-legend clearfix">
                    <li><i class="fa fa-circle-o text-red"></i> Chrome</li>
                    <li><i class="fa fa-circle-o text-green"></i> IE</li>
                    <li><i class="fa fa-circle-o text-yellow"></i> FireFox</li>
                    <li><i class="fa fa-circle-o text-aqua"></i> Safari</li>
                    <li><i class="fa fa-circle-o text-light-blue"></i> Opera</li>
                    <li><i class="fa fa-circle-o text-gray"></i> Navigator</li>
                  </ul>
                </div>
                <!-- /.col -->
              </div>
              <!-- /.row -->
            </div>
            <!-- /.box-body -->
            <div class="box-footer no-padding">
              <ul class="nav nav-pills nav-stacked">
                <li><a href="#">United States of America
                  <span class="pull-right text-red"><i class="fa fa-angle-down"></i> 12%</span></a></li>
                <li><a href="#">India <span class="pull-right text-green"><i class="fa fa-angle-up"></i> 4%</span></a>
                </li>
                <li><a href="#">China
                  <span class="pull-right text-yellow"><i class="fa fa-angle-left"></i> 0%</span></a></li>
              </ul>
            </div>
            <!-- /.footer -->
          </div>
          <!-- /.box -->

        </section>
                </div>
            </section>
        </div>
    </div>
    <div class="control-sidebar-bg"></div>

    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="../assets/bower_components/raphael/raphael.min.js"></script>
    <script src="../assets/bower_components/morris.js/morris.min.js"></script>
    <script src="JavaScript.js" type="text/javascript"></script>
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">


  // To make Pace works on Ajax calls
  $(document).ajaxStart(function () {
    Pace.restart()
  })
  $('.ajax').click(function () {
    $.ajax({
      url: '#', success: function (result) {
        $('.ajax-content').html('<hr>Ajax Request Completed !')
      }
    })
  })

        function btnsubmit() {
            var inputdata = document.getElementById("inp").value;
            var mylink = "../home.aspx?tahun=" + inputdata;
            //alert(mylink);
            window.location.href = mylink;
            window.open(mylink);
        }
        function signout() {
            //sessionStorage.removeItem("user");
            var mylink = "../login.aspx?out";
            //alert(mylink);
            window.location.href = mylink;
        }

        $(function () {

            'use strict';

            var line = new Morris.Line({
                element: 'income-chart',
                resize: true,
                data: [
                    { y: '2011 Q1', item1: 2666 },
                    { y: '2011 Q2', item1: 2778 },
                    { y: '2011 Q3', item1: 4912 },
                    { y: '2011 Q4', item1: 3767 },
                    { y: '2012 Q1', item1: 6810 },
                    { y: '2012 Q2', item1: 5670 },
                    { y: '2012 Q3', item1: 4820 },
                    { y: '2012 Q4', item1: 15073 },
                    { y: '2013 Q1', item1: 10687 },
                    { y: '2013 Q2', item1: 8432 }
                ],
                xkey             : 'y',
                ykeys            : ['item1'],
                labels           : ['Item 1'],
                lineColors       : ['#efefef'],
                lineWidth        : 2,
                hideHover        : 'auto',
                gridTextColor    : '#fff',
                gridStrokeWidth  : 0.4,
                pointSize        : 4,
                pointStrokeColors: ['#efefef'],
                gridLineColor    : '#efefef',
                gridTextFamily   : 'Open Sans',
                gridTextSize     : 10
            });


            var line = new Morris.Line({
                element: 'outcome-chart',
                resize: true,
                data: [
                    { y: '2011 Q1', item1: 2666 },
                    { y: '2011 Q2', item1: 2778 },
                    { y: '2011 Q3', item1: 4912 },
                    { y: '2011 Q4', item1: 3767 },
                    { y: '2012 Q1', item1: 6810 },
                    { y: '2012 Q2', item1: 5670 },
                    { y: '2012 Q3', item1: 4820 },
                    { y: '2012 Q4', item1: 15073 },
                    { y: '2013 Q1', item1: 10687 },
                    { y: '2013 Q2', item1: 8432 }
                ],
                xkey             : 'y',
                ykeys            : ['item1'],
                labels           : ['Item 1'],
                lineColors       : ['#efefef'],
                lineWidth        : 2,
                hideHover        : 'auto',
                gridTextColor    : '#fff',
                gridStrokeWidth  : 0.4,
                pointSize        : 4,
                pointStrokeColors: ['#efefef'],
                gridLineColor    : '#efefef',
                gridTextFamily   : 'Open Sans',
                gridTextSize     : 10
            });
            var area = new Morris.Area({
                element: 'revenue-chart',
                resize: true,
                data: [
                    { y: '2011 Q1', item1: 2666, item2: 2666 },
                    { y: '2011 Q2', item1: 2778, item2: 2294 },
                    { y: '2011 Q3', item1: 4912, item2: 1969 },
                    { y: '2011 Q4', item1: 3767, item2: 3597 },
                    { y: '2012 Q1', item1: 6810, item2: 1914 },
                    { y: '2012 Q2', item1: 5670, item2: 4293 },
                    { y: '2012 Q3', item1: 4820, item2: 3795 },
                    { y: '2012 Q4', item1: 15073, item2: 5967 },
                    { y: '2013 Q1', item1: 10687, item2: 4460 },
                    { y: '2013 Q2', item1: 8432, item2: 5713 }
                ],
                xkey: 'y',
                ykeys: ['item1', 'item2'],
                labels: ['Item 1', 'Item 2'],
                lineColors: ['#a0d0e0', '#3c8dbc'],
                hideHover: 'auto'
            });


            var donut = new Morris.Donut({
                element: 'sales-chart',
                resize: true,
                colors: ['#3c8dbc', '#f56954', '#00a65a'],
                data: [
                    { label: 'Download Sales', value: 12 },
                    { label: 'In-Store Sales', value: 30 },
                    { label: 'Mail-Order Sales', value: 20 }
                ],
                hideHover: 'auto'
            });

            // Fix for charts under tabs
            $('.box ul.nav a').on('shown.bs.tab', function () {
                area.redraw();
                donut.redraw();
                line.redraw();
            });
        });
</script>
</form>
</body>
</html>
