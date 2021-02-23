function ObtenerPerfilColaboradorXId() {  
    $.ajax({
        type: "GET",
        datatype: "JSON",
        url: "/Usuario/ObtenerPerfilColaboradorXId/",       
        success: function (Info) {
            if (Info) {
                $("#txtIdentificacionColaborador").val(Info.Identificacion);
                $("#txtNombreColaborador").val(Info.Nombre);
                $("#txtPrimerApellidoColaborador").val(Info.PrimerApellido);
                $("#txtSegundoApellidoColaborador").val(Info.SegundoApellido);
                $("#txtCorreoElectronicoColaborador").val(Info.CorreoElectronico);
                $("#txtTelefonoColaborador").val(Info.Telefono);
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
    var CorreoElectronico = $("#txtCorreoElectronicoColaborador").val();
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
        Identificacion: $("#txtIdentificacionColaborador").val(),
        Nombre: $("#txtNombreColaborador").val(),
        PrimerApellido: $("#txtPrimerApellidoColaborador").val(),
        SegundoApellido: $("#txtSegundoApellidoColaborador").val(),
        CorreoElectronico: $("#txtCorreoElectronicoColaborador").val(),
        Telefono: $("#txtTelefonoColaborador").val(),
        Genero: $("#ddlGenero").val()     

    };

    if ($("#txtCorreoElectronicoColaborador").val() === "" ||
        $("#txtNombreColaborador").val() === "" ||
        $("#txtPrimerApellidoColaborador").val() === "") {
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
    $("#txtIdentificacionColaborador").val("");
    $("#txtNombreColaborador").val("");
    $("#txtPrimerApellidoColaborador").val("");
    $("#txtSegundoApellidoColaborador").val("");
    $("#txtCorreoElectronicoColaborador").val("");
    $("#txtTelefonoColaborador").val("");
    $("#ddlGenero").val("");   
}

function RedireccionarPerfil() {
    location.href = '/InicioEmpresas/InicioEmpresas';
}


$(document).on('blur', '#txtCorreoElectronicoColaborador', function () {
    ValidarCorreoElectronicoPerfil();

});


$(document).ready(function () {
    ObtenerPerfilColaboradorXId();
});