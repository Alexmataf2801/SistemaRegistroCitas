function InsertarUsuario() {
    var usuario = {
        IdRol: 4,
        Nombre: $("#txtNombre").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        Identificacion: $("#txtIdentificacion").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        Genero: $("#ddlGenero").val(),
        TerminosYCondiciones: $("#TerminosYCondiciones").val()
    };
    var ValidarCorreo = /^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;  

    if (!ValidarCorreo.test($("#txtCorreoElectronico").val()))  {
        $("#msjModal").html("<label>¡El CorreoElectronico no es valido!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else {


        if ($('#TerminosYCondiciones').prop('checked')) {

            $.ajax({
                type: "POST",
                dataType: "JSON",
                url: "/Usuario/InsertarUsuario/",
                data: { usuario },
                success: function (Info) {

                    switch (Info) {

                        case 0:
                            $("#msjModal").html("<label>¡Faltan datos, vuelva a intentarlo!</label>");
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
        else {

       
            $("#msjModal").html("<label>¡Acepte los Términos y Condiciones para acceder!</label>");
            $('#MsjIncorrecto').modal('show');

        }

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