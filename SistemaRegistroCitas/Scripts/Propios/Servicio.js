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



$(document).ready(function () {
    ObtenerServicios();
});