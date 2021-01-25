<%@ Page Title="Tambah Justifikasi" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="justifikasi.aspx.cs" Inherits="Telkomsat.admin.justifikasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <link rel="stylesheet" href="../assets/bower_components/select2/dist/css/select2.min.css"/>
    <style>
        .rbl input[type="radio"]
        {
           margin-left: 10px;
           margin-right: 1px;
        }
        .select2-container--default .select2-results>.select2-results__options{
           max-height:400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtunit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtproker" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtprogram" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtpetugas" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtvendor" runat="server" CssClass="hidden"></asp:TextBox>

    <asp:TextBox ID="txtcount" CssClass="hidden" runat="server"></asp:TextBox>
    <div class="row">
    <section class="col-lg-12 connectedSortable">
    <div class="box box-primary">
     <asp:Panel ID="UserPanel" runat="server" DefaultButton="btnsubmit">
    <div class="box-header with-border">
        <h3 class="box-title">Tambah Justifikasi</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
            <div class="row">
                <div class="alert alert-danger alert-dismissable" id="divfail" runat="server" visible="false">
                    <h5><span class="fa fa-ban"> Nilai Justifikasi tidak boleh lebih dari nilai RKAP</span></h5>
                </div>
            </div>
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Jenis Usulan Permintaan Dana</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="rdjupd"></asp:RequiredFieldValidator>
                         <asp:RadioButtonList ID="rdjupd" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                             <asp:ListItem>Panjar</asp:ListItem>
                             <asp:ListItem>Opex</asp:ListItem>
                             <asp:ListItem>Capex</asp:ListItem>
                         </asp:RadioButtonList>
                    </div>
                 </div>
            </div>

            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Nomor Surat</label>
                         <input type="text" class="form-control" id="txtsurat" runat="server"/>
                    </div>
                 </div>
            </div>  
            <div class="row">
                 <div class="col-md-2">
                     <div class="form-group">
                        <label for="exampleInputPassword1">RKAP Bulan </label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="sobulan" InitialValue="Tahun"></asp:RequiredFieldValidator>
                        <select id="sobulan" runat="server" class="form-control" style="width: 100%;">
                            <option value="Tahun">-</option>
                            <option>Januari</option> 
                            <option>Februari</option> 
                            <option>Maret</option> 
                            <option>April</option> 
                            <option>Mei</option> 
                            <option>Juni</option> 
                            <option>Juli</option> 
                            <option>Agustus</option> 
                            <option>September</option> 
                            <option>Oktober</option> 
                            <option>November</option> 
                            <option>Desember</option>
                        </select>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-3">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Jenis Anggaran</label>
                        <select id="sonamaakun" runat="server" class="form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Program Kerja Utama</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="soproker" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="soproker" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>    
             <div class="row">
                 <div class="col-md-3">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nilai Sisa RKAP</label>
                        <input type="text" class="form-control" id="txtnilairkap" runat="server" readonly/>
                        <button id="addproker" type="button" style="margin-top:10px" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> 
                    </div>
                 </div>
               </div>

            <div class="row" style="display:none" id="divja">
                 <div class="col-md-3" style="margin-left:35px">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Jenis Anggaran</label>
                        <select id="soja2" runat="server" class="form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>
            <div class="row" style="display:none" id="divfilter">
                 <div class="col-md-3" style="margin-left:35px">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Range Sisa RKAP </label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="sobulan" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="sorange" runat="server" class="form-control" style="width: 100%;">
                            <option></option>
                            <option value="1">0 - 10.0000.000</option> 
                            <option value="2">10.000.000 - 50.000.000</option> 
                            <option value="3">50.000.000 - 100.000.000</option> 
                            <option value="4">> 100.000.000</option> 
                        </select>
                    </div>
                 </div>
               </div>   
            <div class="row" style="display:none" id="divproker">
                 <div class="col-md-4" style="margin-left:35px">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Program Kerja Kedua</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="soproker" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="soprogram" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>    
            <div class="row" style="display:none" id="divnilai">
                 <div class="col-md-3" style="margin-left:35px">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nilai Sisa RKAP</label>
                        <input type="text" class="form-control" id="txtnilai2" runat="server" readonly/>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-5">
                     <div class="form-group">
                        <label for="exampleInputEmail1">Nama Kegiatan</label>
                         <input type="text" class="form-control" id="txtnamaket" runat="server"/>
                    </div>
                 </div>
                
            </div>
            
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nilai</label>
                         <asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="TextBox1" controltocompare="txtc" ForeColor="Red" operator="LessThan" type="Integer" errormessage="Tidak boleh lebih dari nilai RKAP " />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="txtnilai"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control nilaitext" id="txtnilai" runat="server" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-6">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Keterangan</label>
                        <input type="text" class="form-control" id="txtket" runat="server"/>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-6">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Detail</label>
                        <asp:TextBox ID="txtdetail" runat="server" TextMode="MultiLine" CssClass="form-control" Height="120px"></asp:TextBox>
                    </div>
                 </div>
               </div>
            <div class="row">
                 <div class="col-md-6">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Evidence</label>
                        <div id="dvfiles">
                                <table class="table table-bordered kita" id="tableku" runat="server">
                                    <thead>
                                        <tr>
                                            <th>File</th>
                                            <th>Caption</th>
                                            <th>#</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                         <button id="addfile" type="button" class="btn-sm btn-default"><i class="fa fa-plus"></i></button> 
                    </div>
                 </div>
                </div>
            <div class="row">
                 <div class="col-md-2">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Tanggal Dokumen Diserahkan</label>
                        <input type="text" class="form-control" id="txttglpsm" runat="server" autocomplete="off"/>
                    </div>
                 </div>
               </div>  
            <div class="row">
                 <div class="col-md-4">
                     <div class="form-group">
                        <label for="exampleInputPassword1">Pemberi Tugas</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Wajib diisi" ForeColor="Red" ControlToValidate="sotugas" InitialValue=""></asp:RequiredFieldValidator>
                        <select id="sotugas" runat="server" class="form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                 </div>
               </div>       
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
            <asp:Button ID="btnsubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="Submit_ServerClick" />
            <button id="btndraft" class="btn btn-warning" runat="server" style="margin-left:10px" onserverclick="Unnamed_ServerClick" visible="false">Draft</button>
        </div>
        </asp:Panel>
    </div>
    </section>
</div>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtflag" runat="server" CssClass="hidden" Text="0"></asp:TextBox>
    <asp:TextBox ID="txtproker2" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txta" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtb" runat="server" Text="0" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtc" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="TextBox5" runat="server" CssClass="hidden"></asp:TextBox>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        var j = 0;
        var rowCount = 0;

        $(document).ready(function () {

            //iterate through each textboxes and add keyup
            //handler to trigger sum event
            $(".nilaitext").each(function () {

                $(this).keyup(function () {
                    calculateSum();
                    //alert('ss');
                });
            });

        });

        function calculateSum() {

            //.toFixed() method will roundoff the final sum to 2 decimal places
            var total = $('#<%=txtnilai.ClientID%>').val().replace(/\./g, '');
            var gt = $('#<%=txtnilairkap.ClientID%>').val().replace(/\./g, '');
            $('#<%=TextBox1.ClientID%>').val(total);
            $('#<%=TextBox2.ClientID%>').val(gt);
        }

        var idbulan = 'Tahun', idja = '', idrange, idja2, flag = '0';


        $(function () {
            /*$.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetUnit",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#*%=soja.ClientID %/*').empty();
                    $('#*%=soja.ClientID %>/*').append('<option></option>');
                    $(customers).each(function () {
                        $('#*%=soja.ClientID %>/*').append($('<option>',
                            {
                                value: this.unit,
                                text: this.unit,
                            }));
                    });
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });*/

            $('#<%=sonamaakun.ClientID %>').change(function () {
                $('#<%=txtunit.ClientID %>').val($(this).val())
            });

            $.ajax({
                type: "POST",
                url: "tambahrkap.aspx/GetNamaAkun",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=soja2.ClientID %>').empty();
                    $('#<%=soja2.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=soja2.ClientID %>').append($('<option>',
                            {
                                value: this.namaakun,
                                text: this.namaakun,
                            }));
                    });
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });

            $('#<%=soja2.ClientID %>').change(function () {
                idja2 = $(this).val();
                $('#<%=soprogram.ClientID %>').empty();
                $.ajax({
                    type: "POST",
                    url: "justifikasi.aspx/GetJA2",
                    contentType: "application/json; charset=utf-8",
                    data: '{videoid:"' + idrange + '", idrange:"' + idrange + '"}',
                    dataType: "json",
                    success: function (response) {
                        var customers = response.d;
                        $('#<%=soprogram.ClientID %>').empty();
                        $('#<%=soprogram.ClientID %>').append('<option></option>');
                        $(customers).each(function () {
                            console.log(this.idbangunan);
                            $('#<%=soprogram.ClientID %>').append($('<option>',
                                {
                                    value: this.idprokersub,
                                    text: this.prokersub,
                                }));
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

            $('#<%=sorange.ClientID %>').change(function () {
                idrange = $(this).val();
                $('#<%=soprogram.ClientID %>').empty();
                $.ajax({
                    type: "POST",
                    url: "justifikasi.aspx/GetJA2",
                    contentType: "application/json; charset=utf-8",
                    data: '{videoid:"' + idja2 + '", idrange:"' + idrange + '"}',
                    dataType: "json",
                    success: function (response) {
                        var customers = response.d;
                        $('#<%=soprogram.ClientID %>').empty();
                        $('#<%=soprogram.ClientID %>').append('<option></option>');
                        $(customers).each(function () {
                            console.log(this.idbangunan);
                            $('#<%=soprogram.ClientID %>').append($('<option>',
                                {
                                    value: this.idprokersub,
                                    text: this.prokersub,
                                }));
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


            $('#<%=sobulan.ClientID %>').change(function () {
                idbulan = $(this).val();
                $('#<%=soproker.ClientID %>').empty();
                $.ajax({
                    type: "POST",
                    url: "justifikasi.aspx/GetJenisAnggaran",
                    contentType: "application/json; charset=utf-8",
                    data: '{videoid:"' + idja + '", idbulan:"' + idbulan + '"}',
                    dataType: "json",
                    success: function (response) {
                        var customers = response.d;
                        $('#<%=soproker.ClientID %>').empty();
                        $('#<%=soproker.ClientID %>').append('<option></option>');
                        $(customers).each(function () {
                            console.log(this.idbangunan);
                            $('#<%=soproker.ClientID %>').append($('<option>',
                                {
                                    value: this.idproker2,
                                    text: this.proker2,
                                }));
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

            $.ajax({
                type: "POST",
                url: "tambahrkap.aspx/GetNamaAkun",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sonamaakun.ClientID %>').empty();
                    $('#<%=sonamaakun.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sonamaakun.ClientID %>').append($('<option>',
                            {
                                value: this.namaakun,
                                text: this.namaakun,
                            }));
                    });
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
                        
         
            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetPIC",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sotugas.ClientID %>').empty();
                    $('#<%=sotugas.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.idbangunan);
                        $('#<%=sotugas.ClientID %>').append($('<option>',
                            {
                                value: this.idpic,
                                text: this.pic,
                            }));
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

        $('#<%=soprogram.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtprogram.ClientID%>').val(id);
            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetProkerHarga",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $(customers).each(function () {
                        $('#<%=txtnilai2.ClientID%>').val(format(this.gt));
                        $('#<%=txtb.ClientID%>').val(this.gt);
                        $('#<%=txtc.ClientID%>').val(parseInt($('#<%=txta.ClientID%>').val()) + parseInt($('#<%=txtb.ClientID%>').val()));
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
            
        $('#<%=soproker.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtproker.ClientID%>').val(id);
            console.log('itu ' + id); 
            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetProkerHarga",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $(customers).each(function () {
                        $('#<%=txtnilairkap.ClientID%>').val(format(this.gt));
                        $('#<%=txta.ClientID%>').val(this.gt);
                        $('#<%=txtc.ClientID%>').val(parseInt($('#<%=txta.ClientID%>').val()) + parseInt($('#<%=txtb.ClientID%>').val()));

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
        $('.select2').select2();

        $('#<%=sonamaakun.ClientID%>').change(function () {
            idja = $(this).val();
            $('#<%=txtproker.ClientID%>').val(idja);
            console.log('ini' + idbulan); 
            $.ajax({
                type: "POST",
                url: "justifikasi.aspx/GetJenisAnggaran",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + idja + '", idbulan:"' + idbulan + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=soproker.ClientID %>').empty();
                    $('#<%=soproker.ClientID %>').append('<option></option>');
                        $(customers).each(function () {
                            console.log(this.idbangunan);
                            $('#<%=soproker.ClientID %>').append($('<option>',
                                {
                                    value: this.idproker2,
                                    text: this.proker2,
                                }));
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


        $('#<%=sotugas.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtpetugas.ClientID%>').val(id);
        });

        
        var i = 0;

        $(document).ready(function() {
            $("#addfile").click(function () {
                var markup = "<tr><td><input name=" + i + "fu type=file /></td><td><input type='text' name='caption' class='form-control' /></td>" +
                    "<td> <button type='button' name='record' onclick='newtest2(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>";
                $('#' + '<%= tableku.ClientID%>').append(markup);
                i++;
                console.log('add');
            });
            var k = 0;
            $("#addproker").click(function () {
                if (k == 0) {
                    flag = '1';
                    $("#divproker").attr("style", "display:block");
                    $("#divfilter").attr("style", "display:block");
                    $("#divja").attr("style", "display:block");
                    $("#divnilai").attr("style", "display:block");
                    $('#<%=txtflag.ClientID%>').val(flag);
                    k = 1;
                }
                else {
                    flag = '0';
                    $("#divproker").attr("style", "display:none");
                    $("#divfilter").attr("style", "display:none");
                    $("#divja").attr("style", "display:none");
                    $("#divnilai").attr("style", "display:none");
                    $('#<%=txtproker2.ClientID%>').val('');
                    $('#<%=txtflag.ClientID%>').val(flag);
                    k = 0;
                }
                
            });
        });  

        function format(str) {
          var length = 3,
            separator = ".",
            count = 0,
            result = str.split('').reduceRight((a, c) => {
              if (count === length) {
                a.push(separator);
                count = 1;
              } else count++;
              a.push(c);
              return a;
            }, []).reverse().join('');
    
            return result;
        }


        function newtest2(e) {              //Add e as parameter
            $(e).parents('tr').remove();   //Use the e to delete
            //console.log('klkl');
        }

        $('#<%=txttglpsm.ClientID%>').datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd',
            orientation: "bottom"
        })
    </script>
</asp:Content>
