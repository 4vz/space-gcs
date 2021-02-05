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
            <label for="exampleInputEmail1" style="width:120px;">Nama</label>
            <asp:Label ID="Label7" runat="server">: </asp:Label>
            <asp:Label ID="lblpetugas" runat="server" Text="Label"></asp:Label>
        </div>
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
            <label for="exampleInputFile" style="width:120px;">File</label>
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
                    <asp:BoundField DataField ="AE_Caption" HeaderText="" ItemStyle-Width="200px" ItemStyle-CssClass="rows"/>
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
                        <asp:Button ID="btnacc" runat="server" Text="Setujui" CssClass="btn btn-primary pull-right" OnClick="Setujui_Click" Visible="false" OnClientClick="return confirm('Apakah anda yakin?');" />
                        <button type="button" id="btnsubmit2" class="btn btn-primary pull-right" style="margin:10px" runat="server" visible="false">Submit</button>
                        <button type="button" id="btnid" class="btn btn-success pull-right" style="margin:10px" runat="server" visible="false">Accept</button>
                        <button type="button" id="btnreject" class="btn btn-danger pull-right" style="margin:10px" runat="server" visible="false" data-toggle="modal" data-target="#modalreject">Reject</button>

                    </div>
                    <div class="box-body">
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                        <asp:Label ID="lblpertanggungan" runat="server" Text="Belum ada pertanggungan" Visible="false"></asp:Label>
                            </div>
                    </div>
                   
                </div>
        <div class="modal fade" id="modalreject">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Approve</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Alasan :</label>
                            <asp:TextBox ID="txtalasanup" autocomplete="off" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                        </div>
                      </div> 
                  </div>
                  
              </div>
              <div class="modal-footer">
                <button type="button" id="btnrjk" class="btn btn-info pull-left" runat="server" >Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
        </div>

        <div class="modal fade" id="modaledit">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">Approve</h3>
              </div>
              <div class="modal-body">
                  <div class="row">
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Tanggal :</label>
                            <asp:TextBox ID="txtedittgl" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Keterangan :</label>
                            <asp:TextBox ID="txteditket" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Jumlah Item :</label>
                            <asp:TextBox ID="txteditji" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Harga Satuan :</label>
                            <asp:TextBox ID="txtediths" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                      </div> 
                      <div class="col-md-12">
                          <div class="form-group">
                            <label style="font-size:16px; font-weight:bold">Evidence :</label>
                              <asp:FileUpload ID="FileUploadedit" runat="server" />
                        </div>
                      </div> 
                  </div>
              </div>
              <div class="modal-footer">
                <button type="button" id="Button4" class="btn btn-info pull-left" onserverclick="Edit_Click" runat="server" >Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
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
    <button type="button" id="Button2" class="btn btn-success pull-left hidden" runat="server" onserverclick="Submit_Click" >Save</button>
    <button type="button" id="Button3" class="btn btn-success pull-left hidden" runat="server" onserverclick="Pertanggungan2_Click">Save</button>
    <button type="button" id="Button5" class="btn btn-success pull-left hidden" runat="server" onserverclick="Pertanggunganreject_Click">Save</button>
    <asp:TextBox ID="txtidpertanggungan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtid" runat="server" CssClass="hidden"></asp:TextBox>
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        var i = 0;
        $(document).ready(function () {
            $("#addfile").click(function () {
                var markup = "<tr><td><input type='text' name='intanggal' autocomplete='off' class='form-control datepicker dpe' /></td>" +
                    "<td><input type='text' name='inketerangan' class='form-control ket' /></td>" +
                    "<td><input type='number' name='inpcs' class='form-control' /></td>" +
                    "<td><input type='text' name='inharga' onkeydown='return numbersonly(this, event);' onkeyup='javascript: tandaPemisahTitik(this);' class='form-control' /></td>" +
                    "<td><input name=" + i + "fu type=file /></td>" +
                    "<td> <button type='button' name='record' onclick='newtest2(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>";
                $('#' + '<%= tableku.ClientID%>').append(markup);
                i++;
                console.log('add');
            });
            
            $(document).on('click', '.datepicker', function () {
                $(".datepicker").datepicker({
                    format: 'yyyy/mm/dd', autoclose: true
                }).focus();
                $(this).removeClass('datepicker');
                console.log("mimi");
            });

            $('#<%=btnsubmit2.ClientID %>').click(function () {
                var favorite = [];
                $.each($("input[name='getid']:checked"), function () {
                    favorite.push($(this).val());
                });
                //alert("My favourite sports are: " + favorite.join(","));
                var id = favorite.join(",");
                $('#<%=txtidpertanggungan.ClientID %>').val(id);
                if (id != "") {
                    $('#<%=Button2.ClientID %>').trigger("click");
                }
                else {
                    alert('harap check pertanggungan untuk di submit');
                }
            });
            $('#<%=btnid.ClientID %>').click(function () {
                var favorite = [];
                $.each($("input[name='getid']:checked"), function () {
                    favorite.push($(this).val());
                });
                //alert("My favourite sports are: " + favorite.join(","));
                var id = favorite.join(",");
                console.log(id);
                $('#<%=txtidpertanggungan.ClientID %>').val(id);
                if (id != "") {
                    $('#<%=Button3.ClientID %>').trigger("click");
                }
                else {
                    alert('harap check pertanggungan untuk di accept');
                }
                
            });
            $('#<%=btnrjk.ClientID %>').click(function () {
                var favorite = [];
                $.each($("input[name='getid']:checked"), function () {
                    favorite.push($(this).val());
                });
                //alert("My favourite sports are: " + favorite.join(","));
                var id = favorite.join(",");
                $('#<%=txtidpertanggungan.ClientID %>').val(id);
                if (id != "") {
                    $('#<%=Button5.ClientID %>').trigger("click");
                }
                else {
                    alert('harap check pertanggungan untuk di reject');
                }
                //$('#<p%=Button3.ClientID %>').trigger("click");
            });
        });

        $('.datawil').click(function () {
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "detail.aspx/GetReferensi",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        console.log(this.edittanggal);
                        $('#<%=txtid.ClientID %>').val(this.dataid);
                        $('#<%=txtedittgl.ClientID %>').val(this.edittanggal);
                        $('#<%=txteditket.ClientID %>').val(this.editketerangan);
                        $('#<%=txteditji.ClientID %>').val(this.editji);
                        $('#<%=txtediths.ClientID %>').val(this.ediths);
                    });
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });


        function toggle(source) {
            var checkboxes = document.querySelectorAll('input[type="checkbox"]');
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] != source) {
                    if (!checkboxes[i].disabled)
                        checkboxes[i].checked = source.checked;
                }
                    
            }
        }

        function confirmselesai() {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data tidak bisa diubah lagi',
                buttons: true,
                icon: "info",

            }).then((willDelete) => {
                if (willDelete) {
                    return true;
                }
            });
        }


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
