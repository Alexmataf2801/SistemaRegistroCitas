var empresas = [];

function ObtenerNombresEmpresasActivas() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Empresa/ObtenerNombresEmpresasActivas/",

        success: function (InfoEmpresas) {

            $(InfoEmpresas).each(function (i, v) {
                empresas.push({ id: v.Id, value: v.Nombre});
            });

            $("#txtIdEmpresaLogin").autocomplete({
                source: empresas,
                //source: function (request, response) {
                //    response($.map(empresas, function (item) {
                //        return {
                //            id: item.Id,
                //            value: item.Nombre

                //        }

                //    }))
                //},
               // minLength: 1,
                //autoFocus:true
                select: function (event, ui) {
                    $("#hfIdEmpresaSel").val(ui.item.id);

                }
            });

        },

        error: function () {
            console.log('error')
        },

    });
}




$(document).ready(function () {
    ObtenerNombresEmpresasActivas();
});





