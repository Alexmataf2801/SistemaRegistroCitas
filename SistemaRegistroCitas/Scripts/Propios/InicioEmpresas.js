function ObtenerEmpresasXId() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Empresa/ObtenerEmpresasXId/",

        success: function (InfoEmpresas) {


           


        },

        error: function () {
            console.log('error')
        },

    });
}