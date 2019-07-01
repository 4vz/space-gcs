<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="searchby.aspx.cs" Inherits="Telkomsat.logbook1.searchby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>
        $(function () {
            $('#<%=txtsdate.ClientID%>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                onClose: function (selectedDate) {
                    $('#<%=txtedate.ClientID%>').datepicker("option", "minDate", selectedDate);
                }
            });

            $('#<%=txtedate.ClientID%>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                onClose: function (selectedDate) {
                    $('#<%=txtsdate.ClientID%>').datepicker("option", "maxDate", selectedDate);
                }

            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="../logbook/log.css" rel="stylesheet" type="text/css"/>

    <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
            <asp:Label ID="lblWaktu" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        
    <h3><span style="left:20%">Cari Berdasarkan</span></h3>
        <asp:Label ID="lblUpdate" runat="server" Text=""></asp:Label>
        <br />
    <div class="divtabel" style="margin-left:80px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Tanggal Mulai </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtsdate" runat="server" class="tb1"></asp:TextBox>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:20px; height: 32px;">
                    <asp:Label ID="Label11" class="lbl" runat="server">Tanggal Akhir </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:40px;">
                    <asp:TextBox ID="txtedate" runat="server" class="tb1"></asp:TextBox>
                </td>
                

            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label27" class="lbl" runat="server">Kategori  </asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlKategori" runat="server" class="ddl3" Width="120px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Perbaikan</asp:ListItem>
                        <asp:ListItem>Perawatan</asp:ListItem>
                        <asp:ListItem>Pointing Antena</asp:ListItem>
                        <asp:ListItem>Penggantian</asp:ListItem>
                        <asp:ListItem>Lain-lain</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:30px;">
                    <asp:Label ID="Label3" class="lbl" runat="server">SN Asset  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="5">
                    <asp:TextBox ID="txtSN" class="tb1" runat="server" Width="129PX"></asp:TextBox>
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
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlUnit" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Harkat</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label4" class="lbl" runat="server">Estimasi Harga </asp:Label>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
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
                    <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-default" Width="110px" OnClick="btnCari_Click"/>
                </td>
            </tr>
        </table>
        <br />
       </div>     
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="False" style="margin:3px auto;" Font-Size="13px" BackColor="White" OnRowDataBound="gvLog_RowData" CssClass="gview"
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
                        <asp:Label ID="lblImage" runat="server" Text='<%# Eval("Image1")!=DBNull.Value ? "@" : " " %>'></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("FileA")!=DBNull.Value ? "*" : " " %>'></asp:Label>
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
      </div>


</asp:Content>
