<%@ Page Title="" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Telkomsat.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div class="navbar navbar-static-top" style="text-align: left">
    <div class="tengah">
        <asp:HiddenField ID="hfContactID" runat="server" />
    </div>
        
    <br/>
        <div align="center">   
            <img src="img/logotelkomsat.png" alt="Logo" style="width:420px; padding-top:150px;"/>     
        </div>
        <div align="center" class="masukan">
            <asp:TextBox ID="txtCari" runat="server" class="textbox" placeholder="cari.." BorderStyle="Solid"></asp:TextBox><br />
            <br />
            <asp:Button ID="btnCari" runat="server" Text="Search" onclick="btnCari_Click" class="btn btn-default btn-block btn-flat" Font-Bold="True"/>
        </div>
    </div>
</form> 
</asp:Content>
