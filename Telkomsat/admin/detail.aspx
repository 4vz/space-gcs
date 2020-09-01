<%@ Page Title="Admin Detail" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Telkomsat.admin.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .myImg {
          border-radius: 5px;
          cursor: pointer;
          transition: 0.3s;
        }

        .rows{
            padding:7px;
        }

        .myImg:hover {opacity: 0.7;}

        /* The Modal (background) */
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal modal1" id="myModal">
          <span class="close close1">&times;</span>
            <img class="modal-content modal-content1" id="img01" src=""/>
          <div id="caption"></div>
    </div>

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
            <label for="exampleInputPassword1" style="width:120px;">Vendor</label>
            <asp:Label ID="Label8" runat="server">: </asp:Label>
            <asp:Label ID="lblvendor" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1" style="width:120px;">Detail</label>
            <asp:Label ID="Label4" runat="server">: </asp:Label>
            <asp:Label ID="lbldetail" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label for="exampleInputFile" style="width:120px;">File input</label>
            <asp:Label ID="Label5" runat="server">: </asp:Label>
        </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
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
            <br />
            
        </div>
    </div>
    </section>
<section class="col-lg-6 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Table Justifikasi</h3>
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
                                              <td><asp:Label ID="lbldetailjus" runat="server" Text="" CssClass="mylabel"></asp:Label></td>
                                          </tr>
                                    </tbody>
                          
                                </table>
                            </div>
    </div>
    </div>
</section>
            <div class="col-sm-12" runat="server" id="div1">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Pertanggungan</h3>
                    </div>
                    <div class="box-body">
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                        <asp:Label ID="lblpertanggungan" runat="server" Text="Belum ada pertanggungan" Visible="false"></asp:Label>
                            </div>
                    </div>
                   
                </div>


            <div class="col-sm-12" runat="server" id="divpertanggungan" visible="false">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Tambah Pertanggungan</h3>
                    </div>
                    <div class="box-body">
                        <div id="dvfiles">
                                    <table class="table table-bordered kita" id="tableku" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Tanggal</th>
                                                <th>Keterangan</th>
                                                <th>Jumlah Item</th>
                                                <th>Harga Satuan</th>
                                                <th>Evidence</th>
                                                <th>#</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                                <button id="addfile" type="button" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> <br />
                            </div>
                    </div>
                    <div class="box-footer">
                        <asp:Button ID="Button1" CssClass="btn btn-primary" OnClick="Pertanggungan_Click" runat="server" Text="Submit" />
                    </div>
                </div>
                
        </div>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script>
        var i = 0;
        $(document).ready(function () {
            $("#addfile").click(function () {
                var markup = "<tr><td><input type='text' name='intanggal' class='form-control datepicker' /></td>" +
                    "<td><input type='text' name='inketerangan' class='form-control' /></td>" +
                    "<td><input type='number' name='inpcs' class='form-control' /></td>" +
                    "<td><input type='number' name='inharga' class='form-control' /></td>" +
                    "<td><input name=" + i + "fu type=file /></td>" +
                    "<td> <button type='button' name='record' onclick='newtest2(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>";
                $('#' + '<%= tableku.ClientID%>').append(markup);
                i++;
                console.log('add');
            });
            
            $(document).on('click', '.datepicker', function () {
                $(".datepicker").datepicker({
                    format: 'yyyy/mm/dd', autoclose: true
                });
                console.log("mimi");
            });

        });

        function newtest2(e) {              //Add e as parameter
            $(e).parents('tr').remove();   //Use the e to delete
        }
       

            //console.log('klkl');

        var modal = document.getElementById("myModal");
        var img = document.getElementsByClassName("myImg");
        var btnimg = document.getElementsByClassName("btnimg");
        var modalImg = document.getElementById("img01");
        var i;
        for (i = 0; i < img.length; i++) {
            img[i].onclick = function(){
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
            }
        }

        var j;
        for (j = 0; j < btnimg.length; j++) {
            btnimg[j].onclick = function () {
                modal.style.display = "block";
                modalImg.src = this.value;
                console.log(this.value);
            }
        }

        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function() { 
          modal.style.display = "none";
        }
    </script>
</asp:Content>
