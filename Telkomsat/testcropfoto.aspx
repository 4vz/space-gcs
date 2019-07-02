<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testcropfoto.aspx.cs" Inherits="Telkomsat.testcropfoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/jquery.Jcrop.css" rel="stylesheet" />  
</head>
<body>
    <script src="js/jquery.min.js"></script>  
    <script src="js/jquery.Jcrop.js"></script>  
    <script type="text/javascript">  
        $(document).ready(function() {  
            $('#<%=cropimage1.ClientID%>').Jcrop({  
                onSelect: SelectCropArea  
            });  
        });  
  
        function SelectCropArea(c) {  
            $('#<%=coordinate_x.ClientID%>').val(parseInt(c.x));  
            $('#<%=coordinate_y.ClientID%>').val(parseInt(c.y));  
            $('#<%=coordinate_w.ClientID%>').val(parseInt(c.w));  
            $('#<%=coordinate_h.ClientID%>').val(parseInt(c.h));  
        }  
        </script>
    <form id="form1" runat="server">
        <div>
            <img src="image/full badan.jpg" id="cropimage1" runat="server" />
            <input type="hidden" id="coordinate_x" runat="server"/>
              <input type="hidden" id="coordinate_y" runat="server"/>
              <input type="hidden" id="coordinate_w" runat="server"/>
              <input type="hidden" id="coordinate_h" runat="server"/>
            <asp:Button ID="Button1" runat="server" Text="Crop" OnClick="Button1_Click" />
            <img src="" id="cropimg" runat="server" visible="false" />
        </div>
    </form>
</body>
</html>
