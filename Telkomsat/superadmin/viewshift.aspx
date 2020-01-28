<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewshift.aspx.cs" Inherits="Telkomsat.superadmin.viewshift" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            <div class="content-wrapper" style="height:auto;">
            <div class="container">
                <section class="content-header">
                    <h1>
                        <img src="../img/logotelkomsat2.png" height="50" alt="Alternate Text" />
                    </h1>
                    <span class="breadcrumb" style="font-size:16px">GCS</span>
        
                </section>

                <!-- Main content -->
                <div class="content">
                        <section class="col-lg-6 connectedSortable" style="min-height:50px">
                            <div class="col-lg-4 col-xs-6" style="padding-left:0; padding-bottom:15px; padding-right:15px">
                                    <asp:DropDownList ID="ddlBulan" runat="server" Width="100%">
                                        <asp:ListItem>-Pilih Bulan-</asp:ListItem>
                                        <asp:ListItem Value="01">Januari</asp:ListItem>
                                        <asp:ListItem Value="02">Februari</asp:ListItem>
                                        <asp:ListItem Value="03">Maret</asp:ListItem>
                                        <asp:ListItem Value="04">April</asp:ListItem>
                                        <asp:ListItem Value="05">Mei</asp:ListItem>
                                        <asp:ListItem Value="06">Juni</asp:ListItem>
                                        <asp:ListItem Value="07">Juli</asp:ListItem>
                                        <asp:ListItem Value="08">Agustus</asp:ListItem>
                                        <asp:ListItem Value="09">September</asp:ListItem>
                                        <asp:ListItem Value="10">Oktober</asp:ListItem>
                                        <asp:ListItem Value="11">November</asp:ListItem>
                                        <asp:ListItem Value="12">Desember</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                 <div class="col-lg-4 col-xs-6" style="padding-bottom:15px;">
                                    <asp:Button ID="Button1" runat="server" Text="Pilih" OnClick="pilih_Click" CssClass="btn btn-success btn-xs" Width="100%"/>
                                </div>
                            </section>
                    <a class="breadcrumb" href="shiftme.aspx">Edit</a>
                        <div class="col-md-12">
                            <div runat="server" id="divdata" visible="false">
                                <asp:GridView ID="gvContact" runat="server" BackColor="White"
                                      BorderColor="#3366CC" BorderStyle="None"  OnRowDataBound="gvContact_RowDataBound"
                                      BorderWidth="1px" CellPadding="4"
                                      style="text-align: left; margin-left: 0px" Width="100%">

                                      <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                      <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="White" />
                                      <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                      <RowStyle BackColor="White" ForeColor="#003399" />
                                      <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                      <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                      <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                      <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                      <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                    <br />
                                    <asp:LinkButton ID="lbnextT3s" runat="server" OnClick="lbnextt3s_Click">next</asp:LinkButton>
                                    <asp:LinkButton ID="lbprevT3s" runat="server" OnClick="pilih_Click" Visible="false">prev</asp:LinkButton>
                                </div>
                                </div>
                        </div>
                    </div>
                </div>
                </div>
                </div>
            </div>

    </form>
</body>
</html>
