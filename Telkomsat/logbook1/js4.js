function status(obj) {
    var selectbox = obj;
    var statuslogbook = selectbox.options[selectbox.selectedIndex].value;
    //alert(userinput);
    if (statuslogbook == "Perawatan" || statuslogbook == "Perbaikan") {
        document.getElementById('labelID').style.visibility = 'visible';
        document.getElementById('labelID1').style.visibility = 'visible';
        document.getElementById('labelID2').style.visibility = 'visible'; 
        document.getElementById('trPergantian').style.display = 'none';
        document.getElementById('lblestimasi').style.visibility = 'visible';
        //alert("bisa");
    }
    else if (statuslogbook == "Pointing Antena") {
        document.getElementById('labelID').style.visibility = 'hidden';
        document.getElementById('labelID1').style.visibility = 'hidden';
        document.getElementById('labelID2').style.visibility = 'hidden';
        document.getElementById('lblestimasi').style.visibility = 'hidden';
        document.getElementById('trPergantian').style.display = 'none';
    }
    else if (statuslogbook == "Penggantian") {
        //alert("bisa");
        document.getElementById('labelID').style.visibility = 'hidden';
        document.getElementById('labelID1').style.visibility = 'hidden';
        document.getElementById('labelID2').style.visibility = 'hidden';
        document.getElementById('lblestimasi').style.visibility = 'hidden';
        document.getElementById('trPergantian').style.display = 'table-row';
    }
    else if (statuslogbook == "Lain-lain") {
        document.getElementById('labelID').style.visibility = 'hidden';
        document.getElementById('labelID1').style.visibility = 'hidden';
        document.getElementById('labelID2').style.visibility = 'hidden';
        document.getElementById('lblestimasi').style.visibility = 'hidden';
        document.getElementById('trPergantian').style.display = 'none';
    }
}

function validate() {
    var check = document.getElementById("checkbox1").checked;

    if (check != "") {
        document.getElementById('trEstimasi').style.display = 'table-row';
    }
    else {
        document.getElementById('trEstimasi').style.display = 'none';
    }
}