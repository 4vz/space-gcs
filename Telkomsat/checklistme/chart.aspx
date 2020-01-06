<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTME.Master" AutoEventWireup="true" CodeBehind="chart.aspx.cs" Inherits="Telkomsat.checklistme.chart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script src="//cdn.jsdelivr.net/excanvas/r3/excanvas.js" type="text/javascript"></script>
<script src="//cdn.jsdelivr.net/chart.js/0.2/Chart.js" type="text/javascript"></script>

<script type="text/javascript">
$(function () {
    LoadChart();
    $("[id*=ddlCountries]").bind("change", function () {
        LoadChart();
    });
    $("[id*=rblChartType] input").bind("click", function () {
        LoadChart();
    });
});
function LoadChart() {
    var chartType = parseInt($("[id*=rblChartType] input:checked").val());
    $.ajax({
        type: "POST",
        url: "chart.aspx/GetChart",
        data: "{country: '" + $("[id*=ddlCountries]").val() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            $("#dvChart").html("");
            $("#dvLegend").html("");
            var data = eval(r.d);
            var el = document.createElement('canvas');
            $("#dvChart")[0].appendChild(el);
 
            //Fix for IE 8
            if ($.browser.msie && $.browser.version == "8.0") {
                G_vmlCanvasManager.initElement(el);
            }
            var ctx = el.getContext('2d');
            var userStrengthsChart;
            switch (chartType) {
                case 1:
                    userStrengthsChart = new Chart(ctx).Pie(data);
                    break;
                case 2:
                    userStrengthsChart = new Chart(ctx).Doughnut(data);
                    break;
            }
            for (var i = 0; i < data.length; i++) {
                var div = $("<div />");
                div.css("margin-bottom", "10px");
                div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);
                $("#dvLegend").append(div);
            }
        },
        failure: function (response) {
            alert('There was an error.');
        }
    });
}
</script>

<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            Country:
            <asp:DropDownList ID="ddlCountries" runat="server">
                <asp:ListItem Text="USA" Value="USA" />
                <asp:ListItem Text="Germany" Value="Germany" />
                <asp:ListItem Text="France" Value="France" />
                <asp:ListItem Text="Brazil" Value="Brazil" />
            </asp:DropDownList>
         
            <asp:RadioButtonList ID="rblChartType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Pie" Value="1" Selected="True" />
                <asp:ListItem Text="Doughnut" Value="2" />
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <div id="dvChart">
            </div>
        </td>
        <td>
            <div id="dvLegend">
            </div>
        </td>
    </tr>
</table>

</asp:Content>
