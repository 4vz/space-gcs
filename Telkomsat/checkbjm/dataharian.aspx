<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTBJM.Master" AutoEventWireup="true" CodeBehind="dataharian.aspx.cs" Inherits="Telkomsat.checkbjm.dataharian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
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
                            <asp:ListItem Value="ruangan">-Pilih Ruangan-</asp:ListItem>
                            <asp:ListItem>BASEBAND ROOM</asp:ListItem>
                            <asp:ListItem>WORKSTATION ROOM</asp:ListItem>
                            <asp:ListItem>RF ROOM</asp:ListItem>
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
        <i class="fa fa-database"></i> Checklist 
       
    <asp:Label ID="lbltanggal" runat="server" Text="" Visible="false" CssClass="pull-right"></asp:Label>
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
              { "className": "bg-warning", "targets": [4] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });
    </script>
</asp:Content>
