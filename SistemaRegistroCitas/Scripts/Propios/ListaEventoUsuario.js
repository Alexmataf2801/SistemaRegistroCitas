function ObtenerTodosLosEventosXIdUsuario() {
    $.ajax({
        type: "GET",
        url: "/Eventos/ObtenerTodosLosEventosXIdUsuario",
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
                var TipoUnidad = value.TipoUnidadEvento;
                var IdServicio = value.IdServicio;

                if (TipoUnidad != 1) {
                    switch (IdServicio) {
                        case 1:
                            IdServicio = "1 Hora Libre"
                            break;
                        case 2:
                            IdServicio = "30 Minutos Libres"
                            break;
                        case 3:
                            IdServicio = "Dia libre"
                            break;                       
                        default:
                            break;
                    }
                } else {
                    IdServicio = value.Nombre
                }

                //var estado = '';
                //if (value.Estado) {
                //    estado = "<span class='EstadoActivo' >Activo</span>";
                //} else {
                //    estado = "<span class='EstadoInactivo' >Inactivo</span>";
                //}
                //var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='ServicioXId(" + value.Id + ")'></a>";
                //var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarServicios(" + value.Id + "," + value.Estado + " )'></a>";
                //var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarEvento(" + value.Id + ")'></a>";

                TablaRoles.row.add([value.UsuarioCreacion, IdServicio, HorarioInicial, HoraFinal]).draw();
            });
            
        },
        error: function (Error) {
        }
    });
}

$(document).ready(function () {  
    ObtenerTodosLosEventosXIdUsuario();
});