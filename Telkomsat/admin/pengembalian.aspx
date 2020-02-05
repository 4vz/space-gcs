<%@ Page Title="Input Pengembalian" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="pengembalian.aspx.cs" Inherits="Telkomsat.admin.pengembalian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" CssClass="hidden"></asp:TextBox>
<section class="col-lg-7 connectedSortable">
 <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">
                <li class="active"><a href="#revenue-chart" data-toggle="tab">tabel</a></li>
                <li class="pull-left header"><i class="fa fa-money"></i> Panjar</li>
            </ul>
            <div class="tab-content no-padding" style="min-height:300px;">
                <!-- Morris chart - Sales -->
                <div class="table-responsive mailbox-messages">
                    <div class="table table-responsive">
                        <asp:PlaceHolder ID="PlaceHolderpanjar" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.table -->
                </div>
            </div>
            <div class="box-footer no-border" style="padding:3px;">
                    <div class="row">
                    <div class="col-xs-6 text-center" style="border-right: 1px solid #f4f4f4">
                        <label style="padding-right:10px">Belum Melampirkan </label>
                        <span class="label label-danger">  </span>
                    </div>
                    <div class="col-xs-6 text-center" style="border-right: 1px solid #f4f4f4">
                        <label style="padding-right:10px">Sudah Beberapa </label>
                        <span class="label label-success">  </span>
                    </div>
                    </div>
                    <!-- /.row -->
                </div>
            </div>
</section>

<section class="col-lg-5 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Panjar</h3>
                <asp:Label Font-Size="X-Large" ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <div class="box-body" style="min-height:200px;">
        <div id="divpengembalian" runat="server" visible="false">
        <div class="form-group">
            <asp:Label ID="lblKeterangan" runat="server" Font-Bold="true" Text="Panjar Pak Budi"></asp:Label>
        </div>
        <div class="col-md-6" style="padding-left:0px">
            <div class="form-group">
                <label for="exampleInputEmail1">Total Panjar</label>
                <div class="input-group">
                    <span class="input-group-addon">Rp.</span>
                    <input type="text" class="form-control" id="txtpengeluaran" disabled="disabled" runat="server" placeholder="Nominal"/>
                </div>
            </div>
        </div>
        <div class="col-md-6" style="padding-right:0px">
            <div class="form-group">
                <label for="exampleInputEmail1">Sisa Panjar </label>
                <div class="input-group">
                    <span class="input-group-addon">Rp.</span>
                    <input type="text" class="form-control" id="txttotal1" disabled="disabled" runat="server" placeholder="Nominal"/>
                </div>
            </div>
        </div>
        <hr style="width:100%" />
        <div class="col-md-6" style="padding-left:0px">
            <div class="form-group">
                <input type="text" id="datainput" placeholder="Keterangan" class="form-control">
            </div>
        </div>
        <div class="col-md-6" style="padding-right:0px">
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon">Rp.</span><input type="text" id="nilaidata" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);" placeholder="Nominal" class="form-control">
                </div>
            </div>
        </div>
        
        <div class="col-md-12" style="padding-bottom:12px;">
            <button type="button" style="width:100%" class="btn btn-success add-row"  value="Add Row"><i class="fa fa-plus-circle"></i> Add Row
          </button>
        </div>
        <table class="table table-bordered kita" id="tableku" runat="server">
        <thead>
            <tr>
                <th>Select</th>
                <th>Keterangan</th>
                <th>Nominal</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <button type="button" class="delete-row btn-danger">Delete Row</button>
    <button type="button" class="btn-info pull-right" runat="server" onserverclick="Save_ServerClick">Save</button>
    </div>
    </div>
    </div>

     <asp:HiddenField ID="hfnama" runat="server" Value="wildan " />
</section>

    <div class="row" runat="server" id="divrinci" visible="false">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header">
                    Rincian Sebelumnya
                </div>
                <div class="box-body">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        $(document).ready(function () {
            var nilai = 0;
            var total = 0;
            var coba;
            var hfnama = $('#' + '<%= hfnama.ClientID%>').val();
            hfnama = '';
        $(".add-row").click(function(){
            var datainput = $("#datainput").val();
            var nilaidata = $("#nilaidata").val();
            
            var panjar = $('#' + '<%= txtpengeluaran.ClientID%>').val();
            

            hfnama = hfnama + datainput;
            console.log(hfnama);

            var nilai1 = $("#nilaidata").val().replace(/\./g, '');
            var panjar1 = panjar.replace(/\./g, '');
            nilai = (Number(nilai) + Number(nilai1));
            total = Number(panjar1) - nilai;
            console.log(total);
            $('#<%=TextBox1.ClientID%>').val(total);
            var txttotal = $('#' + '<%= txttotal1.ClientID%>').val(Number(total).toLocaleString('id'));
            var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + "<input type='text' readonly class='form-control' name='mypanjar' value='" + datainput + "' />" + "</td>" +
                "<td>" + "<input type='text' readonly class='form-control' name='mydatapanjar' value='" + nilaidata + "' />" + "</td>" +
                "<td>" + '<div class="btn btn-default btn-file">' + '<i class="fa fa-paperclip myi"></i>' + '<input type="file" class="fileku" name="fileinput"/>' + '</div>' + "</td>" + "</tr>";
           
            $('#' + '<%= tableku.ClientID%>').append(markup);
            $("#datainput").val('');
            $("#nilaidata").val('');
            });

            $(".myfiles").change(function () {
                $(".myi").css("color", "green");
                alert("bisa");
            });
        // Find and remove selected table rows
        $(".delete-row").click(function(){
            $("table tbody").find('input[name="record"]').each(function(){
            	if($(this).is(":checked")){
                    $(this).parents("tr").remove();
                    coba = $(this).closest("tr").find("td:eq(2)").text();
                    console.log(coba);
                }
                
            });
            var cobaku = coba.replace(/\./g, '');
            var panjar = $('#' + '<%= txtpengeluaran.ClientID%>').val();
            var panjar1 = panjar.replace(/\./g, '');
            nilai = nilai - Number(cobaku);
            total = Number(panjar1) - nilai
            var txttotal = $('#' + '<%= txttotal1.ClientID%>').val(Number(total).toLocaleString('id'));
        });
    });    
</script>
</asp:Content>
