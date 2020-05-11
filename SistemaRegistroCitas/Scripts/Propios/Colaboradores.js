//function ObtenerColaboradoresActivos() {

//    $.ajax({
//        type: "GET",
//        dataType: "JSON",
//        url: "/Colaboradores/ObtenerColaboradoresActivos/",

//        success: function (InfoServicios) {


//            var clasificacion = $("#Colaboradores");

//            $(InfoServicios).each(function (i, v) {
//                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');


//            });


//        },

//        error: function () {
//            console.log('error')
//        },

//    });
//}
//$(document).ready(function () {
//    ObtenerColaboradoresActivos();
//});



function InsertarColaboradores() {
    var usuario = {
        Identificacion: $("#txtIdentificacion").val(),
        Nombre: $("#txtNombre").val(),
        Empresa: $("#txtIdEmpresa").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        IdPerfil: $("#IdPerfil").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Usuario/InsertarDatosColaborador/",
        data: { usuario },
        success: function (Info) {
            console.log(Info);
            //switch (Info) {
            //    case 0:
            //        $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
            //        $('#MsjIncorrecto').modal('show');
            //        break;
            //    case 1:
            //        LimpiarValores();
            //        $('#fm-modal').modal('hide');
            //        $('#MsjCorreo').modal('show');
            //        break;
            //    case 2:
            //        $("#msjModal").html("<label>¡La Identificación ingresada ya existe!</label>");
            //        $('#MsjIncorrecto').modal('show');
            //        break;
            //    default:
            //        $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
            //        $('#MsjIncorrecto').modal('show');
            //}

        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}