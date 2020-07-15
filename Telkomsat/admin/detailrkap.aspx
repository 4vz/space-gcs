<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="detailrkap.aspx.cs" Inherits="Telkomsat.admin.detailrkap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td{
            border-top:0px;
        }

        th{
            font-size:14px;
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
                                              <th>Nama Aktivitas</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblna" runat="server" Text="Wildan Ger saputra" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Sub Unit</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblsu" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Bagian</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblbg" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Cost Center</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblcc" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>No. Akun</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnoa" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nama Akun</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnamaakun" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                         <tr>
                                              <th>Satuan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblsatuan" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Harga</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblharga" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                        <tr>
                                              <th>Volume dalam 1 Tahun</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltahun" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                        <tr>
                                              <th>Grand Total</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblgt" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
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
                                <asp:placeholder runat="server" id="PlaceHolder1"></asp:placeholder>
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
