<%@ Page Title="" Language="C#" MasterPageFile="~/MAINTENANCEHK.Master" AutoEventWireup="true" CodeBehind="data.aspx.cs" Inherits="Telkomsat.maintenancehk.bulanan.data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
        .link{
            color:black;
            font-size:12px;
            font-weight:bold;
        }
        .link:hover{
            color:black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box box-primary">
        <div class="box-header">
            <asp:Label ID="lbltitle" runat="server" Text="lbltitle1"></asp:Label>
        </div>
        <div class="box-body">
            <div class="row">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div> 
</asp:Content>


