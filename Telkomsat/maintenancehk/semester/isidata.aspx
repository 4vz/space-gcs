<%@ Page Title="" Language="C#" MasterPageFile="~/MAINTENANCEHK.Master" AutoEventWireup="true" CodeBehind="isidata.aspx.cs" Inherits="Telkomsat.maintenancehk.semester.isidata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-md-12 no-padding">
        <div class="box box-primary">
        <div class="box-header with-border">
            <asp:Label ID="lblroom" runat="server" Text="Maintenance Semester Harkat" Font-Size="Large" Font-Bold="true"></asp:Label>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table table-responsive">
                <asp:Label ID="lbledit" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">edit</asp:LinkButton>
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer no-padding">
            <div class="mailbox-controls">
            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-primary btn pull-right" Width="100px" OnClick="Button1_Click" />
            <!-- /.pull-right -->
            </div>
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <!-- /.col -->
    <script src="../../assets/mylibrary/rowsgroup.js"></script>
    <script type="text/javascript">
        function SetDropDownListColor(ddl) {
            for (var i = 0; i < ddl.options.length; i++) {
                if (ddl.options[i].selected) {
                    switch (i) {
                        case 0:
                            ddl.style.backgroundColor = 'White';
                            ddl.style.color = 'Black';
                            return;
                        case 1:
                            ddl.style.backgroundColor = '#27d714';
                            ddl.style.color = 'White';
                            return;
                    }
                }
            }
            console.log("tetr");
        }
    function DisableButton() {
        document.getElementById("<%=Button1.ClientID %>").disabled = true;
    }
    window.onbeforeunload = DisableButton;
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

        $('.tgldata').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        });

       
    </script>
</asp:Content>
