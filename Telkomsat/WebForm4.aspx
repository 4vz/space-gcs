<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Telkomsat.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="//tinymce.cachefly.net/4.0/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({ selector: 'textarea', width: 500 });
    </script>
    <link href="./assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="./assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="./assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="./assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link href="./assets/plugins/pace/pace.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="./assets/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"/>
    <link href="./assets/css/style.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="./assets/bower_components/select2/dist/css/select2.min.css">
    
</head>
<body>
    <form id="form1" runat="server">
    <div id = "dvCustomers">
    <table class="tblCustomer" cellpadding="2" cellspacing="0" border="1">
    <tr>
        <th>
            <b><u><span class="name"></span></u></b>
        </th>
    </tr>
    <tr>
        <td>
            <b>City: </b><span class="city"></span><br />
            <b>Postal Code: </b><span class="postal"></span><br />
            <b>Country: </b><span class="country"></span><br />
        </td>
    </tr>
</table>
</div>
        <div id="dropdown">
            <select id="so2" class="form-control select2" runat="server">
                <option></option>
            </select>
            <select id="so1" class="form-control select2" runat="server">
                <option></option>
                <option></option>
            </select>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- Select2 -->
<script src="../assets/bower_components/select2/dist/js/select2.full.min.js"></script>
<script type="text/javascript">
    $(function () {
       /* $.ajax({
            type: "POST",
            url: "WebForm4.aspx/GetCustomers",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });*/
        $('.select2').select2({
             allowClear:true,
             placeholder: "--Wilayah--",
             });

        $.ajax({
            type: "POST",
            url: "WebForm4.aspx/GetID",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var customers = response.d;
                $('#<%=so2.ClientID %>').empty();
                $(customers).each(function () {
                    console.log(this.idperangkat);
                    $('#<%=so2.ClientID %>').append('<option value="' + this.idperangkat + '">' + this.idperangkat + '</option>');
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
    $('#<%=so2.ClientID %>').change(function () {
        $('#<%=so1.ClientID %>').empty();
        var id = $(this).val();
        $.ajax({
            type: "POST",
            url: "WebForm4.aspx/GetCustomers",
            contentType: "application/json; charset=utf-8",
            data: '{videoid:"' + id + '"}',
            dataType: "json",
            success: function (response) {
                var customers = response.d;
                $('#<%=so1.ClientID %>').append('<option>' + '</option>');
                $(customers).each(function () {
                    console.log(this.idperangkat);
                    $('#<%=so1.ClientID %>').append('<option value="' + this.City + '">' + this.City + '</option>');
                });
            },
            failure: function (response) {
                
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    })

 
    function OnSuccess(response) {
        var table = $("#dvCustomers table").eq(0).clone(true);
        
        var customers = response.d;
        console.log(customers);
        /*$("#dvCustomers table").eq(0).remove();
        $(customers).each(function () {
            $(".name", table).html(this.CustomerId);
            $(".city", table).html(this.ContactName);
            $(".postal", table).html(this.City);
            $(".country", table).html(this.Country);
            $("#dvCustomers").append(table).append("<br />");
            table = $("#dvCustomers table").eq(0).clone(true);
        });*/
        $('#<%=so1.ClientID %>').empty();
        $(customers).each(function () {
            console.log(this.City);
            $('#<%=so1.ClientID %>').append('<option value="' + this.CustomerId + '">' + this.City + '</option>');
        });

        
    }
</script>
</body>
</html>