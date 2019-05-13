<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="tambah.aspx.cs" Inherits="Telkomsat.knowledge.tambah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script type="text/javascript">
$(document).ready(function(){
    $("#tr2").hide();
    $("#tr3").hide();
    $("#tr4").hide();
    var i = 0;
    $("#show").click(function () {
        i = i + 1;
        if (i == 1) {
            $("#tr2").show(700);
        }
        if (i == 2) {
            $("#tr3").show(700);
        }
        if (i == 3) {
            $("#tr4").show(700);
        }
    
  });
});
</script>
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
                    <asp:Label ID="Label17" class="lbl" runat="server">Tanggal</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txtWaktu" class="tb1" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Nama</asp:Label>
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
                    <asp:Label ID="Label2" runat="server" class="lbl">Judul</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="2">
                    <asp:TextBox ID="txtJudul" class="tb1" runat="server" Width="470px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label5" runat="server" class="lbl">Kategori</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label6" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:TextBox ID="txtKategori" class="tb1" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label3" runat="server" class="lbl">Posting</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label4" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext" colspan="2">
                    <asp:TextBox ID="txtAktivitas" class="tb1" runat="server" TextMode="MultiLine" Height="500px" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label7" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label8" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; padding-right:10px;" class="tdtext">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td style="padding-bottom:10px; white-space:nowrap; width:400px;" class="tdtext" >
                    <button id="show" type="button" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> 
                </td>
            </tr>
            <tr id="tr2">
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label11" runat="server" class="lbl">Upload Gambar </asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label12" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
            </tr>
            <tr id="tr3">
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label13" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label14" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </td>
            </tr>
            <tr id="tr4">
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label15" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label16" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-default" Width="110px"/>
                </td>
            </tr>
            <tr>
        </table>
        
        
        </div>
        </div>
</form>
</asp:Content>
