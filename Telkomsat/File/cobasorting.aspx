<%@ Page Title="" Language="C#" MasterPageFile="~/KnowledgeFIle.Master" AutoEventWireup="true" CodeBehind="cobasorting.aspx.cs" Inherits="Telkomsat.File.cobasorting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style.css" rel="stylesheet" />
<form id="form1" runat="server">
    <header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard.aspx">
          <img src="../img/logotelkomsat2.png" alt="Alternate Text" height="50"/></a>
          <input type="text" name="q" class="form-control" placeholder="Search..." runat="server" id="txtMaster" style="vertical-align:middle"/>
          <span class="input-group-btn">
                <button type="submit" name="search" class="btn btn-flat" runat="server" onserverclick="btnSearch_Click"><i class="fa fa-search"></i>
                </button>
              </span>  
    </div>
    </div>
    </header>

    <br /> 
    <div class="content-wrapper">
    <section class="content">
        <div class="bodyLB2">

        <ul class="list-inline">
            <li>
                <asp:Button ID="Button1" runat="server" Text="Semua" CssClass="btn btn-sm" Width="80px"/>
            </li>
            <li style="margin-right:300px;">
                <asp:Button ID="Button2" runat="server" Text="File" CssClass="btn btn-adn" Width="80px"/>
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
        </div>
        <asp:GridView ID="gvFile" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White" OnPageIndexChanging="OnPageIndexChanging"
            BorderColor="White" BorderStyle="None" BorderWidth="0px" AllowSorting="true" OnSorting="gvFile_Sorting" EnableViewState="true">
            <Columns>
                <asp:TemplateField HeaderText="Nama File" ItemStyle-Width="300px" SortExpression="NameFile">
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" Text='<%# Eval("NameFile") %>' CommandArgument='<%#Eval("ID") %>' OnClick="linkDownloadFile_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField ="Waktu" HeaderText ="Tanggal" ItemStyle-Width="180px" DataFormatString="{0:dd MMM yyyy}" ItemStyle-CssClass="rows" SortExpression="Waktu"/>
                <asp:TemplateField HeaderText="Ukuran" ItemStyle-Width="100px" SortExpression="Panjang">
                    <ItemTemplate>
                        <asp:Label ID ="lblPanjang" runat ="server" Text='<%# Eval("Panjang") + " kb" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField ="Kategori1" HeaderText ="Kategori" ItemStyle-Width="170px"  ItemStyle-CssClass="rows" SortExpression="Kategori1"/>
                
            </Columns>
           <FooterStyle BackColor="Yellow" ForeColor="Yellow" BorderStyle="Double" />
            <HeaderStyle BackColor="#e6e6e6" Font-Bold="True" ForeColor="#747474"/>
            <PagerStyle BackColor="White" CssClass="pagination-ys" HorizontalAlign="Right" Height="70px" VerticalAlign="Middle" 
                 BorderColor="White" BorderStyle="None" BorderWidth="0" />
            <PagerSettings Mode="Numeric" PageButtonCount="4" FirstPageText="1" />
            <RowStyle BackColor="White" ForeColor="#453d3d" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>

    </section>
    </div>
    </form>
</asp:Content>
