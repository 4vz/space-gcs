<%@ Page Title="Edit Justifikasi" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="editjustifikasi.aspx.cs" Inherits="Telkomsat.admin.editjustifikasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <style>
        .rbl input[type="radio"]
        {
           margin-left: 10px;
           margin-right: 1px;
        }
    </style>
    <link rel="stylesheet" href="../assets/bower_components/select2/dist/css/select2.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtunit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtproker" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtbulan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtpetugas" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtvendor" runat="server" CssClass="hidden" Text="0"></asp:TextBox>

    <asp:TextBox ID="txtcount" CssClass="hidden" runat="server"></asp:TextBox>
    <div class="row">
    <section class="col-lg-12 connectedSortable">
    <div class="box box-primary">
     <asp:Panel ID="UserPanel" runat="server" DefaultButton="btnsubmit">
    <div class="box-header with-border">
        <h3 class="box-title">Edit Justifikasi</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            <div class="row">
                <div class="alert alert-danger alert-dismissable" id="divfail" runat="server" visible="false">
                    <h5><span class="fa fa-ban"> Nilai Justifikasi tidak boleh lebih dari nilai RKAP</span></h5>
                </div>
            </div>
            <div class="row">
                 <div class="col-md-5">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nomor Justifikasi</label>
                        <asp:Label ID="lblnj" runat="server" Text="" CssClass="pull-right" Font-Bold="true"></asp:Label>
                    </div>
                 </div>
               </div>    
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Jenis Usulan Permintaan Dana</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="rdjupd"></asp:RequiredFieldValidator>
                         <asp:RadioButtonList ID="rdjupd" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                             <asp:ListItem>Panjar</asp:ListItem>
                             <asp:ListItem>Cash</asp:ListItem>
                         </asp:RadioButtonList>
                    </div>
                 </div>
            </div>
            <div class="row">
                 <div class="col-md-3">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Jenis Anggaran</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="soja" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="soja" runat="server" class="form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>     
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Program Kerja</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="soproker" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="soproker" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>    
            <div class="row">
                 <div class="col-md-3">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nilai Sisa RKAP</label>
                        <input type="text" class="form-control" id="txtnilairkap" runat="server" readonly/>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-5">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Nama Kegiatan</label>
                         <input type="text" class="form-control" id="txtnamaket" runat="server"/>
                    </div>
                 </div>
                
            </div>
            
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nilai</label>
                         <asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="TextBox1" controltocompare="TextBox2" ForeColor="Red" operator="LessThan" type="Integer" errormessage="Tidak boleh lebih dari nilai RKAP " />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtnilai"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control nilaitext" id="txtnilai" runat="server" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-6">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Keterangan</label>
                        <input type="text" class="form-control" id="txtket" runat="server"/>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-6">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Detail</label>
                        <asp:TextBox ID="txtdetail" runat="server" TextMode="MultiLine" CssClass="form-control" Height="120px"></asp:TextBox>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-6">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Lampiran</label>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-6">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Evidence</label>
                        <div id="dvfiles">
                                <table class="table table-bordered kita" id="tableku" runat="server">
                                    <thead>
                                        <tr>
                                            <th>File</th>
                                            <th>Caption</th>
                                            <th>#</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                         <button id="addfile" type="button" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> 
                    </div>
                 </div>
                </div>
            <div class="row">
                 <div class="col-md-2">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Tanggal Dokumen Diserahkan</label>
                        <input type="text" class="form-control" id="txttglpsm" runat="server" autocomplete="off"/>
                    </div>
                 </div>
               </div>  
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Pemberi Tugas</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="sotugas" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="sotugas" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
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
    <asp:TextBox ID="TextBox1" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden"></asp:TextBox>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        var j = 0;
        var rowCount = 0;

        function calculateSum() {

            //.toFixed() method will roundoff the final sum to 2 decimal places
            var total = $('#<%=txtnilai.ClientID%>').val().replace(/\./g, '');
            var gt = $('#<%=txtnilairkap.ClientID%>').val().replace(/\./g, '');
            $('#<%=TextBox1.ClientID%>').val(total);
            $('#<%=TextBox2.ClientID%>').val(gt);
        }

        $('.select2').select2()

        $(function () {
            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetUnit",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var unit3 = $('#<%=txtunit.ClientID%>').val();
                    $('#<%=soja.ClientID %>').empty();
                    $('#<%=soja.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        $('#<%=soja.ClientID %>').append($('<option>',
                            {
                                value: this.unit,
                                text: this.unit,
                            }));
                    });
                    $('#<%=soja.ClientID %>').val(unit3);
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
                url: "editjustifikasi.aspx/GetProker",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var prok = $('#<%=txtproker.ClientID%>').val();
                    $('#<%=soproker.ClientID %>').empty();
                    $('#<%=soproker.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=soproker.ClientID %>').append($('<option>',
                            {
                                value: this.idproker,
                                text: this.proker,
                            }));
                    });
                    $('#<%=soproker.ClientID %>').val(petugas);
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
                url: "justifikasi.aspx/GetPIC",
                contentType: "application/json; charset=utf-8", 
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var petugas = $('#<%=txtpetugas.ClientID%>').val();
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
                    $('#<%=sotugas.ClientID %>').val(petugas);
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

            
        $('#<%=soproker.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtproker.ClientID%>').val(id);
            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetProkerHarga",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $(customers).each(function () {
                        $('#<%=txtnilairkap.ClientID%>').val("Rp. " + this.gt);
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

        $('#<%=sotugas.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtpetugas.ClientID%>').val(id);
        });

        $('#<%=soproker.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtproker.ClientID%>').val(id);
        });

        $('#<%=soja.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtunit.ClientID%>').val(id);
        });

        var i = 0;

        $(document).ready(function() {
            $("#addfile").click(function () {
                var markup = "<tr><td><input name=" + i + "fu type=file /></td><td><input type='text' name='caption' class='form-control' /></td>" +
                    "<td> <button type='button' name='record' onclick='newtest2(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>";
                $('#' + '<%= tableku.ClientID%>').append(markup);
                i++;
                console.log('add');
            });
            
        });   

        function newtest2(e) {              //Add e as parameter
            $(e).parents('tr').remove();   //Use the e to delete
            //console.log('klkl');
        }

        $('#<%=txttglpsm.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        })
    </script>
</asp:Content>
