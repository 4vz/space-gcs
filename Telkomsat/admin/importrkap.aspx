<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="importrkap.aspx.cs" Inherits="Telkomsat.admin.importrkap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <asp:Label ID="lblerror" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button Text="Upload" OnClick="Upload" runat="server" />
        </div>
    </div>
</asp:Content>
