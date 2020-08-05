﻿function ActualizarDatosServicios() {
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
                $("#txtTiempoEstimadoServicio").val(Info.TiempoEstimado);

                //if (Info.TipoUnidad) {
                //    $("#txtTipoUnidadServicio").val(1);
                //} else {
                //    $("#txtTipoUnidadServicio").val(2);
                //}
                $("#txtTipoUnidadServicio").val(Info.TipoUnidad);

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