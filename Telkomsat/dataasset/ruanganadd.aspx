<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="ruanganadd.aspx.cs" Inherits="Telkomsat.dataasset.ruanganadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div class="col-md-9">
        <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden"></asp:TextBox>
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Ruangan</h3>
            
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="alert alert-success alert-dismissable" id="divsuccess" runat="server" visible="false">
                <h4><span class="fa fa-check"> Berhasil</span></h4>
                berhasil ditambahkan
            </div>
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Nama Ruangan :</label>
                    <asp:TextBox ID="txtbangunan" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">QR Ruangan :</label>
                    <asp:TextBox ID="txtqr" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label style="font-size:16px">Nama Wilayah :</label>
                    <select id="so2" runat="server" class="select2 form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
                <div class="form-group">
                    <label style="font-size:16px">Nama Bangunan :</label>
                    <select id="so3" runat="server" class="select2 form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
            </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer no-padding">
            <div class="mailbox-controls">
                <button type="button"  class=" btn btn-danger btn-sm pull-right" runat="server" onserverclick="Tambah_ServerClick"> Tambah</button>
            <!-- /.pull-right -->
            </div>
        </div>
           
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    </div>
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script type="text/javascript">  
        function fungsi() {
            alert("Berhasil Disimpan");
        }

        $(function () {
            $('#<%=so2.ClientID %>').append('<option value="">' + "--Pilih Wilayah--" + '</option>');
            $.ajax({
                type: "POST",
                url: "bangunanadd.aspx/GetID",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=so2.ClientID %>').empty();
                    $('#<%=so2.ClientID %>').append('<option>' + '</option>');
                    $(customers).each(function () {
                        console.log(this.idwilayah);
                        $('#<%=so2.ClientID %>').append($('<option>',
                            {
                                value: this.idwilayah,
                                text: this.wilayah,
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

            $('#<%=HiddenField1.ClientID %>').val($('#<%=so2.ClientID %>').val());
        });

        $('#<%=so2.ClientID %>').change(function () {
            $('#<%=so3.ClientID %>').empty();
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "ruanganadd.aspx/Getbangunan",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=so3.ClientID %>').empty();
                    $('#<%=so3.ClientID %>').append('<option value=0>' + '--Pilih Bangunan--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=so3.ClientID %>').append('<option value="' + this.idbangunan + '">' + this.bangunan + '</option>');
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

        $('#<%=so3.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=TextBox2.ClientID %>').val(id);
        });
    </script>
</asp:Content>
