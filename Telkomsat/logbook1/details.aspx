<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="Telkomsat.logbook1.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="log.css?version=9" rel="stylesheet"/>
    <style>
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
        padding-top:50px;
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
  position: relative;
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
    
    <div id="divBackground" class="modal">
</div>
    <div id="divImage" class = "info">
    <img id="imgLoader" alt=""
                 src="images/loader.gif" />
        <span class="close" onclick="HideDiv()">&times;</span>
  <img class="modal-content" id="imgFull" src="" runat="server">
        
  <div id="caption"></div>
    
</div>
    <div style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
            <asp:Label ID="lblWaktu" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        
    <h3><span style="left:20%">Input Logbook</span></h3>
        <asp:Label ID="lblUpdate" runat="server" Text=""></asp:Label>
        <br />
    <div class="divtabel" style="margin-left:80px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Tanggal </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext" colspan="7">
                    <asp:Label ID="txtTanggal" class="tb1" runat="server" Width="115px"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label27" class="lbl" runat="server">Kategori  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label28" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="lblKategori" class="tb1" runat="server" Width="120px"></asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:30px; padding-left:82px" id="tdlabel" runat="server">
                    <asp:Label ID="Label11" class="lbl" runat="server">SN Asset  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua" id="tdlabel1" runat="server">
                    <asp:Label ID="Label12" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" id="tdlabel2" runat="server">
                    <asp:Label ID="lblSN" class="tb1" runat="server" Width="170px"></asp:Label>
                </td>

                <td class="tdtext" style="padding-bottom:10px; padding-right:30px; padding-left:82px" id="td1" runat="server">
                    <asp:Label ID="Label15" class="lbl" runat="server">SN Baru  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua" id="td2" runat="server">
                    <asp:Label ID="Label16" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" id="td3" runat="server">
                    <asp:Label ID="lblSN1" class="tb1" runat="server" Width="170px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Event  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label9" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="7">
                    <asp:Label ID="txtEvent" class="tb1" runat="server" Width="570px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label25" class="lbl" runat="server">Unit  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label26" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" >
                    <asp:Label ID="ddlUnit" class="tb1" runat="server" Width="170px"></asp:Label>
                </td>

                <td class="tdtext" style="padding-bottom:10px; padding-right:30px; padding-left:82px" id="td4" runat="server">
                    <asp:Label ID="Label19" class="lbl" runat="server">Estimasi </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua" id="td5" runat="server">
                    <asp:Label ID="Label20" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="7" id="td6" runat="server">
                    <asp:Label ID="lblEstimasi" class="tb1" runat="server" Width="170px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label8" class="lbl" runat="server">Status  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="7">
                    <asp:Label ID="ddlStatus" class="tb1" runat="server" Width="570px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label2" class="lbl" runat="server">PIC OS  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label5" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:Label ID="txtOS" class="tb1" runat="server" Width="180px"></asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:30px; padding-left:82px;">
                    <asp:Label ID="Label6" class="lbl" runat="server">PIC OG  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label7" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:Label ID="txtOG" class="tb1" runat="server" Width="180px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label3" runat="server" class="lbl">Kegiatan  </asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label4" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext" colspan="7">
                    <asp:Label ID="txtInfo" class="tb1" runat="server" TextMode="MultiLine" Width="570px"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1" colspan="7">
                    <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-default" Width="110px" onclick="btnEdit_Click"/>
                </td>
            </tr>
        </table>
        <br />
        <asp:DataList runat="server" id="dtContact" Width="1135px" RepeatColumns="3" GridLines="Both" RepeatDirection="Horizontal" >
        <ItemTemplate>
            <asp:ImageButton ID="myImg" Style="cursor: pointer" runat="server" OnClientClick = "return LoadDiv(this.src);" Width="250px" ImageUrl='<%# Eval("Image1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image1")) %>'/>
            <asp:ImageButton ID="Image2" Style="cursor: pointer" runat="server" OnClientClick = "return LoadDiv(this.src);" Width="250px" ImageUrl='<%# Eval("Image2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image2")) %>'/>
            <asp:ImageButton ID="Image3" Style="cursor: pointer" runat="server" OnClientClick = "return LoadDiv(this.src);" Width="250px" ImageUrl='<%# Eval("Image3")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image3")) %>'/>
            <asp:ImageButton ID="Image4" Style="cursor: pointer" runat="server" OnClientClick = "return LoadDiv(this.src);" Width="250px" ImageUrl='<%# Eval("Image4")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image4")) %>'/>
            <br />
        </ItemTemplate>

    </asp:DataList>
        <br />
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
    <asp:GridView ID="gvFile" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
            BorderColor="White" BorderStyle="None" BorderWidth="0px" Visible="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" Text='<%# Eval("NameFile") %>' CommandArgument='<%# Eval("ID_File") %>' OnClick="linkDownloadFile_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
        <RowStyle BackColor="White" ForeColor="#1b1b1b" />
        </asp:GridView>
        <br />
       </div>     
        
      </div>
    
    

</asp:Content>
