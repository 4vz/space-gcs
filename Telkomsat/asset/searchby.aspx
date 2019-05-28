<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="searchby.aspx.cs" Inherits="Telkomsat.asset.searchby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
        </div>
        
    <h3 style="text-align: center">Pencarian Data Equipment</h3>
        <br />
    <div class="form-group">
        <table align="center">
            <tr>
                <td style="padding-bottom:5px; padding-right:40px">
                    <asp:Label ID="Label1" runat="server" Text="NAMA EQ"></asp:Label>
                </td>
                <td style="padding-bottom:5px;" colspan="3">
                    <asp:TextBox ID="txtNama" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label2" runat="server" Text="MERK"></asp:Label>
                </td>
                <td class="auto-style1" style="padding-bottom:5px;" colspan="3">
                    <asp:TextBox ID="txtMerk" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label4" runat="server" Text="[S/N]"></asp:Label>
                </td>
                <td class="auto-style1" style="padding-bottom:5px;" colspan="3">
                    <asp:TextBox ID="txtSN" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label3" runat="server" Text="LOKASI"></asp:Label>
                </td>
                <td class="auto-style1" style="padding-bottom:5px;" colspan="3">
                    <asp:TextBox ID="txtLokasi" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label5" runat="server" Text="GUDANG"></asp:Label>
                </td>
                <td class="auto-style1" style="padding-bottom:5px;" colspan="3">
                    <asp:TextBox ID="txtGudang" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label6" runat="server" Text="FUNGSI"></asp:Label>
                </td>
                <td class="auto-style1" style="padding-bottom:5px;" colspan="3">
                    <asp:TextBox ID="txtFungsi" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label7" runat="server" Text="STATUS"></asp:Label>
                </td>
                <td class="auto-style1" style="padding-bottom:5px;" colspan="3">
                    <asp:TextBox ID="txtStatus" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;" colspan="4">
                    <asp:Label ID="Label8" runat="server" Text="TAHUN PENGADAAN" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label9" runat="server" Text="DARI"></asp:Label>
                </td>
                <td style="padding-bottom:5px;">
                    <asp:TextBox ID="txtDari" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td class="auto-style1" style="padding-bottom:5px;">
                    <asp:Label ID="Label10" runat="server" Text="KE"></asp:Label>
                </td>
                <td class="auto-style1" style="padding-bottom:5px; padding-left:10px;">
                    <asp:TextBox ID="txtKe" runat="server" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnSearchby" runat="server" Text="Search" OnClick="btnSearchby_Click" />
                </td>
            </tr> 

        </table>
        <br/>
        <asp:Label ID="lblnull" align="center" runat="server" Text="" ForeColor="#666666" Font-Bold="true" Font-Size="18px"></asp:Label> 

        </div>
        <asp:Label ID="lblCount" runat="server" Text="Label" CssClass="count1"></asp:Label>
        <asp:Button ID="btnExpand" runat="server" Text="Expand" OnClick="Expand_OnClick" class="cssexpand"/>
        
        <select class="ddl" id="urutkan" onChange="myNewFunction(this);" runat="server">
            <option >-Urutkan-</option>
            <option value="KELOMPOK">Kelompok</option>
            <option value="NAMA">Nama</option>
            <option value="MERK">Merk</option>
            <option value="SITE">Lokasi</option>
            <option value="FUNGSI">Fungsi</option>
            <option value="STATUS">Status</option>
        </select>
        <asp:Button ID="btnurut" runat="server" Text="Button" OnClick="btnurut_click" CssClass="urut"/>
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False" style="margin:0 auto;" Font-Size="13px" BackColor="White"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" AllowPaging="true" PageSize="30" OnPageIndexChanging="OnPaging" OnPreRender="gvContact_PreRender">
            <Columns>
                <asp:BoundField DataField ="KELOMPOK" HeaderText ="KELOMPOK" ItemStyle-Width="140px"/>
                <asp:BoundField DataField ="NAMA" HeaderText ="NAMA" ItemStyle-Width="160px" />
                <asp:BoundField DataField ="MERK" HeaderText ="MERK" ItemStyle-Width="170px" />
                <asp:BoundField DataField ="MODEL" HeaderText ="MODEL" ItemStyle-Width="90px" />
                <asp:BoundField DataField ="S/N" HeaderText ="S/N" ItemStyle-Width="90px"/>
                <asp:BoundField DataField ="P/N" HeaderText ="P/N" ItemStyle-Width="120px"/>
                <asp:BoundField DataField ="SITE" HeaderText ="LOKASI" ItemStyle-Width="70px" />
                <asp:BoundField DataField ="GUDANG" HeaderText ="RUANGAN" ItemStyle-Width="90px"/>
                <asp:BoundField DataField ="RAK" HeaderText ="RAK" ItemStyle-Width="50px"/>
                <asp:BoundField DataField ="TELKOM2" HeaderText ="TK2" ItemStyle-Width="50px"/>
                <asp:BoundField DataField ="TELKOM3S" HeaderText ="TK3S" ItemStyle-Width="50px"/>
                <asp:BoundField DataField ="MPSAT" HeaderText ="MPSAT" ItemStyle-Width="70px"/>
                <asp:BoundField DataField ="FUNGSI" HeaderText ="FUNGSI" ItemStyle-Width="110px"/>
                <asp:BoundField DataField ="STATUS" HeaderText ="STATUS" ItemStyle-Width="90px"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID_Asset") %>' OnClick ="Ink_OnClick1">View</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Yellow" ForeColor="Yellow" BorderStyle="Double" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#fafafa"/>
            <PagerStyle BackColor="White" CssClass="pagination-ys" HorizontalAlign="Right" Height="70px" VerticalAlign="Middle" 
                 BorderColor="White" BorderStyle="None" BorderWidth="0" />
            <PagerSettings Mode="Numeric" PageButtonCount="4" FirstPageText="1" />
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblPage" runat="server" Text="Label" CssClass="halaman"></asp:Label>
    </div>
</form>
    <script type="text/javascript">
        function myNewFunction(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput == "KELOMPOK" || userinput == "NAMA" || userinput == "MERK" || userinput == "SITE"
                || userinput == "FUNGSI" || userinput == "STATUS")
            {
                document.getElementById('<%=btnurut.ClientID%>').click();
            }
        }
    </script>
</asp:Content>
