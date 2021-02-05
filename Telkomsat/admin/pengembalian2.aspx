<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="pengembalian2.aspx.cs" Inherits="Telkomsat.admin.pengembalian2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tampil{
            display:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
<div class="row" style="padding:20px">
<div class="nav-tabs-custom col-lg-12">
    <!-- Tabs within a box -->
    <ul class="nav nav-tabs pull-right">
        <li class="pull-left header"><i class="fa fa-filter"></i> Pilih User</li>
    </ul>
    <div class="tab-content no-padding">
        <!-- Morris chart - Sales -->
        <div class="box-body">
        
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Petugas</label>
                        <select id="sotugas" runat="server" class="select2 form-control" style="width: 100%;">
                            <option></option>
                        </select>
                    </div>
                </div>
                
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Filter</label>
                        <br />
                        <button type="submit" class="btn btn-primary" runat="server" onserverclick="Filter_ServerClick" >Submit</button>
                    </div>
                </div>
        <!-- /.table -->
            </div>
        </div>
    </div>
</div>

<div class="col-lg-12 connectedSortable">
        <!-- Custom tabs (Charts with tabs)-->
    <div class="box box-primary">
    <!-- Tabs within a box -->
    <div class="box-header">
        <i class="fa fa-money"></i> Pemasukan
        <button type="button" id="btnid" class="btn btn-success pull-right" runat="server" visible="false" >Get Values</button>
    </div>
    <div class="box-body">
        <!-- Morris chart - Sales -->
        <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder> 
                <br />
                <div id="content" style="display:none">
                    <div class="row">
                     <div class="col-md-2">
                         <div class="form-group">
                            <label for="exampleInputPassword1">Total Pengembalian</label>
                            <input type="text" class="form-control" id="txttotal" runat="server" readonly/>
                        </div>
                     </div>
                   </div>
                    <div class="row">
                     <div class="col-md-3">
                         <div class="form-group">
                            <label for="exampleInputPassword1">Tanggal</label>
                            <input type="text" class="form-control datepick" id="txttanggal" runat="server" autocomplete="off"/>
                        </div>
                     </div>
                   </div>
                    <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                            <label for="exampleInputPassword1">Keterangan</label>
                            <asp:TextBox ID="txtket" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                        </div>
                     </div>
                   </div>
                    <div class="row">
                     <div class="col-md-4">
                         <div class="form-group">
                            <label for="exampleInputPassword1">Evidence</label>
                            <asp:FileUpload ID="FileUpload4" runat="server" AllowMultiple="false" />
                        </div>
                     </div>
                   </div>

                </div>
            </div>
    <!-- /.table -->
        </div>
    </div>
    <div class="box-footer">
        <button type="submit" id="mybtn" runat="server" class="btn btn-primary pull-right" style="display:none" onserverclick="Save_Click">Submit</button>
    </div>
    </div>
</div>
</div>
    <asp:TextBox ID="txtid" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtpetugas" runat="server" CssClass="hidden"></asp:TextBox>
    <script src="../assets/bower_components/PACE/pace.min.js"></script>
    <script src="../assets/bower_components/fastclick/lib/fastclick.js"></script>
    <script src="../assets/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../assets/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../assets/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script>
        var table = $(function () {
          $("#example2").DataTable({
          "paging": false,
          "searching": true,
          "info": true,
          "autoWidth": true,
              "scrollX": true,
          "ordering": false,
          });
            $('.dataTables_length').addClass('bs-select');

            $('#example-select-all').on('click', function () {
                // Check/uncheck all checkboxes in the table
                $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
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
                    $('#<%=sotugas.ClientID %>').val($('#<%=txtpetugas.ClientID %>').val());
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

        function toggle(source) {
            var checkboxes = document.querySelectorAll('input[type="checkbox"]');
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] != source)
                    checkboxes[i].checked = source.checked;
            }
        }

        $(document).ready(function () {
            var button = document.getElementById('<%=mybtn.ClientID%>');
            $('#<%=btnid.ClientID %>').click(function () {
                button.style.display = "block";
                var elmnt = document.getElementById("content");
                
                if (elmnt.style.display === "none") {
                    elmnt.style.display = "block";
                }
                elmnt.scrollIntoView();
                var favorite = [];
                $.each($("input[name='getid']:checked"), function () {
                    favorite.push($(this).val());
                });
                //alert("My favourite sports are: " + favorite.join(","));
                var id = favorite.join(",");
                $('#<%=txtid.ClientID %>').val(id);
                $.ajax({
                    type: "POST",
                    url: "pengembalian2.aspx/GetData",
                    data: '{videoid:"' + id + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var mydata = response.d;
                        
                        $('#<%=txttotal.ClientID %>').val(mydata);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                }); 
                
            });
        });

        $(".datepick").datepicker({
            autoclose: true,
            format: 'yyyy/mm/dd'
        });
    </script>

</asp:Content>
