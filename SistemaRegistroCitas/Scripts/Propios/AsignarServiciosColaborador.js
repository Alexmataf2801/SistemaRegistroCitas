function AsignaColaborador() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ObtenerColaboradoresActivos/",

        success: function (InfoColaboraador) {


            var clasificacion = $("#ColaboradoresXEmpresa");

            $(InfoColaboraador).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');


            });


        },

        error: function () {
            console.log('error')
        },

    });
}
$(document).ready(function () {
    AsignaColaborador();
});



function AsignaServicio() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Servicio/ObtenerTodosLosServicios",

        success: function (InfoServicios) {


            var clasificacion = $("#ServiciosXEmpresa");

            $(InfoServicios).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');


            });


        },

        error: function () {
            console.log('error')
        },

    });
}
$(document).ready(function () {
    AsignaServicio();
});



function AsignarServiciosXColaborador() {
    var UsuarioXServicio = {
        Id: $("#ColaboradoresXEmpresa").val(),
        IdServicio: $("#ServiciosXEmpresa").val()


    };

    if ($("#ColaboradoresXEmpresa").val() === "0"
        || $("#ServiciosXEmpresa").val() === "0") {

        $("#msjModalIncorrecto").html("<label>¡Seleccione el colaborador o servicio valido!</label>");
        $('#MsjIncorrecto').modal('show');

    }
    else {
    
    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Usuario/AsignarServiciosXColaborador/",
        data: { UsuarioXServicio },
        success: function (InfoUsuarioXServicio) {
           
            switch (InfoUsuarioXServicio) {
                case 1:
                    $("#lblMensajeCorrecto").html("<label>¡Información Almacenada Correctamenta!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    break;
                case 2:
                    $("#msjModalIncorrecto").html("<label>¡El servicio asignado al colaborador ya existe!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                case 3:
                    $("#msjModalIncorrecto").html("<label>¡Fallo en la asignacion del servicio al colaborador!</label>");
                    $('#MsjIncorrecto').modal('show');

                    break;
                default:
                    $("#msjModalIncorrecto").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                    $('#MsjIncorrecto').modal('show');
            }


        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });

    }
}