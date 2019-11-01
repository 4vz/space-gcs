<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewticket.aspx.cs" Inherits="Telkomsat.ticket.viewticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ticket</title>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="../assets/css/style.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../assets/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"/>
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css?version2" rel="stylesheet" />
    <link href="stylepagination.css?version=1" rel="stylesheet" />
    <link href="ticket.css?version3" rel="stylesheet" />
    <link href="dashboard.css?version=7" rel="stylesheet" type="text/css"/>
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
</head>
<body class="hold-transition skin-blue layout-top-nav">
    <form id="form1" runat="server">
        <div class="wrapper">
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
                          <li><a href="../checklist/checklistgcs.aspx">Checklist</a></li>
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
                        <asp:DataList runat="server" id="dtContact2" Width="100%"> 
                            <ItemTemplate>
                                    <div class="widget-user-image">
                     
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
            <div class="content-wrapper">
                <div class="container">
    <!-- Content Header (Page header) -->
            <section class="content-header">
              <h1>
                Ticket
              </h1>
                      
              <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> Dashboard</a></li>
                <li class="active">Ticket</li>
              </ol>
            </section>

            <!-- Main content -->
            <section class="content">
              <div class="row">
                <div class="col-md-3">
                  <a href="../ticket/tambah.aspx" class="btn btn-primary btn-block margin-bottom">New Ticket</a>

                  <div class="box box-solid">
                    <div class="box-header with-border">
                      <h3 class="box-title">Folders</h3>

                      <div class="box-tools">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                        </button>
                      </div>
                    </div>
                    <div class="box-body no-padding">
                      <ul class="nav nav-pills nav-stacked">
                        <li class="active"><a href="../ticket/ticket.aspx"><i class="fa fa-inbox"></i> Ticket</a></li>
                        <li><a href="#"><i class="fa fa-check-circle-o"></i> Accepted</a></li>
                        <li><a href="#"><i class="fa fa-chain-broken"></i> Rejected</a></li>
                          <li><a href="#"><i class="fa fa-star"></i> Favorit</a></li>
                        <li id="spam" runat="server"><a href="#"><i class="fa fa-trash"></i> Spam</a></li>
                      </ul>
                    </div>
                    <!-- /.box-body -->
                  </div>
                  <!-- /. box -->
                  <div class="box box-solid">
                    <div class="box-header with-border">
                      <h3 class="box-title">Priority</h3>

                      <div class="box-tools">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                        </button>
                      </div>
                    </div>
                    <div class="box-body no-padding">
                      <ul class="nav nav-pills nav-stacked">
                        <li><a href="#"><i class="fa fa-circle-o text-red"></i> High</a></li>
                        <li><a href="#"><i class="fa fa-circle-o text-yellow"></i> Medium</a></li>
                        <li><a href="#"><i class="fa fa-circle-o text-light-blue"></i> Low</a></li>
                      </ul>
                    </div>
                    <!-- /.box-body -->
                  </div>
                  <!-- /.box -->
                </div>
                  <asp:HiddenField ID="hfContactID" runat="server" />
                <!-- /.col -->
        <div class="col-md-9">
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Ticket</h3> <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>

              
            </div>
            <!-- /.box-header -->
            <div class="box-body with-border">
              <asp:DataList runat="server" id="datalist1" CssClass="table">
            <ItemTemplate>
            <asp:Label Text='<%# Eval("subject") %>' runat="server" class="judulLB1 pdg" />
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB pdg" Text='<%# "from : " + Eval("nama_user") %>'/>
                <asp:Label ID="Label1" runat="server" class="namaLB pdg" Text='<%# "  ( " + Eval("nomor_hp") + " )" %>'/>

            <span class="pull-right">
                <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# Eval("prioritas") %>' />
            </span>
            <br />
                <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB pdg" Text='<%# ((DateTime)Eval("tanggal")).ToString("dd/MM/yyyy HH:mm") %>' />
                <span class="pull-right">
                <asp:Label ID="lblStatus" runat="server" class="kategoriLB" Text='<%# Eval("status") %>' />
            </span>
            <br />
                <br />
                <br />
            <asp:Label ID="AKTIVITASLabel" runat="server" class="aktivitasLB1 pdg" Text='<%# Eval("keterangan") %>' />
            <br />
        </ItemTemplate>

    </asp:DataList>
            </div>
            <!-- /.box-body -->
            
            <!-- /.box-footer -->
            <div class="box-footer">
              <div class="pull-right">
                  <button type="button" id="btnaccept" class="btn btn-primary" runat="server" onclick="if (confirm('Sure?')) return" onserverclick="Accepted_ServerClick"><i class="fa fa-check"></i> Accepted</button>
                  <button type="button" id="btnreject" class="btn btn-danger" runat="server" onclick="if (confirm('Sure?')) return" onserverclick="Rejected_ServerClick"><i class="fa fa-close"></i> Rejected</button>
                  <button type="button" id="btncomplete" class="btn btn-success" runat="server" visible="false" onclick="if (confirm('Sure?')) return" onserverclick="Accepted_ServerClick"><i class="fa fa-check"></i> Completed</button>
                  <button type="button" id="btnincomplete" class="btn btn-default" runat="server" visible="false" onclick="if (confirm('Sure?')) return" onserverclick="Rejected_ServerClick"><i class="fa fa-close"></i> Not Complete</button>
                
              </div>
                <button type="button" class="btn btn-default"><i class="fa fa-edit"></i> Edit</button>
            </div>
            <!-- /.box-footer -->
          </div>
          <!-- /. box -->
        </div>
        <!-- /.col -->
      </div>
                </section>
                <!-- /.col -->
              </div>
              <!-- /.row -->
            
            <!-- /.content -->
                    </div>
          </div>
          <!-- /.content-wrapper -->
          <footer class="main-footer">
            <div class="pull-right hidden-xs">
              <b>Version</b> 2.4.0
            </div>
            <strong>Copyright &copy; 2014-2016 <a href="https://adminlte.io">Almsaeed Studio</a>.</strong> All rights
            reserved.
          </footer>

    </form>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
</body>

</html>
