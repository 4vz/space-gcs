<%@ Page Title="Maintenance Baseband" Language="C#" MasterPageFile="~/MAINTENANCEHK.Master" AutoEventWireup="true" CodeBehind="databbu.aspx.cs" Inherits="Telkomsat.maintenancehk.tigabulan.databbu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-lg-12 connectedSortable">
     <div class="box box-primary">
        <div class="box-header">
            <asp:Label ID="lblroom" runat="server" Text="Maintenance Semester Harkat" Font-Size="Large" Font-Bold="true"></asp:Label>
        </div>
        <div class="box-body">
            <div class="table">
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div> 
</div>
    <script src="../../assets/mylibrary/rowsgroup.js"></script>
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
              { "orderable": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });
    </script>
</asp:Content>
