<%@ Page Title="Search By" Language="C#" MasterPageFile="~/ASSET.Master" AutoEventWireup="true" CodeBehind="searchby.aspx.cs" Inherits="Telkomsat.dataasset.searchby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="dataaset.css?version=2" />
    <asp:TextBox ID="txtdevice" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtruangan" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtrak" runat="server" CssClass="hidden"></asp:TextBox>
     <asp:TextBox ID="txtsatelit" runat="server" CssClass="hidden"></asp:TextBox>
<div class="row">
    <div class="nav-tabs-custom col-lg-12">
    <!-- Tabs within a box -->
    <ul class="nav nav-tabs pull-right">
        <li class="pull-left header"><i class="fa fa-filter"></i> Filter</li>
    </ul>
    <asp:Panel ID="UserPanel" runat="server" DefaultButton="Button1">
    <div class="tab-content no-padding">
        <!-- Morris chart - Sales -->
        <div class="box-body">
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Jenis Device</label>
                </div>   
                <div class="col-sm-10">
                    <asp:TextBox ID="txtdevice1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Merk</label>
                </div>   
                <div class="col-sm-10">
                    <asp:TextBox ID="txtmerk" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Serial Number</label>
                </div>   
                <div class="col-sm-10">
                    <asp:TextBox ID="txtsn" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Wilayah</label>
                </div>   
                <div class="col-sm-10">
                    <asp:TextBox ID="txtwilaya" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Ruangan</label>
                </div>   
                <div class="col-sm-10">
                    <asp:TextBox ID="txtruang" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Fungsi</label>
                </div>   
                <div class="col-sm-10">
                    <asp:DropDownList ID="txfungsi" runat="server" CssClass="form-control">
                         <asp:ListItem></asp:ListItem>
                        <asp:ListItem>OPERASIONAL</asp:ListItem>
                        <asp:ListItem>BACKUP</asp:ListItem>
                        <asp:ListItem>SPARE</asp:ListItem>
                        <asp:ListItem>TOOLS</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label for="inputEmail3" class="pull-right">Status</label>
                </div>   
                <div class="col-sm-10">
                    <asp:DropDownList ID="txstatus" runat="server" CssClass="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>BAIK</asp:ListItem>
                        <asp:ListItem>RUSAK</asp:ListItem>
                        <asp:ListItem>PERBAIKAN</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
            <h4>Tahun Pengadaan</h4>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-sm-4">
                            <label for="inputEmail3" class="pull-right">Mulai</label>
                        </div>   
                        <div class="col-sm-8">
                           <asp:TextBox ID="txtmulai" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <div class="col-md-6">
                     <div class="col-sm-4">
                        <label for="inputEmail3" class="pull-right">Sampai </label>
                    </div>   
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtsampai" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                 </div>
                    
                </div>
            </div>
           
               <br />
            <div class="form-group">
                <asp:Button ID="Button1" class="btn btn-info pull-right" OnClick="Filter_Click" runat="server" Text="Filter"  style="width:30%" />
            </div>
        </asp:Panel>
    </div>
    </div>

    <div class="row">
    <div class="col-md-12">
        <div class="box box-danger">
        <div class="box-header with-border">
            <h3 class="box-title">Data Asset</h3>
        
            <button type="button" id="btnexpand" class="showHideColumn btn btn-sm btn-primary pull-right">Expand</button> 
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder> 
                <asp:Label ID="lblpencarian" runat="server" Text="Data pencarian tidak ditemukan" Visible="false"></asp:Label>
            </div>
        </div>
            <div class="box-footer">
                <asp:Button ID="Button2" runat="server" Text="Export to Excel" CssClass="btn btn-default pull-right" OnClick="ExportExcel" />
            </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    </div>
    <script src="../assets/mylibrary/jquery-ui-1-12-1.js"></script>
    <script>
			$(function() {
                $(".exportToExcel").click(function (e) {
                    $('#example2').table2excel({
							exclude: ".noExl",
							name: "Excel Document Name",
							filename: "myFileName" + new Date().toISOString().replace(/[\-\:\.]/g, "") + ".xls",
							fileext: ".xls",
							exclude_img: true,
							exclude_links: true,
							exclude_inputs: true,
							preserveColors: preserveColors
						});
					var table = $(this).prev('#example2');
					if(table && table.length){
						var preserveColors = (table.hasClass('table2excel_with_colors') ? true : false);
						
					}
				});
				
			});
		</script>
    <script type="text/javascript">
        $(function () {
          var datatableInstance = $("#example2").DataTable({
          "paging": true,
          "searching": false,
          "info": true,
          "autoWidth": true,
          "scrollX": true
          });
            $('.dataTables_length').addClass('bs-select');

            datatableInstance.column('0').visible(!datatableInstance.column('0').visible());
            datatableInstance.column('3').visible(!datatableInstance.column('3').visible());
            datatableInstance.column('4').visible(!datatableInstance.column('4').visible());
            datatableInstance.column('5').visible(!datatableInstance.column('5').visible());
            datatableInstance.column('8').visible(!datatableInstance.column('8').visible());
            datatableInstance.column('10').visible(!datatableInstance.column('10').visible());
            datatableInstance.column('12').visible(!datatableInstance.column('12').visible());
            datatableInstance.column('13').visible(!datatableInstance.column('13').visible());
            datatableInstance.column('14').visible(!datatableInstance.column('14').visible());

            var isExpand=false;
            $('.showHideColumn').on('click', function (e) {
                var this1 = $(this);
                if(isExpand)
                {
                  isExpand=false;
                  this1.text('Expand'); 
                }else{
                  isExpand=true;
                  this1.text('Reduce'); 
                }
                e.preventDefault();
                datatableInstance.column('0').visible(!datatableInstance.column('0').visible());
                datatableInstance.column('3').visible(!datatableInstance.column('3').visible());
                datatableInstance.column('4').visible(!datatableInstance.column('4').visible());
                datatableInstance.column('5').visible(!datatableInstance.column('5').visible());
                datatableInstance.column('8').visible(!datatableInstance.column('8').visible());
                datatableInstance.column('8').visible(!datatableInstance.column('10').visible());
                datatableInstance.column('10').visible(!datatableInstance.column('10').visible());
                datatableInstance.column('12').visible(!datatableInstance.column('12').visible());
                datatableInstance.column('13').visible(!datatableInstance.column('13').visible());
                datatableInstance.column('14').visible(!datatableInstance.column('14').visible());

            });
        });
        $(document).ready(function () {
            $(document).ready(function () {
                $('#<%=txtruang.ClientID %>').autocomplete({
                    source: 'Handler1.ashx'
                });
                $('#<%=txtsn.ClientID %>').autocomplete({
                    source: 'HandlerSN.ashx'
                });
                $('#<%=txtmerk.ClientID %>').autocomplete({
                    source: 'Handler3.ashx'
                });
                $('#<%=txtwilaya.ClientID %>').autocomplete({
                    source: 'HandlerSite.ashx'
                });
                $('#<%=txtdevice1.ClientID %>').autocomplete({
                    source: 'HandlerDevice.ashx'
                });
            });
        });
    </script>
</asp:Content>
