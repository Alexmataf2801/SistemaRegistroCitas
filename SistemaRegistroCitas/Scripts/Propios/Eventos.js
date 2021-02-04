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

    var Usuario = null



    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ObtenerUsuarioSesion/",
        async: false,
        success: function (InfoUsuario) {

            Usuario = InfoUsuario
           
        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });

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





    function TiempoLibre() {

        var TiempoFinalLibre;
        var TiempoInicialLibre = $('#txtHorario').val();     

        if ($("#SeleccionTiempoLibre").val() == "1") { //  Horas

            var Hora = 1

            TiempoFinalLibre = moment(TiempoInicialLibre).add(Hora, 'hours');          
                       
            $('#TiempoInicialLibre').val(moment(TiempoInicialLibre).format('DD-MM-YYYY HH:mm A'));
            $('#TiempoFinalLibre').val(moment(TiempoFinalLibre).format('DD-MM-YYYY HH:mm A'));
            $('#TiempoCita').val(moment(TiempoInicialLibre).format('YYYY-MM-DD[T]HH:mm:ss'));
            $('#TiempoFinalLibreOculto').val(moment(TiempoFinalLibre).format('YYYY-MM-DD[T]HH:mm:ss'));

        } else if ($("#SeleccionTiempoLibre").val() == "2") { // Minutos

            var Minutos = 30

            TiempoFinalLibre = moment(TiempoInicialLibre).add(Minutos, 'minutes');          

            $('#TiempoInicialLibre').val(moment(TiempoInicialLibre).format('DD-MM-YYYY HH:mm A'));
            $('#TiempoFinalLibre').val(moment(TiempoFinalLibre).format('DD-MM-YYYY HH:mm A'));
            $('#TiempoCita').val(moment(TiempoInicialLibre).format('YYYY-MM-DD[T]HH:mm:ss'));
            $('#TiempoFinalLibreOculto').val(moment(TiempoFinalLibre).format('YYYY-MM-DD[T]HH:mm:ss'));


        } else if ($("#SeleccionTiempoLibre").val() == "3") {  // Dias

            var FechaSeleccionadaCombo = moment(TiempoInicialLibre).format('MM-DD-YYYY')            
           
            switch (Dia) {
                case 0:
                    var FechaCompletaComboIni = FechaSeleccionadaCombo + " " + InicioDomingo
                    var FechaCompletaComboFinal = FechaSeleccionadaCombo + " " + FinalDomingo
                    $('#TiempoInicialLibre').val(moment(FechaCompletaComboIni).format('DD-MM-YYYY HH:mm A') );
                    $('#TiempoFinalLibre').val(moment(FechaCompletaComboFinal).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoCita').val(moment(FechaCompletaComboIni).format('YYYY-MM-DD[T]HH:mm:ss'));
                    $('#TiempoFinalLibreOculto').val(moment(FechaCompletaComboFinal).format('YYYY-MM-DD[T]HH:mm:ss'));                  
                    break;                  
                case 1:
                    var FechaCompletaComboIniLunes = FechaSeleccionadaCombo + " " + InicioLunes
                    var FechaCompletaComboFinalLunes = FechaSeleccionadaCombo + " " + FinalLunes
                    $('#TiempoInicialLibre').val(moment(FechaCompletaComboIniLunes).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoFinalLibre').val(moment(FechaCompletaComboFinalLunes).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoCita').val(moment(FechaCompletaComboIniLunes).format('YYYY-MM-DD[T]HH:mm:ss'));
                    $('#TiempoFinalLibreOculto').val(moment(FechaCompletaComboFinalLunes).format('YYYY-MM-DD[T]HH:mm:ss'));
                    break;  
                case 2:
                    var FechaCompletaComboIniMartes = FechaSeleccionadaCombo + " " + InicioMartes
                    var FechaCompletaComboFinalMartes = FechaSeleccionadaCombo + " " + FinalMartes
                    $('#TiempoInicialLibre').val(moment(FechaCompletaComboIniMartes).format('DD-MM-YYYY hh:mm A'));
                    $('#TiempoFinalLibre').val(moment(FechaCompletaComboFinalMartes).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoCita').val(moment(FechaCompletaComboIniMartes).format('YYYY-MM-DD[T]HH:mm:ss'));
                    $('#TiempoFinalLibreOculto').val(moment(FechaCompletaComboFinalMartes).format('YYYY-MM-DD[T]HH:mm:ss'));
                    break;  
                case 3:
                    var FechaCompletaComboIniMiercoles = FechaSeleccionadaCombo + " " + InicioMiercoles
                    var FechaCompletaComboFinalMiercoles = FechaSeleccionadaCombo + " " + FinalMiercoles
                    $('#TiempoInicialLibre').val(moment(FechaCompletaComboIniMiercoles).format('DD-MM-YYYY hh:mm A'));
                    $('#TiempoFinalLibre').val(moment(FechaCompletaComboFinalMiercoles).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoCita').val(moment(FechaCompletaComboIniMiercoles).format('YYYY-MM-DD[T]HH:mm:ss'));
                    $('#TiempoFinalLibreOculto').val(moment(FechaCompletaComboFinalMiercoles).format('YYYY-MM-DD[T]HH:mm:ss'));
                    break;  
                case 4:
                    var FechaCompletaComboIniJueves = FechaSeleccionadaCombo + " " + InicioJueves
                    var FechaCompletaComboFinalJueves = FechaSeleccionadaCombo + " " + FinalJueves
                    $('#TiempoInicialLibre').val(moment(FechaCompletaComboIniJueves).format('DD-MM-YYYY hh:mm A'));
                    $('#TiempoFinalLibre').val(moment(FechaCompletaComboFinalJueves).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoCita').val(moment(FechaCompletaComboIniJueves).format('YYYY-MM-DD[T]HH:mm:ss'));
                    $('#TiempoFinalLibreOculto').val(moment(FechaCompletaComboFinalJueves).format('YYYY-MM-DD[T]HH:mm:ss'));
                    break;  
                case 5:
                    var FechaCompletaComboIniViernes = FechaSeleccionadaCombo + " " + InicioViernes
                    var FechaCompletaComboFinalViernes = FechaSeleccionadaCombo + " " + FinalViernes
                    $('#TiempoInicialLibre').val(moment(FechaCompletaComboIniViernes).format('DD-MM-YYYY hh:mm A'));
                    $('#TiempoFinalLibre').val(moment(FechaCompletaComboFinalViernes).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoCita').val(moment(FechaCompletaComboIniViernes).format('YYYY-MM-DD[T]HH:mm:ss'));
                    $('#TiempoFinalLibreOculto').val(moment(FechaCompletaComboFinalViernes).format('YYYY-MM-DD[T]HH:mm:ss'));
                    break;  
                case 6:
                    var FechaCompletaComboIniSabado = FechaSeleccionadaCombo + " " + InicioSabado
                    var FechaCompletaComboFinalSabado = FechaSeleccionadaCombo + " " + FinalSabado
                    $('#TiempoInicialLibre').val(moment(FechaCompletaComboIniSabado).format('DD-MM-YYYY hh:mm A'));
                    $('#TiempoFinalLibre').val(moment(FechaCompletaComboFinalSabado).format('DD-MM-YYYY HH:mm A'));
                    $('#TiempoCita').val(moment(FechaCompletaComboIniSabado).format('YYYY-MM-DD[T]HH:mm:ss'));
                    $('#TiempoFinalLibreOculto').val(moment(FechaCompletaComboFinalSabado).format('YYYY-MM-DD[T]HH:mm:ss'));
                    break;  

            }

        }

    }

    $("#SeleccionTiempoLibre").change(function () {
        TiempoLibre();
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
        // antes estaba editable, que podia mover el evento y sus horas, como esta ahora solo los puede mover 
        eventStartEditable: true,
        dateClick: function (info) {        
            var TipoModal = ""
            var FechaSeleccionada = moment(info.dateStr).format('YYYY-MM-DD[T]HH:mm:ss');

            var FechaDelDia = new Date(FechaSeleccionada);
            Dia = FechaDelDia.getDay();

            $('#DiaSeleccionado').val(Dia);  
            
            if (Usuario.IdRol == 4) {

                TipoModal = "#NuevoEvento"
                $('#TiempoFinal').val("");
                $('#TiempoCita').val(FechaSeleccionada);               
                $('#txtHorario').val(moment(info.dateStr).format('DD-MM-YYYY hh:mm A'));
                $('#txtHorarioOculta').val(info.dateStr);


            } else {
                TipoModal = "#EventoTiempo"
               
                $('#TiempoFinal').val("");
                $('#TiempoCita').val(FechaSeleccionada);
                $('#txtHorario').val(moment(info.dateStr).format('MM-DD-YYYY hh:mm A'));
                $('#txtHorarioOculta').val(info.dateStr);

            }
            
            //Fecha = FechaCompletaSeleccioada.getDate();            
            //Mes = FechaCompletaSeleccioada.getMonth();
            //Año = FechaCompletaSeleccioada.getFullYear();

            // HoraSeleccionada
            var FechaCompletaSeleccioada = new Date(FechaSeleccionada);
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
                            $(TipoModal).modal();
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
                            $(TipoModal).modal();
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
                            $(TipoModal).modal();
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
                            $(TipoModal).modal();
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
                            $(TipoModal).modal();
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
                            $(TipoModal).modal();
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
                            $(TipoModal).modal();
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
        //eventClick: function (info) {

        //    IdRol = 4
            
        //    if (IdRol == 3 ) {
        //        $('#NuevoEvento').modal();
        //    }
        //    else {
        //        $('#EventoTiempo').modal();
        //    }

        //}
       
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
             InsertarEventos(); 
    });

    function InsertarEventos() {
        var eventos = {
            TipoUnidadEvento: 1,
            HorarioInicial: $("#txtHorario").val(),
            HoraFinal: $("#TiempoFinal").val(),
            IdUsuario: $("#Colaboradores").val(),
            IdServicio: $("#Servicios").val(),
            Nombre: $("#Servicios option:selected").text(),
            IdDia: $("#DiaSeleccionado").val()

        };

        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Eventos/InsertarEventos/",
            data: { eventos },
            success: function (Info) {
                               
                $("#NuevoEvento").modal('hide');

                switch (Info) {
                    case 5:
                        $("#msjModalIncorrecto").html("<label>¡El rango horario selecionado no se puede ingresar el evento!</label>");
                        $('#MsjIncorrecto').modal('show');
                        break;
                    case 1:

                        $("#lblMensajeCorrecto").html("<label>¡Evento asignado Correctamenta!</label>");
                        $("#lblTituloCorrecto").html("<label>Información</label>");
                        $('#MsjCorrecto').modal('show');
                        doSubmit();
                        break;
                    case 2:
                        $("#msjModalIncorrecto").html("<label>¡Ya existe un Evento asignado!</label>");
                        $('#MsjIncorrecto').modal('show');
                        break;
                    default:
                        $("#msjModalIncorrecto").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                        $('#MsjIncorrecto').modal('show');
                }

            },
            error: function (Error) {
                //alert(Error);
                console.log(Error);
            }

        });


    }

    function doSubmit() {
       
        calendar.addEvent({
            title: $("#Servicios option:selected").text(),
            start: $("#TiempoCita").val(),
            end: $("#txtFinalHorarioOculto").val(),
            //allDay: true,
        });

    }




    $('#btnReservarTiempo').on('click', function (e) {
        e.preventDefault();
        InsertarTiempoLibre();
    });

    function InsertarTiempoLibre() {
        var eventos = {
            TipoUnidadEvento: 2,
            HorarioInicial: $("#TiempoInicialLibre").val(),
            HoraFinal: $("#TiempoFinalLibre").val(),
            IdUsuario: $("#Colaboradores").val(),
            IdServicio: $("#SeleccionTiempoLibre").val(),
            IdDia: $("#DiaSeleccionado").val()

        };

        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Eventos/InsertarEventos/",
            data: { eventos },
            success: function (Info) {

                $("#EventoTiempo").modal('hide');

                switch (Info) {
                    case 5:
                        $("#msjModalIncorrecto").html("<label>¡El rango horario selecionado no se puede ingresar el evento!</label>");
                        $('#MsjIncorrecto').modal('show');
                       
                        break;
                    case 1:

                        $("#lblMensajeCorrecto").html("<label>¡Evento asignado Correctamenta!</label>");
                        $("#lblTituloCorrecto").html("<label>Información</label>");
                        $('#MsjCorrecto').modal('show');
                        doSubmitTiempo();
                        break;
                    case 2:
                        $("#msjModalIncorrecto").html("<label>¡Ya existe un Evento asignado!</label>");
                        $('#MsjIncorrecto').modal('show');
                        break;
                    default:
                        $("#msjModalIncorrecto").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                        $('#MsjIncorrecto').modal('show');
                }

            },
            error: function (Error) {
                //alert(Error);
                console.log(Error);
            }

        });


    }

    function doSubmitTiempo() {      

        calendar.addEvent({
            title: $("#SeleccionTiempoLibre option:selected").text(),
            start: $("#TiempoCita").val(),
            end: $("#TiempoFinalLibreOculto").val(),
            //allDay: true,
        });

    } 

})



