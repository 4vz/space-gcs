<%@ Page Title="" Language="C#" MasterPageFile="~/KNOWLEDGE.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Telkomsat.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Bootstrap Part 14 : Membuat Carousel dengan Bootstrap</title>
	<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/bootstrap.js"></script>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <button data-target="#loginModal" data-toggle="modal">login</button>
    <div class="modal fade" tabindex="-1" id="loginModal"
        data-keyboard="false" data-backdrop="static">
    <div class="modal-dialog modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    &times;
                </button>
                <h4 class="modal-title">Login</h4>
            </div>
            <div class="modal-body">

                    <div class="form-group">
                        <label for="inputUserName">Username</label>
                        <input placeholder="Login Username"
                                type="text" id="inputUserName" />
                    </div>
                    <div class="form-group">
                        <label for="inputPassword">Password</label>
                        <input class="form-control" placeholder="Login Password"
                                type="password" id="inputPassword" />
                    </div>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-primary">Login</button>
                <button type="button" class="btn btn-primary"
                        data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
</form>
</asp:Content>
