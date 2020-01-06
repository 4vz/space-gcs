<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="serverside.aspx.cs" Inherits="Telkomsat.dataasset.serverside" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../assets/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"/>

    <link href="./assets/css/style.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="./assets/bower_components/select2/dist/css/select2.min.css" />
    <link href="Style2.css" rel="stylesheet" />
    <link href="Style1.css?version=5" rel="stylesheet" />
    <link href="stylepagination.css" rel="stylesheet" />
    <link href="logbook/log.css" rel="stylesheet" type="text/css"/>
    <script src="~/assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 900px">
            <table id="datatable" class="table table-bordered table-hover table-striped">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Device</th>
                        <th>Merk</th>
                        <th>Wilayah</th>
                        <th>S/N</th>
                        <th>Fungsi</th>
                        <th>Ruangan</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <th>Id</th>
                        <th>Device</th>
                        <th>Merk</th>
                        <th>Wilayah</th>
                        <th>S/N</th>
                        <th>Fungsi</th>
                        <th>Ruangan</th>
                    </tr>
                </tfoot>
            </table>
        </div>
        <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datatable').DataTable({
                columns: [
                    { 'data': 'idperangkat' },
                    { 'data': 'device' },
                    { 'data': 'merk' },
                    { 'data': 'wilayah' },
                    { 'data': 'sn' },
                    { 'data': 'fungsi' },
                    { 'data': 'ruangan' }
                ],
                "processing": true, //Feature control the processing indicator.
    	        "serverSide": true, 
                bServerSide: true,
                sAjaxSource: 'EmployeeService.asmx/GetEmployees',
                sServerMethod: 'post'
            });
        });
    </script>
    </form>
</body>
</html>
