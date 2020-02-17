<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="deviceadd.aspx.cs" Inherits="Telkomsat.dataasset.deviceadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div class="col-md-9">
        <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden"></asp:TextBox>
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Bangunan</h3>
            
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
                    <label style="font-size:16px; font-weight:bold">Nama Bangunan :</label>
                    <asp:TextBox ID="txtbangunan" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label style="font-size:16px">Nama Wilayah :</label>
                    <select id="so2" runat="server" class="select2 form-control" style="width: 100%;">
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
    <script type="text/javascript">  
        function fungsi() {
            alert("Berhasil Disimpan");
        }

        $(function () {
            $('#<%=so2.ClientID %>').append('<option value="">' + "--Pilih Equipment--" + '</option>');
            $.ajax({
                type: "POST",
                url: "deviceadd.aspx/GetID",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=so2.ClientID %>').empty();
                    $('#<%=so2.ClientID %>').append('<option>' + '</option>');
                    $(customers).each(function () {
                        console.log(this.equipments);
                        $('#<%=so2.ClientID %>').append($('<option>',
                            {
                                value: this.idequipment,
                                text: this.equipments,
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

            $('.select2').select2({
                allowClear: true,
                placeholder: "--Pilih Equipment--",
            });

            $('#<%=HiddenField1.ClientID %>').val($('#<%=so2.ClientID %>').val());
        });

        $('#<%=so2.ClientID %>').select2().on('change', function () {
            var id = $(this).val();
            $('#<%=TextBox2.ClientID %>').val(id);
        });
    </script>
</asp:Content>
