<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="importrkap.aspx.cs" Inherits="Telkomsat.admin.importrkap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <asp:Label ID="lblerror" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
            <br />
            <b>Upload file excel dibawah </b>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button Text="Upload" OnClick="Upload" runat="server" />
        </div>
        <div class="col-lg-6">
            <asp:Button Text="Upload Format Baru" class="btn btn-sm btn-primary pull-right" OnClick="UploadFormat" runat="server" Visible="false" ID="btnupload" />
            <asp:FileUpload ID="FileUpload2" Visible="false" runat="server" class="pull-right" />

            <br />
            <b>Download file excel untuk melihat format </b>
            <br />
            <br />
            <asp:GridView ID="DataList3a" runat="server" AutoGenerateColumns="False" style="margin:0;" Font-Size="13px" BackColor="White"
                BorderColor="White" BorderStyle="None" BorderWidth="0px" Visible="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="File">
                        <ItemTemplate>
                            <span class="fa fa-check" style="width:20px"></span>
                            <asp:LinkButton ID ="InkView" runat ="server" CssClass="rows" CommandArgument='<%# Eval("AE_NamaFile") %>' CommandName="Download" Text='<%# Eval("AE_NamaFile") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField ="AE_Caption" HeaderText="Deskripsi" ItemStyle-Width="200px" ItemStyle-CssClass="rows"/>
                    </Columns>
            <RowStyle BackColor="White" ForeColor="#1b1b1b" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
