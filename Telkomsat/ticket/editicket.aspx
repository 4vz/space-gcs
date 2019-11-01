<%@ Page Title="Edit" Language="C#" MasterPageFile="~/TICKETMASTER.Master" AutoEventWireup="true" CodeBehind="editicket.aspx.cs" Inherits="Telkomsat.ticket.editicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <section class="content">
              <div class="row">
                <div class="col-md-3">
                  <a href="../ticket/tambah.aspx" class="btn btn-primary btn-block margin-bottom">New Ticket</a>

                  <div class="box box-solid">
                    <div class="box-header with-border">
                      <h3 class="box-title">Folders</h3>

                      <div class="box-tools">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                        </button>
                      </div>
                    </div>
                    <div class="box-body no-padding">
                      <ul class="nav nav-pills nav-stacked">
                        <li class="active"><a href="../ticket/ticket.aspx"><i class="fa fa-inbox"></i> Ticket</a></li>
                        <li><a href="#"><i class="fa fa-check-circle-o"></i> Accepted</a></li>
                        <li><a href="#"><i class="fa fa-chain-broken"></i> Rejected</a></li>
                        <li><a href="#"><i class="fa fa-star"></i> Favorit</a></li>
                        <li id="spam" runat="server"><a href="#"><i class="fa fa-trash"></i> Spam</a></li>
                      </ul>
                    </div>
                    <!-- /.box-body -->
                  </div>
                  <!-- /. box -->
                  <div class="box box-solid">
                    <div class="box-header with-border">
                      <h3 class="box-title">Priority</h3>

                      <div class="box-tools">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                        </button>
                      </div>
                    </div>
                    <div class="box-body no-padding">
                      <ul class="nav nav-pills nav-stacked">
                        <li><a href="#"><i class="fa fa-circle-o text-red"></i> High</a></li>
                        <li><a href="#"><i class="fa fa-circle-o text-yellow"></i> Medium</a></li>
                        <li><a href="#"><i class="fa fa-circle-o text-light-blue"></i> Low</a></li>
                      </ul>
                    </div>
                    <!-- /.box-body -->
                  </div>
                  <!-- /.box -->
                </div>
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
                      <input type="email" class="form-control" id="nama" runat="server"/>
                        </div>
                </div>
                <div class="col-md-6" style="padding-right:0px">
                    <div class="form-group">
                      <label for="exampleInputEmail1">Nomor HP</label>
                      <input type="number" class="form-control" id="nomor" runat="server"/>
                    </div>
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
                      <input type="file" id="exampleInputFile"/>
                </div>
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <button type="submit" class="btn btn-primary" runat="server" onserverclick="submitbtn">Submit</button>
              </div>
            </div>
          </div>
          <!-- /. box -->
        </div>
                </section>

</asp:Content>
