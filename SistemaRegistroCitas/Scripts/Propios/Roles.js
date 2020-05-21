function ObtenerRoles() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Roles/ObtenerRoles/",

        success: function (InfoRoles) {


            var clasificacion = $("#IdRol");

            $(InfoRoles).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');


            });


        },

        error: function () {
            console.log('error')
        },

    });
}
$(document).ready(function () {
    ObtenerRoles();
});