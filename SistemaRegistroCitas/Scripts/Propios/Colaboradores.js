﻿function ObtenerColaboradoresActivos() {

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


$("#Colaboradores").change(function () {
    ObtenerServicios();
});


function InsertarDatosColaborador() {
    var usuario = {
        Identificacion: $("#txtIdentificacion").val(),
        Nombre: $("#txtNombre").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        Genero: $("#ddlGenero").val(),
        IdRol: $("#IdRol").val()
    };
    var ValidarCorreo = /^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
    if (!ValidarCorreo.test($("#txtCorreoElectronico").val())) {
        $("#msjModalIncorrecto").html("<label>¡El CorreoElectronico no es valido!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Usuario/InsertarDatosColaborador/",
        data: { usuario },
        success: function (Info) {
            
            switch (Info) {
                case 0:
                    $("#msjModalIncorrecto").html("<label>¡Faltan datos, vuelva a intentarlo!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                case 1:
                    LimpiarDatosColaborador();
                    $("#lblMensajeCorrecto").html("<label>¡Información Almacenada Correctamenta!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    break;
                case 2:
                    $("#msjModalIncorrecto").html("<label>¡El Correo ingresado ya existe!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                case 3:
                    $("#msjModalIncorrecto").html("<label>¡Su plan no permite mas colaboradores con ese tipo de rol!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                case 4:
                    $("#msjModalIncorrecto").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                default:
                    $("#msjModalIncorrecto").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                    $('#MsjIncorrecto').modal('show');
            }

        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });
    }

}


function ObtenerTodoLosRoles() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Roles/ObtenerTodoLosRoles/",

        success: function (InfoServicios) {


            var clasificacion = $("#IdRol");

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
     ObtenerTodoLosRoles();
});


function LimpiarDatosColaborador() {
    $("#txtIdentificacion").val('');
    $("#txtNombre").val('');
    $("#txtPrimerApellido").val('');
    $("#txtSegundoApellido").val('');
    $("#txtCorreoElectronico").val('');
    $("#txtTelefono").val('');
}