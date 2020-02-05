<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="listpengeluaran.aspx.cs" Inherits="Telkomsat.admin.listpengeluaran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
<div class="row" style="padding:20px">
<div class="nav-tabs-custom col-lg-12">
    <!-- Tabs within a box -->
    <ul class="nav nav-tabs pull-right">
        <li class="pull-left header"><i class="fa fa-filter"></i> Filter</li>
    </ul>
    <div class="tab-content no-padding">
        <!-- Morris chart - Sales -->
        <div class="box-body">
        
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Start Date</label>
                        <input type="text" class="form-control pull-right" id="txtsdate" runat="server"/>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="exampleInputEmail1">End Date</label>
                        <input type="text" class="form-control pull-right" id="dateend" runat="server"/>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Status Aprroval</label>
                        <asp:DropDownList ID="ddlpengeluaran" CssClass="form-control" runat="server">
                            <asp:ListItem>--All--</asp:ListItem>
                            <asp:ListItem>Belum Approval</asp:ListItem>
                            <asp:ListItem>Approval</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Filter</label>
                        <br />
                        <button type="submit" class="btn btn-primary" runat="server" onserverclick="Filter_ServerClick" >Submit</button>
                    </div>
                </div>
        <!-- /.table -->
            </div>
        </div>
    </div>
</div>

<div class="col-lg-12 connectedSortable">
        <!-- Custom tabs (Charts with tabs)-->
    <div class="box box-primary">
    <!-- Tabs within a box -->
    <div class="box-header">
        <i class="fa fa-money"></i> Pemasukan
    </div>
    <div class="box-body">
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
</div>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script>
        $('#<%=txtsdate.ClientID%>').datepicker({
            autoclose: true,
            format: 'dd/mm/yyyy'
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=dateend.ClientID%>').datepicker('setStartDate', minDate);
        });
        $('#' + '<%=dateend.ClientID%>').datepicker({
            autoclose: true,
            format: 'dd/mm/yyyy'
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $('#<%=txtsdate.ClientID%>').datepicker('setEndDate', minDate);
        });

        function status(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
            //alert(userinput);
            if (statuslogbook == "'pengeluaran'") {
                document.getElementById('<%=ddlpengeluaran.ClientID%>').disabled = false;
                console.log("ksksk");
            }
            else {
                document.getElementById('<%=ddlpengeluaran.ClientID%>').disabled = true;
            }
        }

        window.addEventListener('load', function () { document.getElementById('<%=ddlpengeluaran.ClientID%>').disabled = true; }, true);
    </script>
    <script>
        $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
          "autoWidth": true,
          "scrollX": true,
          "order": [[ 1, 'desc' ]],
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });
    </script>
</asp:Content>
