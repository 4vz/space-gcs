<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="ruangan.aspx.cs" Inherits="Telkomsat.dataasset.ruangan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script src="../assets/mylibrary/sweetalert.min.js"></script>
<div class="row">
    <div class="col-md-9">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Ruangan</h3>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer no-padding">
            <div class="mailbox-controls">
            <a href="ruanganadd.aspx" class=" btn btn-danger btn-sm pull-right"> Tambah</a>
            <!-- /.pull-right -->
            </div>
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
</div>
    <asp:HiddenField ID="HiddenField1" runat="server" Value="bisa" />
    <asp:TextBox ID="txtid" runat="server" CssClass="hidden"></asp:TextBox>
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
                    <label style="font-size:16px; font-weight:bold">ID Bangunan :</label>
                    <asp:Label ID="lblid" runat="server" style="font-size:16px; font-weight:bold"></asp:Label>
                </div>
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Nama Ruangan :</label>
                    <asp:TextBox ID="txtwiayah" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">QR Ruangan :</label>
                    <asp:TextBox ID="txtqr" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label style="font-size:16px">Nama Bangunan :</label>
                    <select id="so2" runat="server" class="form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Edit_ServerClick">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        <asp:TextBox ID="TextBox2" CssClass="hidden" runat="server"></asp:TextBox>
          <!-- /.modal-dialog -->
        </div>
    <script type="text/javascript">
        $('#<%=so2.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=TextBox2.ClientID %>').val(id);
        })
        $(function () {
            $('.select2').select2({
                 allowClear:true,
                 placeholder: "--Pilih Wilayah--",
             });


          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
          "autoWidth": true,
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });


        $.ajax({
            type: "POST",
            url: "Ruangan.aspx/GetID",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var customers = response.d;
                $('#<%=so2.ClientID %>').empty();
                $('#<%=so2.ClientID %>').append('<option>' + '--Pilih Bangunan--' + '</option>');
                $(customers).each(function () {
                    console.log(this.idbangunan);
                    $('#<%=so2.ClientID %>').append($('<option>',
                     {
                        value: this.idbangunan,
                        text : this.bangunan1, 
                    }));
                });
            },
            failure: function (response) {
                
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
            });


        $(document).ready(function () {
            $('#checkBoxAll').click(function () {
                if ($(this).is(":checked"))
                    $('.chkCheckBoxId').prop('checked', true);
                else
                    $('.chkCheckBoxId').prop('checked', false);
            });
        });

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
                url: "ruangan.aspx/Getbangunan",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        console.log(this.bangunan);
                        $('#<%=txtwiayah.ClientID %>').val(this.bangunan);
                        $('#<%=txtqr.ClientID %>').val(this.qr);
                        $('#<%=lblid.ClientID %>').html(this.idruangan);
                        $('#<%=txtid.ClientID %>').val(this.idruangan);
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

        function fungsi() {
            alert("Berhasil Disimpan");
        }
    </script>  
</asp:Content>
