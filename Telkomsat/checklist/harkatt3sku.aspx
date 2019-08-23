<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLIST.Master" AutoEventWireup="true" CodeBehind="harkatt3sku.aspx.cs" Inherits="Telkomsat.checklist.harkatt3sku" %>
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
                      <li class="select" style="width:30%">Page 1</li>
                      <li style="width:30%">Page 2</li>
                      <li style="width:30%">Page 3</li>
                  </ul>
                      </div>
<!-- /.Horizontal Steppers -->

              <table class="table table-bordered table-hover">
                  <tbody>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Up Converter 1</b></td>
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
                          <td class="tabel" rowspan="3"><b>Up Converter 2</b></td>
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
                          <td class="tabel" rowspan="7"><b>TWTA 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1TWTA1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label48" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Local</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA1lc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label30" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA1rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label49" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Refl RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA1rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label50" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Hlx</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA1hlx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label51" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power TX Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA1ptx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label52" runat="server" Text="dBW"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA1bc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label6" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td class="tabel" rowspan="7"><b>TWTA 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1TWTA2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label7" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Local</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA2lc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label31" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA2rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label19" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Refl RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA2rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label20" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Hlx</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA2hlx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label21" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power TX Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA2ptx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label22" runat="server" Text="dBW"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA2bc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label23" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="7"><b>TWTA 3</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1TWTA3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" Value="1">Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" Value="0">Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label24" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Local</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA3lc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label32" runat="server" Text="A"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">RF Out</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA3rf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label25" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Refl RF</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA3rrf" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label26" runat="server" Text="W"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Hlx</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA3hlx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label27" runat="server" Text="kV"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Power TX Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA3ptx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label28" runat="server" Text="dBW"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Body Current</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1TWTA3bc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label29" runat="server" Text="mA"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="2"><b>Dehydrator</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1De1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel">PR</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt1De1pr" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label33" runat="server" Text="h"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Power Meter</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1PM1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>PCB Panel</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl1PCB1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
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
                      <li class="active" style="width:30%">Page 1</li>
                      <li class="select" style="width:30%">Page 2</li>
                      <li style="width:30%">Page 3</li>
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
                          <td class="tabel" rowspan="1"><b>RCU 100a</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RCUa" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label57" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>RCU 100b</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RCUb" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label34" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>RCU 100c</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RCUc" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label35" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>RF Inhibit Distribution</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2RFI" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label36" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Laptop</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2Lap" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label37" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Fiber Optic PSU</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2FoPSU" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label38" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Fiber Optik Transmision</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2FoT" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label39" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Lantime M200</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2Lan" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label40" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>PCB Panel</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl2PCB" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label41" runat="server"></asp:Label></td>
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
                <li class="active" style="width:33%">Page 1</li>
                <li class="active" style="width:33%">Page 2</li>
                <li class="select" style="width:33%">Page 3</li>
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
                          <td class="tabel" rowspan="6"><b>Antena Controll Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3ACU1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Azimuth</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3ACU1az" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label13" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Elevation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3ACU1el" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label2" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Polarization</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3ACU1po" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label3" runat="server" Text="deg"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">AGC</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3ACU1agc" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label4" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Stack</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3ACU1st" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Redundant Sys. Control</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3RSC" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label14" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3DC1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label16" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frequensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3DC1fq" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label17" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3DC1at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label18" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3DC2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label42" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frequensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3DC2fq" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label43" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3DC2at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label44" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="3"><b>Down Converter 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3DC3" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label45" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Frequensi</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3DC3fq" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label58" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">Attenuation</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txt3DC3at" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label59" runat="server" Text="dB"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Cortex BBU</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3AC" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                              </td>
                          <td class="tabel"></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="5"><b>Digital Tracking Receiver</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3DTR1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
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
                          <td class="tabel">RX Level</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDTR1tx" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label64" runat="server" Text="dBm"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel">DAC 1</td>
                          <td class="tabel" style="max-width:150px;"><asp:TextBox ID="txtDTR1dac" runat="server" Width="100%"></asp:TextBox></td>
                          <td class="tabel"><asp:Label ID="Label65" runat="server" Text="VDC"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Test Panel</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3TP" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label60" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Remote Control Unit</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddlRCU" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label66" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Power Panel</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3PP" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label67" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>PCB Panel</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3PCB" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label68" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>GPS Receiver</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel" style="max-width:150px;">
                              <asp:DropDownList ID="ddl3GPS" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                          <td class="tabel"><asp:Label ID="Label69" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>GPS 1</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl3GPS1" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>GPS 2</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl3GPS2" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>NTP</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl3NTP" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>Time</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl3Time" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="tabel" rowspan="1"><b>UCT</b></td>
                          <td class="tabel"><b>Status</b></td>
                          <td class="tabel"><asp:DropDownList ID="ddl3UCT" runat="server" onchange="SetDropDownListColor(this);" Width="100%">
                                <asp:ListItem style="background-color: #38f345 !important; color:white" >Normal</asp:ListItem>
                                <asp:ListItem style="background-color: #ff3d3d !important; color:white" >Failure</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                  </tbody>
              </table>
            </div>
              <div class="box-footer clearfix no-border">
                  <asp:Button ID="Button7" runat="server" OnClientClick="return page2()" Text="Prev" Width="60px" CssClass="btn btn-primary pull-left" />
                  <asp:Button ID="Button8" runat="server" Text="Save" Width="60px" CssClass="btn btn-success pull-right" />
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

        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1UC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1TWTA1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1TWTA2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1TWTA3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1De1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1PM1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl1PCB1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2RCUa.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2RCUb.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2RCUc.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2RFI.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2Lap.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2FoPSU.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2FoT.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2Lan.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl2PCB.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3ACU1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3DC1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3DC2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3DC3.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3AC.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3DTR1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3TP.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddlRCU.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3PP.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3PCB.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3GPS.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3GPS1.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3GPS2.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3NTP.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3Time.ClientID %>')); }, false);
        window.addEventListener('load', function () { SetDropDownListColor(document.getElementById('<%= ddl3UCT.ClientID %>')); }, false);
    </script>

</asp:Content>
