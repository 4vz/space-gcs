<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="asset1.aspx.cs" Inherits="Telkomsat.asset.asset1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="./assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="./assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="./assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="./assets/css/style.min.css" rel="stylesheet" />
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css" rel="stylesheet" />
    <link href="stylepagination.css" rel="stylesheet" />
    <link href="logbook/log.css" rel="stylesheet" type="text/css"/>
    <script src="~/assets/plugins/jQuery/jquery-2.2.3.min.js"></script>

</head>
<body class="skin-blue sidebar-mini" style="height:auto; min-height:100%">
<form id="form12" runat="server">
<div class="wrapper">
<header class="main-header">
    
    <!-- Logo -->
    <a href="../dashboard.aspx" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>T</b>SA</span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>Telkom </b>Satellite</span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </a>

    <div class="collapse navbar-collapse pull-left" id="navbar-collapse">
        <ul class="nav navbar-nav">
            <li><a href="../home.aspx"><b>Home </b></a> </li>
            <li><a href="../asset/tambah.aspx"><b>Input Database </b></a></li>
            <li><a href="../asset/searchby.aspx"><b>Search by </b></a></li>
        </ul>
    </div>

      <div class="navbar-custom-menu">
        
        <ul class="nav navbar-nav">
            
          <!-- Messages: style can be found in dropdown.less-->
          <!-- User Account: style can be found in dropdown.less -->
          <li class="dropdown user user-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <asp:Label ID="lblProfile" runat="server" Text="Label" CssClass="hidden-xs"></asp:Label>
            </a>
            <ul class="dropdown-menu">
              <!-- User image -->
              <li class="user-header">
    <asp:DataList runat="server" id="DataList1" Width="100%"> 
        <ItemTemplate>
                <div class="widget-user-image">
                    <asp:Image ID="Image5" alt="User Avatar" runat="server" class="img-circle" Width="55px" Height="55px" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("foto")) %>'/>
                </div>
        </ItemTemplate>

    </asp:DataList>

                <p><a href="../asset/home.aspx">
                  Admin- Telkom Satellite
                  <small>2019</small>
                    </a>
                </p>
              </li>
              <!-- Menu Body -->
              
              <!-- Menu Footer-->
              <li class="user-footer">
                <div class="pull-right">
                    <button onclick="signout()" value="signout" class="btn btn-default"> Sign Out </button>
                  
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
    </nav>
    
  </header>

<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar" style="height:auto">
      <!-- Sidebar user panel -->
      <div class="user-panel"> 
        <div class="pull-left image">
          <asp:DataList runat="server" id="dtContact1" Width="100%">
        
        
        <ItemTemplate>
                <div class="widget-user-image">
                    <asp:Image ID="Image5" alt="User Avatar" runat="server" Width="45px" Height="45px" class="img-circle" ImageUrl='<%# Eval("foto")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("foto")) %>'/>
                </div>
        </ItemTemplate>

    </asp:DataList>
        </div>
        <div class="pull-left info">
            <asp:Label ID="lblProfile1" runat="server" Text="Label"></asp:Label>
          <a href="#"></a>
        </div>
      </div>
      <!-- search form -->
      <ul class="sidebar-menu">
        <li class="treeview"><a href="../asset/semuaasset.aspx">
            <i class="fa fa-database"></i><span><b>All Data</b></span></a></li>
      </ul>
      
      <!-- /.search form -->
      <!-- sidebar menu: : style can be found in sidebar.less -->
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">FILTER</li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-cubes"></i> <span>Jenis Equipment</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> RF Equipment
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=UP-CONVERTER"><i class="fa fa-circle-o"></i> Up Converter</a></li>
                  <li><a href="../asset/filter.aspx?ID=DOWN-CONVERTER"><i class="fa fa-circle-o"></i> Down Converter</a></li>
                  <li><a href="../asset/filter.aspx?ID=RF-MATRIX-SWITCH" title="rfmatrix"><i class="fa fa-circle-o"></i> RF Matrix</a></li>
                  <li><a href="../asset/filter.aspx?ID=IF-MATRIX-SWITCH"><i class="fa fa-circle-o"></i> IF Matrix</a></li>
                  <li><a href="../asset/filter.aspx?ID=HPA"><i class="fa fa-circle-o"></i> HPA</a></li>
                  <li><a href="../asset/filter.aspx?ID=LNA"><i class="fa fa-circle-o"></i> LNA</a></li>
                  <li><a href="../asset/filter.aspx?ID=(RCU)-HPA"><i class="fa fa-circle-o"></i> RCU HPA</a></li>
                  <li><a href="../asset/filter.aspx?ID=LNA-REDUNDANT-SWITCH"><i class="fa fa-circle-o"></i> LNA RSC</a></li>
                  <li><a href="../asset/filter.aspx?ID=(RCU)-TX"><i class="fa fa-circle-o"></i> RCU Up Converter</a></li>
                  <li><a href="../asset/filter.aspx?ID=(RCU)-RX"><i class="fa fa-circle-o"></i> RCU Down Converter</a></li>
              </ul>
            </li>

            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Baseband
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=GPS-ANTENA"><i class="fa fa-circle-o"></i> GPS Antena</a></li>
                  <li><a href="../asset/filter.aspx?ID=GPS-TIME-SERVER"><i class="fa fa-circle-o"></i> GPS Time Server</a></li>
                  <li><a href="../asset/filter.aspx?ID=BASEBAND"><i class="fa fa-circle-o"></i> Baseband</a></li>
                  <li><a href="../asset/filter.aspx?ID=IF-MODEM"><i class="fa fa-circle-o"></i> If Modem</a></li>
              </ul>
            </li>
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Server & NE
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=VM-HARDWARE"><i class="fa fa-circle-o"></i> VM Hardware</a></li>
                  <li><a href="../asset/filter.aspx?ID=NAS-HARDWARE"><i class="fa fa-circle-o"></i> NAS Hardware</a></li>
                  <li><a href="../asset/filter.aspx?ID=FEP-HARDWARE"><i class="fa fa-circle-o"></i> FEP Hardware</a></li>
                  <li><a href="../asset/filter.aspx?ID=ETHERNET-HUB"><i class="fa fa-circle-o"></i> Ethernet HUB</a></li>
                  <li><a href="../asset/filter.aspx?ID=ETHERNET-SWITCH"><i class="fa fa-circle-o"></i> Ethernet Switch</a></li>
                  <li><a href="../asset/filter.aspx?ID=FIREWALL"><i class="fa fa-circle-o"></i> Firewall</a></li>
                  <li><a href="../asset/filter.aspx?ID=ROUTER"><i class="fa fa-circle-o"></i> Router</a></li>
                  <li><a href="../asset/filter.aspx?ID=KVM"><i class="fa fa-circle-o"></i> KVM</a></li>
                  <li><a href="../asset/filter.aspx?ID=COMPASS-SERVER"><i class="fa fa-circle-o"></i> Compass Server</a></li>
                  <li><a href="../asset/filter.aspx?ID=DEVICE-MASTER"><i class="fa fa-circle-o"></i> Device Master</a></li>
                  <li><a href="../asset/filter.aspx?ID=ADAM-UNIT"><i class="fa fa-circle-o"></i> Adam Unit</a></li>
                  <li><a href="../asset/filter.aspx?ID=NETWORK-SERIAL"><i class="fa fa-circle-o"></i> Network Serial Adapter</a></li>
                  <li><a href="../asset/filter.aspx?ID=WEB-RELAY"><i class="fa fa-circle-o"></i> WEB I/O Relay</a></li>
                  <li><a href="../asset/filter.aspx?ID=SEACAMS-SERVER"><i class="fa fa-circle-o"></i> Saecams Server</a></li>
                  <li><a href="../asset/filter.aspx?ID=ID-SERVER"><i class="fa fa-circle-o"></i> Sat ID Server</a></li>
              </ul>
            </li>
                
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Antena
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=DEHYDRATOR"><i class="fa fa-circle-o"></i> Dehydrator</a></li>
                  <li><a href="../asset/filter.aspx?ID=ANTENNA"><i class="fa fa-circle-o"></i> Antena</a></li>
                  <li><a href="../asset/filter.aspx?ID=RF-TO-OPTIC"><i class="fa fa-circle-o"></i> RF to Optic Converter</a></li>
                  <li><a href="../asset/filter.aspx?ID=ACU"><i class="fa fa-circle-o"></i> Acu</a></li>
                  <li><a href="../asset/filter.aspx?ID=MOTOR"><i class="fa fa-circle-o"></i> Motor</a></li>
                  <li><a href="../asset/filter.aspx?ID=REMOTE-CONTROL"><i class="fa fa-circle-o"></i> Remote Control Unit</a></li>
                  <li><a href="../asset/filter.aspx?ID=DIGITAL-TRACKING"><i class="fa fa-circle-o"></i> Digital Tracking Receiver</a></li>
                  <li><a href="../asset/filter.aspx?ID=MONOPULSE"><i class="fa fa-circle-o"></i> Monopulse TR</a></li>
                  <li><a href="../asset/filter.aspx?ID=DUAL-CHANNEL"><i class="fa fa-circle-o"></i> Dual Channel DC</a></li>
                  <li><a href="../asset/filter.aspx?ID=SERVO-DRIVES"><i class="fa fa-circle-o"></i> Servo Drives</a></li>
                  <li><a href="../asset/filter.aspx?ID=SNOW-SENSOR"><i class="fa fa-circle-o"></i> Rain/Snow Sensor</a></li>
                  <li><a href="../asset/filter.aspx?ID=OPTICAL-ENCODER"><i class="fa fa-circle-o"></i> Optical Encoder</a></li>
                  <li><a href="../asset/filter.aspx?ID=(ACB)"><i class="fa fa-circle-o"></i> Antena Control Board</a></li>
                  <li><a href="../asset/filter.aspx?ID=(BDC)"><i class="fa fa-circle-o"></i> Block Down Control</a></li>
                  <li><a href="../asset/filter.aspx?ID=PHASE-SHIFTER"><i class="fa fa-circle-o"></i> Phase Shifter</a></li>
              </ul>
            </li>
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Alat Ukur
              <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=CIMMUNICATION"><i class="fa fa-circle-o"></i> Communication Analyzer</a></li>
                  <li><a href="../asset/filter.aspx?ID=SPEKTRUM"><i class="fa fa-circle-o"></i> Spektrum Analyzer</a></li>
                  <li><a href="../asset/filter.aspx?ID=SYNTHESIZER"><i class="fa fa-circle-o"></i> Synthesizer Sweeper</a></li>
                  <li><a href="../asset/filter.aspx?ID=POWER-METER"><i class="fa fa-circle-o"></i> Power Meter</a></li>
              </ul>
            </li>
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Workstation
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=WORKSTATION-OPERASIONAL"><i class="fa fa-circle-o"></i> WS Operasional</a></li>
                  <li><a href="../asset/filter.aspx?ID=ENGINEERING"><i class="fa fa-circle-o"></i> WS Engineering</a></li>
                  <li><a href="../asset/filter.aspx?ID=FLIGHT-DYNAMICS"><i class="fa fa-circle-o"></i> WS Flight Dynamics</a></li>
              </ul>
            </li>
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> License
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=EPOCH-CLIENT"><i class="fa fa-circle-o"></i> Epoch Client Licenses</a></li>
                  <li><a href="../asset/filter.aspx?ID=EPOCH-SERVER"><i class="fa fa-circle-o"></i> Epoch Server Licenses</a></li>
                  <li><a href="../asset/filter.aspx?ID=ARES"><i class="fa fa-circle-o"></i> Ares Licenses</a></li>
              </ul>
            </li>
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Electrical
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=CUBICLE"><i class="fa fa-circle-o"></i> Cubicle</a></li>
                  <li><a href="../asset/filter.aspx?ID=TRAFO"><i class="fa fa-circle-o"></i> Trafo</a></li>
                  <li><a href="../asset/filter.aspx?ID=MDP"><i class="fa fa-circle-o"></i> Main Distribution</a></li>
                  <li><a href="../asset/filter.aspx?ID=ATS"><i class="fa fa-circle-o"></i> ATS</a></li>
                  <li><a href="../asset/filter.aspx?ID=FEEDER"><i class="fa fa-circle-o"></i> Feeder</a></li>
                  <li><a href="../asset/filter.aspx?ID=AIR-COMPRESSOR"><i class="fa fa-circle-o"></i> Air Compressor</a></li>
                  <li><a href="../asset/filter.aspx?ID=ESSENSIAL-PANEL"><i class="fa fa-circle-o"></i> Essensial Panel</a></li>
              </ul>
            </li>

              <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Genset
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=625-KVA"><i class="fa fa-circle-o"></i> Genset 625 KVA</a></li>
                  <li><a href="../asset/filter.aspx?ID=1500-KVA"><i class="fa fa-circle-o"></i> Genset 1500 KVA</a></li>
                  <li><a href="../asset/filter.aspx?ID=BBM-TANK"><i class="fa fa-circle-o"></i> BBM Tank</a></li>
                  <li><a href="../asset/filter.aspx?ID=DAILY-TANK"><i class="fa fa-circle-o"></i> Daily Tank</a></li>
              </ul>
            </li>
              <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> UPS
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=310-KVA"><i class="fa fa-circle-o"></i> UPS 310 KVA</a></li>
                  <li><a href="../asset/filter.aspx?ID=330-KVA"><i class="fa fa-circle-o"></i> UPS 330 KVA</a></li>
                  <li><a href="../asset/filter.aspx?ID=3.1-KVA"><i class="fa fa-circle-o"></i> UPS 3.1 KVA</a></li>
                  <li><a href="../asset/filter.aspx?ID=5-KVA"><i class="fa fa-circle-o"></i> UPS 5 KVA</a></li>
                  <li><a href="../asset/filter.aspx?ID=10-KVA"><i class="fa fa-circle-o"></i> UPS 10 KVA</a></li>
                  <li><a href="../asset/filter.aspx?ID=BATTERY-UPS"><i class="fa fa-circle-o"></i> Battery UPS</a></li>
                  <li><a href="../asset/filter.aspx?ID=APOTRANS"><i class="fa fa-circle-o"></i> Apotrans</a></li>
              </ul>
            </li>
              <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Air Conditioning
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=AC-CHILLER"><i class="fa fa-circle-o"></i> AC Chiller</a></li>
                  <li><a href="../asset/filter.aspx?ID=AHU"><i class="fa fa-circle-o"></i> AHU</a></li>
                  <li><a href="../asset/filter.aspx?ID=FAN-COIL"><i class="fa fa-circle-o"></i> Fan Coil</a></li>
                  <li><a href="../asset/filter.aspx?ID=AC-PRECISION"><i class="fa fa-circle-o"></i> AC Precision</a></li>
                  <li><a href="../asset/filter.aspx?ID=AC-STANDING-FLOOR"><i class="fa fa-circle-o"></i> AC Standing Floor</a></li>
                  <li><a href="../asset/filter.aspx?ID=AC-PORTABLE"><i class="fa fa-circle-o"></i> AC Portable</a></li>
                  <li><a href="../asset/filter.aspx?ID=AC-SPLIT"><i class="fa fa-circle-o"></i> AC Split</a></li>
                  <li><a href="../asset/filter.aspx?ID=COMPRESSOR"><i class="fa fa-circle-o"></i> Compressor</a></li>
                  <li><a href="../asset/filter.aspx?ID=AC-PACKAGE"><i class="fa fa-circle-o"></i> AC Package</a></li>
              </ul>
            </li>
              <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Hydrant
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=DIESEL-ENGINE"><i class="fa fa-circle-o"></i> Diesel Engine</a></li>
                  <li><a href="../asset/filter.aspx?ID=PILLAR-HYDRANT"><i class="fa fa-circle-o"></i> Pillar Hydrant</a></li>
                  <li><a href="../asset/filter.aspx?ID=WATER-TANK"><i class="fa fa-circle-o"></i> Water Tank</a></li>
              </ul>
            </li>
              <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Fire Alarm Protection
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="../asset/filter.aspx?ID=HSSD"><i class="fa fa-circle-o"></i> HSSD</a></li>
                  <li><a href="../asset/filter.aspx?ID=FM200"><i class="fa fa-circle-o"></i> FM 200</a></li>
              </ul>
            </li>
          </ul>
        </li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-globe"></i>
            <span>Lokasi</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="../asset/filter.aspx?ID=CBI"><i class="fa fa-circle-o"></i> Cibinong</a></li>
            <li><a href="../asset/filter.aspx?ID=BJR"><i class="fa fa-circle-o"></i> Banjarmasin</a></li>
            <li><a href="../asset/filter.aspx?ID=MDN"><i class="fa fa-circle-o"></i> Medan</a></li>
            <li><a href="../asset/filter.aspx?ID=MDO"><i class="fa fa-circle-o"></i> Manado</a></li>
            <li class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Gudang Cibinong
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                    <li><a href="../asset/filter.aspx?ID=SR1"><i class="fa fa-circle-o"></i> Storageroom 1</a></li>
                    <li><a href="../asset/filter.aspx?ID=SR2"><i class="fa fa-circle-o"></i> Storageroom 2</a></li>
                    <li><a href="../asset/filter.aspx?ID=SR3"><i class="fa fa-circle-o"></i> Storageroom 3</a></li>
                    <li><a href="../asset/filter.aspx?ID=SR4"><i class="fa fa-circle-o"></i> Storageroom 4</a></li>
                    <li><a href="../asset/filter.aspx?ID=WRD3"><i class="fa fa-circle-o"></i> Workshop D3</a></li>
                    <li><a href="../asset/filter.aspx?ID=WRGCS"><i class="fa fa-circle-o"></i> Workshop GCS</a></li>
                    <li><a href="../asset/filter.aspx?ID=SRC"><i class="fa fa-circle-o"></i> Storageroom Container</a></li>
                    <li><a href="../asset/filter.aspx?ID=SRA"><i class="fa fa-circle-o"></i> Storageroom Antena</a></li>
              </ul>
            </li>
            <li  class="treeview"><a href="#"><i class="fa fa-circle-o"></i> Gudang Banjarmasin
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                  <li><a href="#"><i class="fa fa-circle-o"></i> Gudang Atas</a></li>
                  <li><a href="#"><i class="fa fa-circle-o"></i> Gudang Bawah</a></li>
              </ul>
            </li>
          </ul>
        </li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-check"></i>
            <span>Status</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="../asset/filter.aspx?ID=baik"><i class="fa fa-circle-o"></i> Baik</a></li>
            <li><a href="../asset/filter.aspx?ID=Perbaikan"><i class="fa fa-circle-o"></i> Kurang Baik</a></li>
            <li><a href="../asset/filter.aspx?ID=rusak"><i class="fa fa-circle-o"></i> Rusak</a></li>
          </ul>
        </li>
        <li class="treeview">
          <a href="../asset/filter.aspx?ID=TELKOM-2">
            <i class="fa fa-space-shuttle"></i> <span>Kelompok Satelit</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="../asset/filter.aspx?ID=TELKOM-2"><i class="fa fa-circle-o"></i> Telkom 2</a></li>
            <li><a href="../asset/filter.aspx?ID=TELKOM-3S"><i class="fa fa-circle-o"></i> Telkom 3S</a></li>
            <li><a href="../asset/filter.aspx?ID=MPSAT"><i class="fa fa-circle-o"></i> Telkom 4</a></li>
          </ul>
        </li>
        </ul>
        <ul class="sidebar-menu">
        <li class="header">RESEARCH</li>     
          <li class="treeview">
          <a href="../asset/chart.aspx">
            <i class="fa fa-space-shuttle"></i> <span>Chart</span>
          </a>
        </li>
        </ul>
    </section>
    <!-- /.sidebar -->
    
  </aside>
    
        <div class="content-wrapper">
            <section class="content">
            <div class="waktu">
                <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                
            </div>
                
            <div style="text-align: left" class="datakita">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
        </div>
        <div class="input-group">
          <span class="headlb">Database Asset</span>
          <input type="text" name="q" class="form-control" placeholder="Search..." runat="server" id="inputsearch"/>
          <span class="input-group-btn">
                <button type="submit" name="search" class="btn btn-flat" runat="server" onserverclick="btnSearch_Click"><i class="fa fa-search"></i>
                </button>
              </span>
            
        </div>     

        
        <br />
        <asp:Label ID="lblCount" runat="server" Text="Label" CssClass="count1"></asp:Label>
        <asp:Button ID="btnExpand" runat="server" Text="Expand" OnClick="Expand_OnClick" class="cssexpand"/>
        <select class="ddl" id="urutkan" onChange="myNewFunction(this);" runat="server">
            <option >-Urutkan-</option>
            <option value="KELOMPOK">Kelompok</option>
            <option value="NAMA">Nama</option>
            <option value="MERK">Merk</option>
            <option value="SITE">Lokasi</option>
            <option value="FUNGSI">Fungsi</option>
            <option value="STATUS">Status</option>
        </select>
        <asp:Button ID="btnurut" runat="server" Text="Button" OnClick="btnurut_click" CssClass="urut"/>
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False" style="margin:0 auto;" Font-Size="13px" BackColor="White" CssClass="gview" EnableViewState="false"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" AllowPaging="true" PageSize="30" OnPageIndexChanging="OnPaging" OnPreRender="gvContact_PreRender">
            <Columns>
                <asp:BoundField DataField ="KELOMPOK" HeaderText ="KELOMPOK" ItemStyle-Width="140px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="NAMA" HeaderText ="NAMA" ItemStyle-Width="160px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="MERK" HeaderText ="MERK" ItemStyle-Width="170px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="MODEL" HeaderText ="MODEL" ItemStyle-Width="90px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="S/N" HeaderText ="S/N" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="P/N" HeaderText ="P/N" ItemStyle-Width="120px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="SITE" HeaderText ="LOKASI" ItemStyle-Width="70px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="GUDANG" HeaderText ="RUANGAN" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="RAK" HeaderText ="RAK" ItemStyle-Width="50px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="TELKOM2" HeaderText ="TK2" ItemStyle-Width="50px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="TELKOM3S" HeaderText ="TK3S" ItemStyle-Width="50px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="MPSAT" HeaderText ="MPSAT" ItemStyle-Width="70px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="FUNGSI" HeaderText ="FUNGSI" ItemStyle-Width="110px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="STATUS" HeaderText ="STATUS" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID_Asset") %>' OnClick ="Ink_OnClick1">View</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Yellow" ForeColor="Yellow" BorderStyle="Double" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#fafafa"/>
            <PagerStyle BackColor="White" CssClass="pagination-ys" HorizontalAlign="Right" Height="70px" VerticalAlign="Middle" 
                 BorderColor="White" BorderStyle="None" BorderWidth="0" />
            <PagerSettings Mode="Numeric" PageButtonCount="4" FirstPageText="1" />
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <asp:Label ID="lblPage" runat="server" Text="Label" CssClass="halaman"></asp:Label>
    </div>
    <script type="text/javascript">
        function myNewFunction(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput == "KELOMPOK" || userinput == "NAMA" || userinput == "MERK" || userinput == "SITE"
                || userinput == "FUNGSI" || userinput == "STATUS")
            {
                document.getElementById('<%=btnurut.ClientID%>').click();
            }
        }
    </script>
            </section>
        </div>
    </div>
    <div class="control-sidebar-bg"></div>

    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="JavaScript.js" type="text/javascript"></script>
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
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

        function btnsubmit() {
            var inputdata = document.getElementById("inp").value;
            var mylink = "../home.aspx?tahun=" + inputdata;
            //alert(mylink);
            window.location.href = mylink;
            window.open(mylink);
        }
        function signout() {
            //sessionStorage.removeItem("user");
            var mylink = "../login.aspx?out";
            //alert(mylink);
            window.location.href = mylink;
        }

</script>
</form>
</body>
</html>

