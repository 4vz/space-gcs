<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shiftme.aspx.cs" Inherits="Telkomsat.superadmin.shiftme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shift ME</title>
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
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
    <link href="../Style2.css" rel="stylesheet" />
    <link href="../Style1.css?version2" rel="stylesheet" />
    <link href="../stylepagination.css?version=2" rel="stylesheet" />
    <link rel="stylesheet" href="../assets/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"/>
    <link rel="stylesheet" href="../assets/bower_components/select2/dist/css/select2.min.css"/>
    <link href="../dashboard.css?version=12" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"/>
    <link rel="stylesheet" href="../assets/mylibrary/jquery-ui.css" />
    <link rel="stylesheet" href="../assets/mylibrary/bootstrap.min.css" />
    <style type="text/css">
        .select2-container--default .select2-selection--multiple .select2-selection__choice{
            background-color:darkblue;
        }
    </style>
    <style type="text/css">
        #example2 th, td {
            white-space: nowrap;
        }
        #peta {
          width: 100%;
          height: 400px;

        }
        h4 {
            position: relative;
            font-size: 16px;
            font-family:Constantia;
            z-index: 1;
            overflow: hidden;
            text-align: center;
        }

            h4:before, h4:after {
                position: absolute;
                top: 51%;
                overflow: hidden;
                width: 50%;
                height: 1px;
                content: '\a0';
                background-color: gray;
            }

            h4:before {
                margin-left: -50%;
                text-align: right;
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
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Checklist <span class="caret"></span></a>
                                    <ul class="dropdown-menu" role="menu">
                                    <li><a href="../dataasset/alldata.aspx">Data Asset</a></li>
                                    <li><a href="../datalogbook/data.aspx">Logbook</a></li>
                                    <li><a href="../admin/dashboard.aspx">Administrator</a></li>
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
                                            <asp:Image ID="Image5" alt="User Avatar" runat="server" class="img-circle" Width="55px" Height="55px" />
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
            <asp:TextBox ID="txtsatelit" runat="server" autocomplete="off" CssClass="hidden"></asp:TextBox>
        <div class="content-wrapper" style="height:auto;">
            <div class="container">
            <asp:TextBox ID="txtid1" runat="server" CssClass="hidden"></asp:TextBox>
            <asp:TextBox ID="txtid2" runat="server" CssClass="hidden"></asp:TextBox>
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                        <img src="../img/logotelkomsat2.png" height="50" alt="Alternate Text" />
                    </h1>
                    <span class="breadcrumb" style="font-size:16px">GCS</span>
        
                </section>

                <!-- Main content -->
                <div class="content">
                    <div class="row">
                        <section class="col-lg-4 connectedSortable">
                            <div class="box box-danger" style="min-height:90%">
                                <div class="box-header">
                                    Tambah Data
                                </div>
                                <div class="box-body">
                                    <div class="alert alert-success alert-dismissable" id="divsuccess" runat="server" visible="false">
                                        <h4><span class="fa fa-check"> Berhasil</span></h4>
                                        berhasil ditambahkan
                                    </div>
                                    <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Petugas :</label>
                                        <select class="form-control select2" multiple="multiple" data-placeholder="--Petugas--"
                                            style="width: 100%;" id="slsatelit">
                                              <option value="1">Syehab</option>
                                              <option value="2">Maman</option>
                                              <option value="3">Herman</option>
                                              <option value="4">Saiful</option>
                                              <option value="5">Badrudin</option>
                                              <option value="6">Putra</option>
                                              <option value="7">Ibnu</option>
                                              <option value="8">Heri</option>
                                              <option value="9">Radius</option>
                                              <option value="10">Sumanto</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Petugas :</label>
                                        <asp:DropDownList ID="ddljadwal" runat="server" placeholder="jadwal" CssClass="form-control">
                                            <asp:ListItem>Pagi</asp:ListItem>
                                            <asp:ListItem>Sore</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Tanggal :</label>
                                        <asp:TextBox ID="txttanggal" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnadd" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnadd_Click" />
                                    </div>
                                </div>
                               
                            </div>
                            <div class="box box-danger collapsed-box" style="min-height:90%">
                                <div class="box-header">
                                    <div class="pull-right box-tools">
                                        <button type="button" class="btn btn-primary btn-sm pull-right" data-widget="collapse"
                                                data-toggle="tooltip" title="Collapse" aria-expanded="false" style="margin-right: 5px;">
                                          <i class="fa fa-plus"></i></button>
                                      </div>
                                    Tuker SHift
                                </div>
                                <div class="box-body" style="display: none;">
                                    <div class="alert alert-success alert-dismissable" id="div1" runat="server" visible="false">
                                        <h4><span class="fa fa-check"> Berhasil</span></h4>
                                        berhasil ditambahkan
                                    </div>
                                    <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Petugas :</label>
                                        <select class="form-control" data-placeholder="--Petugas--" style="width: 100%;" id="slpetugas1" runat="server">
                                            <option value="0">--Petugas--</option>
                                              <option value="1">Syehab</option>
                                              <option value="2">Maman</option>
                                              <option value="3">Herman</option>
                                              <option value="4">Saiful</option>
                                              <option value="5">Badrudin</option>
                                              <option value="6">Putra</option>
                                              <option value="7">Ibnu</option>
                                              <option value="8">Heri</option>
                                              <option value="9">Radius</option>
                                              <option value="10">Sumanto</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Pilih Jadwal :</label>
                                        <select id="sljadwalbef" runat="server" class="form-control" style="width: 100%;"></select>
                                    </div>
                                    <div>
                                        <h4>Tukar Dengan</h4>
                                    </div>
                                    <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Petugas :</label>
                                        <select class="form-control" data-placeholder="--Petugas--" style="width: 100%;" id="slpetugas2" runat="server">
                                            <option value="0">--Petugas--</option>
                                              <option value="1">Syehab</option>
                                              <option value="2">Maman</option>
                                              <option value="3">Herman</option>
                                              <option value="4">Saiful</option>
                                              <option value="5">Badrudin</option>
                                              <option value="6">Putra</option>
                                              <option value="7">Ibnu</option>
                                              <option value="8">Heri</option>
                                              <option value="9">Radius</option>
                                              <option value="10">Sumanto</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Pilih Jadwal :</label>
                                        <select id="slselctaft" runat="server" class="form-control" style="width: 100%;"></select>
                                    </div>
                                     <div class="form-group">
                                        <label style="font-size:16px; font-weight:bold">Alasan :</label>
                                        <asp:TextBox ID="txtalasan" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnupdate_Click" UseSubmitBehavior="false"
                                            OnClientClick="this.disabled='true'; this.value='Please wait...';"  />
                                    </div>
                                </div>
                            </div>
                        </section>
                        <section class="col-lg-8 connectedSortable">
                            <div class="box box-danger" style="min-height:90%">
                                <div class="box-header">
                                    Data
                                </div>
                                <div class="box-body">
                                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                                </div>
                                 <div class="box-footer">
                                    <a class="btn btn-danger" href="viewshift.aspx">View</a>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
           </div>
        </div>
      </div>
        <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
        <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <script src="../assets/bower_components/PACE/pace.min.js"></script>
        <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
        <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
        <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
        <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
        <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
        <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
        <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
        <script type="text/javascript" src="../assets/mylibrary/js.js"></script>
        <script src="../assets/mylibrary/sweetalert.min.js"></script>
        <script>

            function fungsi() {
            alert("Berhasil Disimpan");
            }

            $('#<%=txttanggal.ClientID%>').datepicker({
                autoclose: true,
                format: 'yyyy/mm/dd',
                orientation: "bottom"
        });

        $('#<%=slpetugas1.ClientID %>').change(function () {
            $('#<%=sljadwalbef.ClientID %>').empty();
            
            var id = $(this).val();

            $.ajax({
                type: "POST",
                url: "shiftme.aspx/Get1",
                contentType: "application/json; charset=utf-8",
                data: '{sopetugas1:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sljadwalbef.ClientID %>').empty();
                    $('#<%=sljadwalbef.ClientID %>').append('<option value=0>' + '--Pilih Jadwal--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sljadwalbef.ClientID %>').append('<option value="' + this.idshift + '">' + this.tanggalshift + "  (" + this.jadwal + ")" + '</option>');
                    });
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
            });

            $('#<%=slpetugas2.ClientID %>').change(function () {
            $('#<%=slselctaft.ClientID %>').empty();
            
            var id = $(this).val();

            $.ajax({
                type: "POST",
                url: "shiftme.aspx/Get2",
                contentType: "application/json; charset=utf-8",
                data: '{sopetugas2:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slselctaft.ClientID %>').empty();
                    $('#<%=slselctaft.ClientID %>').append('<option value=0>' + '--Pilih Jadwal--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=slselctaft.ClientID %>').append('<option value="' + this.idshift2 + '">' + this.tanggalshift2 + "  (" + this.jadwal2 + ")" + '</option>');
                    });
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
            });
            $('#<%=sljadwalbef.ClientID %>').change(function () {
                var id = $(this).val();
                $('#<%= txtid1.ClientID%>').val(id);
            });

             $('#<%=slselctaft.ClientID %>').change(function () {
                var id = $(this).val();
                $('#<%= txtid2.ClientID%>').val(id);
            });
            $(function () {
                $('#slsatelit').change(function () {
                    var selectedValues = $(this).val();
                    $('#<%=txtsatelit.ClientID %>').val(selectedValues);
                });
                 $("#example2").DataTable({
                      "paging": true,
                      "searching": true,
                      "ordering": false,
                      "info": true,
                      "autoWidth": true,
                      "scrollX": true
                      });
                       $('.dataTables_length').addClass('bs-select');
            });

            function confirmdelete(deleteurl) {
                swal({
                    title: 'Apakah Anda Yakin ?',
                    text: 'Data yang dihapus tidak akan kembali lagi',
                    buttons: true,
                    dangerMode: true,

                }).then((willDelete)=>{
                    if (willDelete) {
                        document.location = deleteurl;
                    }
                });
            }

            $('.select2').select2()
        </script>
    </form>
</body>
</html>