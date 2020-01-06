<%@ Page Title="Tambah Data" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="tambah.aspx.cs" Inherits="Telkomsat.asset.tambah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="StyleSheet1.css?version=8" />
    <script type="text/javascript" src="js1.js?version=4"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="text-align: left">
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
                    <asp:Label ID="Label66" class="lbl" runat="server">Jenis <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label67" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:DropDownList ID="ddlperangkat" runat="server" CssClass="tb1" Width="340px" onchange="GetTeam(this);">
                    </asp:DropDownList>
                </td>
                <td rowspan="18" style="padding-left:70px">

                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Jenis Equipment <span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:DropDownList ID="txtKelompok" runat="server" CssClass="tb1" Width="340px" onchange="GetTeam(this);">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>RF EQUIPMENT</asp:ListItem>
                        <asp:ListItem>BASEBAND</asp:ListItem>
                        <asp:ListItem>SERVER & NETWORK ELEMENT</asp:ListItem>
                        <asp:ListItem>MEASURING INSTRUMENT</asp:ListItem>
                        <asp:ListItem>ANTENNA</asp:ListItem>
                        <asp:ListItem>WORKSTATION</asp:ListItem>
                        <asp:ListItem>LICENSE</asp:ListItem>
                        <asp:ListItem>ACCESORIES</asp:ListItem>
                        <asp:ListItem>ELECTRICAL</asp:ListItem>
                        <asp:ListItem>GENSET</asp:ListItem>
                        <asp:ListItem>AIR CONDITIONING</asp:ListItem>
                        <asp:ListItem>UPS</asp:ListItem> 
                        <asp:ListItem>HYDRANT</asp:ListItem>
                        <asp:ListItem>FIRE ALARM PROTECTION</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td rowspan="18" style="padding-left:70px">
                    <img id="myImg" src="" style="width:400px"/>
                </td>
            </tr>
            <tr id="trDf" style="display:table-row">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label44" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label45" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px" class="tdtext">
                    <asp:DropDownList ID="DropDownList1" runat="server" class="ddl3" Width="340px">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
                    <tr id="trRF" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label1" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label9" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px" class="tdtext">
                            <asp:DropDownList ID="txtNama" runat="server" class="ddl3" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>UP CONVERTER</asp:ListItem>
                                <asp:ListItem>DOWN CONVERTER</asp:ListItem>
                                <asp:ListItem>MATRIX SWITCH</asp:ListItem>
                                <asp:ListItem>REDUNDANCY CONTROL UNIT (RCU)</asp:ListItem>
                                <asp:ListItem>REDUNDANT SYSTEM CONTROL (RSC)</asp:ListItem>
                                <asp:ListItem>TEST LOOP TRANSLATOR (TLT)</asp:ListItem>
                                <asp:ListItem>TEST LOOP SWITCH</asp:ListItem>
                                <asp:ListItem>BAND PASS FILTER</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr id="trBB" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label38" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label39" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamabb" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>GPS ANTENNA</asp:ListItem>
                                <asp:ListItem>GPS TIME SERVER</asp:ListItem>
                                <asp:ListItem>BASEBAND</asp:ListItem>
                                <asp:ListItem>MODEM</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trSN" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label40" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label41" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamasn" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>VM HARDWARE</asp:ListItem>
                                <asp:ListItem>NAS HARDWARE</asp:ListItem>
                                <asp:ListItem>FEP HARDWARE</asp:ListItem>
                                <asp:ListItem>ETHERNET HUB</asp:ListItem>
                                <asp:ListItem>ETHERNET SWITCH</asp:ListItem>
                                <asp:ListItem>FIREWALL</asp:ListItem>
                                <asp:ListItem>ROUTER</asp:ListItem>
                                <asp:ListItem>KVM</asp:ListItem>
                                <asp:ListItem>COMPASS SERVER</asp:ListItem>
                                <asp:ListItem>DEVICE MASTER</asp:ListItem>
                                <asp:ListItem>DIGITAL I/O MODULE</asp:ListItem>
                                <asp:ListItem>NETWORK SERIAL ADAPTER </asp:ListItem>
                                <asp:ListItem>WEB I/O RELAY</asp:ListItem>
                                <asp:ListItem>SEACAMS SERVER</asp:ListItem>
                                <asp:ListItem>SAT-ID SERVER</asp:ListItem>
                                <asp:ListItem>SERVER UNIT</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trAntena" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label42" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label43" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaantena" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>ANTENNA</asp:ListItem>
                                <asp:ListItem>MOTOR</asp:ListItem>
                                <asp:ListItem>ANTENNA CONTROL UNIT (ACU)</asp:ListItem>
                                <asp:ListItem>MANUAL CONTROL UNIT (MCU)</asp:ListItem>
                                <asp:ListItem>REMOTE CONTROL UNIT</asp:ListItem>
                                <asp:ListItem>ANTENA DRIVE UNIT (ADU)</asp:ListItem>
                                <asp:ListItem>SERVO DRIVES/ AMPLIFIER</asp:ListItem>
                                <asp:ListItem>DIGITAL TRACKING RECEIVER (DTR)</asp:ListItem>
                                <asp:ListItem>MONOPULSE TRACKING RECEIVER (MTR)</asp:ListItem>
                                <asp:ListItem>DUAL CHANNEL DOWN CONVERTER</asp:ListItem>
                                <asp:ListItem>OPTICAL ENCODER</asp:ListItem>
                                <asp:ListItem>TRACKING DOWN CONVERTER</asp:ListItem>
                                <asp:ListItem>RAIN /SNOW SENSOR</asp:ListItem>
                                <asp:ListItem>ANTENA CONTROL BOARD (ACB)</asp:ListItem>
                                <asp:ListItem>BLOCK DOWN CONTROL (BDC)</asp:ListItem>
                                <asp:ListItem>PHASE SHIFTER</asp:ListItem>
                                <asp:ListItem>LIMIT SWITCH</asp:ListItem>
                                <asp:ListItem>MOTOR</asp:ListItem>
                                <asp:ListItem>MOTOR</asp:ListItem>
                                <asp:ListItem>MOTOR</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trMI" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label46" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label47" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaMI" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>COMMUNICATION ANALYZER</asp:ListItem>
                                <asp:ListItem>SPECTRUM ANALYZER</asp:ListItem>
                                <asp:ListItem>SYNTHESIZER SWEEPER</asp:ListItem>
                                <asp:ListItem>POWER METER</asp:ListItem>
                                <asp:ListItem>POWER SENSOR</asp:ListItem>
                                <asp:ListItem>OSCILLOSCOPE</asp:ListItem>
                                <asp:ListItem>SYNCHROSCOPE</asp:ListItem>
                                <asp:ListItem>MULTIMETER</asp:ListItem>
                                <asp:ListItem>FREQUENCY COUNTER</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trWo" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label48" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label49" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaWo" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>WORKSTATION OPERASIONAL</asp:ListItem>
                                <asp:ListItem>WORKSTATION ENGINEERING</asp:ListItem>
                                <asp:ListItem>WORKSTATION FLIGHT DYNAMICS</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trLi" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label50" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label51" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaLi" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>EPOCH CLIENT LICENSES</asp:ListItem>
                                <asp:ListItem>EPOCH SERVER LICENSES</asp:ListItem>
                                <asp:ListItem>ARES LICENSES</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trAcc" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label52" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label53" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaAcc" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>WAVEGUIDE</asp:ListItem>
                                <asp:ListItem>POWER SUPPLY</asp:ListItem>
                                <asp:ListItem>EXHAUST FAN</asp:ListItem>
                                <asp:ListItem>DUMMYLOAD</asp:ListItem>
                                <asp:ListItem>FAN BLOWER</asp:ListItem>
                                <asp:ListItem>HARDISK</asp:ListItem>
                                <asp:ListItem>MODULE</asp:ListItem>
                                <asp:ListItem>CPU</asp:ListItem>
                                <asp:ListItem>MONITOR</asp:ListItem>
                                <asp:ListItem>SWITCH CONTROL</asp:ListItem>
                                <asp:ListItem>SWITCH POWER</asp:ListItem>
                                <asp:ListItem>PRINTER</asp:ListItem>
                                <asp:ListItem>LAPTOP</asp:ListItem>
                                <asp:ListItem>DEHYDRATOR</asp:ListItem>
                                <asp:ListItem>RF TO OPTIC CONVERTER</asp:ListItem>
                                <asp:ListItem>SIGNAL GENERATOR</asp:ListItem>
                                <asp:ListItem>PROTECTION SWITCH </asp:ListItem>
                                <asp:ListItem>PATCH PANEL</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trEl" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label54" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label55" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaEl" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>CUBICLE</asp:ListItem>
                                <asp:ListItem>TRAFO</asp:ListItem>
                                <asp:ListItem>MAIN DISTRIBUTION</asp:ListItem>
                                <asp:ListItem>ATS</asp:ListItem>
                                <asp:ListItem>FEEDER</asp:ListItem>
                                <asp:ListItem>AIR COMPRESSOR</asp:ListItem>
                                <asp:ListItem>ESSENTIAL PANEL</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trGe" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label56" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label57" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaGe" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>GENSET 625 KVA</asp:ListItem>
                                <asp:ListItem>GENSET 1500 KVA</asp:ListItem>
                                <asp:ListItem>BBM TANK</asp:ListItem>
                                <asp:ListItem>DAILY TANK</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trUPS" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label58" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label59" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaUPS" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>UPS 310 KVA</asp:ListItem>
                                <asp:ListItem>UPS 330 KVA</asp:ListItem>
                                <asp:ListItem>UPS 3.1 KVA</asp:ListItem>
                                <asp:ListItem>UPS 5 KVA</asp:ListItem>
                                <asp:ListItem>UPS 10 KVA</asp:ListItem>
                                <asp:ListItem>BATTERY UPS</asp:ListItem>
                                <asp:ListItem>APOTRANS</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trAC" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label60" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label61" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaAC" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>AC CHILLER</asp:ListItem>
                                <asp:ListItem>AHU</asp:ListItem>
                                <asp:ListItem>FAN COIL</asp:ListItem>
                                <asp:ListItem>AC PRECISION</asp:ListItem>
                                <asp:ListItem>AC STANDING FLOOR</asp:ListItem>
                                <asp:ListItem>AC PORTABLE</asp:ListItem>
                                <asp:ListItem>AC SPLIT</asp:ListItem>
                                <asp:ListItem>COMPRESSOR</asp:ListItem>
                                <asp:ListItem>AC PACKAGE</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trHy" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label62" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label63" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaHy" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>DIESEL ENGINE</asp:ListItem>
                                <asp:ListItem>PILLAR HYDRANT</asp:ListItem>
                                <asp:ListItem>WATER TANK</asp:ListItem>
                            </asp:DropDownList>  
                        </td>
                    </tr>
                    <tr id="trFi" style="display:none">
                        <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                            <asp:Label ID="Label64" class="lbl" runat="server">Nama Equipment<span class="spn"> * </span></asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="titikdua">
                            <asp:Label ID="Label65" runat="server" >:</asp:Label>
                        </td>
                        <td style="padding-bottom:10px;" class="tdtext">
                            <asp:DropDownList ID="txtnamaFi" runat="server" CssClass="tb1" Width="340px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>HSSD</asp:ListItem>
                                <asp:ListItem>FM 200</asp:ListItem>
                            </asp:DropDownList>  
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
                                        <asp:ListItem>BJM</asp:ListItem>
                                        <asp:ListItem>MDN</asp:ListItem>
                                        <asp:ListItem>MDO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label23" runat="server" class="lbl">Lokasi Ruangan</asp:Label>
                                </td>
                                <td style="padding-bottom:10px;" class="titikdua">
                                    <asp:Label ID="Label24" runat="server">:</asp:Label>
                                </td>
                                <td class="tdtext" style="padding-bottom:10px; visibility:hidden;" id="gudang">
                                    <asp:DropDownList ID="ddlGudang" runat="server" class="ddl3" Width="170px">
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
                                <td class="tdtext" style="padding-bottom:10px; padding-left:35px">
                                    <asp:Label ID="Label25" runat="server" class="lbl">Lokasi Rak</asp:Label>
                                </td>
                                <td style="padding-bottom:10px;" class="titikdua">
                                    <asp:Label ID="Label26" runat="server">:</asp:Label>
                                </td>
                                <td class="tdtext" style="padding-bottom:10px; visibility:hidden;" id="rak">
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

    <div id="myModal" class="modal">
      <span class="close">&times;</span>
      <img class="modal-content" id="img01" src="">
      <div id="caption"></div>
    </div>
    
    <script>
        var modal = document.getElementById("myModal");

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementById("myImg");
        var modalImg = document.getElementById("img01");
        var captionText = document.getElementById("caption");
        img.onclick = function(){
          modal.style.display = "block";
          modalImg.src = this.src;
          captionText.innerHTML = this.alt;
        }

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
            }

    </script>
</asp:Content>
