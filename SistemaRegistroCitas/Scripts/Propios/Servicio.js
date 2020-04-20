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


function ServicioTiempo() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Servicio/ServicioTiempo/",
        data: { "Id": $("#Servicios").val()} ,

        success: function (InfoServicio) {
            $("#TiempoAprox").val(InfoServicio.TiempoEstimado);

        },

        error: function () {
            console.log('error')
        },

    });
}

$("#Servicios").change(function () {
    ServicioTiempo();
})


$(document).ready(function () {
    ObtenerServicios();
});

