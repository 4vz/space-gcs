﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTHK.Master" AutoEventWireup="true" CodeBehind="editharianit.aspx.cs" Inherits="Telkomsat.checkhk.editharianit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 no-padding">
        <div class="box box-primary">
        <div class="box-header with-border">
            <asp:Label ID="lblroom" runat="server" Text="Checklist Harkat" Font-Size="Large" Font-Bold="true"></asp:Label>
         
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:Label ID="lbledit" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">lihat</asp:LinkButton>
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer">
            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-primary btn pull-right" Width="100px" OnClick="Button1_Click" />
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    </div>
    
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <!-- /.col -->
    <script src="../assets/mylibrary/rowsgroup.js"></script>
    <script type="text/javascript">
       $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
          "rowsGroup": [0, 1, 2],
            "pageLength": 200,
              "ordering": false,
              "lengthChange": false,
            "searching": false
          });
           $('.dataTables_length').addClass('bs-select');
        });


        $(document).ready(function () {
            $('#checkBoxAll').click(function () {
                if ($(this).is(":checked"))
                    $('.chkCheckBoxId').prop('checked', true);
                else
                    $('.chkCheckBoxId').prop('checked', false);
            });
        });


        function fungsi() {
            alert("Berhasil Disimpan");
        }

      

       
    </script>
</asp:Content>
