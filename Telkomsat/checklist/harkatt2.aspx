<%@ Page Title="Telkom 2" Language="C#" MasterPageFile="~/CHECKLIST.Master" AutoEventWireup="true" CodeBehind="harkatt2.aspx.cs" Inherits="Telkomsat.checklist.harkatt2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box box-header" style="margin-bottom:0px">
        <asp:Label ID="Label22" runat="server" Text="Shelter Telkom 2" Font-Size="Large" Font-Bold="true"></asp:Label>
        <asp:Label ID="lblstatus" runat="server" Font-Size="Large" Font-Bold="true" Visible="false"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Copy From The Last" CssClass="btn btn-sm btn-primary pull-right" OnClick="inisialisasi_Click" />
    </div>
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
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit (RCU)</b><asp:Label ID="lbl1rcu" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1RCU" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl1uc1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
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
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1UC1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label46" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1UC1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label47" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Redundant Control Unit (RCU)</b><asp:Label ID="lbl1rcu1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1RCU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label48" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Converter</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1SOU1c" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1SOU1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label49" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Priority</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1SOU1pr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label50" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Address</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1SOU1ad" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label51" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1SOU1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label52" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter </b><asp:Label ID="lbl1uc2" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1UC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1UC2fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label53" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1UC2at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label54" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl1uc3" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1UC3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1UC3fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label55" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1UC3at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label56" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Modem</b><asp:Label ID="lbl1mo" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1Mo" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">IF Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1MoFr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label19" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">IF Power</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1MoPo" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label20" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Dehydrator</b><asp:Label ID="lbl1de" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1De1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Pressure</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1DePr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label21" runat="server" Text="mBar"></asp:Label></td>
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
                          <td class="tabel" rowspan="2"><b>Power Meter</b><asp:Label ID="lbl2pm" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2PM1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label57" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2PM1lv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label58" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>TLT Switch</b><asp:Label ID="lbl2tlt" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2TLT1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label59" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Switch</b><asp:Label ID="lbl2rs" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RS1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label60" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>Digital Tracking Receiver</b><asp:Label ID="lbl2dtr" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddlDTR1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label61" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DTR1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label62" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">C/No</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DTR1c" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label63" runat="server" Text="dB.Hz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">TX Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DTR1tx" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label64" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">DAC 1</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DTR1dac" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label65" runat="server" Text="VDC"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Manual Rate Control</b><asp:Label ID="lbl2mrc" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2MRC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label66" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Antena Control Unit</b><asp:Label ID="lbl2acu" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2ACU" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label67" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2ACU2fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label68" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Azimuth</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2ACU2az" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label69" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Elevation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2ACU2el" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label70" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Polarization</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2ACU2po" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label71" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Input</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2ACU2rf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label72" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b><asp:Label ID="lbl2dc" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label74" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label75" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Redundant Control Unit (RCU)</b><asp:Label ID="lbl2rcu" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RCU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label76" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Converter</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1co" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label77" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Priority</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1pr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label78" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Address</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1ad" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label79" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2SOU1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label80" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 1</b><asp:Label ID="lbl2dc1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC2fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label81" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC2at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label82" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 2</b><asp:Label ID="lbl2dc2" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2DC3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC3fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label83" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2DC3at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
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
                          <td class="tabel" rowspan="11"><b>HPA</b><asp:Label ID="lbl3hpa1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1rf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label6" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Klystron Channel</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1kc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1bc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label4" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1ct" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label5" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1ot" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label13" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1bv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label14" runat="server" Text="KV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Volt</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1hv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label16" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label17" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3KPA1boc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label18" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Power Supply</b><asp:Label ID="lbl3aps" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3AC" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
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
                          <td class="tabel" rowspan="11"><b>HPA</b><asp:Label ID="lbl4hpa1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label9" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1rf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label23" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Klystron Channel</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1kc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label10" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label11" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1bc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label12" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1ct" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label85" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1ot" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label86" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1bv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label87" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Volt</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1hv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label88" runat="server" Text="KV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label89" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA1boc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label90" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>AC Power HPA 1</b><asp:Label ID="lbl4ps" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4AC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label15" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="11"><b>HPA</b><asp:Label ID="lbl4hpa2" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4HPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label91" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2rf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label24" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuator</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label92" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label93" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2hc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label94" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Helix Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4KPA2hv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label95" runat="server" Text="KV"></asp:Label></td>
                      </tr>
                      
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button9" runat="server" OnClientClick="return page3()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="btnsave" runat="server" OnClientClick="return page5()" OnClick="Save_Click" Text="Save" Width="60px" CssClass="btn btn-success pull-right" />
                  <asp:Button ID="btnedit" runat="server" OnClientClick="return save()" Text="Edit" Width="60px" OnClick="Edit_Click" CssClass="btn btn-warning pull-right" Visible="false" />
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

        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1RCU.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC1.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1RCU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1Mo.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1De1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2PM1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2TLT1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2RS1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2DC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddlDTR1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2MRC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2ACU.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2RCU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2DC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2DC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3HPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3AC.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4HPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4AC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4HPA2.ClientID %>')); }, false);


        function validate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
            // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\.|\-/;
            if( !regex.test(key) ) {
            theEvent.returnValue = false;
            if(theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
</asp:Content>
