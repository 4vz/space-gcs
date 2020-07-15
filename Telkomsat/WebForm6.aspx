<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="Telkomsat.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>

<script type="text/javascript">

        var i = 1;

        $(document).ready(function() {
            $("#addfile").click(function () {
                var markup = "<tr><td><input name=" + i + "fu type=file /></td><td><input type='text' name='caption' class='form-control' /></td>" +
                    "<td> <button type='button' name='record' onclick='newtest2(this)' class='btn-sm btn-default delete-row'><i class=fa>X</i></button></td></tr>";
                $('#' + '<%= tableku.ClientID%>').append(markup);
                i++;
                console.log('add');
            });
        });      

</script>
    <title></title>
</head>

<body>

<form id="form1" runat="server" enctype="multipart/form-data">

<div id="dvfiles">

 <table class="table table-bordered kita" id="tableku" runat="server">
    <thead>
        <tr>
            <th>File</th>
            <th>Caption</th>
            <th>#</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>

</div>

<a href="#" id="addfile">Add file..</a><br />
<button id="addfile2">add</button><br />

<asp:Label ID="lblMessage" runat="server"></asp:Label><br />

<asp:Button ID="btnUpload" runat="server" Text="Upload"

        onclick="btnUpload_Click" />

    <div>
        <select id="sltest" runat="server" class="form-control">
            <option value="1">satu</option>
            <option value="2">dua</option>
            <option value="3">tiga</option>
        </select>
    </div>


    <script>
        $('#<%=sltest.ClientID %>').change(function () {
            console.log($('#<%=sltest.ClientID %> option:selected').text());
        });
    </script>
</form>
</body>
</html>
