<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="idasset.aspx.cs" Inherits="Telkomsat.logbook1.idasset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="log.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblJudul" runat="server" Text="Label" CssClass="tabeljudul"></asp:Label>
    <br />
    <div style="padding-left:100px">
    <asp:HiddenField ID="hfContactID" runat="server" />
        <br />
    <asp:DataList runat="server" Width="568px" ID="DataList1" >
        <ItemTemplate>
            <table style="padding-left:100px;" class="tabel">
                <tr>
                <td class="tbl" style="padding-bottom:7px; padding-right:170px">
                    <asp:Label ID="Label15" runat="server" Text="ID" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID_Asset") %>' Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px; padding-right:170px">
                    <asp:Label ID="Label1" runat="server" Text="Kelompok" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblKelompok" runat="server" Text='<%# Eval("kelompok") %>' Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label23" runat="server" Text="Nama" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblNama" runat="server" Text='<%# Eval("nama") %>' Width="220px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label2" runat="server" Text="Merk" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblMerk" runat="server" Text='<%# Eval("merk") %>' Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label3" runat="server" Text="Model" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblModel" runat="server" Text='<%# Eval("model") %>' Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label4" runat="server" Text="Serial Number" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblSN" runat="server" Text='<%# Eval("S/N") %>' Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px; padding-top:0;">
                    <asp:Label ID="Label5" runat="server" Text="Product Number" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px; padding-top:0;">
                    <asp:Label ID="lblPN" runat="server" Text='<%# Eval("P/N") %>' Width="300px" class="tb"></asp:Label>
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
                            <asp:Label ID="lblSite" runat="server" Text='<%# Eval("Site") %>' Width="300px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px">
                            <asp:Label ID="Label13" runat="server" Text="Gudang" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px;">
                            <asp:Label ID="lblGudang" runat="server" Text='<%# Eval("gudang") %>' Width="200px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:15px; padding-left:35px">
                            <asp:Label ID="Label10" runat="server" Text="Rak" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:15px;">
                            <asp:Label ID="lblRak" runat="server" Text='<%# Eval("rak") %>' Width="300px" class="tb"></asp:Label>
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
                            <asp:Label ID="lblTelkom2" runat="server" Text='<%# Eval("telkom2") %>' Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:5px; padding-left:35px">
                            <asp:Label ID="lbl1" runat="server" Text="Telkom3S" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:5px;">
                            <asp:Label ID="lblTelkom3S" runat="server" Text='<%# Eval("telkom3s") %>' Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl" style="padding-bottom:15px; padding-left:35px">
                            <asp:Label ID="Label27" runat="server" Text="MPSat" class="tb"></asp:Label>
                        </td>
                        <td class="tbl" style="padding-bottom:15px;">
                            <asp:Label ID="lblMpsat" runat="server" Text='<%# Eval("mpsat") %>' Width="100px" class="tb"></asp:Label>
                        </td>
                    </tr>

            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label6" runat="server" Text="Fungsi" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblFungsi" runat="server" Text='<%# Eval("fungsi") %>' Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label7" runat="server" Text="Status" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' Width="300px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="Label8" runat="server" Text="Keterangan" class="tb"></asp:Label>
                </td>
                <td class="tbl" style="padding-bottom:7px;">
                    <asp:Label ID="lblKeterangan" runat="server" Text='<%# Eval("keterangan") %>' Width="400px" class="tb"></asp:Label>
                </td>
            </tr>
            <tr>
            </table>
        </ItemTemplate>

    </asp:DataList>
        <div style="padding-left:234px">
            <asp:Button ID="btnKembali" runat="server" Text="Kembali" OnClick="btnKembali_Click" CssClass="btn btn-warning" Width="90px"/>
        </div>
        
    </div>

</asp:Content>
