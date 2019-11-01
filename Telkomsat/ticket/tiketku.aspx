<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiketku.aspx.cs" Inherits="Telkomsat.ticket.ticketku" %>

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
                <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
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
                        <li><a href="#"><i class="fa fa-envelope-o"></i> Accepted</a></li>
                        <li><a href="#"><i class="fa fa-envelope-o"></i> Rejected</a></li>
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
                <!-- /.col -->
                <div class="col-md-9">
                  <div class="box box-primary">
                    <div class="box-header with-border">
                      <h3 class="box-title">Ticket</h3>
                      <!-- /.box-tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                      <div class="table-responsive mailbox-messages">
                        <div class="table table-responsive">
                            <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                                </div>
                        <!-- /.table -->
                      </div>
                      <!-- /.mail-box-messages -->
                    </div>
                    <div class="box-footer no-padding">
                      <div class="mailbox-controls">
                        <div class="btn-group">
                          <button type="button" id="dispdelete" class=" btn btn-default btn-sm"><i class="fa fa-trash-o"></i> Delete</button>
                        </div>
                        <!-- /.btn-group -->
                        <button type="button" id="disp" class=" btn btn-default btn-sm"><i class="fa fa-star"></i> Favorit</button>
                        <!-- /.pull-right -->
                      </div>
                    </div>
                    <!-- /.box-body -->
                  </div>
                  <!-- /. box -->
                </div>
                <!-- /.col -->
              </div>
              <!-- /.row -->
            </section>
            <!-- /.content -->
                    </div>
                      <asp:HiddenField ID="HiddenField1" runat="server" />
                      <input type="button" value="display" id="disp1" runat="server" onserverclick="disp_ServerClick" visible="false"/>
                       <input type="button" value="display" id="dispdelete1" runat="server" onserverclick="dispdelete_ServerClick" visible="false"/>
          </div>
          <!-- /.content-wrapper -->
          <footer class="main-footer">
            <div class="pull-right hidden-xs">
              <b>Version</b> 2.4.0
            </div>
            <strong>Copyright &copy; 2014-2016 <a href="https://adminlte.io">Almsaeed Studio</a>.</strong> All rights
            reserved.
          </footer>

        </div>
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
    <script>
       $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
          "autoWidth": true,
          "scrollX": true,
          "order": [[ 1, 'desc' ]],
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });


        $(document).ready(function () {
            $('#checkBoxAll').click(function () {
                if ($(this).is(":checked"))
                    $('.chkCheckBoxId').prop('checked', true);
                else
                    $('.chkCheckBoxId').prop('checked', false);
            });
        });

        $('#disp').click(function () {
            var arrayid = [];
            var hf = document.getElementById('<%= HiddenField1.ClientID%>');
            var buttondisp = document.getElementById('<%= disp1.ClientID%>');
            $(".chkCheckBoxId:checked").each(function () {               
                arrayid.push($(this).val());     
            });
            console.log(arrayid);
            hf.value = arrayid;
            buttondisp.click();
        });

        $('#dispdelete').click(function () {
            var arrayid = [];
            var hf = document.getElementById('<%= HiddenField1.ClientID%>');
            var buttondisp = document.getElementById('<%= dispdelete1.ClientID%>');
            $(".chkCheckBoxId:checked").each(function () {               
                arrayid.push($(this).val());     
            });
            console.log(arrayid);
            hf.value = arrayid;
            buttondisp.click();
        });
    </script>
</body>
</html>
