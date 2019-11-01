<%@ Page Title="Edit" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Telkomsat.asset.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                        <asp:ListItem>BJM</asp:ListItem>
                                        <asp:ListItem>MDN</asp:ListItem>
                                        <asp:ListItem>MDO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tbl" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label8" runat="server" class="tb">Lokasi Ruangan</asp:Label>
                                </td>

                                <td class="tdtext" style="padding-bottom:10px; visibility:visible;" id="gudang">
                                    <asp:DropDownList ID="ddlGudang" runat="server" class="ddl3" Width="175px">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>AHRA</asp:ListItem>
                                        <asp:ListItem>AHRB</asp:ListItem>
                                        <asp:ListItem>ATSR</asp:ListItem>
                                        <asp:ListItem>BBBJM</asp:ListItem>
                                        <asp:ListItem>BBRC</asp:ListItem>
                                        <asp:ListItem>BCS-BJM</asp:ListItem>
                                        <asp:ListItem>BTRR</asp:ListItem>
                                        <asp:ListItem>CHLR</asp:ListItem>
                                        <asp:ListItem>Console</asp:ListItem>
                                        <asp:ListItem>Consul SAT</asp:ListItem>
                                        <asp:ListItem>CSLR</asp:ListItem>
                                        <asp:ListItem>D2B</asp:ListItem>
                                        <asp:ListItem>D3</asp:ListItem>
                                        <asp:ListItem>D3B</asp:ListItem>
                                        <asp:ListItem>D4B</asp:ListItem>
                                        <asp:ListItem>EST1</asp:ListItem>
                                        <asp:ListItem>exT1</asp:ListItem>
                                        <asp:ListItem>FDRR</asp:ListItem>
                                        <asp:ListItem>FMA 11</asp:ListItem>
                                        <asp:ListItem>GDPB</asp:ListItem>
                                        <asp:ListItem>GDU</asp:ListItem>
                                        <asp:ListItem>GSTR</asp:ListItem>
                                        <asp:ListItem>HDDR</asp:ListItem>
                                        <asp:ListItem>HDRR</asp:ListItem>
                                        <asp:ListItem>Helpdesk</asp:ListItem>
                                        <asp:ListItem>HPA</asp:ListItem>
                                        <asp:ListItem>HPAR</asp:ListItem>
                                        <asp:ListItem>MPSAT</asp:ListItem>
                                        <asp:ListItem>MSQR</asp:ListItem>
                                        <asp:ListItem>OOR</asp:ListItem>
                                        <asp:ListItem>PSEC1</asp:ListItem>
                                        <asp:ListItem>PSEC2</asp:ListItem>
                                        <asp:ListItem>RFBJM</asp:ListItem>
                                        <asp:ListItem>S16M</asp:ListItem>
                                        <asp:ListItem>SF11</asp:ListItem>
                                        <asp:ListItem>SF9,8M</asp:ListItem>
                                        <asp:ListItem>SFMR</asp:ListItem>
                                        <asp:ListItem>Shelter T3S KU</asp:ListItem>
                                        <asp:ListItem>Shelter T4</asp:ListItem>
                                        <asp:ListItem>SMKU</asp:ListItem>
                                        <asp:ListItem>SMPSAT</asp:ListItem>
                                        <asp:ListItem>SR1</asp:ListItem>
                                        <asp:ListItem>SR2</asp:ListItem>
                                        <asp:ListItem>SR2BJM</asp:ListItem>
                                        <asp:ListItem>SR3</asp:ListItem>
                                        <asp:ListItem>SRME</asp:ListItem>
                                        <asp:ListItem>ST2</asp:ListItem>
                                        <asp:ListItem>ST3SC</asp:ListItem>
                                        <asp:ListItem>ST3SKU</asp:ListItem>
                                        <asp:ListItem>STAR</asp:ListItem>
                                        <asp:ListItem>STEL</asp:ListItem>
                                        <asp:ListItem>T2</asp:ListItem>
                                        <asp:ListItem>T3S-C</asp:ListItem>
                                        <asp:ListItem>T3S-KU</asp:ListItem>
                                        <asp:ListItem>TAR</asp:ListItem>
                                        <asp:ListItem>TAR Medan</asp:ListItem>
                                        <asp:ListItem>TCCR</asp:ListItem>
                                        <asp:ListItem>TELIN</asp:ListItem>
                                        <asp:ListItem>TRFR</asp:ListItem>
                                        <asp:ListItem>UPSR</asp:ListItem>
                                        <asp:ListItem>VSAT</asp:ListItem>
                                        <asp:ListItem>WRKM</asp:ListItem>
                                        <asp:ListItem>WSBJM</asp:ListItem>
                                        <asp:ListItem>WS-D3</asp:ListItem>
                                        <asp:ListItem>WTTR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tbl" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label25" runat="server" class="tb">Lokasi Rak</asp:Label>
                                </td>

                                <td class="tdtext" style="padding-bottom:10px; visibility:visible;" id="rak">
                                    <asp:DropDownList ID="ddlRak" runat="server" class="ddl3" Width="160px">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>43</asp:ListItem>
                                        <asp:ListItem>44</asp:ListItem>
                                        <asp:ListItem>45</asp:ListItem>
                                        <asp:ListItem>49</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>55</asp:ListItem>
                                        <asp:ListItem>58</asp:ListItem>
                                        <asp:ListItem>59</asp:ListItem>
                                        <asp:ListItem>60</asp:ListItem>
                                        <asp:ListItem>64</asp:ListItem>
                                        <asp:ListItem>1-Telvis</asp:ListItem>
                                        <asp:ListItem>2-Telvis</asp:ListItem>
                                        <asp:ListItem>A2</asp:ListItem>
                                        <asp:ListItem>A3</asp:ListItem>
                                        <asp:ListItem>A4</asp:ListItem>
                                        <asp:ListItem>Antena</asp:ListItem>
                                        <asp:ListItem>Antena 9M</asp:ListItem>
                                        <asp:ListItem>Control</asp:ListItem>
                                        <asp:ListItem>GCE M&C</asp:ListItem>
                                        <asp:ListItem>L1.1E</asp:ListItem>
                                        <asp:ListItem>L1.2E</asp:ListItem>
                                        <asp:ListItem>L1.3</asp:ListItem>
                                        <asp:ListItem>OOR</asp:ListItem>
                                        <asp:ListItem>R1</asp:ListItem>
                                        <asp:ListItem>R1A</asp:ListItem>
                                        <asp:ListItem>R1B</asp:ListItem>
                                        <asp:ListItem>R1C</asp:ListItem>
                                        <asp:ListItem>R1D</asp:ListItem>
                                        <asp:ListItem>R1E</asp:ListItem>
                                        <asp:ListItem>R1TOR</asp:ListItem>
                                        <asp:ListItem>R2</asp:ListItem>
                                        <asp:ListItem>R2A</asp:ListItem>
                                        <asp:ListItem>R2B</asp:ListItem>
                                        <asp:ListItem>R2C</asp:ListItem>
                                        <asp:ListItem>R2D</asp:ListItem>
                                        <asp:ListItem>R2E</asp:ListItem>
                                        <asp:ListItem>R3</asp:ListItem>
                                        <asp:ListItem>R3A</asp:ListItem>
                                        <asp:ListItem>R3B</asp:ListItem>
                                        <asp:ListItem>R3C</asp:ListItem>
                                        <asp:ListItem>R3D</asp:ListItem>
                                        <asp:ListItem>R3E</asp:ListItem>
                                        <asp:ListItem>R4</asp:ListItem>
                                        <asp:ListItem>R4A</asp:ListItem>
                                        <asp:ListItem>R4B</asp:ListItem>
                                        <asp:ListItem>R4C</asp:ListItem>
                                        <asp:ListItem>R4D</asp:ListItem>
                                        <asp:ListItem>R5</asp:ListItem>
                                        <asp:ListItem>R6</asp:ListItem>
                                        <asp:ListItem>R6E</asp:ListItem>
                                        <asp:ListItem>R6H</asp:ListItem>
                                        <asp:ListItem>R7</asp:ListItem>
                                        <asp:ListItem>RAK A11</asp:ListItem>
                                        <asp:ListItem>RAK A13</asp:ListItem>
                                        <asp:ListItem>RAK B10</asp:ListItem>
                                        <asp:ListItem>RAK B9</asp:ListItem>
                                        <asp:ListItem>RFX</asp:ListItem>
                                        <asp:ListItem>RRR</asp:ListItem>
                                        <asp:ListItem>RSR</asp:ListItem>
                                        <asp:ListItem>RSRT4</asp:ListItem>
                                        <asp:ListItem>RT2</asp:ListItem>
                                        <asp:ListItem>RT3S</asp:ListItem>
                                        <asp:ListItem>RT4</asp:ListItem>
                                        <asp:ListItem>RVSAT</asp:ListItem>
                                        <asp:ListItem>RX</asp:ListItem>
                                        <asp:ListItem>SatID</asp:ListItem>
                                        <asp:ListItem>SCPS</asp:ListItem>
                                        <asp:ListItem>Seacams</asp:ListItem>
                                        <asp:ListItem>TORTx3</asp:ListItem>
                                        <asp:ListItem>tower BCS</asp:ListItem>
                                        <asp:ListItem>Tx</asp:ListItem>
                                        <asp:ListItem>Tx1</asp:ListItem>
                                        <asp:ListItem>Tx2</asp:ListItem>
                                        <asp:ListItem>Tx3</asp:ListItem>
                                        <asp:ListItem>UPLINK</asp:ListItem>
                                        <asp:ListItem>VSAT</asp:ListItem>
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
                        <asp:ListItem>BACKUP OPERASIONAL</asp:ListItem>
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
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" OnClientClick="if (!confirm('Are you sure you want to delete?')) return false;" CssClass="btn btn-default" Width="90px"/>
                </td>
            </tr>
        </table>
        </div>
    </div>

</asp:Content>
