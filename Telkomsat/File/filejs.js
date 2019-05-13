function kategori1(obj) {
    var selectbox = obj;
    var userinput = selectbox.options[selectbox.selectedIndex].value;
    //alert(userinput);
    if (userinput == "Buku Manual") {
        document.getElementById('trawal').style.display = 'none';
        document.getElementById('trBuku').style.display = 'table-row';
        document.getElementById('trBukuEquipment').style.display = 'table-row';
        document.getElementById('trSOP').style.display = 'none';
        document.getElementById('trPelatihan').style.display = 'none';
        document.getElementById('trPelatihanSatelit').style.display = 'none';
        document.getElementById('trPembaruan1').style.display = 'none';
        document.getElementById('trPembaruanOp').style.display = 'none';
        document.getElementById('trPembaruanOp1').style.display = 'none';
        document.getElementById('trPembaruanNe').style.display = 'none';
    }
    else if (userinput == "SOP"){
        document.getElementById('trawal').style.display = 'none';
        document.getElementById('trBuku').style.display = 'none';
        document.getElementById('trBukuEquipment').style.display = 'none';
        document.getElementById('trSOP').style.display = 'table-row';
        document.getElementById('trPelatihan').style.display = 'none';
        document.getElementById('trPelatihanSatelit').style.display = 'none';
        document.getElementById('trPembaruan1').style.display = 'none';
        document.getElementById('trPembaruanOp').style.display = 'none';
        document.getElementById('trPembaruanOp1').style.display = 'none';
        document.getElementById('trPembaruanNe').style.display = 'none';
    }
    else if (userinput == "Pelatihan") {
        document.getElementById('trawal').style.display = 'none';
        document.getElementById('trBuku').style.display = 'none';
        document.getElementById('trBukuEquipment').style.display = 'none';
        document.getElementById('trSOP').style.display = 'none';
        document.getElementById('trPelatihan').style.display = 'table-row';
        document.getElementById('trPelatihanSatelit').style.display = 'table-row';
        document.getElementById('trPembaruan1').style.display = 'none';
        document.getElementById('trPembaruanOp').style.display = 'none';
        document.getElementById('trPembaruanOp1').style.display = 'none';
        document.getElementById('trPembaruanNe').style.display = 'none';
    }
    else if (userinput == "Pembaruan Konfigurasi") {
        document.getElementById('trawal').style.display = 'none';
        document.getElementById('trBuku').style.display = 'none';
        document.getElementById('trBukuEquipment').style.display = 'none';
        document.getElementById('trSOP').style.display = 'none';
        document.getElementById('trPelatihan').style.display = 'none';
        document.getElementById('trPelatihanSatelit').style.display = 'none';
        document.getElementById('trPembaruan1').style.display = 'table-row';
        document.getElementById('trPembaruanOp').style.display = 'none';
        document.getElementById('trPembaruanOp1').style.display = 'none';
        document.getElementById('trPembaruanNe').style.display = 'none';
    }
    else {
        document.getElementById('trawal').style.display = 'table-row';
        document.getElementById('trBuku').style.display = 'none';
        document.getElementById('trBukuEquipment').style.display = 'none';
        document.getElementById('trSOP').style.display = 'none';
        document.getElementById('trPelatihan').style.display = 'none';
        document.getElementById('trPelatihanSatelit').style.display = 'none';
        document.getElementById('trPembaruan1').style.display = 'none';
        document.getElementById('trPembaruanOp').style.display = 'none';
        document.getElementById('trPembaruanOp1').style.display = 'none';
        document.getElementById('trPembaruanNe').style.display = 'none';
    }
}

function pembaruan(obj) {
    var selectbox = obj;
    var userinput = selectbox.options[selectbox.selectedIndex].value;
    //alert(userinput);
    if (userinput == "Operasional") {
        document.getElementById('trPembaruanOp').style.display = 'table-row';
        document.getElementById('trPembaruanOp1').style.display = 'table-row';
        document.getElementById('trPembaruanNe').style.display = 'none';
    }
    else if (userinput == "Network") {
        document.getElementById('trPembaruanOp').style.display = 'none';
        document.getElementById('trPembaruanOp1').style.display = 'none';
        document.getElementById('trPembaruanNe').style.display = 'table-row';
    }
    else {
        document.getElementById('trPembaruanOp').style.display = 'none';
        document.getElementById('trPembaruanOp1').style.display = 'none';
        document.getElementById('trPembaruanNe').style.display = 'none';
    }
}

