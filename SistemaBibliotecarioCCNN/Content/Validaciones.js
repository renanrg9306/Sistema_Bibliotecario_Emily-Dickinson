//$(document).ready(function () {
//    $('.Fecha1').datepicker({
//        dateFormat: "mm/dd/yy",
//        minDate: 0
//    });
//});

function ValidarNumero(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == 48 || charCode == 49 || charCode == 50 || charCode == 51 || charCode == 52 || charCode == 53 || charCode == 54 || charCode == 55 || charCode == 56 || charCode == 57) {
        return true;
    }
    else {
        return false;
    }
}

function ValidarLetra(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode >=65 && charCode<=90)||(charCode>=97 && charCode<=122)||(charCode==241||charCode==209||charCode==32 || charCode==180 || charCode==232)) {
        return true;
    }
    else {
        return false;
    }
}

function Letras(nombre) {
    let regex = /^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$/g;
    return regex.exec(nombre)[0];

}


function toUpper(control) {
    if (/[a-z]/.test(control.value)) {
        control.value = control.value.toUpperCase();
    }
}



function ucwords(oracion) {
    oracion.value = oracion.value.replace(/^([a-z\u00E0-\u00FC])|\s+([a-z\u00E0-\u00FC])/g, function ($1) {
        return $1.toUpperCase();
    });
}




function Search_Gridview(strKey, strGV) {
        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById(strGV);
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }
    }    

function MensajeError(Mensaje,Titulo) {
    Swal({
        type: 'error',
        title: Titulo,
        text:  Mensaje,

    })
}

//function DatosUsuariosNoEncontrados() {
//    Swal({
//        type: 'error',
//        title: 'ERROR...',
//        text: 'Los datos proporcionados no corresponde a ningún usuario en la base de datos',

//    })
//}

function CorreoEnviado() {
    Swal.fire({
        position: 'center',
        type: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 1500
    })

}


