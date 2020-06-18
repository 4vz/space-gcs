<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Telkomsat.datalogbook.add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <style type="text/css">
        .row{
            padding-bottom:16px;
        }
        .ui-autocomplete { z-index:2147483647; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:TextBox ID="txtdevice" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtdevice1" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtsite" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtgedung" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtruangan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtrak" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtruanganid" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtrakid" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidp" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidpfung" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidl" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtjenispekerjaan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtstart" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtend" runat="server" CssClass="hidden"></asp:TextBox>
    <div class="box box-default">
        <div class="box-header">
            <h4>Tambah Logbook</h4>
        </div>
        <div class="box-body">
            <div class="row">
                <div class="col-md-12">
                    <div class="alert alert-success alert-dismissable" id="divsuccess" runat="server" visible="false">
                        <h5><span class="fa fa-check"> Berhasil ditambahkan</span></h5>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="Label1" runat="server" Text="Mulai Kegiatan" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:TextBox ID="txtstartdate" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="Label2" runat="server" Text="Perkiraan selesai" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:TextBox ID="txtduedate" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label3" runat="server" Text="Judul Kegiatan" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:TextBox ID="txtjudul" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label4" runat="server" Text="Unit Divisi" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:DropDownList ID="ddlunit" runat="server" CssClass="form-control">
                                <asp:ListItem>--Pilih Divisi--</asp:ListItem>
                                <asp:ListItem>Harkat</asp:ListItem>
                                <asp:ListItem>ME</asp:ListItem>
                                <asp:ListItem>SCO</asp:ListItem>
                                <asp:ListItem>Andat</asp:ListItem>
                                <asp:ListItem>Orbital</asp:ListItem>
                                <asp:ListItem>STS</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label5" runat="server" Text="Status Kegiatan" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control">
                                <asp:ListItem>--Pilih Status--</asp:ListItem>
                                <asp:ListItem>On Progress</asp:ListItem>
                                <asp:ListItem>Selesai</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="Label6" runat="server" Text="PIC Internal" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:TextBox ID="txtint" placeholder="PIC bisa lebih dari 1 (pisahkan dengan tanda ;)" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="Label7" runat="server" Text="PIC External" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtext" placeholder="PIC bisa lebih dari 1 (pisahkan dengan tanda ;)" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label8" runat="server" Text="Kategori Kegiatan" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:DropDownList ID="ddlkategori" runat="server" CssClass="form-control">
                                <asp:ListItem>--Pilih Kategori Kegiatan--</asp:ListItem>
                                <asp:ListItem>Pointing Antena</asp:ListItem>
                                <asp:ListItem>Perbaikan</asp:ListItem>
                                <asp:ListItem>Perawatan</asp:ListItem>
                                <asp:ListItem>Penggantian</asp:ListItem>
                                <asp:ListItem>Troubleshot</asp:ListItem>
                                <asp:ListItem>Update/Upgrade</asp:ListItem>
                                <asp:ListItem>Lain-lain</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label9" runat="server" Text="Deskripsi Kegiatan" Font-Bold="true"></asp:Label><span style="color:red"> *</span>
                            <asp:TextBox ID="txtAktivitas" TextMode="MultiLine" runat="server" Height="100px" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-8 col-sm-12">
                             <label for="exampleInputFile">Sub Pekerjaan</label><span style="color:red"> *</span>
                            <button type="button" class="btn btn-block btn-primary dropdown-toggle" data-toggle="dropdown" style="width:160px"><i class="fa fa-plus"></i>  Tambah Pekerjaan <span class="caret"></span></button>
                            <ul class="dropdown-menu">
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#" data-toggle="modal" data-id="mutasi" data-target="#modalupdate" id="btnmutasi">Mutasi Asset</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#" data-toggle="modal" data-id="statusaset" data-target="#modalfungsi" id="btnstatus">Status Asset</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#" data-toggle="modal" data-id="maintenance" data-target="#modalmaintenance" id="btnmain">Maintenance</a></li>
                            </ul>
                            <table class="table table-bordered kita tbsub" id="tablemain" runat="server">
                                <thead>
                                    <tr>
                                        <th>Startdate</th>
                                        <th>Enddate</th>
                                        <th>Status</th>
                                        <th>Deskripsi</th>
                                        <th>#</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <label for="exampleInputFile">Lampiran</label><span style="color:red"> *</span>
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
                            <button id="addfile" type="button" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="box-footer">
            <button type="submit" class="btn btn-default pull-right" runat="server" onclick="return checkDecision();" onserverclick="Unnamed_ServerClick">Submit</button>
        </div>
    </div>
    <div class="box box-solid">
        <div class="box-header">
            <h4>Logbook Hari Ini</h4>
        </div>
        <div class="box-body">
            <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
        </div>
        <div class="box-footer">

        </div>
     </div>
    <button id="btnbtn" class="btn btn-default pull-right hidden" runat="server" onserverclick="Unnamed_ServerClick">Submit</button>
    <asp:HiddenField ID="HiddenField1" runat="server" />
   <div class="modal fade" id="modalupdate">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Mutasi</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Serial Number Asset :</label>
                                <asp:TextBox ID="txtruang" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Awal :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtsdate" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Akhir :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtedate" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Status :</label>
                                <asp:DropDownList ID="ddlstatusmut" runat="server" CssClass="form-control">
                                    <asp:ListItem>--Pilih Status--</asp:ListItem>
                                    <asp:ListItem>On Progress</asp:ListItem>
                                    <asp:ListItem>Selesai</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div>
                      <div class="col-md-6">
                            <div>
                                <h4>Lokasi Sebelum</h4>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Nama Wilayah :</label>
                                <asp:Label ID="lblwilayah" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Bangunan :</label>
                                <asp:Label ID="lblbangunan" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Ruangan :</label>
                                <asp:Label ID="lblruangan" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Rak :</label>
                                <asp:Label ID="lblraak" runat="server" Text=""></asp:Label>
                            </div>
                      </div>
                      
                      <div class="col-md-6">
                            <div>
                                <h4>Lokasi Setelah</h4>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Nama Wilayah :</label>
                                <select id="slsite" runat="server" class="form-control" style="width: 100%;"></select>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Bangunan :</label>
                                <select id="slgedung" runat="server" class="form-control" style="width: 100%;"></select>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Ruangan :</label>
                                <select id="slruang" runat="server" class="form-control" style="width: 100%;"></select>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Rak :</label>
                                <select id="slrak" runat="server" class="form-control" style="width: 100%;"></select>
                            </div>
                      </div>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Mutasi_ServerClick1">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

        <div class="modal fade" id="modalfungsi">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Fungsi & Status</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Serial Number Asset :</label>
                                <asp:TextBox ID="txtsnfung" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Awal :</label>
                             <input type="text" class="form-control pull-right" id="txtsdatefung" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Akhir :</label>
                             <input type="text" class="form-control pull-right" id="txtedatefung" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Status :</label>
                                <asp:DropDownList ID="ddlstatusf" runat="server" CssClass="form-control">
                                    <asp:ListItem>--Pilih Status--</asp:ListItem>
                                    <asp:ListItem>On Progress</asp:ListItem>
                                    <asp:ListItem>Selesai</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div>
                      <div class="col-md-6">
                            <div>
                                <h4>Keterangan Sebelum</h4>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Fungsi :</label>
                                <asp:Label ID="lbfungsi" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Status :</label>
                                <asp:Label ID="lbstatus" runat="server" Text="Label"></asp:Label>
                            </div>
                      </div>
                      <div class="col-md-6">
                            <div>
                                <h4>Keterangan Setelah</h4>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Fungsi </label>
                                <asp:DropDownList ID="ddlFungsifung" runat="server" class="form-control">
                                    <asp:ListItem>--Pilih Fungsi--</asp:ListItem>
                                    <asp:ListItem>OPERASIONAL</asp:ListItem>
                                    <asp:ListItem>BACKUP</asp:ListItem>
                                    <asp:ListItem>SPARE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Status :</label>
                                <asp:DropDownList ID="ddlStatusfung" runat="server" class="form-control">
                                    <asp:ListItem>--Pilih Status--</asp:ListItem>
                                    <asp:ListItem>BAIK</asp:ListItem>
                                    <asp:ListItem>PERBAIKAN</asp:ListItem>
                                    <asp:ListItem>RUSAK</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Keterangan :</label>
                                <asp:TextBox ID="txtKet" TextMode="MultiLine" Height="100px" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                      </div>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Fungsi_ServerClick1">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>
        
        <div class="modal fade" id="modalmaintenance">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Maintenance</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Awal :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtsdatemain" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Akhir :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtedatemain" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Status :</label>
                                <select class="form-control" runat="server" id="ddlstatusmain">
                                    <option>On Progress</option>
                                    <option>Selesai</option>
                                </select>
                                
                            </div>
                      </div>
                      <div class="col-md-12">
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Keterangan :</label>
                                <asp:TextBox ID="txtketmain" CssClass="form-control" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                            </div> 
                      </div>
                      <div class="col-md-12">
                            <label for="exampleInputFile">Lampiran</label>
                            <asp:FileUpload ID="fileuploadmain" runat="server" AllowMultiple="true"/>
                        </div>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left add-row" runat="server" data-dismiss="modal" aria-label="Close">Simpan</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

    <script>
        var i = 1;
        var rowCount = 0;

        $(document).ready(function() {
            $("#addfile").click(function () {
                var markup = "<tr><td><input name=" + i + "fu type=file /></td><td><input type='text' name='caption' class='form-control' /></td>" +
                    "<td> <button type='button' name='record' onclick='newtest2(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>";
                $('#' + '<%= tableku.ClientID%>').append(markup);
                i++;
                console.log('add');
            });
            
            $(".add-row").click(function () {
                var startdate = $('#<%=txtsdatemain.ClientID%>').val();
                var enddate = $('#<%=txtedatemain.ClientID%>').val();
                var keterangan = $('#<%=txtketmain.ClientID%>').val();
                var status = $('#<%=ddlstatusmain.ClientID%>').val();

                var markup = "<tr><td>" + "<input type='text' readonly class='form-control' name='nmstartdate' value='" + startdate + "' />" + "</td>" +
                    "<td>" + "<input type='text' readonly class='form-control' name='nmenddate' value='" + enddate + "' />" + "</td>" +
                    "<td>" + "<input type='text' readonly class='form-control' name='nmstatus' value='" + status + "' />" + "</td>" +
                    "<td>" + "<input type='text' readonly class='form-control' name='nmketerangan' value='" + keterangan + "' />" + "</td>" +
                    "<td> <button type='button' name='record' onclick='delmain(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>" +
                    "</tr>";

                console.log($("input[name='nmketerangan']").val());
                rowCount++;
                $('#<%=HiddenField1.ClientID%>').val(rowCount);
                console.log(rowCount);
           
                $('#' + '<%= tablemain.ClientID%>').append(markup);
                $('#<%=txtsdatemain.ClientID%>').val('');
                $('#<%=txtedatemain.ClientID%>').val('');
                $('#<%=ddlstatusmain.ClientID%>').val('');
                $('#<%=txtketmain.ClientID%>').val('');
            });

            
        });   

        function checkDecision() {
            if ($("input[name='nmketerangan']").val() == null) {
                alert("Minimal isi 1 sub pekerjaan !");
                return false;
            }
            else {
                $('#<%=btnbtn.ClientID%>').click();
            }
        }

        function newtest2(e) {              //Add e as parameter
            $(e).parents('tr').remove();   //Use the e to delete
            //console.log('klkl');
        }

        function delmain(e) {              //Add e as parameter
            $(e).parents('tr').remove();   //Use the e to delete
            rowCount--;
            $('#<%=HiddenField1.ClientID%>').val(rowCount);
            //console.log('klkl');
        }

        $(function () {
            //CKEDITOR.replace('<txtAktivitas.ClientID%>');
        })

        $(document).on("click", "#btnmutasi", function () {
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            $('#<%=txtidl.ClientID %>').val(id);
            $('#<%=txtjenispekerjaan.ClientID %>').val('Mutasi');
        });

        $(document).on("click", "#btnkonfigurasi", function () {
            $(".datepick").datepicker({startDate:null,autoclose: true,
            format: 'yyyy/mm/dd' ,endDate :null});
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            $('#<%=txtidl.ClientID %>').val(id);
        });

        $(document).on("click", "#btnmain", function () {
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            $('#<%=txtidl.ClientID %>').val(id);
        });

        $(document).on("click", "#btnlain", function () {
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            $('#<%=txtidl.ClientID %>').val(id);
        });

        $(document).on("click", "#btnstatus", function () {
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            $('#<%=txtidl.ClientID %>').val(id);
        });

        $(document).ready(function () {
            var select = false;
            var select1 = false;

            $('#<%=txtruang.ClientID %>').autocomplete({
                source: '../dataasset/HandlerSN.ashx',
                autoFocus: true,
                selectFirst: true,
                open: function(event, ui) { if(select) select=false; },
                select: function (event, ui) {
                    console.log(ui.item);
                    if (ui.item) {                     
                        var id = ui.item.value;
                        $.ajax({
                            type: "POST",
                            url: "tambah.aspx/Getsn",
                            contentType: "application/json; charset=utf-8",
                            data: '{videoid:"' + id + '"}',
                            dataType: "json",
                            success: function (response) {
                                var customers = response.d;
                                $(customers).each(function () {
                                    $('#<%=lblwilayah.ClientID %>').html(this.site);
                                    $('#<%=lblbangunan.ClientID %>').html(this.bangunan);
                                    $('#<%=lblruangan.ClientID %>').html(this.ruangan);
                                    $('#<%=lblraak.ClientID %>').html(this.rak);
                                    $('#<%=txtidp.ClientID %>').val(this.idperangkat);
                                    $('#<%=txtruanganid.ClientID %>').val(this.ruanganid);
                                    $('#<%=txtrakid.ClientID %>').val(this.rakid);
                                    $('#<%=txtdevice.ClientID %>').val(this.device);
                                });
                            },
                            failure: function (response) {
                                alert(response.d);
                            },
                            error: function (response) {
                                alert(response.d);
                            }
                        });
                    }
                    select = true;
                },
            }).blur(function(){
                if (!select) {
                    $('#<%=txtruang.ClientID %>').val($('ul.ui-autocomplete li.ui-menu-item:first div').text());
                    var id = $('ul.ui-autocomplete li.ui-menu-item:first div').text();
                    $.ajax({
                        type: "POST",
                        url: "tambah.aspx/Getsn",
                        contentType: "application/json; charset=utf-8",
                        data: '{videoid:"' + id + '"}',
                        dataType: "json",
                        success: function (response) {
                            var customers = response.d;
                            $(customers).each(function () {
                                $('#<%=lblwilayah.ClientID %>').html(this.site);
                                $('#<%=lblbangunan.ClientID %>').html(this.bangunan);
                                $('#<%=lblruangan.ClientID %>').html(this.ruangan);
                                $('#<%=lblraak.ClientID %>').html(this.rak);
                                $('#<%=txtidp.ClientID %>').val(this.idperangkat);
                                $('#<%=txtruanganid.ClientID %>').val(this.ruanganid);
                                $('#<%=txtrakid.ClientID %>').val(this.rakid);
                                $('#<%=txtdevice.ClientID %>').val(this.device);
                            });
                        },
                        failure: function (response) {
                            alert(response.d);
                        },
                        error: function (response) {
                            alert(response.d);
                        }
                    });
                }
            });

            $('#<%=txtsnfung.ClientID %>').autocomplete({
                source: '../dataasset/HandlerSN.ashx',
                autoFocus: true,
                selectFirst: true,
                open: function(event, ui) { if(select1) select1=false; },
                select: function (event, ui) {
                    console.log(ui.item);
                    if (ui.item) {                     
                        var id = ui.item.value;
                        $.ajax({
                            type: "POST",
                            url: "tambah.aspx/Getfungsi",
                            contentType: "application/json; charset=utf-8",
                            data: '{idf:"' + id + '"}',
                            dataType: "json",
                            success: function (response) {
                                var customers = response.d;
                                $(customers).each(function () {
                                     $('#<%=lbfungsi.ClientID %>').html(this.fungsi);
                                    $('#<%=lbstatus.ClientID %>').html(this.status);
                                    $('#<%=txtdevice1.ClientID %>').val(this.devicefung);
                                    $('#<%=txtidpfung.ClientID %>').val(this.idperangkatfung);
                                });
                            },
                            failure: function (response) {
                                alert(response.d);
                            },
                            error: function (response) {
                                alert(response.d);
                            }
                        });
                    }
                    select1 = true;
                },
            }).blur(function () {
                if (!select1) {
                    $('#<%=txtsnfung.ClientID %>').val($('ul.ui-autocomplete li.ui-menu-item:first div').text());
                    var id = $('ul.ui-autocomplete li.ui-menu-item:first div').text();
                    $.ajax({
                        type: "POST",
                        url: "tambah.aspx/Getfungsi",
                        contentType: "application/json; charset=utf-8",
                        data: '{idf:"' + id + '"}',
                        dataType: "json",
                        success: function (response) {
                            var customers = response.d;
                            $(customers).each(function () {
                                 $('#<%=lbfungsi.ClientID %>').html(this.fungsi);
                                    $('#<%=lbstatus.ClientID %>').html(this.status);
                                    $('#<%=txtdevice1.ClientID %>').val(this.devicefung);
                                    $('#<%=txtidpfung.ClientID %>').val(this.idperangkatfung);
                            });
                        },
                        failure: function (response) {
                            alert(response.d);
                        },
                        error: function (response) {
                            alert(response.d);
                        }
                    });
                }
            });

            $.ajax({
                type: "POST",
                url: "tambah.aspx/Getwilayah",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slsite.ClientID %>').empty();
                    $('#<%=slsite.ClientID %>').append('<option value=0>' + '--Pilih Wilayah--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.idwilayah);
                        $('#<%=slsite.ClientID %>').append('<option value="' + this.idwilayah + '">' + this.wilayah + '</option>');
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

        $('#<%=slsite.ClientID %>').change(function () {
                $('#<%=slgedung.ClientID %>').empty();
                var id = $(this).val();
                $.ajax({
                    type: "POST",
                    url: "tambah.aspx/Getbangunan",
                    contentType: "application/json; charset=utf-8",
                    data: '{videoid:"' + id + '"}',
                    dataType: "json",
                    success: function (response) {
                        var customers = response.d;
                        $('#<%=slgedung.ClientID %>').empty();
                        $('#<%=slgedung.ClientID %>').append('<option value=0>' + '--Pilih Bangunan--' + '</option>');
                        $(customers).each(function () {
                            console.log(this.idbangunan);
                            $('#<%=slgedung.ClientID %>').append('<option value="' + this.idbangunan + '">' + this.bangunan1 + '</option>');
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
        $('#<%=slgedung.ClientID %>').change(function () {
            $('#<%=slruang.ClientID %>').empty();
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "tambah.aspx/Getruangan",
                contentType: "application/json; charset=utf-8",
                data: '{sobangunan:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slruang.ClientID %>').empty();
                    $('#<%=slruang.ClientID %>').append('<option value=0>' + '--Pilih Ruangan--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.ruangan);
                        $('#<%=slruang.ClientID %>').append('<option value="' + this.idruangan + '">' + this.ruangan1 + '</option>');
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

        $('#<%=slruang.ClientID %>').change(function () {
            $('#<%=slrak.ClientID %>').empty();
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "tambah.aspx/Getrak",
                contentType: "application/json; charset=utf-8",
                data: '{soruangan:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slrak.ClientID %>').empty();
                    $('#<%=slrak.ClientID %>').append('<option value=0>' + '--Pilih Rak--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.rak);
                        $('#<%=slrak.ClientID %>').append('<option value="' + this.idrak + '">' + this.rak1 + '</option>');
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

        $('#<%=txtstartdate.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtduedate.ClientID%>').datepicker('setStartDate', minDate);
        });
        $('#' + '<%=txtduedate.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtstartdate.ClientID%>').datepicker('setEndDate', minDate);
            });

        $('#<%=txtsdate.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtedate.ClientID%>').datepicker('setStartDate', minDate);
        });
        $('#' + '<%=txtedate.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtsdate.ClientID%>').datepicker('setEndDate', minDate);
            });

        $('#<%=txtsdatemain.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtedatemain.ClientID%>').datepicker('setStartDate', minDate);
        });
        $('#' + '<%=txtedatemain.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtsdatemain.ClientID%>').datepicker('setEndDate', minDate);
            });

        
        $('#<%=txtsdatefung.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtedatefung.ClientID%>').datepicker('setStartDate', minDate);
        });
        $('#' + '<%=txtedatefung.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtsdatefung.ClientID%>').datepicker('setEndDate', minDate);
            });

        
        $('#<%=slsite.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtsite.ClientID %>').val(id);
        });

        $('#<%=slgedung.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtgedung.ClientID %>').val(id);
        });

        $('#<%=slruang.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtruangan.ClientID %>').val(id);
        });

        $('#<%=slrak.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtrak.ClientID %>').val(id);
        });


    </script>
</asp:Content>
