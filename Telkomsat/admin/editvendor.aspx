<%@ Page Title="Edit Vendor" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="editvendor.aspx.cs" Inherits="Telkomsat.admin.editvendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtbankper" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtbankpic" runat="server" CssClass="hidden"></asp:TextBox>
<div class="row">
    <section class="col-lg-6 connectedSortable">
    <div class="box box-primary">
     <asp:Panel ID="UserPanel" runat="server" DefaultButton="btnsubmit">
    <div class="box-header with-border">
        <h3 class="box-title">Edit Vendor</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            
            <div class="form-group">
                <label for="exampleInputEmail1">Nama Perusahaan</label>
                <input type="text" class="form-control" id="txtperusahaan" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Jenis Perusahaan</label>
                <asp:DropDownList ID="ddljp" runat="server" CssClass="form-control">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>PKP</asp:ListItem>
                    <asp:ListItem>Non PKP</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">NPWP Perusahaan</label>
                <input type="text" class="form-control" id="txtnpwpper" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nomor Telepon</label>
                <input type="text" class="form-control" id="txttelpper" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Email</label>
                <input type="text" class="form-control" id="txtemailper" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nama Bank</label>
                <select id="sobankper" runat="server" class="select2 form-control" style="width: 100%;">
                    <option></option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nomor Rekening</label>
                <input type="text" class="form-control" id="txtrekper" runat="server"/>
            </div>
            <h4 style="margin-top:20px">PIC Perusahaan</h4>
            <div class="form-group">
                <label for="exampleInputPassword1">Nama PIC</label>
                <input type="text" class="form-control" id="txtpic" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nomor Telepon</label>
                <input type="text" class="form-control" id="txttelppic" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Email</label>
                <input type="text" class="form-control" id="txtemailpic" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nama Bank</label>
                <select id="sobankpic" runat="server" class="select2 form-control" style="width: 100%;">
                    <option></option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nomor Rekening</label>
                <input type="text" class="form-control" id="txtrekpic" runat="server"/>
            </div>
            
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
            <asp:Button ID="btnsubmit" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="save_click" />
        </div>
        </asp:Panel>
    </div>
    </section>
</div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        $(function () {
            $.ajax({
                type: "POST",
                url: "perusahaan.aspx/GetBank",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var bank = $('#<%=txtbankper.ClientID%>').val();
                    $('#<%=sobankper.ClientID %>').empty();
                    $('#<%=sobankper.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sobankper.ClientID %>').append($('<option>',
                            {
                                value: this.bank,
                                text: this.bank,
                            }));
                    });
                    $('#<%=sobankper.ClientID %>').val(bank);

                    var customers = response.d;
                    var bankpic = $('#<%=txtbankpic.ClientID%>').val();
                    $('#<%=sobankpic.ClientID %>').empty();
                    $('#<%=sobankpic.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sobankpic.ClientID %>').append($('<option>',
                            {
                                value: this.bank,
                                text: this.bank,
                            }));
                    });
                    $('#<%=sobankpic.ClientID %>').val(bankpic);
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

        $('#<%=sobankper.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtbankper.ClientID %>').val(id);
        });

        $('#<%=sobankpic.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtbankpic.ClientID %>').val(id);
        });
    </script>
</asp:Content>
