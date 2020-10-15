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
                <a href="importrkap.aspx" class="btn btn-default pull-right" id="btnimport" style="margin-right:10px; margin-left:10px" runat="server" visible="false">Import</a>
            <a href="tambahrkap.aspx" class="btn btn-primary pull-right">Tambah</a>
                                <button type="button" style="margin-right:10px" class="btn btn-sm btn-warning pull-right datawil" data-toggle="modal" data-target="#modalupdate" id="edit">Filter </button>

            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </section>
        </div>

        <div class="modal fade" id="modalupdate">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Harkat</h4>
              </div>
              <div class="modal-body">
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Jenis Anggaran :</label>
                    <select id="sotugas" runat="server" class="select2 form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
                
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Bulan :</label>
                    <select id="sobulan" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                            <option>Januari</option> 
                            <option>Februari</option> 
                            <option>Maret</option> 
                            <option>April</option> 
                            <option>Mei</option> 
                            <option>Juni</option> 
                            <option>Juli</option> 
                            <option>Agustus</option> 
                            <option>September</option> 
                            <option>Oktober</option> 
                            <option>November</option> 
                            <option>Desember</option>
                        </select>
                </div>

              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Filter_Click">Submit</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
    <asp:TextBox ID="txtnamaakun" CssClass="hidden" runat="server"></asp:TextBox>

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

        $(function () {
            $.ajax({
                type: "POST",
                url: "listrkap.aspx/GetNA",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sotugas.ClientID %>').empty();
                    $('#<%=sotugas.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log($('#<%=txtnamaakun.ClientID%>').val() + " sd ");
                        $('#<%=sotugas.ClientID %>').append($('<option>',
                            {
                                value: this.namaakun,
                                text: this.namaakun,
                            }));
                        $('#<%=sotugas.ClientID %>').val($('#<%=txtnamaakun.ClientID%>').val())

                    });
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

        $('#<%=sotugas.ClientID%>').change(function () {
        var id = $(this).val();
            $('#<%=txtnamaakun.ClientID%>').val(id);
        });
    </script>
</asp:Content>
