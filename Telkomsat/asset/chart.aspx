<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="chart.aspx.cs" Inherits="Telkomsat.asset.chart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="chart.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
        <div class="col-md-6">
        <asp:DropDownList ID="ddlKelompok" runat="server" onChange="myNewFunction(this);">
            <asp:ListItem>Kelompok</asp:ListItem>
            <asp:ListItem>RF EQUIPMENT</asp:ListItem>
            <asp:ListItem>BASEBAND</asp:ListItem>
            <asp:ListItem>SERVER & NE</asp:ListItem>
            <asp:ListItem>ANTENA</asp:ListItem>
            <asp:ListItem>ALAT UKUR</asp:ListItem>
            <asp:ListItem>WORKSTATION</asp:ListItem>
            <asp:ListItem>LICENSE</asp:ListItem>
            <asp:ListItem Value="MECHANINCAL ELECTRICAL">ME</asp:ListItem>
        </asp:DropDownList>
            <br />
          <!-- AREA CHART -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Bar Chart</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <div class="box-body">
                <asp:Literal ID="ltChart" runat="server"></asp:Literal> 
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->

          <!-- DONUT CHART -->
        <asp:DropDownList ID="ddlRF" runat="server" onChange="myNewFunction1(this);">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>UPCONVERTER</asp:ListItem>
            <asp:ListItem>DOWNCONVERTER</asp:ListItem>
            <asp:ListItem>RF MATRIX</asp:ListItem>
            <asp:ListItem>IF MATRIX</asp:ListItem>
            <asp:ListItem>HPA</asp:ListItem>
            <asp:ListItem>LNA</asp:ListItem>
            <asp:ListItem>RCU HPA</asp:ListItem>
            <asp:ListItem>LNA RSC</asp:ListItem>
            <asp:ListItem>RCU UPCONVERTER</asp:ListItem>
            <asp:ListItem>RCU DOWNCONVERTER</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlBaseband" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>GPS ANTENA</asp:ListItem>
            <asp:ListItem>GPS TIME SERVER</asp:ListItem>
            <asp:ListItem>BASEBAND</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlServer" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
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
            <asp:ListItem>ADAM UNIT</asp:ListItem>
            <asp:ListItem>NETWORK SERIAL ADAPTER</asp:ListItem>
            <asp:ListItem>WEB I/O RELAY</asp:ListItem>
            <asp:ListItem>SAECAMS SERVER</asp:ListItem>
            <asp:ListItem>SAT ID SERVER</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlAntena" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>Dehydrator</asp:ListItem>
            <asp:ListItem>Antena</asp:ListItem>
            <asp:ListItem>RF TO OPTIC CONVERTER</asp:ListItem>
            <asp:ListItem>ACU</asp:ListItem>
            <asp:ListItem>MOTOR</asp:ListItem>
            <asp:ListItem>REMOTE CONTROL UNIT</asp:ListItem>
            <asp:ListItem>DIGITAL TRACKING</asp:ListItem>
            <asp:ListItem>MONOPULSE TR</asp:ListItem>
            <asp:ListItem>DUAL CHANNEL DC</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlAlat" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>COMMUNICATION</asp:ListItem>
            <asp:ListItem>SPECTRUM ANALYZER</asp:ListItem>
            <asp:ListItem>SYNTHESIZER SWEEPER</asp:ListItem>
            <asp:ListItem>POWER METER</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlWorkstation" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>OPERASIONAL</asp:ListItem>
            <asp:ListItem>ENGINEERING</asp:ListItem>
            <asp:ListItem>FLIGHT DYNAMIC</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlLicense" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>EPOCH CLIENT LICENSES</asp:ListItem>
            <asp:ListItem>EPOCH SERVER LICENSES</asp:ListItem>
            <asp:ListItem>ARES LICENSES</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlME" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>UPS</asp:ListItem>
            <asp:ListItem>TRAFO</asp:ListItem>
            <asp:ListItem>GENSET</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnDDL" runat="server" Text="Button" OnClick="btnDDL_Click" class="urut"/>
          <div class="box box-danger">
            <div class="box-header with-border">
              <h3 class="box-title">Pie Chart</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <div class="box-body">
              <asp:Literal ID="ltChartKel" runat="server"></asp:Literal> 
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        </div>

    <script src="../ChartJS.js" type="text/javascript"></script>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/Chart.js"></script>
    <script src="../assets/bower_components/Chart.min.js"></script>
    <script type="text/javascript">
        function myNewFunction1(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput != "") {
                document.getElementById('<%=btnDDL.ClientID%>').click();
            }
        }
        function myNewFunction(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput != "") {
                document.getElementById('<%=btnDDL.ClientID%>').click();
            }
        }
    </script>
</asp:Content>
