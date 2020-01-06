<%@ Page Title="Input Pengeluaran" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="pengeluaran.aspx.cs" Inherits="Telkomsat.admin.pengeluaran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
<section class="col-lg-7 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Tambah Pengeluaran</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
        <div class="form-group">
            <label for="exampleInputEmail1">Keterangan</label>
            <input type="text" class="form-control" id="keterangan" runat="server" placeholder="Keterangan"/>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Nominal</label>
            <input type="text" class="form-control" id="nominal" runat="server" placeholder="Nominal" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"/>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Kategori</label>
            <asp:DropDownList ID="ddlKategori" CssClass="form-control" runat="server">
                <asp:ListItem>--Kategori--</asp:ListItem>
                <asp:ListItem>Rek. Harkat Bendahara 1</asp:ListItem>
                <asp:ListItem>Rek. Harkat Bendahara 2</asp:ListItem>
                <asp:ListItem>Rek. ME Bendahara 1</asp:ListItem>
                <asp:ListItem>Rek. ME Bendahara 2</asp:ListItem>
                <asp:ListItem>Brankas Harkat</asp:ListItem>
                <asp:ListItem>Brankas ME</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label for="exampleInputPassword1">Jenis</label>
            <asp:DropDownList ID="ddljenis" runat="server" class="form-control" Width="120px" onchange="status(this)">
                        <asp:ListItem>--jenis--</asp:ListItem>
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>Panjar</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group" id="user" style="display:none">
            <label for="exampleInputPassword1">User</label>
            <asp:DropDownList ID="ddluser" runat="server" class="form-control" Width="100%" onchange="status(this)">
                        <asp:ListItem>--user--</asp:ListItem>
                        <asp:ListItem Value="8">Budi</asp:ListItem>
                        <asp:ListItem Value="2">Rokhman</asp:ListItem>
                        <asp:ListItem Value="3">Aceng</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group" id="detaill" style="display:none">
            <label for="exampleInputPassword1">Detail</label>
            <asp:DropDownList ID="ddldetail" runat="server" class="form-control" Width="120px" onchange="detail(this)">
                        <asp:ListItem>--detail--</asp:ListItem>
                        <asp:ListItem>Upload</asp:ListItem>
                        <asp:ListItem>Manual</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group" id="tabledetail"  style="display:none">
            <label for="exampleInputPassword1">Table</label><button id="show" type="button" class="btn-xs btn-primary pull-right"><i class="fa fa-plus"></i></button> 
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
                            <asp:FileUpload ID="FileUpload2" runat="server" />
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
                            <asp:FileUpload ID="FileUpload3" runat="server" />
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
                            <asp:FileUpload ID="FileUpload4" runat="server" />
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
                            <asp:FileUpload ID="FileUpload5" runat="server" />
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
                            <asp:FileUpload ID="FileUpload6" runat="server" />
                        </td>
                    </tr>
                    <tr id="tr6">
                        <td>
                            <asp:TextBox ID="txtketerangan6" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnominal6" runat="server" CssClass="form-control" onkeydown="return numbersonly(this, event);" onkeyup="javascript:tandaPemisahTitik(this);"></asp:TextBox>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload7" runat="server" />
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
                            <asp:FileUpload ID="FileUpload8" runat="server" />
                        </td>
                    </tr>
                </tbody>
                
            </table>
        
        </div>
        <div class="form-group" id="file" style="display:none">
            <label for="exampleInputFile">File input</label>
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="false"/>
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
        <button type="submit" class="btn btn-primary" runat="server" onserverclick="Save_ServerClick">Submit</button>
        </div>
    </div>
    </section>
<section class="col-lg-5 connectedSortable">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Pengeluaran Hari ini</h3>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <div class="box-body" style="min-height:200px;">
        <asp:DataList runat="server" id="datalist1" CssClass="table">
            <ItemTemplate>

            <asp:Label ID="NAMALabel" runat="server" class="namaLB pdg" Text="Pengeluaran"/>
            <span class="pull-right">
                <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# "Rp. " + Eval("input", "{0:N0}") %>' />
            </span>
            <br />
            <asp:Label ID="Label2" runat="server" class="namaLB pdg" Text="Dari"/>
            <span class="pull-right">
                <asp:Label ID="Label3" runat="server" class="kategoriLB" Text='<%# Eval("simpanan") %>' />
            </span>
            <br />
            <asp:Label ID="Label4" runat="server" class="namaLB pdg" Text="Jenis"/>
            <span class="pull-right">
                <asp:Label ID="Label5" runat="server" class='<%# Eval("status").ToString()=="done" ? "label label-sm label-success" : "label label-sm label-danger" %>' 
                    Text='<%# Eval("status").ToString()=="done" ? "Cash" : "Panjar" %>' />
            </span>
            <br />
                
            </ItemTemplate>
    </asp:DataList>
    </div>
    </div>
</section>
</div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="nominal.js"></script>
    <script>
        function status(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
            //alert(userinput);
            if (statuslogbook == "Cash") {
                document.getElementById('detaill').style.display = 'block';
                document.getElementById('user').style.display = 'none';
            }
            else {
                document.getElementById('user').style.display = 'block';
                document.getElementById('detaill').style.display = 'none';
                document.getElementById('tabledetail').style.display = 'none';
                document.getElementById('file').style.display = 'none';
            }
        }
        function detail(obj) {
            var selectbox = obj;
            var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
            //alert(userinput);
            if (statuslogbook == "Manual") {
                document.getElementById('tabledetail').style.display = 'block';
                document.getElementById('file').style.display = 'none';
            }
            else {
                document.getElementById('file').style.display = 'block';
                document.getElementById('tabledetail').style.display = 'none';     
            }
        }
    </script>
    <script type="text/javascript">
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
        });
    </script>

</asp:Content>
