<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTME.Master" AutoEventWireup="true" CodeBehind="harian.aspx.cs" Inherits="Telkomsat.checklistme.harian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" Visible="false">
        <asp:ListItem>pagi</asp:ListItem>
        <asp:ListItem>siang</asp:ListItem>
        <asp:ListItem>malam</asp:ListItem>
    </asp:DropDownList>
<div class="col-md-12 no-padding">
        <div class="box box-primary">
        <div class="box-header with-border">
            <asp:Label ID="lblroom" runat="server" Text="Checklist ME" Font-Size="Large" Font-Bold="true"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Copy From The Last" OnClick="inisialisasi_Click" CssClass="btn btn-sm btn-primary pull-right"  />
            <asp:Label ID="lblsave" runat="server" Text=" Berhasil disimpan" ForeColor="YellowGreen" Visible="false"></asp:Label>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:Label ID="lbledit" runat="server" Visible="false" Text="Label"></asp:Label>               
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
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <!-- /.col -->
    <script src="//cdn.rawgit.com/ashl1/datatables-rowsgroup/v1.0.0/dataTables.rowsGroup.js"></script>
    <script type="text/javascript">
       $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
          "rowsGroup": [0, 1],
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
