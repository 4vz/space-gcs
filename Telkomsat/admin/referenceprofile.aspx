<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="referenceprofile.aspx.cs" Inherits="Telkomsat.admin.referenceprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/bower_components/select2/dist/css/select2.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtid" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtsubdit" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtnama" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtjabatan" runat="server" CssClass="hidden"></asp:TextBox>
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Tambah Profile</h3>
                        <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                        <asp:Panel ID="UserPanel" runat="server" DefaultButton="btnsave">
                            <div class="alert alert-danger alert-dismissable" id="divfail" runat="server" visible="false">
                                <h5><span class="fa fa-ban"> GM atau Admin Bendahara sudah tersedia, harap ubah yang sebelumnya</span></h5>
                            </div>
                        <table class="table">
                            <thead>
                                <tr>
                                    <td>Nama</td>
                                    <td>Subdit</td>
                                    <td>Jabatan</td>
                                    <td>Previllage</td>
                                    <td>Action</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><select id="sonama" runat="server" class="select2 form-control" style="width: 100%;">
                                            <option></option>
                                        </select></td>
                                    <td><select id="sosubdit" runat="server" class="select2 form-control" style="width: 100%;">
                                            <option></option>
                                        </select></td>
                                    <td><select id="sojabatan" runat="server" class="select2 form-control" style="width: 100%;">
                                            <option></option>
                                        </select></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>GM</asp:ListItem>
                                            <asp:ListItem>Admin Bendahara</asp:ListItem>
                                            <asp:ListItem>User Organik</asp:ListItem>
                                            <asp:ListItem>User</asp:ListItem>
                                            <asp:ListItem>SA</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td><asp:Button ID="btnsave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="save_click" /></td>
                                </tr>
                            </tbody>
                        </table>
                        </asp:Panel>
                    </div>
                </div>
            </section>
        </div>
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Profile</h3>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                    <div class="box-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </section>
        </div>


    <div class="modal fade" id="modalupdate">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Harkat</h4>
              </div>
              <div class="modal-body">
                <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Nama :</label>
                    <select id="sonama2" runat="server" class="select2 form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
                  <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Subdit :</label>
                    <select id="sosubdit2" runat="server" class="select2 form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
                  <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Jabatan :</label>
                    <select id="sojabatan2" runat="server" class="select2 form-control" style="width: 100%;">
                        <option></option>
                    </select>
                </div>
                  <div class="form-group">
                    <label style="font-size:16px; font-weight:bold">Previllage :</label>
                    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>GM</asp:ListItem>
                        <asp:ListItem>Admin Bendahara</asp:ListItem>
                        <asp:ListItem>User Organik</asp:ListItem>
                        <asp:ListItem>User</asp:ListItem>
                        <asp:ListItem>SA</asp:ListItem>
                    </asp:DropDownList>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-success pull-left" runat="server" onserverclick="Edit_ServerClick">Save</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/mylibrary/sweetalert.min.js"></script>
    <script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script>
        function confirmdelete(deleteurl) {
            swal({
                title: 'Apakah Anda Yakin ?',
                text: 'Data yang dihapus tidak akan kembali lagi',
                buttons: true,
                dangerMode: true,

            }).then((willDelete)=>{
                if (willDelete) {
                    document.location = deleteurl;
                }
            });
        }

        $('.datawil').click(function () {
            var id = $(this).val();
            $.ajax({
                type: "POST",
                url: "referenceprofile.aspx/GetReferensi",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    //console.log(response);
                    var data = response.d;
                    $(data).each(function () {
                        console.log(this.wilayah);
                        $('#<%=txtid.ClientID %>').val(this.idreferensi);
                        $('#<%=DropDownList2.ClientID %>').val(this.previllage);
                        $('#<%=txtjabatan.ClientID %>').val(this.idjabatan2);
                        $('#<%=txtnama.ClientID %>').val(this.idnama2);
                        $('#<%=txtsubdit.ClientID %>').val(this.idsubdit2);
                    });

                    $.ajax({
                        type: "POST",
                        url: "referenceprofile.aspx/GetSubdit",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var customers = response.d;
                            var unit3 = $('#<%=txtsubdit.ClientID%>').val();
                            $('#<%=sosubdit2.ClientID %>').empty();
                            $('#<%=sosubdit2.ClientID %>').append('<option></option>');
                            $(customers).each(function () {
                                $('#<%=sosubdit2.ClientID %>').append($('<option>',
                                    {
                                        value: this.idsubdit,
                                        text: this.subdit,
                                    }));
                            });
                            $('#<%=sosubdit2.ClientID %>').val(unit3);
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
                        url: "referenceprofile.aspx/GetJabatan",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var customers = response.d;
                            var unit3 = $('#<%=txtjabatan.ClientID%>').val();
                            $('#<%=sojabatan2.ClientID %>').empty();
                            $('#<%=sojabatan2.ClientID %>').append('<option></option>');
                            $(customers).each(function () {
                                $('#<%=sojabatan2.ClientID %>').append($('<option>',
                                    {
                                        value: this.idjabatan,
                                        text: this.jabatan,
                                    }));
                            });
                            $('#<%=sojabatan2.ClientID %>').val(unit3);
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
                        url: "referenceprofile.aspx/GetNama",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var customers = response.d;
                            var unit3 = $('#<%=txtnama.ClientID%>').val();
                            $('#<%=sonama2.ClientID %>').empty();
                            $('#<%=sonama2.ClientID %>').append('<option></option>');
                            $(customers).each(function () {
                                $('#<%=sonama2.ClientID %>').append($('<option>',
                                    {
                                        value: this.idnama,
                                        text: this.nama,
                                    }));
                            });
                            $('#<%=sonama2.ClientID %>').val(unit3);
                        },
                        failure: function (response) {

                            alert(response.d);
                        },
                        error: function (response) {
                            alert(response.d);
                        }
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

        $(function () {
            $.ajax({
                type: "POST",
                url: "referenceprofile.aspx/GetNama",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var unit3 = $('#<%=txtnama.ClientID%>').val();
                    $('#<%=sonama.ClientID %>').empty();
                    $('#<%=sonama.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        $('#<%=sonama.ClientID %>').append($('<option>',
                            {
                                value: this.idnama,
                                text: this.nama,
                            }));
                    });
                    $('#<%=sonama.ClientID %>').val(unit3);
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
                url: "referenceprofile.aspx/GetSubdit",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var unit3 = $('#<%=txtsubdit.ClientID%>').val();
                    $('#<%=sosubdit.ClientID %>').empty();
                    $('#<%=sosubdit.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        $('#<%=sosubdit.ClientID %>').append($('<option>',
                            {
                                value: this.idsubdit,
                                text: this.subdit,
                            }));
                    });
                    $('#<%=sosubdit.ClientID %>').val(unit3);
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
                url: "referenceprofile.aspx/GetJabatan",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    var unit3 = $('#<%=txtjabatan.ClientID%>').val();
                    $('#<%=sojabatan.ClientID %>').empty();
                    $('#<%=sojabatan.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        $('#<%=sojabatan.ClientID %>').append($('<option>',
                            {
                                value: this.idjabatan,
                                text: this.jabatan,
                            }));
                    });
                    $('#<%=sojabatan.ClientID %>').val(unit3);
                },
                failure: function (response) {

                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

        $('#<%=sosubdit.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtsubdit.ClientID%>').val(id);
        });

        $('#<%=sonama.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtnama.ClientID%>').val(id);
        });


        $('#<%=sojabatan.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtjabatan.ClientID%>').val(id);
        });

        $('#<%=sosubdit2.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtsubdit.ClientID%>').val(id);
        });

        $('#<%=sojabatan2.ClientID%>').change(function () {
            var id = $(this).val();
            $('#<%=txtjabatan.ClientID%>').val(id);
        });

        $('.select2').select2()
    </script>
</asp:Content>
