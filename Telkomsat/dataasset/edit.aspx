<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Telkomsat.dataasset.edit" %>
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
    <link rel="stylesheet" href="dataaset.css?version=2" />
    <asp:TextBox ID="txtdevice" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtruangan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtrak" runat="server" CssClass="hidden"></asp:TextBox>
     <asp:TextBox ID="txtsatelit" runat="server" CssClass="hidden"></asp:TextBox>
    <div class="row">
    <div class="col-md-7">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Detail Data</h3>
            <label runat="server" style="font-size:10px; color:#a9a9a9" class="pull-right" id="lbltanggal"></label>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="alert alert-success alert-dismissable" id="divsuccess" runat="server" visible="false">
                <h5><span class="fa fa-check"> Berhasil diedit</span></h5>
            </div>
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
                <label for="inputEmail3" class="col-sm-4 control-label">Tipe Perangkat</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txttipe" runat="server" CssClass="form-control"></asp:TextBox>
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
                <label for="inputEmail3" class="col-sm-4 control-label">Serial Number</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtsn" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Tahun Pengadaan</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txttahunpengadaan" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <asp:Label ID="lblruangan" runat="server" Text="Label"></asp:Label>
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
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer">
            <asp:Button ID="Button1" runat="server" Text="Simpan" CssClass="btn btn-success" OnClick="Save_Click"/>
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
    <div class="modal" id="myModal">
          <span class="close">&times;</span>
            <img class="modal-content" id="img01" src=""/>
          <div id="caption"></div>
    </div>

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

        $(function () {
            $('.select2').select2({
                allowClear: true,
                placeholder: "--Wilayah--",
            });
        });
                // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function() { 
          modal.style.display = "none";
        }

    </script>
</asp:Content>
