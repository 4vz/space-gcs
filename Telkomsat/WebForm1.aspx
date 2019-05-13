<%@ Page Title="" Language="C#" MasterPageFile="~/KNOWLEDGE.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Telkomsat.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard.aspx">
          <img src="../img/logotelkomsat2.png" alt="Alternate Text" height="50"/></a>
          <input type="text" name="q" class="form-control" placeholder="Search..." runat="server" id="Text1" style="vertical-align:middle"/>
          <span class="input-group-btn">
                <button type="submit" name="search" class="btn btn-flat" runat="server" onserverclick="btnSearch_Click"><i class="fa fa-search"></i>
                </button>
              </span>  
    </div>
    </div>
    </header>
    <div class="content-wrapper">
    <section class="content">
    
    <br />
        
    <div class="bodyLB2">

        <ul class="list-inline">
            <li style="margin-right:400px;">
                <asp:Button ID="Button1" runat="server" Text="Semua" CssClass="btn btn-adn" Width="80px"/>
            </li>
            <li>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl28" Width="120px">
                    <asp:ListItem>-Kategori-</asp:ListItem>
                    <asp:ListItem>Upload</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </li>
            <li style="margin-right:10px;">
                <button type="submit" class="btn-file" runat="server" onserverclick="btnTambah_Click"><i class="fa fa-plus" style="font-size:12px"></i> Tambah
                </button>
            </li>
        </ul>
        <br />

    <asp:HiddenField ID="hfContactID" runat="server" />
    
    <asp:DataList runat="server" Width="568px" OnItemCommand="DataList1_ItemCommand" ID="DataList1">
        <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("JUDUL") %>' runat="server" class="judulLB" CommandArgument='<%# Eval("ID") %>' CommandName="id"/>
            <br />
            <asp:Label ID="NAMALabel" runat="server" class="namaLB" Text='<%# Eval("NAMA") %>'/>
            <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# " - " + Eval("KATEGORI") %>' />
            <br />
            <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# ((DateTime)Eval("WAKTU")).ToString("dd/MM/yyyy") + " - " %>' />
            <asp:Label ID="AKTIVITASLabel" runat="server" class="aktivitasLB" Text='<%# Eval("AKTIVITAS").ToString().Length > 200 ? 
                    Eval("AKTIVITAS").ToString().Substring(0,200)+"..." : Eval("AKTIVITAS")%>' />
            <br />
            <br />
        </ItemTemplate>

    </asp:DataList>
        <ul class="list-inline">
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lb1_Click" class="lbpaging" Text="<<"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lb2_Click" class="lbpaging" Text="prev"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lb3_Click" class="lbpaging" Text="next"></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lb4_Click" class="lbpaging" Text=">>"></asp:LinkButton>
            </li>
        </ul>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KNOWLEDGEConnectionString2 %>" SelectCommand="SELECT * FROM [LOGBOOK]"></asp:SqlDataSource>
        </section>
        </div>
</form>
</asp:Content>
