<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checklist.aspx.cs" Inherits="Telkomsat.checklist.checklist" %>

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
    <link href="../css/bs-stepper.css" rel="stylesheet"/>
    <link href="check.css?version=5" rel="stylesheet"/>
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
            <asp:DropDownList ID="DropDownList" runat="server" CssClass="ddl" Width="100%">
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
<div runat="server" id="T3SHarkat">


    <div class="row">
        <!-- Left col -->
        <div class="col-lg-12 col-xs-12">
          <!-- Custom tabs (Charts with tabs)-->
            <div id="bayA4" style="display:block">
          <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header ui-sortable-handle">

                <i class="fa fa-inbox"></i> <h3 class="box-title">BAY A4</h3>

            </div>
              <div class="box-body">
                  <div style="padding-bottom:100px;">
                  <ul class="progressbar">
                      <li class="select">Page 1</li>
                      <li>Page 2</li>
                      <li>Page 3</li>
                      <li>Page 4</li>
                      <li>Page 5</li>
                      <li>Page 6</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td colspan="2" style="width:50px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Nilai</td>
                      </tr>
                      <tr>
                          <td style="width:15px; padding-left:10px; max-width:40px; font-weight:bold">pass</td>
                          <td style="width:15px; padding-left:10px; max-width:40px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Power Meter</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" style="background-color:green; border:1px solid blue;" name="rbt3ca4post" runat="server" value="1" id="Radio1"/></td>
                          <td class="tabel"><input type="radio" style="background-color:red; border:1px solid green;" name="rbt3ca4post" runat="server" value="0" id="Radio2"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox5" runat="server" Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel"><input type="radio" name="rbt3ca4polv" runat="server" value="1" id="Radio3"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4polv" runat="server" value="0" id="Radio4"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox6" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>RF Calibration</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rbt3ca4rfst" runat="server" value="1" id="Radio5"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4rfst" runat="server" value="0" id="Radio6"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox1" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel"><input type="radio" name="rbt3ca4rflv" runat="server" value="1" id="Radio7"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4rflv" runat="server" value="0" id="Radio8"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox7" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Inpedance</td>
                          <td class="tabel"><input type="radio" name="rbt3ca4rfin" runat="server" value="1" id="Radio9"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca4rfin" runat="server" value="0" id="Radio10"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox8" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Output</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton3" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton4" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox2" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">BUS</td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton5" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:RadioButton ID="RadioButton6" runat="server" GroupName="rbsort3" /></td>
                          <td class="tabel"><asp:TextBox ID="TextBox3" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>U/C Output Switch</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rba4out" runat="server" value="1" id="Radio19"/></td>
                          <td class="tabel"><input type="radio" name="rba4out" runat="server" value="0" id="Radio20"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox19" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Up Converter 1</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rba4uc1st" runat="server" value="1" id="Radio21"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc1st" runat="server" value="0" id="Radio22"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox20" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel"><input type="radio" name="rba4uc1fr" runat="server" value="1" id="Radio23"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc1fr" runat="server" value="1" id="Radio24"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox21" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Modulation</td>
                          <td class="tabel"><input type="radio" name="rba4uc1mo" runat="server" value="1" id="Radio25"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc1mo" runat="server" value="1" id="Radio26"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox22" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Modulation Rate</td>
                          <td class="tabel"><input type="radio" name="rba4uc1mr" runat="server" value="1" id="Radio27"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc1mr" runat="server" value="1" id="Radio28"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox23" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Atenuation</td>
                          <td class="tabel"><input type="radio" name="rba4uc1at" runat="server" value="1" id="Radio29"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc1at" runat="server" value="1" id="Radio30"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox24" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Deviation</td>
                          <td class="tabel"><input type="radio" name="rba4uc1de" runat="server" value="1" id="Radio31"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc1de" runat="server" value="1" id="Radio32"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox25" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Up Converter 2</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rba4uc2st" runat="server" value="1" id="Radio33"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc2st" runat="server" value="0" id="Radio34"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox26" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel"><input type="radio" name="rba4uc2fr" runat="server" value="1" id="Radio35"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc2fr" runat="server" value="1" id="Radio36"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox27" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Modulation</td>
                          <td class="tabel"><input type="radio" name="rba4uc2mo" runat="server" value="1" id="Radio37"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc2mo" runat="server" value="1" id="Radio38"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox28" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Modulation Rate</td>
                          <td class="tabel"><input type="radio" name="rba4uc2mr" runat="server" value="1" id="Radio39"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc2mr" runat="server" value="1" id="Radio40"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox29" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Atenuation</td>
                          <td class="tabel"><input type="radio" name="rba4uc2at" runat="server" value="1" id="Radio41"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc2at" runat="server" value="1" id="Radio42"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox30" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Deviation</td>
                          <td class="tabel"><input type="radio" name="rba4uc2de" runat="server" value="1" id="Radio43"/></td>
                          <td class="tabel"><input type="radio" name="rba4uc2de" runat="server" value="1" id="Radio44"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox31" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 2</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rba4dc2st" runat="server" value="1" id="Radio45"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc2st" runat="server" value="0" id="Radio46"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox32" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel"><input type="radio" name="rba4dc2fr" runat="server" value="1" id="Radio47"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc2fr" runat="server" value="1" id="Radio48"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox33" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Atenuation</td>
                          <td class="tabel"><input type="radio" name="rba4dc2at" runat="server" value="1" id="Radio49"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc2at" runat="server" value="1" id="Radio50"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox34" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 3</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rba4dc3st" runat="server" value="1" id="Radio51"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc3st" runat="server" value="0" id="Radio52"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox35" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel"><input type="radio" name="rba4dc3fr" runat="server" value="1" id="Radio53"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc3fr" runat="server" value="1" id="Radio54"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox36" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Atenuation</td>
                          <td class="tabel"><input type="radio" name="rba4dc3at" runat="server" value="1" id="Radio55"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc3at" runat="server" value="1" id="Radio56"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox37" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 1</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rba4dc1st" runat="server" value="1" id="Radio57"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc1st" runat="server" value="0" id="Radio58"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox38" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel"><input type="radio" name="rba4dc1fr" runat="server" value="1" id="Radio59"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc1fr" runat="server" value="1" id="Radio60"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox39" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Atenuation</td>
                          <td class="tabel"><input type="radio" name="rba4dc1at" runat="server" value="1" id="Radio61"/></td>
                          <td class="tabel"><input type="radio" name="rba4dc1at" runat="server" value="1" id="Radio62"/></td>
                          <td class="tabel"><asp:TextBox ID="TextBox40" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button5" runat="server" OnClientClick="return page2()" Text="Next" Width="60px" CssClass="btn btn-primary pull-right" />
              </div>
          </div>
          </div>

        <div id="bayA2" style="display:none">
          <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header ui-sortable-handle">

                <i class="fa fa-inbox"></i> <h3 class="box-title">BAY A2 K-HPA 1</h3>

            </div>
              <div class="box-body">
                  <div style="padding-bottom:100px;">
                  <ul class="progressbar">
                      <li class="active">Page 1</li>
                      <li class="select">Page 2</li>
                      <li>Page 3</li>
                      <li>Page 4</li>
                      <li>Page 5</li>
                      <li>Page 6</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td rowspan="2" style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td colspan="2" style="width:50px; padding-left:10px; font-weight:bold; text-align:center">Status</td>
                          <td rowspan="2" style="width:30px; padding-left:10px; font-weight:bold">Nilai</td>
                      </tr>
                      <tr>
                          <td style="width:15px; padding-left:10px; max-width:40px; font-weight:bold">pass</td>
                          <td style="width:15px; padding-left:10px; max-width:40px; font-weight:bold">fail</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="8"><b>K-HPA 1</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rba2hp1st" runat="server" value="1" id="Radio11"/></td>
                          <td class="tabel"><input type="radio" name="rba2hp1st" runat="server" value="0" id="Radio12"/></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Channel</td>
                          <td class="tabel"></td>
                          <td class="tabel"></td>
                          <td class="tabel"><asp:TextBox ID="TextBox9" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out Level</td>
                          <td class="tabel"></td>
                          <td class="tabel"></td>
                          <td class="tabel"><asp:TextBox ID="TextBox41" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out Power</td>
                          <td class="tabel"></td>
                          <td class="tabel"></td>
                          <td class="tabel"><asp:TextBox ID="TextBox42" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel"></td>
                          <td class="tabel"></td>
                          <td class="tabel"><asp:TextBox ID="TextBox43" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam</td>
                          <td class="tabel"></td>
                          <td class="tabel"></td>
                          <td class="tabel"><asp:TextBox ID="TextBox44" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">Bdy</td>
                          <td class="tabel"></td>
                          <td class="tabel"></td>
                          <td class="tabel"><asp:TextBox ID="TextBox45" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF drive</td>
                          <td class="tabel"></td>
                          <td class="tabel"></td>
                          <td class="tabel"><asp:TextBox ID="TextBox46" runat="server"  Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>PSU K-HPA</b></td>
                          <td class="tabel">Status</td>
                          <td class="tabel"><input type="radio" name="rbt3ca5rfst" runat="server" value="1" id="Radio15"/></td>
                          <td class="tabel"><input type="radio" name="rbt3ca5rfst" runat="server" value="0" id="Radio16"/></td>
                          <td class="tabel"></td>
                      </tr>
                      
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button6" runat="server" OnClientClick="return page1()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button2" runat="server" OnClientClick="return page3()" Text="Next" Width="60px" CssClass="btn btn-primary pull-right" />
              </div>
          </div>
          </div>

                <div id="bayA3" style="display:none">
          <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header ui-sortable-handle">

                <i class="fa fa-inbox"></i> <h3 class="box-title">BAY A3 K-HPA 2</h3>

            </div>
              <div class="box-body">
                  <div style="padding-bottom:100px;">
                  <ul class="progressbar">
                      <li class="active">Page 1</li>
                      <li class="active">Page 2</li>
                      <li class="select">Page 3</li>
                      <li>Page 4</li>
                      <li>Page 5</li>
                      <li>Page 6</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td style="width:50px; padding-left:10px; font-weight:bold; text-align:center; max-width:150px;">Status/Nilai</td>
                          <td style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Switch & Distribution</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList6" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label13" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA Protection Switch</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList7" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label14" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter Backup</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList9" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label16" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox71" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label17" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox72" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label18" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Switch Over Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Converter</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox10" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox17" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Priority</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox18" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Address</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox47" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label4" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox48" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label5" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up COnverter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox4" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label9" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox11" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label10" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up COnverter 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList4" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox49" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label11" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox50" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label12" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Dehydrator</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList5" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button7" runat="server" OnClientClick="return page2()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button8" runat="server" OnClientClick="return page4()" Text="Next" Width="60px" CssClass="btn btn-primary pull-right" />
              </div>
          </div>
          </div>

        <div id="bay1" style="display:none">
          <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header ui-sortable-handle">

                <i class="fa fa-inbox"></i> <h3 class="box-title">BAY 1</h3>

            </div>
              <div class="box-body">
                  <div style="padding-bottom:100px;">
                  <ul class="progressbar">
                      <li class="active">Page 1</li>
                      <li class="active">Page 2</li>
                      <li class="active">Page 3</li>
                      <li class="select">Page 4</li>
                      <li>Page 5</li>
                      <li>Page 6</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td style="width:50px; padding-left:10px; font-weight:bold; text-align:center; max-width:150px;">Status/Nilai</td>
                          <td style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Power Meter</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList8" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label15" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox61" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label32" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>TLT Switch</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList10" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label19" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Switch</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList16" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label35" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>Digital Tracking Receiver</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList11" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label20" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox12" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label21" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">C/No</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox51" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label22" runat="server" Text="dB.Hz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">TX Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox62" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label33" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">DAC 1</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox63" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label34" runat="server" Text="VDC"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Manual Rate Control</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList17" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label36" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Antena Control Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList12" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label23" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox52" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label37" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Azimuth</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox53" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label24" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Elevation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox54" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label25" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Polarization</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox55" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label26" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Input</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox56" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label27" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Monitor RF</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList19" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label43" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList13" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox57" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label28" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox58" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label29" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Switch Over Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList18" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label38" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Converter</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox64" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox65" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label39" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Priority</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox66" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label40" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Address</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox67" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label41" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox68" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label42" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down COnverter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList14" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox59" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label30" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox60" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label31" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="DropDownList15" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox69" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label44" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBox70" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label45" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button9" runat="server" OnClientClick="return page3()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button10" runat="server" OnClientClick="return page5()" Text="Next" Width="60px" CssClass="btn btn-primary pull-right" />
              </div>
          </div>
          </div>



        </div>


        <!-- right col -->
      </div>
    </div>

        <div runat="server" id="T3SKUHarkat" visible="false">
        <asp:Button ID="Button4" runat="server" Text="check all" CssClass="btn btn-flat" OnClick="check_Click"/>
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
      function page2(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'block';
          document.getElementById("bayA3").style.display = 'none';
          document.getElementById("bay1").style.display = 'none';
          return false;
        }
        function page4(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'none';
            document.getElementById("bay1").style.display = 'block';
          return false;
        }
        function page3(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'block';
            document.getElementById("bay1").style.display = 'none';
          return false;
        }
        function page1(){
          // put your code here 
            document.getElementById("bayA4").style.display = 'block';
            document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'none';
            document.getElementById("bay1").style.display = 'none';
          return false;
        }



    function SetDropDownListColor(ddl) {
    for (var i = 0; i < ddl.options.length; i++) {
        if (ddl.options[i].selected) {
            switch (i) {
                case 0:
                    ddl.style.backgroundColor = '#38f345';
                    ddl.style.color = 'White';
                    return;
                case 1:
                    ddl.style.backgroundColor = '#ff3d3d';
                    return;
            }
        }
    }
        }

        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList4.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList5.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList6.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList7.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList9.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList10.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList11.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList12.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList13.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList14.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList15.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList16.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList17.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList18.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= DropDownList19.ClientID %>')); }, false);
    </script>
</body>
</html>
