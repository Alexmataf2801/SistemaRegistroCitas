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



//function FormatoHorasDias(ObjetoHora) {
//    var ArregloTiempo = ObjetoHora.Hours.toString().split('')
    
//    if (ArregloTiempo.length > 1) {
//        return ArregloTiempo[0] + ArregloTiempo[1];
//    } else {
//        return "0" + ArregloTiempo[0]   
//    }
//}

//function FormatoMinutosDias(ObjetoMinuto) {
//    var ArregloTiempo = ObjetoMinuto.Minutes.toString().split('')

//    if (ArregloTiempo.length > 1) {
//        return ArregloTiempo[0] + ArregloTiempo[1];
//    } else {
//        return "0" + ArregloTiempo[0]
//    }
//}


function FormatoTiempo(ObjetoTiempo) {
    var Hora = ""
    var Minuto = ""

    var ArregloTiempoH = ObjetoTiempo.Hours.toString().split('')

    if (ArregloTiempoH.length > 1) {
        Hora = ArregloTiempoH[0] + ArregloTiempoH[1];
    } else {
        Hora = "0" + ArregloTiempoH[0]
    }

    var ArregloTiempoM = ObjetoTiempo.Minutes.toString().split('')

    if (ArregloTiempoM.length > 1) {
        Minuto = ArregloTiempoM[0] + ArregloTiempoM[1];
    } else {
        Minuto = "0" + ArregloTiempoM[0]
    }

    return Hora + ":" + Minuto
}


function FormatoHoras(ObjetoHoras) {
    var Tamanos = ObjetoHoras
    if (Tamanos < 10) {
        return "0" + ObjetoHoras;
    } else {
        return ObjetoHoras
    }

}

function FormatoMinutos(ObjetoMinutos) {
    var Tamanos = ObjetoMinutos
    if (Tamanos < 10) {
        return ObjetoMinutos + "0" ;
    } else {
        return ObjetoMinutos
    }

}


$(function () {

    var calendarEl = document.getElementById('calendar');
    var Calendar = FullCalendar.Calendar;

    var hiddenDays = [];

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

            InicioLunes = FormatoTiempo(Info.InicioLunes);               
            FinalLunes = FormatoTiempo(Info.FinalLunes);      
            EstadoLunes = Info.EstadoLunes

            if (EstadoLunes == false) {
                hiddenDays.push(1);
            }

            InicioMartes = FormatoTiempo(Info.InicioMartes);            
            FinalMartes = FormatoTiempo(Info.FinalMartes)                          
            EstadoMartes = Info.EstadoMartes

            if (EstadoMartes == false) {
                hiddenDays.push(2);
            }

            InicioMiercoles = FormatoTiempo(Info.InicioMiercoles);                
            FinalMiercoles = FormatoTiempo(Info.FinalMiercoles);                        
            EstadoMiercoles = Info.EstadoMiercoles

            if (EstadoMiercoles == false) {
                hiddenDays.push(3);
            }
            InicioJueves = FormatoTiempo(Info.InicioJueves);               
            FinalJueves = FormatoTiempo(Info.FinalJueves);                        
            EstadoJueves = Info.EstadoJueves

            if (EstadoJueves == false) {
                hiddenDays.push(4);
            }

            InicioViernes = FormatoTiempo(Info.InicioViernes);             
            FinalViernes = FormatoTiempo(Info.FinalViernes);                          
            EstadoViernes = Info.EstadoViernes

            if (EstadoViernes == false) {
                hiddenDays.push(5);
            }
            InicioSabado = FormatoTiempo(Info.InicioSabado);                
            FinalSabado = FormatoTiempo(Info.FinalSabado);                      
            EstadoSabado = Info.EstadoSabado

            if (EstadoSabado == false) {
                hiddenDays.push(6);
            }

            InicioDomingo = FormatoTiempo(Info.InicioDomingo);                
            FinalDomingo = FormatoTiempo(Info.FinalDomingo);                         
            EstadoDomingo = Info.EstadoDomingo

            if (EstadoDomingo == false) {
                hiddenDays.push(0);
            }
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
             
        hiddenDays: hiddenDays,          
        
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


       
        locale: 'es',
        editable: false,
        dateClick: function (info) {        

            $('#TiempoFinal').val("");
            var FechaSeleccionada = moment(info.dateStr).format('YYYY-MM-DD[T]HH:mm:ss');
            $('#TiempoCita').val(FechaSeleccionada);
            $('#txtHorario').val(moment(info.dateStr).format('DD-MM-YYYY hh:mm A'));
            $('#txtHorarioOculta').val(info.dateStr);

            var FechaCompletaSeleccioada = new Date(FechaSeleccionada);
      
            
            //Fecha = FechaCompletaSeleccioada.getDate();            
            //Mes = FechaCompletaSeleccioada.getMonth();
            //Año = FechaCompletaSeleccioada.getFullYear();

            // HoraSeleccionada
            Dia = FechaCompletaSeleccioada.getDay();
            HoraSeleccionada = FechaCompletaSeleccioada.getHours();
            MinutosSeleccionados = FechaCompletaSeleccioada.getMinutes();         
            HoraTotalSeleccionada = FormatoHoras(HoraSeleccionada) + ":" + FormatoMinutos(MinutosSeleccionados)  
            
            if ($("#Colaboradores").val() == "0") {
                $("#msjModalIncorrecto").html("<label>¡No se ha seleccionado un colaborador!</label>");
                $('#MsjIncorrecto').modal('show');
            } else {
            switch (Dia) {

                case 0:
                    if (InicioDomingo <= HoraTotalSeleccionada) {
                        if (FinalDomingo > HoraTotalSeleccionada) {
                            $('#NuevoEvento').modal();
                        } else {
                            $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                            $('#MsjIncorrecto').modal('show');
                        }

                    } else {
                        $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                        $('#MsjIncorrecto').modal('show');
                    }
                    break;
                case 1:
                    if (InicioLunes <= HoraTotalSeleccionada) {
                        if (FinalLunes > HoraTotalSeleccionada) {
                            $('#NuevoEvento').modal();
                        } else {
                            $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                            $('#MsjIncorrecto').modal('show');
                        }                      

                    } else {
                        $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                        $('#MsjIncorrecto').modal('show');
                    }
                    break;
                case 2:
                    if (InicioMartes <= HoraTotalSeleccionada) {
                        if (FinalMartes > HoraTotalSeleccionada) {
                                $('#NuevoEvento').modal();
                            } else {
                                $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                                $('#MsjIncorrecto').modal('show');
                            }

                        } else {
                            $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                            $('#MsjIncorrecto').modal('show');
                        }
                        break;
                case 3:
                    if (InicioMiercoles <= HoraTotalSeleccionada) {
                        if (FinalMiercoles > HoraTotalSeleccionada) {
                            $('#NuevoEvento').modal();
                        } else {
                            $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                            $('#MsjIncorrecto').modal('show');
                        }

                    } else {
                        $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                        $('#MsjIncorrecto').modal('show');
                    }
                    break;
                case 4:
                    if (InicioJueves <= HoraTotalSeleccionada) {
                        if (FinalJueves > HoraTotalSeleccionada) {
                            $('#NuevoEvento').modal();
                        } else {
                            $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                            $('#MsjIncorrecto').modal('show');
                        }

                    } else {
                        $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                        $('#MsjIncorrecto').modal('show');
                    }
                    break;
                case 5:
                    if (InicioViernes <= HoraTotalSeleccionada) {
                        if (FinalViernes > HoraTotalSeleccionada) {
                            $('#NuevoEvento').modal();
                        } else {
                            $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                            $('#MsjIncorrecto').modal('show');
                        }

                    } else {
                        $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                        $('#MsjIncorrecto').modal('show');
                    }
                    break;
                case 6:
                    if (InicioSabado <= HoraTotalSeleccionada) {
                        if (FinalSabado > HoraTotalSeleccionada) {
                            $('#NuevoEvento').modal();
                        } else {
                            $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                            $('#MsjIncorrecto').modal('show');
                        }

                    } else {
                        $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                        $('#MsjIncorrecto').modal('show');
                    }
                    break;

                default:
                    $("#msjModalIncorrecto").html("<label>¡No se puede sacar una cita a esta hora!</label>");
                    $('#MsjIncorrecto').modal('show');
            }    

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