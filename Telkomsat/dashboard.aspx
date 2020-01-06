<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Telkomsat.dashboard" %>

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
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css?version2" rel="stylesheet" />
    <link href="stylepagination.css?version=2" rel="stylesheet" />
    <link href="dashboard.css?version=8" rel="stylesheet" type="text/css"/>
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
        media="screen" />
    <style type="text/css">
        #example2 th, td {
            white-space: nowrap;
        }
        #peta {
          width: 100%;
          height: 400px;

        }
    </style>
    
</head>

<body class="hold-transition skin-blue layout-top-nav">
    <form id="form1" runat="server">
<div class="wrapper" style="height:auto">

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
            
    </nav>
  </header>

  <!-- Full Width Column -->
  <div class="content-wrapper" style="height:auto;">
    <div class="container">
      <!-- Content Header (Page header) -->
      <section class="content-header">
        <h1>
          <img src="img/logotelkomsat2.png" height="60" alt="Alternate Text" />
        </h1>
        
      </section>

      <!-- Main content -->
      <section class="content">
      <div class="row" style="height:auto">
          <div class="col-lg-9 col-xs-12 col-sm-9 col-md-9">
          <div class="nav-tabs-custom">

                    <ul class="nav nav-tabs pull-right">
                      <li class="active"><a href="#foto" data-toggle="tab">Dokumentasi</a></li>
                      <li><a href="#lokasi" data-toggle="tab">Lokasi</a></li>
                      <li class="pull-left header"><i class="fa fa-inbox"></i> Ground Control System</li>
                    </ul>
              
                <div class="tab-content no-padding">
                    <div id="lokasi" class="tab-pane fade">
                        <div id="peta"></div>
                    </div>
                    <div id="foto" class="tab-pane fade in active">
                        <a href="profileperson.aspx">
                    		<div id="myCarousel" class="carousel slide" data-ride="carousel">
			<!-- Indicators -->
			                <ol class="carousel-indicators">
				                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
				                <li data-target="#myCarousel" data-slide-to="1"></li>
				                <li data-target="#myCarousel" data-slide-to="2"></li>	
                                <li data-target="#myCarousel" data-slide-to="3"></li>
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
			                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
				                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
				                <span class="sr-only">Previous</span>
			                </a>
			                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
				                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
				                <span class="sr-only">Next</span>
			                </a>
		                </div>
                        </a>
                    </div>
                </div>
               
            </div>
            </div>
          <button type="button" visible="false" id="Button1" style="float:right; color:darkred; background-color:transparent" data-toggle="modal" data-target="#exampleModalButton" class="btn-file" runat="server"><i class="fa fa-plus" style="font-size:12px"></i>
                </button>
          <div class="col-lg-3 col-xs-12 col-sm-3 col-md-3">
          <div class="box box-default" style="max-height:450px; height:auto; min-height:300px">
                <div class="box-header with-border">
                    Event 
                <button type="button" id="btnModal" style="float:right; color:darkred; background-color:transparent" onserverclick="btnModal_ServerClick" class="btn-file" runat="server"><i class="fa fa-plus" style="font-size:12px"></i>
                </button>
                </div>
                <div class="box-body" style="width:100%; margin:0 auto;">
                    <asp:Label ID="lblEvent" runat="server" Text="Tidak ada event" CssClass="waktudashboard2"></asp:Label>
                    <asp:DataList runat="server" id="dtEvent" CssClass="dtAssets" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="dtEvent_ItemDataBound">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" class="img-circle" Height="20px" Width="20px" ImageUrl='<%# Eval("icon")==DBNull.Value ? null : Eval("icon") %>'/>
                        <asp:Label Text='<%# Eval("event") %>' runat="server" class="namadashboard" />
                        <asp:Label Text='<%# " diselenggarakan oleh " + Eval("penyelenggara") %>' runat="server" class="event" />
                        <br />
                        <i class="fa fa-clock-o" style="color:#777777"></i>
                        <asp:Label ID="Label1" runat="server" class="waktudashboard" Text='<%# ((DateTime)Eval("tanggal")).ToString("dd MMM yyyy") %>'/>
                        <asp:Label Text='<%# Eval("jam") %>' runat="server" class="waktudashboard" />
                        <br />
                        <i class="fa fa-map-marker" style="color:#777777"></i>
                        <asp:Label ID="lokasi" runat="server" Text='<%# Eval("lokasi") %>' Font-Size="14px" />
                        <br />
                        <asp:LinkButton Text="sunting" runat="server" class="a" CommandArgument='<%# Eval("ID_Event") %>' CommandName="id" ID="lbSunting"
                            Visible='<%# Eval("statususer").ToString() != Session["jenis1"].ToString() ? false : true %>'/>
                        <hr width="100%" />
                    </ItemTemplate>

                </asp:DataList>
                </div>
            </div>
            </div>
        </div>

      <div class="row">
        
        <!-- ./col -->
        

        <div class="col-lg-4 col-xs-12 col-sm-4 col-md-4">
          <div class="box box-success" style="min-height:600px;">
                <div class="box-header with-border">
                    Pemberitahuan
                </div>
              <div style="margin-left:5px;">
          <asp:Label ID="lblAsset" runat="server" Text="Label" Visible="false" CssClass="waktudashboard2"></asp:Label>
              <asp:DataList runat="server" id="dtAsset" CssClass="dtAssets">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" class="waktudashboard" Text='<%# ((DateTime)Eval("TANGGAL")).ToString("dd/MM/yyyy") %>'/>
                        <br />
                        <asp:Image ID="Image2" runat="server" class="img-circle" Height="20px" Width="20px" ImageUrl="~/img/download.png"/>
                        <asp:Label Text='<%# Eval("user_name") %>' runat="server" class="namadashboard" />
                        <asp:Label Text=" melakukan perubahan data " runat="server" />
                        <asp:Label ID="NAMALabel" runat="server" class="waktudashboard" Text='<%# Eval("NAMA") %>'/>
                        <asp:Label Text=" dengan SN " runat="server" />
                        <asp:Label ID="AKTIVITASLabel" runat="server" class="waktudashboard" Text='<%# Eval("[S/N]") %>' />
                        <br />
                       
                        <hr width="100%" />
                    </ItemTemplate>

                </asp:DataList>
                  </div>
            </div>
            </div>
                
        <!-- ./col -->
           
        <div class="col-lg-8 col-sm-8 col-md-8 col-xs-12">
          <!-- small box -->
            

            <div class="box box-danger" style="min-height:400px;">
                <div class="box-header with-border">
                    Ticket
                    </div>
                <div class="box-body">
                    <div class="table-responsive mailbox-messages">
                    <div class="table table-responsive">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
                </div>
            <!-- /.col -->
            </div>
                </div>

            <div class="box box-primary" style="height:300px;">
                <br />
                    <span style="margin-left:10px; font-size:14px; color:darkslateblue; margin-bottom:10px">Aktivitas GCS</span>
                    <hr width="100%" />
          <div class="tab-content">
              <div class="active tab-pane" id="activity" style="margin-left:5px">
                <!-- Post -->
                  <asp:Label ID="lblLogbook" runat="server" Text="Label" Visible="false" CssClass="waktudashboard2"></asp:Label>
            <asp:DataList runat="server" id="dtLogbook" CssClass="dtAssets">
                    <ItemTemplate>
                        <asp:Image ID="Image3" runat="server" class="img-circle" Height="30px" Width="30px" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : Eval("foto") %>'/>
                        <asp:Label Text='<%# Eval("nama") %>' runat="server" class="namadashboard" />
                        <br />
                        <asp:Label ID="NAMALabel" runat="server" class="waktudashboard" Text='<%# ((DateTime)Eval("TANGGAL")).ToString("dd/MM/yyyy") %>'/>
                        <br />
                        <asp:Label ID="AKTIVITASLabel" runat="server" class="eventdashboard" Text='<%# Eval("EVENT") %>' />
                        <br />
                        <hr width="100%" />
                    </ItemTemplate>

                </asp:DataList>
                <!-- Post -->
                <!-- /.post -->
              </div>
              <!-- /.tab-pane -->
             <!-- /.tab-pane -->

              <!-- /.tab-pane -->
            </div>
            </div>

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

      <div class="pull-right hidden-xs">
        <b>Version</b> 2.0
      </div>
      <strong>Copyright &copy; 2019 <a href="https://www.telkomsat.co.id">Telkomsat</a>.</strong> All rights
      reserved.
    <!-- /.container -->
  </footer>
</div>
  <div class="modal fade" id="exampleModalButton" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content" style="height:400px;">
       <div class="modal-header" style="background-color:darkred">
                <button type="button" class="close" data-dismiss="modal">
                    &times;
                </button>
                <h4 class="modal-title" style="color:ghostwhite">Tambah Event</h4>
            </div>
      <div class="modal-body">
          <div class="divtabel">
          <table align="center">
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Pilih Icon</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="5">
                      <div class="select-sim" id="select-color">
                          <div class="options">
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
                      <asp:TextBox ID="txtEven" class="tb1" runat="server" Width="300px" TextMode="MultiLine" Height="60px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Lokasi</label>
                  </td>
                  <td colspan="3" style="padding-left:40px; padding-bottom:15px;"">
                      <asp:TextBox ID="txtLokasi" class="tb1" runat="server" Width="300px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Tanggal</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;">
                      <input type="text" id="txtttl" runat="server" class="tb1" onkeypress="return runScript(event)" />
                      
                  </td>
                  <td style="padding-bottom:15px;">
                      <asp:DropDownList ID="ddlJam" runat="server" class="ddl3" Width="70px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>00:00</asp:ListItem>
                        <asp:ListItem>00:30</asp:ListItem>
                        <asp:ListItem>01:00</asp:ListItem>
                        <asp:ListItem>01:30</asp:ListItem>
                        <asp:ListItem>02:00</asp:ListItem>
                        <asp:ListItem>02:30</asp:ListItem>
                        <asp:ListItem>03:00</asp:ListItem>
                        <asp:ListItem>03:30</asp:ListItem>
                        <asp:ListItem>04:00</asp:ListItem>
                        <asp:ListItem>04:30</asp:ListItem>
                        <asp:ListItem>05:00</asp:ListItem>
                        <asp:ListItem>05:30</asp:ListItem>
                        <asp:ListItem>06:00</asp:ListItem>
                        <asp:ListItem>06:30</asp:ListItem>
                        <asp:ListItem>07:00</asp:ListItem>
                        <asp:ListItem>07:30</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>08:30</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>09:30</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>12:30</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>13:30</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>14:30</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>15:30</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>16:30</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>17:30</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>18:30</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>19:30</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>20:30</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>21:30</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>22:30</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                        <asp:ListItem>23:30</asp:ListItem>

                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Penyelenggara</label>
                  </td>
                  <td colspan="3" style="padding-left:40px; padding-bottom:15px;"">
                      <asp:TextBox ID="txtPenyelenggara" class="tb1" runat="server" Width="300px"></asp:TextBox>
                  </td>
              </tr>
          </table>
              </div>
        </div>

      </div>
      <div class="modal-footer">
          <asp:Button runat="server" Text="submit" class="btn btn-primary" OnClick="btnSubmit" Visible="false" ID="btntambah" />
          <asp:Button runat="server" Text="edit" class="btn btn-success" OnClick="Unnamed_Click" Visible="false" ID="btnedit"/>
          <asp:Button runat="server" Text="hapus" class="btn btn-success" OnClick="btnDelete_Click" Visible="false" ID="btnhapus" />
        <!-- <button type="button" class="btn btn-primary">Button</button> -->
      </div>
    </div>
  </div>
  <div class="modal fade" id="modaltiket" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog">
                <div class="modal-content">
                <section class="panel panel-danger">
      <header class="panel-heading" style="background-color:darkred; border-color:darkred;">
                <button type="button" class="close" data-dismiss="modal">
                    &times;
                </button>
                <h4 class="modal-title" style="color:ghostwhite">Ticket</h4>
            </header>
      <div class="panel-body">
          <div class="divtabel">
          <table align="center">
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Nama</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="5">
                      <asp:TextBox ID="txt2nama" CssClass="form-control" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Nomor HP</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="5">
                      <asp:TextBox ID="txt2No" CssClass="form-control" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Subject</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;"" colspan="3">
                      <asp:TextBox ID="txt2subject" CssClass="form-control" runat="server" Width="300px" TextMode="MultiLine" Height="60px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Keterangan</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="3">
                      <asp:TextBox ID="txt2keterangan" CssClass="form-control" runat="server" Width="300px" TextMode="MultiLine" Height="200px"></asp:TextBox>
                  </td>
              </tr>
              
          </table>
              </div>
        </div>
        <footer class="panel-footer">
                        <div class="row" style="height:auto">
                            <div class="col-md-12 text-right">
                                <button class="btn btn-primary" type="submit" runat="server" onserverclick="saveticket">Submit</button>
                                <button class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </footer>
                </section>
      </div>
    </div>
  </div>

        </form>


<!-- ./wrapper -->

    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <!--<script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>-->
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBXJtWR3xFFcpCXG971HMX6zdCjm8BRHzU&libraries=places,geometry&v=3"></script>
   <script type="text/javascript">
       (function() {
  window.onload = function() {
var map;
    //Parameter Google maps
    var options = {
      zoom: 5, //level zoom
	  //posisi tengah peta
      center: new google.maps.LatLng(-1.104140,113.769642),
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
	
	 // Buat peta di 
    var map = new google.maps.Map(document.getElementById('peta'), options);
	 // Tambahkan Marker 
     var locations = [
               		    ['Telkom Cibinong', -6.4480592, 106.9362584],
                   		['Telkom Banjarmasin', -3.328096, 114.583624],
                   		['Telkom Manado', 1.4868708, 124.8432774],
                   		['Telkom Medan', 3.5827399, 98.6896095], 		
    
    ];
	  var infowindow = new google.maps.InfoWindow();

    var marker, i;
     /* kode untuk menampilkan banyak marker */
    for (i = 0; i < locations.length; i++) {  
      marker = new google.maps.Marker({
        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
        map: map,
		 icon: 'anten.png'
      });
     /* menambahkan event clik untuk menampikan
     	 infowindows dengan isi sesuai denga
	    marker yang di klik */
		
      google.maps.event.addListener(marker, 'click', (function(marker, i) {
        return function() {
          infowindow.setContent(locations[i][0]);
          infowindow.open(map, marker);
        }
      })(marker, i));
    }
  

  };
})();

	</script>
    <script>
        $(document).ready(function(){
          $(".nav-tabs a").click(function(){
            $(this).tab('show');
          });
        });
</script>
   <script>
       $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "ordering": true,
          "info": true,
          "autoWidth": true,
          "scrollX": true
          });
           $('.dataTables_length').addClass('bs-select');
       });

       
        $(function () {
            $("#txtttl").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                onClose: function (selectedDate) {
                    $("#txtttl").datepicker("option", "minDate", "19/07/2019", selectedDate);
                }
            });
       })
    </script>
</body>
</html>
