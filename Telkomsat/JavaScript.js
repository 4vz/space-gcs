function GetTeamUsersByTeamID(obj) {
    var selectbox = obj;
    var userinput = selectbox.options[selectbox.selectedIndex].value;
    //alert(userinput);
    if (userinput == "CBI" || userinput == "BJR") {
        document.getElementById('gudang').style.visibility = 'visible';
        document.getElementById('rak').style.visibility = 'visible';
    }
    else {
        document.getElementById('gudang').style.visibility = 'hidden';
        document.getElementById('rak').style.visibility = 'hidden';
    }
}

function btnsubmit(){
    var inp;
    var mylink = "http://home.aspx?tahun=" + inp;
    window.location.href = mylink;
}

