<%@ Page Title="Data Vendor" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="detailvendor.aspx.cs" Inherits="Telkomsat.admin.detailvendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td{
            border-top:0px;
        }

        th{
            font-size:14px;
            float:left;
        }

        .table>tbody>tr>td, .table>tbody>tr>th{
            padding-bottom:20px;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtunit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtproker" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtpetugas" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtvendor" runat="server" CssClass="hidden"></asp:TextBox>

    <asp:TextBox ID="txtcount" CssClass="hidden" runat="server"></asp:TextBox>
    <div class="row">
    <section class="col-lg-12 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Data Vendor</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="box box-comment">
                        <div class="box-header" style="text-align:center">
                            <span style="font-weight:bold; font-size:16px">Detail Vendor</span>
                        </div>
                        <div class="box-body">
                            <div class="table-responsive">
                                <table class="table" style="border:none">
                                    <tbody>
                                          <tr>
                                              <th>Nama Perusahaan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnp" runat="server" Text="Wildan Ger saputra" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Jenis Perusahaan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbljp" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>No. Telepon</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnote" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Email</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblemail" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>NPWP</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnpwp" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nama Bank</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnambank" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                         <tr>
                                              <th>No. Rekening</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnorek" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>PIC Perusahaan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblpic" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                        </tbody>
                                    </table>
                                    
                            </div>
                                
                        </div>

                    </div>
                </div>

                                <div class="col-md-6 col-lg-6">
                    <div class="box box-comment">
                        <div class="box-header" style="text-align:center">
                            <span style="font-weight:bold; font-size:16px">PIC Vendor</span>
                        </div>
                        <div class="box-body">
                           
                            <div class="table-responsive">
                                <table class="table" style="border:none">
                                        <tbody>
                                            <tr>
                                              <th>Nomor Telepon PIC</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblotpic" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Email PIC</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblemailpic" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nama Bank</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnbpic" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>No Rekening</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnrpic" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                        </tbody>
                                </table>
                            </div>

                        </div>

                    </div>
                </div>

            </div>
            
            
        </div>
    </div>
    </section>
    </div>
</asp:Content>
