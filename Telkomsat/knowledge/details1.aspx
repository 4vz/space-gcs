<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="details1.aspx.cs" Inherits="Telkomsat.knowledge.details1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
  <div class="bodyLB">
      <asp:HiddenField ID="hfContactID" runat="server" />

      <asp:DataList runat="server" id="dtContact" Width="568px" >
        <ItemTemplate>
            <asp:Label Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB" />
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") + " - " %>' />
            <asp:Label ID="AKTIVITASLabel" runat="server" class="aktivitasLB" Text='<%# Eval("POSTING") %>' />
            <br />
            <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR1")) %>'/>
            <asp:Image ID="Image2" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR2")) %>'/>
            <asp:Image ID="Image3" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR3")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR3")) %>'/>
            <asp:Image ID="Image4" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR4")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR4")) %>'/>
            <br />
        </ItemTemplate>

    </asp:DataList>
    </div>
</form>
</asp:Content>
