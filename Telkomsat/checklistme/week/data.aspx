<%@ Page Title="Data Maintenance ME Mingguan" Language="C#" MasterPageFile="~/CHECKMEWEEK.Master" AutoEventWireup="true" CodeBehind="data.aspx.cs" Inherits="Telkomsat.checklistme.week.data" %>
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
                        <label for="exampleInputEmail1">Bulan</label>
                        <asp:DropDownList ID="ddlbulan" CssClass="form-control" runat="server" onchange="status(this)">
                            <asp:ListItem Value="bulan">-Bulan-</asp:ListItem>
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
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Tahun</label>
                        <asp:DropDownList ID="ddltahun" CssClass="form-control" runat="server" onchange="status(this)" >
                            <asp:ListItem Value="tahun" >-Tahun-</asp:ListItem>
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
        <i class="fa fa-database"></i> Data Maintenance Mingguan
    </div>
    <div class="box-body">
        <!-- Morris chart - Sales -->
        <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:Label ID="lblstat" runat="server" Text="" Visible="false"></asp:Label>
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
            </div>
    <!-- /.table -->
        </div>
    </div>
    </div>
</div>
</div>
    <script type="text/javascript">
       $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
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
