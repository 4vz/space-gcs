<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="filterbulan.aspx.cs" Inherits="Telkomsat.knowledge.filterbulan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
        </div>
        
        <h3 style="text-align: center">Logbook GCS</h3>
        <br/>
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="False" style="margin:3px auto;" Font-Size="13px" BackColor="White" OnRowDataBound="gvLog_RowData" CssClass="gview"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPaging" OnPreRender="gvLog_PreRender">
            <Columns>
                <asp:BoundField DataField ="tanggal" HeaderText ="Tanggal" ItemStyle-Width="100px" DataFormatString="{0:dd MMM yyyy}" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="event" HeaderText ="Event" ItemStyle-Width="220px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="mulai" HeaderText ="Mulai" ItemStyle-Width="80px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="selesai" HeaderText ="Selesai" ItemStyle-Width="80px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="info" HeaderText ="Info" ItemStyle-Width="300px" ItemStyle-CssClass="rows"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID") %>' OnClick ="Ink_OnClick1">edit</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           <FooterStyle BackColor="#FFFFCC" ForeColor="#ffffff"/>
            <HeaderStyle BackColor="#212325" Font-Bold="True" ForeColor="#fafafa" />
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
