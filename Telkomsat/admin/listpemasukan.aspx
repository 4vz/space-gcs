<%@ Page Title="Pemasukan" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="listpemasukan.aspx.cs" Inherits="Telkomsat.admin.listpemasukan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .myImg {
          border-radius: 5px;
          cursor: pointer;
          transition: 0.3s;
        }

        .rows{
            padding:7px;
        }

        .myImg:hover {opacity: 0.7;}

        /* The Modal (background) */
        .modal1 {
          display: none; /* Hidden by default */
          position: fixed; /* Stay in place */
          z-index: 1; /* Sit on top */
          padding-top: 100px; /* Location of the box */
          left: 0;
          top: 0;
          width: 100%; /* Full width */
          height: 100%; /* Full height */
          overflow: auto; /* Enable scroll if needed */
          background-color: rgb(0,0,0); /* Fallback color */
          background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modal-content1 {
          margin: auto;
          display: block;
          width: 80%;
          max-width: 700px;
        }

        
        /* Add Animation */
        .modal-content1, #caption {  
          -webkit-animation-name: zoom;
          -webkit-animation-duration: 0.6s;
          animation-name: zoom;
          animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
          from {-webkit-transform:scale(0)} 
          to {-webkit-transform:scale(1)}
        }

        @keyframes zoom {
          from {transform:scale(0)} 
          to {transform:scale(1)}
        }

        /* The Close Button */
        .close1 {
            position: absolute;
            top: 65px;
            right: 45px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .close1:hover,
            .close1:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        /* 100% Image Width on Smaller Screens */
        @media only screen and (max-width: 700px) {
            .modal-content1 {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal modal1" id="myModal">
          <span class="close close1">&times;</span>
            <img class="modal-content modal-content1" id="img01" src=""/>
          <div id="caption"></div>
    </div>
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <i class="fa fa-money"></i> Pemasukan
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <a href="pemasukan.aspx" class="btn btn-primary btn-sm pull-right">Tambah</a>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </section>
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
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script>
        $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
              "ordering": false,
              "lengthChange": true,
            "searching": true
          });
           $('.dataTables_length').addClass('bs-select');
        });

        function confirmhapus(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data yang dihapus tidak akan kembali lagi',
                buttons: true,
                dangerMode: true,

            }).then((willDelete)=>{
                if (willDelete) {
                    document.location = deleteurl;
                }
            });
        }

        $('.datatotal').click(function () {
            var id = $(this).val();
            $('#<%=txtidl.ClientID %>').val(id);
        });

        var modal = document.getElementById("myModal");
        var img = document.getElementsByClassName("myImg");
        var modalImg = document.getElementById("img01");
        var i;
        for (i = 0; i < img.length; i++) {
            img[i].onclick = function(){
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
            }
        }

        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function() { 
          modal.style.display = "none";
        }
    </script>
</asp:Content>
