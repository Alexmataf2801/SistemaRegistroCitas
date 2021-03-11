function ObtenerServiciosXColaborador() {
    $.ajax({
        type: "GET",
        url: "/Usuario/ObtenerServiciosXColaborador",
        dataType: "JSON",
        success: function (Info) {

            var TablaRoles = $('#tbServiciosXColaborador').DataTable(
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

                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarServicioXColaborador(" + value.IdServicioXColaborador + "," + value.Estado + " )'></a>";

                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarServicioXColaborador(" + value.IdServicioXColaborador + ")'></a>";

                TablaRoles.row.add([value.Nombre, value.NombreServicio, estado, CambiarEstado, Eliminar]).draw();
            });


        },
        error: function (Error) {
        }
    });
}


function ConfirmarEliminarServicioXColaborador(Id) {
    $("#IdServicioXColaboradorSeleccionado").val(Id);
    $("#msjConfServicioXColaborador").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionServicioXColaborador').modal('show');
}


function EliminarServiciosXColaborador() {
    var IdServicioXColaborador = $("#IdServicioXColaboradorSeleccionado").val();
    $('#ModalConfirmacionServicioXColaborador').modal('hide');
    if (IdServicioXColaborador !== null || IdServicioXColaborador !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Usuario/EliminarServiciosXColaborador/",
            data: { Id: IdServicioXColaborador },
            success: function (Info) {
                if (Info) {
                    $("#lblMensajeCorrecto").html("<label>¡Servicio Eliminado Correctamente!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    ObtenerServiciosXColaborador();
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

function DesactivarActivarServicioXColaborador(Id, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { Id, Estado },
        url: "/Usuario/DesactivarActivarServicioXColaborador/",
        success: function (Info) {
            if (Info) {
                ObtenerServiciosXColaborador();
            } else {
                $("#msjModalIncorrecto").html("<label>¡No se pudo actualizar el estado del Servicio del colaborador!</label>");
                $('#MsjIncorrecto').modal('show');
            }

        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡No se pudo actualizar el estado del Servicio del colaborador!</label>");
            $('#MsjIncorrecto').modal('show');
        }
    });


}

$(document).ready(function () {
    ObtenerServiciosXColaborador();
});