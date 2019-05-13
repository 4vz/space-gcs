﻿function GetTeamUsersByTeamID(obj) {
    var selectbox = obj;
    var userinput = selectbox.options[selectbox.selectedIndex].value;
    //alert(userinput);
    if (userinput == "CBI" || userinput == "BJR") {
        document.getElementById('gudang').style.visibility = 'visible';
        document.getElementById('rak').style.visibility = 'visible';
    }
    else {
        document.getElementById('gudang').style.visibility = 'hidden';
        document.getElementById('rak').style.visibility = 'hidden';
    }
}

function btnsubmit() {
    var inp;
    var mylink = "http://home.aspx?tahun=" + inp;
    window.location.href = mylink;
}

$(document).ready(function () {
    $.ajax({
        url: "http://asset/chart.aspx",
        method: "GET",
        success: function (data) {
            console.log(data);
            var player = [];
            var score = [];

            for (var i in data) {
                player.push("Player " + data[i].NAMA);
                score.push(data[i].TOTAL);
            }   

            var chartdata = {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
                datasets: [
                    {
                        label: 'Player Score',
                        backgroundColor: 'rgba(200, 200, 200, 0.75)',
                        borderColor: 'rgba(200, 200, 200, 0.75)',
                        hoverBackgroundColor: 'rgba(200, 200, 200, 1)',
                        hoverBorderColor: 'rgba(200, 200, 200, 1)',
                        data: [65, 59, 80, 81, 56, 55, 40]
                    }
                ]
            };

            var ctx = $("#mycanvas");

            var barGraph = new Chart(ctx, {
                type: 'bar',
                data: chartdata
            });
        },
        error: function (data) {
            console.log(data);
        }
    });
});

$(function () {


    var areaChartData = {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
        datasets: [
            {
                label: 'Electronics',
                fillColor: 'rgba(210, 214, 222, 1)',
                strokeColor: 'rgba(210, 214, 222, 1)',
                pointColor: 'rgba(210, 214, 222, 1)',
                pointStrokeColor: '#c1c7d1',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(220,220,220,1)',
                data: [65, 59, 80, 81, 56, 55, 40]
            },
            {
                label: 'Digital Goods',
                fillColor: 'rgba(60,141,188,0.9)',
                strokeColor: 'rgba(60,141,188,0.8)',
                pointColor: '#3b8bba',
                pointStrokeColor: 'rgba(60,141,188,1)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(60,141,188,1)',
                data: [28, 48, 40, 19, 86, 27, 90]
            }
        ]
    }

var barChartCanvas = $('#barChart').get(0).getContext('2d')
var barChart = new Chart(barChartCanvas)
var barChartData = areaChartData
barChartData.datasets[1].fillColor = '#00a65a'
barChartData.datasets[1].strokeColor = '#00a65a'
barChartData.datasets[1].pointColor = '#00a65a'
var barChartOptions = {
    //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
    scaleBeginAtZero: true,
    //Boolean - Whether grid lines are shown across the chart
    scaleShowGridLines: true,
    //String - Colour of the grid lines
    scaleGridLineColor: 'rgba(0,0,0,.05)',
    //Number - Width of the grid lines
    scaleGridLineWidth: 1,
    //Boolean - Whether to show horizontal lines (except X axis)
    scaleShowHorizontalLines: true,
    //Boolean - Whether to show vertical lines (except Y axis)
    scaleShowVerticalLines: true,
    //Boolean - If there is a stroke on each bar
    barShowStroke: true,
    //Number - Pixel width of the bar stroke
    barStrokeWidth: 2,
    //Number - Spacing between each of the X value sets
    barValueSpacing: 5,
    //Number - Spacing between data sets within X values
    barDatasetSpacing: 1,
    //String - A legend template
    legendTemplate: '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].fillColor%>"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>',
    //Boolean - whether to make the chart responsive
    responsive: true,
    maintainAspectRatio: true
}

barChartOptions.datasetFill = false
barChart.Bar(barChartData, barChartOptions)
  })

