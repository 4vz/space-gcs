<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="coba.aspx.cs" Inherits="Telkomsat.coba1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="bodyLB">
    <asp:HiddenField ID="hfContactID" runat="server" />
    <asp:DataList runat="server" DataSourceID="SqlDataSource1" Width="568px" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB" CommandArgument='<%# Eval("ID") %>' OnClick ="Ink_OnClick" 
                CommandName="id"/>
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") + " - " %>' />
            <asp:Label ID="AKTIVITASLabel" runat="server" class="aktivitasLB" Text='<%# Eval("AKTIVITAS").ToString().Length > 200 ? 
                    Eval("AKTIVITAS").ToString().Substring(0,200)+"..." : Eval("AKTIVITAS")%>' />
            <br />
            <br />
        </ItemTemplate>

    </asp:DataList>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KNOWLEDGEConnectionString2 %>" SelectCommand="SELECT * FROM [LOGBOOK]"></asp:SqlDataSource>
</form>
</asp:Content>

