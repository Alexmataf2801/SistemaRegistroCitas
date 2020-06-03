function ObtenerTodosLosRoles() {
    $.ajax({
        type: "GET",
        url: "/Roles/ObtenerTodoLosRoles",
        dataType: "JSON",
        success: function (Info) {

            var TablaRoles = $('#tbRoles').DataTable(
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
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='ObtenerRolXId(" + value.Id + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarRol(" + value.Id + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarRol(" + value.Id + ")'></a>";

                TablaRoles.row.add([Editar, value.Nombre, value.Descripcion, estado, CambiarEstado, Eliminar]).draw();
            });


        },
        error: function (Error) {
        }
    });
}

function ObtenerRolXId(IdRol) {
    sessionStorage.setItem("IdRolEditar", IdRol);
    location.href = '/Roles/ActualizarRol';
}

function ConfirmarEliminarRol(IdRol) {
    $("#IdRolSeleccionado").val(IdRol);
    $("#msjConfRol").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionRol').modal('show');

}

function EliminarRol() {
    var Id = $("#IdRolSeleccionado").val();
    $('#ModalConfirmacionRol').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Roles/ElimnarRol/",
            data: { IdRol: Id },
            success: function () {
                $("#lblMensajeCorrecto").html("<label>¡Rol Eliminado Correctamente!</label>");
                $("#lblTituloCorrecto").html("<label>Información</label>");
                $('#MsjCorrecto').modal('show');
                ObtenerTodosLosRoles();
            },
            error: function () {
                $("#msjModalIncorrecto").html("<label>¡Algo Fallo!</label>");
                $('#MsjIncorrecto').modal('show');
            }
        });

    }
}

function DesactivarActivarRol(IdRol, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdRol, Estado },
        url: "/Roles/DesactivarActivarRol/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosLosRoles();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

$(document).ready(function () {
    ObtenerTodosLosRoles();
});