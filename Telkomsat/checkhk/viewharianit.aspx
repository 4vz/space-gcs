<%@ Page Title="Lihat Data Checklist IT" Language="C#" MasterPageFile="~/CHECKLISTHK.Master" AutoEventWireup="true" CodeBehind="viewharianit.aspx.cs" Inherits="Telkomsat.checkhk.viewharianit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 connectedSortable">
        <!-- Custom tabs (Charts with tabs)-->
            <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header">
                <i class="fa fa-database"></i> Checklist 
       
            <asp:Label ID="lbltanggal" runat="server" Text="" Visible="false" CssClass="pull-right"></asp:Label>
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
            </div>
        </div>
    </div>
    

    <script src="../assets/mylibrary/rowsgroup.js"></script>
    <script>
        $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
          "autoWidth": true,
          "scrollX": true,
          "pageLength": 100,
          "rowsGroup": [0, 1, 2],
          "ordering": false,
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "className": "bg-warning", "targets": [4] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });
    </script>
</asp:Content>
