function ObtenerPerfilColaboradorXId() {  
    $.ajax({
        type: "GET",
        datatype: "JSON",
        url: "/Usuario/ObtenerPerfilColaboradorXId/",       
        success: function (Info) {
            if (Info) {
                $("#txtIdentificacionPerfil").val(Info.Identificacion);
                $("#txtNombrePerfil").val(Info.Nombre);
                $("#txtPrimerApellidoPerfil").val(Info.PrimerApellido);
                $("#txtSegundoApellidoPerfil").val(Info.SegundoApellido);
                $("#txtCorreoElectronicoPerfil").val(Info.CorreoElectronico);
                $("#txtTelefonoPerfil").val(Info.Telefono);
                if (Info.Genero) {
                    $("#ddlGenero").val(1);
                } else {
                    $("#ddlGenero").val(0);
                }              


            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Error al obtener datos del Colaborador!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });


}
function ValidarCorreoElectronicoPerfil() {  
    var CorreoElectronico = $("#txtCorreoElectronicoPerfil").val();
    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ValidarCorreoElectronicoPerfil/",
        data: { CorreoElectronico },

        success: function (Validar) {


            if (Validar) {
                alert("no funciona");
            }
            else {
                alert("Si funciona");
            }

        },

        error: function () {
            console.log('error')
        },

    });
}


function ActualizarPerfil() {   
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
        $("#txtPrimerApellidoPerfil").val() === "") {
        $("#msjModalIncorrecto").html("<label>¡Falta complementar datos importantes!</label>");
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


$(document).ready(function () {
    ObtenerPerfilColaboradorXId();
});