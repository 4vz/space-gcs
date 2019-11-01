<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLIST.Master" AutoEventWireup="true" CodeBehind="harkatbbu.aspx.cs" Inherits="Telkomsat.checklist.harkatbbu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="bayA4" style="display:block">
          <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header ui-sortable-handle">

                <i class="fa fa-inbox"></i> <h3 class="box-title">Rack 1</h3>

            </div>
              <div class="box-body">
                  <div style="padding-bottom:100px;">
                  <ul class="progressbar">
                      <li class="select">Rack 1</li>
                      <li>Rack 2</li>
                      <li>Rack 3</li>
                      <li>Rack 4</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td style="width:50px; padding-left:10px; font-weight:bold; text-align:center; max-width:150px;">Status/Nilai</td>
                          <td style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Uplink Switchbank</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1LAN1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label6" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Test Translator</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1TT1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Power Meter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1PM1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label8" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1PM1lv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label46" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Power Meter 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1PM2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label19" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1PM2lv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label20" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Baseband Generator</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1BG1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label21" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Synthesized Sweeper</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1SS1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label22" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1SS1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label47" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1SS1pl" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label23" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Tracking Receiver</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1TR1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label24" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Input Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TRif" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label25" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TRpl" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label26" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Antena Control Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1ACU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label48" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Azimuth</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU1az" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label27" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Elevasi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU1el" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label49" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Polarization</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU1po" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label50" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Signal</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU1si" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label51" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label28" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel" rowspan="1"><b>Manual Rate Control</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1MRC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Emergency Stop</td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1ES1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>UP/ Down Link</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1UP1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button5" runat="server" OnClientClick="return page2()" Text="Next" Width="60px" CssClass="btn btn-primary pull-right" />
              </div>
          </div>
          </div>

        <div id="bayA2" style="display:none">
          <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header ui-sortable-handle">

                <i class="fa fa-inbox"></i> <h3 class="box-title">Rack 2</h3>

            </div>
              <div class="box-body">
                  <div style="padding-bottom:100px;">
                  <ul class="progressbar">
                      <li class="active">Rack 1</li>
                      <li class="select">Rack 2</li>
                      <li>Rack 3</li>
                      <li>Rack 4</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td style="width:50px; padding-left:10px; font-weight:bold; text-align:center; max-width:150px;">Status/Nilai</td>
                          <td style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>Up Converter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2UC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label57" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label58" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label29" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Modulation Rate</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC1mr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label31" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Deviation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC1de" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label32" runat="server" Text="kHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>Up Converter 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddlUC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label33" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC2fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label34" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label35" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Modulation Rate</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC2mr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label37" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Deviation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC2de" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label38" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Uplink Switchbank</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2US1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label59" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA Switching & Combining</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label60" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Downlink Switchbank</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DS1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label61" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label30" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC2fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label62" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label63" runat="server" Text="dB.Hz"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DC3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC3fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label83" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC3at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label84" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Controller</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RC" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label36" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA Switching & Combining</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2HPASC" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label39" runat="server"></asp:Label></td>
                      </tr>
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button6" runat="server" OnClientClick="return page1()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button2" runat="server" OnClientClick="return page3()" Text="Next" Width="60px" CssClass="btn btn-primary pull-right" />
              </div>
          </div>
          </div>

<div id="bayA3" style="display:none">
    <div class="box box-primary">
    <!-- Tabs within a box -->
    <div class="box-header ui-sortable-handle">

        <i class="fa fa-inbox"></i> <h3 class="box-title">Rack 3</h3>

    </div>
        <div class="box-body">
            <div style="padding-bottom:100px;">
            <ul class="progressbar">
                <li class="active">Rack 1</li>
                <li class="active">Rack 2</li>
                <li class="select">Rack 3</li>
                <li>Rack 4</li>
            </ul>
                </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td style="width:50px; padding-left:10px; font-weight:bold; text-align:center; max-width:150px;">Status/Nilai</td>
                          <td style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Switch Input HPA</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3SIHPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Video Distribution Amplifier</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3VD" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label40" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Switch HPA</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3SHPA" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label41" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label42" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label43" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA 3</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPA3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label44" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA 4</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPA4" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label45" runat="server"></asp:Label></td>
                      </tr>
                      
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button7" runat="server" OnClientClick="return page2()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button8" runat="server" OnClientClick="return page4()" Text="Next" Width="60px" CssClass="btn btn-primary pull-right" />
              </div>
          </div>
          </div>

        <div id="bay1" style="display:none">
          <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header ui-sortable-handle">

                <i class="fa fa-inbox"></i> <h3 class="box-title">Rack 4</h3>

            </div>
              <div class="box-body">
                  <div style="padding-bottom:100px;">
                  <ul class="progressbar">
                      <li class="active">Rack 1</li>
                      <li class="active">Rack 2</li>
                      <li class="active">Rack 3</li>
                      <li class="select">Rack 4</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td style="width:50px; padding-left:10px; font-weight:bold; text-align:center; max-width:150px;">Status/Nilai</td>
                          <td style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="8"><b>HPA 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label9" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Channel</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA1ch" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label10" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA1rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label11" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA1rfo" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label12" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label85" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA1be" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label86" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Bdy</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA1bdy" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label87" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Drive</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA1rfd" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label88" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel" rowspan="1"><b>PSU HPA</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4PSUHPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label15" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="8"><b>HPA 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4HPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Channel</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA2ch" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA2rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label4" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA2rfo" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label5" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label13" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA2be" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label14" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Bdy</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA2bdy" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label16" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Drive</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPA2rfd" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label17" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel" rowspan="1"><b>PSU HPA 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4PSUHPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label18" runat="server"></asp:Label></td>
                      </tr>
                      
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button9" runat="server" OnClientClick="return page3()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button10" runat="server" OnClientClick="return page5()" Text="Save" Width="60px" CssClass="btn btn-success pull-right" />
              </div>
          </div>
          </div>

</asp:Content>
