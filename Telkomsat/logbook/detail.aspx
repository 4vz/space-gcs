<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Telkomsat.logbook.detail" %>
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
                    <asp:Label ID="Label17" class="lbl" runat="server">Tanggal </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:Label ID="txtTanggal" class="tb1" runat="server" Width="115px"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label27" class="lbl" runat="server">Kategori  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label28" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="7">
                    <asp:Label ID="lblKategori" class="tb1" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Event  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label9" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="4">
                    <asp:Label ID="txtEvent" class="tb1" runat="server" Width="570px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label25" class="lbl" runat="server">Unit  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label26" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="4">
                    <asp:Label ID="ddlUnit" class="tb1" runat="server" Width="570px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label8" class="lbl" runat="server">Status  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="4">
                    <asp:Label ID="ddlStatus" class="tb1" runat="server" Width="570px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label2" class="lbl" runat="server">PIC OS  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label5" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:Label ID="txtOS" class="tb1" runat="server" Width="180px"></asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:30px; padding-left:82px;">
                    <asp:Label ID="Label6" class="lbl" runat="server">PIC OG  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label7" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:Label ID="txtOG" class="tb1" runat="server" Width="180px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label3" runat="server" class="lbl">Kegiatan  </asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label4" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext" colspan="4">
                    <asp:Label ID="txtInfo" class="tb1" runat="server" TextMode="MultiLine" Width="570px"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-default" Width="110px" onclick="btnEdit_Click"/>
                </td>
            </tr>
        </table>
        <br />
        <asp:DataList runat="server" id="dtContact" Width="1135px" RepeatColumns="3" GridLines="Both" RepeatDirection="Horizontal" >
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" Width="250px" ImageUrl='<%# Eval("Image1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image1")) %>'/>
            <asp:Image ID="Image2" runat="server" Width="250px" ImageUrl='<%# Eval("Image2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image2")) %>'/>
            <asp:Image ID="Image3" runat="server" Width="250px" ImageUrl='<%# Eval("Image3")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image3")) %>'/>
            <asp:Image ID="Image4" runat="server" Width="250px" ImageUrl='<%# Eval("Image4")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image4")) %>'/>
            <asp:Image ID="File1" runat="server" Width="250px" ImageUrl='<%# Eval("File1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("File1")) %>'/>
            <asp:Image ID="File2" runat="server" Width="250px" ImageUrl='<%# Eval("File2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("File2")) %>'/>
            <br />
        </ItemTemplate>

    </asp:DataList>
        <br />
       </div>     
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        
      </div>
    </form>
</asp:Content>
