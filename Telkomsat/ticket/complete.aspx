﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TICKETMASTER.Master" AutoEventWireup="true" CodeBehind="complete.aspx.cs" Inherits="Telkomsat.ticket.complete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-9">
        <div class="box box-primary">
        <div class="box-header with-border">
            <h3 class="box-title">Ticket</h3>
            <!-- /.box-tools -->
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="table-responsive mailbox-messages">
            <div class="table table-responsive">
                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    </div>
            <!-- /.table -->
            </div>
            <!-- /.mail-box-messages -->
        </div>
        <div class="box-footer no-padding">
            <div class="mailbox-controls">
            <div class="btn-group">
                <button type="button" id="dispdelete" class=" btn btn-default btn-sm"><i class="fa fa-trash-o"></i> Delete</button>
            </div>
            <!-- /.btn-group -->
            <button type="button" id="disp" class=" btn btn-default btn-sm"><i class="fa fa-star"></i> Favorit</button>
            <!-- /.pull-right -->
            </div>
        </div>
        <!-- /.box-body -->
        </div>
        <!-- /. box -->
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <input type="button" value="display" id="disp1" runat="server" onserverclick="disp_ServerClick" style="visibility:hidden"/>
    <input type="button" value="display" id="dispdelete1" runat="server" onserverclick="dispdelete_ServerClick" style="visibility:hidden;"/>

    <!-- /.col -->
    
    <script type="text/javascript">
       $(function () {
          $("#example2").DataTable({
          "paging": true,
          "searching": true,
          "info": true,
              "autoWidth": true,
              "ordering": false,
          "scrollX": true
          });
           $('.dataTables_length').addClass('bs-select');
        });


        $('#disp').click(function () {
            var arrayid = [];
            var hf = document.getElementById('<%= HiddenField1.ClientID%>');
            var buttondisp = document.getElementById('<%= disp1.ClientID%>');
            $(".chkCheckBoxId:checked").each(function () {               
                arrayid.push($(this).val());     
            });
            console.log(arrayid);
            hf.value = arrayid;
            buttondisp.click();
        });

        $('#dispdelete').click(function () {
            var arrayid = [];
            var hf = document.getElementById('<%= HiddenField1.ClientID%>');
            var buttondisp = document.getElementById('<%= dispdelete1.ClientID%>');
            $(".chkCheckBoxId:checked").each(function () {               
                arrayid.push($(this).val());     
            });
            console.log(arrayid);
            hf.value = arrayid;
            buttondisp.click();
        });
    </script>
</asp:Content>
