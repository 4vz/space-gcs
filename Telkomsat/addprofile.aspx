﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addprofile.aspx.cs" Inherits="Telkomsat.addprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tambah User</title>
    <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
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
    <link href="profile.css" rel="stylesheet" type="text/css"/>
    <link href="profile2.css" rel="stylesheet" />
    <link rel="stylesheet" href="./assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"/>
</head>
<body class="hold-transition skin-blue layout-top-nav">
<form id="form1" runat="server">
<div class="wrapper">
    
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
                                <li class="dropdown-submenu">
                                    <a class="test" tabindex="-1" href="#">Checklist <span class="caret"></span></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="../checkhk/harian.aspx">Harkat</a></li>
                                        <li><a href="../checklistme/harian.aspx">ME</a></li>
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
  <!-- Full Width Column -->
  <div class="content-wrapper">
    <div class="container">
    <section class="content">
        <div class="row">
    <div class="register-logo">
     <b>Tambah</b> User</>
  </div>
    <div>
        <hr width="100%" />
    </div>
</div>
  
<div class="row">
    <div class="col-lg-5">
            <div>
                <asp:Label ID="lblUpdate" runat="server" Visible="false"></asp:Label>
              </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Nama</label> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtnama"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtnama" runat="server"/>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">NIK</label> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtnik"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtnik" runat="server"/>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Alias</label> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtalias"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtalias" runat="server"/>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Jenis</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtalias"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddljenis" runat="server" CssClass="form-control">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>OG</asp:ListItem>
                            <asp:ListItem>OS</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Previllage</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="ddlprevillage" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlprevillage" runat="server" CssClass="form-control">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>super</asp:ListItem>
                            <asp:ListItem>adminhk</asp:ListItem>
                            <asp:ListItem>adminme</asp:ListItem>
                            <asp:ListItem>normal</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Approval Checklist</label>
                        <asp:DropDownList ID="ddlchecklist" runat="server" CssClass="form-control">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Harkat</asp:ListItem>
                            <asp:ListItem>ME</asp:ListItem>
                        </asp:DropDownList>
                    </div>
            
              <div class="form-group has-feedback">
                <!-- /.col -->
                <div>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" onkeypress="return runScript(event)" OnClick="btnUpdate_click" />
                </div>
                <!-- /.col -->
              </div>
        </div>

          <div class="col-lg-1">
            
          </div>
          <div class="col-lg-7">
              <br />
            <h4>Password default untuk login : "gcsgcs"</h4>
          </div>
</div>

    </section>
  

      <!-- /.content -->
    </div>
    <!-- /.container -->
</div>
   
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="container">
      <div class="pull-right hidden-xs">
        <b>Version</b> 2.0
      </div>
      <strong>Copyright &copy; 2019 <a href="https://www.telkomsat.co.id">Telkomsat</a>.</strong> All rights
      reserved.
    </div>
    <!-- /.container -->
  </footer>

</div>
</form>
<!-- ./wrapper -->

    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>


    <script>
        $(function () {
            $("#txtttl").datepicker({
                format: "dd/mm/yyyy"
            });

            $("#txttanggal").datepicker({
                format: "dd/mm/yyyy"
            });
        })
    </script>
    <script type="text/javascript">
        function runScript(e) {
            if (e.keyCode == 13) {
                document.getElementById('<%=btnUpdate.ClientID%>').focus();
                document.getElementById('<%=btnUpdate.ClientID%>').click(); //javascript
        }
    </script>
</body>

</html>
