<%@ Page Title="Tambah Data" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="tambahdata.aspx.cs" Inherits="Telkomsat.dataasset.tambahdata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
body {font-family: Arial, Helvetica, sans-serif;}

#myImg {
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
}

#myImg:hover {opacity: 0.7;}

/* The Modal (background) */
.modal {
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
.modal-content {
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
.modal-content, #caption {  
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
.close {
    position: absolute;
    top: 65px;
    right: 45px;
    color: #f1f1f1;
    font-size: 40px;
    font-weight: bold;
    transition: 0.3s;
}

    .close:hover,
    .close:focus {
        color: #bbb;
        text-decoration: none;
        cursor: pointer;
    }

/* 100% Image Width on Smaller Screens */
@media only screen and (max-width: 700px) {
    .modal-content {
        width: 100%;
    }
}

}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <link rel="stylesheet" href="dataaset.css?version=2" />
    <asp:TextBox ID="txtdevice" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtruangan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtrak" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtmerk" runat="server" CssClass="hidden"></asp:TextBox>
     <asp:TextBox ID="txtsatelit" runat="server" CssClass="hidden"></asp:TextBox>
    <div class="row">
    <div class="col-md-7">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Tambah Data</h3>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="alert alert-success alert-dismissable" id="divsuccess" runat="server" visible="false">
                <h5><span class="fa fa-check"> Berhasil ditambahkan</span></h5>
            </div>
            <div class="alert alert-danger alert-dismissable" id="divfail" runat="server" visible="false">
                <h5><span class="fa fa-ban"> Tanda * wajib diisi</span></h5>
            </div>
            <div>
                <h4>Equipment</h4>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Jenis Equipment</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <select id="slequipment" runat="server" class="form-control" style="width: 100%;"></select>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Jenis Device</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <select id="sldevice" runat="server" class="form-control" style="width: 100%;"></select>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Merk</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <select id="slmerk" runat="server" class="form-control" style="width: 100%;"></select>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Model</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtmodel" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Product Number</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtpn" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Serial Number</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <asp:TextBox ID="txtsn" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Tahun Pengadaan</label><span style="color:red"> *</span>
                </div> 
                <div class="col-sm-8">
                    <asp:TextBox ID="txttahun" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div>
                <h4>Lokasi</h4>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Wilayah</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <select id="slsite" runat="server" class="form-control" style="width: 100%;"></select>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Gedung</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <select id="slgedung" runat="server" class="form-control" style="width: 100%;"></select>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Ruangan</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <select id="slruangan" runat="server" class="form-control" style="width: 100%;"></select>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Rack</label>
                <div class="col-sm-8">
                    <select id="slrak" runat="server" class="form-control" style="width: 100%;"></select>
                </div>
            </div>
            <div>
                <h4>Kelompok Satelit</h4>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Kelompok Satelit</label>
                <div class="col-sm-8">
                    <select class="form-control select2" multiple="multiple" data-placeholder="--Kelompok Satelit--"
                        style="width: 100%;" id="slsatelit">
                          <option>Telkom 2</option>
                          <option>Telkom 3S</option>
                          <option>MPSat</option>
                        </select>
                </div>
            </div>
            <div>
                <h4>Keterangan</h4>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Fungsi</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                    <asp:DropDownList ID="txtfungsi" runat="server" CssClass="form-control">
                    <asp:ListItem>--Pilih Fungsi--</asp:ListItem>
                        <asp:ListItem>OPERASIONAL</asp:ListItem>
                        <asp:ListItem>BACKUP</asp:ListItem>
                        <asp:ListItem>SPARE</asp:ListItem>
                        <asp:ListItem>TOOLS</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4">
                    <label for="inputEmail3">Status</label><span style="color:red"> *</span>
                </div>   
                <div class="col-sm-8">
                <asp:DropDownList ID="txtstatus" runat="server" CssClass="form-control">
                    <asp:ListItem>--Pilih Status--</asp:ListItem>
                    <asp:ListItem>BAIK</asp:ListItem>
                    <asp:ListItem>RUSAK</asp:ListItem>
                    <asp:ListItem>PERBAIKAN</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Keterangan</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtKeterangan" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer">
            <asp:Button ID="Button1" runat="server" Text="Simpan" CssClass="btn btn-success" OnClick="Save_Click" />
            <!-- /.pull-right -->
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
   
        <div class="col-md-5">
            <img id="myImg" src="" style="width:100%"/>
        </div>
        </div>
    <asp:HiddenField ID="HiddenField1" runat="server" Value="bisa" />
    <div class="modal" id="myModal">
          <span class="close">&times;</span>
            <img class="modal-content" id="img01" src=""/>
          <div id="caption"></div>
    </div>
    <asp:TextBox ID="txtid" runat="server"  CssClass="hidden"></asp:TextBox>
    <script type="text/javascript">
    var modal = document.getElementById("myModal");
    var img = document.getElementById("myImg");
    var modalImg = document.getElementById("img01");
    var captionText = document.getElementById("caption");
    img.onclick = function(){
        modal.style.display = "block";
        modalImg.src = this.src;
        captionText.innerHTML = this.alt;
     }

            // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() { 
      modal.style.display = "none";
    }
    function DisableButton() {
        document.getElementById("<%=Button1.ClientID %>").disabled = true;
    }
    window.onbeforeunload = DisableButton;
    $(function () {
        $('.select2').select2({
             allowClear:true,
             placeholder: "--Wilayah--",
        });
        $('#slsatelit').change(function() {
            var selectedValues = $(this).val();  
            $('#<%=txtsatelit.ClientID %>').val(selectedValues);
        });

        $('#<%=sldevice.ClientID %>').change(function () {
            var id = $(this).val();
            $('#<%=txtdevice.ClientID %>').val(id);
        });

        $('#<%=slruangan.ClientID %>').change(function () {
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


        $.ajax({
                type: "POST",
                url: "tambahdata.aspx/Getequipment",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slequipment.ClientID %>').empty();
                    $('#<%=slequipment.ClientID %>').append('<option value=0>' + '--Pilih Equipment--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.equipment);
                        $('#<%=slequipment.ClientID %>').append('<option value="' + this.idequipment + '">' + this.equipment + '</option>');
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
            $('#<%=slruangan.ClientID %>').empty();
            $('#<%=slrak.ClientID %>').empty();
            var id = $(this).val();
            if (id == '1') {
                $("#myImg").attr("src", "../img/CIBINONG.jpg");
            } else {
                $("#myImg").attr("src", "");
            }
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
            $('#<%=slruangan.ClientID %>').empty();
            $('#<%=slrak.ClientID %>').empty();
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "tambahdata.aspx/Getruangan",
                contentType: "application/json; charset=utf-8",
                data: '{sobangunan:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slruangan.ClientID %>').empty();
                    $('#<%=slruangan.ClientID %>').append('<option value=0>' + '--Pilih Ruangan--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.ruangan);
                        $('#<%=slruangan.ClientID %>').append('<option value="' + this.idruangan + '">' + this.ruangan + '</option>');
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

        $('#<%=slruangan.ClientID %>').change(function () {
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

            $.ajax({
                type: "POST",
                url: "tambahdata.aspx/Getimage",
                contentType: "application/json; charset=utf-8",
                data: '{soruangan:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $(customers).each(function () {
                        $("#myImg").attr("src", this.image);
                        console.log(this.image);
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

        $('#<%=slequipment.ClientID %>').change(function () {
            $('#<%=sldevice.ClientID %>').empty();
            $('#<%=slmerk.ClientID %>').empty();
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "tambahdata.aspx/Getdevice",
                contentType: "application/json; charset=utf-8",
                data: '{soequipment:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sldevice.ClientID %>').empty();
                    $('#<%=sldevice.ClientID %>').append('<option value=0>' + '--Pilih Device--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.device);
                        $('#<%=sldevice.ClientID %>').append('<option value="' + this.iddevice + '">' + this.device + '</option>');
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

         $('#<%=sldevice.ClientID %>').change(function () {
            $('#<%=slmerk.ClientID %>').empty();
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "tambahdata.aspx/Getmerk",
                contentType: "application/json; charset=utf-8",
                data: '{sodevice:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=slmerk.ClientID %>').empty();
                    $('#<%=slmerk.ClientID %>').append('<option value=0>' + '--Pilih Merk--' + '</option>');
                    $(customers).each(function () {
                        console.log(this.merk);
                        $('#<%=slmerk.ClientID %>').append('<option value="' + this.idmerk + '">' + this.merk + '</option>');
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
