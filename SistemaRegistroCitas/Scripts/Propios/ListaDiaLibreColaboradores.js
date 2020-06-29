

function AsignarDiasLibres() {

    var IdColaborador = $("#ddlColaboradores").val()
    var Lunes = $("#CheckLunes").is(':checked')
    var Martes = $("#CheckMartes").is(':checked')
    var Miercoles = $("#CheckMiercoles").is(':checked')
    var Jueves = $("#CheckJueves").is(':checked')
    var Viernes = $("#CheckViernes").is(':checked')
    var Sabado = $("#CheckSabado").is(':checked')
    var Domingo = $("#CheckDomingo").is(':checked')
   

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, IdColaborador },
        url: "/DiasLibresColaboradores/DesactivarActivarDiasLibres/",
        success: function (Info) {
            if (Info) {
                //Modal todo correcto
            } else {
                $("#msjModalIncorrecto").html("<label>¡Se actualizo el dia del Colaborador!</label>");
                $('#MsjIncorrecto').modal('show');
            }

        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡No se pudo actualizar el dia del Colaborador!</label>");
            $('#MsjIncorrecto').modal('show');
        }
    });


}

function ObtenerColaboradoresActivos() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ObtenerColaboradoresActivos/",

        success: function (InfoServicios) {


            var clasificacion = $("#ddlColaboradores");

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








//$(document).ready(function () {
//    ObtenerColaboradoresActivos();
//});