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

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Usuario/AsignarServiciosXColaborador/",
        data: { UsuarioXServicio },
        success: function (InfoUsuarioXServicio) {
            if (InfoUsuarioXServicio) {               
                $("#lblMensajeCorrecto").html("<label>¡Información Almacenada Correctamenta!</label>");
                $("#lblTituloCorrecto").html("<label>Información</label>");
                $('#MsjCorrecto').modal('show');
            } else {
                $("#msjModal").html("<label>¡Fallo en la asignacion del servicio al colaborador!</label>");
                $('#MsjIncorrecto').modal('show');
            }


        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}