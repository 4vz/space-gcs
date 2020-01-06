<%@ Page Title="Detail" Language="C#" MasterPageFile="~/TICKETMASTER.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Telkomsat.ticket.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="hfContactID" runat="server" />

<div class="modal fade" id="modal-default">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title">Default Modal</h4>
        </div>
        <div class="modal-body">
            <p>One fine body&hellip;</p>
        </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
        </div>
    </div>
    <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
        <!-- /.col -->
<div class="col-md-9">
    <div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Ticket</h3> <asp:Label ID="lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>

              
    </div>
    <!-- /.box-header -->
    <div class="box-body with-border">
        <asp:DataList runat="server" id="datalist1" CssClass="table">
    <ItemTemplate>
    <asp:Label Text='<%# Eval("subject") %>' runat="server" class="judulLB1 pdg" />
    <br />
    <asp:Label ID="NAMALabel" runat="server" class="namaLB pdg" Text='<%# "from : " + Eval("nama_user") %>'/>
        <asp:Label ID="Label1" runat="server" class="namaLB pdg" Text='<%# "  ( " + Eval("nomor_hp") + " )" %>'/>

    <span class="pull-right">
        <asp:Label ID="KATEGORILabel" runat="server" class="kategoriLB" Text='<%# Eval("prioritas") %>' />
    </span>
    <br />
        <br />
    <asp:Label ID="WAKTULabel" runat="server" class="waktuLB pdg" Text='<%# ((DateTime)Eval("tanggal")).ToString("dd/MM/yyyy HH:mm") %>' />
        <span class="pull-right">
        <asp:Label ID="lblStatus" runat="server" class="kategoriLB" Text='<%# Eval("status") %>' />
    </span>
    <br />
        <asp:Label ID="Label3" style="white-space: pre-line; font-size:13px" runat="server" class="aktivitasLB1 pdg" Text='<%# Eval("kategori") %>' />
        <br />
        <br />
    <asp:Label ID="AKTIVITASLabel" style="white-space: pre-line;" runat="server" class="aktivitasLB1 pdg" Text='<%# Eval("keterangan") %>' />
    <br />
</ItemTemplate>

</asp:DataList>
        <br />
    <asp:GridView ID="DataList3a" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
            BorderColor="White" BorderStyle="None" BorderWidth="0px" Visible="false" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="InkView" runat ="server" CommandArgument='<%# Eval("namafiles") %>' CommandName="Download" Text='<%# Eval("namafiles") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
        <RowStyle BackColor="White" ForeColor="#1b1b1b" />
        </asp:GridView>
    </div>
    <!-- /.box-body -->
            
    <!-- /.box-footer -->
    <div class="box-footer" id="reply">
        <div class="pull-right">
            <button type="button" value="accept" onclick="if (confirm('Sure accept?')) return" id="btnaccept" class="btn btn-primary" runat="server" onserverclick="Accepted_ServerClick"><i class="fa fa-check"></i> Accepted</button>
            <button type="button" id="btnreject" class="btn btn-danger" runat="server" onclick="if (confirm('Sure reject?')) return" onserverclick="Rejected_ServerClick"><i class="fa fa-close"></i> Rejected</button>
            <button type="button" id="btncomplete" class="btn btn-success" runat="server" visible="false" data-toggle="modal" data-target="#modaltiket"><i class="fa fa-check"></i> Completed</button>
            
            <button type="button" id="btnconfirm" class="btn btn-info" runat="server" visible="false" onclick="if (confirm('Sure confirm?')) return" onserverclick="Confirm_ServerClick"><i class="fa fa-check-square"></i> Close</button>
                
        </div>
        <button type="button" class="btn btn-default" onclick="reply()"><i class="fa fa-reply"></i> Reply</button>
    </div>

    <div class="box-footer" id="inreply" style="display:none">
        <div class="box-body">
            <div class="form-group">
                <label for="exampleInputEmail1">Nama</label><span style="color:red">*</span>
                <input type="email" class="form-control" id="nama" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Keterangan</label><span style="color:red">*</span>
                <textarea  name="keterangan" class="form-control" id="keterangan" rows="10" runat="server"></textarea>
            </div>
            <div class="form-group">
                <label for="exampleInputFile">File input</label>
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/>
            </div>
            <div class="box-footer">
        
                <button type="button" class="btn btn-primary" runat="server" onserverclick="Reply_ServerClick"><i class="fa fa-reply"></i> Send</button>
            </div>
        </div>
    </div>
    <!-- /.box-footer -->
    </div>
    <!-- /. box -->

    <div class="box box-default" style="display:none" id="replybox" runat="server">
    <div class="box-header with-border">
        <h3 class="box-title">Reply</h3> <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>

              
    </div>
    <!-- /.box-header -->
    <div class="box-body with-border">
        <asp:DataList runat="server" id="datalist2" CssClass="table" >
    <ItemTemplate>
    <asp:Label Text='<%# Eval("nama") %>' runat="server" class="judulLB2" />
    <asp:Label ID="WAKTULabel" runat="server" class="waktuLB" Text='<%# "  " + ((DateTime)Eval("tanggal")).ToString("dd/MM/yyyy HH:mm") %>' />
        <br />
    <asp:Label ID="AKTIVITASLabel" style="white-space: pre-line;" runat="server" class="aktivitasLB1" Text='<%# Eval("reply") %>' />
        <br />
        <br />
        <asp:LinkButton ID ="InkView" Font-Size="Small" runat ="server" CommandArgument='<%# Eval("namafiles") %>' OnCommand="InkView_Command" CommandName="Download" OnClick="InkView_Click"
            Visible='<%# Eval("namafiles")==DBNull.Value ? false : true %>' Text='<%# Eval("namafiles")==DBNull.Value ? null : Eval("namafiles") %>'></asp:LinkButton>
        <i class="fa fa-download" runat="server" visible='<%# Eval("namafiles")==DBNull.Value ? false : true %>'></i>
</ItemTemplate>

</asp:DataList>
                        

    </div>
    <!-- /.box-body -->

    <div class="box-footer" id="reply1">
      
                <button type="button" class="btn btn-default" onclick="reply1()"><i class="fa fa-reply"></i> Reply</button>
    </div>
    <div class="box-footer" id="inreply1" style="display:none">
        <div class="box-body">
            <div class="form-group">
                <label for="exampleInputEmail1">Nama</label><span style="color:red">*</span>
                <input type="email" class="form-control" id="txtnama" runat="server"/>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Keterangan</label><span style="color:red">*</span>
                <textarea name="keterangan" class="form-control" id="txtket" rows="10" runat="server"></textarea>
            </div>
            <div class="form-group">
                <label for="exampleInputFile">File input</label>
                <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="false"/>
            </div>
            <div class="box-footer">
        
                <button type="button" class="btn btn-primary" runat="server" onserverclick="Reply1_ServerClick"><i class="fa fa-reply"></i> Send</button>
            </div>
        </div>
    </div>
    <!-- /.box-footer -->
    <!-- /.box-footer -->
    </div>

</div>

  <div class="modal fade" id="modaltiket" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog">
                <div class="modal-content">
                <section class="panel panel-danger">
      <header class="panel-heading" style="background-color:darkred; border-color:darkred;">
                <button type="button" class="close" data-dismiss="modal">
                    &times;
                </button>
                <h4 class="modal-title" style="color:ghostwhite">Ticket</h4>
            </header>
      <div class="panel-body">
          <div class="divtabel">
          <table align="center">
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Kategori</label><span style="color:red"> *</span>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="5">
                      <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                          <asp:ListItem Text="Recovery"></asp:ListItem>
                          <asp:ListItem Text="Instalasi"></asp:ListItem>
                          <asp:ListItem Text="Repair"></asp:ListItem>
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Affident</label><span style="color:red"> *</span>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="5">
                      <asp:FileUpload ID="FileUpload3" runat="server" />
                  </td>
              </tr>
              
              
          </table>
              </div>
        </div>
        <footer class="panel-footer">
                        <div class="row" style="height:auto">
                            <div class="col-md-12 text-right">
                                <button class="btn btn-primary" type="submit" runat="server" onserverclick="Complete_ServerClick">Submit</button>
                                <button class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </footer>
                </section>
      </div>
    </div>
  </div>

    <script>
        function reply() {
            var reply = document.getElementById("reply");
            var inreply = document.getElementById("inreply");

            reply.style.display = 'none';
            inreply.style.display = 'block';
        }

        function reply1() {
            var reply = document.getElementById("reply1");
            var inreply = document.getElementById("inreply1");

            reply.style.display = 'none';
            inreply.style.display = 'block';
        }

    </script>
</asp:Content>
