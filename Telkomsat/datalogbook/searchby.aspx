<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="searchby.aspx.cs" Inherits="Telkomsat.datalogbook.searchby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        h4 {
            position: relative;
            font-size: 16px;
            font-family:Constantia;
            z-index: 1;
            overflow: hidden;
            text-align: center;
        }

            h4:before, h4:after {
                position: absolute;
                top: 51%;
                overflow: hidden;
                width: 50%;
                height: 1px;
                content: '\a0';
                background-color: gray;
            }

            h4:before {
                margin-left: -50%;
                text-align: right;
            }
    </style>
    <link rel="stylesheet" href="dataaset.css?version=2" />
    <asp:TextBox ID="txtdevice" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtruangan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtrak" runat="server" CssClass="hidden"></asp:TextBox>
     <asp:TextBox ID="txtsatelit" runat="server" CssClass="hidden"></asp:TextBox>
<div class="row">
    <div class="nav-tabs-custom col-lg-12">
    <!-- Tabs within a box -->
    <ul class="nav nav-tabs pull-right">
        <li class="pull-left header"><i class="fa fa-filter"></i> Search By</li>
    </ul>
    <asp:Panel ID="UserPanel" runat="server" DefaultButton="Button1">
    <div class="tab-content no-padding">
        <!-- Morris chart - Sales -->
        <div class="box-body">
            <h4>Filter</h4>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Divisi</label>
                </div>   
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlunit" runat="server" CssClass="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Harkat</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                        <asp:ListItem>SCO</asp:ListItem>
                        <asp:ListItem>Andat</asp:ListItem>
                        <asp:ListItem>Orbital</asp:ListItem>
                        <asp:ListItem>STS</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Kategori</label>
                </div>   
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlkategori" runat="server" CssClass="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Pointing Antena</asp:ListItem>
                        <asp:ListItem>Perbaikan</asp:ListItem>
                        <asp:ListItem>Perawatan</asp:ListItem>
                        <asp:ListItem>Penggantian</asp:ListItem>
                        <asp:ListItem>Lain-lain</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Status</label>
                </div>   
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>On Progress</asp:ListItem>
                        <asp:ListItem>Selesai</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">PIC Internal</label>
                </div>   
                <div class="col-sm-10">
                    <asp:TextBox ID="txtpicint" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">PIC External</label>
                </div>   
                <div class="col-sm-10">
                    <asp:TextBox ID="txtpicext" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            
            <h4>Tanggal</h4>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-sm-4">
                            <label for="inputEmail3" class="pull-right">Mulai</label>
                        </div>   
                        <div class="col-sm-8">
                           <asp:TextBox ID="txtmulai" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <div class="col-md-6">
                     <div class="col-sm-4">
                        <label for="inputEmail3" class="pull-right">Sampai </label>
                    </div>   
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtsampai" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                 </div>
                    
                </div>
            </div>
           
               <br />
            <div class="form-group">
                <asp:Button ID="Button1" class="btn btn-info pull-right" runat="server" OnClick="submit_click" Text="Filter"  style="width:30%" />
            </div>
        </asp:Panel>
    </div>
    </div>

    <div class="row">
    <div class="col-md-12">
        <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Hasil Pencarian</h3>
 
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
        <asp:Label ID="lblpencarian" runat="server" Text="Data pencarian tidak ditemukan" Visible="false"></asp:Label>
            </div>
            <!-- /.table -->
            <!-- /.mail-box-messages -->
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    </div>
    <script src="../assets/mylibrary/jquery-ui-1-12-1.js"></script>
    <script type="text/javascript">
        $(function () {
          var datatableInstance = $("#example2").DataTable({
          "paging": true,
          "searching": false,
          "info": true,
          "ordering": false,
          "autoWidth": true,
          "scrollX": true
          });
            $('.dataTables_length').addClass('bs-select');

        });

        $('#<%=txtmulai.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtsampai.ClientID%>').datepicker('setStartDate', minDate);
        });
        $('#' + '<%=txtsampai.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtmulai.ClientID%>').datepicker('setEndDate', minDate);
        });
       
    </script>
</asp:Content>
