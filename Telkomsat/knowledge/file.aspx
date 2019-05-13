<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="file.aspx.cs" Inherits="Telkomsat.knowledge.file" %>

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
    <link href="../Style2.css" rel="stylesheet" />
    <link href="../Style1.css" rel="stylesheet" />
    <link href="../StyleLogBook.css" rel="stylesheet" />
    <link href="../stylepagination.css" rel="stylesheet" />
    <link href="../logbook/log.css" rel="stylesheet" type="text/css"/>
    <link href="knowledge.css" rel="stylesheet" />
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
</head>
<body>
   <div class="wrapper">
    <aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar" style="height:auto">

      <!-- search form -->
      <ul class="sidebar-menu">
        <li class="treeview"><a href="../logbook/datalogbook.aspx">
            <i class="fa fa-file-text-o"></i><span><b>Data Logbook</b></span></a>
        </li>
          <li class="treeview"><a href="../logbook/datalogbook.aspx">
            <i class="fa fa-file-text-o"></i><span><b>IP Password</b></span></a>
        </li>
      </ul>
      
      <!-- /.search form -->
      <!-- sidebar menu: : style can be found in sidebar.less -->
    <form action="search.aspx" method="post">
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">FILTER</li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-calendar"></i> <span>Buku Manual</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> CBI
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=10-12-2019"><i class="fa fa-circle-o"></i> RF EQUIPMENT</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-11-2019"><i class="fa fa-circle-o"></i> BASEBAND</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-10-2019"><i class="fa fa-circle-o"></i> SERVER & NE</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-09-2019"><i class="fa fa-circle-o"></i> ANTENA</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-08-2019"><i class="fa fa-circle-o"></i> ALAT UKUR</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-07-2019"><i class="fa fa-circle-o"></i> WORKSTATION</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-06-2019"><i class="fa fa-circle-o"></i> LICENSE</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-05-2019"><i class="fa fa-circle-o"></i> MECHANIC ELECTRICAL</a></li>
              </ul>
            </li>

            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> BJM
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=10-12-2019"><i class="fa fa-circle-o"></i> RF EQUIPMENT</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-11-2019"><i class="fa fa-circle-o"></i> BASEBAND</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-10-2019"><i class="fa fa-circle-o"></i> SERVER & NE</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-09-2019"><i class="fa fa-circle-o"></i> ANTENA</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-08-2019"><i class="fa fa-circle-o"></i> ALAT UKUR</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-07-2019"><i class="fa fa-circle-o"></i> WORKSTATION</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-06-2019"><i class="fa fa-circle-o"></i> LICENSE</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-05-2019"><i class="fa fa-circle-o"></i> MECHANIC ELECTRICAL</a></li>
              </ul>
            </li>

            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> MDO
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=10-12-2019"><i class="fa fa-circle-o"></i> RF EQUIPMENT</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-11-2019"><i class="fa fa-circle-o"></i> BASEBAND</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-10-2019"><i class="fa fa-circle-o"></i> SERVER & NE</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-09-2019"><i class="fa fa-circle-o"></i> ANTENA</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-08-2019"><i class="fa fa-circle-o"></i> ALAT UKUR</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-07-2019"><i class="fa fa-circle-o"></i> WORKSTATION</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-06-2019"><i class="fa fa-circle-o"></i> LICENSE</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-05-2019"><i class="fa fa-circle-o"></i> MECHANIC ELECTRICAL</a></li>
              </ul>
            </li>
        </ul>
        </li>

          <li class="treeview">
          <a href="#">
            <i class="fa fa-clipboard"></i>
            <span>SOP</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
              <li><a href="../logbook1/filter.aspx?ID=12-Perbaikan"><i class="fa fa-circle-o"></i> TELKOM 2</a></li>
              <li><a href="../logbook1/filter.aspx?ID=12-Perawatan"><i class="fa fa-circle-o"></i> TELKOM 3S</a></li>
              <li><a href="../logbook1/filter.aspx?ID=12-Pointing+Antena"><i class="fa fa-circle-o"></i> MPSAT</a></li>
              <li><a href="../logbook1/filter.aspx?ID=12-Penggantian"><i class="fa fa-circle-o"></i> LAIN-LAIN</a></li>
          </ul>
        </li>


        <li class="treeview">
          <a href="#">
            <i class="fa fa-tag"></i>
            <span>Pelatihan</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
              <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> SATELIT
                  <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=12-Perbaikan"><i class="fa fa-circle-o"></i> TELKOM 2</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Perawatan"><i class="fa fa-circle-o"></i> TELKOM 3S</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Pointing+Antena"><i class="fa fa-circle-o"></i> MPSAT</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Penggantian"><i class="fa fa-circle-o"></i> LAIN-LAIN</a></li>
              </ul>
              </li>
              <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> GROUND
                  <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=12-Perbaikan"><i class="fa fa-circle-o"></i> TELKOM 2</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Perawatan"><i class="fa fa-circle-o"></i> TELKOM 3S</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Pointing+Antena"><i class="fa fa-circle-o"></i> MPSAT</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Penggantian"><i class="fa fa-circle-o"></i> LAIN-LAIN</a></li>
              </ul>
              </li>
              
          </ul>
        </li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-calendar"></i> <span>Konfigurasi Pembaruan</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> OPERASIONAL
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=12-Perbaikan"><i class="fa fa-circle-o"></i> TELKOM 2</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Perawatan"><i class="fa fa-circle-o"></i> TELKOM 3S</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Pointing+Antena"><i class="fa fa-circle-o"></i> MPSAT</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=12-Penggantian"><i class="fa fa-circle-o"></i> LAIN-LAIN</a></li>
              </ul>
            </li>

            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> NETWORK
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=10-12-2019"><i class="fa fa-circle-o"></i> CBI</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-11-2019"><i class="fa fa-circle-o"></i> BJM</a></li>
              </ul>
            </li>

            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> RF
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../logbook1/filter.aspx?ID=10-12-2019"><i class="fa fa-circle-o"></i> CBI</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-11-2019"><i class="fa fa-circle-o"></i> BJM</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-10-2019"><i class="fa fa-circle-o"></i> MDN</a></li>
                  <li><a href="../logbook1/filter.aspx?ID=10-09-2019"><i class="fa fa-circle-o"></i> MDO</a></li>
              </ul>
            </li>
        </ul>
        </li>
        
             
      </ul>
    </form>
    </section>
    <!-- /.sidebar -->
    
  </aside>

<header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard.aspx">
          <img src="../img/logotelkomsat2.png" alt="Alternate Text" height="50"/></a>
          <input type="text" name="q" class="form-control" placeholder="Search..." runat="server" id="Text1" style="vertical-align:middle"/>
          <span class="input-group-btn">
                <button type="submit" name="search" class="btn btn-flat" runat="server" onserverclick="btnSearch_Click"><i class="fa fa-search"></i>
                </button>
              </span>  
    </div>
    </div>
    </header>
    <div class="content-wrapper">
    <section class="content">
    <form id="form1" runat="server">
    
    <br />
        
    <div class="bodyLB2">

        <ul class="list-inline">
            <li style="margin-right:400px;">
                <asp:Button ID="Button1" runat="server" Text="Semua" CssClass="btn btn-adn" Width="80px"/>
            </li>
            <li>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl28" Width="120px">
                    <asp:ListItem>-Kategori-</asp:ListItem>
                    <asp:ListItem>Upload</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </li>
            <li style="margin-right:10px;">
                <button type="submit" class="btn-file" runat="server" onserverclick="btnTambah_Click"><i class="fa fa-plus" style="font-size:12px"></i> Tambah
                </button>
            </li>
        </ul>
        <br />

    <asp:HiddenField ID="hfContactID" runat="server" />
    
    <asp:DataList runat="server" Width="568px" OnItemCommand="DataList1_ItemCommand" ID="DataList1">
        <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB" CommandArgument='<%# Eval("ID") %>' CommandName="id"/>
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") + " - " %>' />
            <asp:Label ID="AKTIVITASLabel" runat="server" class="aktivitasLB" Text='<%# Eval("AKTIVITAS").ToString().Length > 200 ? 
                    Eval("AKTIVITAS").ToString().Substring(0,200)+"..." : Eval("AKTIVITAS")%>' />
            <br />
            <br />
        </ItemTemplate>

    </asp:DataList>
        <ul class="list-inline">
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lb1_Click" class="lbpaging" Text="<<"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lb2_Click" class="lbpaging" Text="prev"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lb3_Click" class="lbpaging" Text="next"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lb4_Click" class="lbpaging" Text=">>"></asp:LinkButton>
            </li>
        </ul>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KNOWLEDGEConnectionString2 %>" SelectCommand="SELECT * FROM [LOGBOOK]"></asp:SqlDataSource>
</form>
        </section>
        </div>


        </div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="JavaScript.js" type="text/javascript"></script>
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
</script>
</body>
</html>
