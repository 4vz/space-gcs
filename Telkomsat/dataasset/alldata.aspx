<%@ Page Title="Data Asset" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="alldata.aspx.cs" Inherits="Telkomsat.dataasset.alldata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="row">
    <div class="col-md-12">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Data Asset</h3>
            <button type="button" id="btnexpand" class="showHideColumn btn btn-sm btn-primary pull-right">Expand</button> 
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table-responsive">
            <div class="table">
               <table id="datatable" style="min-width:100%" class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Equipment</th>
                            <th>Device</th>
                            <th>Merk</th>
                            <th>Tipe</th>
                            <th>Kategori</th>
                            <th>Model</th>
                            <th>Product Number</th>
                            <th>Serial Number</th>
                            <th>Wilayah</th>
                            <th>Gedung</th>
                            <th>Ruangan</th>
                            <th>Rak</th>
                            <th>Fungsi</th>
                            <th>Status Perangkat</th>
                            <th>Satelit</th>
                            <th>Tahun</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>Equipment</th>
                            <th>Device</th>
                            <th>Merk</th>
                            <th>Tipe</th>
                            <th>Kategori</th>
                            <th>Model</th>
                            <th>Product Number</th>
                            <th>Serial Number</th>
                            <th>Wilayah</th>
                            <th>Gedung</th>
                            <th>Ruangan</th>
                            <th>Rak</th>
                            <th>Fungsi</th>
                            <th>Status</th>
                            <th>Satelit</th>
                            <th>Tahun</th>
                            <th>Action</th>
                        </tr>
                    </tfoot>
                </table>
                </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
            <div class="box-footer">
                <asp:Button ID="Button2" runat="server" Text="Export to Excel" CssClass="btn btn-default pull-right" OnClick="ExportExcel" />
            </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
</div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var datatableInstance = $('#datatable').DataTable({
                columns: [
                    { 'data': 'equipment' },
                    { 'data': 'device' },
                    { 'data': 'merk' },
                    { 'data': 'tipe' },
                    { 'data': 'kategori' },
                    { 'data': 'model' },
                    { 'data': 'pn' },
                    { 'data': 'sn' },
                    { 'data': 'wilayah' },
                    { 'data': 'gudang' },
                    { 'data': 'ruangan' },
                    { 'data': 'rak' },
                    { 'data': 'fungsi' },
                    { 'data': 'status' },
                    { 'data': 'satelit' },
                    { 'data': 'tahun' },
                    { 'data': 'action' }
                ],
                "processing": false, //Feature control the processing indicator.
                bServerSide: true,
                autoWidth: true,
                "scrollX": true,
                sAjaxSource: 'EmployeeService.asmx/GetEmployees',
                sServerMethod: 'post'
            });
            datatableInstance.column('0').visible(!datatableInstance.column('0').visible());
            datatableInstance.column('3').visible(!datatableInstance.column('3').visible());
            datatableInstance.column('4').visible(!datatableInstance.column('4').visible());
            datatableInstance.column('5').visible(!datatableInstance.column('5').visible());
            datatableInstance.column('5').visible(!datatableInstance.column('6').visible());
            datatableInstance.column('8').visible(!datatableInstance.column('9').visible());
            datatableInstance.column('10').visible(!datatableInstance.column('11').visible());
            datatableInstance.column('12').visible(!datatableInstance.column('13').visible());
            datatableInstance.column('13').visible(!datatableInstance.column('14').visible());
            datatableInstance.column('14').visible(!datatableInstance.column('15').visible());

            var isExpand=false;
            $('.showHideColumn').on('click', function (e) {
                var this1 = $(this);
                if(isExpand)
                {
                  isExpand=false;
                  this1.text('Expand'); 
                }else{
                  isExpand=true;
                  this1.text('Reduce'); 
                }
                e.preventDefault();
                datatableInstance.column('0').visible(!datatableInstance.column('0').visible());
                datatableInstance.column('3').visible(!datatableInstance.column('3').visible());
                datatableInstance.column('4').visible(!datatableInstance.column('4').visible());
                datatableInstance.column('5').visible(!datatableInstance.column('5').visible());
                datatableInstance.column('5').visible(!datatableInstance.column('6').visible());
                datatableInstance.column('8').visible(!datatableInstance.column('9').visible());
                datatableInstance.column('10').visible(!datatableInstance.column('11').visible());
                datatableInstance.column('12').visible(!datatableInstance.column('13').visible());
                datatableInstance.column('13').visible(!datatableInstance.column('14').visible());
                datatableInstance.column('14').visible(!datatableInstance.column('15').visible());

            });
        });
    </script>
</asp:Content>
