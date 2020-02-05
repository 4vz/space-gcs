<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard2.aspx.cs" Inherits="Telkomsat.dashboard2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
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
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css?version2" rel="stylesheet" />
    <link href="stylepagination.css?version=2" rel="stylesheet" />
    <link href="dashboard.css?version=12" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"/>
    <link rel="stylesheet" href="./assets/mylibrary/jquery-ui.css" />
    <link rel="stylesheet" href="assets/mylibrary/bootstrap.min.css" />
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <style type="text/css">
        @media all and (min-width:1500px) {
            .container {
                width:1330px;
            }
        }
        @media all and (min-width:1700px) {
            .container {
                width: 1560px;
            }
        }

        #example2 th, td {
            white-space: nowrap;
        }
        #peta {
          width: 100%;
          height: 400px;

        }
        .tengah{
            text-align:center;
        }

        p{
            margin-bottom:5px;
            z-index:2147483647;
        }

        .carousel-indicators .active{
            background-color:transparent;
            border-color:transparent;
        }

        .carousel-indicators li{
            border-color:transparent;
        }
        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td{
            border-top:none;
        }

        .ab{
            color:orangered;
        }

        .dropdown-submenu {
          position: relative;
        }

        .dropdown-submenu .dropdown-menu {
          top: 0;
          left: 100%;
          margin-top: -1px;
        }
    </style>
</head>
<body class="hold-transition skin-blue layout-top-nav">
    <form id="form1" runat="server">
        <input type="hidden" id="mylabel" runat="server"/>
        <div class="wrapper" style="height:auto">
             <header class="main-header">
                <nav class="navbar navbar-static-top">
        
                  <div class="container">
                    <div class="navbar-header">
                      <a href="../dashboard2.aspx" class="navbar-brand"> <b>Telkomsat</b></a>
                      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse">
                        <i class="fa fa-bars"></i>
                      </button>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse pull-left" id="navbar-collapse">
                      <ul class="nav navbar-nav">
                          <li class="dropdown">
                              <a href="#" class="dropdown-toggle" data-toggle="dropdown">Fitur GCS <span class="caret"></span></a>
                              <ul class="dropdown-menu" role="menu">
                                <li><a href="../dataasset/alldata.aspx">Data Asset</a></li>
                                <li><a href="../datalogbook/data.aspx">Logbook</a></li>
                                <li><a href="../admin/dashboard.aspx">Administrator</a></li>
                                <li class="dropdown-submenu">
                                    <a class="test" tabindex="-1" href="#">Checklist <span class="caret"></span></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="../checkhk/harian.aspx">Harkat</a></li>
                                        <li><a href="../checklistme/harian.aspx">ME</a></li>
                                    </ul>
                                </li>
                              </ul>
                          </li>
                          <li><a href="../knowledge/semua.aspx">Knowledge</a></li>
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
                                <asp:Button ID="btn" runat="server" Text="Sign Out" CssClass="btn btn-default" />
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

        <div class="content-wrapper" style="height:auto;">
            <div class="container no-padding">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                        <img src="img/logotelkomsat2.png" height="50" alt="Alternate Text" />
                    </h1>
                    <asp:Label CssClass="breadcrumb" ID="lblwaktu1" runat="server" Text="Label" Font-Bold="true" ForeColor="#808080" Font-Size="Large"></asp:Label>
        
                </section>
            <asp:TextBox ID="txtpie" CssClass="hidden" runat="server" Text=""></asp:TextBox>
                <asp:TextBox ID="txtsent" CssClass="hidden" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtconfirm" CssClass="hidden" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtcomplete" CssClass="hidden" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtreject" CssClass="hidden" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtaccept" CssClass="hidden" runat="server"></asp:TextBox>
                <!-- Main content -->
                <section class="content no-padding">
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box bg-aqua">
                            <span class="info-box-icon"><i class="fa fa-bookmark-o"></i></span>

                            <div class="info-box-content">
                                <span class="info-box-text">Checklist Harkat</span>
                                <span class="info-box-number">-</span>

                            <div class="progress">
                            <div class="progress-bar" runat="server" id="divhk" style="width: 0%"></div>
                            </div>
                        <asp:Label ID="lblchharkat" CssClass="progress-description" runat="server" Text="Tidak ada data checklist"></asp:Label>
                        </div>
                        <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
            <!-- /.col -->
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="info-box bg-green">
                        <span class="info-box-icon"><i class="fa fa-thumbs-o-up"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Checklist ME</span>
                            <span class="info-box-number">Malam</span>

                            <div class="progress">
                            <div class="progress-bar" runat="server" id="divmalam" style="width: 0%"></div>
                            </div>
                                <asp:Label ID="lblmalamme" CssClass="progress-description" runat="server" Text="Tidak ada data checklist"></asp:Label>
                        </div>
                        <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- /.col -->
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="info-box bg-yellow">
                        <span class="info-box-icon"><i class="fa fa-calendar"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Checklist ME</span>
                            <span class="info-box-number">Pagi</span>

                            <div class="progress">
                            <div class="progress-bar" runat="server" id="divpagi" style="width: 0%"></div>
                            </div>
                                <asp:Label ID="lblpagime" CssClass="progress-description" runat="server" Text="Tidak ada data checklist"></asp:Label>
                        </div>
                        <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- /.col -->
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="info-box bg-red">
                        <span class="info-box-icon"><i class="fa fa-comments-o"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Checklist ME</span>
                            <span class="info-box-number">Siang</span>

                            <div class="progress">
                            <div class="progress-bar" runat="server" id="divsiang" style="width: 0%"></div>
                            </div>
                                <asp:Label ID="lblsiangme" CssClass="progress-description" runat="server" Text="Tidak ada data checklist"></asp:Label>
                        </div>
                        <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- /.col -->
                    </div>
                    <div class="row">
                    <div class="col-lg-8 col-md-12">
                        <div class="box box-danger">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12" style="min-height:220px;">
                                        <h5><b>Logbook hari ini</b></h5>
                                        <asp:Label ID="lblEvent" runat="server" Text="Tidak ada logbook hari ini" CssClass="waktudashboard2"></asp:Label>
                                        <asp:PlaceHolder ID="PlaceholderNow" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div class="col-md-6" style="min-height:220px">
                                        <h5><b>Logbook On Progress</b></h5>
                                        <table class="table">
                                            <tr>
                                                <td >Utama</td>
                                                <td >:</td>
                                                <td><asp:Label ID="lbutama" runat="server" Text="0"></asp:Label></td>
                                                <td><a style="font-size:12px; font-weight:normal" href="datalogbook/onprogress.aspx">View</a></td>
                                            </tr>
                                            <tr>
                                                <td >Mutasi Asset</td>
                                                <td >:</td>
                                                <td><asp:Label ID="lbmutasi" runat="server" Text="0"></asp:Label></td>
                                                <td><a style="font-size:12px; font-weight:normal" href="datalogbook/onprogress.aspx?tipe=mutasi">View</a></td>
                                            </tr>
                                            <tr>
                                                <td >Status Asset</td>
                                                <td >:</td>
                                                <td><asp:Label ID="lbStatus" runat="server" Text="0"></asp:Label></td>
                                                <td><a style="font-size:12px; font-weight:normal" href="datalogbook/onprogress.aspx?tipe=status">View</a></td>
                                            </tr>
                                            <tr>
                                                <td >Konfigurasi</td>
                                                <td >:</td>
                                                <td><asp:Label ID="lbkonfig" runat="server" Text="0"></asp:Label></td>
                                                <td><a style="font-size:12px; font-weight:normal" href="datalogbook/onprogress.aspx?tipe=konfigurasi">View</a></td>
                                            </tr>
                                            <tr>
                                                <td >Lain-lain</td>
                                                <td >:</td>
                                                <td><asp:Label ID="lblain" runat="server" Text="0"></asp:Label></td>
                                                <td><a style="font-size:12px; font-weight:normal" href="datalogbook/onprogress.aspx?tipe=lain-lain">View</a></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-md-6">
                                        <h5><b>Logbook Deadline</b></h5>
                                        <asp:Label ID="lbldeadline" runat="server" Text="Tidak ada logbook deadline" CssClass="waktudashboard2"></asp:Label>
                                        <asp:PlaceHolder ID="PlaceHolderDeadline" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-12">
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs pull-right">
                              <li class="pull-left header"><i class="fa fa-check-circle"></i> Shift ME</li>
                                <a href="superadmin/shiftme.aspx" class="pull-right" runat="server">Add</a>
                            </ul>
                            <div class="tab-content no-padding">
                        <div class="tab-pane fade in active">
                    		<div id="myCarousel" class="carousel slide" data-ride="carousel">
			<!-- Indicators -->
			                <ol class="carousel-indicators">
                                <li data-target="#myCarousel" data-slide-to="0"></li>
				                <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
				                <li data-target="#myCarousel" data-slide-to="2"></li>
			                </ol>
 
			                <!-- deklarasi carousel -->
			                <div class="carousel-inner" role="listbox" style="padding-bottom:5px">
                                <div class="item" style="background-color:darkseagreen">
                                    <p class="tengah" style="font-size:22px; font-weight:bold">Kemarin</p>
					                <p class="text-bold tengah">Shift Pagi</p>
                                    <p class="tengah" id="pagikemaren" runat="server">(data belum diisi)</p><br />
                                    <p class="text-bold tengah">Shift Sore</p>
                                    <p class="tengah" runat="server" id="sorekemaren">(data belum diisi)</p>
                                </div>
				                <div class="item active" style="background-color:floralwhite">
                                    <p class="tengah" style="font-size:22px; font-weight:bold">Hari ini</p>
					                <p class="text-bold tengah">Shift Pagi</p>
                                    <p class="tengah" runat="server" id="paginow">(data belum diisi)</p><br />
                                    <p class="text-bold tengah">Shift Sore</p>
                                    <p class="tengah" runat="server" id="sorenow">(data belum diisi)</p>
				                </div>
                                <div class="item" style="background-color:cyan">
                                    <p class="tengah" style="font-size:22px; font-weight:bold">Besok</p>
					                <p class="text-bold tengah">Shift Pagi</p>
                                    <p class="tengah" id="pagitomorrow" runat="server">(data belum diisi)</p><br />
                                    <p class="text-bold tengah">Shift Sore</p>
                                    <p class="tengah" runat="server" id="soretomorrow">(data belum diisi)</p>
                                </div>
			                </div>
 
			                <!-- membuat panah next dan previous -->
			                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
				                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
				                <span class="sr-only">Previous</span>
			                </a>
			                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
				                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
				                <span class="sr-only">Next</span>
			                </a>
		                </div>
                    </div>
                    </div>
                    </div>
                        <div class="box box-solid bg-light-blue-gradient">
                            <div class="box-body" style="max-width:100%; margin:0px">
                                <asp:Label ID="lblwaktu" runat="server" Text="Event" Font-Bold="true" Font-Size="Large"></asp:Label>
                                <button type="button" class="btn btn-sm btn-primary pull-right" id="btnadd" data-toggle="modal" data-target="#modalupdate1">ADD</button>
                                    <div class="row">
                                        <asp:DataList runat="server" id="dtEvent" CssClass="table" OnItemCommand="DataList1_ItemCommand" style="max-width:100%; position:relative">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" class="img-circle" Height="20px" Width="20px" ImageUrl='<%# Eval("icon")==DBNull.Value ? null : Eval("icon") %>'/>
                                            <span style="max-width:100%; white-space:pre-line; font-weight:bold; position:relative"> <%# Eval("event") %></span> <br />
                                            <asp:Label ForeColor="White"  Text='<%# " PIC : " + Eval("penyelenggara") %>' style="max-width:100%; white-space:pre-line;" runat="server" class="event" />
                                            <br />
                                            <i class="fa fa-clock-o" style="color:aliceblue"></i>
                                            <asp:Label ID="Label1" ForeColor="WhiteSmoke" runat="server" class="waktudashboard" Text='<%# ((DateTime)Eval("tanggal")).ToString("dd MMM yyyy") %>'/>
                                            <asp:Label Text='<%# Eval("jam") %>' runat="server" ForeColor="WhiteSmoke" class="waktudashboard" /> 
                                            <i class="fa fa-map-marker" style="color:azure; padding-left:10px;"></i>
                                            <asp:Label ID="lokasi" runat="server" style="white-space:pre-line;" Text='<%# Eval("lokasi") %>' Font-Size="14px" />
                                            <br />
                                            <asp:LinkButton Text="sunting" runat="server" class="ab" CommandArgument='<%# Eval("ID_Event") %>' CommandName="id" ID="lbSunting"/>
                                            <hr width="100%" style="margin-top:5px; margin-bottom:5px" />
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                            <div class="weather-report" style="height:78px; width:100%;"></div>
                        </div>
                    </div>
                </div>
                    <div class="row">
                        <div class="col-md-4">
                                <div class="box box-default">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Saldo</h3>

                                        <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                                        </button>
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
                                             <li><i class="fa fa-circle-o text-gray"></i> Null</li>
                                            <li><i class="fa fa-circle-o text-red"></i> Sent</li>
                                            <li><i class="fa fa-circle-o text-green"></i> Accepted</li>
                                            <li><i class="fa fa-circle-o text-yellow"></i> Complete</li>
                                            <li><i class="fa fa-circle-o text-aqua"></i> Confirm</li>
                                            <li><i class="fa fa-circle-o text-light-blue"></i> Reject</li>
                                            </ul>
                                        </div>
                                        <!-- /.col -->
                                        </div>
                                        <!-- /.row -->
                                    </div>
                                    <!-- /.box-body -->
                                    <div class="box-footer no-padding">
                                        <ul class="nav nav-pills nav-stacked">
                                        <li><a href="#">TCC
                                            <span class="pull-right text-red"> 0%</span></a></li>
                                        <li><a href="#">SCO <span class="pull-right text-green"> 0%</span></a>
                                        </li>
                                        <li><a href="#">SCA <span class="pull-right text-green"> 0%</span></a>
                                        </li>
                                        </ul>
                                    </div>
                                    <!-- /.footer -->
                                    </div>

                        </div>

                        <div class="col-md-8">
                            <div class="nav-tabs-custom">

                                <ul class="nav nav-tabs pull-right">
                                  <li class="active"><a href="#foto" data-toggle="tab">Dokumentasi</a></li>
                                  <li><a href="#lokasi" data-toggle="tab">Naru</a></li>
                                  <li class="pull-left header"><i class="fa fa-inbox"></i> Ground Control System</li>
                                </ul>
              
                            <div class="tab-content no-padding">
                                <div id="lokasi" class="tab-pane fade">
                                    
                                </div>
                                <div id="foto" class="tab-pane fade in active">
                                    <a href="profileperson.aspx">
                    		            <div id="myCarousel2" class="carousel slide" data-ride="carousel">
			            <!-- Indicators -->
			                            <ol class="carousel-indicators">
				                            <li data-target="#myCarousel2" data-slide-to="0" class="active"></li>
				                            <li data-target="#myCarousel2" data-slide-to="1"></li>
				                            <li data-target="#myCarousel2" data-slide-to="2"></li>	
                                            <li data-target="#myCarousel2" data-slide-to="3"></li>
			                            </ol>
 
			                            <!-- deklarasi carousel -->
			                            <div class="carousel-inner" role="listbox">
				                            <div class="item active">
					                            <img src="img/capture.jpg" alt="" style="max-height:100%; max-width:100%" width="1100"/>
					                            <div class="carousel-caption">
						                            <h3>Satellite Operation Cibinong</h3>
					                            </div>
				                            </div>
				                            <div class="item">
					                            <img src="img/ba.jpg" alt="" style="max-height:100%; max-width:100%" width="1100"/>
					                            <div class="carousel-caption">
						                            <p>Saling berbagi kesusahan dan kemudahan</p>
					                            </div>
				                            </div>
				                            <div class="item">
					                            <img src="img/bb.jpg" alt="" style="max-height:100%; max-width:100%" width="1100"/>
					                            <div class="carousel-caption">
						                            <p>Saling terbuka untuk menjadi lebih baik</p>
					                            </div>
				                            </div>		
                                            <div class="item">
					                            <img src="img/bc.jpg" alt="" style="max-height:100%; max-width:100%" width="1100"/>
					                            <div class="carousel-caption">
						                            <p>Kehangatan dan kebersamaan tidak hanya didapat di kantor</p>
					                            </div>
				                            </div>			
			                            </div>
 
			                            <!-- membuat panah next dan previous -->
			                            <a class="left carousel-control" href="#myCarousel2" role="button" data-slide="prev">
				                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
				                            <span class="sr-only">Previous</span>
			                            </a>
			                            <a class="right carousel-control" href="#myCarousel2" role="button" data-slide="next">
				                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
				                            <span class="sr-only">Next</span>
			                            </a>
		                            </div>
                                    </a>
                                </div>
                            </div>
               
                        </div>

                        </div>
                    </div>
                </section>
           </div>
        </div>
        </div>
<div class="modal fade" id="modalupdate1">
  <div class="modal-dialog">
    <div class="modal-content">
       <div class="modal-header" style="background-color:darkred">
                <button type="button" class="close" data-dismiss="modal">
                    &times;
                </button>
                <h4 class="modal-title" style="color:ghostwhite">Tambah Event</h4>
        </div>
      <div class="modal-body">
          <table align="center">
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Pilih Icon</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="5">
                      <div class="select-sim" id="select-color">
                          <div class="options">
                              <div class="option">
                                  <input type="radio" name="icon" value="manuver" id="color-rocket" />
                                  <label for="color-blue">
                                    <img src="img/rocket.png" alt="" width="20" height="20" /> Manuver
                                  </label>
                            </div>
                              <div class="option">
                                  <input type="radio" name="icon" value="vendor" id="color-vendor" />
                                  <label for="color-blue">
                                    <img src="img/vendor.png" alt="" width="20" height="20" /> Vendor
                                  </label>
                            </div>
                            <div class="option">
                              <input type="radio" name="icon" value="sport" id="color-" />
                              <label for="color-">
                                <img src="img/sport.png" alt="" width="20" height="20" /> Olahraga
                              </label>
                            </div>
                            <div class="option">
                              <input type="radio" name="icon" value="rapat" id="color-red" />
                              <label for="color-red">
                                <img src="img/meeting.png" alt="" width="20" height="20" /> Rapat
                              </label>
                            </div>
                            <div class="option">
                              <input type="radio" name="icon" value="makan" id="color-green" />
                              <label for="color-green">
                                <img src="img/makan.png" alt="" width="20" height="20" /> Makan-makan
                              </label>
                            </div>
                            <div class="option">
                              <input type="radio" name="icon" value="holiday" id="color-blue" />
                              <label for="color-blue">
                                <img src="img/holiday.jpg" alt="" width="20" height="20" /> Liburan
                              </label>
                            </div>
                              </div>
                          </div>

                  </td>
              </tr>
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Nama Event</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;"" colspan="3">
                      <asp:TextBox ID="txtEven" class="form-control" runat="server" Width="300px" TextMode="MultiLine" Height="60px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Lokasi</label>
                  </td>
                  <td colspan="3" style="padding-left:40px; padding-bottom:15px;"">
                      <asp:TextBox ID="txtLokasi" class="form-control" runat="server" Width="300px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Tanggal</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;">
                      <input type="text" id="txtttl" runat="server" class="form-control datepick" autocomplete="off" />
                      
                  </td>
                  <td style="padding-bottom:15px;">
                      <input type="time" id="txttime" runat="server" class="form-control time"/>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">PIC</label>
                  </td>
                  <td colspan="3" style="padding-left:40px; padding-bottom:15px;"">
                      <asp:TextBox ID="txtPenyelenggara" class="form-control" runat="server" Width="300px"></asp:TextBox>
                  </td>
              </tr>
          </table>
        </div>
      <div class="modal-footer">
          <asp:Button runat="server" Text="submit" class="btn btn-primary" style="display:none" ID="btntambah" OnClick="btntambah_Click" />
          <asp:Button runat="server" Text="edit" class="btn btn-success" Visible="false" ID="btnedit"/>
          <asp:Button runat="server" Text="hapus" class="btn btn-success" Visible="false" ID="btnhapus" />
        <!-- <button type="button" class="btn btn-primary">Button</button> -->
      </div>
    </div>
      </div>
  </div>

        
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
        <script>
            $(function () {
                 $(".datepick").datepicker({startDate:null,autoclose: true,
                    format: 'yyyy/mm/dd', endDate: null
                });

                var test = $('#' + '<%= mylabel.ClientID %>').val();
                var test3 = test.split(',');
                console.log(test3);

                var pieChartCanvas = $('#pieChart').get(0).getContext('2d');
                var pieChart       = new Chart(pieChartCanvas);
                var PieData        = [
                    {
                        value: $('#<%=txtsent.ClientID %>').val(),
                        color    : '#f56954',
                        highlight: '#f56954',
                        label    : 'Sent'
                    },
                    {
                        value    : $('#<%=txtaccept.ClientID %>').val(),
                        color    : '#00a65a',
                        highlight: '#00a65a',
                        label    : 'Accepted'
                    },
                    {
                        value    : $('#<%=txtcomplete.ClientID %>').val(),
                        color    : '#f39c12',
                        highlight: '#f39c12',
                        label    : 'Complete'
                    },
                    {
                        value    : $('#<%=txtconfirm.ClientID %>').val(),
                        color    : '#00c0ef',
                        highlight: '#00c0ef',
                        label    : 'Confirm'
                    },
                    {
                        value    : $('#<%=txtreject.ClientID %>').val(),
                        color    : '#3c8dbc',
                        highlight: '#3c8dbc',
                        label    : 'Reject'
                    }
                ];

                var pieData2 = [{
                    value: 1,
                    color: '#bebebe',
                    highlight: '#f56954',
                    label: 'Rek. Harkat 1'
                }];
                var pieOptions     = {
                // Boolean - Whether we should show a stroke on each segment
                segmentShowStroke    : true,
                // String - The colour of each segment stroke
                segmentStrokeColor   : '#fff',
                // Number - The width of each segment stroke
                segmentStrokeWidth   : 1,
                // Number - The percentage of the chart that we cut out of the middle
                percentageInnerCutout: 50, // This is 0 for Pie charts
                // Number - Amount of animation steps
                animationSteps       : 100,
                // String - Animation easing effect
                animationEasing      : 'easeOutBounce',
                // Boolean - Whether we animate the rotation of the Doughnut
                animateRotate        : true,
                // Boolean - Whether we animate scaling the Doughnut from the centre
                animateScale         : false,
                // Boolean - whether to make the chart responsive to window resizing
                responsive           : true,
                // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
                maintainAspectRatio  : false,

                };
                // Create pie or douhnut chart
                // You can switch between pie and douhnut using the method below.
                if ($('#<%=txtpie.ClientID %>').val() == null || $('#<%=txtpie.ClientID %>').val() == '') {
                    pieChart.Doughnut(pieData2, pieOptions);
                }
                else {
                    pieChart.Doughnut(PieData, pieOptions);
                }
                
            })

            $(document).on("click", "#btnadd", function () {
                $('#<%=btntambah.ClientID %>').show();
            });

            $(document).ready(function(){
              $('.dropdown-submenu a.test').on("click", function(e){
                $(this).next('ul').toggle();
                e.stopPropagation();
                e.preventDefault();
              });
            });
        </script>
    </form>
</body>
</html>
