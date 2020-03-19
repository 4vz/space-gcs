<%@ Page Title="Filter Logbook" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="filter.aspx.cs" Inherits="Telkomsat.datalogbook.filter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <div class="row">
    <div class="col-md-12">
        <div class="box box-default">
        <div class="box-header with-border">
            <asp:Label ID="lblHeading" Font-Bold="true" runat="server" Text="Label"></asp:Label>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:Label ID="lblkosong" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" Value="bisa" />
    <asp:TextBox ID="txtid" runat="server" CssClass="hidden"></asp:TextBox>
    <!-- /.col -->
    <script type="text/javascript">

        $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
          "ordering": false,
          "autoWidth": true,
          "scrollX": true
          });
            $('.dataTables_length').addClass('bs-select');
             
    </script>  
</asp:Content>
