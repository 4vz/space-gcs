<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="approvement.aspx.cs" Inherits="Telkomsat.admin.approvement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Approvement</h3>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </section>
        </div>


    <div class="modal fade" id="modalmaintenance">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Justifikasi</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <table class="table" style="border:none">
                                    <tbody>
                                          <tr>
                                              <th>Jenis UPD</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbljupd" runat="server" Text="Wildan Ger saputra" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Subdit</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblsubdit" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Jabatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbljabatan" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                         <tr>
                                              <th>No. Akun Anggaran</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnaa" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Tanggal Kegiatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltgl" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Tanggal Dokumen Diserahkan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltglds" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Pemberi Tugas</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltglpt" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Jenis Anggaran</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblja" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Program Kerja</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblpk" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nilai RKAP</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnrkap" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nama Kegiatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnk" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Comply</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblcom" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nama Vendor</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnv" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nilai</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnilai" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Keterangan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblket" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Detail</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbldetail" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                    </tbody>
                          
                                </table>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal" aria-label="Close">Close</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

    
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

        function confirmselesai(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data tidak bisa diubah lagi',
                buttons: true,
                icon: "success",

            }).then((willDelete)=>{
                if (willDelete) {
                    document.location = deleteurl;
                }
            });
        }

        $('.datamain').click(function () {
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "approvement.aspx/GetDetail",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        console.log(this.keteranganmain);
                        $('#<%=lblcom.ClientID %>').html(this.comply);
                        $('#<%=lbldetail.ClientID %>').html(this.detail);
                        $('#<%=lblja.ClientID %>').html(this.ja);
                        $('#<%=lbljabatan.ClientID %>').html(this.jabatan);
                        $('#<%=lbljupd.ClientID %>').html(this.jupd);
                        $('#<%=lblket.ClientID %>').html(this.ket);
                        $('#<%=lblnaa.ClientID %>').html(this.naa);
                        $('#<%=lblnilai.ClientID %>').html(this.nilai);
                        $('#<%=lblnk.ClientID %>').html(this.nk);
                        $('#<%=lblnrkap.ClientID %>').html(this.nrkap);
                        $('#<%=lblnv.ClientID %>').html(this.nv);
                        $('#<%=lblpk.ClientID %>').html(this.pk);
                        $('#<%=lblsubdit.ClientID %>').html(this.subdit);
                        $('#<%=lbltgl.ClientID %>').html(this.tgl);
                        $('#<%=lbltglds.ClientID %>').html(this.tglds);
                        $('#<%=lbltglpt.ClientID %>').html(this.tglpt);
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
    </script>
</asp:Content>
