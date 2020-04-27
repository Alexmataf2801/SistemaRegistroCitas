function ObtenerColaboradoresActivos() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Colaboradores/ObtenerColaboradoresActivos/",

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



function InsertarColaboradores() {
    var colaboradores = {
        Nombre: $("#txtNombre").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        Identificacion: $("#txtIdentificacion").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        Genero: $("#IdPerfil").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Colaboradores/InsertarColaboradores/",
        data: { colaboradores },
        //success: function (Info) {
        //    switch (Info) {
        //        case 0:
        //            $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
        //            $('#MsjIncorrecto').modal('show');
        //            break;
        //        case 1:
        //            LimpiarValores();
        //            $('#fm-modal').modal('hide');
        //            $('#MsjCorreo').modal('show');
        //            break;
        //        case 2:
        //            $("#msjModal").html("<label>¡La Identificación ingresada ya existe!</label>");
        //            $('#MsjIncorrecto').modal('show');
        //            break;
        //        default:
        //            $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
        //            $('#MsjIncorrecto').modal('show');
        //    }

        //},
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}