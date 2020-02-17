<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Telkomsat.datalogbook.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <style>
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
    <asp:TextBox ID="txtaddwork" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtend" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtstart" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden"></asp:TextBox>
     <div class="box box-default">
        <div class="box-header">
            <h4>Detail</h4>
        </div>
        <div class="box-body">
            <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
            <br />
            <h4 runat="server" id="hlampiran" style="font-weight:bold">Lampiran-lampiran</h4>
            <asp:GridView ID="DataList3a" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
                BorderColor="White" BorderStyle="None" BorderWidth="0px" Visible="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <span class="fa fa-check" style="width:20px"></span>
                            <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("namafiles") %>' CommandName="Download" Text='<%# Eval("namafiles") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            </asp:GridView>
        </div>
    </div>
    <div class="row" style="height:auto">
        <div class="col-md-12">
          <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs pull-right">
                      <li id="limutasi" runat="server"><a href="#mutasi" data-toggle="tab">Mutasi</a></li>
                      <li id="listatus" runat="server"><a href="#status" data-toggle="tab">Status</a></li>
                        <li id="likonfig" runat="server"><a href="#konfigurasi" data-toggle="tab">Konfigurasi</a></li>
                        <li id="lilain" runat="server"><a href="#lainlain" data-toggle="tab">Lain-lain</a></li>
                      <li class="pull-left header"><i class="fa fa-inbox"></i> Pekerjaan</li>
                    </ul>
              
                <div class="tab-content no-padding">
                    <div id="status" class="tab-pane fade">
                        <asp:PlaceHolder ID="PlaceHolderStatus" runat="server"></asp:PlaceHolder>
                        <asp:Label ID="lblinfostatus" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                    <div id="mutasi" class="tab-pane fade">
                        <asp:PlaceHolder ID="PlaceHolderMutasi" runat="server"></asp:PlaceHolder>  
                        <asp:Label ID="lblinfomutasi" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                     <div id="konfigurasi" class="tab-pane fade">
                        <asp:PlaceHolder ID="PlaceHolderKonfigurasi" runat="server"></asp:PlaceHolder>  
                         <asp:Label ID="lblinfokonfig" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                     <div id="lainlain" class="tab-pane fade">
                        <asp:PlaceHolder ID="PlaceHolderLain" runat="server"></asp:PlaceHolder>  
                         <asp:Label ID="lblinfolain" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                </div>
               
            </div>
            </div>
          
        </div>
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
                             <input type="text" class="form-control pull-right datepick" id="txtsdatefung" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Akhir :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtedatefung" autocomplete="off" runat="server"/>
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


       <div class="modal fade" id="modalkonfigurasi">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Konfigurasi</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Awal :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtsdatekonf" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Akhir :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtedatekonf" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Status :</label>
                                <asp:DropDownList ID="ddlstatuskonf" runat="server" CssClass="form-control">
                                    <asp:ListItem>--Pilih Status--</asp:ListItem>
                                    <asp:ListItem>On Progress</asp:ListItem>
                                    <asp:ListItem>Selesai</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div>
                      <div class="col-md-12">
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Keterangan :</label>
                                <asp:TextBox ID="txtKetKonfig" CssClass="form-control" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                            </div> 
                      </div>
                      <div class="col-md-12">
                            <label for="exampleInputFile">Lampiran</label>
                            <asp:FileUpload ID="filekonfig" runat="server" AllowMultiple="true"/>
                        </div>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Konfigurasi_ServerClick2">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

           <div class="modal fade" id="modallainlain">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Lain-lain</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Awal :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtsdatelain" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-6">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal Akhir :</label>
                             <input type="text" class="form-control pull-right datepick" id="txtedatelain" autocomplete="off" runat="server"/>
                        </div>
                      </div>
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Status :</label>
                                <asp:DropDownList ID="ddlstatuslain" runat="server" CssClass="form-control">
                                    <asp:ListItem>--Pilih Status--</asp:ListItem>
                                    <asp:ListItem>On Progress</asp:ListItem>
                                    <asp:ListItem>Selesai</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div>
                      <div class="col-md-12">
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Keterangan :</label>
                                <asp:TextBox ID="txtketeranganlain" CssClass="form-control" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                            </div> 
                      </div>
                      <div class="col-md-12">
                            <label for="exampleInputFile">Lampiran</label>
                            <asp:FileUpload ID="FileLain" runat="server" AllowMultiple="true"/>
                        </div>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Lain_ServerClick3">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script>
        $(document).on("click", "#btnmutasi", function () {
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            $('#<%=txtidl.ClientID %>').val(id);
            $('#<%=txtjenispekerjaan.ClientID %>').val('Mutasi');
        });

        $(document).on("click", "#btnkonfigurasi", function () {
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
            if ($('#<%=txtaddwork.ClientID %>').val() == 'M') {
                $('#mutasi').addClass('in active')
            }
            else if ($('#<%=txtaddwork.ClientID %>').val() == 'F') {
                $('#status').addClass('in active')
            }
            else if ($('#<%=txtaddwork.ClientID %>').val() == 'K') {
                $('#konfigurasi').addClass('in active')
            }
            else if ($('#<%=txtaddwork.ClientID %>').val() == 'L') {
                $('#lainlain').addClass('in active')
            }

            var select = false;
            var select1 = false;

            $('#<%=txtruang.ClientID %>').autocomplete({
                source: '../dataasset/HandlerSN.ashx',
                autoFocus: true,
                selectFirst: true,
                open: function(event, ui) { if(select) select=false; },
                select: function (event, ui) {
                    console.log(ui);
                    if (ui.item) {                     
                        var id = ui.item.value;
                        $.ajax({
                            type: "POST",
                            url: "detail.aspx/Getsn",
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
                }
            }).blur(function(){
                if (!select) {
                    $('#<%=txtruang.ClientID %>').val($('ul.ui-autocomplete li.ui-menu-item:first div').text());
                    var id = $('ul.ui-autocomplete li.ui-menu-item:first div').text();
                    $.ajax({
                        type: "POST",
                        url: "detail.aspx/Getsn",
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
                open: function (event, ui) { if (select1) select1 = false; },
                select: function (event, ui) {
                    console.log(ui.item);
                    if (ui.item) {
                        var id = ui.item.value;
                        $.ajax({
                            type: "POST",
                            url: "detail.aspx/Getfungsi",
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
                        url: "detail.aspx/Getfungsi",
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
                url: "detail.aspx/Getwilayah",
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
                    url: "detail.aspx/Getbangunan",
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
                url: "detail.aspx/Getruangan",
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
                url: "detail.aspx/Getrak",
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

        
        $(".datepick").datepicker({startDate:$('#<%=txtstart.ClientID %>').val(),autoclose: true,
            format: 'yyyy/mm/dd' ,endDate :$('#<%=txtend.ClientID %>').val()});

        console.log($('#<%=txtstart.ClientID %>').val());
        console.log($('#<%=txtend.ClientID %>').val());


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
    <script>
        $(function () {
            $('.toggle-two').bootstrapToggle({
                on: 'Selesai',
                off: 'On-Progress'
            });

            $('.toggle-two').change(function () {
                var id = $(this).data('id');
                if ($(this).prop('checked')) {
                    alert(id);
                }
            })
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

        function confirmselesai(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data tidak bisa diubah on-progress lagi',
                buttons: true,
                dangerMode: true,

            }).then((willDelete)=>{
                if (willDelete) {
                    document.location = deleteurl;
                }
            });
        }
    </script>
</asp:Content>
