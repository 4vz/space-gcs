<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="penyetoran.aspx.cs" Inherits="Telkomsat.admin.penyetoran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <label style="padding-right:10px">Incomplete </label>
                        <span class="label label-danger">  </span>
                    </div>
                    <div class="col-xs-6 text-center" style="border-right: 1px solid #f4f4f4">
                        <label style="padding-right:10px">Complete </label>
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
        <div id="divpengembalian" runat="server">
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
                <asp:DropDownList ID="ddlupload" runat="server" class="form-control" Width="120px" onchange="detail(this)">
                        <asp:ListItem>--Evidence--</asp:ListItem>
                        <asp:ListItem>Langsung</asp:ListItem>
                        <asp:ListItem>Manual</asp:ListItem>
            </asp:DropDownList>
            </div>
        </div>
        
        <div id="detaildiv" style="display:none">
        <button id="show" type="button" class="btn-xs btn-primary pull-right"><i class="fa fa-plus"></i></button> 
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th> Keterangan</th>
                        <th> Nilai</th>
                        <th> Bukti</th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="tr1">
                        <td>
                            <asp:TextBox ID="txtketerangan1" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal1" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td>
                            <div class="btn btn-default btn-file" id="btnfu1">
                              <i class="fa fa-paperclip"></i>
                               <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr id="tr2">
                        <td>
                            <asp:TextBox ID="txtketerangan2" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal2" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td>
                            <div class="btn btn-default btn-file" id="btnfu2">
                              <i class="fa fa-paperclip"></i>
                               <asp:FileUpload ID="FileUpload3" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr id="tr3">
                        <td>
                            <asp:TextBox ID="txtketerangan3" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal3" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td>
                            <div class="btn btn-default btn-file" id="btnfu3">
                              <i class="fa fa-paperclip"></i>
                               <asp:FileUpload ID="FileUpload4" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr id="tr4">
                        <td>
                            <asp:TextBox ID="txtketerangan4" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal4" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td>
                            <div class="btn btn-default btn-file" id="btnfu4">
                              <i class="fa fa-paperclip"></i>
                               <asp:FileUpload ID="FileUpload5" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr id="tr5">
                        <td>
                            <asp:TextBox ID="txtketerangan5" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal5" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td>
                            <div class="btn btn-default btn-file" id="btnfu5">
                              <i class="fa fa-paperclip"></i>
                               <asp:FileUpload ID="FileUpload6" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr id="tr6">
                        <td>
                            <asp:TextBox ID="txtketerangan6" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal6" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td><div class="btn btn-default btn-file" id="btnfu6">
                              <i class="fa fa-paperclip"></i>
                               <asp:FileUpload ID="FileUpload7" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr id="tr7">
                        <td>
                            <asp:TextBox ID="txtketerangan7" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal7" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td>
                            <div class="btn btn-default btn-file" id="btnfu7">
                              <i class="fa fa-paperclip"></i>
                               <asp:FileUpload ID="FileUpload8" runat="server" CssClass="table-str" />
                            </div>
                        </td>
                    </tr>
                </tbody>
                
            </table>
        </div>

        <div id="langsungdiv" style="display:none">
            <input type="text" class="form-control" id="nominal" runat="server" placeholder="Total Nominal" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
        </div>
        <br />
        <div id="btndiv" style="display:none">
            <button type="button" class="delete-row btn-danger">Delete Row</button>
            <button type="button" class="btn-info pull-right" runat="server" onserverclick="Save_ServerClick">Save</button>
        </div>
    
    </div>
    </div>
    </div>

     <asp:HiddenField ID="hfnama" runat="server" Value="wildan " />
</section>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script type="text/javascript">
        function detail(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
            //alert(userinput);
            if (statuslogbook == "Manual") {
                document.getElementById('detaildiv').style.display = 'block';
                document.getElementById('langsungdiv').style.display = 'none';
                document.getElementById('btndiv').style.display = 'block';
            }
            else {
                document.getElementById('langsungdiv').style.display = 'block';
                document.getElementById('detaildiv').style.display = 'none';     
                document.getElementById('btndiv').style.display = 'block';
            }
        }
    </script>
    <script type="text/javascript">
    $('#' + '<%= FileUpload1.ClientID %>').change(function() {
        var fileName = $(this).val();

        if (fileName != '') {
            $("#btnfu1").css('background-color', 'cyan');
        } else {
            $("#btnfu1").css('color', 'red');
        }
        });
        $('#' + '<%= FileUpload3.ClientID %>').change(function() {
        var fileName = $(this).val();

        if (fileName != '') {
            $("#btnfu2").css('background-color', 'cyan');
        } else {
            $("#btnfu2").css('color', 'red');
        }
        });
        $('#' + '<%= FileUpload4.ClientID %>').change(function() {
        var fileName = $(this).val();

        if (fileName != '') {
            $("#btnfu3").css('background-color', 'cyan');
        } else {
            $("#btnfu3").css('color', 'red');
        }
        });
        $('#' + '<%= FileUpload5.ClientID %>').change(function() {
        var fileName = $(this).val();

        if (fileName != '') {
            $("#btnfu4").css('background-color', 'cyan');
        } else {
            $("#btnfu4").css('color', 'red');
        }
        });
        $('#' + '<%= FileUpload6.ClientID %>').change(function() {
        var fileName = $(this).val();

        if (fileName != '') {
            $("#btnfu5").css('background-color', 'cyan');
        } else {
            $("#btnfu5").css('color', 'red');
        }
        });
        $('#' + '<%= FileUpload7.ClientID %>').change(function() {
        var fileName = $(this).val();

        if (fileName != '') {
            $("#btnfu6").css('background-color', 'cyan');
        } else {
            $("#btnfu6").css('color', 'red');
        }
        });
        $('#' + '<%= FileUpload8.ClientID %>').change(function() {
        var fileName = $(this).val();

        if (fileName != '') {
            $("#btnfu7").css('background-color', 'cyan');
        } else {
            $("#btnfu7").css('color', 'red');
        }
        });
        var nilai = 0;
        var total = 0;
        $(document).ready(function () {
            $("#tr2").hide();
            $("#tr3").hide();
            $("#tr4").hide();
            $("#tr5").hide();
            $("#tr6").hide();
            $("#tr7").hide();
            var i = 0;
            $("#show").click(function () {
                i = i + 1;
                if (i == 1) {
                    $("#tr2").show(700);
                }
                if (i == 2) {
                    $("#tr3").show(700);
                }
                if (i == 3) {
                    $("#tr4").show(700);
                }
                if (i == 4) {
                    $("#tr5").show(700);
                }
                if (i == 5) {
                    $("#tr6").show(700);
                }
                if (i == 6) {
                    $("#tr7").show(700);
                    $("#show").attr("disabled", true);
                }

            });

            var panjar = $('#' + '<%= txtpengeluaran.ClientID%>').val();
            var nilai1 = $("#nilaidata").val().replace(/\./g, '');
            var panjar1 = panjar.replace(/\./g, '');
            nilai = (Number(nilai) + Number(nilai1));
            total = Number(panjar1) - nilai
            console.log(total);
            var txttotal = $('#' + '<%= txttotal1.ClientID%>').val(Number(total).toLocaleString('id'));
        });
</script>
</asp:Content>
