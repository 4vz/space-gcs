﻿<%@ Page Title="Input Pengeluaran" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="pengeluaran.aspx.cs" Inherits="Telkomsat.admin.pengeluaran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
<section class="col-lg-7 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Tambah Pengeluaran</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">

        <div class="form-group" id="userupd">
            <label for="exampleInputPassword1">Nama</label>
            <select id="sotugas" runat="server" class="select2 form-control" style="width: 100%;">
                <option></option>
            </select>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Kategori</label>
            <asp:DropDownList ID="ddlKategori" CssClass="form-control" runat="server">
                <asp:ListItem>--Kategori--</asp:ListItem>
                <asp:ListItem>Rek. Harkat Bendahara 1</asp:ListItem>
                <asp:ListItem>Rek. Harkat Bendahara 2</asp:ListItem>
                <asp:ListItem>Rek. ME Bendahara 1</asp:ListItem>
                <asp:ListItem>Rek. ME Bendahara 2</asp:ListItem>
                <asp:ListItem>Brankas Harkat</asp:ListItem>
                <asp:ListItem>Brankas ME</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group" id="divvendor" runat="server">
            <label for="exampleInputPassword1">Jenis</label>
            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" Width="100%" onchange="status(this)">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Vendor</asp:ListItem>
                        <asp:ListItem>Lain-lain</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group" id="uservendor" style="display:none">
            <label for="exampleInputPassword1">Vendor</label>
            <select id="sovendor" runat="server" class="select2 form-control" style="width: 100%;">
                <option></option>
            </select>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Nominal</label>
            <input type="text" class="form-control" id="nominal" runat="server" placeholder="Nominal" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Keterangan</label>
            <input type="text" class="form-control" id="keterangan" runat="server" placeholder="Keterangan"/>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Jenis</label>
            <asp:DropDownList ID="ddljenis" runat="server" class="form-control" Width="120px" onchange="status(this)">
                        <asp:ListItem>--jenis--</asp:ListItem>
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>Panjar</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group" id="file" style="display:none">
            <label for="exampleInputFile">File input</label>
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="false"/>
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
        <button type="submit" class="btn btn-primary" runat="server" onserverclick="Save_ServerClick">Submit</button>
        </div>
    </div>
    </section>
<section class="col-lg-5 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Pengeluaran Hari ini</h3>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <div class="box-body" style="min-height:200px;">
        <asp:DataList runat="server" id="datalist1" CssClass="table">
            <ItemTemplate>

            <asp:Label ID="NAMALabel" runat="server" class="namaLB pdg" Text="Pengeluaran"/>
            <span class="pull-right">
                <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# "Rp. " + Eval("input", "{0:N0}") %>' />
            </span>
            <br />
            <asp:Label ID="Label2" runat="server" class="namaLB pdg" Text="Dari"/>
            <span class="pull-right">
                <asp:Label ID="Label3" runat="server" class="kategoriLB" Text='<%# Eval("simpanan") %>' />
            </span>
            <br />
            <asp:Label ID="Label4" runat="server" class="namaLB pdg" Text="Jenis"/>
            <span class="pull-right">
                <asp:Label ID="Label5" runat="server" class='<%# Eval("status").ToString()=="done" ? "label label-sm label-success" : "label label-sm label-danger" %>' 
                    Text='<%# Eval("status").ToString()=="done" ? "Cash" : "Panjar" %>' />
            </span>
            <br />
                
            </ItemTemplate>
    </asp:DataList>
    </div>
    </div>
</section>
</div>
    <asp:TextBox ID="txtpetugas" CssClass="hidden" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtvendor" CssClass="hidden" runat="server"></asp:TextBox>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        function status(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
            //alert(userinput);
            if (statuslogbook == "Vendor") {
                document.getElementById('uservendor').style.display = 'block';
                document.getElementById('<%=sovendor.ClientID%>').selectedIndex = -1;
            }
            else {
                document.getElementById('uservendor').style.display = 'none';
                document.getElementById('<%=txtvendor.ClientID%>').value = '0';
                document.getElementById('tabledetail').style.display = 'none';
                
                $('#<%=sovendor.ClientID %>').empty();
            }
        }
        function detail(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
            //alert(userinput);
            if (statuslogbook == "Manual") {
                document.getElementById('tabledetail').style.display = 'block';
                document.getElementById('file').style.display = 'none';
            }
            else {
                document.getElementById('file').style.display = 'block';
                document.getElementById('tabledetail').style.display = 'none';     
            }
        }
    </script>
    <script type="text/javascript">
        /*$(document).ready(function () {
            var i = 0;
            $("#show").click(function () {
                var myfile = $("#myfile").val();
                var markup = "<tr><td><input type='button' onclick='remove(this);' class='close' value='x' name='record'></td><td>" + "<input type='text' class='form-control' name='mypanjar' />" + "</td>" +
                    "<td>" + "<input type='text' class='form-control' name='mydatapanjar' onkeydown='return numbersonly(this, event);' onkeyup='javascript:tandaPemisahTitik(this);' />" + "</td>" +
                    "<td>" + '<input type="file" class="fileku" name="fileinput"/>' + "</td>" + "</tr>";
                console.log(myfile);
                $('#' + '%= tableku.ClientID%>').append(markup);
                $("#datainput").val('');
                $("#nilaidata").val('');
            });
        });*/

        $(function () {
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
                url: "justifikasi.aspx/GetVendor",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var vendor3 = "CV Yeka Jaya"
                    $('#<%=sovendor.ClientID %>').empty();
                    $('#<%=sovendor.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sovendor.ClientID %>').append($('<option>',
                            {
                                value: this.idvendor,
                                text: this.vendor,
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
        });

        $('#<%=sovendor.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtvendor.ClientID%>').val(id);
        });

        $('#<%=sotugas.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtpetugas.ClientID%>').val(id);
        });

        /*function remove(button) {
            //Determine the reference of the Row using the Button.
            var row = $(button).closest("TR");
            var name = $("TD", row).eq(1).html();
            if (confirm("Do you want to delete: " + name)) {
 
                //Get the reference of the Table.
                var table = $('#' + '%= tableku.ClientID%>')[0];
 
                //Delete the Table row using it's Index.
                table.deleteRow(row[0].rowIndex);
            }
        };*/
    </script>

</asp:Content>
