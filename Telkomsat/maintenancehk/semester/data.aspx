<%@ Page Title="Maintenance Semester" Language="C#" MasterPageFile="~/MAINTENANCEHK.Master" AutoEventWireup="true" CodeBehind="data.aspx.cs" Inherits="Telkomsat.maintenancehk.semester.data" %>
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
            Maintenance Semester
        </div>
        <div class="box-body">
            <div class="row">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div> 
</asp:Content>
