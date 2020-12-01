function ValidarCorreoElectronico() {
    var Id = sessionStorage.getItem("IdColaboradorEditar");
    var CorreoElectronico = $("#txtCorreoElectronicoColaborador").val();

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ValidarCorreoElectronico/",
        data: { Id, CorreoElectronico },

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

$(document).ready(function () {
    //ValidarCorreoElectronico();
});

$(document).on('blur', '#txtCorreoElectronicoColaborador', function () {
    ValidarCorreoElectronico();

});