<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="editrkap2.aspx.cs" Inherits="Telkomsat.admin.editrkap2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtunit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtsubunit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtnamaakun" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtsatuan" runat="server" CssClass="hidden"></asp:TextBox>

    <asp:TextBox ID="txtcount" CssClass="hidden" runat="server"></asp:TextBox>
    <div class="row">
    <section class="col-lg-6 connectedSortable">
    <div class="box box-primary">
     <asp:Panel ID="UserPanel" runat="server" DefaultButton="btnsubmit">
    <div class="box-header with-border">
        <h3 class="box-title">Edit RKAP</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            
            <div class="form-group">
                <label for="exampleInputEmail1">Nama Aktivitas</label>
                <input type="text" class="form-control" id="txtaktivitas" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Unit</label>
                <select id="so2" runat="server" class="select2 form-control" style="width: 100%;">
                    <option></option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Sub Unit</label>
                <select id="sosub" runat="server" class="select2 form-control" style="width: 100%;">
                    <option></option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Cost Center</label>
                <input type="text" class="form-control" id="txtcc" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nomor Akun</label>
                <input type="text" class="form-control" id="txtnoakun" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nama Akun</label>
                <select id="sonamaakun" runat="server" class="select2 form-control" style="width: 100%;">
                    <option></option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Satuan</label>
                <select id="sosatuan" runat="server" class="select2 form-control" style="width: 100%;">
                    <option></option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Harga</label>
                <input type="text" class="form-control" id="txtnominal" runat="server" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Volume Bulanan</label>
                <div class="table-responsive">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
            <div class="form-group">
                <div class="table-responsive">
                    <table class="table table-bordered kita" id="tableku" runat="server">
                    <thead>
                        <tr>
                            <th>Volume Bulan</th>
                            <th>Jumlah Volume</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><input type="text" class="form-control" value="Januari" id="Text1" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtjanuari" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Februari" id="Text2" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtfebruari" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Maret" id="Text4" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtmaret" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="April" id="Text6" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtapril" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Mei" id="Text8" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtmei" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Juni" id="Text10" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtjuni" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Juli" id="Text12" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtjuli" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Agustus" id="Text14" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtagustus" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="September" id="Text16" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtseptember" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Oktober" id="Text18" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtoktober" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="November" id="Text20" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtnovemb" runat="server"  name="jumlah"/></td >
                        </tr>
                        <tr>
                            <td><input type="text" class="form-control" value="Desember" id="Text22" runat="server" readonly/></td >
                            <td><input type="number" class="form-control" id="txtdesember" runat="server" name="jumlah"/></td >
                        </tr>
                    </tbody>
                </table>
                </div>
                <button id="addfile" type="button" class="btn-sm btn-default" hidden="hidden"><i class="fa fa-plus"></i></button> <br />
            </div>
         
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
            <asp:Button ID="btnsubmit" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="Unnamed_ServerClick" />
        </div>
        </asp:Panel>
    </div>
    </section>
</div>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        var j = 0;
        var rowCount = 0;

        $(function () {
            $.ajax({
                type: "POST",
                url: "rkap.aspx/GetUnit",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=so2.ClientID %>').empty();
                    var unit3 = $('#<%=txtsubunit.ClientID%>').val();
                    $('#<%=so2.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(unit3 + " ini oy");
                        $('#<%=so2.ClientID %>').append($('<option>',
                            {
                                value: this.unit,
                                text: this.unit,
                            }));
                    });
                    $('#<%=so2.ClientID %>').val(unit3);
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
                url: "rkap.aspx/GetSub",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var unit = $('#<%=txtunit.ClientID%>').val();
                    $('#<%=sosub.ClientID %>').empty();
                    $('#<%=sosub.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(unit + " oh");
                        $('#<%=sosub.ClientID %>').append($('<option>',
                            {
                                value: this.subunit,
                                text: this.subunit,
                            }));
                    });
                    $('#<%=sosub.ClientID %>').val(unit);
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
                url: "rkap.aspx/GetSatuan",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var satuan = $('#<%=txtsatuan.ClientID%>').val();
                    $('#<%=sosatuan.ClientID %>').empty();
                    $('#<%=sosatuan.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sosatuan.ClientID %>').append($('<option>',
                            {
                                value: this.satuan,
                                text: this.satuan,
                            }));
                    });
                    $('#<%=sosatuan.ClientID %>').val(satuan);
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
                url: "rkap.aspx/GetNamaAkun",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var akun = $('#<%=txtnamaakun.ClientID%>').val();
                    $('#<%=sonamaakun.ClientID %>').empty();
                    $('#<%=sonamaakun.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sonamaakun.ClientID %>').append($('<option>',
                            {
                                value: this.namaakun,
                                text: this.namaakun,
                            }));
                    });
                    $('#<%=sonamaakun.ClientID %>').val(akun);
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
            
        });


        $(document).ready(function () {
            var i = 0;
            $("#addfile").click(function () {
                var markup = "<tr><td><select class='form-control' name='bulanan'>" +
                                    "<option>Januari</option>" +
                                    "<option>Februari</option>" +
                                    "<option>Maret</option>" +
                                    "<option>April</option>" +
                                    "<option>Mei</option>" +
                                    "<option>Juni</option>" +
                                    "<option>Juli</option>" +
                                    "<option>Agustus</option>" +
                                    "<option>September</option>" +
                                    "<option>Oktober</option>" +
                                    "<option>November</option>" +
                                    "<option>Desember</option>" +
                             "</select ></td > " +
                    "<td><input type='number' name='jumlah' class='form-control' /></td>" +
                    "<td><button type='button' name='record' onclick='newtest2(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>";

                $('#' + '<%= tableku.ClientID%>').append(markup);
                i++;
                $('#' + '<%=txtcount.ClientID%>').val(i);
            });
            
        });  
        function newtest2(e) {              //Add e as parameter
            $(e).parents('tr').remove();   //Use the e to delete
            //console.log('klkl');
            j = $('#' + '<%=txtcount.ClientID%>').val() - 1;
            $('#' + '<%=txtcount.ClientID%>').val(j);

        }

        $('#<%=so2.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtsubunit.ClientID %>').val(id);
        });

        $('#<%=sosub.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtunit.ClientID %>').val(id);
        });

        $('#<%=sosatuan.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtsatuan.ClientID %>').val(id);
        });

        $('#<%=sonamaakun.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtnamaakun.ClientID %>').val(id);
        });
    </script>
</asp:Content>
