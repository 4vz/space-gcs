<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checklistme.aspx.cs" Inherits="Telkomsat.checklist.cheklistme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="../assets/css/style.min.css" rel="stylesheet" />
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
                <asp:ListItem>T3S C-Band</asp:ListItem>
                <asp:ListItem>T3S Ku-Band</asp:ListItem>
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

        <div runat="server" id="Div1">
            <section class="col-lg-12" style="min-height:40px">
            <div>
            <asp:GridView ID="gvPerangkat" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="gvPerangkat_RowEditing">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField ="NAMA" HeaderText ="NAMA" ItemStyle-Width="160px"  ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="160px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField ="MERK" HeaderText ="MERK" ItemStyle-Width="160px"  ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="160px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField ="MODEL" HeaderText ="MODEL" ItemStyle-Width="160px"  ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="160px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField ="S/N" HeaderText ="S/N" ItemStyle-Width="160px"  ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="160px"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
                <br />
            </div>
            </section>
        </div>

        <div runat="server" id="T3SHarkat" visible="false">
        <div class="row">
        <!-- Left col -->
        <div class="col-lg-6 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Up Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:50px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td style="width:15px; padding-left:10px; font-weight:bold">P</td>
                          <td style="width:15px; padding-left:10px; font-weight:bold">F</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="rbasc" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton1" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter terbaik</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton2" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton3" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox2" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton4" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton5" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox3" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton6" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton7" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox4" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label4" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                  </tbody>
              </table>
          </div>
          


        </div>

        <div class="col-lg-6 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Down Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:60px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                      </tr>
                      <tr>
                          <td style="width:20px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:20px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton8" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton9" runat="server" GroupName="rbsort" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton10" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton11" runat="server" GroupName="rbsort1" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton12" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton13" runat="server" GroupName="rbsort2" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton14" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton15" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                  </tbody>
              </table>
          </div>
        </div>

        <!-- right col -->
      </div>

    <div class="row">
        <!-- Left col -->
        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Up Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:50px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Nilai</td>
                      </tr>
                      <tr>
                          <td style="width:15px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:15px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton30" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton31" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox5" runat="server" Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton32" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton33" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox6" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton34" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton35" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox7" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton36" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton37" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox8" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                  </tbody>
              </table>
          </div>
          


        </div>

        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Down Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:60px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                      </tr>
                      <tr>
                          <td style="width:20px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:20px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton38" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton39" runat="server" GroupName="rbsort" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton40" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton41" runat="server" GroupName="rbsort1" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton42" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton43" runat="server" GroupName="rbsort2" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton44" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton45" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                  </tbody>
              </table>
          </div>
        </div>

        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Down Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:60px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                      </tr>
                      <tr>
                          <td style="width:20px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:20px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton46" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton47" runat="server" GroupName="rbsort" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton48" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton49" runat="server" GroupName="rbsort1" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton50" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton51" runat="server" GroupName="rbsort2" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton52" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton53" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton54" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton55" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa2</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton56" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton57" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa1</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton58" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton59" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                  </tbody>
              </table>
          </div>
        </div>
        <!-- right col -->
      </div>
      <div class="row">
        <!-- Left col -->
            <div class="col-lg-12 col-xs-12">
                <asp:Button ID="Button2" runat="server" Text="Save" Width="100%" CssClass="btn btn-primary" />

            </div>
        </div>
    </div>
        <div runat="server" id="T3SKUHarkat" visible="false">
           <div style="padding-bottom:10px">
        <asp:Button ID="Button4" runat="server" Text="check all" CssClass="btn btn-primary btn-xs" OnClientClick="return allclick()"/>
            </div>
        <div class="row">
        <!-- Left col -->
        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> BAY A4</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:50px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td style="width:15px; padding-left:10px; font-weight:bold">P</td>
                          <td style="width:15px; padding-left:10px; font-weight:bold">F</td>
                      </tr>
                      <tr>
                          <td class="tabel"><b>Power Meter</b></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4po" runat="server" value="1"  id="rbt3ca4po1"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4po" runat="server" value="0" id="rbt3ca4po0"/></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4po" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="lblt3ca4po" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rbt3ca4post" runat="server" value="1" id="rbt3ca4post1"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4post" runat="server" value="0" id="rbt3ca4post0"/></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4post" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="lblt3ca4st" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel"><input type="radio" name="rbt3ca4polv" runat="server" value="1" id="rbt3ca4polv1"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4polv" runat="server" value="0" id="rbt3ca4polv0"/></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4polv" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="lblt3ca4lv" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel"><b>RF Calibration</b></td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RF1" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RF2" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4rf" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="lblt3ca4rf" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFlv1" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFlv0" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4rflv" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="lblt3ca4rflv" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Indepedance</td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFin1" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFin0" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4rfin" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label6" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Output</td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFou1" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFou0" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4rfou" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">BUS</td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFbu1" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="rbt3a4RFbu0" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:TextBox ID="txtt3ca4rfbu" runat="server"  Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label8" runat="server" Text="dbm"></asp:Label></td>
                      </tr>
                  </tbody>
              </table>
          </div>
          


        </div>

        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Down Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:60px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                      </tr>
                      <tr>
                          <td style="width:20px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:20px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">BAY A4</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton68" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton69" runat="server" GroupName="rbsort" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton70" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton71" runat="server" GroupName="rbsort1" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton72" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton73" runat="server" GroupName="rbsort2" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton74" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton75" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                  </tbody>
              </table>
          </div>
        </div>

        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Down Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:60px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                      </tr>
                      <tr>
                          <td style="width:20px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:20px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton76" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton77" runat="server" GroupName="rbsort" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton78" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton79" runat="server" GroupName="rbsort1" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton80" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton81" runat="server" GroupName="rbsort2" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton82" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton83" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton84" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton85" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa2</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton86" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton87" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa1</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton88" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton89" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                  </tbody>
              </table>
          </div>
        </div>
        <!-- right col -->
      </div>

    <div class="row">
        <!-- Left col -->
        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Up Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:50px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Nilai</td>
                      </tr>
                      <tr>
                          <td style="width:15px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:15px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton90" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton91" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox13" runat="server" Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton92" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton93" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox14" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton94" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton95" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox15" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton96" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton97" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox16" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                  </tbody>
              </table>
          </div>
          


        </div>

        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Down Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:60px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                      </tr>
                      <tr>
                          <td style="width:20px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:20px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton98" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton99" runat="server" GroupName="rbsort" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton100" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton101" runat="server" GroupName="rbsort1" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton102" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton103" runat="server" GroupName="rbsort2" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton104" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton105" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                  </tbody>
              </table>
          </div>
        </div>

        <div class="col-lg-4 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
          <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
              <li class="pull-left header"><i class="fa fa-inbox"></i> Down Converter</li>
            </ul>
              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td colspan="2" style="width:60px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                      </tr>
                      <tr>
                          <td style="width:20px; padding-left:10px; font-weight:bold">pass</td>
                          <td style="width:20px; padding-left:10px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel">upconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton106" runat="server" GroupName="rbsort" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton107" runat="server" GroupName="rbsort" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">downconverter</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton108" runat="server" GroupName="rbsort1" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton109" runat="server" GroupName="rbsort1" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton110" runat="server" GroupName="rbsort2" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton111" runat="server" GroupName="rbsort2" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton112" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton113" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">hpa</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton114" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton115" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa2</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton116" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton117" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                      <tr>
                          <td class="tabel">kpa1</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton118" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton119" runat="server" GroupName="rbsort3" /></td>
                      </tr>
                  </tbody>
              </table>
          </div>
        </div>
        <!-- right col -->
      </div>
      <div class="row">
        <!-- Left col -->
            <div class="col-lg-12 col-xs-12">
                <asp:Button ID="Button3" runat="server" Text="Save" Width="100%" CssClass="btn btn-primary" OnClick="Save_Click" />

            </div>
        </div>
    </div>

    
      </section>
    </div>
    </div>
        
   </div>
        
    </form>

    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <!--<script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>-->
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
   <script>
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

    <script type="text/javascript">
      function allclick(){
          // put your code here 
          document.getElementById("rbt3ca4po1").click();
          document.getElementById("rbt3ca4polv1").click();
          document.getElementById("rbt3ca4post1").click();
          return false;
      }
    </script>
</body>

</html>
