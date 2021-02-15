<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTHK.Master" AutoEventWireup="true" CodeBehind="harianit.aspx.cs" Inherits="Telkomsat.checkhk.harianit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div class="box box-primary" runat="server" id="divdata" visible="false">
        <div class="box-header">
            Checklist Harkat Cibinong
        </div>
        <div class="box-body">
            <div class="col-md-12 col-xs-12">
                <table class="table">
                    <tr>
                    <th>Tanggal</th>
                    <th>Petugas</th>
                    <th>Approval</th>
                    </tr>
                    <tr style="background-color:white">
                    <td><asp:Label ID="lbltanggal" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblpetugas" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblapproval" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
            </div>
            
        </div>
    </div>
    <div class="col-lg-12">
        <div class="box box-primary">
            <div class="box-header">
                Checklist IT Cibinong
            </div>
            <div class="box-body">
                <div class="row">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div> 
    </div>
        <div class="col-md-12 no-padding">
        <div class="box box-primary">
        <div class="box-header with-border">
            <asp:Label ID="lblroom" runat="server" Text="Checklist Harkat" Font-Size="Large" Font-Bold="true"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Copy From The Last" OnClick="inisialisasi_Click" CssClass="btn btn-sm btn-primary pull-right"  />
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:Label ID="lbledit" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">edit</asp:LinkButton>
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.table -->
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

</div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <!-- /.col -->
    <script src="../assets/mylibrary/rowsgroup.js"></script>
    <script type="text/javascript">
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

      

       
    </script>
</asp:Content>
