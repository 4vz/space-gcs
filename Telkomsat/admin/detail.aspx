<%@ Page Title="Admin Detail" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Telkomsat.admin.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
<section class="col-lg-7 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Detail</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
        <div class="form-group">
            <label for="exampleInputEmail1" style="width:120px;">Keterangan</label>
            <asp:Label ID="Label2" runat="server">: </asp:Label>
            <asp:Label ID="lblKeterangan" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1" style="width:120px;">Nominal</label>
            <asp:Label ID="Label6" runat="server">: </asp:Label>
            <asp:Label ID="lblNominal" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1" style="width:120px;">Kategori</label>
            <asp:Label ID="Label3" runat="server">: </asp:Label>
            <asp:Label ID="lblKategori" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1" style="width:120px;">Detail</label>
            <asp:Label ID="Label4" runat="server">: </asp:Label>
            <asp:Label ID="lbldetail" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputFile" style="width:120px;">File input</label>
            <asp:Label ID="Label5" runat="server">: </asp:Label>
            <asp:LinkButton ID="lbupload" runat="server" OnClick="lbupload_Click">LinkButton</asp:LinkButton>
        </div>
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
        <button type="submit" class="btn btn-primary" runat="server" >Submit</button>
        </div>
    </div>
    </section>
<section class="col-lg-5 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Table Detail</h3>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <div class="box-body" style="min-height:200px;">
        <asp:PlaceHolder ID="PlaceHolderDetail" runat="server"></asp:PlaceHolder>  
    </div>
    </div>
</section>
</div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
</asp:Content>
