<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKMEWEEK.Master" AutoEventWireup="true" CodeBehind="data.aspx.cs" Inherits="Telkomsat.checklistme.month.data" %>
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
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Ruangan</label>
                        <asp:DropDownList ID="ddlruang" runat="server" CssClass="form-control" Width="100%">
                            <asp:ListItem>-Pilih Ruangan-</asp:ListItem>
                            <asp:ListItem>RO-CHL</asp:ListItem>
                            <asp:ListItem>RO-HPA</asp:ListItem>
                            <asp:ListItem>RO-BBRC</asp:ListItem>
                            <asp:ListItem>RO-UPS</asp:ListItem>
                            <asp:ListItem>SH-T1</asp:ListItem>
                            <asp:ListItem>SH-T2</asp:ListItem>
                            <asp:ListItem>SH-T3S-KU</asp:ListItem>
                            <asp:ListItem>SH-T3S-C</asp:ListItem>
                            <asp:ListItem>SH-MP-SAT</asp:ListItem>
                            <asp:ListItem>SH-MON-KU-BAND</asp:ListItem>
                            <asp:ListItem>SH-TAR</asp:ListItem>
                            <asp:ListItem>SH-FMA-11</asp:ListItem>
                            <asp:ListItem>SH-FMA-9,8</asp:ListItem>
                            <asp:ListItem>SH-TEL</asp:ListItem>
                            <asp:ListItem>SH-16</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Bulan</label>
                        <asp:DropDownList ID="ddlbulan" CssClass="form-control" runat="server" onchange="status(this)">
                            <asp:ListItem Value="pagi">-Bulan-</asp:ListItem>
                            <asp:ListItem Value="1">Januari</asp:ListItem>
                            <asp:ListItem Value="2">Februari</asp:ListItem>
                            <asp:ListItem Value="3">Maret</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">Mei</asp:ListItem>
                            <asp:ListItem Value="6">Juni</asp:ListItem>
                            <asp:ListItem Value="7">Juli</asp:ListItem>
                            <asp:ListItem Value="8">Agustus</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">Oktober</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">Desember</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3">
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
                <div class="col-md-3">
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
        <i class="fa fa-database"></i> Data Maintenance Bulanan
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
