<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cobafile.aspx.cs" Inherits="Telkomsat.knowledge.cobafile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:FileUpload ID="fuimage" runat="server"></asp:FileUpload>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUploadImage" runat="server" Text="Upload"
                               OnClick="btnUploadImage_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdBindFiles" runat="server" AutoGenerateColumns="False" >
                            <Columns>
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="linkDownloadFile_Click" CommandArgument='<%#Eval("ID") %>' Text='<%# Eval("NameFile") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
 
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkDownloadFile" runat="server" Text="Download" OnClick="linkDownloadFile_Click" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
 
                            </Columns>
                            </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
