<%@ Page Title="Kategori" Language="C#" MasterPageFile="~/KnowledgeFIle.Master" AutoEventWireup="true" CodeBehind="kategori1.aspx.cs" Inherits="Telkomsat.File.kategori1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <header class="main-header">
        <hr width="100%" align="center" style="margin-top:0px; margin-bottom:10px;" class="hrline"> 
            
    <div class="bodyLB3">
    <div class="input-group" style="vertical-align:middle">
        <a href="../dashboard2.aspx">
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
    <div class="row" id="bukuManual" runat="server" style="display:none">
        <!-- /.col -->
        <a href="../File/filter.aspx?ID=01-Cibinong">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-globe"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Cibinong</span>
              <asp:Label ID="lblBukuCBI" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <a href="../File/filter.aspx?ID=01-Banjarmasin">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-globe"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Banjarmasin</span>
              <asp:Label ID="lblBukuBJM" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
        <a href="../File/filter.aspx?ID=01-Medan">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-globe"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Medan</span>
              <asp:Label ID="lblBukuMDN" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
      </div>

    <div class="row" id="Pelatihan" runat="server" style="display:none">
        <!-- /.col -->
        <a href="../File/filter.aspx?ID=03-Satelit">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-folder-open-o"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Satelit</span>
              <asp:Label ID="lblPelSat" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <a href="../File/filter.aspx?ID=03-Ground">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-folder-open-o"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Ground</span>
              <asp:Label ID="lblPelGro" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
      </div>

    <div class="row" id="SOP" runat="server" style="display:none">
        <!-- /.col -->
        <a href="../File/filter.aspx?ID=02-Telkom+2">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-space-shuttle"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Telkom 2</span>
              <asp:Label ID="lblSOPT2" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <a href="../File/filter.aspx?ID=02-Telkom+3S">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-space-shuttle"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Telkom 3S</span>
              <asp:Label ID="lblSOPT3S" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
        <a href="../File/filter.aspx?ID=02-MPSat">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-space-shuttle"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">MPSat</span>
              <asp:Label ID="lblSOPMP" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>

        <a href="../File/filter.aspx?ID=02-Other">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-folder-o"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Other</span>
              <asp:Label ID="lblSOPOther" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
      </div>

        <div class="row" id="pembaruan" runat="server" style="display:none">
        <!-- /.col -->
        <a href="../File/filter.aspx?ID=04-Operasional">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-folder-open"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Operasional</span>
              <asp:Label ID="lblPemOp" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <a href="../File/filter.aspx?ID=04-Network">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-folder-open"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Network</span>
              <asp:Label ID="lblPemNe" runat="server" class="info-box-number"></asp:Label>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <!-- /.col -->
        <a href="../File/filter.aspx?ID=04-Communication+&+Monitor">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-folder-open"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Communication & Monitoring</span>
              <asp:Label ID="lblPemCom" runat="server" class="info-box-number"></asp:Label>
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
