<%@ Page Title="" Language="C#" MasterPageFile="~/KnowledgeFIle.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Telkomsat.File.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
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
        <br />
        </div>
    <div class="row" id="dash" runat="server">
        <a href="../File/ippass.aspx">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-aqua"><i class="fa fa-file-text-o"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">IP</span>
              <asp:Label ID="lblPass" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
        <a href="../password/semuasoftware.aspx">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-aqua"><i class="fa fa-file-archive-o"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Password</span>
              <asp:Label ID="lblpassword" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
        <a href="../File/kategori1.aspx?ID=bukuManual">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-book"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Buku Manual</span>
                <asp:Label ID="lblBuku" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <a href="../File/kategori1.aspx?ID=SOP">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-file-text"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">SOP</span>
              <asp:Label ID="lblSOP" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
        <a href="../File/kategori1.aspx?ID=Pelatihan">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-folder-o"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Pelatihan</span>
              <asp:Label ID="lblPelatihan" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>

        <a href="../File/kategori1.aspx?ID=pembaruan">
      <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-cloud-upload"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Pembaruan Konfigurasi</span>
              <asp:Label ID="lblPembaruan" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
      </div>
        </section>
        </div>
</form>
</asp:Content>
