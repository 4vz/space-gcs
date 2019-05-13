<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="Telkomsat.RF.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
  <div class="bodyLB">
      <asp:HiddenField ID="hfContactID" runat="server" />

      <asp:DataList runat="server" id="dtContact" Width="568px" >
        <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB" CommandArgument='<%# Eval("ID") %>' />
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") + " - " %>' />
            <asp:Label ID="AKTIVITASLabel" runat="server" class="aktivitasLB" Text='<%# Eval("AKTIVITAS") %>' />
            <br />
            <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR")) %>'/>
            
            <br />
        </ItemTemplate>

    </asp:DataList>
    </div>
</form>
</asp:Content>
