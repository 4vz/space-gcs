<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="tambahrkap.aspx.cs" Inherits="Telkomsat.admin.tambahrkap" %>
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
        <h3 class="box-title">Tambah RKAP</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            <div class="alert alert-success alert-dismissable" id="divsuccess" runat="server" visible="false">
                <h5><span class="fa fa-check"> Berhasil ditambahkan</span></h5>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Kategori RKAP</label> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="sokategori" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="sokategori" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                            <option>Non Tematik</option> 
                            <option>Tematik</option> 
                        </select>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Nama Aktivitas</label> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtaktivitas"></asp:RequiredFieldValidator>
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
                <label for="exampleInputEmail1">Jenis Anggaran</label>
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
                <label for="exampleInputEmail1">Harga Satuan</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtnominal"></asp:RequiredFieldValidator>
                <input type="text" class="form-control" id="txtnominal" runat="server" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
            </div>
            <div class="form-group">
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
         
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
            <asp:Button ID="btnsubmit" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="Unnamed_ServerClick" />
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
        var j = 0;
        var rowCount = 0;

        $(function () {
            $.ajax({
                type: "POST",
                url: "tambahrkap.aspx/GetUnit",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=so2.ClientID %>').empty();
                    $('#<%=so2.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=so2.ClientID %>').append($('<option>',
                            {
                                value: this.unit,
                                text: this.unit,
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
                url: "tambahrkap.aspx/GetSub",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sosub.ClientID %>').empty();
                    $('#<%=sosub.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sosub.ClientID %>').append($('<option>',
                            {
                                value: this.subunit,
                                text: this.subunit,
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
                url: "tambahrkap.aspx/GetSatuan",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
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
                url: "tambahrkap.aspx/GetNamaAkun",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
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
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
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
            $('#<%=txtunit.ClientID %>').val(id);
        });

        $('#<%=sosub.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtsubunit.ClientID %>').val(id);
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
