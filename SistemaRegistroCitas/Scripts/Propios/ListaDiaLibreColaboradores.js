

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


function ObtenerTodosLosDias() {
  
    
    var IdColaborador = $("#ddlColaboradores").val();
   
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/DiasLibresColaboradores/ObtenerTodosLosDias/",
        data: { "IdColaborador": IdColaborador },
        success: function (Info) {
            if (Info) {
              

                $("#CheckLunes").prop("checked", Info[0].Lunes);
                $("#CheckMartes").prop("checked", Info[0].Martes);
                $("#CheckMiercoles").prop("checked", Info[0].Miercoles);
                $("#CheckJueves").prop("checked", Info[0].Jueves);
                $("#CheckViernes").prop("checked", Info[0].Viernes);
                $("#CheckSabado").prop("checked", Info[0].Sabado);
                $("#CheckDomingo").prop("checked", Info[0].Domingo);
               


            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Error al obtener datos del Colaborador!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });


}

$("#ddlColaboradores").change(function () {
    ObtenerTodosLosDias();
});


$(document).ready(function () {
    ObtenerColaboradoresActivos();
   });