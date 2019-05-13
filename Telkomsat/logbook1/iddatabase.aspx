<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="iddatabase.aspx.cs" Inherits="Telkomsat.logbook1.iddatabase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
        </div>
        <div class="divtabel">
        <h3><span style="left:20%">Data Equipment</span></h3>
        <br/>
        <table style="padding-left:150px;" class="tabel">
            <tr>
                <td class="tbl" style="padding-bottom:7px; padding-right:170px">
                    <asp:Label ID="Label15" runat="server" Text="ID" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblID" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px; padding-right:170px">
                    <asp:Label ID="Label1" runat="server" Text="Kelompok" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblKelompok" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label23" runat="server" Text="Nama" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblNama" runat="server" Text="" Width="220px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label2" runat="server" Text="Merk" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblMerk" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label3" runat="server" Text="Model" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblModel" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label4" runat="server" Text="Serial Number" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblSN" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px; padding-top:0;">
                    <asp:Label ID="Label5" runat="server" Text="Product Number" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px; padding-top:0;">
                    <asp:Label ID="lblPN" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:14px; padding-top:0;">
                    <asp:Label ID="Label14" runat="server" Text="Tahun Pengadaan" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:14px; padding-top:0;">
                    <asp:Label ID="lblTahun" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label9" runat="server" Text="Lokasi" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">

                </td>
            </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px;">
                            <asp:Label ID="Label11" runat="server" Text="Site" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px;">
                            <asp:Label ID="lblSite" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px">
                            <asp:Label ID="Label13" runat="server" Text="Gudang" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px;">
                            <asp:Label ID="lblGudang" runat="server" Text="" Width="200px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:15px; padding-left:35px">
                            <asp:Label ID="Label10" runat="server" Text="Rak" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:15px;">
                            <asp:Label ID="lblRak" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                        </td>
                    </tr>

            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label12" runat="server" Text="Kelompok Satelit" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">

                </td>
            </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px;">
                            <asp:Label ID="lbl2" runat="server" Text="Telkom2" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px;">
                            <asp:Label ID="lblTelkom2" runat="server" Text="" Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px">
                            <asp:Label ID="lbl1" runat="server" Text="Telkom3S" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px;">
                            <asp:Label ID="lblTelkom3S" runat="server" Text="" Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:15px; padding-left:35px">
                            <asp:Label ID="Label27" runat="server" Text="MPSat" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:15px;">
                            <asp:Label ID="lblMpsat" runat="server" Text="" Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>

            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label6" runat="server" Text="Fungsi" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblFungsi" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label7" runat="server" Text="Status" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblStatus" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label8" runat="server" Text="Keterangan" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblKeterangan" runat="server" Text="" Width="400px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="btnKembali" runat="server" Text="Kembali" onclick="btnKembali_Click" CssClass="btn btn-warning" Width="90px"/>
                </td>
            </tr>
        </table>
        </div>
        <br />
        <asp:Label ID="lblMore" runat="server" Text=" " class="tb"></asp:Label>
        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False" style="margin:0 auto;" Font-Size="13px" BackColor="White" CssClass="gview"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField ="TANGGAL" HeaderText ="TANGGAL" ItemStyle-Width="100px" DataFormatString="{0:dd MMM yyyy}" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="SITE" HeaderText ="LOKASI" ItemStyle-Width="120px"  ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="GUDANG" HeaderText ="GUDANG" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="RAK" HeaderText ="RAK" ItemStyle-Width="50px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="FUNGSI" HeaderText ="FUNGSI" ItemStyle-Width="110px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="STATUS" HeaderText ="STATUS" ItemStyle-Width="90px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="KETERANGAN" HeaderText ="KETERANGAN" ItemStyle-Width="200px" ItemStyle-CssClass="rows"/>
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
    </div>
</form>
</asp:Content>
