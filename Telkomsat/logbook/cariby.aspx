<%@ Page Title="Search By" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="cariby.aspx.cs" Inherits="Telkomsat.logbook.cariby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="log.css" rel="stylesheet" type="text/css"/>
<form id="form1" runat="server">
    <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
            <asp:Label ID="lblWaktu" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        
    <h3><span style="left:20%">Input Logbook</span></h3>
        <asp:Label ID="lblUpdate" runat="server" Text=""></asp:Label>
        <br />
    <div class="divtabel" style="margin-left:80px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Tahun </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlTahun" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem>-</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:20px; height: 32px;">
                    <asp:Label ID="Label11" class="lbl" runat="server">Bulan </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:40px;">
                    <asp:DropDownList ID="ddlBulan" runat="server" class="ddl3" Width="129px">
                        <asp:ListItem Value="0">-</asp:ListItem>
                        <asp:ListItem Value="01">Januari</asp:ListItem>
                        <asp:ListItem Value="02">Februari</asp:ListItem>
                        <asp:ListItem Value="03">Maret</asp:ListItem>
                        <asp:ListItem Value="04">April</asp:ListItem>
                        <asp:ListItem Value="05">Mei</asp:ListItem>
                        <asp:ListItem Value="06">Juni</asp:ListItem>
                        <asp:ListItem Value="07">Juli</asp:ListItem>
                        <asp:ListItem Value="08">Agustus</asp:ListItem>
                        <asp:ListItem Value="09">September</asp:ListItem>
                        <asp:ListItem Value="10">Oktober</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">Desember</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:30px; height: 32px;">
                    <asp:Label ID="Label12" class="lbl" runat="server">Minggu </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlWeek" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem Value="0">-</asp:ListItem>
                        <asp:ListItem Value="1">Minggu 1</asp:ListItem>
                        <asp:ListItem Value="2">Minggu 2</asp:ListItem>
                        <asp:ListItem Value="3">Minggu 3</asp:ListItem>
                        <asp:ListItem Value="4">Minggu 4</asp:ListItem>
                        <asp:ListItem Value="5">Minggu 5</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label27" class="lbl" runat="server">Kategori  </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="7">
                    <asp:DropDownList ID="ddlKategori" runat="server" class="ddl3" Width="120px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Perbaikan</asp:ListItem>
                        <asp:ListItem>Perawatan</asp:ListItem>
                        <asp:ListItem>Pointing Antena</asp:ListItem>
                        <asp:ListItem>Penggantian</asp:ListItem>
                        <asp:ListItem>Lain-lain</asp:ListItem>
                    </asp:DropDownList>
                </td>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Event  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="5">
                    <asp:TextBox ID="txtEvent" class="tb1" runat="server" Width="630px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label25" class="lbl" runat="server">Unit  </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="4">
                    <asp:DropDownList ID="ddlUnit" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Harkat</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label8" class="lbl" runat="server">Status  </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="4">
                    <asp:DropDownList ID="ddlStatus" runat="server" class="ddl3" Width="140px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>On Progress</asp:ListItem>
                        <asp:ListItem>Selesai</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label2" class="lbl" runat="server">PIC OS</asp:Label>
                </td>
                <td style="padding-bottom:10px; padding-right:70px;" class="tdtext">
                    <asp:TextBox ID="txtOS" class="tb1" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td class="tdtext" style="padding-bottom:10px;  padding-right:30px;">
                    <asp:Label ID="Label6" class="lbl" runat="server">PIC OG  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtOG" class="tb1" runat="server" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-default" Width="110px" OnClick="btnCari_Click"/>
                </td>
            </tr>
        </table>
        <br />
       </div>     
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="False" style="margin:3px auto;" Font-Size="13px" BackColor="White" CssClass="gview"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center">
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
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID_Log") %>' OnClick ="Ink_OnClick1"> edit </asp:LinkButton>

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
      </div>
</form>

</asp:Content>
