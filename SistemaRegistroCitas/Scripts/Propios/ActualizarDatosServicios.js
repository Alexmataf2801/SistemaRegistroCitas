function ActualizarDatosServicios() {
    var Id = sessionStorage.getItem("IdServicioEditar");
    var Servicio = {
        Id: Id,
        Nombre: $("#txtNombre").val(),
        Descripcion: $("#txtDescripcionServicio").val(),
        TiempoEstimado: $("#txtTiempoEstimadoServicio").val(),
        TipoUnidad: $("#txtTipoUnidadServicio").val()
    };
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Servicio/ActualizarServicios/",
        data: { servicio: Servicio },
        success: function (Info) {
            if (Info) {
                $("#msjCorrectoActServicio").html("<label>¡Servicio Actualizado Correctamente!</label>");
                $('#ModalCorrectoActServicio').modal('show');
                LimpiarCampos();
            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Servicio!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });

}

function ObtenerDatosServicio() {
    var Id = sessionStorage.getItem("IdServicioEditar");
    ObtenerMinutosYHoras();
   
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Servicio/ServicioXId/",
        data: { Id: Id },
        success: function (Info) {
            if (Info) {
                $("#txtNombre").val(Info.Nombre);
                $("#txtDescripcionServicio").val(Info.Descripcion);          
                $("#txtTipoUnidadServicio").val(Info.TipoUnidad);
                LlenarComboTiempos();
                $("#txtTiempoEstimadoServicio").val(Info.TiempoEstimado);
            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Error al obtener datos del Servicio!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });


}

function RedireccionarServicios() {
    location.href = '/Servicio/ListaServicios/';
}

function LimpiarCampos() {
    $("#txtNombre").val("");
    $("#txtDescripcionServicio").val("");
    $("#txtTiempoEstimadoServicio").val("");
    $("#txtTipoUnidadServicio").val("");
}

$(document).ready(function () {
    ObtenerDatosServicio();
});






function ObtenerMinutosYHoras() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/UnidadMedida/ObtenerMinutosYHoras/",
        async:false,
        success: function (InfoServicios) {


            var clasificacion = $("#txtTipoUnidadServicio");

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
     //ObtenerMinutosYHoras();
});


function LlenarComboTiempos() {

    var Tiempo = $("#txtTiempoEstimadoServicio");
    Tiempo.empty();
    //Tiempo.append('<option value="0">Duracion del Servicio</option>');

    if ($("#txtTipoUnidadServicio").val() == "1") { // Minutos

        var cantidad = 30
        var contador = 0


        for (var i = 0; i < 6; i++) {
            contador = contador + cantidad
            Tiempo.append('<option value="' + contador + '">' + contador + '</option>');
        }

    } else if ($("#txtTipoUnidadServicio").val() == "2") { // Horas
        var cantidad = 1
        var contador = 0


        for (var i = 0; i < 10; i++) {
            contador = contador + cantidad
            Tiempo.append('<option value="' + contador + '">' + contador + '</option>');
        }
    }

}

$("#txtTipoUnidadServicio").change(function () {
    LlenarComboTiempos()
});