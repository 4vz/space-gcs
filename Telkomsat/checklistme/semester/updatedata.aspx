<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKMEWEEK.Master" AutoEventWireup="true" CodeBehind="updatedata.aspx.cs" Inherits="Telkomsat.checklistme.semester.updatedata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
        <!-- Left col -->
        <section class="col-lg-6 connectedSortable" style="min-height:50px">
            <div class="col-lg-4 col-xs-6" style="padding-left:0; padding-bottom:15px; padding-right:15px">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="100%">
                <asp:ListItem>-Pilih Ruangan-</asp:ListItem>
                <asp:ListItem>RO-GST</asp:ListItem>
                <asp:ListItem>RO-UPS</asp:ListItem>
            </asp:DropDownList>
                </div>
             <div class="col-lg-4 col-xs-12" style="padding-bottom:15px; ">
            <asp:Button ID="Button1" runat="server" Text="Pilih" CssClass="btn btn-success btn-sm" OnClick="Pilih_Click" Width="100%"/>
            </div>
        </section>
    </div>

<div class="col-md-12">
        <div class="box box-primary">
        <div class="box-header with-border">
            <asp:Label ID="lblroom" runat="server" Text="Maintenance Semester" Font-Size="Large" Font-Bold="true"></asp:Label>

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
        <div class="box-footer no-padding">
            <div class="mailbox-controls">
            <asp:Button ID="Button3" runat="server" Text="Save" CssClass="btn-primary btn pull-right" Width="100px" OnClick="Button1_Click" />
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
          "ordering": false,
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });

        function fungsi() {
            alert("Berhasil Disimpan");
        }
      
    </script>
</asp:Content>
