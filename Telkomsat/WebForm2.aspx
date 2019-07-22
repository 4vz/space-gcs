<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Telkomsat.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/AdminLTE.min.css" rel="stylesheet" />
    <link href="../assets/plugins/AdminLTE/skins/_all-skins.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <link href="../Style2.css?version=1" rel="stylesheet" />
    <link href="../Style1.css" rel="stylesheet" />
    <script src="../assets/plugins/AdminLTE/js/adminlte.min.js"></script>
    <script src="../assets/plugins/AdminLTE/js/demo.js"></script>
    <script src="../assets/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../assets/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
   <script>
        $(function () {
            $("#txtttl").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                onClose: function (selectedDate) {
                    $("#txtttl").datepicker("option", "minDate", selectedDate);
                }
            });
       })

        var items = document.querySelectorAll("#list li");
            
       for (var i = 0; i < items.length; i++) {
           items[i].onclick = function () {

               document.getElementById("txtLokasi").value = this.innerHTML;

           };
       }

    </script>
</head>
<body>
<form id="form1" runat="server">
        <!-- Button Modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalButton">
  Klick mich
</button>
<!-- Modal -->
<div class="modal fade" id="exampleModalButton" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content" style="height:400px;">
       <div class="modal-header" style="background-color:orangered">
                <button type="button" class="close" data-dismiss="modal">
                    &times;
                </button>
                <h4 class="modal-title">Tambah Event</h4>
            </div>
      <div class="modal-body">
          <div class="divtabel">
          <table align="center">
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Pilih Icon</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;" colspan="5">
                      <div class="select-sim" id="select-color">
                          <div class="options">
                            <div class="option">
                              <input type="radio" name="icon" value="sport" id="color-" />
                              <label for="color-">
                                <img src="img/sport.png" alt="" width="20" height="20" /> Olahraga
                              </label>
                            </div>
                            <div class="option">
                              <input type="radio" name="icon" value="rapat" id="color-red" />
                              <label for="color-red">
                                <img src="img/meeting.png" alt="" width="20" height="20" /> Rapat
                              </label>
                            </div>
                            <div class="option">
                              <input type="radio" name="icon" value="makan" id="color-green" />
                              <label for="color-green">
                                <img src="img/makan.png" alt="" width="20" height="20" /> Makan-makan
                              </label>
                            </div>
                            <div class="option">
                              <input type="radio" name="icon" value="holiday" id="color-blue" />
                              <label for="color-blue">
                                <img src="img/holiday.jpg" alt="" width="20" height="20" /> Liburan
                              </label>
                            </div>
                              </div>
                          </div>

                  </td>
              </tr>
              <tr>
                  <td style="text-align:right; vertical-align:text-top; padding-bottom:15px;">
                      <label>Nama Event</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;"" colspan="3">
                      <asp:TextBox ID="txtEven" class="tb1" runat="server" Width="300px" TextMode="MultiLine" Height="60px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Lokasi</label>
                  </td>
                  <td colspan="3" style="padding-left:40px; padding-bottom:15px;"">
                      <asp:TextBox ID="txtLokasi" class="tb1" runat="server" Width="300px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Tanggal</label>
                  </td>
                  <td style="padding-left:40px; padding-bottom:15px;">
                      <input type="text" id="txtttl" runat="server" class="tb1" onkeypress="return runScript(event)" />
                      
                  </td>
                  <td style="padding-bottom:15px;">
                      <asp:DropDownList ID="DropDownList1" runat="server" class="ddl3" Width="70px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>00:00</asp:ListItem>
                        <asp:ListItem>00:30</asp:ListItem>
                        <asp:ListItem>01:00</asp:ListItem>
                        <asp:ListItem>01:30</asp:ListItem>
                        <asp:ListItem>02:00</asp:ListItem>
                        <asp:ListItem>02:30</asp:ListItem>
                        <asp:ListItem>03:00</asp:ListItem>
                        <asp:ListItem>03:30</asp:ListItem>
                        <asp:ListItem>04:00</asp:ListItem>
                        <asp:ListItem>04:30</asp:ListItem>
                        <asp:ListItem>05:00</asp:ListItem>
                        <asp:ListItem>05:30</asp:ListItem>
                        <asp:ListItem>06:00</asp:ListItem>
                        <asp:ListItem>06:30</asp:ListItem>
                        <asp:ListItem>07:00</asp:ListItem>
                        <asp:ListItem>07:30</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>08:30</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>09:30</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>12:30</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>13:30</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>14:30</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>15:30</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>16:30</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>17:30</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>18:30</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>19:30</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>20:30</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>21:30</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>22:30</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                        <asp:ListItem>23:30</asp:ListItem>

                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td  style="text-align:right; padding-bottom:15px;">
                      <label style="text-align:right">Penyelenggara</label>
                  </td>
                  <td colspan="3" style="padding-left:40px; padding-bottom:15px;"">
                      <asp:TextBox ID="TextBox1" class="tb1" runat="server" Width="300px"></asp:TextBox>
                  </td>
              </tr>
          </table>
              </div>
        </div>

      </div>
      <div class="modal-footer">
          <asp:Button runat="server" OnClick="btnSubmit_Click" Text="submit" class="btn btn-primary" />
        <!-- <button type="button" class="btn btn-primary">Button</button> -->
      </div>
    </div>
  </div>

    </form>
</body>
</html>
