function ValidarCorreoElectronico() {
    var ValidarCorreo = /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
    var Id = sessionStorage.getItem("IdColaboradorEditar");
    var CorreoElectronico = $("#txtCorreoElectronicoColaborador").val();

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ValidarCorreoElectronico/",
        data: { Id, CorreoElectronico },

        success: function (Validar) {


            if (Validar ||
                !ValidarCorreo.test($("#txtCorreoElectronicoColaborador").val())) {
                //alert("no funciona");
                $("#MensajeCorreoCorrecto").empty();
                $("#MensajeCorreoCorrecto").append('<p>¡El Correo Electronico ya existe o no es valido!</p>').css("color", "red");
          
            }
            else {

                //alert("Si funciona");
                $("#MensajeCorreoCorrecto").empty();
                $("#MensajeCorreoCorrecto").append('<p>¡CorreoElectronico valido!</p>').css("color", "green");
             
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