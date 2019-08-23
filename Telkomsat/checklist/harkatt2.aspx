<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLIST.Master" AutoEventWireup="true" CodeBehind="harkatt2.aspx.cs" Inherits="Telkomsat.checklist.harkatt2" %>
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
                      <li class="select">Page 1</li>
                      <li>Page 2</li>
                      <li>Page 3</li>
                      <li>Page 4</li>
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
                          <td class="tabel" rowspan="1"><b>Switch & Distribution</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1SD1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label6" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>HPA Protection Switch</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter Backup</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1UC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label8" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtUC1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label46" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtUC1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label47" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Switch Over Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1SOU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label48" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Converter</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtSOU1c" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtSOU1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label49" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Priority</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtSOU1pr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label50" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Address</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtSOU1ad" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label51" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtSOU1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label52" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1UC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtUC2fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label53" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtUC2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label54" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up COnverter 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1UC3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtUC3fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label55" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtUC3at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label56" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Dehydrator</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1De1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
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
                      <li class="active">Page 1</li>
                      <li class="select">Page 2</li>
                      <li>Page 3</li>
                      <li>Page 4</li>
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
                          <td class="tabel" rowspan="2"><b>Power Meter</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2PM1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label57" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtPM1lv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label58" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>TLT Switch</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2TLT1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label59" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Switch</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RS1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label60" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>Digital Tracking Receiver</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddlDTR1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label61" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDTR1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label62" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">C/No</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDTR1c" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label63" runat="server" Text="dB.Hz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">TX Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDTR1tx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label64" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">DAC 1</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDTR1dac" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label65" runat="server" Text="VDC"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Manual Rate Control</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2MRC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label66" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Antena Control Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2ACU" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label67" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU2fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label68" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Azimuth</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU2az" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label69" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Elevation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU2el" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label70" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Polarization</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU2po" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label71" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Input</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtACU2rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label72" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Monitor RF</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2MR1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label73" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDC1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label74" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDC1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label75" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Switch Over Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2SOU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label76" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Converter</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1co" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label77" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Priority</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1pr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label78" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Address</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1ad" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label79" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label80" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down COnverter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC2fr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label81" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label82" runat="server" Text="dB"></asp:Label></td>
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
                <li class="active">Page 1</li>
                <li class="active">Page 2</li>
                <li class="select">Page 3</li>
                <li>Page 4</li>
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
                          <td class="tabel" rowspan="11"><b>KPA Backup</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3KPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Klystron Channel</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1kc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1bc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label4" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1ct" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label5" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1ot" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label13" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1bv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label14" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Volt</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1hv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label16" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label17" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1boc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label18" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>AC Power KPA Backup</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3AC" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
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
                      <li class="active">Page 1</li>
                      <li class="active">Page 2</li>
                      <li class="active">Page 3</li>
                      <li class="select">Page 4</li>
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
                          <td class="tabel" rowspan="11"><b>KPA 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4KPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label9" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Klystron Channel</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1kc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label10" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label11" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1bc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label12" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1ct" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label85" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1ot" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label86" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1bv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label87" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Volt</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1hv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label88" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label89" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1boc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label90" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>AC Power KPA 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4AC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label15" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="11"><b>KPA 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4KPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label91" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Klystron Channel</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2kc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label92" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label93" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2bc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label94" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2ct" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label95" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2ot" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label96" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2bv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label97" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Volt</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2hv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label98" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label99" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="TextBoxtxt4KPA2boc83" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label100" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>AC Power KPA 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4AC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label101" runat="server"></asp:Label></td>
                      </tr>
                     
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button9" runat="server" OnClientClick="return page3()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button10" runat="server" OnClientClick="return page5()" OnClick="Save_Click" Text="Save" Width="60px" CssClass="btn btn-success pull-right" />
              </div>
          </div>
          </div>

    <script type="text/javascript">
      function page2(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'block';
          document.getElementById("bayA3").style.display = 'none';
          document.getElementById("bay1").style.display = 'none';
          return false;
        }
        function page4(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'none';
            document.getElementById("bay1").style.display = 'block';
          return false;
        }
        function page3(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'block';
            document.getElementById("bay1").style.display = 'none';
          return false;
        }
        function page1(){
          // put your code here 
            document.getElementById("bayA4").style.display = 'block';
            document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'none';
            document.getElementById("bay1").style.display = 'none';
          return false;
        }



    function SetDropDownListColor(ddl) {
    for (var i = 0; i < ddl.options.length; i++) {
        if (ddl.options[i].selected) {
            switch (i) {
                case 0:
                    ddl.style.backgroundColor = '#38f345';
                    ddl.style.color = 'White';
                    return;
                case 1:
                    ddl.style.backgroundColor = '#ff3d3d';
                    return;
            }
        }
    }
        }

        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1SD1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1HPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1SOU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1De1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2PM1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2TLT1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2RS1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddlDTR1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2MRC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2ACU.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2SOU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2DC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2DC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3KPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3AC.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4KPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4AC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4KPA2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4AC2.ClientID %>')); }, false);
    </script>
</asp:Content>
