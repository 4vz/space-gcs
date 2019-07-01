<%@ Page Title="" Language="C#" MasterPageFile="~/LOGBOOK.Master" AutoEventWireup="true" CodeBehind="editlogbook.aspx.cs" Inherits="Telkomsat.logbook1.editlogbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    

<script type="text/javascript">
$(document).ready(function(){
    $("#tr2").hide();
    $("#tr3").hide();
    $("#tr4").hide();
    var i = 0;
    $("#show").click(function () {
        i = i + 1;
        if (i == 1) {
            $("#tr2").show(700);
        }
        if (i == 2) {
            $("#tr3").show(700);
        }
        if (i == 3) {
            $("#tr4").show(700);
        }
    
    });

    $("#close1").click(function () {
        document.getElementById('<%=ImgUpload1.ClientID %>').value = '';
    });
    $("#close2").click(function () {
        document.getElementById('<%=ImgUpload2.ClientID %>').value = '';
    });
    $("#close3").click(function () {
        document.getElementById('<%=ImgUpload3.ClientID %>').value = '';
    });
    $("#close4").click(function () {
        document.getElementById('<%=ImgUpload4.ClientID %>').value = '';
    });
    $("#closefile1").click(function () {
        document.getElementById('<%=FileUpload1.ClientID %>').value = '';
    });
    $("#closefile2").click(function () {
        document.getElementById('<%=FileUpload2.ClientID %>').value = '';
    });
    });

</script>
    <script src="js4.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="log.css" rel="stylesheet" type="text/css"/>

    <div class="navbar navbar-static-top" style="text-align: left">
        <div class="tengah">
            <asp:HiddenField ID="hfContactID" runat="server" />
            <asp:Label ID="lblWaktu" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        
    <h3><span style="left:20%">Input Logbook</span></h3>
        <asp:Label ID="lblUpdate" runat="server" Text=""></asp:Label>
        <br />
    <div class="divtabel" style="margin-left:80px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Tanggal </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txtTanggal" class="tb1" runat="server" Width="115px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label27" class="lbl" runat="server">Kategori  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label28" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:DropDownList ID="ddlKategori" runat="server" class="ddl3" Width="120px" onchange="status(this)">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Perbaikan</asp:ListItem>
                        <asp:ListItem>Perawatan</asp:ListItem>
                        <asp:ListItem>Pointing Antena</asp:ListItem>
                        <asp:ListItem>Penggantian</asp:ListItem>
                        <asp:ListItem>Lain-lain</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-left:50px; padding-right:20px; visibility:hidden" id="labelID">
                    <asp:Label ID="Label29" class="lbl" runat="server">SN Asset  </asp:Label>
                </td>
                <td style="padding-bottom:10px; visibility:hidden" class="titikdua" id="labelID1">
                    <asp:Label ID="Label30" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; visibility:hidden" class="tdtext" id="labelID2" colspan="3">
                    <asp:TextBox ID="txtSN" class="tb1" runat="server" Width="188px"></asp:TextBox>
                </td>
                <td style="padding-bottom:10px; padding-right:5px; height: 32px; visibility:hidden" class="tdtext" id="lblestimasi">
                    <asp:Label ID="Label35" runat="server" Text="Estimasi Harga"></asp:Label>
                    <input type="checkbox" id="checkbox1" onchange="validate()"/>
                </td>
            </tr>
            <tr id="trPergantian" style="display:none">
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">SN Aset Lama </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label32" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;">
                    <asp:TextBox ID="txtSN2" class="tb1" runat="server" Width="188px"></asp:TextBox>
                </td>
                <td>

                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-left:50px;">
                    <asp:Label ID="Label33" class="lbl" runat="server">SN Aset Baru </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label34" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtSN3" class="tb1" runat="server" Width="188px"></asp:TextBox>
                </td>
            </tr>
            <tr id="trEstimasi" style="display:none">
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label36" class="lbl" runat="server">Estimasi Harga</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label37" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="7">
                    <asp:TextBox ID="txtHarga" class="tb1" runat="server" Width="570px" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label9" class="lbl" runat="server">Event  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label38" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="7">
                    <asp:TextBox ID="txtEvent" class="tb1" runat="server" Width="570px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label25" class="lbl" runat="server">Unit  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label26" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="7">
                    <asp:DropDownList ID="ddlUnit" runat="server" class="ddl3" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Harkat</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label8" class="lbl" runat="server">Status  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server" >:</asp:Label>
                </td>
                <td class="tdtext" style="padding-bottom:10px;" colspan="7">
                    <asp:DropDownList ID="ddlStatus" runat="server" class="ddl3" Width="140px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>On Progress</asp:ListItem>
                        <asp:ListItem>Selesai</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px;">
                    <asp:Label ID="Label2" class="lbl" runat="server">PIC OS  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label5" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext">
                    <asp:TextBox ID="txtOS" class="tb1" runat="server" Width="160px"></asp:TextBox>
                </td>
                <td>

                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-right:30px; padding-left:50px;">
                    <asp:Label ID="Label6" class="lbl" runat="server">PIC OG  </asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="titikdua">
                    <asp:Label ID="Label7" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px;" class="tdtext" colspan="2">
                    <asp:TextBox ID="txtOG" class="tb1" runat="server" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label3" runat="server" class="lbl">Kegiatan  </asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label4" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext" colspan="7">
                    <asp:TextBox ID="txtInfo" class="tb1" runat="server" TextMode="MultiLine" Height="120px" Width="570px"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr1">
                <td class="tdtext" style="padding-bottom:10px; vertical-align:middle">
                    <asp:Label ID="Label15" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle;" class="titikdua">
                    <asp:Label ID="Label16" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle;" class="tdtext">
                    <asp:FileUpload ID="ImgUpload1" runat="server" Width="180px" />
                </td>

                <td style="padding-bottom:10px; vertical-align:middle; padding-left:10px" class="tdtext">
                    <button onclick="close()" id="close1" type="button" class="close">x</button> 
                </td>

                <td class="tdtext" style="padding-bottom:10px; padding-left:50px; padding-right:20px; vertical-align:middle">
                    <asp:Label ID="Label11" runat="server" class="lbl">Upload File</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle;" class="titikdua">
                    <asp:Label ID="Label12" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle;" class="tdtext">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="180px" />
                </td>
                <td style="padding-bottom:10px; vertical-align:middle; padding-left:10px" class="tdtext">
                    <button onclick="close()" id="closefile1" type="button" class="close">x</button> 
                </td>
                <td style="padding-bottom:10px; white-space:nowrap; padding-left:20px; vertical-align:top;" class="tdtext" >
                    <button id="show" type="button" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> 
                </td>
            </tr>
            <tr id="tr2">
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label13" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label14" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="ImgUpload2" runat="server"  Width="180px"/>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle; padding-left:10px" class="tdtext">
                    <button onclick="close()" id="close2" type="button" class="close">x</button> 
                </td>
                <td class="tdtext" style="padding-bottom:10px; padding-left:50px; padding-right:20px; vertical-align:top">
                    <asp:Label ID="Label19" runat="server" class="lbl">Upload File</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label20" runat="server">:</asp:Label>
                </td>
                
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="FileUpload2" runat="server" Width="180px"/>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle; padding-left:10px" class="tdtext">
                    <button onclick="close()" id="closefile2" type="button" class="close">x</button> 
                </td>
            </tr>
            <tr id="tr3">
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label21" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label22" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="ImgUpload3" runat="server" Width="180px"/>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle;" class="tdtext">
                    <button onclick="close()" id="close3" type="button" class="close">x</button> 
                </td>
            </tr>
            <tr id="tr4">
                <td class="tdtext" style="padding-bottom:10px; vertical-align:top">
                    <asp:Label ID="Label23" runat="server" class="lbl">Upload Gambar</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="titikdua">
                    <asp:Label ID="Label24" runat="server">:</asp:Label>
                </td>
                <td style="padding-bottom:10px; vertical-align:top;" class="tdtext">
                    <asp:FileUpload ID="ImgUpload4" runat="server" Width="180px"/>
                </td>
                <td style="padding-bottom:10px; vertical-align:middle;" class="tdtext">
                    <button onclick="close()" id="close4" type="button" class="close">x</button> 
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1">
                    
                </td>
                <td class="auto-style1" colspan="3">
                    <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-primary" Width="110px" OnClick="btnUpdate_Click" />
                    <asp:Label ID="Label31" runat="server" Text="  |  "></asp:Label>
                    <asp:Button ID="Button2" runat="server" Text="Delete" class="btn btn-default" Width="110px" OnClick="btnDelete_Click" OnClientClick="if (!confirm('Are you sure you want to delete?')) return false;" />
                </td>
            </tr>
        </table>
        <br />
        <asp:DataList runat="server" id="dtContact" Width="1135px" RepeatColumns="3" GridLines="Both" RepeatDirection="Horizontal" >
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" Width="250px" ImageUrl='<%# Eval("Image1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image1")) %>'/>
            <asp:Image ID="Image2" runat="server" Width="250px" ImageUrl='<%# Eval("Image2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image2")) %>'/>
            <asp:Image ID="Image3" runat="server" Width="250px" ImageUrl='<%# Eval("Image3")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image3")) %>'/>
            <asp:Image ID="Image4" runat="server" Width="250px" ImageUrl='<%# Eval("Image4")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image4")) %>'/>
            <asp:Image ID="File1" runat="server" Width="250px" ImageUrl='<%# Eval("File1")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("File1")) %>'/>
            <asp:Image ID="File2" runat="server" Width="250px" ImageUrl='<%# Eval("File2")==DBNull.Value ? null : "data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("File2")) %>'/>
            <br />
        </ItemTemplate>

    </asp:DataList>
        <br />
       </div>     
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;">
        <asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="False" style="margin:3px auto;" Font-Size="13px" BackColor="White" OnRowDataBound="gvLog_RowData" CssClass="gview"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField ="tanggal" HeaderText ="Tanggal" ItemStyle-Width="100px" DataFormatString="{0:dd MMM yyyy}" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="Unit" HeaderText ="Unit" ItemStyle-Width="120px" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="event" HeaderText ="Event" ItemStyle-Width="220px" ItemStyle-CssClass="rows" />
                <asp:BoundField DataField ="Status" HeaderText ="Status" ItemStyle-Width="120px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="info" HeaderText ="Info" ItemStyle-Width="300px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="PIC_OG" HeaderText ="PIC_OG" ItemStyle-Width="80px" ItemStyle-CssClass="rows"/>
                <asp:BoundField DataField ="PIC_OS" HeaderText ="PIC_OS" ItemStyle-Width="80px" ItemStyle-CssClass="rows"/>
                <asp:TemplateField HeaderText="Attach">
                    <ItemTemplate>
                        <asp:Label ID="lblImage" runat="server" Text='<%# Eval("Image1")!=DBNull.Value || Eval("File1")!=DBNull.Value ? "@" : " " %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("ID_Log") %>'> edit </asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           <FooterStyle BackColor="Yellow" ForeColor="Yellow" BorderStyle="Double" />
            <HeaderStyle BackColor="#212325" Font-Bold="True" ForeColor="#fafafa"/>
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

</asp:Content>
