<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="equipmentadd.aspx.cs" Inherits="Telkomsat.dataasset.equipmentadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-md-9">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Tambah Equipment</h3>
            
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="alert alert-success alert-dismissable" id="divsuccess" runat="server" visible="false">
                <h4><span class="fa fa-check"> Berhasil</span></h4>
                berhasil ditambahkan
            </div>
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Nama Equipment :</label>
                    <asp:TextBox ID="txtwiayah" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer no-padding">
            <div class="mailbox-controls">
                <button type="button"  class=" btn btn-danger btn-sm pull-right" runat="server" onserverclick="Tambah_ServerClick"> Tambah</button>
            <!-- /.pull-right -->
            </div>
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
  
    <script type="text/javascript">  
        function fungsi() {
            alert("Berhasil Disimpan");
        }
    </script>  
</asp:Content>
