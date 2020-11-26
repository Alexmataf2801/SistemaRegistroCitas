function ActualizarHorarioEmpresa() {
   
    var EstadoLunes = $("#EstadoLunes").is(':checked')
    var EstadoMartes = $("#EstadoMartes").is(':checked')
    var EstadoMiercoles = $("#EstadoMiercoles").is(':checked')
    var EstadoJueves = $("#EstadoJueves").is(':checked')
    var EstadoViernes = $("#EstadoViernes").is(':checked')
    var EstadoSabado = $("#EstadoSabado").is(':checked')
    var EstadoDomingo = $("#EstadoDomingo").is(':checked')
    var HorarioEmpresa = {       
        InicioLunes: $("#InicioLunes").val(),
        FinalLunes: $("#FinalLunes").val(),     
        InicioMartes: $("#InicioMartes").val(),
        FinalMartes: $("#FinalMartes").val(),
        InicioMiercoles: $("#InicioMiercoles").val(),
        FinalMiercoles: $("#FinalMiercoles").val(),
        InicioJueves: $("#InicioJueves").val(),
        FinalJueves: $("#FinalJueves").val(),
        InicioViernes: $("#InicioViernes").val(),
        FinalViernes: $("#FinalViernes").val(),
        InicioSabado: $("#InicioSabado").val(),
        FinalSabado: $("#FinalSabado").val(),
        InicioDomingo: $("#InicioDomingo").val(),
        FinalDomingo: $("#FinalDomingo").val(),
        
    };
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/InicioEmpresas/ActualizarHorarioEmpresa/",
        data: { horarioEmpresa: HorarioEmpresa, EstadoLunes, EstadoMartes, EstadoMiercoles, EstadoJueves, EstadoViernes, EstadoSabado, EstadoDomingo },
        success: function (Info) {
            if (Info) {
                $("#lblMensajeCorrecto").html("<label>¡Horarios Insertados Correctamente!</label>");
                $("#lblTituloCorrecto").html("<label>Información</label>");
                $('#MsjCorrecto').modal('show');               
            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Horario!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });

}