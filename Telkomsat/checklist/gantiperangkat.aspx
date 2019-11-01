<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gantiperangkat.aspx.cs" Inherits="Telkomsat.checklist.gantiperangkat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ganti Perangkat</title>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="../assets/css/style.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../assets/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"/>
    <link href="check.css" rel="stylesheet"/>
    <script src="../assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />

    <style type="text/css">
        tr:nth-child(even) {
          background-color: #f2f2f2
        }
    </style>
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
            <li><a href="../checklist/checklistgcs.aspx">Tambah Checklist</a></li>
              <li><a href="../checklist/view.aspx">Data</a></li>
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
    <div class="content-wrapper" style="min-height:1300px;">
    <div class="container">
    <section class="content">
      <!-- Small boxes (Stat box) -->
      <div class="row">
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua-gradient">
            <div class="inner" style="text-align:center">
              <span style="font-size:19px; font-weight:bold">CHECKLIST</span>

              <p>Harian</p>

            </div>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua-active">
            <div class="inner" style="text-align:center">
              <span style="font-size:19px; font-weight:bold">MAINTENANCE</span>

              <p>Mingguan</p>

            </div>
            
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua-active">
            <div class="inner" style="text-align:center">
              <span style="font-size:19px; font-weight:bold">MAINTENANCE</span>

              <p>Bulanan</p>
            </div>
            
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua-active">
            <div class="inner" style="text-align:center">
              <span style="font-size:19px; font-weight:bold">MAINTENANCE</span>

              <p>3 Bulanan</p>
            </div>
            
          </div>
        </div>

          <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua-active">
            <div class="inner" style="text-align:center">
              <span style="font-size:19px; font-weight:bold">MAINTENANCE</span>

              <p>6 Bulanan</p>
            </div>
            
          </div>
        </div>

          <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua-active">
            <div class="inner" style="text-align:center">
              <span style="font-size:19px; font-weight:bold">MAINTENANCE</span>

              <p>1 Tahun</p>
            </div>
            
          </div>
        </div>
        <!-- ./col -->
      </div>
        <div class="row">
        <!-- Left col -->
        <section class="col-lg-6 connectedSortable" style="min-height:50px">
            <div class="col-lg-4 col-xs-6" style="padding-left:0; padding-bottom:15px; padding-right:15px">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl" Width="100%">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Telkom 2</asp:ListItem>
                <asp:ListItem>T3S Ku-Band</asp:ListItem>
                <asp:ListItem>T3S C-Band</asp:ListItem>
                <asp:ListItem>MPSat</asp:ListItem>
                <asp:ListItem>FMA 11</asp:ListItem>
                <asp:ListItem>HPA</asp:ListItem>
            </asp:DropDownList>
                </div>
             <div class="col-lg-4 col-xs-6" style="padding-bottom:15px;">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="ddl" Width="100%">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Harkat</asp:ListItem>
                <asp:ListItem>ME</asp:ListItem>
            </asp:DropDownList>
            </div>
             <div class="col-lg-4 col-xs-12" style="padding-bottom:15px; ">
            <asp:Button ID="Button1" runat="server" Text="Pilih" CssClass="btn btn-success btn-xs" OnClick="Pilih_Click" Width="100%"/>
            </div>
        </section>
        </div>
                <section class="content">
      <div class="row">
        <div class="col-12">
            <div class="box box-danger">
          <div class="card">
              <div class="box-header">
            <div class="card-header">
              <h3 class="card-title">Hover Data Table</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">

            <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  

            </div>
            <!-- /.card-body -->
          </div>
              </div>
                </div>

          <!-- /.card -->

          <!-- /.card -->
        </div>
        <!-- /.col -->
      </div>

        <div class="modal fade" id="modal-default" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
                <div class="modal-content">
                <section class="panel panel-primary">

                    <header class="panel-heading">
                        <h2 class="panel-title">Edit Serial Number</h2>
                    </header>
                    <div class="panel-body">
                            <div class="form-group" style="padding-bottom:15px;">
                                <label class="col-sm-3 control-label">Perangkat</label>
                                <div class="col-sm-9">
                                    <asp:Label ID="lblPerangkat" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group" style="padding-bottom:15px;">
                                <label class="col-sm-3 control-label">SN Lama</label>
                                <div class="col-sm-9">
                                    <asp:Label ID="lblSN" runat="server" Text="VC6843"></asp:Label>
                                </div>
                            </div>
                        <div class="form-group" style="padding-bottom:15px;">
                                <label class="col-sm-3 control-label">SN Baru</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtSN" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                    </div>
                    <footer class="panel-footer">
                        <div class="row">
                            <div class="col-md-12 text-right">
                                <button class="btn btn-primary modal-confirm" runat="server" id="submitform" onserverclick="editsn">Submit</button>
                                <button class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </footer>
                </section>
                </div>
            </div>          <!-- /.modal-dialog -->
        </div>
      <!-- /.row -->
    </section>

        </section>
        </div>
        </div>
        </div>

    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="../assets/dist/js/adminlte.min.js"></script>
    <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../assets/plugins/jQuery-ui/js/jquery-ui.min.js"></script>
    <script src="../assets/plugins/jQuery-ui/js/jquery-ui.js"></script>
    <script src="JavaScript.js" type="text/javascript"></script>
    <script src="../assets/dist/js/demo.js"></script>
    <script>
  $(function () {
      $("#example1").DataTable();
    $("#example2").DataTable({
      "paging": false,
      "lengthChange": false,
      "searching": false,
      "ordering": true,
      "info": true,
      "autoWidth": false
    });
  });

        function test(obj) {      
        var currentOrderID = $(obj).attr('CommandArgument');
        var text = document.getElementById('<%=lblPerangkat.ClientID%>');
        var text2 = document.getElementById('<%=lblSN.ClientID%>');
        
        //var button1 = document.getElementById(
        var commandstring = currentOrderID.split('%');
        var idcommand = commandstring[1].replace(/#/g, ' ');
        //button1.click();
        //document.getElementById('text1').value = "bsbsb";
            text.textContent = idcommand;
            text2.textContent = commandstring[0];
        
            //alert(currentOrderID);
            // Call model popup 
        openmodalaccept();
            console.log(document.getElementById("example2"))
    } 
    
        </script>
    </form>
</body>
</html>
