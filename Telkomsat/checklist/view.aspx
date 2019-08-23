<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Telkomsat.checklist.view" %>

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
        <section class="col-lg-12 connectedSortable" style="min-height:40px">
            <div class="col-lg-3 col-xs-6" style="padding-bottom:5px; ">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl" Width="100%">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Telkom 2</asp:ListItem>
                <asp:ListItem Value="LMA 11M">T3S Ku-Band</asp:ListItem>
            </asp:DropDownList>
                </div>
             <div class="col-lg-3 col-xs-6" style="padding-bottom:5px;">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="ddl" Width="100%">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Harkat</asp:ListItem>
                <asp:ListItem>ME</asp:ListItem>
            </asp:DropDownList>
            </div>
            <div class="col-lg-3 col-xs-6" style="padding-bottom:5px;">
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="ddl" Width="100%">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Januari</asp:ListItem>
                <asp:ListItem>Februari</asp:ListItem>
                <asp:ListItem>Maret</asp:ListItem>
                <asp:ListItem>April</asp:ListItem>
                <asp:ListItem>Mei</asp:ListItem>
                <asp:ListItem>Juni</asp:ListItem>
                <asp:ListItem>Juli</asp:ListItem>
                <asp:ListItem>Agustus</asp:ListItem>
                <asp:ListItem>September</asp:ListItem>
                <asp:ListItem>Oktober</asp:ListItem>
                <asp:ListItem>November</asp:ListItem>
                <asp:ListItem>Desember</asp:ListItem>
            </asp:DropDownList>
            </div>
            <div class="col-lg-3 col-xs-6" style="padding-bottom:5px;">
            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="ddl" Width="100%">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
            </asp:DropDownList>
            </div>
             
        </section>
            <section class="col-lg-12" style="min-height:40px">
                <div class="col-lg-4 col-xs-12" style="padding-bottom:10px; "></div>
            <div class="col-lg-4 col-xs-12" style="padding-bottom:10px; ">
            <asp:Button ID="Button1" runat="server" Text="Pilih" OnClick="pilih_Click" CssClass="btn btn-success btn-xs" Width="100%"/>
            </div>
                <div class="col-lg-4 col-xs-12" style="padding-bottom:10px; "></div>
            </section>
        </div>
        
        <div runat="server" id="data" visible="false">
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
        </form>
    </body>
</html>
