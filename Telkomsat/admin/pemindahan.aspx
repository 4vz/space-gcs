<%@ Page Title="Input Pemindahan" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="pemindahan.aspx.cs" Inherits="Telkomsat.admin.pemindahan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
<section class="col-lg-7 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Pemindahan</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
        <div class="form-group">
            <label for="exampleInputEmail1">Keterangan</label>
            <input type="text" class="form-control" id="keterangan" runat="server" placeholder="Keterangan"/>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Nominal</label>
            <input type="text" class="form-control" id="nominal" runat="server" placeholder="Nominal" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
        </div>
        <div class="col-md-6" style="padding-left:0px">
            <div class="form-group">
                <label for="exampleInputEmail1">Dari</label>
                <asp:DropDownList ID="ddlKategori1" CssClass="form-control" runat="server">
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
        <div class="col-md-6" style="padding-right:0px">
            <div class="form-group">
                <label for="exampleInputEmail1">Ke</label>
                <asp:DropDownList ID="ddlkategori2" CssClass="form-control" runat="server">
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
        
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
        <button type="submit" class="btn btn-primary" runat="server" onserverclick="Save_ServerClick">Submit</button>
        </div>
    </div>
    </section>
<section class="col-lg-5 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Pemindahan</h3>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <div class="box-body" style="min-height:200px;">
        <asp:DataList runat="server" id="datalist1" CssClass="table">
            <ItemTemplate>
            <asp:Label ID="Label2" runat="server" class="namaLB pdg" Text="Keterangan"/>
            <span class="pull-right">
            <asp:Label ID="Label3" runat="server" class="kategoriLB" Text='<%# Eval("keterangan") %>' />
            </span>
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB pdg" Text="Nominal Pemindahan"/>
            <span class="pull-right">
                <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# "Rp. " + Eval("input", "{0:N0}") %>' />
            </span>
            <br />
            
                
            </ItemTemplate>
    </asp:DataList>
    </div>
    </div>
</section>
</div>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
</asp:Content>
