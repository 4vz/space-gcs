<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Telkomsat.admin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .keterangan::first-letter{
            text-transform:uppercase;
        }
    </style>
    <input type="hidden" id="mylabel" runat="server"/>
    <div class="row">
        <div class="col-lg-4 col-xs-12">
            <!-- small box -->
            <div class="small-box bg-aqua">
            <div class="inner">
                <asp:Label Font-Size="22px" ID="dashtotal" runat="server" Text="0"></asp:Label>
                <p>Total</p>
            </div>
            <div class="icon">
                <i class="ion ion-stats-bars"></i>
            </div>
            <a class="small-box-footer">Total Keuangan <i class="fa fa-money"></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-green">
            <div class="inner">
                <asp:Label Font-Size="22px" ID="dashharkat" runat="server" Text="0"></asp:Label>

                <p>Harkat</p>
            </div>
            <div class="icon">
                <i class="ion ion-cash"></i>
            </div>
            <a href="#" data-toggle="modal" data-target="#modal-success" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-yellow">
            <div class="inner">
                <asp:Label Font-Size="22px" ID="dashme" runat="server" Text="0"></asp:Label>

                <p>Mechanical Electrical</p>
            </div>
            <div class="icon">
                <i class="ion ion-cash"></i>
            </div>
            <a href="#" data-toggle="modal" data-target="#modal-warning" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <!-- ./col -->
        </div>
    <div class="row">
<!-- Left col -->
        <section class="col-lg-12 connectedSortable">
            <div class="col-lg-7">
            <!-- Custom tabs (Charts with tabs)-->
                <div class="nav-tabs-custom">
                <!-- Tabs within a box -->
                <ul class="nav nav-tabs pull-right">
                    <li class="active"><a href="#revenue-chart" data-toggle="tab">tabel</a></li>
                    <li class="pull-left header"><i class="fa fa-money"></i> Total</li>
                </ul>
                <div class="tab-content no-padding">
                    <!-- Morris chart - Sales -->
                    <div class="table-responsive mailbox-messages">
                        <div class="table table-responsive">
                            <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                        </div>
                <!-- /.table -->
                    </div>
                </div>
                <div class="box-footer no-border" style="padding:3px;">
                        <div class="row">
                        <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                            <label style="padding-right:10px">Pemasukan </label>
                            <span class="label label-info">  </span>
                        </div>
                            <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                            <label style="padding-right:10px">Pemindahan </label>
                            <span class="label label-success">  </span>
                        </div>
                        <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                            <label style="padding-right:10px">Pengeluaran </label>
                            <span class="label label-warning">  </span>
                        </div>
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </div>
            <div class="col-lg-5">

                    <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Saldo</h3>

                        <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                        </button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                        <div class="col-md-8">
                            <div class="chart-responsive">
                                    <canvas id="pieChart" height="150"></canvas>
                                  </div>
                            <!-- ./chart-responsive -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-4">
                            <ul class="chart-legend clearfix">
                            <li><i class="fa fa-circle-o text-red"></i> Rek. Harkat 1</li>
                            <li><i class="fa fa-circle-o text-green"></i> Rek. Harkat 2</li>
                            <li><i class="fa fa-circle-o text-yellow"></i> Rek. ME 1</li>
                            <li><i class="fa fa-circle-o text-aqua"></i> Rek. ME 2</li>
                            <li><i class="fa fa-circle-o text-light-blue"></i> Brankas Harkat</li>
                            <li><i class="fa fa-circle-o text-gray"></i> Brankas ME</li>
                            </ul>
                        </div>
                        <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer no-padding">
                        <ul class="nav nav-pills nav-stacked">
                        <li><a href="#">Harkat
                            <span class="pull-right text-red"> 62%</span></a></li>
                        <li><a href="#">ME <span class="pull-right text-green"> 38%</span></a>
                        </li>
                    </div>
                    <!-- /.footer -->
                    </div>
                    <!-- /.box -->

                </div>

        </section>
</div>
    <div class="row">
        <div class="col-lg-12">
            <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
                <ul class="nav nav-tabs pull-right">
                    <li class="active"><a href="#revenue-chart" data-toggle="tab">tabel</a></li>
                    <li class="pull-left header"><i class="fa fa-money"></i> Pertanggungan Dana</li>
                </ul>
                <div class="tab-content no-padding" style="min-height:300px;">
                    <!-- Morris chart - Sales -->
                    <div class="table-responsive mailbox-messages">
                        <div class="table table-responsive">
                            <asp:PlaceHolder ID="PlaceHolderpanjar" runat="server"></asp:PlaceHolder>  
                        </div>
                <!-- /.table -->
                    </div>
                </div>
                <div class="box-footer no-border" style="padding:3px;">

                        <!-- /.row -->
                    </div>
                </div>

        </div>

    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
                <ul class="nav nav-tabs pull-right">
                    <li class="active"><a href="#revenue-chart" data-toggle="tab">tabel</a></li>
                    <li class="pull-left header"><i class="fa fa-money"></i> Justifikasi </li>
                </ul>
                <div class="tab-content no-padding" style="min-height:300px;">
                    <!-- Morris chart - Sales -->
                    <div class="table-responsive mailbox-messages">
                        <div class="table table-responsive">
                            <asp:PlaceHolder ID="PlaceHolderJust" runat="server"></asp:PlaceHolder>  
                        </div>
                <!-- /.table -->
                    </div>
                </div>
                <div class="box-footer no-border" style="padding:3px;">

                        <!-- /.row -->
                    </div>
                </div>

        </div>

    </div>

        <div class="modal modal-warning fade" id="modal-warning">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Mechanical Electrical</h4>
              </div>
              <div class="modal-body">
                <table id="demo1" class="table">
					<tbody>
						<tr>
							<td style="width:200px;">Rekening ME 1</td>
							<td style="width:20px"> : </td>
							<td>
                                <asp:Label ID="lblrekme1" runat="server" Text="Label"></asp:Label>
							</td>
						</tr>
						<tr>
							<td> Rekening ME 2</td>
							<td> : </td>
							<td><asp:Label ID="lblrekme2" runat="server" Text="Label"></asp:Label></td>
						</tr>
						<tr>
							<td>Brankas ME</td>
							<td> : </td>
							<td><asp:Label ID="lblbrame" runat="server" Text="Label"></asp:Label></td>
						</tr>
					</tbody>
				</table>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Close</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

        <div class="modal modal-success fade" id="modal-success">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Harkat</h4>
              </div>
              <div class="modal-body">
                <table id="demo" class="table">
					<tbody>
						<tr>
							<td style="width:200px;">Rekening Harkat 1</td>
							<td style="width:20px"> : </td>
							<td>
                                <asp:Label ID="lblrekharkat1" runat="server" Text="Label"></asp:Label>
							</td>
						</tr>
						<tr>
							<td> Rekening Harkat 2</td>
							<td> : </td>
							<td><asp:Label ID="lblrekharkat2" runat="server" Text="Label"></asp:Label></td>
						</tr>
						<tr>
							<td>Brankas Harkat</td>
							<td> : </td>
							<td><asp:Label ID="lblbraharkat" runat="server" Text="Label"></asp:Label></td>
						</tr>
					</tbody>
				</table>
                
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Close</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>


    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/bower_components/chart.js/Chart.js"></script>
    <script>
        $(function () { 

            var test = $('#' + '<%= mylabel.ClientID %>').val().replace(/\./g, "");
            var test3 = test.split(',');
            console.log(test3);


            var pieChartCanvas = $('#pieChart').get(0).getContext('2d');
  var pieChart       = new Chart(pieChartCanvas);
  var PieData        = [
      {
          value: test3[0],
      color    : '#f56954',
      highlight: '#f56954',
          label: 'Rek. Harkat 1',
    },
    {
      value    : test3[1],
      color    : '#00a65a',
      highlight: '#00a65a',
      label    : 'Rek. Harkat 2'
    },
    {
      value    : test3[2],
      color    : '#f39c12',
      highlight: '#f39c12',
      label    : 'Rek. ME 1'
    },
    {
      value    : test3[3],
      color    : '#00c0ef',
      highlight: '#00c0ef',
      label    : 'Rek ME 2'
    },
    {
      value    : test3[4],
      color    : '#3c8dbc',
      highlight: '#3c8dbc',
      label    : 'Brankas Harkat'
    },
    {
      value    : test3[5],
      color    : '#d2d6de',
      highlight: '#d2d6de',
      label    : 'Brankas ME'
    }
  ];
  var pieOptions     = {
    // Boolean - Whether we should show a stroke on each segment
    segmentShowStroke    : true,
    // String - The colour of each segment stroke
    segmentStrokeColor   : '#fff',
    // Number - The width of each segment stroke
    segmentStrokeWidth   : 1,
    // Number - The percentage of the chart that we cut out of the middle
    percentageInnerCutout: 50, // This is 0 for Pie charts
    // Number - Amount of animation steps
    animationSteps       : 100,
    // String - Animation easing effect
    animationEasing      : 'easeOutBounce',
    // Boolean - Whether we animate the rotation of the Doughnut
    animateRotate        : true,
    // Boolean - Whether we animate scaling the Doughnut from the centre
    animateScale         : false,
    // Boolean - whether to make the chart responsive to window resizing
    responsive           : true,
    // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
    maintainAspectRatio  : false,
  };
  // Create pie or douhnut chart
  // You can switch between pie and douhnut using the method below.
  pieChart.Doughnut(PieData, pieOptions);
        })
    </script>
    

</asp:Content>
