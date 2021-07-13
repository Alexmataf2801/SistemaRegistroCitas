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

                var Nombre = value.Nombre;
                var HorarioInicial = moment(value.HorarioInicial).format('DD-MM-YYYY HH:mm A');
                var HoraFinal = moment(value.HoraFinal).format('DD-MM-YYYY HH:mm A');               
               

                TablaRoles.row.add([value.UsuarioCreacion, Nombre, HorarioInicial, HoraFinal]).draw();
            });

            $('#cargando').html(' ')
        },
        error: function (Error) {
        }
    });
}

$(document).ready(function () {  
    ObtenerTodosLosEventosXIdUsuario();
});