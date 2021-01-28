 <%@ Page Title="Approvement" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="approvement.aspx.cs" Inherits="Telkomsat.admin.approvement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/select2/dist/css/select2.min.css"/>
    <style type="text/css">
        .select2-container--default .select2-selection--multiple .select2-selection__choice{
            background-color:deepskyblue;
        }

        .main-header .navbar .nav>li>a>.label{
            font-size:11px;
            top:1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

        <div class="row" style="height:auto">
        <div class="col-md-12">
          <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs navbar-nav pull-right">
                      <li id="lijustifikasi" class="messages-menu dropdown" runat="server"><a href="#justifikasi" data-toggle="tab"><span class="label label-primary" runat="server" id="spcheck">0</span>Justifikasi</a></li>
                      <li id="lipengeluaran" runat="server"><a href="#pengeluaran" data-toggle="tab">Pengeluaran</a></li>
                       <li id="lipertanggungan" runat="server" visible="false"><a href="#pertanggungan" data-toggle="tab">Pertanggungan</a></li> 
                      <li class="pull-left header"><i class="fa fa-inbox"></i> Approvement</li>
                    </ul>
              
                <div class="tab-content no-padding">
                    <div id="pengeluaran" class="tab-pane fade">
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                        <asp:Label ID="lblpeng" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                    <div id="justifikasi" class="tab-pane fade">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>  
                        <asp:Label ID="lblgm" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                    <div id="pertanggungan" class="tab-pane in fade">
                        <button type="button" id="btnid" class="btn btn-success pull-right" style="margin:10px" runat="server" visible="false">Accept</button>
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>  
                        <asp:Label ID="lblpertanggungan" runat="server" Text="Tidak ada data pertanggungan" Visible="false"></asp:Label>
                    </div>
                    </div>
                </div>
               
            </div>
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
                                              <th>Nama Kegiatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnk" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
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
                <h3 class="modal-title">Update</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Pilih Aksi :</label>
                                  <asp:DropDownList ID="ddlaksi" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Approve</asp:ListItem>
                                    <asp:ListItem>Revision</asp:ListItem>
                                    <asp:ListItem>Reject</asp:ListItem>
                                    <asp:ListItem>Pending</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Keterangan :</label>
                            <asp:TextBox ID="txtalasan" autocomplete="off" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                        </div>
                      </div> 
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" id="btngm" class="btn btn-success pull-left" runat="server" onserverclick="Approve_GM">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

            <div class="modal fade" id="modalpenggm">
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
                                  <asp:DropDownList ID="ddlaksigm" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Approve</asp:ListItem>
                                    <asp:ListItem>Revision</asp:ListItem>
                                    <asp:ListItem>Reject</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Alasan :</label>
                            <asp:TextBox ID="txtalasangm" autocomplete="off" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                        </div>
                      </div> 
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" id="Button2" class="btn btn-primary pull-left" runat="server" onserverclick="Approve_GMPeng">Save</button>
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

        <div class="modal fade" id="modalpengeluaran">
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
                                <label style="font-size:16px; font-weight:bold">Lampiran Evidence :</label>
                              <asp:FileUpload ID="FileUpload4" runat="server" AllowMultiple="true" />
                            </div>
                      </div> 
                      
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" id="Button1" class="btn btn-success pull-left" runat="server" onserverclick="Approve_Pengeluaran">Save</button>
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
                              <asp:TextBox ID="txttanggal" autocomplete="off" runat="server" CssClass="form-control datepick" data-date-end-date="0d"></asp:TextBox>
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
                              <input type="text" class="form-control" id="txtnominalven1" runat="server" readonly/>
                            </div>
                      </div> 
                      <div class="col-md-6" style="display:none" id="divlampem">
                          <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Lampiran Pemasukan :</label>
                              <asp:FileUpload ID="FileUpload2" runat="server" />
                            </div>
                      </div> 
                      <div class="col-md-6" style="display:none" id="divlampeng">
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
    <asp:TextBox ID="txtidrkap2" runat="server" Text="" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtideng" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidjustifikasi" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtliactive" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtidpertanggungan" runat="server" CssClass="hidden"></asp:TextBox>
    
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        $(document).ready(function () {
            $('#<%=txtnominalint1.ClientID %>').keyup(function () {
                var nominalinternal = $('#<%=txtnominalint1.ClientID %>').val().replace(/\./g, "");
                var totaljus = $('#<%=txttotal.ClientID %>').val();
                $('#<%=txtnominalven1.ClientID %>').val(totaljus - nominalinternal);
            });

            $('#<%=btnid.ClientID %>').click(function () {
                var favorite = [];
                $.each($("input[name='getid']:checked"), function () {
                    favorite.push($(this).val());
                });
                //alert("My favourite sports are: " + favorite.join(","));
                var id = favorite.join(",");
                $('#<%=txtidpertanggungan.ClientID %>').val(id);
                //$('#<=%=Button3.ClientID %>').trigger("click");
            });
        });


        function toggle(source) {
            var checkboxes = document.querySelectorAll('input[type="checkbox"]');
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] != source)
                    checkboxes[i].checked = source.checked;
            }
        }

        $('#slpetugas1').change(function () {
            var id = $(this).val();
            console.log(id);
            if (id == "1") {
                $("#divlampem").removeAttr("style").hide();
                $("#divlampeng").removeAttr("style").hide();
                $("#divvendor").removeAttr("style").hide();
                $("#divinternal").show();
                $("#divtextvendor").removeAttr("style").hide();
                $("#divtextinternal").removeAttr("style").hide();
                $('#<%=txttipe.ClientID%>').val('internal');
            }
            else if (id == "2") {
                $("#divlampem").removeAttr("style").hide();
                $("#divlampeng").removeAttr("style").hide();
                $("#divinternal").removeAttr("style").hide();
                $("#divvendor").show();
                $("#divtextvendor").removeAttr("style").hide();
                $("#divtextinternal").removeAttr("style").hide();
                $('#<%=txttipe.ClientID%>').val('vendor');
            }
            else if (id[0] == "1" && id[1] == "2") {
                $("#divlampem").show();
                $("#divlampeng").show();
                $("#divvendor").show();
                $("#divinternal").show();
                $("#divtextinternal").show();
                $("#divtextvendor").show();
                $('#<%=txttipe.ClientID%>').val('dua');
            }
            else {
                $("#divlampem").removeAttr("style").hide();
                $("#divlampeng").removeAttr("style").hide();
                $("#divvendor").removeAttr("style").hide();
                $("#divinternal").removeAttr("style").hide();
                $("#divtextvendor").removeAttr("style").hide();
                $("#divtextinternal").removeAttr("style").hide();
                $('#<%=txttipe.ClientID%>').val('null');
            }
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
            format: 'yyyy/mm/dd'});

        $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
              "ordering": false,
              "lengthChange": true,
            "searching": true
          });

            $("#example3").DataTable({
                "autoWidth": true,
                "ordering": false,
                "lengthChange": true,
                "searching": true
            });
            $('.dataTables_length').addClass('bs-select');
        });

        function DisableButton() {
            document.getElementById("<%=btnadmin.ClientID %>").disabled = true;
            document.getElementById("<%=btngm.ClientID %>").disabled = true;
            document.getElementById("<%=btngmup.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;

        $(document).on("click", "#btnadmin", function () {
            var id = $(this).data('id');
            console.log(id);
            $("#id").val(id);
            
        });

        $(document).ready(function () {

            if ($('#<%=txtliactive.ClientID %>').val() == 'pengeluaran') {
                $('#pengeluaran').addClass('in active');
                console.log('iuiui');
            }            
            else if ($('#<%=txtliactive.ClientID %>').val() == 'pertanggungan') {
                $('#pertanggungan').addClass('in active');
            }
            else {
                $('#justifikasi').addClass('in active');
                console.log('iuiui');
            }
        });

        function confirmselesai(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data tidak bisa diubah lagi',
                buttons: true,
                icon: "info",

            }).then((willDelete)=>{
                if (willDelete) {
                    document.location = deleteurl;
                }
            });
        }

        $('.datagm').click(function () {
            var id = $(this).val();
            $('#<%=txtidgm.ClientID %>').val(id);
        });

        $('.datapeng').click(function () {
            var id = $(this).val();
            $('#<%=txtideng.ClientID %>').val(id);
        });

        $('.datagmup').click(function () {
            var id = $(this).val();
            $('#<%=txtidgm.ClientID %>').val(id);
        });

        $('.datamain').click(function () {
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "approvement.aspx/GetDetail",
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
                url: "approvement.aspx/GetTotal",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        $('#<%=txttotal.ClientID %>').val(this.total);
                        $('#<%=txtketerangan.ClientID %>').val(this.keterangan);
                        $('#<%=txtgt.ClientID %>').val(this.gt);
                        $('#<%=lbltotal.ClientID %>').html(this.total);
                        $('#<%=txtidrkap.ClientID %>').val(this.idrkap);
                        $('#<%=txtidrkap2.ClientID %>').val(this.idrkap2);
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
