<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="snasset.aspx.cs" Inherits="Telkomsat.logbook1.snasset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="log.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div class="datakita" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
        </div>
        
        
        <div class="input-group">
          <span class="headlb">Logbook GCS</span>
          <input type="text" name="q" class="form-control" placeholder="Search..." runat="server" id="inputsearch"/>
          <span class="input-group-btn">
                <button type="submit" name="search" class="btn btn-flat" runat="server" onserverclick="btnSearch_Click"><i class="fa fa-search"></i>
                </button>
              </span>
            
        </div>     
        <br />
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="False" style="margin:3px auto;" Font-Size="13px" BackColor="White" OnRowDataBound="gvLog_RowData" CssClass="gview"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" AllowPaging="true" PageSize="20" OnPageIndexChanging="OnPaging" OnPreRender="gvLog_PreRender">
            <Columns>
                <asp:BoundField DataField ="tanggal" HeaderText ="Tanggal" ItemStyle-Width="100px" DataFormatString="{0:dd MMM yyyy}" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="Unit" HeaderText ="Unit" ItemStyle-Width="80px" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="Kategori" HeaderText ="Kategori" ItemStyle-Width="120px" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="event" HeaderText ="Event" ItemStyle-Width="230px" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="Status" HeaderText ="Status" ItemStyle-Width="120px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="info" HeaderText ="Info" ItemStyle-Width="300px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="PIC_OG" HeaderText ="PIC_OG" ItemStyle-Width="80px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="PIC_OS" HeaderText ="PIC_OS" ItemStyle-Width="80px" ItemStyle-CssClass="rows"/>
                <asp:TemplateField HeaderText="Attach">
                    <ItemTemplate>
                        <asp:Label ID="lblImage" runat="server" Text='<%# Eval("Image1")!=DBNull.Value || Eval("File1")!=DBNull.Value ? "@" : " " %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID_Logbook") %>' OnClick ="Ink_OnClick1"> edit </asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           <FooterStyle BackColor="Yellow" ForeColor="Yellow" BorderStyle="Double" />
            <HeaderStyle BackColor="#212325" Font-Bold="True" ForeColor="#fafafa"/>
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
</asp:Content>
