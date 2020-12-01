var empresas = [];
//var empresaSelecionada;
function ObtenerNombresEmpresasActivas() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Empresa/ObtenerNombresEmpresasActivas/",

        success: function (InfoEmpresas) {


            //$("#txtIdEmpresaLogin").typeahead({
            //    source: InfoEmpresa
            //});

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


//var substringMatcher = function (strs) {
//    return function findMatches(q, cb) {
//        var matches, substringRegex;

//        // an array that will be populated with substring matches
//        matches = [];

//        // regex used to determine if a string contains the substring `q`
//        substrRegex = new RegExp(q, 'i');

//        // iterate through the pool of strings and for any string that
//        // contains the substring `q`, add it to the `matches` array
//        $.each(strs, function (i, str) {
//            if (substrRegex.test(str.Nombre)) {
//                matches.push(str);
//            }
//        });

//        cb(matches);
//    };
//};




//$('#txtIdEmpresaLogin .typeahead').typeahead({
//    hint: true,
//    highlight: true,
//    minLength: 1,
//    onselect: function (obj) { console.log(obj) }
//},
//    {
//        name: 'empresas',
//        display: 'Nombre',
//        source: substringMatcher(empresas),
        
//        //onselect: function (obj) { console.log(obj); }
//    });


