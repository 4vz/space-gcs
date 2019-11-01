<%@ Page Title="MPSat" Language="C#" MasterPageFile="~/CHECKLIST.Master" AutoEventWireup="true" CodeBehind="harkatmpsat.aspx.cs" Inherits="Telkomsat.checklist.harkatmpsat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box box-header" style="margin-bottom:0px">
        <asp:Label ID="Label17" runat="server" Text="Shelter MPSat" Font-Size="Large" Font-Bold="true"></asp:Label>
        <asp:Label ID="lblstatus" runat="server" Font-Size="Large" Font-Bold="true" Visible="false"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Copy From The Last" OnClick="inisialisasi_Click" CssClass="btn btn-sm btn-primary pull-right"  />
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
                      <li class="select" style="width:30%">Rack 1</li>
                      <li style="width:30%">Rack 2</li>
                      <li style="width:30%">Rack 3</li>
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
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl1RCU1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1RCU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl1RCU2" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1RCU2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label96" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Spectrum Analyzer</b><asp:Label ID="lbl1SA1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1sa1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label97" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="13"><b>HPA 1</b><asp:Label ID="lbl1hpa1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1hpa1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label52" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1rf" onkeypress='validate(event)' runat="server" Width="100%" ></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label84" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label85" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1bv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label86" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1hv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label87" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label88" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Inlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1it" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label89" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1boc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label90" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beacon</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1bea" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label91" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1beC" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label92" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Current </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1hc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label93" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1ct" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label94" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa1ot" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label95" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Power Supply</b><asp:Label ID="lbl1ps1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1ps1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label51" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="11"><b>HPA 2</b><asp:Label ID="lbl1hpa2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1hpa2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label99" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2rf" onkeypress='validate(event)' runat="server" Width="100%" ></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label100" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Setpoint</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2rfs" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label102" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label101" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel">Hotspot Temp</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2ht" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label103" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label106" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Id </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2id" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label104" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Vd</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2vd" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label105" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel">PS Temp </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2pst" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label109" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2ct" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label110" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Inlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa2it" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label111" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="11"><b>HPA 3</b><asp:Label ID="lbl1hpa3" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1hpa3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label108" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3rfo" onkeypress='validate(event)' runat="server" Width="100%" ></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label112" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Setpoint</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3rfs" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label113" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label114" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel">Hotspot Temp</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3ht" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label115" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label116" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Id </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3id" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label117" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Vd</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3vd" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label118" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel">PS Temp </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3pst" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label119" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3ct" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label120" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Inlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1hpa3it" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label121" runat="server" Text="*C"></asp:Label></td>
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
                      <li class="active" style="width:30%">Rack 1</li>
                      <li class="select" style="width:30%">Rack 2</li>
                      <li style="width:30%">Rack 3</li>
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
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl2RCU1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2rcu1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label98" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl2rcu2" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2rcu2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label122" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Receiver</b><asp:Label ID="lbl2rec1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2rec1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label124" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b><asp:Label ID="lbl2dc1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2dC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label125" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2dC1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label126" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Gain</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2dC1ga" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label127" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b><asp:Label ID="lbl2dc2" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2dc" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label129" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2dc2fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label130" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Gain</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2dc2ga" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label131" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b><asp:Label ID="lbl2dc3" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2dc3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label133" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2dc3fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label134" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Gain</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2dc3ga" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label135" runat="server" Text="dB"></asp:Label></td>
                      </tr>

                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl2rcu3" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2rcu3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label137" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>KVM</b><asp:Label ID="lbl2kvm1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2kvm1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label139" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl2uc1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2uc1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label141" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2uc1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label142" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Gain</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2uc1ga" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label143" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl2uc2" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2uc2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label145" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2uc2fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label146" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Gain</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2uc2ga" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label147" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl2uc3" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2uc3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label149" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2uc3fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label150" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Gain</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2UC3ga" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label151" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Fiber Optik</b><asp:Label ID="lbl2HPA1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2fo1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label57" runat="server"></asp:Label></td>
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
                <li class="active" style="width:33%">Rack 1</li>
                <li class="active" style="width:33%">Rack 2</li>
                <li class="select" style="width:33%">Rack 3</li>
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
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl3RCu1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3rcu1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl3rcu2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3rcu2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label35" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="6"><b>Antenna Control Unit</b><asp:Label ID="lbl3acu1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3acu1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label8" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Azimut</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3acu1az" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label runat="server" text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Elevasi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3acu1el" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label15" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Polarization</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3acu1po" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label19" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Signal</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3acu1si" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3acu1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label20" runat="server" Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Manual Control Unit</b><asp:Label ID="lbl3MCU1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3MCU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label5" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>Digital Tracking Receiver</b><asp:Label ID="lbl3dtr1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3dtr1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label37" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3dtr1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label38" runat="server"  Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Input Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3dtr1il" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Bandwidth</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3dtr1bw" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label21" runat="server" Text="kHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3dtr1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label23" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Server Unit</b><asp:Label ID="lbl3su1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3su1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label45" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Server Unit</b><asp:Label ID="lbl3su2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3su2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label46" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Dehydrator</b><asp:Label ID="lbl3de1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3de1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label47" runat="server"></asp:Label></td>
                      </tr>
                       <tr>
                          <td class="tabel">Pressure</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3de1pr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label27" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Dehydrator</b><asp:Label ID="lbl3de2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3de2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label25" runat="server"></asp:Label></td>
                      </tr>
                       <tr>
                          <td class="tabel">Pressure</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3de2pr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label26" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button7" runat="server" OnClientClick="return page2()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
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
          return false;
        }
        function page4(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'none';
          return false;
        }
        function page3(){
          // put your code here 
          document.getElementById("bayA4").style.display = 'none';
          document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'block';
          return false;
        }
        function page1(){
          // put your code here 
            document.getElementById("bayA4").style.display = 'block';
            document.getElementById("bayA2").style.display = 'none';
            document.getElementById("bayA3").style.display = 'none';
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

        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1hpa1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1hpa2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1hpa3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1ps1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1RCU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1RCU2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1sa1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2dc.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2dC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2dc3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2fo1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2kvm1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2rcu1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2rcu2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2rcu3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2rec1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2uc1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2uc2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2uc3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3acu1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3de1.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3de2.ClientID %>')); }, false);
          window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3dtr1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3rcu1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3rcu2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3su1.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3su2.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3MCU1.ClientID %>')); }, false);
         

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
