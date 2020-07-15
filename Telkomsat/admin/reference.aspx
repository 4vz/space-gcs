<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="reference.aspx.cs" Inherits="Telkomsat.admin.reference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtid" runat="server" CssClass="hidden"></asp:TextBox>
    <div class="row">
        <section class="col-lg-6 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Tambah Reference</h3>
                        <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                        <asp:Panel ID="UserPanel" runat="server" DefaultButton="btnsave">
                        <table class="table">
                            <thead>
                                <tr>
                                    <td>Tambah</td>
                                    <td>Action</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><asp:TextBox ID="txtreference" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <td><asp:Button ID="btnsave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="save_click" /></td>
                                </tr>
                            </tbody>
                        </table>
                        </asp:Panel>
                    </div>
                </div>
            </section>
        </div>
    <div class="row">
        <section class="col-lg-6 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Tambah Reference</h3>
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
                    <label style="font-size:16px; font-weight:bold">Referensi :</label>
                    <asp:TextBox ID="txtreferens" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Edit_ServerClick">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script>
        function confirmdelete(deleteurl) {
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

        $('.datawil').click(function () {
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "reference.aspx/GetReferensi",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        console.log(this.wilayah);
                        $('#<%=txtreferens.ClientID %>').val(this.referensi);
                        $('#<%=txtid.ClientID %>').val(this.idreferensi);
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
