$(document).ready(function () {
    $('.Selector').select2();
    $('.gvdatatable').DataTable(
    {
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });

   


    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '< Ant',
        nextText: 'Sig >',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        weekHeader: 'Sm',
        dateFormat: 'yy/mm/dd',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };

    $('.datepicker').datepicker({
        dateFormat: "mm/dd/yy"
  

    });

    
    $.datepicker.setDefaults($.datepicker.regional['es']);
    var splitDataFechaPrimeraProrroga = $('.devolucion').val().split("/");
    var minDatePrimeraProrroga = new Date();

    if (splitDataFechaPrimeraProrroga.length > 1) {
        var day = parseInt(splitDataFechaPrimeraProrroga[0]) + 1;
        var month = parseInt(splitDataFechaPrimeraProrroga[1]) - 1;
        var year = splitDataFechaPrimeraProrroga[2];
        minDatePrimeraProrroga = new Date(year, month, day);
    }
   
    $('.campofecha').datepicker({
        minDate: new Date(year, month, day),
        dateFormat: "mm/dd/yy"
       

    });

    $('.campofecha1').datepicker({
        dateFormat: "mm/dd/yy",
        minDate:0

    });

    

    var splitDataFechaSegudaProrroga = $('.campofecha').val().split("/");
    var minDateSegundaProrroga = new Date();

    if (splitDataFechaSegudaProrroga.length > 1) {
        var day1 = parseInt(splitDataFechaSegudaProrroga[1]) + 1;
        var month1 = parseInt(splitDataFechaSegudaProrroga[0]) - 1;
        var year1 = splitDataFechaSegudaProrroga[2];
        minDateSegundaProrroga = new Date(year1, month1, day1);
        
      
    }

    $('.campofechaSegundaProrroga').datepicker({
        dateFormat: "mm/dd/yy",
        minDate: new Date(year1, month1, day1)
    });
});



function MensajeErrorExistencia() {
    Swal({
        type: 'error',
        title: 'Oops...',
        text: 'Cantidad no disponible, revisar la cantidad de este material y vuelva a intentarlo!',

    })
}
function MensajeErrorActualizarExistencia() {
        Swal({
            type: 'error',
            title: 'ERROR...',
            text: 'La cantidad que desea actualizar es menor a la que existe, recepcione los prestamos de este material o ingrese una cantidad mayor!',
    
        })
}

function MensajeErrorISBNExistente() {
    Swal({
        type: 'error',
        title: 'ERROR...',
        text: 'El ISBN asignado ya pertenece a un libro, verifique e intente nuevamente!',

    })
}

function ErrorEliminarMaterial() {
    Swal({
        type: 'error',
        title: 'ERROR...',
        text: 'Este registro de este material no puede ser eliminado porque se encuentra en prestamo',

    })
}
function ErrorFecha() {
    Swal({
        type: 'error',
        title: 'ERROR...',
        text: 'Ingrese la fecha de la prorroga',

    })
}

function MensajeError(Mensaje,Titulo) {
    Swal({
        type: 'error',
        title: Titulo,
        text:  Mensaje,

    })
}





function MensajeExito(Mensaje) {
        Swal({
            position: 'center',
            type: 'success',
            title: Mensaje,
            showConfirmButton: false,
            timer: 1500
        })
    }

function numeros(e) {
    var tecla = e.keyCode;

    if (tecla == 8 || tecla == 9 || tecla == 13) {
        return true;
    }

    var patron = /[0-9]/;
    var tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}