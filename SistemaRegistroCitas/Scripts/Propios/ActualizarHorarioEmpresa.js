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
            switch (Info) {
                case 1:
                    $("#lblMensajeCorrecto").html("<label>¡Horario Actualizado Correctamenta!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    $('#MsjCorrecto').on('hidden.bs.modal', function () {
                        // do something…
                        Redireccionar();
                    }); 
                    break;
                case 2:
                    $("#msjModalIncorrecto").html("<label>¡El Horario no se puede actualizar, existe un evento asignado en ese rango de horas!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                default:
                    $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Horario!</label>");
                    $('#MsjIncorrecto').modal('show');
            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Horario!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });

}

function Redireccionar() {
    location.href = '/InicioEmpresas/InicioEmpresas';
}