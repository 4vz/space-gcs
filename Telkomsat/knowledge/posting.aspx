<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="posting.aspx.cs" Inherits="Telkomsat.knowledge.posting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link href="../assets/css/style.min.css" rel="stylesheet" />
    <link href="../Style2.css" rel="stylesheet" />
    <link href="../Style1.css" rel="stylesheet" />
    <link href="../StyleLogBook.css" rel="stylesheet" />
    <link href="../stylepagination.css" rel="stylesheet" />
    <link href="../logbook/log.css" rel="stylesheet" type="text/css"/>
    <link href="knowledge.css" rel="stylesheet" />
    <style>
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
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <hr width="100%" align="center" style="margin-top:20px; margin-bottom:0px;" class="hrline">  
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard2.aspx">
          <img src="../img/logotelkomsat2.png" alt="Alternate Text" height="50"/></a>
          <input type="text" name="q" class="form-control" placeholder="Search..." runat="server" id="inputsearch" style="vertical-align:middle"/>
          <span class="input-group-btn">
                <button type="submit" name="search" class="btn btn-flat" runat="server" onserverclick="btnSearch_Click"><i class="fa fa-search"></i>
                </button>
              </span>  
    </div>
    </div>
    <br />
        
    <div class="bodyLB5">
        <br />

        <ul class="list-inline">
            <li>
                <asp:Button ID="Button1" runat="server" Text="Posting" CssClass="btn btn-adn" Width="80px" OnClick="btnPosting_Click"/>
            </li>
            <li style="margin-right:300px;">
                <asp:Button ID="Button2" runat="server" Text="File" CssClass="btn btn-sm" Width="80px" OnClick="btnFile_Click"/>
            </li>
            <li style="margin-right:400px;">
                <button type="submit" class="btn-file" runat="server" onserverclick="btnTambah_Click"><i class="fa fa-plus" style="font-size:12px"></i> Tambah
                </button>
            </li>
        </ul>
        <br />

    <asp:HiddenField ID="hfContactID" runat="server" />
    <div class="bodyLB">
      <asp:HiddenField ID="HiddenField1" runat="server" />
        <button class="btn btn-danger pull-right" runat="server" style="margin-right:10px" onserverclick="Delete_ServerClick">Delete</button>
        <button class="btn btn-info pull-right" runat="server" style="margin-right:10px" onserverclick="Edit_ServerClick">Edit</button>

         

      <asp:DataList runat="server" id="dtContact" Width="650px" >
        <ItemTemplate>
            <asp:Label Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB1" />
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") %>' />
            <br />
            <br />
            <asp:Label ID="AKTIVITASLabel" runat="server" style="white-space: pre-line;" class="aktivitasLB1" Text='<%# Eval("POSTING") %>' />
            <br />
        </ItemTemplate>

    </asp:DataList>
        <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
        <br />
        <br />
    </div>
    </div>
        <div class="modal modal1" id="myModal">
          <span class="close close1">&times;</span>
            <img class="modal-content modal-content1" id="img01" src=""/>
          <div id="caption"></div>
    </div>
    <script>
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
        
                    // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];

            // When the user clicks on <span> (x), close the modal
            span.onclick = function() { 
              modal.style.display = "none";
            }
        </script>
    </form>
</body>
</html>
