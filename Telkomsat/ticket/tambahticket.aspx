<%@ Page Title="Tambah Ticket" Language="C#" MasterPageFile="~/TICKETMASTER.Master" AutoEventWireup="true" CodeBehind="tambahticket.aspx.cs" Inherits="Telkomsat.ticket.tambahticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="hfContactID" runat="server" />
<!-- /.col -->
<div class="col-md-9">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Tambah Ticket</h3>
                <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <!-- /.box-header -->
    <!-- form start -->
        <div class="box-body">
        <div class="col-md-6" style="padding-left:0px">
            <div class="form-group">
                <label for="exampleInputEmail1">Nama</label>
                <select id="sonama" runat="server" class="select2 form-control" style="width: 100%;">
                    <option></option>
                </select>
                </div>
        </div>
        <div class="col-md-6" style="padding-right:0px">
            <div class="form-group">
                <label for="exampleInputEmail1">Nomor HP</label>
                <input type="text" class="form-control" id="nomor" runat="server"/>
            </div>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Kategori</label>
            <asp:DropDownList ID="ddlKategori" CssClass="form-control" runat="server">
                <asp:ListItem>--Kategori--</asp:ListItem>
                <asp:ListItem>Quality factor data ranging</asp:ListItem>
                <asp:ListItem>Readiness perangkat ranging</asp:ListItem>
                <asp:ListItem>Readiness perangkat pengendalian MCS</asp:ListItem>
                <asp:ListItem>Readiness perangkat pengendalian BCS</asp:ListItem>
                <asp:ListItem>Perangkat Engineering</asp:ListItem>
                <asp:ListItem>Readiness perangkat monitoring transponder</asp:ListItem>
                <asp:ListItem>Readiness perangkat geolocator</asp:ListItem>
                <asp:ListItem>Readiness perangkat antena LFT</asp:ListItem>
                <asp:ListItem>Readiness perangkat antena ASI</asp:ListItem>
                <asp:ListItem>Readiness perangkat antena monitoring satelit sewa</asp:ListItem>
                <asp:ListItem>Readiness ME</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Subject</label>
            <input type="text" class="form-control" id="subject" placeholder="Subject" runat="server"/>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Keterangan</label>
            <textarea name="keterangan" class="form-control" id="keterangan" rows="10" runat="server"></textarea>
        </div>
                
        <div class="form-group">
            <label for="exampleInputFile">Prioritas</label>
            <div class="options">
                    
            <label style="padding-right:15px" class="option">
                <input type="radio" name="optionsRadios" id="optionsRadios1" value="High" runat="server"/>
                High
            </label>
                      
            <label style="padding-right:15px" class="option">
                <input type="radio" name="optionsRadios" id="optionsRadios2" value="Medium" runat="server"/>
                Medium
            </label>
                  
            <label style="padding-right:15px" class="option">
                <input type="radio" name="optionsRadios" id="optionsRadios3" value="Low" runat="server"/>
                Low
            </label>
            </div>
        </div>
            <div class="form-group">
                <label for="exampleInputFile">File input</label>
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/>
        </div>
        </div>
        <!-- /.box-body -->

        <div class="box-footer">
        <button type="submit" class="btn btn-primary" runat="server" onserverclick="submitbtn">Submit</button>
        </div>
    </div>
    </div>

    <asp:TextBox ID="txtnama" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtnomor" runat="server" CssClass="hidden"></asp:TextBox>
    <asp:TextBox ID="txtjenis" runat="server" CssClass="hidden"></asp:TextBox>

    <script>
        var jenis = $('#<%=txtjenis.ClientID %>').val();

        $(function () {
            $.ajax({
                type: "POST",
                url: "tambahticket.aspx/GetProfile",
                contentType: "application/json; charset=utf-8",
                data: '{jenis:"' + jenis + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=sonama.ClientID %>').empty();
                    $('#<%=sonama.ClientID %>').append('<option></option>');
                    $(customers).each(function () {
                        console.log(this.nama);
                        $('#<%=sonama.ClientID %>').append($('<option>',
                            {
                                value: this.id,
                                text: this.nama,
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


        $('#<%=sonama.ClientID%>').change(function () {
            var id = $(this).val();
            var nama = $(this).find("option:selected").text();

            $('#<%=txtnama.ClientID %>').val(nama);
            $.ajax({
                type: "POST",
                url: "tambahticket.aspx/GetNomor",
                contentType: "application/json; charset=utf-8",
                data: '{videoid:"' + id + '"}',
                dataType: "json",
                success: function (response) {
                    var customers = response.d;
                    $('#<%=nomor.ClientID%>').val('');
                    $(customers).each(function () {
                        $('#<%=nomor.ClientID%>').val(this.nomor);
                        $('#<%=txtnomor.ClientID %>').val(nomor);
                        console.log(this.nomor)
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

    </script>

</asp:Content>
