<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="approve.aspx.cs" Inherits="Telkomsat.admin.approve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <section class="col-lg-5 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Pengeluaran</h3>
                        <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <div  class="box-body">
                <table class="table">
                    <tbody>
                        <tr>
                            <td><asp:Label ID="Label4" runat="server" Text="Keterangan"></asp:Label></td>
                            <td>:</td>
                            <td><asp:Label ID="lblketerangan" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label8" runat="server" Text="Kategori"></asp:Label></td>
                            <td>:</td>
                            <td><asp:Label ID="lblkategori" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label10" runat="server" Text="Nominal"></asp:Label></td>
                            <td>:</td>
                            <td><asp:Label ID="lblnominal" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label12" runat="server" Text="PIC"></asp:Label></td>
                            <td>:</td>
                            <td><asp:Label ID="lblpic" runat="server" Text="Label"></asp:Label></td>
                        </tr>

                    </tbody>
                </table>
            </div>
                </div>
        </section>
        <section class="col-lg-7 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Detail Pengeluaran</h3>
                        <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                <div class="box-body">
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                </div>
                <!-- /.box-body -->

                <div class="box-footer">
                <button type="submit" class="btn btn-primary" runat="server">Submit</button>
                </div>
            </div>
            </section>
            </div>
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script>
        function confirmselesai(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data tidak bisa diubah on-progress lagi',
                buttons: true,
                dangerMode: true,

            }).then((willDelete)=>{
                if (willDelete) {
                    document.location = deleteurl;
                }
            });
        }
    </script>
</asp:Content>
