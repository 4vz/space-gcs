<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tes.aspx.cs" Inherits="Telkomsat.checklistme.week.tes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type='text/css'>
  #peta {
  width: 50%;
  height: 400px;

} </style>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBXJtWR3xFFcpCXG971HMX6zdCjm8BRHzU&libraries=places,geometry&v=3"></script>
   <script type="text/javascript">
       (function() {
  window.onload = function() {
var map;
    //Parameter Google maps
    var options = {
      zoom: 5, //level zoom
	  //posisi tengah peta
      center: new google.maps.LatLng(-1.104140,113.769642),
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
	
	 // Buat peta di 
    var map = new google.maps.Map(document.getElementById('peta'), options);
	 // Tambahkan Marker 
     var locations = [
               		    ['Telkom Cibinong', -6.4480592, 106.9362584],
                   		['Telkom Banjarmasin', -3.328096, 114.583624],
                   		['Telkom Manado', 1.4868708, 124.8432774],
                   		['Telkom Medan', 3.5827399, 98.6896095], 		
    
    ];
	  var infowindow = new google.maps.InfoWindow();

    var marker, i;
     /* kode untuk menampilkan banyak marker */
    for (i = 0; i < locations.length; i++) {  
      marker = new google.maps.Marker({
        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
        map: map,
		 icon: 'anten.png'
      });
     /* menambahkan event clik untuk menampikan
     	 infowindows dengan isi sesuai denga
	    marker yang di klik */
		
      google.maps.event.addListener(marker, 'click', (function(marker, i) {
        return function() {
          infowindow.setContent(locations[i][0]);
          infowindow.open(map, marker);
        }
      })(marker, i));
    }
  

  };
})();

	</script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="peta"></div>
    </form>
</body>
</html>
