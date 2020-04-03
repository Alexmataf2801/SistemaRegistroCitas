function InsertarUsuario() {
    var usuario = {
        Nombre: $("#txtNombre").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        Identificacion: $("#txtIdentificacion").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        Genero: $("#ddlGenero").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Usuario/InsertarUsuario/",
        data: { usuario },
        success: function (Info) {
            switch (Info) {
                case "0":
                    // FALTA CREAR EL MODAL PARA ERROR
                    break;
                case "1":
                    $('#fm-modal').modal('hide');
                    $('#MsjCorreo').modal('show');
                    break;
                case "2":
                    // FALTA PARAMETRIZAR EL MODAL MENSAJE
                    break;
                default:
            }

        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}