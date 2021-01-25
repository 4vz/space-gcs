<%@ Page Title="Justifikasi" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="listjustifikasi.aspx.cs" Inherits="Telkomsat.admin.listjustifikasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Justifikasi</h3>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                <a href="importrkap.aspx" class="btn btn-default pull-right" id="btnimport" style="padding-right:10px" runat="server" visible="false">Import</a>
            <a href="justifikasi.aspx" class="btn btn-primary btn-sm pull-right" id="btntambah" runat="server" visible="false">Tambah</a>
                <button type="button" style="margin-right:10px" class="btn btn-sm btn-warning pull-right datawil" data-toggle="modal" data-target="#modalupdate" id="filter">Filter </button>
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
                <h4 class="modal-title">Filter</h4>
              </div>
              <div class="modal-body">
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Jenis Anggaran :</label>
                    <select id="soja" runat="server" class="form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
                
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Jenis Proc :</label>
                    <select id="sojp" runat="server" class="form-control" style="width: 100%;">
                            <option></option>
                            <option>OPEX</option> 
                            <option>CAPEX</option> 
                            <option>Panjar</option> 
                        </select>
                </div>
                  <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Status :</label>
                    <asp:DropDownList ID="ddlstatus" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="diajukan">Diajukan</asp:ListItem>
                        <asp:ListItem Value="reject">Ditolak</asp:ListItem>
                        <asp:ListItem Value="pending">Pending</asp:ListItem>
                        <asp:ListItem Value="revision">Revisi</asp:ListItem>
                        <asp:ListItem Value="gm">Diapprove GM</asp:ListItem>
                        <asp:ListItem Value="admin">Selesai</asp:ListItem>
                    </asp:DropDownList>
                </div>
                  <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Pemberi Tugas :</label>
                    <select id="sotugas" runat="server" class="form-control" style="width: 100%;">
                            <option></option>
                        </select>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Filter_Click" >Submit</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
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
    <asp:TextBox ID="txtnamaakun" CssClass="hidden" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtpetugas" CssClass="hidden" runat="server"></asp:TextBox>

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

            $.ajax({
                type: "POST",
                url: "listrkap.aspx/GetNA",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=soja.ClientID %>').empty();
                    $('#<%=soja.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        $('#<%=soja.ClientID %>').append($('<option>',
                            {
                                value: this.namaakun,
                                text: this.namaakun,
                            }));
                        $('#<%=soja.ClientID %>').val($('#<%=txtnamaakun.ClientID%>').val())
                    });
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });

            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetPIC",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sotugas.ClientID %>').empty();
                    $('#<%=sotugas.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sotugas.ClientID %>').append($('<option>',
                            {
                                value: this.idpic,
                                text: this.pic,
                            }));
                        $('#<%=sotugas.ClientID %>').val($('#<%=txtpetugas.ClientID%>').val())
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

        $('.datariwayat').click(function () {
            var id = $(this).val();
            $('#<%=txtidaj.ClientID %>').val(id);
        });

        $('#<%=soja.ClientID%>').change(function () {
        var id = $(this).val();
            $('#<%=txtnamaakun.ClientID%>').val(id);
        });

        $('#<%=sotugas.ClientID%>').change(function () {
        var id = $(this).val();
            $('#<%=txtpetugas.ClientID%>').val(id);
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
