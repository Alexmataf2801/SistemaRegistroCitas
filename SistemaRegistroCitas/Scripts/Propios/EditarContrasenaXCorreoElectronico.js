function EditarContrasenaXCorreoElectronico() {
    var Login = {
        ContrasenaActual: $("#txtContrasenaActual").val(),
        NuevaContrasena : $("#txtNuevaContrasena").val(),
        ConfirmaContrasena : $("#txtConfirmaContrasena").val()
    };
   

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Usuario/EditarContrasenaXCorreoElectronico/",
        data: { login: Login },
        success: function (Info) {

            switch (Info) {

                case 1:
                    $("#lblMensajeCorrecto").html("<label>¡Contraseña Actualizada Correctamenta!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    LimpiarCampos()
                    break;
                case 2:                  
                    $("#msjModalIncorrecto").html("<label>¡La nueva contraseñas no conside!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                case 3:
                    $("#msjModalIncorrecto").html("<label>¡La contraseña actual no conside !</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;

                default:
                    $("#msjModalIncorrecto").html("<label>¡Hubo un error vuelva a intentar!</label>");
                    $('#MsjIncorrecto').modal('show');
            }

        },

        error: function () {
            console.log('error')
        },

    });
}

function LimpiarCampos() {
    $("#txtContrasenaActual").val("");
    $("#txtNuevaContrasena").val("");
    $("#txtConfirmaContrasena").val("");
 
}