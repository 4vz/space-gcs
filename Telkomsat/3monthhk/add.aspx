<%@ Page Title="" Language="C#" MasterPageFile="~/3MONTH.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Telkomsat._3monthhk.add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 connectedSortable" style="min-height:50px">
            <div class="col-md-5 col-xs-12" style="padding-left:0; padding-bottom:15px; padding-right:15px">
            <asp:DropDownList ID="ddlruang" runat="server" CssClass="form-control" Width="100%">
                <asp:ListItem>-Pilih Site-</asp:ListItem>
                <asp:ListItem>Cibinong</asp:ListItem>
                <asp:ListItem>Banjarmasin</asp:ListItem>
            </asp:DropDownList>
                </div>
            <div class="col-md-5 col-xs-12" style="padding-left:0; padding-bottom:15px; padding-right:15px">
            <asp:DropDownList ID="ddlbbu" runat="server" CssClass="form-control" Width="100%">
                <asp:ListItem>-Pilih Baseband-</asp:ListItem>
                <asp:ListItem Value="T21">BBU2a</asp:ListItem>
                <asp:ListItem Value="T22">BBU2b</asp:ListItem>
                <asp:ListItem Value="T3SC1">BBU3a</asp:ListItem>
                <asp:ListItem Value="T3SC2">BBU3b</asp:ListItem>
                <asp:ListItem Value="MP1">BBU4a</asp:ListItem>
                <asp:ListItem Value="MP2">BBU4b</asp:ListItem>
            </asp:DropDownList>
                </div>
             <div class="col-md-2 col-xs-12" style="padding-bottom:15px; ">
            <asp:Button ID="Button1" runat="server" Text="Pilih" CssClass="btn btn-success btn-sm" OnClick="Pilih_Click" Width="100%"/>
            </div>
        </div>
    <div class="col-md-12">
        <div class="box box-primary">
        <div class="box-header with-border">
            <asp:Label ID="lblroom" runat="server" Text="Checklist" Font-Size="Large" Font-Bold="true"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Copy From The Last" OnClick="inisialisasi_Click" CssClass="btn btn-sm btn-primary pull-right"  />

            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
                        <div class="row" id="div4" style="display:none" runat="server">
    <a href="../3monthhk/add.aspx?parameter=output#baseband">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-link"></i></span>
            <div class="info-box-content">
              <span>Output Baseband </span><br />
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=IFR1">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-desktop"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFR 1</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=IFR2">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-desktop"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFR 2</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
    <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-desktop"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFR 3</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-code-fork"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TMU 1</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-code-fork"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TMU 2</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
    <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-code-fork"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TMU 3</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-code-fork"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TMU 4</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-server"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFM 1</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
          <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-server"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFM 2</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
            <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-sort-amount-desc"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">RAU</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-tasks"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TCU</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
            <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-ticket"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">Baseband Temp Monitoring</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     </div>

            <div class="row" id="divbiasa" runat="server" style="display:none">
    <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-link"></i></span>
            <div class="info-box-content">
              <span>Output Baseband </span><br />
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-desktop"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFR 1</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-desktop"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFR 2</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-code-fork"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TMU 1</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-code-fork"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TMU 2</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-server"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFM 1</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
          <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-server"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">IFM 2</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
            <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-sort-amount-desc"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">RAU</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
        <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-tasks"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">TCU</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
            <a href="../3monthhk/add.aspx?parameter=output">
        <div class="col-md-3 col-sm-6 col-xs-6">
          <div class="info-box">
            <span class="info-box-icon bg-gray-light"><i class="fa fa-ticket"></i></span>
            <div class="info-box-content">
              <span class="info-box-text">Baseband Temp Monitoring</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        </a>
     </div>
            <br />
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:Label ID="lbledit" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">lihat</asp:LinkButton>
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer no-padding">
            <div class="mailbox-controls">
            <asp:Button ID="Button3" runat="server" Text="Save" CssClass="btn-primary btn pull-right" Width="100px" OnClick="Button1_Click" />
            <!-- /.pull-right -->
            </div>
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    
    <!-- /.col -->
    <script src="//cdn.rawgit.com/ashl1/datatables-rowsgroup/v1.0.0/dataTables.rowsGroup.js"></script>
    <script type="text/javascript">
       $(function () {
          $("#example2").DataTable({
          "autoWidth": true,
          "scrollX": true,
          "rowsGroup": [0, 1],
          "pageLength": 120,
              "lengthChange": false,
          "ordering": false,
          "columnDefs": [
              { "orderable": false, "targets": [0] },
              { "bSort": false, "targets": [0] }
          ]
          });
           $('.dataTables_length').addClass('bs-select');
        });

        function fungsi() {
            alert("Berhasil Disimpan");
        }
      
    </script>
</asp:Content>
