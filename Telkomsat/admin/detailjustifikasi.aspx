<%@ Page Title="Detail Justifikasi" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="detailjustifikasi.aspx.cs" Inherits="Telkomsat.admin.detailjustifikasi" %>
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

        .rows{
            padding:7px;
        }

        .mylabel{
            white-space:pre-line;
        }

        .myImg {
          border-radius: 5px;
          cursor: pointer;
          transition: 0.3s;
        }

        .modal1 {
          display: none; /* Hidden by default */
          position: fixed; /* Stay in place */
          z-index: 1; /* Sit on top */
          padding-top: 100px; /* Location of the box */
          left: 0;
          top: 0;
          width: 100%; /* Full width */
          height: 100%; /* Full height */
          overflow: auto; /* Enable scroll if needed */
          background-color: rgb(0,0,0); /* Fallback color */
          background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modal-content1 {
          margin: auto;
          display: block;
          width: 80%;
          max-width: 700px;
        }

        
        /* Add Animation */
        .modal-content1, #caption {  
          -webkit-animation-name: zoom;
          -webkit-animation-duration: 0.6s;
          animation-name: zoom;
          animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
          from {-webkit-transform:scale(0)} 
          to {-webkit-transform:scale(1)}
        }

        @keyframes zoom {
          from {transform:scale(0)} 
          to {transform:scale(1)}
        }

        /* The Close Button */
        .close1 {
            position: absolute;
            top: 65px;
            right: 45px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .close1:hover,
            .close1:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        /* 100% Image Width on Smaller Screens */
        @media only screen and (max-width: 700px) {
            .modal-content1 {
                width: 100%;
            }
        }

        .myImg:hover {opacity: 0.7;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtunit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtproker" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtpetugas" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtvendor" runat="server" CssClass="hidden"></asp:TextBox>

    <asp:TextBox ID="txtcount" CssClass="hidden" runat="server"></asp:TextBox>
    <div class="modal modal1" id="myModal">
          <span class="close close1">&times;</span>
            <img class="modal-content modal-content1" id="img01" src=""/>
          <div id="caption"></div>
    </div>

    <div class="row">
    <section class="col-lg-12 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Perimtaan Dana</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            <div class="row">
                <div class="col-md-5 col-lg-5">
                    <div class="box box-comment">
                        <div class="box-header" style="text-align:center">
                            <span style="font-weight:bold; font-size:16px">Permintaan Dana</span>
                        </div>
                        <div class="box-body">
                            <div class="table-responsive">
                                <table class="table" style="border:none">
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
                                              <td><asp:Label ID="lbldetail" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                    </tbody>
                          
                                </table>
                            </div>

                        </div>
                        <div class="box-footer">
                            <asp:Button ID="Button1" CssClass="btn btn-warning btn-sm" runat="server" Text="Edit" OnClick="Edit_Click" />
                        </div>

                    </div>
                </div>
                
                <div class="col-md-7">
                    <div class="box box-comment">
                        <div class="box-header" style="text-align:center">
                            <span style="font-weight:bold; font-size:16px">Status Verifikasi</span>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-7 col-xs-6" style="margin-bottom:20px">
                                    <span>Verifikasi</span><br />
                                    <span>GM/VP</span><br /><br />
                                    <asp:Label ID="lblgm" runat="server" Text="-" Font-Bold="True" Font-Size="22px"></asp:Label><br />
                                    <asp:Label ID="lblnamagm" runat="server" Text="-" Font-Bold="True" Font-Size="14px"></asp:Label>
                                </div>
                                <div class="col-md-4 col-xs-6" style="margin-bottom:20px">
                                    <span>Verifikasi</span><br />
                                    <span>Bendahara Unit</span><br /><br />
                                    <asp:Label ID="lblbendahara" runat="server" Text="-" Font-Bold="True" Font-Size="22px"></asp:Label><br />
                                    <asp:Label ID="lblnamaadmin" runat="server" Text="-" Font-Bold="True" Font-Size="14px"></asp:Label>
                                </div>
                                </div>
                            
                        </div>
                </div>
                    <h4 runat="server" id="hlampiran" style="font-weight:bold">Lampiran-lampiran</h4>
                    <br />
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <br />
            <asp:GridView ID="DataList3a" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
                BorderColor="White" BorderStyle="None" BorderWidth="0px" Visible="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="File">
                        <ItemTemplate>
                            <span class="fa fa-check" style="width:20px"></span>
                            <asp:LinkButton ID ="InkView" runat ="server" CssClass="rows" CommandArgument='<%# Eval("AE_NamaFile") %>' CommandName="Download" Text='<%# Eval("AE_NamaFile") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField ="AE_Caption" HeaderText="Deskripsi" ItemStyle-Width="200px" ItemStyle-CssClass="rows"/>
                    </Columns>
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            </asp:GridView>
            </div>
            
            
        </div>
    </div>
    </section>
    </div>
    <script>
        var modal = document.getElementById("myModal");
        var img = document.getElementsByClassName("myImg");
        var modalImg = document.getElementById("img01");
        var i;
        for (i = 0; i < img.length; i++) {
            img[i].onclick = function(){
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
            }
        }

        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function() { 
          modal.style.display = "none";
        }
    </script>
</asp:Content>
