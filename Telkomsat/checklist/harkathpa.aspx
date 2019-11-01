<%@ Page Title="HPA" Language="C#" MasterPageFile="~/CHECKLIST.Master" AutoEventWireup="true" CodeBehind="harkathpa.aspx.cs" Inherits="Telkomsat.checklist.harkathpa" %>
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
                          <td class="tabel" rowspan="8"><b>HPA A (XICOM)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1HPAA" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label48" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtHPAApo" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label27" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rfl Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtHPAArfl" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label49" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Twt Temp</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtHPAAtwt" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label50" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix I</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtHPAAheI" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label51" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix V</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtHPAAheV" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label28" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtHPAAhe" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label6" runat="server" Text="hours"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtHPAAbe" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server" Text="hours"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel" rowspan="1"><b>Switch HPA</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1SHPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>

                      <tr>
                          <td class="tabel" rowspan="8"><b>HPA B (XICOM)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1HPAB" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label8" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1HPABpo" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label19" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rfl Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1HPABrfl" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label20" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Twt Temp</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1HPABtwt" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label21" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix I</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1HPABheI" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label22" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix V</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1HPABheV" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label23" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1HPABhe" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label24" runat="server" Text="hours"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1HPABbe" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label25" runat="server" Text="hours"></asp:Label></td>
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
                          <td class="tabel" rowspan="7"><b>HPA 1 (CPI)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label26" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1rfo1" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label46" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rf Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1rfo2" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label47" runat="server" Text="w"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuator Setting</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label52" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label53" runat="server" Text="w"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1hec" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label54" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1hev" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label55" runat="server" Text="kV"></asp:Label></td>
                      </tr>

                      
                      <tr>
                          <td class="tabel" rowspan="1"><b>Switch Panel HPA</b></td>
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
                          <td class="tabel" rowspan="7"><b>HPA 2 (CPI)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2HPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label56" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2rfo1" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label64" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rf Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2rfo2" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label65" runat="server" Text="w"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuator Setting</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label66" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label67" runat="server" Text="w"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2hc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label68" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2hv" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label69" runat="server" Text="kV"></asp:Label></td>
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
                          <td style="width:100px; padding-left:10px; font-weight:bold">Perangkat</td>
                          <td style="width:100px; padding-left:10px; font-weight:bold">Parameter</td>
                          <td style="width:50px; padding-left:10px; font-weight:bold; text-align:center; max-width:150px;">Status/Nilai</td>
                          <td style="width:30px; padding-left:10px; font-weight:bold">Satuan</td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="8"><b>HPA A (XICOM)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPAA" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label29" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAApo" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label30" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rfl Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAArfl" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label31" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Twt Temp</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAAtwt" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label32" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix I</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAAhei" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label33" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix V</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAAhev" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label34" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAAhe" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label35" runat="server" Text="hours"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAAbe" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label36" runat="server" Text="hours"></asp:Label></td>
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
                          <td class="tabel"></td>
                      </tr>

                      <tr>
                          <td class="tabel" rowspan="8"><b>HPA 2 (CPI)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label37" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPArfo1" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label38" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rf Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPArfo2" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label39" runat="server" Text="w"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuator Setting</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAats" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label58" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPArrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label59" runat="server" Text="w"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAhec" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label60" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPAhev" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label61" runat="server" Text="kV"></asp:Label></td>
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
                          <td class="tabel" rowspan="7"><b>HPA A (COMTECH)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4HPAA" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPAApo" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label40" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rfl Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPAArfl" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label41" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Twt Temp</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPAAtwt" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label42" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPAAhec" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label43" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPAAhev" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label44" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPAAheav" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label45" runat="server" Text="hours"></asp:Label></td>
                      </tr>

                      <tr>
                          <td class="tabel" rowspan="1"><b>Switch Panel HPA</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4SPH" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="7"><b>HPA B (COMTECH)</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4HPAB" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label62" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPABrfo" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label63" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rfl Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPABrfl" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label70" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Twt Temp</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPABtwt" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label71" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPABhec" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label72" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPABhev" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label73" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4HPABheav" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label74" runat="server" Text="hours"></asp:Label></td>
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

        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1HPAA.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1SHPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1HPAB.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2HPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2UC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2HPA2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3HPAA.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3SHPA.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3HPA2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4HPAA.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4SPH.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4HPAB.ClientID %>')); }, false);
        
    </script>

</asp:Content>
