<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="detailrkap2.aspx.cs" Inherits="Telkomsat.admin.detailrkap2" %>
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
        <h3 class="box-title">Data RKAP</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="box box-comment">
                        <div class="box-header" style="text-align:center">
                            <span style="font-weight:bold; font-size:16px">Detail RKAP</span>
                        </div>
                        <div class="box-body">
                            <div class="table-responsive">
                                <table class="table" style="border:none">
                                    <tbody>
                                         <tr>
                                              <th>Kategori RKAP</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblkategori" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
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
                                              <th>Jenis Anggaran</th>
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
                                        <tr>
                                              <th>Sisa Grand Total</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblsisagt" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
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
                            <span style="font-weight:bold; font-size:16px">RKAP Per Bulan</span>
                        </div>
                        <div class="box-body">
                           
                            <div class="table-responsive">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>Bulan</th>
                                            <th>Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="padding-bottom:10px;">Januari</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="voljan" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Februari</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volfeb" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Maret</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volmar" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">April</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volapr" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Mei</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volmei" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Juni</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="voljuni" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Juli</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="voljuli" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Agustus</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volagu" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">September</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volsep" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Oktober</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volokt" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">November</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="volnov" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom:10px;">Desember</td>
                                            <td style="padding-bottom:10px;"><asp:Label runat="server" Id="voldes" CssClass="tdvolume"></asp:Label></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <asp:Label ID="lblcarry" runat="server" Text="Tidak ada carry over"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="box box-primary">
        <div class="box-header with-border">
            <h3 class="box-title">Justifikasi</h3>
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
        </div>
        <!-- /.box-header -->
        <!-- form start -->
            <div class="box-body">
                <div class="row">
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </section>
    </div>
</asp:Content>
