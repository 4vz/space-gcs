<%@ Page Title="" Language="C#" MasterPageFile="~/MAINTENANCEHK.Master" AutoEventWireup="true" CodeBehind="editdata.aspx.cs" Inherits="Telkomsat.maintenancehk.bulanan.editdata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .link{
            color:black;
            font-size:12px;
            font-weight:bold;
        }
        .link:hover{
            color:black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden"></asp:TextBox>
<div class="row" style="padding:20px">
<div class="nav-tabs-custom col-lg-12 no-padding">
    <!-- Tabs within a box -->
    <ul class="nav nav-tabs pull-right">
        <li class="pull-left header"><i class="fa fa-filter"></i> Filter</li>
    </ul>
    <div class="tab-content no-padding">
        <!-- Morris chart - Sales -->
        <div class="box-body">
        <asp:Label ID="lblwarning" Font-Size="11px" runat="server" Text="Label" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
            <div class="row">
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Start Date</label>
                        <select id="so1" runat="server" class="select2 form-control selectcolor" style="width: 100%;">
                            <option>--Pilih Lokasi--</option>
                            <option>Cibinong</option>
                            <option>Banjarmasin</option>
                        </select>
                    </div>
                </div>
                
                <div class="col-md-5">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Kategori</label>
                        <select id="so2" runat="server" class="select2 form-control" style="width: 100%;">
                            <option>--Pilih Ruangan--</option>
                        </select>
                    </div>
                </div>
                <div class="col-md-2 col-xs-12">
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
        <i class="fa fa-check"></i> Maintenance Bulanan 
        <asp:Label ID="lblroom" runat="server" Text="Checklist ME" Font-Size="Large" Font-Bold="true"></asp:Label>
    </div>
    <div class="box-body">

                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
    </div>
    <div class="box-footer">
        <asp:Button ID="Button1" CssClass="btn btn-primary pull-right" runat="server" OnClick="Save_Click" Text="Save" />
    </div>
    </div>
</div>
</div>
    <script src="//cdn.rawgit.com/ashl1/datatables-rowsgroup/v1.0.0/dataTables.rowsGroup.js"></script>
    <script>
        function SetDropDownListColor(ddl) {
            for (var i = 0; i < ddl.options.length; i++) {
                if (ddl.options[i].selected) {
                    switch (i) {
                        case 0:
                            ddl.style.backgroundColor = 'White';
                            ddl.style.color = 'Black';
                            return;
                        case 1:
                            ddl.style.backgroundColor = '#27d714';
                            ddl.style.color = 'White';
                            return;
                    }
                }
            }
            console.log("tetr");
        }

        /*var img = document.getElementsByClassName("selectcolor");
        var modalImg = document.getElementById("img01");
        var i;
        for (i = 0; i < img.length; i++) {
            img[i].onclick = function(){
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
            }
        }*/

        $(function () {
          $("#example3").DataTable({
          "paging": true,
          "searching": true,
          "scrollX": true,
          "order": [[ 0, 'desc' ]]
          });
           $('.dataTables_length').addClass('bs-select');
        });

        $(function () {
            SetDropDownListColor('.selectcolor');
        });

        $('#<%=so1.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=so2.ClientID %>').append('<option value="">' + "--Pilih Ruangan--" + '</option>');
            $.ajax({
                type: "POST",
                url: "isidata.aspx/GetID",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{myid:"' + id + '"}',
                success: function (response) {
                    var customers = response.d;
                    $('#<%=so2.ClientID %>').empty();
                    $('#<%=so2.ClientID %>').append('<option>' + '--Pilih Ruangan--' + '</option>');
                    $(customers).each(function () {
                        $('#<%=so2.ClientID %>').append($('<option>',
                            {
                                value: this.idruang,
                                text: this.ruang,
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

        $('#<%=so2.ClientID %>').on('change', function () {
            var id = $(this).val();
            $('#<%=TextBox2.ClientID %>').val(id);
        });
    </script>
</asp:Content>
