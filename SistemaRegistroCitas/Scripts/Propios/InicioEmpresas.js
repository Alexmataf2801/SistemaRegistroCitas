function ObtenerEmpresasXId() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/InicioEmpresas/ObtenerEmpresasXId/",

        success: function (InfoEmpresas) {

            console.log(InfoEmpresas);

            $("#txtNombreEmpresa").val(InfoEmpresas.Nombre);
            $("#Descripcion").val(InfoEmpresas.Descripcion);

            
            //alert("Funciona traer empresas");


        },

        error: function () {
            console.log('error')
        },

    });
}

$(document).ready(function () {
    ObtenerEmpresasXId();
});