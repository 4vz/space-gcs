<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Telkomsat.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
            <asp:Label ID="lblWaktu" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        <div class="divtabel">
        <h3><span style="left:20%">Data Equipment</span></h3>
        <asp:Label ID="lblSukses" runat="server" Text="" ForeColor="#33cc33"></asp:Label> 
        <br/>
        
        <table style="padding-left:150px;" class="tabel">
            <tr>
                <td class="tbl" style="padding-bottom:7px; padding-right:170px">
                    <asp:Label ID="Label1" runat="server" Text="Kelompok" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblKelompok" runat="server" Text="" Width="500px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label23" runat="server" Text="Nama" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblNama" runat="server" Text="" Width="500px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label2" runat="server" Text="Merk" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblMerk" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label3" runat="server" Text="Model" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblModel" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label4" runat="server" Text="Serial Number" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblSN" runat="server" Text="" Width="500px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label5" runat="server" Text="Product Number" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblPN" runat="server" Text="" Width="100px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:14px; padding-top:0;">
                    <asp:Label ID="Label14" runat="server" Text="Tahun Pengadaan" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:14px; padding-top:0;">
                    <asp:Label ID="lblTahun" runat="server" Text="" Width="500px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label12" runat="server" Text="Kelompok Satelit" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">

                </td>
            </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px;">
                            <asp:Label ID="lbl2" runat="server" Text="Telkom2" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px; ">
                            <asp:Label ID="lblTelkom2" runat="server" Text="" Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px">
                            <asp:Label ID="lbl1" runat="server" Text="Telkom3S" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px;">
                            <asp:Label ID="lblTelkom3S" runat="server" Text="" Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:15px; padding-left:35px">
                            <asp:Label ID="Label27" runat="server" Text="MPSat" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:15px;">
                            <asp:Label ID="lblMpsat" runat="server" Text="" Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>

            <tr>
                <td class="tbl" style="padding-bottom:10px;">
                    <asp:Label ID="Label7" runat="server" class="tb">Lokasi </asp:Label>
                </td>

                <td class="tdtext" style="padding-bottom:10px;">

                </td>
            </tr>
                            <tr>
                                <td class="tbl" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label21" runat="server" class="tb">Lokasi Site</asp:Label>
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
                                <td class="tbl" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label8" runat="server" class="tb">Lokasi Gudang</asp:Label>
                                </td>

                                <td class="tdtext" style="padding-bottom:10px; visibility:hidden;" id="gudang">
                                    <asp:DropDownList ID="ddlGudang" runat="server" class="ddl3">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>ATAS</asp:ListItem>
                                        <asp:ListItem>BAWAH</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tbl" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label25" runat="server" class="tb">Lokasi Rak</asp:Label>
                                </td>

                                <td class="tdtext" style="padding-bottom:10px; visibility:hidden;" id="rak">
                                    <asp:DropDownList ID="ddlRak" runat="server" class="ddl3">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>A</asp:ListItem>
                                        <asp:ListItem>B</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:10px;">
                    <asp:Label ID="Label6" runat="server" class="tb">Fungsi </asp:Label>
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
                <td class="tbl" style="padding-bottom:10px;">
                    <asp:Label ID="Label10" runat="server" class="tb">Status </asp:Label>
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
                <td class="tbl" style="padding-bottom:15px;">
                    <asp:Label ID="Label13" runat="server" Text="Keterangan" class="tb"></asp:Label>
                </td>

                <td class="tdtext" style="padding-bottom:15px;">
                    <asp:TextBox ID="txtKeterangan" runat="server" Text="" Width="250px" class="tb1" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:20px; padding-top:20px;" colspan="2">
                    <asp:Label ID="Label29" runat="server" class="lbl6">Masukkan Penulis </asp:Label>
                </td>

                <td class="tdtext" style="padding-bottom:20px; padding-top:20px;">

                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label36" runat="server" class="lbl">PIC <span class="spn"> * </span></asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtPIC" class="tb1" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-bottom:10px;">

                </td>
                <td style="padding-bottom:10px;">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click" CssClass="btn btn-default" Width="90px"/>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" CssClass="btn btn-default" Width="90px"/>
                </td>
            </tr>
        </table>
        </div>
    </div>
</form>

</asp:Content>
