<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="bangunan.aspx.cs" Inherits="Telkomsat.dataasset.bangunan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <div class="col-md-9">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Bangunan</h3>
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
            <a href="siteadd.aspx" class=" btn btn-danger btn-sm pull-right"> Tambah</a>
            <!-- /.pull-right -->
            </div>
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
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
                    <label style="font-size:16px; font-weight:bold">ID Wilayah :</label>
                    <asp:Label ID="lblid" runat="server" style="font-size:16px; font-weight:bold"></asp:Label>
                </div>
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Nama Bangunan :</label>
                    <asp:TextBox ID="txtwiayah" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label style="font-size:16px">Nama Wilayah :</label>
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

    <!-- /.col -->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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
          "scrollX": true,
          "order": [[ 1, 'desc' ]],
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });


        $.ajax({
            type: "POST",
            url: "bangunan.aspx/GetID",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var customers = response.d;
                $('#<%=so2.ClientID %>').empty();
                $('#<%=so2.ClientID %>').append('<option>' + '--Pilih Wilayah--' + '</option>');
                $(customers).each(function () {
                    console.log(this.idwilayah);
                    $('#<%=so2.ClientID %>').append($('<option>',
                     {
                        value: this.idwilayah,
                        text : this.wilayah1, 
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
                url: "bangunan.aspx/GetWilayah",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        console.log(this.wilayah);
                        $('#<%=txtwiayah.ClientID %>').val(this.wilayah);
                        $('#<%=lblid.ClientID %>').html(this.idbangunan);
                        $('#<%=txtid.ClientID %>').val(this.idbangunan);
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
