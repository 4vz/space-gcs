<%@ Page Title="Data Tahunan" Language="C#" MasterPageFile="~/CHECKMEWEEK.Master" AutoEventWireup="true" CodeBehind="data.aspx.cs" Inherits="Telkomsat.checklistme.year.data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Ruangan</label>
                        <asp:DropDownList ID="ddlruang" CssClass="form-control" runat="server" onchange="status(this)">
                            <asp:ListItem Value="ruangan">-Semua Ruangan-</asp:ListItem>
                            <asp:ListItem>RO-TRF</asp:ListItem>
                            <asp:ListItem>RO-HYD</asp:ListItem>
                            <asp:ListItem>CBI</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Tahun</label>
                        <asp:DropDownList ID="ddltahun" CssClass="form-control" runat="server" onchange="status(this)">
                            <asp:ListItem >-Tahun-</asp:ListItem>
                            <asp:ListItem >2019</asp:ListItem>
                            <asp:ListItem >2020</asp:ListItem>
                            <asp:ListItem >2021</asp:ListItem>
                            <asp:ListItem >2022</asp:ListItem>
                            <asp:ListItem >2023</asp:ListItem>
                            <asp:ListItem >2024</asp:ListItem>
                            <asp:ListItem >2025</asp:ListItem>
                            <asp:ListItem >2026</asp:ListItem>
                            <asp:ListItem >2027</asp:ListItem>
                            <asp:ListItem >2028</asp:ListItem>
                            <asp:ListItem >2029</asp:ListItem>
                            <asp:ListItem >2030</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
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
        <i class="fa fa-database"></i> Data Maintenance Tahunan
    </div>
    <div class="box-body">
        <!-- Morris chart - Sales -->
        <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:Label ID="lblkosong" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
            </div>
    <!-- /.table -->
        </div>
    </div>
    </div>
</div>
</div>
    <script src="//cdn.rawgit.com/ashl1/datatables-rowsgroup/v1.0.0/dataTables.rowsGroup.js"></script>
    <script type="text/javascript">
       $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
          "rowsGroup": [0, 1, 2, 3],
          "pageLength": 100,
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });
    </script>
</asp:Content>
