<%@ Page Title="Checklist Harian ME" Language="C#" MasterPageFile="~/CHECKLISTME.Master" AutoEventWireup="true" CodeBehind="harian.aspx.cs" Inherits="Telkomsat.checklistme.harian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .box .border-right{
            border-right: 3px solid #e2e2e2;
        }
        .uli {
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
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    <br />
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
            //setTimeout(function () { alert("Berhasil Disimpan"); }, 3000)
            alert("Berhasil Disimpan");
            location.href = "harian.aspx";
        };

      

       
    </script>
</asp:Content>
