<%@ Page Title="" Language="C#" MasterPageFile="~/CHECKLISTHK.Master" AutoEventWireup="true" CodeBehind="dashboardbjm.aspx.cs" Inherits="Telkomsat.checkbjm.dashboardbjm" %>
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
     <div class="box box-primary" runat="server" id="divdata" visible="false">
        <div class="box-header">
            Checklist Harkat Cibinong
        </div>
        <div class="box-body">
            <div class="col-md-12 col-xs-12">
                <table class="table">
                    <tr>
                    <th>Tanggal</th>
                    <th>Petugas</th>
                    <th>Approval</th>
                    </tr>
                    <tr style="background-color:white">
                    <td><asp:Label ID="lbltanggal" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblpetugas" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblapproval" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
            </div>
            
        </div>
    </div> 
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
