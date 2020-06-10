<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTHK.Master" AutoEventWireup="true" CodeBehind="editharian.aspx.cs" Inherits="Telkomsat.checkbjm.editharian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row" id="divddl" runat="server">
        <!-- Left col -->
        <section class="col-lg-6 connectedSortable" style="min-height:50px">
            <div class="col-lg-4 col-xs-12" style="padding-left:0; padding-bottom:15px; padding-right:15px">
            <asp:DropDownList ID="ddlruang" runat="server" CssClass="form-control" Width="100%">
                <asp:ListItem>-Pilih Ruangan-</asp:ListItem>
                <asp:ListItem>BASEBAND ROOM</asp:ListItem>
                <asp:ListItem>WORKSTATION ROOM</asp:ListItem>
                <asp:ListItem>RF ROOM</asp:ListItem>
            </asp:DropDownList>
                </div>
             <div class="col-lg-4 col-xs-12" style="padding-bottom:15px; ">
            <asp:Button ID="Button3" runat="server" Text="Pilih" CssClass="btn btn-success btn-sm" OnClick="Pilih_Click" Width="100%"/>
            </div>
        </section>
        </div>
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
