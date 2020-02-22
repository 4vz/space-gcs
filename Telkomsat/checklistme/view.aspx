<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTME.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Telkomsat.checklistme.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .box .border-right{
            border-right: 3px solid #e2e2e2;
        }
        ul {
          padding: 5px;
        }

        .myli {
          float: left;
          border: 1px solid #e2e2e2;
          display: block;
          color: black;
          text-align: center;
          padding: 16px;
          text-decoration: none;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
    </div>
    <br />

    <div class="row">
        <div class="col-lg-12 connectedSortable">
                <!-- Custom tabs (Charts with tabs)-->
            <div class="box box-primary">
            <!-- Tabs within a box -->
            <div class="box-header">
                <i class="fa fa-database"></i> Checklist Harian
            </div>
            <div class="box-body">
                <!-- Morris chart - Sales -->
                <div class="table-responsive mailbox-messages">
                    <div class="table table-responsive">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.table -->
                </div>
            </div>
            </div>
        </div>

    </div>
    <script src="../assets/mylibrary/rowsgroup.js"></script>
    <script type="text/javascript">
       $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
          "rowsGroup": [0, 1, 2],
          "pageLength": 100,
          "ordering": false
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
