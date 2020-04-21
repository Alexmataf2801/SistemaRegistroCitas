function ObtenerColaboradoresActivos() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Colaboradores/ObtenerColaboradoresActivos/",

        success: function (InfoServicios) {


            var clasificacion = $("#Colaboradores");

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
    ObtenerColaboradoresActivos();
});