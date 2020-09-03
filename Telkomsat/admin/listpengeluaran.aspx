<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="listpengeluaran.aspx.cs" Inherits="Telkomsat.admin.listpengeluaran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
<div class="row" style="padding:20px">

    <div class="row" style="height:auto">
        <div class="col-md-12">
            <a href="pengeluaran.aspx" class="btn btn-primary btn-sm pull-right" runat="server" id="btntmbh" visible="false">Tambah</a>
          <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs pull-right">
                      <li id="lipengeluaran" runat="server"><a href="#pengeluaran" data-toggle="tab">Pengeluaran</a></li>
                      <li id="lidraft" runat="server"><a href="#draft" data-toggle="tab">Draft</a></li>
                        
                      <li class="pull-left header"><i class="fa fa-inbox"></i> Approvement</li>
                    </ul>
              
                <div class="tab-content no-padding">
                    <div id="pengeluaran" class="tab-pane fade">
                        <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                        <asp:Label ID="lblpeng" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                    <div id="draft" class="tab-pane fade">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>  
                        <asp:Label ID="lblgm" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                    </div>
                </div>
               
            </div>
            </div>


</div>

    <div class="modal fade" id="modalupdate">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Tambah File</h4>
              </div>
              <div class="modal-body">
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">File :</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Edit_File">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>

    <asp:TextBox ID="txtidl" CssClass="hidden" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtliactive" CssClass="hidden" runat="server"></asp:TextBox>
    <script>
        
        function status(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
        }

    </script>
    <script>
        $(function () {
            $("#example2").DataTable({
                "autoWidth": true,
                "ordering": false,
                "lengthChange": true,
                "searching": true
            });

            $("#example3").DataTable({
                "autoWidth": true,
                "ordering": false,
                "lengthChange": true,
                "searching": true
            });

            $('.dataTables_length').addClass('bs-select');
        });

        $('.datatotal').click(function () {
            var id = $(this).val();
            $('#<%=txtidl.ClientID %>').val(id);
        });

        var modal = document.getElementById("myModal");
        var img = document.getElementsByClassName("myImg");
        var modalImg = document.getElementById("img01");
        var i;
        for (i = 0; i < img.length; i++) {
            img[i].onclick = function () {
                modal.style.display = "block";
                modalImg.src = this.src;
                captionText.innerHTML = this.alt;
            }
        }

        $(document).ready(function () {
            if ($('#<%=txtliactive.ClientID %>').val() == 'pengeluaran') {
                $('#pengeluaran').addClass('in active');
                console.log('iuiui');

            }
            else if ($('#<%=txtliactive.ClientID %>').val() == 'draft') {
                $('#draft').addClass('in active');
                console.log('iuiui');
            }
        });

        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }
    </script>
</asp:Content>
