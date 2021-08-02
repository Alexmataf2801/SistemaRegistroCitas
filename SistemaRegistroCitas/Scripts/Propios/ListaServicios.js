function ObtenerTodosLosServicios() {
    $.ajax({
        type: "GET",
        url: "/Servicio/ObtenerTodosLosServicios",
        dataType: "JSON",
        success: function (Info) {

            var TablaRoles = $('#tbServicios').DataTable(
                {
                    autoWidth: false,
                    dom: 'frtip',
                    lengthChange: false,
                    "language": {
                        "url": "../../Content/Spanish.json"
                    },
                    retrieve: true,
                    responsive: true,
                    searching: true
                }
            );
            TablaRoles.clear().draw();
            $(Info).each(function (key, value) {
                var estado = '';
                if (value.Estado) {
                    estado = "<span class='EstadoActivo' >Activo</span>";
                } else {
                    estado = "<span class='EstadoInactivo' >Inactivo</span>";
                }
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='ServicioXId(" + value.Id + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarServicios(" + value.Id + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarServicio(" + value.Id + ")'></a>";

                TablaRoles.row.add([Editar, value.Nombre, value.Descripcion, value.TiempoEstimado, value.NombreUnidadMedida, estado, CambiarEstado, Eliminar]).draw();
            });

            $('#cargando').html(' ')
        },
        error: function (Error) {
        }
    });
}

function ServicioXId(Id) {
    sessionStorage.setItem("IdServicioEditar", Id);
    location.href = '/Servicio/ActualizarServicios';
}


function ConfirmarEliminarServicio(Id) {
    $("#IdServiciosSeleccionado").val(Id);
    $("#msjConfServicios").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionServicios').modal('show');
}

    function EliminarServicios() {
        var Id = $("#IdServiciosSeleccionado").val();
        $('#ModalConfirmacionServicios').modal('hide');
        if (Id !== null || Id !== undefined) {
            $.ajax({
                type: "POST",
                dataType: "JSON",
                url: "/Servicio/ElimnarServicio/",
                data: { Id: Id },
                success: function (Info) {
                    if (Info) {
                        $("#lblMensajeCorrecto").html("<label>¡Servicio Eliminado Correctamente!</label>");
                        $("#lblTituloCorrecto").html("<label>Información</label>");
                        $('#MsjCorrecto').modal('show');
                        ObtenerTodosLosServicios();
                    } else {
                        $("#msjModalIncorrecto").html("<label>¡El Servicio no pudo ser eliminado!</label>");
                        $('#MsjIncorrecto').modal('show');
                    }

                },
                error: function () {
                    $("#msjModalIncorrecto").html("<label>¡Algo Fallo!</label>");
                    $('#MsjIncorrecto').modal('show');
                }
            });

        }
}



function DesactivarActivarServicios(Id, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { Id, Estado },
        url: "/Servicio/DesactivarActivarServicios/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosLosServicios();
            } else {
                $("#msjModalIncorrecto").html("<label>¡No se pudo actualizar el estado del Servicio!</label>");
                $('#MsjIncorrecto').modal('show');
            }

        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡No se pudo actualizar el estado del Servicio!</label>");
            $('#MsjIncorrecto').modal('show');
        }
    });


}



$(document).ready(function () {
    ObtenerTodosLosServicios();
});