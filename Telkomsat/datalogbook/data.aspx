<%@ Page Title="Logbook" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="data.aspx.cs" Inherits="Telkomsat.datalogbook.data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box box-default">
        <div class="box-header">
            <h4 style="font-weight:bold">Data Logbook</h4>
        </div>
        <div class="box-body">
            <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
        </div>
        <div class="box-footer">

        </div>
     </div>

    <script>
       $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "ordering": false,
          "info": true,
          "autoWidth": true,
          "scrollX": true
          });
           $('.dataTables_length').addClass('bs-select');
       });
</script>
</asp:Content>
