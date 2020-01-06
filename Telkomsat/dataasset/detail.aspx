<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Telkomsat.dataasset.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #myImg {
          border-radius: 5px;
          cursor: pointer;
          transition: 0.3s;
        }

        #myImg:hover {opacity: 0.7;}

        /* The Modal (background) */
        .modal1 {
          display: none; /* Hidden by default */
          position: fixed; /* Stay in place */
          z-index: 1; /* Sit on top */
          padding-top: 100px; /* Location of the box */
          left: 0;
          top: 0;
          width: 100%; /* Full width */
          height: 100%; /* Full height */
          overflow: auto; /* Enable scroll if needed */
          background-color: rgb(0,0,0); /* Fallback color */
          background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modal-content1 {
          margin: auto;
          display: block;
          width: 80%;
          max-width: 700px;
        }

        /* Caption of Modal Image */
        #caption {
          margin: auto;
          display: block;
          width: 80%;
          max-width: 700px;
          text-align: center;
          color: #ccc;
          padding: 10px 0;
          height: 150px;
        }

        /* Add Animation */
        .modal-content1, #caption {  
          -webkit-animation-name: zoom;
          -webkit-animation-duration: 0.6s;
          animation-name: zoom;
          animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
          from {-webkit-transform:scale(0)} 
          to {-webkit-transform:scale(1)}
        }

        @keyframes zoom {
          from {transform:scale(0)} 
          to {transform:scale(1)}
        }

        /* The Close Button */
        .close1 {
            position: absolute;
            top: 65px;
            right: 45px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .close1:hover,
            .close1:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        /* 100% Image Width on Smaller Screens */
        @media only screen and (max-width: 700px) {
            .modal-content1 {
                width: 100%;
            }
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="dataaset.css?version=2" />
    <asp:TextBox ID="txtdevice" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtsite" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtgedung" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtruangan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtrak" runat="server" CssClass="hidden"></asp:TextBox>
     <asp:TextBox ID="txtsatelit" runat="server" CssClass="hidden"></asp:TextBox>
    <div class="row">
    <div class="col-md-7">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Detail Data</h3>
            <asp:Label ID="label1" runat="server" Text="" ForeColor="YellowGreen"></asp:Label>
            <label runat="server" style="font-size:10px; color:#a9a9a9" class="pull-right" id="lbltanggal"></label>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div>
                <h4>Equipment</h4>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Jenis Equipment</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblequipment" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Jenis Device</label>
                <div class="col-sm-8">
                    <asp:Label ID="lbldevice" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Merk</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblmerk" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Model</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblmodel" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Product Number</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblpn" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Serial Number</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblsn" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Tahun Pengadaan</label>
                <div class="col-sm-8">
                    <asp:Label ID="lbltahun" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div>
                <h4>Lokasi</h4>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Site</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblsite" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Gedung</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblgedung" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Ruangan</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblruang" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Rack</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblrak" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div>
                <h4>Kelompok Satelit</h4>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Kelompok Satelit</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblsatelit" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div>
                <h4>Keterangan</h4>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Fungsi</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblfungsi" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Status</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblstatus" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Keterangan</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblketerangan" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div>
                <h4>PIC</h4>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Nama PIC</label>
                <div class="col-sm-8">
                    <asp:Label ID="lblpic" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer">
            <button type="button" class="btn btn-success pull-left" data-toggle="modal" data-target="#modalupdate" style="margin-right:10px">Mutasi</button>
            <button type="button" class="btn btn-warning pull-left" data-toggle="modal" data-target="#modalfungsi">Edit Fungsi</button>
                <asp:Button ID="Button1" runat="server" Text="History" CssClass="btn btn-info pull-right" OnClick="History_Click" />
            <!-- /.pull-right -->
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>

        <div class="col-md-5">
            <img id="myImg" src="" runat="server" style="width:100%"/>
        </div>
        </div>

    <div class="row" runat="server" id="divhistory" visible="false">
        <div class="col-md-7">
            <div class="box box-danger">
                <div class="box-header with-border">
                    <h4 class="box-title">History Mutasi</h4>
                </div>
                <div class="box-body">
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
                    <asp:Label ID="lblhl" runat="server" Text="Tidak ada histori mutasi pada perangkat ini" Visible="false"></asp:Label>
                </div>
                 
            </div>
        </div>
        <div class="col-md-5">
            <div class="box box-danger">
                <div class="box-header with-border">
                    <h4 class="box-title">History Fungsional</h4>
                </div>
                <div class="box-body">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>  
                    <asp:Label ID="lblhf" runat="server" Text="Tidak ada histori fungsional pada perangkat ini" Visible="false"></asp:Label>
                </div>
                </div>
        </div>
    </div>
    <div class="modal modal1" id="myModal">
          <span class="close close1">&times;</span>
            <img class="modal-content modal-content1" id="img01" src=""/>
          <div id="caption"></div>
    </div>
     <div class="modal fade" id="modalupdate">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>x</button>
                <h3 class="modal-title">Harkat</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-6">
                            <div>
                                <h4>Lokasi Sebelum</h4>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Nama Wilayah :</label>
                                <asp:Label ID="lblwilayah" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Bangunan :</label>
                                <asp:Label ID="lblbangunan" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Ruangan :</label>
                                <asp:Label ID="lblruangan" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Nama Rak :</label>
                                <asp:Label ID="lblraak" runat="server" Text="Label"></asp:Label>
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
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Lok_ServerClick">Save</button>
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
                  <span aria-hidden="true">&times;</span>x</button>
                <h3 class="modal-title">Harkat</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
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
                            <div class="form-group">
                                <label style="font-size:16px">Keterangan :</label>
                                <asp:Label ID="lbket" runat="server" Text="Label"></asp:Label>
                            </div>
                      </div>
                      <div class="col-md-6">
                            <div>
                                <h4>Keterangan Setelah</h4>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px; font-weight:bold">Fungsi </label>
                                <asp:DropDownList ID="ddlFungsi" runat="server" class="form-control">
                                    <asp:ListItem>--Pilih Fungsi--</asp:ListItem>
                                    <asp:ListItem>OPERASIONAL</asp:ListItem>
                                    <asp:ListItem>BACKUP</asp:ListItem>
                                    <asp:ListItem>SPARE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Status :</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                                    <asp:ListItem>--Pilih Status--</asp:ListItem>
                                    <asp:ListItem>BAIK</asp:ListItem>
                                    <asp:ListItem>PERBAIKAN</asp:ListItem>
                                    <asp:ListItem>RUSAK</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label style="font-size:16px">Keterangan :</label>
                                <asp:TextBox ID="txtKet" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                      </div>
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Ket_ServerClick">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        var modal = document.getElementById("myModal");
        var img = document.getElementById('<%= myImg.ClientID%>');
        var modalImg = document.getElementById("img01");
        var captionText = document.getElementById("caption");
        img.onclick = function(){
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
        }
        
        function fungsi() {
            alert("Berhasil Disimpan");
        }

        window.setTimeout(function () { fungsi.close() }, 3000);

                // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function() { 
          modal.style.display = "none";
        }

        $(function () {
            $("#example1").DataTable({
              "paging": true,
              "searching": true,
              "info": true,
              "autoWidth": true,
              "scrollX": true
            });
            $("#example2").DataTable({});
           $('.dataTables_length').addClass('bs-select');

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

            $.ajax({
                type: "POST",
                url: "tambahdata.aspx/Getwilayah",
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
                    url: "tambahdata.aspx/Getbangunan",
                    contentType: "application/json; charset=utf-8",
                    data: '{videoid:"' + id + '"}',
                    dataType: "json",
                    success: function (response) {
                        var customers = response.d;
                        $('#<%=slgedung.ClientID %>').empty();
                        $('#<%=slgedung.ClientID %>').append('<option value=0>' + '--Pilih Bangunan--' + '</option>');
                        $(customers).each(function () {
                            console.log(this.idbangunan);
                            $('#<%=slgedung.ClientID %>').append('<option value="' + this.idbangunan + '">' + this.bangunan + '</option>');
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
                url: "tambahdata.aspx/Getruangan",
                contentType: "application/json; charset=utf-8",
                data: '{sobangunan:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slruang.ClientID %>').empty();
                    $('#<%=slruang.ClientID %>').append('<option value=0>' + '--Pilih Ruangan--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.ruangan);
                        $('#<%=slruang.ClientID %>').append('<option value="' + this.idruangan + '">' + this.ruangan + '</option>');
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
                url: "tambahdata.aspx/Getrak",
                contentType: "application/json; charset=utf-8",
                data: '{soruangan:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slrak.ClientID %>').empty();
                    $('#<%=slrak.ClientID %>').append('<option value=0>' + '--Pilih Rak--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.rak);
                        $('#<%=slrak.ClientID %>').append('<option value="' + this.idrak + '">' + this.rak + '</option>');
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
