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
// Lunes
function FormatoInicioLunes(ObjetoHoras) {
    var HLI = ObjetoHoras
    if (HLI > 09) {
        return ObjetoHoras;
    } else {
        return HoraLunesInicial0
    }

}

function FormatoFinalLunes(ObjetoHoras) {
    var HLF = ObjetoHoras
    if (HLF > 09) {
        return ObjetoHoras;
    } else {
        return HoraLunesFinal0
    }

}
// Martes
function FormatoInicioMartes(ObjetoHoras) {
    var HMI = ObjetoHoras
    if (HMI > 09) {
        return ObjetoHoras;
    } else {
        return HoraMartesInicial0
    }

}

function FormatoFinalMartes(ObjetoHoras) {
    var HMF = ObjetoHoras
    if (HMF > 09) {
        return ObjetoHoras;
    } else {
        return HoraMartesFinal0
    }

}
//Miercoles
function FormatoInicioMiercoles(ObjetoHoras) {
    var HMII = ObjetoHoras
    if (HMII > 09) {
        return ObjetoHoras;
    } else {
        return HoraMiercolesInicial0
    }

}

function FormatoFinalMiercoles(ObjetoHoras) {
    var HMIF = ObjetoHoras
    if (HMIF > 09) {
        return ObjetoHoras;
    } else {
        return HoraMiercolesFinal0
    }

}
//Jueves

function FormatoInicioJueves(ObjetoHoras) {
    var HJI = ObjetoHoras
    if (HJI > 09) {
        return ObjetoHoras;
    } else {
        return HoraJuevesInicial0
    }

}

function FormatoFinalJueves(ObjetoHoras) {
    var HJF = ObjetoHoras
    if (HJF > 09) {
        return ObjetoHoras;
    } else {
        return HoraJuevesFinal0
    }

}
//Viernes

function FormatoInicioViernes(ObjetoHoras) {
    var HVI = ObjetoHoras
    if (HVI > 09) {
        return ObjetoHoras;
    } else {
        return HoraViernesInicial0
    }

}

function FormatoFinalViernes(ObjetoHoras) {
    var HVF = ObjetoHoras
    if (HVF > 09) {
        return ObjetoHoras;
    } else {
        return HoraViernesFinal0
    }

}
  // Sabado

function FormatoInicioSabado(ObjetoHoras) {
    var HSI = ObjetoHoras
    if (HSI > 09) {
        return ObjetoHoras;
    } else {
        return HoraSabadoInicial0
    }

}

function FormatoFinalSabado(ObjetoHoras) {
    var HSF = ObjetoHoras
    if (HSF > 09) {
        return ObjetoHoras;
    } else {
        return HoraSabadoFinal0
    }

}
 // Domingo

function FormatoInicioDomingo(ObjetoHoras) {
    var HDI = ObjetoHoras
    if (HDI > 09) {
        return ObjetoHoras;
    } else {
        return HoraDomingoInicial0
    }

}

function FormatoFinalDomingo(ObjetoHoras) {
    var HDF = ObjetoHoras
    if (HDF > 09) {
        return ObjetoHoras;
    } else {
        return HoraDomingoFinal0
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

            InicioLunes = Formato(Info.InicioLunes);
            FinalLunes = Formato(Info.FinalLunes);
            EstadoLunes = Info.EstadoLunes

            if (EstadoLunes == false) {
                hiddenDays.push(1);
            }

            InicioMartes = Formato(Info.InicioMartes);
            FinalMartes = Formato(Info.FinalMartes);
            EstadoMartes = Info.EstadoMartes

            if (EstadoMartes == false) {
                hiddenDays.push(2);
            }


            InicioMiercoles = Formato(Info.InicioMiercoles);
            FinalMiercoles = Formato(Info.FinalMiercoles);
            EstadoMiercoles = Info.EstadoMiercoles

            if (EstadoMiercoles == false) {
                hiddenDays.push(3);
            }

            InicioJueves = Formato(Info.InicioJueves);
            FinalJueves = Formato(Info.FinalJueves)
            EstadoJueves = Info.EstadoJueves

            if (EstadoJueves == false) {
                hiddenDays.push(4);
            }

            InicioViernes = Formato(Info.InicioViernes);
            FinalViernes = Formato(Info.FinalViernes);
            EstadoViernes = Info.EstadoViernes

            if (EstadoViernes == false) {
                hiddenDays.push(5);
            }

            InicioSabado = Formato(Info.InicioSabado);
            FinalSabado = Formato(Info.FinalSabado);
            EstadoSabado = Info.EstadoSabado

            if (EstadoSabado == false) {
                hiddenDays.push(6);
            }

            InicioDomingo = Formato(Info.InicioDomingo);
            FinalDomingo = Formato(Info.FinalDomingo);
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

                // Lunes

            HoraLunesInicial0 = InicioLunes[0] // # 
            HoraLunesInicial1 = InicioLunes[1] // :
            MinutosLunesInicial = InicioLunes[3]
            HLI = HoraLunesInicial0 + HoraLunesInicial1            
            LunesInicio = FormatoHoras(FormatoInicioLunes(HLI)) + ":" + FormatoMinutos(MinutosLunesInicial)

            HoraLunesFinal0 = FinalLunes[0] // # 
            HoraLunesFinal1 = FinalLunes[1] // :
            MinutosLunesFinal = FinalLunes[3]
            HLF = HoraLunesFinal0 + HoraLunesFinal1
            LunesFinal = FormatoHoras(FormatoFinalLunes(HLF)) + ":" + FormatoMinutos(MinutosLunesFinal)     

             // Martes

            HoraMartesInicial0 = InicioMartes[0] // # 
            HoraMartesInicial1 = InicioMartes[1] // :
            MinutosMartesInicial = InicioMartes[3]
            HMI = HoraMartesInicial0 + HoraMartesInicial1
            MartesInicio = FormatoHoras(FormatoInicioMartes(HMI)) + ":" + FormatoMinutos(MinutosMartesInicial)

            HoraMartesFinal0 = FinalMartes[0] // # 
            HoraMartesFinal1 = FinalMartes[1] // :
            MinutosMartesFinal = FinalMartes[3]
            HMF = HoraMartesFinal0 + HoraMartesFinal1
            MartesFinal = FormatoHoras(FormatoFinalMartes(HMF)) + ":" + FormatoMinutos(MinutosMartesFinal) 

            // Miercoles

            HoraMiercolesInicial0 = InicioMiercoles[0] // # 
            HoraMiercolesInicial1 = InicioMiercoles[1] // :
            MinutosMiercolesInicial = InicioMiercoles[3]
            HMII = HoraMiercolesInicial0 + HoraMiercolesInicial1
            MiercolesInicio = FormatoHoras(FormatoInicioMiercoles(HMII)) + ":" + FormatoMinutos(MinutosMiercolesInicial)

            HoraMiercolesFinal0 = FinalMiercoles[0] // # 
            HoraMiercolesFinal1 = FinalMiercoles[1] // :
            MinutosMiercolesFinal = FinalMiercoles[3]
            HMIF = HoraMiercolesFinal0 + HoraMiercolesFinal1
            MiercolesFinal = FormatoHoras(FormatoFinalMiercoles(HMIF)) + ":" + FormatoMinutos(MinutosMiercolesFinal) 

            // Jueves

            HoraJuevesInicial0 = InicioJueves[0] // # 
            HoraJuevesInicial1 = InicioJueves[1] // :
            MinutosJuevesInicial = InicioJueves[3]
            HJI = HoraJuevesInicial0 + HoraJuevesInicial1
            JuevesInicio = FormatoHoras(FormatoInicioJueves(HJI)) + ":" + FormatoMinutos(MinutosJuevesInicial)

            HoraJuevesFinal0 = FinalJueves[0] // # 
            HoraJuevesFinal1 = FinalJueves[1] // :
            MinutosJuevesFinal = FinalJueves[3]
            HJF = HoraJuevesFinal0 + HoraJuevesFinal1
            JuevesFinal = FormatoHoras(FormatoFinalJueves(HJF)) + ":" + FormatoMinutos(MinutosJuevesFinal) 

             // Viernes

            HoraViernesInicial0 = InicioViernes[0] // # 
            HoraViernesInicial1 = InicioViernes[1] // :
            MinutosViernesInicial = InicioViernes[3]
            HVI = HoraViernesInicial0 + HoraViernesInicial1
            ViernesInicio = FormatoHoras(FormatoInicioViernes(HVI)) + ":" + FormatoMinutos(MinutosViernesInicial)

            HoraViernesFinal0 = FinalViernes[0] // # 
            HoraViernesFinal1 = FinalViernes[1] // :
            MinutosViernesFinal = FinalJueves[3]
            HVF = HoraViernesFinal0 + HoraViernesFinal1
            ViernesFinal = FormatoHoras(FormatoFinalViernes(HVF)) + ":" + FormatoMinutos(MinutosViernesFinal) 

            // Sabado

            HoraSabadoInicial0 = InicioSabado[0] // # 
            HoraSabadoInicial1 = InicioSabado[1] // :
            MinutosSabadoInicial = InicioSabado[3]
            HSI = HoraSabadoInicial0 + HoraSabadoInicial1
            SabadoInicio = FormatoHoras(FormatoInicioSabado(HSI)) + ":" + FormatoMinutos(MinutosSabadoInicial)

            HoraSabadoFinal0 = FinalSabado[0] // # 
            HoraSabadoFinal1 = FinalSabado[1] // :
            MinutosSabadoFinal = FinalSabado[3]
            HSF = HoraSabadoFinal0 + HoraSabadoFinal1
            SabadoFinal = FormatoHoras(FormatoFinalSabado(HSF)) + ":" + FormatoMinutos(MinutosSabadoFinal) 

            // Domingo

            HoraDomingoInicial0 = InicioDomingo[0] // # 
            HoraDomingoInicial1 = InicioDomingo[1] // :
            MinutosDomingoInicial = InicioDomingo[3]
            HDI = HoraDomingoInicial0 + HoraDomingoInicial1
            DomingoInicio = FormatoHoras(FormatoInicioDomingo(HDI)) + ":" + FormatoMinutos(MinutosDomingoInicial)

            HoraDomingoFinal0 = FinalDomingo[0] // # 
            HoraDomingoFinal1 = FinalDomingo[1] // :
            MinutosDomingoFinal = FinalDomingo[3]
            HDF = HoraDomingoFinal0 + HoraDomingoFinal1
            DomingoFinal = FormatoHoras(FormatoFinalDomingo(HDF)) + ":" + FormatoMinutos(MinutosDomingoFinal) 

            switch (Dia) {

                case 0:
                    if (DomingoInicio <= HoraTotalSeleccionada) {
                        if (DomingoFinal > HoraTotalSeleccionada) {
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
                    if (LunesInicio <= HoraTotalSeleccionada) {
                        if (LunesFinal > HoraTotalSeleccionada) {
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
                    if (MartesInicio <= HoraTotalSeleccionada) {
                        if (MartesFinal > HoraTotalSeleccionada) {
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
                    if (MiercolesInicio <= HoraTotalSeleccionada) {
                        if (MiercolesFinal > HoraTotalSeleccionada) {
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
                    if (JuevesInicio <= HoraTotalSeleccionada) {
                        if (JuevesFinal > HoraTotalSeleccionada) {
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
                    if (ViernesInicio <= HoraTotalSeleccionada) {
                        if (ViernesFinal > HoraTotalSeleccionada) {
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
                    if (SabadoInicio <= HoraTotalSeleccionada) {
                        if (SabadoFinal > HoraTotalSeleccionada) {
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
           

            //$('#NuevoEvento').modal();




           

          

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