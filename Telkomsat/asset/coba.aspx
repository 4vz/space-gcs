<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coba.aspx.cs" Inherits="Telkomsat.asset.coba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../ChartJS.js"></script>
    <script src="chart.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="DropDownList1" runat="server" onChange="myNewFunction(this);">
            <asp:ListItem>BASEBAND</asp:ListItem>
            <asp:ListItem>RF EQUIPMENT</asp:ListItem>
            <asp:ListItem>BASEBAND</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" onChange="myNewFunction1(this);">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>UPCONVERTER</asp:ListItem>
            <asp:ListItem>DOWNCONVERTER</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" runat="server" onChange="myNewFunction1(this);" Visible="false">
            <asp:ListItem>Nama Equipment</asp:ListItem>
            <asp:ListItem>GPS</asp:ListItem>
            <asp:ListItem>GPS ANTENA</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnDDL" runat="server" Text="Button" OnClick="btnDDL_Click"/>
        <div>
            <h3>chart</h3>
            <asp:Literal ID="ltChart" runat="server"></asp:Literal> 
            <asp:Literal ID="ltChartKel" runat="server"></asp:Literal> 
        </div>
    </form>

    <script type="text/javascript">
        function myNewFunction1(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput == "DOWNCONVERTER" || userinput == "UPCONVERTER") {
                document.getElementById('<%=btnDDL.ClientID%>').click();
            }
        }
        function myNewFunction(object) {
            var userinput = object.options[object.selectedIndex].value;
            if (userinput == "BASEBAND" || userinput == "RF EQUIPMENT")
            {
                document.getElementById('<%=btnDDL.ClientID%>').click();
            }

            /*if (userinput == "RF EQUIPMENT") {
                // Create an Option object       
                var opt = document.createElement("option");        

                // Assign text and value to Option object
                opt.text = "New Value";
                opt.value = "New 23";

                // Add an Option object to Drop Down List Box
               
            /*}
            if (ddl1 == "RF EQUIPMENT") {
                var opt = document.createElement("option");        

                // Assign text and value to Option object
                opt.text = "New Value";
                opt.value = "New 23";

                // Add an Option object to Drop Down List Box
                document.getElementById('<//%=DropDownList2.ClientID%>').options.add(opt);
            }*/
        }

      
    </script>
</body>
</html>
