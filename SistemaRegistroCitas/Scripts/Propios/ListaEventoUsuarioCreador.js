﻿function ObtenerTodosLosEventosXIdUsuarioCreador() {
    $.ajax({
        type: "GET",
        url: "/Eventos/ObtenerTodosLosEventosXIdUsuarioCreador",
        dataType: "JSON",
        success: function (Info) {

            var TablaRoles = $('#tbEventos').DataTable(
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

                var HorarioInicial = moment(value.HorarioInicial).format('DD-MM-YYYY HH:mm A');
                var HoraFinal = moment(value.HoraFinal).format('DD-MM-YYYY HH:mm A');            
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarEvento(" + value.Id + ")'></a>";

                TablaRoles.row.add([value.NombreColaborador, value.NombreServicio, HorarioInicial, HoraFinal, Eliminar]).draw();
            });

            $('#cargando').html(' ')
        },
        error: function (Error) {
        }
    });
}

function ConfirmarEliminarEvento(Id) {
    $("#IdEventosSeleccionado").val(Id);
    $("#msjConfEventos").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionEventos').modal('show');
}

function EliminarEventos() {
    var Id = $("#IdEventosSeleccionado").val();
    $('#ModalConfirmacionEventos').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Eventos/EliminarEventos/",
            data: { Id: Id },
            success: function (Info) {
                if (Info) {
                    $("#lblMensajeCorrecto").html("<label>¡Evento Eliminado Correctamente!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    ObtenerTodosLosEventosXIdUsuarioCreador();
                } else {
                    $("#msjModalIncorrecto").html("<label>¡El Evento no pudo ser eliminado!</label>");
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



$(document).ready(function () {
    ObtenerTodosLosEventosXIdUsuarioCreador();
});