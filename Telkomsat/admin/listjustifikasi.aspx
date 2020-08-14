<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="listjustifikasi.aspx.cs" Inherits="Telkomsat.admin.listjustifikasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Justifikasi</h3>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <a href="justifikasi.aspx" class="btn btn-primary pull-right" id="btntambah" runat="server" visible="false">Tambah</a>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </section>
        </div>

        <div class="modal fade" id="modalriwayat">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Riwayat</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                      </div>
                  
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-sm btn-default" data-dismiss="modal" aria-label="Close">Close</button>
                  </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>
        </div>
    <asp:TextBox ID="txtidaj" CssClass="hidden" runat="server"></asp:TextBox>

    <script src="../assets/mylibrary/sweetalert.min.js"></script>
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

        $('.datariwayat').click(function () {
            var id = $(this).val();
            $('#<%=txtidaj.ClientID %>').val(id);
        });

        function confirmhapus(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data yang dihapus tidak akan kembali lagi',
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
