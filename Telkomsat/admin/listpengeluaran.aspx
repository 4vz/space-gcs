<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="listpengeluaran.aspx.cs" Inherits="Telkomsat.admin.listpengeluaran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
<div class="row" style="padding:20px">

<div class="col-lg-12 connectedSortable">
        <!-- Custom tabs (Charts with tabs)-->
    <div class="box box-primary">
    <!-- Tabs within a box -->
    <div class="box-header">
        <i class="fa fa-money"></i> Pengeluaran
        <a href="pemasukan.aspx" class="btn btn-primary btn-sm pull-right">Tambah</a>
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

    <div class="modal fade" id="modalupdate">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Tambah File</h4>
              </div>
              <div class="modal-body">
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">File :</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Edit_File">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>

    <asp:TextBox ID="txtidl" runat="server"></asp:TextBox>
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
        
        function status(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
        }

    </script>
    <script>
        $(function () {
            $("#example2").DataTable({
                "autoWidth": true,
                "scrollX": true,
                "ordering": false,
                "lengthChange": true,
                "searching": true
            });
            $('.dataTables_length').addClass('bs-select');
        });

        $('.datatotal').click(function () {
            var id = $(this).val();
            $('#<%=txtidl.ClientID %>').val(id);
        });

        var modal = document.getElementById("myModal");
        var img = document.getElementsByClassName("myImg");
        var modalImg = document.getElementById("img01");
        var i;
        for (i = 0; i < img.length; i++) {
            img[i].onclick = function () {
                modal.style.display = "block";
                modalImg.src = this.src;
                captionText.innerHTML = this.alt;
            }
        }

        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }
    </script>
</asp:Content>
