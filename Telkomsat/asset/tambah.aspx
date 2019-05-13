<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="tambah.aspx.cs" Inherits="Telkomsat.asset.tambah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
            <asp:Label ID="lblWaktu" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        
    <h3><span style="left:20%">Masukkan Data Equipment</span></h3>
        <asp:Label ID="lblUpdate" runat="server" Text=""></asp:Label>
        <br />
    <div class="divtabel" style="margin-left:120px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Kelompok <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtKelompok" class="tb1" runat="server" Width="340px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label9" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtNama" class="tb1" runat="server" Width="340px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label2" runat="server" class="lbl">Merk <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtMerk" class="tb1" runat="server" Width="270px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label3" runat="server" class="lbl">Model</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label11" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtModel" class="tb1" runat="server" Width="270px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label4" runat="server" class="lbl">Serial Number </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label12" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtSN" class="tb1" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label5" runat="server" class="lbl">Product Number </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label13" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtPN" class="tb1" runat="server" Width="240px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label19" runat="server" class="lbl">Tahun Pengadaan </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label20" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtTahun" class="tb1" runat="server" Width="140px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label27" runat="server" class="lbl">Lokasi </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">

                </td>
                <td class="tdtext" style="padding-bottom:10px;">

                </td>
            </tr>
                            <tr>
                                <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label21" runat="server" class="lbl">Lokasi Site</asp:Label>
                                </td>
                                <td style="padding-bottom:10px;" class="titikdua">
                                    <asp:Label ID="Label22" runat="server">:</asp:Label>
                                </td>
                                <td class="tdtext" style="padding-bottom:10px;">
                                    <asp:DropDownList ID="ddlSite" runat="server" class="ddl3" onchange="GetTeamUsersByTeamID(this);">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>CBI</asp:ListItem>
                                        <asp:ListItem>BJR</asp:ListItem>
                                        <asp:ListItem>MDN</asp:ListItem>
                                        <asp:ListItem>MDO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label23" runat="server" class="lbl">Lokasi Gudang</asp:Label>
                                </td>
                                <td style="padding-bottom:10px;" class="titikdua">
                                    <asp:Label ID="Label24" runat="server">:</asp:Label>
                                </td>
                                <td class="tdtext" style="padding-bottom:10px; visibility:hidden;" id="gudang">
                                    <asp:DropDownList ID="ddlGudang" runat="server" class="ddl3" Width="70px">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>SR1</asp:ListItem>
                                        <asp:ListItem>SR2</asp:ListItem>
                                        <asp:ListItem>SR3</asp:ListItem>
                                        <asp:ListItem>SR4</asp:ListItem>
                                        <asp:ListItem>WRD3</asp:ListItem>
                                        <asp:ListItem>WRGCS</asp:ListItem>
                                        <asp:ListItem>SRC</asp:ListItem>
                                        <asp:ListItem>SRA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label25" runat="server" class="lbl">Lokasi Rak</asp:Label>
                                </td>
                                <td style="padding-bottom:10px;" class="titikdua">
                                    <asp:Label ID="Label26" runat="server">:</asp:Label>
                                </td>
                                <td class="tdtext" style="padding-bottom:10px; visibility:hidden;" id="rak">
                                    <asp:DropDownList ID="ddlRak" runat="server" class="ddl3" Width="60px">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>R1A</asp:ListItem>
                                        <asp:ListItem>R1B</asp:ListItem>
                                        <asp:ListItem>R1C</asp:ListItem>
                                        <asp:ListItem>R1D</asp:ListItem>
                                        <asp:ListItem>R2A</asp:ListItem>
                                        <asp:ListItem>R2B</asp:ListItem>
                                        <asp:ListItem>R2C</asp:ListItem>
                                        <asp:ListItem>R2D</asp:ListItem>
                                        <asp:ListItem>R3A</asp:ListItem>
                                        <asp:ListItem>R3B</asp:ListItem>
                                        <asp:ListItem>R3C</asp:ListItem>
                                        <asp:ListItem>R3D</asp:ListItem>
                                        <asp:ListItem>R4A</asp:ListItem>
                                        <asp:ListItem>R4B</asp:ListItem>
                                        <asp:ListItem>R4C</asp:ListItem>
                                        <asp:ListItem>R4D</asp:ListItem>
                                        <asp:ListItem>R5A</asp:ListItem>
                                        <asp:ListItem>R5B</asp:ListItem>
                                        <asp:ListItem>R5C</asp:ListItem>
                                        <asp:ListItem>R5D</asp:ListItem>
                                        <asp:ListItem>R6A</asp:ListItem>
                                        <asp:ListItem>R6B</asp:ListItem>
                                        <asp:ListItem>R6C</asp:ListItem>
                                        <asp:ListItem>R6D</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label28" runat="server" class="lbl">Kelompok Satelit </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">

                </td>
                <td class="tdtext" style="padding-bottom:10px;">

                </td>
            </tr>
                        <tr>
                            <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                <asp:Label ID="Label30" runat="server" class="lbl">Telkom2 </asp:Label>
                            </td>
                            <td style="padding-bottom:10px;" class="titikdua">
                                <asp:Label ID="Label31" runat="server">:</asp:Label>
                            </td>
                            <td class="tdtext" style="padding-bottom:10px;">
                                <asp:DropDownList ID="ddlTelkom2" runat="server" class="ddl3">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                <asp:Label ID="Label32" runat="server" class="lbl">Telkom3S </asp:Label>
                            </td>
                            <td style="padding-bottom:10px;" class="titikdua">
                                <asp:Label ID="Label33" runat="server">:</asp:Label>
                            </td>
                            <td class="tdtext" style="padding-bottom:10px;">
                                <asp:DropDownList ID="ddlTelkom3S" runat="server" class="ddl3">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                <asp:Label ID="Label34" runat="server" class="lbl">MPSat </asp:Label>
                            </td>
                            <td style="padding-bottom:10px;" class="titikdua">
                                <asp:Label ID="Label35" runat="server">:</asp:Label>
                            </td>
                            <td class="tdtext" style="padding-bottom:10px;">
                                <asp:DropDownList ID="ddlMPSat" runat="server" class="ddl3">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label6" runat="server" class="lbl">Fungsi </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label14" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlFungsi" runat="server" class="ddl3">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>OPERASIONAL</asp:ListItem>
                        <asp:ListItem>BACKUP</asp:ListItem>
                        <asp:ListItem>SPARE</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label7" runat="server" class="lbl">Status </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label15" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlStatus" runat="server" class="ddl3">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>BAIK</asp:ListItem>
                        <asp:ListItem>PERBAIKAN</asp:ListItem>
                        <asp:ListItem>RUSAK</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label8" runat="server" class="lbl">Keterangan</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label16" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtKeterangan" class="tb1" runat="server" Width="340px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:20px; padding-top:20px;" colspan="2">
                    <asp:Label ID="Label29" runat="server" class="lbl5">Masukkan Penulis </asp:Label>
                </td>

                <td class="tdtext" style="padding-bottom:20px; padding-top:20px;">

                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label36" runat="server" class="lbl">PIC <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label37" runat="server">:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtPIC" class="tb1" runat="server" Width="280px"></asp:TextBox>
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
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label> 
                </td>
            </tr>

            
        </table>
        </div>
        </div>
</form>

</asp:Content>
