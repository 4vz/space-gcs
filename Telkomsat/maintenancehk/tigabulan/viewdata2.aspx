<%@ Page Title="Data Triwulan" Language="C#" MasterPageFile="~/MAINTENANCEHK.Master" AutoEventWireup="true" CodeBehind="viewdata2.aspx.cs" Inherits="Telkomsat.maintenancehk.tigabulan.viewdata2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tooltips {
          border-bottom: 1px dotted red;
          cursor:pointer;
        }

        .tooltips .tooltiptexts {
          visibility: hidden;
          width: 120px;
          background-color: black;
          color: #fff;
          text-align: center;
          border-radius: 6px;
          padding: 5px 0;

          /* Position the tooltip */
          position: absolute;
          z-index: 1;
        }

        .tooltips:hover .tooltiptexts {
          visibility: visible;
        }
        .ui-autocomplete { z-index:2147483647; }
        .gambar {
          float: left;
          padding:10px;
        }
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
<div class="col-lg-12 connectedSortable">
     <div class="box box-primary">
        <div class="box-header">
            <asp:Label ID="lblroom" runat="server" Text="Maintenance Semester Harkat" Font-Size="Large" Font-Bold="true"></asp:Label>
        </div>
        <div class="box-body">
            <div class="table">
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div> 
</div>

    <div class="modal modal1" id="myModal">
          <span class="close close1">&times;</span>
            <img class="modal-content modal-content1" id="img01" src=""/>
          <div id="caption"></div>
    </div>
    <script src="../../assets/mylibrary/rowsgroup.js"></script>
    <script>
        $(function () {
          $("#example2").DataTable({
              "paging": true,
              "searching": true,
              "info": true,
              "autoWidth": true,
              "scrollX": true,
              "ordering": false,
              "lengthChange": false,
              "searching": false,
              "pageLength": 200

          });
           $('.dataTables_length').addClass('bs-select');
        });

        var modal = document.getElementById("myModal");
        var img = document.getElementsByClassName("myImg");
        var modalImg = document.getElementById("img01");
        var i;
        console.log(img.length);
        for (i = 0; i < img.length; i++) {
            img[i].onclick = function () {
                modal.style.display = "block";
                modalImg.src = this.src;
                captionText.innerHTML = this.alt;
                console.log(this.src);
            }
        }

        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }
    </script>
</asp:Content>
