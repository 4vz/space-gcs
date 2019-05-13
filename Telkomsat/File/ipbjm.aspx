<%@ Page Title="" Language="C#" MasterPageFile="~/KnowledgeFIle.Master" AutoEventWireup="true" CodeBehind="ipbjm.aspx.cs" Inherits="Telkomsat.File.ipbjm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="file.css" rel="stylesheet" />
<form id="form1" runat="server">
    <header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
        <asp:HiddenField ID="hfContactID" runat="server" />
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
        <asp:Button ID="btnurut" runat="server" Text="Button" OnClick="btnurut_click" CssClass="urut"/>
        <asp:Button ID="btnip" runat="server" Text="Button" OnClick="btnip_click" CssClass="urut"/>
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
                    <option value="Host">Host Name</option>
                    <option value="Description">Description</option>
                    <option value="IP_Address">IP Address</option>
                </select>
            </li>
            <li style="margin-right:20px;">
                <asp:RadioButton ID="rbasc" runat="server" Text=" Asc" GroupName="rbsort" onchange="change()" />
                <asp:RadioButton ID="rbdesc" runat="server" Text=" Desc" GroupName="rbsort" onchange="change()"/>
            </li>
            <li style="margin-right:10px;">
                <button type="submit" class="btn-file" runat="server" onserverclick="btnTambah_Click"><i class="fa fa-plus" style="font-size:12px"></i> Tambah
                </button>
            </li>
        </ul>
        </div>
        <span class="headIP">IP Password</span>
        <br />
        <ul class="list-inline">
            <li style="margin-right:20px;">
                <asp:RadioButton ID="rbbjm" runat="server" Text=" BJM" GroupName="rbip" onchange="change1()" Width="70px" />
                <asp:RadioButton ID="rbcbi" runat="server" Text=" CBI" GroupName="rbip" onchange="change1()" Width="70px"/>
                <asp:RadioButton ID="rbt2" runat="server" Text=" Telkom 2" GroupName="rbip" onchange="change1()" Width="170px"/>
            </li>
        </ul>
        <asp:GridView ID="gvFile" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
            BorderColor="White" BorderStyle="None" BorderWidth="1px" CssClass="gview" AllowPaging="true" PageSize="30" OnPageIndexChanging="OnPaging" OnPreRender="gvContact_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No" ItemStyle-Width="30px">   
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>   
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField ="HOST_NAME" HeaderText ="Host Name" ItemStyle-Width="140px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="DESCRIPTION" HeaderText ="Description" ItemStyle-Width="220px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="SUPPLIER" HeaderText ="Supplier" ItemStyle-Width="140px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="INSTALLATION" HeaderText ="Installation" ItemStyle-Width="120px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="IP_ADDRESS" HeaderText ="IP Address" ItemStyle-Width="150px"  ItemStyle-CssClass="rows"/>  
                <asp:TemplateField ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID") %>' OnClick ="Ink_OnClick1">edit</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:Label ID="lblPage" runat="server" Text="Label" CssClass="halaman1"></asp:Label>
        </section>
        </div>
    </form>
    <script type="text/javascript">
        function myNewFunction1(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput == "Host" || userinput == "Description" || userinput == "IP_Address")
            {
                document.getElementById('<%=btnurut.ClientID%>').click();
            }
        }

        function change() {
            document.getElementById('<%=btnurut.ClientID%>').click();
        }
        function change1() {
            document.getElementById('<%=btnip.ClientID%>').click();
        }
    </script>
</asp:Content>
