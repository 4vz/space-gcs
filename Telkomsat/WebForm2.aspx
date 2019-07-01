<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Telkomsat.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>
        $(function () {
            $("#txtsdate").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                onClose: function (selectedDate) {
                    $("#txtedate").datepicker("option", "minDate", selectedDate);
                }
            });

            $("#txtedate").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                onClose: function (selectedDate) {
                    $("#txtsdate").datepicker("option", "maxDate", selectedDate);
                }

            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Start Date:<input type="text" id="txtsdate"/> End Date:<asp:TextBox ID="txtedate" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
