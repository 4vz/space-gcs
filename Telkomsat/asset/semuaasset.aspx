<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="semuaasset.aspx.cs" Inherits="Telkomsat.asset.semuaasset" %>
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
        <asp:Label ID="lblCount" runat="server" Text="Label" CssClass="count1"></asp:Label>
        <asp:Button ID="btnExpand" runat="server" Text="Expand" OnClick="Expand_OnClick" class="cssexpand"/>
        <select class="ddl" id="urutkan" onChange="myNewFunction(this);" runat="server">
            <option >-Urutkan-</option>
            <option value="KELOMPOK">Kelompok</option>
            <option value="NAMA">Nama</option>
            <option value="MERK">Merk</option>
            <option value="SITE">Lokasi</option>
            <option value="FUNGSI">Fungsi</option>
            <option value="STATUS">Status</option>
        </select>
        <asp:Button ID="btnurut" runat="server" Text="Button" OnClick="btnurut_click" CssClass="urut"/>
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;"> 
        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False" style="margin:0 auto;" Font-Size="13px" BackColor="White" CssClass="gview" EnableViewState ="false"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" AllowPaging="true" PageSize="30" OnPageIndexChanging="OnPaging" OnPreRender="gvContact_PreRender">
            <Columns>
                <asp:BoundField DataField ="KELOMPOK" HeaderText ="KELOMPOK" ItemStyle-Width="140px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="NAMA" HeaderText ="NAMA" ItemStyle-Width="160px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="MERK" HeaderText ="MERK" ItemStyle-Width="170px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="MODEL" HeaderText ="MODEL" ItemStyle-Width="90px" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="S/N" HeaderText ="S/N" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="P/N" HeaderText ="P/N" ItemStyle-Width="120px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="SITE" HeaderText ="LOKASI" ItemStyle-Width="70px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="GUDANG" HeaderText ="RUANGAN" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="RAK" HeaderText ="RAK" ItemStyle-Width="50px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="TELKOM2" HeaderText ="TK2" ItemStyle-Width="50px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="TELKOM3S" HeaderText ="TK3S" ItemStyle-Width="50px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="MPSAT" HeaderText ="MPSAT" ItemStyle-Width="70px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="FUNGSI" HeaderText ="FUNGSI" ItemStyle-Width="110px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="STATUS" HeaderText ="STATUS" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID_Asset") %>' OnClick ="Ink_OnClick1">View</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           <FooterStyle BackColor="Yellow" ForeColor="Yellow" BorderStyle="Double" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#fafafa"/>
            <PagerStyle BackColor="White" CssClass="pagination-ys" HorizontalAlign="Right" Height="70px" VerticalAlign="Middle" 
                 BorderColor="White" BorderStyle="None" BorderWidth="0" />
            <PagerSettings Mode="Numeric" PageButtonCount="4" FirstPageText="1" />
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <asp:Label ID="lblPage" runat="server" Text="Label" CssClass="halaman"></asp:Label>
    </div>
    </form>
    <script type="text/javascript">
        function myNewFunction(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput == "KELOMPOK" || userinput == "NAMA" || userinput == "MERK" || userinput == "SITE"
                || userinput == "FUNGSI" || userinput == "STATUS")
            {
                document.getElementById('<%=btnurut.ClientID%>').click();
            }
        }
    </script>
</asp:Content>
