function InsertarEvento() {
    var evento = {
        IdUsuario: $(5).val(),
        IdServicio: $("#Servicios").val(),
        Estado: $(1).val(),
        UsuarioCreacion: $("Jose").val(),
        HorarioInicial: $("#txtHorario").val(),
        HoraFinal: $("#TiempoFinal").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Evento/InsertarEvento/",
        data: { evento },
        success: function (Info) {
            switch (Info) {
                case 0:
                    $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                case 1:
                    LimpiarValores();
                    $('#fm-modal').modal('hide');
                    $('#MsjCorreo').modal('show');
                    break;
                case 2:
                    $("#msjModal").html("<label>¡La Identificación ingresada ya existe!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                default:
                    $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                    $('#MsjIncorrecto').modal('show');
            }

        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}