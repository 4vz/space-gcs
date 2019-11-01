<%@ Page Title="Detail" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="Telkomsat.asset.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                    <asp:Label ID="Label1" runat="server" Text="Kelompok" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblKelompok" runat="server" Text="" Width="300px" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label15" runat="server" Text="Terakhir Update" class="tb" Width="220px" ForeColor="Black"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblWaktu" runat="server" Text="" Width="300px" class="tb" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label23" runat="server" Text="Nama" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblNama" runat="server" Text="" Width="220px" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label16" runat="server" Text="PIC" class="tb" ForeColor="Black"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblPIC" runat="server" Text="" Width="300px" class="tb" ForeColor="Black"></asp:Label>
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
                            <asp:Label ID="Label13" runat="server" Text="Ruangan" class="tb"></asp:Label>
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
                    <asp:Button ID="btnMore" runat="server" Text="Histori" onclick="btnMore_Click" CssClass="btn btn-info" Width="90px"/>
                    <asp:Label ID="Label17" runat="server" Text="  |  "></asp:Label>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click" CssClass="btn btn-default" Width="90px"/>
                </td>
            </tr>
        </table>
        </div>
        <br />
        <asp:Label ID="lblMore" runat="server" Text=" " class="tb"></asp:Label>
        <div style="padding-left:110px;">
            <asp:LinkButton ID="linkLog" runat="server" OnClick="linkSN_Click" Visible="false">Go to Logbook</asp:LinkButton>
        </div>
        <br />
        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False" style="margin:0 auto;" Font-Size="13px" BackColor="White" CssClass="gview"
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField ="TANGGAL" HeaderText ="TANGGAL" ItemStyle-Width="100px" DataFormatString="{0:dd MMM yyyy}" ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="120px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField ="SITE" HeaderText ="LOKASI" ItemStyle-Width="120px"  ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="110px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField ="GUDANG" HeaderText ="GUDANG" ItemStyle-Width="90px" ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="120px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField ="RAK" HeaderText ="RAK" ItemStyle-Width="50px" ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField ="FUNGSI" HeaderText ="FUNGSI" ItemStyle-Width="110px" ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField ="STATUS" HeaderText ="STATUS" ItemStyle-Width="90px" ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="90px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField ="KETERANGAN" HeaderText ="KETERANGAN" ItemStyle-Width="200px" ItemStyle-CssClass="rows">
                        <ItemStyle CssClass="rows" Width="400px"></ItemStyle>
                </asp:BoundField>
            </Columns>
           <FooterStyle BackColor="#CCCC99" ForeColor="Black" BorderStyle="Double" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="White" CssClass="pagination-ys" HorizontalAlign="Right" Height="70px" VerticalAlign="Middle" 
                 BorderColor="White" BorderStyle="None" BorderWidth="0" ForeColor="Black" />
            <PagerSettings Mode="Numeric" PageButtonCount="4" FirstPageText="1" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</asp:Content>
