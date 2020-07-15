<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="justifikasi.aspx.cs" Inherits="Telkomsat.admin.justifikasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <style>
        .rbl input[type="radio"]
        {
           margin-left: 10px;
           margin-right: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtunit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtproker" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtpetugas" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtvendor" runat="server" CssClass="hidden"></asp:TextBox>

    <asp:TextBox ID="txtcount" CssClass="hidden" runat="server"></asp:TextBox>
    <div class="row">
    <section class="col-lg-12 connectedSortable">
    <div class="box box-primary">
     <asp:Panel ID="UserPanel" runat="server" DefaultButton="btnsubmit">
    <div class="box-header with-border">
        <h3 class="box-title">Tambah Justifikasi</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Jenis UPD</label>
                         <asp:RadioButtonList ID="rdjupd" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                             <asp:ListItem>Panjar</asp:ListItem>
                             <asp:ListItem>Cash</asp:ListItem>
                         </asp:RadioButtonList>
                    </div>
                 </div>
                <div class="col-md-2">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Tanggal</label>
                        <input type="text" class="form-control" id="txttanggal" runat="server"/>
                    </div>
                 </div>
            </div>
            <div class="row">
                 <div class="col-md-2">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Jenis Anggaran</label>
                        <select id="soja" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>     
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Program Kerja</label>
                        <select id="soproker" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>    
            <div class="row">
                 <div class="col-md-3">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nilai RKAP</label>
                        <input type="text" class="form-control" id="txtnilairkap" runat="server" readonly/>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-3">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Nama Kegiatan</label>
                         <input type="text" class="form-control" id="txtnamaket" runat="server"/>
                    </div>
                 </div>
                <div class="col-md-3">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Nomor Justifikasi</label>
                        <input type="text" class="form-control" id="txtnojus" runat="server"/>
                    </div>
                 </div>
            </div>
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Comply</label>
                        <asp:RadioButtonList ID="rdcomply" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                             <asp:ListItem>Iya</asp:ListItem>
                             <asp:ListItem>Tidak</asp:ListItem>
                         </asp:RadioButtonList>
                    </div>
                 </div>
               </div> 
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nama Vendor</label>
                        <select id="sovendor" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>  
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nilai</label>
                        <input type="text" class="form-control" id="txtnilai" runat="server" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
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
                        <input type="text" class="form-control" id="txttglpsm" runat="server"/>
                    </div>
                 </div>
               </div>  
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Pemberi Tugas</label>
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
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        var j = 0;
        var rowCount = 0;

        $(function () {
            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetUnit",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=soja.ClientID %>').empty();
                    $('#<%=soja.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        $('#<%=soja.ClientID %>').append($('<option>',
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
                url: "justifikasi.aspx/GetProker",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
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
                    $('#<%=sovendor.ClientID %>').val("1");
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

        $('#<%=sovendor.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtvendor.ClientID%>').val(id);
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

        $('#<%=txttanggal.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        });

        $('#<%=txttglpsm.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        })
    </script>
</asp:Content>
