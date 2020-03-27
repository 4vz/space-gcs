﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTME.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Telkomsat.checklistme.dashboard" %>
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
            Checklist ME
        </div>
        <div class="box-body">
            <div class="row">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div> 
</asp:Content>