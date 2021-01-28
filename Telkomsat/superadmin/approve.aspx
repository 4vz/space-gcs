<%@ Page Title="Approval Checklist" Language="C#" MasterPageFile="~/APPROVAL.Master" AutoEventWireup="true" CodeBehind="approve.aspx.cs" Inherits="Telkomsat.superadmin.approve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content">
        <div class="row">
            <section class="col-lg-9 connectedSortable">
                <div class="box box-danger" style="min-height:90%">
                    <div class="box-header">
                        Data
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-sm btn-success pull-right" OnClientClick="if (!confirmselesai()) return false" Text="Approve All" />
                    </div>
                    <div class="box-body">
                        <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
                </div>
            </section>
        </div>
    </div>

    <asp:Button ID="btnapprove" runat="server" Text="Button" CssClass="hidden" OnClick="Approveall_Click" />
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script>
        $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
          "autoWidth": true,
          "scrollX": true,
          "order": [[ 0, 'desc' ]],
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });

        function confirmselesai(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data tidak bisa diubah lagi',
                buttons: true,
                icon: "info",

            }).then((willDelete)=>{
                if (willDelete) {
                    document.getElementById('<%= btnapprove.ClientID %>').click();
                }
            });
        }
    </script>
</asp:Content>
