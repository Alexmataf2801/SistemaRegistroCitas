function InsertarUsuario() {
    var usuario = {
        IdRol: 4,
        Nombre: $("#txtNombre").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        Identificacion: $("#txtIdentificacion").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        Genero: $("#ddlGenero").val()
    };
    var ValidarCorreo = /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
           //    /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
   

    if (!ValidarCorreo.test($("#txtCorreoElectronico").val()))  {
        $("#msjModal").html("<label>¡El CorreoElectronico no es valido!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else {

        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Usuario/InsertarUsuario/",
            data: { usuario },
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
                        $("#msjModal").html("<label>¡El CorreoElectronico ingresado ya existe!</label>");
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
}


function LimpiarValores() {
    $("#txtNombre").val('');
    $("#txtPrimerApellido").val('');
    $("#txtSegundoApellido").val('');
    $("#txtIdentificacion").val('');
    $("#txtCorreoElectronico").val('');
    $("#txtTelefono").val('');
}