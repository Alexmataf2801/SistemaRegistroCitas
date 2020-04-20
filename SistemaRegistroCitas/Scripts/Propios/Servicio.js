function ObtenerServicios() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Servicio/ObtenerServicios/",

        success: function (InfoServicios) {

                                   
            var clasificacion = $("#Servicios");

            $(InfoServicios).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');
                                          
            
            });


        },

        error: function () {
            console.log('error')
        },

    });
}


function ServicioXId() {

    if ($("#Servicios").val() !== "0") {
        $("#btnReservar").prop("disabled", false);
 
        $.ajax({
            type: "GET",
            dataType: "JSON",
            url: "/Servicio/ServicioXId/",
            data: { "Id": $("#Servicios").val() },

            success: function (InfoServicio) {
                $("#TiempoAprox").val(InfoServicio.TiempoEstimado + " " + InfoServicio.UnidadMedida);

            },

            error: function () {
                console.log('error')
            },

        });
    } else {
        $("#btnReservar").prop("disabled", true);
        $("#TiempoAprox").val('');
    }

   
}

$("#Servicios").change(function () {
    ServicioXId();
})


$(document).ready(function () {
    ObtenerServicios();
});

