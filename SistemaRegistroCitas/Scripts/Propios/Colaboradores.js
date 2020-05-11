function ObtenerColaboradoresActivos() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ObtenerColaboradoresActivos/",

        success: function (InfoServicios) {


            var clasificacion = $("#Colaboradores");

            $(InfoServicios).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');


            });


        },

        error: function () {
            console.log('error')
        },

    });
}
$(document).ready(function () {
    ObtenerColaboradoresActivos();
});



function InsertarDatosColaborador() {
    var usuario = {
        Identificacion: $("#txtIdentificacion").val(),
        Nombre: $("#txtNombre").val(),
        //Empresa: $("#txtIdEmpresaColaborador").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        Genero: $("#ddlGenero").val(),
        IdRol: $("#IdRol").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Usuario/InsertarDatosColaborador/",
        data: { usuario },
        success: function (Info) {
            alert: 'entro'
            switch (Info) {
                //case 0:
                //    $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                //    $('#MsjIncorrecto').modal('show');
                //    break;
                case 1:
                    LimpiarValores();
                    $('#fm-modal').modal('hide');
                    $('#MsjCorreo').modal('show');
                    break;
                case 2:
                    $("#msjModal").html("<label>¡La Correo ingresado ya existe!</label>");
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


