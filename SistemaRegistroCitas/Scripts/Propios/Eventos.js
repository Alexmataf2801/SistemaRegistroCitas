//function InsertarEvento() {
//    var evento = {
//        IdUsuario: $(5).val(),
//        IdServicio: $("#Servicios").val(),
//        Estado: $(1).val(),
//        UsuarioCreacion: $("Jose").val(),
//        HorarioInicial: $("#txtHorario").val(),
//        HoraFinal: $("#TiempoFinal").val()
//    };

//    $.ajax({
//        type: "POST",
//        dataType: "JSON",
//        url: "/Evento/InsertarEvento/",
//        data: { evento },
//        success: function (Info) {
                //var EsValido = false
//            switch (info.str.day) {
//                case "Monday":
//                    var hora = "06:00"
                    //arreglo[0] = 06
                    //arreglo[1] = 00
 //                 if primer numero > 12
                        //primerNUmero > FinalLunes
                        //primerNUmero > InicioLunes
//                  EsValido = true
//                case 1:
//                    LimpiarValores();
//                    $('#fm-modal').modal('hide');
//                    $('#MsjCorreo').modal('show');
//                    break;
//                case 2:
//                    $("#msjModal").html("<label>¡La Identificación ingresada ya existe!</label>");
//                    $('#MsjIncorrecto').modal('show');
//                    break;
//                default:
//                    $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
//                    $('#MsjIncorrecto').modal('show');
//            }

//        },
//        error: function (Error) {
//            alert("Se Cayo");
//        }

//    });


//}

function Formato(ObjetoHora) {
    var Tamano = ObjetoHora.Minutes.toString().split('')
    if (Tamano.length > 1) {
        return ObjetoHora.Hours + ":" + ObjetoHora.Minutes;
    } else {
        if (parseInt(Tamano[0]) > 0) {
            return ObjetoHora.Hours + ":0" + ObjetoHora.Minutes;
        } else {
            return ObjetoHora.Hours + ":" + ObjetoHora.Minutes + "0";
        } 
    }
   

}


$(function () {

    var calendarEl = document.getElementById('calendar');
    var Calendar = FullCalendar.Calendar;

    var InicioLunes = '00:00'
    var FinalLunes = '00:00'

    var InicioMartes = '00:00'
    var FinalMartes = '00:00'

    var InicioMiercoles = '00:00'
    var FinalMiercoles = '00:00'

    var InicioJueves = '00:00'
    var FinalJueves = '00:00'

    var InicioViernes = '00:00'
    var FinalViernes = '00:00'

    var InicioSabado = '00:00'
    var FinalSabado = '00:00'

    var InicioDomingo = '00:00'
    var FinalDomingo = '00:00'


    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Empresa/ObtenerHorarioEmpresa/",
        async: false,
        success: function (Info) {

            InicioLunes = Formato(Info.InicioLunes);
            FinalLunes = Formato(Info.FinalLunes);

            InicioMartes = Formato(Info.InicioMartes);
            FinalMartes = Formato(Info.FinalMartes);

            InicioMiercoles = Formato(Info.InicioMiercoles);
            FinalMiercoles = Formato(Info.FinalMiercoles);

            InicioJueves = Formato(Info.InicioJueves);
            FinalJueves = Formato(Info.FinalJueves)

            InicioViernes = Formato(Info.InicioViernes);
            FinalViernes = Formato(Info.FinalViernes);

            InicioSabado = Formato(Info.InicioSabado);
            FinalSabado = Formato(Info.FinalSabado);

            InicioDomingo = Formato(Info.InicioDomingo);
            FinalDomingo = Formato(Info.FinalDomingo);
        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });

  

    var calendar = new Calendar(calendarEl, {
        plugins: ['bootstrap', 'interaction', 'dayGrid', 'timeGrid', 'list'],
        defaultView: 'timeGridWeek',
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'timeGridWeek,timeGridDay,listWeek'
        },

        
        businessHours: [ // specify an array instead 
            {
                daysOfWeek: [1], //Lunes
                startTime: InicioLunes, // 8am
                endTime: FinalLunes // 6pm
            },
            {
                daysOfWeek: [2], // Martes
                startTime: InicioMartes, // 10am
                endTime: FinalMartes // 4pm
            },
            {
                daysOfWeek: [3], // Miercoles
                startTime: InicioMiercoles, // 10am
                endTime: FinalMiercoles // 4pm
            },
            {
                daysOfWeek: [4], // Jueves
                startTime: InicioJueves, // 10am
                endTime: FinalJueves // 4pm
            },
            {
                daysOfWeek: [5], // Viernes
                startTime: InicioViernes, // 10am
                endTime: FinalViernes // 4pm
            },
            {
                daysOfWeek: [6], // Sabado
                startTime: InicioSabado, // 10am
                endTime: FinalSabado // 4pm
            },
            {
                daysOfWeek: [0], // Domingo
                startTime: InicioDomingo, // 10am
                endTime: FinalDomingo // 4pm
            },
        ],


        //minTime: "08:00:00",
        //maxTime: "19:00:00",
        locale: 'es',
        editable: false,
        dateClick: function (info) {
            // Obtener que dia esta seleccionando la persona
            // Obtengo la hora que esta seleccionado la persona
            // Valido que la hora seleccionada no sea menor o mayor al horario del dia.
            if (1 < 0) {

                $('#TiempoFinal').val("");
                var FechaSeleccionada = moment(info.dateStr).format('YYYY-MM-DD[T]HH:mm:ss');
                $('#TiempoCita').val(FechaSeleccionada);
                $('#txtHorario').val(moment(info.dateStr).format('DD-MM-YYYY hh:mm A'));
                $('#txtHorarioOculta').val(info.dateStr);

                $('#NuevoEvento').modal();
            } else {
                alert("La hora seleccionada no es valida por el horario de la empresa")
            }

            

        },
        eventClick: function (info) {
            $('#NuevoEvento').modal();
        }
        //events: [
        //    {
        //        title: 'Prueba',
        //        start: $("#TiempoCita").val(),//'2020-02-17T14:30:00',//new Date(y, m, 1),
        //        backgroundColor: '#f56954', //red
        //        borderColor: '#f56954', //red
        //        allDay: false
        //    }

        //]
    });

    calendar.render();



    $('#btnReservar').on('click', function (e) {
        e.preventDefault();

        doSubmit();
    });

    function doSubmit() {
        $("#NuevoEvento").modal('hide');

        calendar.addEvent({
            title: $("#Servicios option:selected").text(),
            start: $("#TiempoCita").val(),
            end: $("#txtFinalHorarioOculto").val(),
            //allDay: true,
        });

    }



})