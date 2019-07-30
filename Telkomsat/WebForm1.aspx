<%@ Page Title="" Language="C#" MasterPageFile="~/KNOWLEDGE.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Telkomsat.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Bootstrap Part 14 : Membuat Carousel dengan Bootstrap</title>
	<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/bootstrap.js"></script>	
    <style type="text/css">
     body 
     {
        margin:0;
        padding:0;
        height:100%; 
        overflow-y:auto;  
     }
     .modal {
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
.modal-content {
  margin: auto;
  display: block;
  width: 80%;
  max-width: 700px;
}
     #divImage
     {
        display: none;
        z-index: 1000;
        position: fixed;
        top: 0;
        left: 0;
        background-color:transparent;
        height: auto;
        width: auto;
        padding: 3px;
     }
  
     .modal-content, #caption {  
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
.close {
  position: absolute;
  top: 15px;
  right: 35px;
  color: #f1f1f1;
  font-size: 40px;
  font-weight: bold;
  transition: 0.3s;
}

.close:hover,
.close:focus {
  color: #bbb;
  text-decoration: none;
  cursor: pointer;
}

/* 100% Image Width on Smaller Screens */
@media only screen and (max-width: 700px){
  .modal-content {
    width: 100%;
  }
}
</style>
    <script type="text/javascript">
        function LoadDiv(url) {
        var img = new Image();
        var bcgDiv = document.getElementById("divBackground");
        var imgDiv = document.getElementById("divImage");
        var imgFull = document.getElementById("<%= imgFull.ClientID %>");
        //var imgLoader = document.getElementById("imgLoader");

        //imgLoader.style.display = "block";
        img.onload = function () {
        imgFull.src = img.src;
        imgFull.style.display = "block";
        //imgLoader.style.display = "none";
        };
        img.src = url;
        var width = document.body.clientWidth;
        if (document.body.clientHeight > document.body.scrollHeight) {
        bcgDiv.style.height = document.body.clientHeight + "px";
        }
        else {
        bcgDiv.style.height = document.body.scrollHeight + "px";
        }

        imgDiv.style.left = (width - 650) / 2 + "px";
        imgDiv.style.top = "20px";
        bcgDiv.style.width = "100%";

        bcgDiv.style.display = "block";
        imgDiv.style.display = "block";
        return false;
        }
        function HideDiv() {
        var bcgDiv = document.getElementById("divBackground");
        var imgDiv = document.getElementById("divImage");
        var imgFull = document.getElementById("<%= imgFull.ClientID %>");
        if (bcgDiv != null) {
        bcgDiv.style.display = "none";
        imgDiv.style.display = "none";
        imgFull.style.display = "none";
        }
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    
        
<div id="divBackground" class="modal">
</div>
<div id="divImage" class = "info">
    <img id="imgLoader" alt=""
                 src="images/loader.gif" />
    <span class="close" onclick="HideDiv()">&times;</span>
  <img class="modal-content" id="imgFull" src="" runat="server">
  <div id="caption"></div>
    
</div>
    <div>
            <br />
            
             <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/img/3.jpg" Width="100px"
            Height="100px" Style="cursor: pointer" 
            OnClientClick = "return LoadDiv(this.src);"
            />
              <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/img/ba.jpg" Width="100px"
            Height="100px" Style="cursor: pointer" 
            OnClientClick = "return LoadDiv(this.src);"
            />

        </div>
    <asp:DataList runat="server" id="dtContact" Width="1135px" RepeatColumns="3" GridLines="Both" RepeatDirection="Horizontal" >
        <ItemTemplate>
            <asp:ImageButton ID="myImg" Style="cursor: pointer" runat="server" OnClientClick = "return LoadDiv(this.src);" Width="250px" ImageUrl='<%# Eval("Image1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image1")) %>'/>
            <asp:Image ID="Image2" runat="server" Width="250px" ImageUrl='<%# Eval("Image2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image2")) %>'/>
            <asp:Image ID="Image3" runat="server" Width="250px" ImageUrl='<%# Eval("Image3")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image3")) %>'/>
            <asp:Image ID="Image4" runat="server" Width="250px" ImageUrl='<%# Eval("Image4")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image4")) %>'/>
            <br />
        </ItemTemplate>

    </asp:DataList>


</form>
</asp:Content>
