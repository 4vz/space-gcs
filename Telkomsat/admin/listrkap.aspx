<%@ Page Title="RKAP" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="listrkap.aspx.cs" Inherits="Telkomsat.admin.listrkap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">RKAP</h3>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <a href="rkap.aspx" class="btn btn-primary pull-right">Tambah</a>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </section>
        </div>

    <script>
        $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
              "ordering": false,
              "lengthChange": true,
            "searching": true
          });
           $('.dataTables_length').addClass('bs-select');
        });
    </script>
</asp:Content>
