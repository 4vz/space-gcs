<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tambahpost.aspx.cs" Inherits="Telkomsat.knowledge.tambahpost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tambah Postingan</title>
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
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

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

    <asp:HiddenField ID="hfContactID" runat="server" />
        <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:Label ID="lblWaktu" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        
    <h3><span style="left:20%">Input Posting</span></h3>
        <asp:Label ID="lblUpdate" runat="server" Text=""></asp:Label>
        <br />
    <div class="divtabel" style="margin-left:80px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Nama</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label9" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtNama" class="tb1" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label2" runat="server" class="lbl">Judul</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="2">
                    <asp:TextBox ID="txtJudul" class="tb1" runat="server" Width="470px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label5" runat="server" class="lbl">Kategori</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label6" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:DropDownList ID="ddlkategori" runat="server" CssClass="tb1" Width="160px">
                        <asp:ListItem>RF</asp:ListItem>
                        <asp:ListItem>Komputer</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                        <asp:ListItem>Lain-lain</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label3" runat="server" class="lbl">Posting</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label4" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext" colspan="2">
                    <asp:TextBox ID="txtAktivitas" class="tb1" runat="server" TextMode="MultiLine" Height="500px" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label7" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label8" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; padding-right:10px;" class="tdtext">
                    <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                </td>
                <td style="padding-bottom:10px; white-space:nowrap; width:400px;" class="tdtext" >
                    <button id="show" type="button" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> 
                </td>
            </tr>
           
            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-default" Width="110px"/>
                </td>
            </tr>
        </table>
        
        
        </div>
        </div>
    </div>
    
</form>
</body>
</html>
