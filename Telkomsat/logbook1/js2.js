function status(obj) {
    var selectbox = obj;
    var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
    if (obj.value == "Perbaikan") {
        document.getElementById('labelID').style.visibility = 'visible';
        document.getElementById('labelID1').style.visibility = 'visible';
        document.getElementById('labelID2').style.visibility = 'visible';
    }
    //alert(userinput);
    if (statuslogbook == "Perbaikan") {
        document.getElementById('labelID').style.visibility = 'visible';
        document.getElementById('labelID1').style.visibility = 'visible';
        document.getElementById('labelID2').style.visibility = 'visible';
        document.getElementById('lblsn').style.visibility = 'visible';
        document.getElementById('lblcari').style.visibility = 'visible';
    }
    else {
        document.getElementById('labelID').style.visibility = 'hidden';
        document.getElementById('labelID1').style.visibility = 'hidden';
        document.getElementById('labelID2').style.visibility = 'hidden';
        document.getElementById('lblsn').style.visibility = 'hidden';
        document.getElementById('lblcari').style.visibility = 'hidden';
    }
}

function btnsubmit() {
    var inp;
    var mylink = "http://home.aspx?tahun=" + inp;
    window.location.href = mylink;
}

