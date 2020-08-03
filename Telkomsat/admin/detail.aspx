<%@ Page Title="Admin Detail" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Telkomsat.admin.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
<section class="col-lg-6 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Detail</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
        <div class="form-group">
            <label for="exampleInputEmail1" style="width:120px;">Keterangan</label>
            <asp:Label ID="Label2" runat="server">: </asp:Label>
            <asp:Label ID="lblKeterangan" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1" style="width:120px;">Nominal</label>
            <asp:Label ID="Label6" runat="server">: </asp:Label>
            <asp:Label ID="lblNominal" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1" style="width:120px;">Kategori</label>
            <asp:Label ID="Label3" runat="server">: </asp:Label>
            <asp:Label ID="lblKategori" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1" style="width:120px;">Detail</label>
            <asp:Label ID="Label4" runat="server">: </asp:Label>
            <asp:Label ID="lbldetail" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputFile" style="width:120px;">File input</label>
            <asp:Label ID="Label5" runat="server">: </asp:Label>
            <asp:LinkButton ID="lbupload" runat="server" OnClick="lbupload_Click">LinkButton</asp:LinkButton>
        </div>
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
        <button type="submit" class="btn btn-primary" runat="server" >Submit</button>
        </div>
    </div>
    </section>
<section class="col-lg-6 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Table Detail</h3>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <div class="box-body" style="min-height:200px;">
        <div class="table-responsive">
            <asp:placeholder runat="server" id="PlaceHolderDetail"></asp:placeholder>
                                <table class="table" style="border:none" runat="server" id="tbljustifikasi">
                                    <tbody>
                                          <tr>
                                              <th>Jenis UPD</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbljupd" runat="server" Text="Wildan Ger saputra" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nomor Justifikasi</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnojus" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Subdit</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblsubdit" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Jabatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbljabatan" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                         <tr>
                                              <th>No. Akun Anggaran</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnaa" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Tanggal</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltgl" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Tanggal Dokumen Diserahkan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltglds" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Pemberi Tugas</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lbltglpt" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Jenis Anggaran</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblja" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Program Kerja</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblpk" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nilai RKAP</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnrkap" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Nama Kegiatan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnk" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          
                                          <tr>
                                              <th>Nilai</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblnilai" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Keterangan</th>
                                              <td>:</td>
                                              <td><asp:Label ID="lblket" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <th>Detail</th>
                                              <td>:</td>
                                              <td><asp:Label ID="Label7" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                    </tbody>
                          
                                </table>
                            </div>
    </div>
    </div>
</section>
</div>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
</asp:Content>
