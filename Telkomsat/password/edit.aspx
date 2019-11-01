<%@ Page Title="Edit" Language="C#" MasterPageFile="~/KnowledgeFIle.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Telkomsat.password.edit" %>
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
        
        <ul class="list-inline">
            <li>
                <asp:Button ID="Button1" runat="server" Text="Posting" CssClass="btn btn-sm" Width="80px" OnClick="btnPosting_Click"/>
            </li>
            <li style="margin-right:300px;">
                <asp:Button ID="Button2" runat="server" Text="File" CssClass="btn btn-adn" Width="80px" OnClick="btnFile_Click"/>
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
        </div>
        <span class="headIP">Update Konfigurasi Password</span>
        <br />
        <asp:Label ID="lblUpdate" runat="server" Text="Label" Visible="false"></asp:Label>
        <div class="divtabel" style="margin-left:80px;">
        <table>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label17" class="lbl" runat="server">Nama </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label18" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txtnama" class="tb1" runat="server" Width="315px"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label2" class="lbl" runat="server">Lokasi </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label3" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txtlokasi" class="tb1" runat="server" Width="185px"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label4" class="lbl" runat="server">Jenis </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label5" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:DropDownList ID="ddlJenis" runat="server" class="ddl3" Width="120px" onchange="kategori1(this);">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Software</asp:ListItem>
                        <asp:ListItem>Hardware</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>

            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label6" class="lbl" runat="server">Hostname </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label7" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txthost" class="tb1" runat="server" Width="155px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label1" class="lbl" runat="server">Username </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label8" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txtuser" class="tb1" runat="server" Width="155px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    <asp:Label ID="Label9" class="lbl" runat="server">Password </asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    <asp:Label ID="Label10" runat="server" >:</asp:Label>
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:TextBox ID="txtpass" class="tb1" runat="server" Width="155px"></asp:TextBox>
                </td>

            </tr>
             <tr>
                <td class="tdtext" style="padding-bottom:10px; padding-right:70px; height: 32px;">
                    
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="titikdua">
                    
                </td>
                <td style="padding-bottom:10px; height: 32px;" class="tdtext">
                    <asp:Button ID="Button3" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-danger"/>
                </td>

            </tr>
            
            </table>
            </div>

        </section>
        </div>
    </form>

</asp:Content>
