function ActualizarDatosServicios() {
    var Id = sessionStorage.getItem("IdServicioEditar");
    var Servicio = {
        Id: Id,
        Nombre: $("#txtNombre").val(),
        Descripcion: $("#txtDescripcionServicio").val(),
        TiempoEstimado: $("#txtTiempoEstimadoServicio").val()
    };
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Servicio/ActualizarServicios/",
        data: { InfoServicio: Servicio },
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
}

$(document).ready(function () {
    ObtenerDatosServicio();
});