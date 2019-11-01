<%@ Page Title="Telkom 3S C-Band" Language="C#" MasterPageFile="~/CHECKLIST.Master" AutoEventWireup="true" CodeBehind="harkatt3sc.aspx.cs" Inherits="Telkomsat.checklist.harkatt3sc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box box-header" style="margin-bottom:0px">
        <asp:Label ID="Label17" runat="server" Text="Shelter Telkom 3S C-Band" Font-Size="Large" Font-Bold="true"></asp:Label>
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
                          <td class="tabel" rowspan="2"><b>Dehydrator</b><asp:Label ID="lbl1DP1" runat="server" Text="" ForeColor="Blue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1DP1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Presure</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1De1pr1" onkeypress='validate(event)' runat="server" Width="100%" ></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label33" runat="server" Text="mBar"></asp:Label></td>
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
                          <td class="tabel" rowspan="13"><b>HPA 1</b><asp:Label ID="lbl2HPA1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2HPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label57" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1rf" onkeypress='validate(event)' runat="server" Width="100%" ></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label58" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label21" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1bv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label22" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1hv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label23" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label24" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Inlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1it" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label25" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1bc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label30" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beacon</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1bea" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label32" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1becu" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label26" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Current </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1hecu" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label27" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1cate" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label28" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA1ot" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label29" runat="server" Text="*C"></asp:Label></td>
                      </tr>

                      <tr>
                          <td class="tabel" rowspan="1"><b>AC Power Unit HPA 1</b><asp:Label ID="lbl2ACHPA1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2ACHPA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label59" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="13"><b>HPA 2</b><asp:Label ID="lbl2HPA2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2HPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label31" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2rfo" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label6" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label8" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2bv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label15" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2hv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label19" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label20" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Inlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2it" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label61" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2boc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label62" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beacon</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2bea" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label63" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2bc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label64" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Current </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2hc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label65" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2ct" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label66" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt2HPA2ot" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label67" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>AC Power Unit HPA 2</b><asp:Label ID="lbl2ACHPA2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2ACHPA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label34" runat="server"></asp:Label></td>
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
                          <td class="tabel" rowspan="1"><b>Fiber Optik PSU</b><asp:Label ID="lbl3FOPSU1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3FOPSU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Fiber Optik Transmision</b><asp:Label ID="lbl3FOTr1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3FOTr1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label35" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>KVM</b><asp:Label ID="lbl3KVM1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3KVM1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label36" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl3UC1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3UC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label37" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3UC1fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label38" runat="server"  Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3UC1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl3UC2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3UC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label39" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3UC2fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label40" runat="server"  Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3UC2at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label41" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter</b><asp:Label ID="lbl3UC3" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3UC3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label42" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3UC3fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label43" runat="server"  Text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3UC3at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label44" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>RCU</b><asp:Label ID="lbl3RCU1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3RCUa" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label45" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>RCU</b><asp:Label ID="lbl3RCU2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3RCUb" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label46" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>KVM</b><asp:Label ID="lbl3KVM2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3KVM2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label47" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="13"><b>HPA</b><asp:Label ID="lbl3HPA1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3HPA3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label48" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Output</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3rfo" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label60" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label68" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3bv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label70" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Voltage</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3hv" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label71" runat="server" Text="V"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Reflected RF </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3rrf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label72" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Inlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3it" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label73" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3boc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label74" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beacon</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3bea" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label75" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Beam Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3bec" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label76" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Heater Current </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3hc" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label77" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Cabinet Temperature </td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3ct" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label78" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Outlet Temperature</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3HPA3ot" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label79" runat="server" Text="*C"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Power Supply</b><asp:Label ID="lbl3PS1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddlACHPA3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label49" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Ethernet</b><asp:Label ID="lbl3eth" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3eth1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label50" runat="server"></asp:Label></td>
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
                          <td class="tabel" rowspan="1"><b>Redundant Control Unit</b><asp:Label ID="lbl4rcu0" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4RCU0" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label9" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b><asp:Label ID="lbl4dc1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4DC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DC1rf" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label runat="server" text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DC1at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label10" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b><asp:Label ID="lbl4dc2" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4DC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label4" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DC2fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label runat="server" text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DC2at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label5" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter</b><asp:Label ID="lbl4dc3" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4DC3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label13" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DC3fr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label runat="server" text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DC3at" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label14" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="4"><b>Antenna Control Unit</b><asp:Label ID="lbl4acu" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4acu1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label80" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Azimut</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4acuaz" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label runat="server" text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Elevasi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4acuel" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label81" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Polarization</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4acupol" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label82" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Converter</b><asp:Label ID="lbl4con" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4con" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label18" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4CONfr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label runat="server" text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4CONat" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label83" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Tracking Receiver (MTR)</b><asp:Label ID="lbl4mtr" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4MTR" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label16" runat="server"></asp:Label></td>
                      </tr>
                     
                      
                      <tr>
                          <td class="tabel" rowspan="5"><b>Digital Tracking Receiver</b><asp:Label ID="lbl4dtr1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4DTR" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label53" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frekuensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DTRfr" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label runat="server" text="MHz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Rx Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DTRrx" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label54" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">C/No</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DTRCn" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label11" runat="server" Text="dB.Hz"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">DAC 1</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt4DTRDac" runat="server" Width="100%" onkeypress='validate(event)'></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label12" runat="server" Text="VDc"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>RCU</b><asp:Label ID="lbl4rcu1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4RCU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label55" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Patch Panel</b><asp:Label ID="lbl4pp" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4PP" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label56" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>GPS Receiver</b><asp:Label ID="lbl4gps" runat="server" Text="" ForeColor="DarkBlue"></asp:Label></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl4GPS" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label69" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>GPS 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl4GPS1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>GPS 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl4GPS2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>NTP</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl4NTP" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Time</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl4Time" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>UCT</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl4UCT" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                                            
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button9" runat="server" OnClientClick="return page3()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="btnsave" runat="server" OnClientClick="return save()"  Text="Save" Width="60px" OnClick="Save_Click" CssClass="btn btn-success pull-right" />
                  <asp:Button ID="btnedit" runat="server" OnClientClick="return save()"  Text="Edit" Width="60px" OnClick="Edit_Click" CssClass="btn btn-warning pull-right" Visible="false" />
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

        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1DP1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3eth1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2HPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2ACHPA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2HPA2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2ACHPA2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4RCU0.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3FOPSU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3FOTr1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3KVM1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3UC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3UC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3UC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3RCUa.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3RCUb.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3KVM2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3HPA3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddlACHPA3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddlACHPA3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4acu1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4RCU1.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4DC1.ClientID %>')); }, false);
          window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4DC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1DP1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4DC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4acu1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1DP1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4DTR.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1DP1.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4GPS.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4MTR.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4GPS1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4GPS2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4NTP.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4Time.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4UCT.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4con.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4RCU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl4PP.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1DP1.ClientID %>')); }, false);
         window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1DP1.ClientID %>')); }, false);

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
