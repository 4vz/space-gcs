<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="tampil.aspx.cs" Inherits="Telkomsat.knowledge.tampil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div class="bodyLB">
    <asp:HiddenField ID="hfContactID" runat="server" />
    <asp:DataList runat="server" Width="568px" OnItemCommand="DataList1_ItemCommand" ID="DataList1">
        <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB" CommandArgument='<%# Eval("ID_Post") %>'  CommandName="id"/>
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# Eval("WAKTU")==DBNull.Value ? null : ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") + " - " %>' />
            <asp:Label ID="POSTINGLabel" runat="server" class="POSTINGLB" Text='<%# Eval("POSTING").ToString().Length > 200 ? 
                    Eval("POSTING").ToString().Substring(0,200)+"..." : Eval("POSTING")%>' />
            
            <br />
            <br />
        </ItemTemplate>

    </asp:DataList>
        <ul class="list-inline">
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lb1_Click" class="lbpaging" Text="<<"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lb2_Click" class="lbpaging" Text="prev"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lb3_Click" class="lbpaging" Text="next"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lb4_Click" class="lbpaging" Text=">>"></asp:LinkButton>
            </li>
        </ul>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KNOWLEDGEConnectionString2 %>" SelectCommand="SELECT * FROM [LOGBOOK]"></asp:SqlDataSource>
</form>

</asp:Content>
