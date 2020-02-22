<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cobadata.aspx.cs" Inherits="Telkomsat.checklistme.cobadata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content-wrapper" style="min-height:1300px;">
            <div class="container no-padding">
            <section class="content">
                <div class="row" style="padding:20px">
<div class="nav-tabs-custom col-lg-12">
    <!-- Tabs within a box -->
    <ul class="nav nav-tabs pull-right">
        <li class="pull-left header"><i class="fa fa-filter"></i> Filter</li>
    </ul>
    <div class="tab-content no-padding">
        <!-- Morris chart - Sales -->
        <div class="box-body">
        
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Ruangan</label>
                        <asp:DropDownList ID="ddlKategori" CssClass="form-control" runat="server" onchange="status(this)">
                            <asp:ListItem Value="ruangan">-Semua Ruangan-</asp:ListItem>
                            <asp:ListItem>RO-TRF</asp:ListItem>
                            <asp:ListItem>RO-ATS</asp:ListItem>
                            <asp:ListItem>RO_FDR</asp:ListItem>
                            <asp:ListItem>RO-GST</asp:ListItem>
                            <asp:ListItem>RO-BBM</asp:ListItem>
                            <asp:ListItem>RO-CHL</asp:ListItem>
                            <asp:ListItem>RO-UPS</asp:ListItem>
                            <asp:ListItem>RO-AHU-1</asp:ListItem>
                            <asp:ListItem>RO-AHU-2</asp:ListItem>
                            <asp:ListItem>RO-HPA</asp:ListItem>
                            <asp:ListItem>RO-BBRC</asp:ListItem>
                            <asp:ListItem>SH-16</asp:ListItem>
                            <asp:ListItem>SH-TEL</asp:ListItem>
                            <asp:ListItem>SH-FMA-9,8</asp:ListItem>
                            <asp:ListItem>SH-FMA-11</asp:ListItem>
                            <asp:ListItem>SH-TAR</asp:ListItem>
                            <asp:ListItem>SH-MON-KU-BAND</asp:ListItem>
                            <asp:ListItem>SH-T1</asp:ListItem>
                            <asp:ListItem>SH-T2</asp:ListItem>
                            <asp:ListItem>SH-T3S-KU</asp:ListItem>
                            <asp:ListItem>SH-T3S-C</asp:ListItem>
                            <asp:ListItem>SH-MPSAT</asp:ListItem>
                            <asp:ListItem>RO-WTT</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Filter</label>
                        <br />
                        <button type="submit" class="btn btn-primary" runat="server" onserverclick="Filter_ServerClick" >Submit</button>
                    </div>
                </div>
        <!-- /.table -->
            </div>
        </div>
    </div>
</div>

<div class="col-lg-12 connectedSortable">
        <!-- Custom tabs (Charts with tabs)-->
    <div class="box box-primary">
    <!-- Tabs within a box -->
    <div class="box-header">
        <i class="fa fa-database"></i> Checklist Harian
    </div>
    <div class="box-body">
        <!-- Morris chart - Sales -->
        <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
            </div>
    <!-- /.table -->
        </div>
    </div>
    </div>
</div>
</div>
    <script src="../assets/mylibrary/rowsgroup.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script>
        $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
          "autoWidth": true,
          "scrollX": true,
          "pageLength": 100,
          "rowsGroup": [0, 1, 2],
          "ordering": false,
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });
    </script>
            </section>
            </div>
        </div>
    </form>
</body>
</html>
