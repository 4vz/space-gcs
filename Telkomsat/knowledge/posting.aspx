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
    <script src="./assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <hr width="100%" align="center" style="margin-top:20px; margin-bottom:0px;" class="hrline">  
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard.aspx">
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

      <asp:DataList runat="server" id="dtContact" Width="650px" >
        <ItemTemplate>
            <asp:Label Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB1" />
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") %>' />
            <br />
            <asp:Label ID="AKTIVITASLabel" runat="server" class="aktivitasLB1" Text='<%# Eval("POSTING") %>' />
            <br />
            <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR1")) %>'/>
            <asp:Image ID="Image2" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR2")) %>'/>
            <asp:Image ID="Image3" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR3")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR3")) %>'/>
            <asp:Image ID="Image4" runat="server" Height="300px" ImageUrl='<%# Eval("GAMBAR4")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("GAMBAR4")) %>'/>
            <br />
        </ItemTemplate>

    </asp:DataList>
    </div>
    </div>
    </form>
</body>
</html>
