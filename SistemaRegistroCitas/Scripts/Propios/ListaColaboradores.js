function ObtenerTodosLosColaboradores() {
    $.ajax({
        type: "GET",
        url: "/Usuario/ObtenerTodosLosColaboradores",
        dataType: "JSON",
        success: function (Info) {

            var TablaRoles = $('#tbColaboradores').DataTable(
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
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='ColaboradoresXId(" + value.Id + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarColaboradores(" + value.Id + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarColaborador(" + value.Id + ")'></a>";

                TablaRoles.row.add([Editar, value.Nombre, value.PrimerApellido, value.NombreRol, estado, CambiarEstado, Eliminar]).draw();
            });

            $('#cargando').html(' ')
        },
        error: function (Error) {
        }
    });
}


function ColaboradoresXId(Id) {
    sessionStorage.setItem("IdColaboradorEditar", Id);
    location.href = '/Usuario/ActualizarColaboradores';
}

function ConfirmarEliminarColaborador(Id) {
    $("#IdColaboradorSeleccionado").val(Id);
    $("#msjConfColaboradores").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionColaboradores').modal('show');
}

function EliminarColaboradores() {
    var Id = $("#IdColaboradorSeleccionado").val();
    $('#ModalConfirmacionColaboradores').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Usuario/EliminarColaboradores/",
            data: { Id: Id },
            success: function (Info) {
                if (Info) {
                    $("#lblMensajeCorrecto").html("<label>¡Colaborador Eliminado Correctamente!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    ObtenerTodosLosColaboradores();
                } else {
                    $("#msjModalIncorrecto").html("<label>¡El Colaborador no pudo ser eliminado!</label>");
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



function DesactivarActivarColaboradores(Id, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { Id, Estado },
        url: "/Usuario/DesactivarActivarColaboradores/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosLosColaboradores();
            } else {
                $("#msjModalIncorrecto").html("<label>¡No se pudo actualizar el estado del Colaborador!</label>");
                $('#MsjIncorrecto').modal('show');
            }

        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡No se pudo actualizar el estado del Colaborador!</label>");
            $('#MsjIncorrecto').modal('show');
        }
    });


}

$(document).ready(function () {
    ObtenerTodosLosColaboradores();
});