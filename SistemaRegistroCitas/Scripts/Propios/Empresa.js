//var empresas = [];

function ObtenerNombresEmpresasActivas() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Empresa/ObtenerNombresEmpresasActivas/",

        success: function (InfoEmpresas) {

            var emp = $("#txtIdEmpresaLogin");

            $(InfoEmpresas).each(function (i, v) {
                //empresas.push({ id: v.Id, value: v.Nombre });
                emp.append('<option value="' + v.Id + '">' + v.Nombre + '</option>')
              

            });      
           


            emp.select2({
                minimumInputLength: 2,
                placeholder: "Nombre de la empresa",
                allowClear: true,
                language: {
                    
                    inputTooShort: function () {
                        return "Escriba 2 letras para mostrar resultados";
                    },
                    noResults: function () {

                        return "No hay resultado";
                    },
                }
              
            });

            var lg = document.querySelector('.select2-container');
            lg.removeAttribute('style')
            lg.style.width = "100%";
            //$("#txtIdEmpresaLogin").autocomplete({
            //    source: empresas,
            //    //source: function (request, response) {
            //    //    response($.map(empresas, function (item) {
            //    //        return {
            //    //            id: item.Id,
            //    //            value: item.Nombre

            //    //        }

            //    //    }))
            //    //},
            //   // minLength: 1,
            //    //autoFocus:true
            //    select: function (event, ui) {
            //        $("#hfIdEmpresaSel").val(ui.item.id);

            //    }
            //});

        },

        error: function () {
            console.log('error')
        },

    });
}


function Loguear() {

    var login = {

        'CorreoElectronico': $("#txtCorreoElectronicoLogin").val().trim(),
        'Contrasena': $("#txtPassword").val()

    }
    var IdEmpresa = $("#txtIdEmpresaLogin").val();


    if ($("#txtIdEmpresaLogin").val() === "") {
        $("#msjModal").html("<label>¡Selecione Correctamente la Empresa!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Usuario/Loguear",
        data: { login, IdEmpresa },
        success: function (Info) {
            if (Info.Id > 0) {
                //window.location.href = "/InicioEmpresas/InicioEmpresas?IdEmpresa=" + IdEmpresa
                window.location.href = "/InicioEmpresas/InicioEmpresas"
            } else {
                $("#msjModal").html("<label>¡Usuario o Contraseña Invalido!</label>");
                $('#MsjIncorrecto').modal('show');
            }

        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
    }
}





$(document).ready(function () {
    ObtenerNombresEmpresasActivas();
});





