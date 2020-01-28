<%@ Page Title="Semua" Language="C#" MasterPageFile="~/KnowledgeFIle.Master" AutoEventWireup="true" CodeBehind="semuafile.aspx.cs" Inherits="Telkomsat.File.semuafile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style.css" rel="stylesheet" />
<form id="form1" runat="server">
    <header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard2.aspx">
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
            <asp:Button ID="btnurut" runat="server" Text="Button" OnClick="btnurut_click" CssClass="urut"/>
        <ul class="list-inline">
            <li>
                <asp:Button ID="Button1" runat="server" Text="Posting" CssClass="btn btn-sm" Width="80px" OnClick="btnPosting_Click"/>
            </li>
            <li style="margin-right:300px;">
                <asp:Button ID="Button2" runat="server" Text="File" CssClass="btn btn-adn" Width="80px" OnClick="btnFile_Click"/>
            </li>
            <li>
                <select class="ddl28" id="urutkan" onChange="myNewFunction1(this);" runat="server">
                    <option >-Urutkan-</option>
                    <option value="Nama File">Nama File</option>
                    <option value="Waktu">Waktu</option>
                    <option value="Ukuran">Ukuran</option>
                    <option value="Kategori">Kategori</option>
                </select>
            </li>
            <li style="margin-right:20px;">
                <asp:RadioButton ID="rbasc" runat="server" Text=" Asc" GroupName="rbsort" onchange="change()" />
                <asp:RadioButton ID="rbdesc" runat="server" Text=" Desc" GroupName="rbsort" onchange="change()"/>
            </li>
            <li>
                <button type="submit" class="btn-file" runat="server" onserverclick="btnTambah_Click"><i class="fa fa-plus" style="font-size:12px"></i> Tambah
                </button>
            </li>
        </ul>
        <br />
        </div>
        <asp:GridView ID="gvFile" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
            BorderColor="White" BorderStyle="None" BorderWidth="0px">
            <Columns>
                <asp:TemplateField HeaderText="Nama File" ItemStyle-Width="300px">
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" Text='<%# Eval("NameFile") %>' CommandArgument='<%# Eval("ID") %>' OnClick="linkDownloadFile_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField ="Waktu" HeaderText ="Tanggal" ItemStyle-Width="180px" DataFormatString="{0:dd MMM yyyy}" ItemStyle-CssClass="rows"/>
                <asp:TemplateField HeaderText="Ukuran" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID ="lblPanjang" runat ="server" Text='<%# Eval("Panjang") + " kb" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField ="Kategori1" HeaderText ="Kategori" ItemStyle-Width="170px"  ItemStyle-CssClass="rows"/>
                
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

    <script type="text/javascript">
        function myNewFunction1(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput == "Nama File" || userinput == "Waktu" || userinput == "Ukuran" || userinput == "Kategori")
            {
                document.getElementById('<%=btnurut.ClientID%>').click();
            }
        }

        function change() {
            document.getElementById('<%=btnurut.ClientID%>').click();
        }
    </script>
</asp:Content>
