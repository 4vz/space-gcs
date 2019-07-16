<%@ Page Title="" Language="C#" MasterPageFile="~/KnowledgeFIle.Master" AutoEventWireup="true" CodeBehind="tambah.aspx.cs" Inherits="Telkomsat.File.tambah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard.aspx">
          <img src="../img/logotelkomsat2.png" alt="Alternate Text" height="50"/></a>
          <input type="text" name="q" class="form-control" placeholder="Search..." runat="server" id="txtMaster" style="vertical-align:middle"/>
          <span class="input-group-btn">
                <button type="submit" name="search" class="btn btn-flat" runat="server" onserverclick="btnSearch_Click"><i class="fa fa-search"></i>
                </button>
              </span>  
    </div>
    </div>
    </header>

    <br /> 
    <div class="content-wrapper">
    <section class="content">
        <div class="bodyLB2">

        <ul class="list-inline">
            <li>
                <asp:Button ID="Button1" runat="server" Text="Posting" CssClass="btn btn-sm" Width="80px" OnClick="btnPosting_Click"/>
            </li>
            <li style="margin-right:300px;">
                <asp:Button ID="Button3" runat="server" Text="File" CssClass="btn btn-adn" Width="80px" OnClick="btnFile_Click"/>
            </li>
            <li>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl28" Width="120px">
                    <asp:ListItem>-Kategori-</asp:ListItem>
                    <asp:ListItem>Upload</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </li>
            <li style="margin-right:10px;">
                <button type="submit" class="btn-file" runat="server" onserverclick="btnTambah_Click"><i class="fa fa-plus" style="font-size:12px"></i> Tambah
                </button>
            </li>
        </ul>
        <br />
        </div>

    <h3><span style="left:20%">Input File</span></h3>
        <asp:Label ID="lblBerhasil" runat="server" Text="Label" Visible="false"></asp:Label>
    <div class="divtabel" style="margin-left:80px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Tanggal </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext" >
                    <asp:TextBox ID="txtTanggal" class="tb1" runat="server" Width="115px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label27" class="lbl" runat="server">Kategori  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label28" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlKategori" runat="server" class="ddl3" Width="120px" onchange="kategori1(this);">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Buku Manual</asp:ListItem>
                        <asp:ListItem>Pelatihan</asp:ListItem>
                        <asp:ListItem>SOP</asp:ListItem>
                        <asp:ListItem>Pembaruan Konfigurasi</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trawal">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Kategori 1  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label9" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddl1" runat="server" class="ddl3" Width="120px" onchange="status(this)">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trBuku" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label25" class="lbl" runat="server">Lokasi  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label26" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlBuku" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Banjarmasin</asp:ListItem>
                        <asp:ListItem>Cibinong</asp:ListItem>
                        <asp:ListItem>Manado</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trPelatihan" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label2" class="lbl" runat="server">Pemakaian  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label3" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlPelatihan" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Satelit</asp:ListItem>
                        <asp:ListItem>Ground</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trSOP" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label4" class="lbl" runat="server">Satelit  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label5" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlSOP" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Telkom 2</asp:ListItem>
                        <asp:ListItem>Telkom 3S</asp:ListItem>
                        <asp:ListItem>MPSat</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trPelatihanSatelit" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label6" class="lbl" runat="server">Satelit </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label7" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlPelatihan1" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Telkom 2</asp:ListItem>
                        <asp:ListItem>Telkom 3S</asp:ListItem>
                        <asp:ListItem>MPSat</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trBukuEquipment" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label8" class="lbl" runat="server">Equipment  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlBuku1" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>RF Equipment</asp:ListItem>
                        <asp:ListItem>Baseband</asp:ListItem>
                        <asp:ListItem>Server & NE</asp:ListItem>
                        <asp:ListItem>Antena</asp:ListItem>
                        <asp:ListItem>Alat Ukur</asp:ListItem>
                        <asp:ListItem>Workstation</asp:ListItem>
                        <asp:ListItem>License</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trPembaruan1" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label11" class="lbl" runat="server">Sub-kategori </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label12" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlPembaruan1" runat="server" class="ddl3" Width="100px" onchange="pembaruan(this)">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Operasional</asp:ListItem>
                        <asp:ListItem>Network</asp:ListItem>
                        <asp:ListItem>Communication & Monitor</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trPembaruanOp" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label13" class="lbl" runat="server">Satelit </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label14" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlPembaruanOp" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Telkom 2</asp:ListItem>
                        <asp:ListItem>Telkom 3S</asp:ListItem>
                        <asp:ListItem>MPSat</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trPembaruanNe" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label15" class="lbl" runat="server">Lokasi </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label16" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlPembaruanNe" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Banjarmasin</asp:ListItem>
                        <asp:ListItem>Cibinong</asp:ListItem>
                        <asp:ListItem>Manado</asp:ListItem>
                        <asp:ListItem>Medan</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr id="trPembaruanOp1" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label19" class="lbl" runat="server">Lokasi </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label20" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlPembaruanOp1" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Banjarmasin</asp:ListItem>
                        <asp:ListItem>Cibinong</asp:ListItem>
                        <asp:ListItem>Manado</asp:ListItem>
                        <asp:ListItem>Medan</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">

                </td>
                <td style="padding-bottom:10px;" class="titikdua">

                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:FileUpload ID="fuimage" runat="server"></asp:FileUpload>
                </td>
            </tr>

            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">

                </td>
                <td style="padding-bottom:10px;" class="titikdua">

                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-default" Width="110px"/>
                </td>
            </tr>
            </table>
        </div>
        </section>
        </div>
    </form>

    <script src="filejs.js"></script>
</asp:Content>
