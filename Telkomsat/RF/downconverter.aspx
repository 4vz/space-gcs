<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="downconverter.aspx.cs" Inherits="Telkomsat.RF.downconverter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
        </div>
        
        <h3 style="text-align: center">Database Aset Telkomsat</h3>
        <br/>
        <asp:Label ID="lblCount" runat="server" Text="Label" CssClass="count"></asp:Label>
        <asp:Button ID="btnExpand" runat="server" Text="Expand" OnClick="Expand_OnClick" class="cssexpand"/>
        <select class="ddl">
            <option>-Urutkan-</option>
            <option>Kelompok</option>
            <option>Nama</option>
            <option>Merk</option>
            <option>Lokasi</option>
            <option>Fungsi</option>
            <option>Status</option>
        </select>
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False" style="margin:0 auto;" Font-Size="13px" BackColor="White"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" AllowPaging="true" PageSize="20" OnPageIndexChanging="OnPaging" OnPreRender="gvContact_PreRender">
            <Columns>
                <asp:BoundField DataField ="KELOMPOK" HeaderText ="KELOMPOK" ItemStyle-Width="140px"/>
                <asp:BoundField DataField ="NAMA" HeaderText ="NAMA" ItemStyle-Width="160px" />
                <asp:BoundField DataField ="MERK" HeaderText ="MERK" ItemStyle-Width="170px" />
                <asp:BoundField DataField ="MODEL" HeaderText ="MODEL" ItemStyle-Width="90px" />
                <asp:BoundField DataField ="S/N" HeaderText ="S/N" ItemStyle-Width="90px"/>
                <asp:BoundField DataField ="P/N" HeaderText ="P/N" ItemStyle-Width="120px"/>
                <asp:BoundField DataField ="SITE" HeaderText ="LOKASI" ItemStyle-Width="70px" />
                <asp:BoundField DataField ="GUDANG" HeaderText ="GUDANG" ItemStyle-Width="90px"/>
                <asp:BoundField DataField ="RAK" HeaderText ="RAK" ItemStyle-Width="50px"/>
                <asp:BoundField DataField ="TELKOM2" HeaderText ="TK2" ItemStyle-Width="50px"/>
                <asp:BoundField DataField ="TELKOM3S" HeaderText ="TK3S" ItemStyle-Width="50px"/>
                <asp:BoundField DataField ="MPSAT" HeaderText ="MPSAT" ItemStyle-Width="70px"/>
                <asp:BoundField DataField ="FUNGSI" HeaderText ="FUNGSI" ItemStyle-Width="110px"/>
                <asp:BoundField DataField ="STATUS" HeaderText ="STATUS" ItemStyle-Width="90px"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID") %>' OnClick ="Ink_OnClick1">View</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#ffffff"/>
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#fafafa" />
            <PagerStyle BackColor="White" CssClass="pagination-ys" HorizontalAlign="Right" Height="50px" VerticalAlign="Bottom"/>
            <PagerSettings Mode="Numeric" PageButtonCount="4" FirstPageText="1" />
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblPage" runat="server" Text="Label" CssClass="halaman"></asp:Label>
    </div>
    </form>
</asp:Content>
