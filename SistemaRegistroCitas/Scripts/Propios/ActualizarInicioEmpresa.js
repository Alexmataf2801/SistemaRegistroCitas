function ActualizarInicioEmpresa() {
  
    var empresa = {
        Nombre: $("#txtNombreEmpresa").val(),
        CorreoElectronico: $("#txtContactoEmpresa").val(),
        Descripcion: $("#txtDescripcionEmpresa").val(),
        Direccion: $("#txtDireccionEmpresa").val(),     

    };

    if ($("#txtNombreEmpresa").val() === "" ) {
        $("#msjModalIncorrecto").html("<label>¡Falta complementar datos importantes!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else {

    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Empresa/ActualizarDatosXIdEmpresa/",
        data: { empresa },
        success: function (Info) {
            console.log(Info)
            if (Info) {
                $("#lblMensajeCorrecto").html("<label>¡Inicio Empresa Actualizado Correctamente!</label>");
                $("#lblTituloCorrecto").html("<label>Información</label>");
                $('#MsjCorrecto').modal('show');
            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Inicio Empresa!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });
    }
}

function ObtenerEmpresasXId() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/InicioEmpresas/ObtenerEmpresasXId/",

        success: function (InfoEmpresas) {

            console.log(InfoEmpresas);

            $("#txtNombreEmpresa").val(InfoEmpresas.Nombre);
            $("#txtContactoEmpresa").val(InfoEmpresas.CorreoElectronico);
            $("#txtDescripcionEmpresa").val(InfoEmpresas.Descripcion);
            $("#txtDireccionEmpresa").val(InfoEmpresas.Direccion);




        },

        error: function () {
            console.log('error')
        },

    });
}

$(document).ready(function () {
    ObtenerEmpresasXId();
});