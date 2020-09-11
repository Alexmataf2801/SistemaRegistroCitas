function ObtenerEmpresasXId() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/InicioEmpresas/ObtenerEmpresasXId/",

        success: function (InfoEmpresas) {

            console.log(InfoEmpresas);

            $("#txtNombreEmpresa").val(InfoEmpresas.Nombre);
            $("#txtContactoEmpresa").val(InfoEmpresas.Telefono);

            
          

        },

        error: function () {
            console.log('error')
        },

    });
}

$(document).ready(function () {
    ObtenerEmpresasXId();
});