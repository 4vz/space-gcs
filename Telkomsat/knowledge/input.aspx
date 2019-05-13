<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="input.aspx.cs" Inherits="Telkomsat.Logbook.input" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <asp:Label ID="Label17" class="lbl" runat="server">Tanggal <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txtWaktu" class="tb1" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Nama <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label9" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtNama" class="tb1" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label2" runat="server" class="lbl">Judul <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtJudul" class="tb1" runat="server" Width="470px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label5" runat="server" class="lbl">Kategori <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label6" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:TextBox ID="txtKategori" class="tb1" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label3" runat="server" class="lbl">Kegiatan <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label4" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:TextBox ID="txtAktivitas" class="tb1" runat="server" TextMode="MultiLine" Height="500px" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label7" runat="server" class="lbl">Upload Gambar <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label8" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-default" Width="110px"/>
                </td>
            </tr>
            <tr>
        </table>
        
        </div>
        </div>
</form>

</asp:Content>
