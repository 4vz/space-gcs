function status(obj) {
    var selectbox = obj;
    var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
    //alert(userinput);
    if (statuslogbook == "Perawatan" || statuslogbook == "Perbaikan") {
        document.getElementById('labelID').style.visibility = 'visible';
        document.getElementById('labelID1').style.visibility = 'visible';
        document.getElementById('labelID2').style.visibility = 'visible';
        document.getElementById('lblsn').style.visibility = 'visible';
        document.getElementById('lblcari').style.visibility = 'visible';
        document.getElementById('trPergantian').style.display = 'none';
        //alert("bisa");
    }
    else if (statuslogbook == "Pointing") {
        alert(userinput);
        document.getElementById('labelID').style.visibility = 'hidden';
        document.getElementById('labelID1').style.visibility = 'hidden';
        document.getElementById('labelID2').style.visibility = 'hidden';
        document.getElementById('lblsn').style.visibility = 'hidden';
        document.getElementById('lblcari').style.visibility = 'hidden';
        document.getElementById('trPergantian').style.display = 'table-row';
    }
    else if (statuslogbook == "Penggantian") {
        //alert("bisa");
        document.getElementById('labelID').style.visibility = 'hidden';
        document.getElementById('labelID1').style.visibility = 'hidden';
        document.getElementById('labelID2').style.visibility = 'hidden';
        document.getElementById('lblsn').style.visibility = 'hidden';
        document.getElementById('lblcari').style.visibility = 'hidden';
        document.getElementById('trPergantian').style.display = 'table-row';
    }
    else {
        document.getElementById('labelID').style.visibility = 'hidden';
        document.getElementById('labelID1').style.visibility = 'hidden';
        document.getElementById('labelID2').style.visibility = 'hidden';
        document.getElementById('lblsn').style.visibility = 'hidden';
        document.getElementById('lblcari').style.visibility = 'hidden';
        document.getElementById('trPergantian').style.display = 'none';
    }
}

function btnsubmit() {
    var inp;
    var mylink = "http://home.aspx?tahun=" + inp;
    window.location.href = mylink;
}