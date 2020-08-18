<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="approvementsa.aspx.cs" Inherits="Telkomsat.admin.approvementsa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/select2/dist/css/select2.min.css"/>
    <style type="text/css">
        .select2-container--default .select2-selection--multiple .select2-selection__choice{
            background-color:deepskyblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Approvement</h3>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        <asp:Label ID="lblgm" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                </div>
            </section>
        </div>


    <div class="modal fade" id="modalmaintenance">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Justifikasi</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <table class="table" style="border:none">
                                    <tbody>
                                          <tr>
                                              <th>Jenis UPD</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbljupd" runat="server" Text="Wildan Ger saputra" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                        <tr>
                                              <th>Nomor Justifikasi</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnj" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                        <tr>
                                              <th>Pemberi Tugas</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltglpt" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Subdit</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblsubdit" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Jabatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbljabatan" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                         <tr>
                                              <th>No. Akun Anggaran</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnaa" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Tanggal Kegiatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltgl" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Tanggal Dokumen Diserahkan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltglds" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          
                                          <tr>
                                              <th>Jenis Anggaran</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblja" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Program Kerja</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblpk" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nilai RKAP</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnrkap" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nama Kegiatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnk" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          
                                          <tr>
                                              <th>Nilai</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnilai" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Keterangan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblket" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Detail</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbldetail" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                    </tbody>
                          
                                </table>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal" aria-label="Close">Close</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>
        </div>

            <div class="modal fade" id="modalgm">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Approve</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Pilih Aksi :</label>
                                  <asp:DropDownList ID="ddlaksi" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Approve</asp:ListItem>
                                      <asp:ListItem>Repair</asp:ListItem>
                                    <asp:ListItem>Reject</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Alasan :</label>
                            <asp:TextBox ID="txtalasan" autocomplete="off" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                        </div>
                      </div> 
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" id="Button1" class="btn btn-success pull-left" runat="server" onserverclick="Approve_GM">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

            <div class="modal fade" id="modalgmup">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Approve</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Pilih Aksi :</label>
                                  <asp:DropDownList ID="ddlaksiup" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Reject</asp:ListItem>
                                      <asp:ListItem>Postpon</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Alasan :</label>
                            <asp:TextBox ID="txtalasanup" autocomplete="off" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                        </div>
                      </div> 
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" id="btngmup" class="btn btn-info pull-left" runat="server" onserverclick="Approve_GMUP">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>


       <div class="modal fade" id="modalupdate">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Approve</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Nilai Justifikasi :</label>
                              <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                            </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Lampiran Evidence :</label>
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Tanggal :</label>
                              <asp:TextBox ID="txttanggal" autocomplete="off" runat="server" CssClass="form-control datepick"></asp:TextBox>
                            </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Jenis Pengeluaran :</label>
                                <select class="form-control select2" multiple="multiple" style="width: 100%;" id="slpetugas1">
                                        <option value="1">Cash Internal</option>
                                        <option value="2">Vendor</option>
                                </select>
                            </div>
                      </div> 
                      <div class="col-md-12" style="display:none" id="divinternal">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Kategori Penyimpanan :</label>
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
                      </div> 
                     <div class="col-md-12" style="display:none" id="divvendor">
                         <div class="form-group">
                                <label for="exampleInputPassword1">Nama Vendor</label>
                                <select id="sovendor" runat="server" class="select2 form-control" style="width: 100%;">
                                    <option></option>
                                </select>
                        </div>
                     </div> 
                      
                      <div class="col-md-6">
                          <div class="form-group" style="display:none" id="divtglint">
                                <label style="font-size:16px; font-weight:bold">Tanggal Internal :</label>
                              <input type="text" class="form-control datepick" id="txttglint" runat="server"/>
                            </div>
                      </div> 
                      <div class="col-md-6">
                          <div class="form-group" style="display:none" id="divtglven">
                                <label style="font-size:16px; font-weight:bold">Tanggal Vendor :</label>
                              <input type="text" class="form-control datepick" id="txttglven" runat="server"/>
                            </div>
                      </div> 
                      <div class="col-md-6">
                          <div class="form-group" style="display:none" id="divtextinternal">
                                <label style="font-size:16px; font-weight:bold">Nominal Internal :</label>
                              <input type="text" class="form-control" id="txtnominalint1" runat="server" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
                            </div>
                      </div> 
                      <div class="col-md-6">
                          <div class="form-group" style="display:none" id="divtextvendor">
                                <label style="font-size:16px; font-weight:bold">Nominal Vendor :</label>
                              <input type="text" class="form-control" id="txtnominalven1" runat="server" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
                            </div>
                      </div> 
                      <div class="col-md-6">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Lampiran Pemasukan :</label>
                              <asp:FileUpload ID="FileUpload2" runat="server" />
                            </div>
                      </div> 
                      <div class="col-md-6">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Lampiran Pengeluaran :</label>
                              <asp:FileUpload ID="FileUpload3" runat="server" />
                            </div>
                      </div> 
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" id="btnadmin" class="btn btn-success pull-left" runat="server" onserverclick="Approve_Admin">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

    <asp:TextBox ID="txtidl" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtvendor" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txttipe" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txttotal" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtketerangan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidgm" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtgt" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidrkap" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidjustifikasi" runat="server" CssClass="hidden"></asp:TextBox>
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script>
        $('#slpetugas1').change(function () {
            var id = $(this).val();
            console.log(id);
            if (id == "1") {
                $("#divvendor").removeAttr("style").hide();
                $("#divinternal").show();
                $("#divtextvendor").removeAttr("style").hide();
                $("#divtextinternal").removeAttr("style").hide();
                $('#<%=txttipe.ClientID%>').val('internal');
            }
            else if (id == "2") {
                $("#divinternal").removeAttr("style").hide();
                $("#divvendor").show();
                $("#divtextvendor").removeAttr("style").hide();
                $("#divtextinternal").removeAttr("style").hide();
                $('#<%=txttipe.ClientID%>').val('vendor');
            }
            else if (id[0] == "1" && id[1] == "2") {
                $("#divvendor").show();
                $("#divinternal").show();
                $("#divtextinternal").show();
                $("#divtextvendor").show();
                $('#<%=txttipe.ClientID%>').val('dua');
            }
            else {
                $("#divvendor").removeAttr("style").hide();
                $("#divinternal").removeAttr("style").hide();
                $("#divtextvendor").removeAttr("style").hide();
                $("#divtextinternal").removeAttr("style").hide();
                $('#<%=txttipe.ClientID%>').val('null');
            }
        });

        $('.datagm').click(function () {
            var id = $(this).val();
            $('#<%=txtidgm.ClientID %>').val(id);
        });

        $(function () {
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


        $('.select2').select2()

        $(".datepick").datepicker({autoclose: true,
            format: 'yyyy/mm/dd' });

        $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
              "ordering": false,
              "lengthChange": true,
            "searching": true
          });
           $('.dataTables_length').addClass('bs-select');
        });

        $(document).on("click", "#btnadmin", function () {
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            
        });

        function confirmselesai(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data tidak bisa diubah lagi',
                buttons: true,
                icon: "success",

            }).then((willDelete)=>{
                if (willDelete) {
                    document.location = deleteurl;
                }
            });
        }

        $('.datamain').click(function () {
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "approvementsa.aspx/GetDetail",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        console.log(this.keteranganmain);
                        $('#<%=lblnj.ClientID %>').html(this.nj);
                        $('#<%=lbldetail.ClientID %>').html(this.detail);
                        $('#<%=lblja.ClientID %>').html(this.ja);
                        $('#<%=lbljabatan.ClientID %>').html(this.jabatan);
                        $('#<%=lbljupd.ClientID %>').html(this.jupd);
                        $('#<%=lblket.ClientID %>').html(this.ket);
                        $('#<%=lblnaa.ClientID %>').html(this.naa);
                        $('#<%=lblnilai.ClientID %>').html(this.nilai);
                        $('#<%=lblnk.ClientID %>').html(this.nk);
                        $('#<%=lblnrkap.ClientID %>').html(this.nrkap);
                        $('#<%=lblpk.ClientID %>').html(this.pk);
                        $('#<%=lblsubdit.ClientID %>').html(this.subdit);
                        $('#<%=lbltgl.ClientID %>').html(this.tgl);
                        $('#<%=lbltglds.ClientID %>').html(this.tglds);
                        $('#<%=lbltglpt.ClientID %>').html(this.tglpt);
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

        $('.datatotal').click(function () {
            var id = $(this).val();
            $('#<%=txtidl.ClientID %>').val(id);
            $.ajax({
                type: "POST",
                url: "approvementsa.aspx/GetTotal",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        $('#<%=txttotal.ClientID %>').val(this.total);
                        $('#<%=txtketerangan.ClientID %>').val(this.keterangan);
                        $('#<%=txtgt.ClientID %>').val(this.total);
                        $('#<%=txtidrkap.ClientID %>').val(this.idrkap);
                        $('#<%=txtidjustifikasi.ClientID %>').val(this.idjustifikasi);
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
    </script>
</asp:Content>
