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
//            switch (Info) {
//                case 0:
//                    $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
//                    $('#MsjIncorrecto').modal('show');
//                    break;
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

$(function () {

    var calendarEl = document.getElementById('calendar');
    var Calendar = FullCalendar.Calendar;


    var calendar = new Calendar(calendarEl, {
        plugins: ['bootstrap', 'interaction', 'dayGrid', 'timeGrid', 'list'],
        defaultView: 'timeGridWeek',
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
        },
        minTime: "08:00:00",
        maxTime: "19:00:00",
        locale: 'es',
        editable: false,
        dateClick: function (info) {
            $('#TiempoFinal').val("");
            var FechaSeleccionada = moment(info.dateStr).format('YYYY-MM-DD[T]HH:mm:ss');
            $('#TiempoCita').val(FechaSeleccionada);
            $('#txtHorario').val(moment(info.dateStr).format('DD-MM-YYYY hh:mm A'));
            $('#txtHorarioOculta').val(info.dateStr);

            $('#NuevoEvento').modal();

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