﻿function ValidarCorreoElectronicoPerfil() {  
    var ValidarCorreo = /^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
    var CorreoElectronico = $("#txtCorreoElectronicoPerfil").val();
    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ValidarCorreoElectronicoPerfil/",
        data: { CorreoElectronico },

        success: function (Validar) {


            if (Validar || 
                !ValidarCorreo.test($("#txtCorreoElectronicoPerfil").val())) {
                
                $("#MensajeCorreoCorrecto").empty();
                $("#MensajeCorreoCorrecto").append('<p>¡El Correo Electronico ya existe o no es valido!</p>').css("color", "red");
            }
            else {
               
                $("#MensajeCorreoCorrecto").empty();
                $("#MensajeCorreoCorrecto").append('<p>¡CorreoElectronico valido!</p>').css("color", "green");
            }

        },

        error: function () {
            console.log('error')
        },

    });
}


function ActualizarPerfil() {   
    var ValidarCorreo = /^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
    var Usuario = {      
        Identificacion: $("#txtIdentificacionPerfil").val(),
        Nombre: $("#txtNombrePerfil").val(),
        PrimerApellido: $("#txtPrimerApellidoPerfil").val(),
        SegundoApellido: $("#txtSegundoApellidoPerfil").val(),
        CorreoElectronico: $("#txtCorreoElectronicoPerfil").val(),
        Telefono: $("#txtTelefonoPerfil").val(),
        Genero: $("#ddlGenero").val()     

    };

    if ($("#txtCorreoElectronicoPerfil").val() === "" ||
        $("#txtNombrePerfil").val() === "" ||
        $("#txtPrimerApellidoPerfil").val() === "" || 
        ValidarCorreo.test($("#txtCorreoElectronicoPerfil").val()) === false) {
        $("#msjModalIncorrecto").html("<label>¡Falta complementar datos importantes o el Correo Electronico no es valido!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else {

        $.ajax({
            type: "POST",
            datatype: "JSON",
            url: "/Usuario/ActualizarPerfil/",
            data: { perfil: Usuario },
            success: function (Info) {
                if (Info) {
                    $("#msjCorrectoActPerfil").html("<label>¡Perfil Actualizado Correctamente!</label>");
                    $('#ModalCorrectoActPerfil').modal('show');
                    LimpiarCampos()
                } 
                else {
                    $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el perfil!</label>");
                    $('#MsjIncorrecto').modal('show');
                }
            },
            error: function (Error) {
                $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Perfil!</label>");
                $('#MsjIncorrecto').modal('show');
            }

        });

    }
}


function LimpiarCampos() {
    $("#txtIdentificacionPerfil").val("");
    $("#txtNombrePerfil").val("");
    $("#txtPrimerApellidoPerfil").val("");
    $("#txtSegundoApellidoPerfil").val("");
    $("#txtCorreoElectronicoPerfil").val("");
    $("#txtTelefonoPerfil").val("");
    $("#ddlGenero").val("");   
}

function RedireccionarPerfil() {
    location.href = '/InicioEmpresas/InicioEmpresas';
}


$(document).on('blur', '#txtCorreoElectronicoPerfil', function () {
    ValidarCorreoElectronicoPerfil();

});
