<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTME.Master" AutoEventWireup="true" CodeBehind="checklist.aspx.cs" Inherits="Telkomsat.checklistme.checklist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <canvas id="myChart"></canvas>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>

    <script>
        var ctx = document.getElementById("myChart");
var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: []
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true,
                    callback: function(value, index, values) {
                        if (parseInt(value) >= 1000) {
                            return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                        } else {
                            return value;
                        }
                    }
                }
            }]
        }
    }
});

var model = {
	2015: [20, 12, 32, 8, 25, 14, 20, 12, 32, 8, 25, 14],
	2016: [17, 26, 21, 41, 8, 23, 17, 26, 21, 41, 8, 23],
	2017: [23, 15, 8, 24, 38, 20, 23, 15, 8, 24, 38, 20],
};

for (year in model) {
	var newDataset = {
    	label: year,
        data: []
    };
    
    for (value in model[year]) {
    	newDataset.data.push(model[year][value]);
    }
    
    myChart.config.data.datasets.push(newDataset);
}

    myChart.update();
    </script>
</asp:Content>
