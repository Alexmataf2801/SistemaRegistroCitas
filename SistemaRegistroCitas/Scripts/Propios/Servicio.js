function ObtenerServicios() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ObtenerServiciosXColaboradorXId/",
        data: { "IdColaborador": $("#Colaboradores").val()},
        success: function (InfoServicios) {

                                   
            var clasificacion = $("#Servicios");

            clasificacion.empty();
            clasificacion.append('<option value="0">Seleccione uno...</option>');

            $(InfoServicios).each(function (i, v) {
                clasificacion.append('<option value="' + v.IdServicio + '">' + v.NombreServicio + '</option>');
                                          
            
            });


        },

        error: function () {
            console.log('error')
        },

    });
}


function ServicioXId() {

    if ($("#Servicios").val() !== "0") {
        $("#btnReservar").prop("disabled", false);
 
        $.ajax({
            type: "GET",
            dataType: "JSON",
            url: "/Servicio/ServicioXId/",
            data: { "Id": $("#Servicios").val() },

            success: function (InfoServicio) {
                $("#TiempoAprox").val(InfoServicio.TiempoEstimado + " " + InfoServicio.UnidadMedida);
                $("#txtDescripcionServicio").val(InfoServicio.Descripcion);

                var tiempofinal;

                var tiempoInicial = $('#txtHorarioOculta').val();

                switch (InfoServicio.UnidadMedida) {
                    case 'Horas':
                        tiempofinal = moment(tiempoInicial).add(InfoServicio.TiempoEstimado, 'hours');
                        break;
                    case 'Minutos':
                        tiempofinal = moment(tiempoInicial).add(InfoServicio.TiempoEstimado, 'minutes');
                        break;
                }

                $('#TiempoFinal').val(moment(tiempofinal).format('DD-MM-YYYY hh:mm A'));
                $('#txtFinalHorarioOculto').val(moment(tiempofinal).format('YYYY-MM-DD[T]HH:mm:ss'));
            },

            error: function () {
                console.log('error')
            },

        });
    } else {
        $("#btnReservar").prop("disabled", true);
        $("#TiempoAprox").val('');
    }

   
}

function InsertarDatosServicios() {
    var servicio = {
        Nombre: $("#txtServicio").val(),
        TiempoEstimado: $("#txtTiempoEstimado").val(),
        Descripcion: $("#txtDescripcion").val(),
        TipoUnidad: $("#TipoUnidad").val(),

    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Servicio/InsertarDatosServicios/",
        data: { servicio },
        success: function (Info) {
            if (Info) {
                LimpiarValores();
                $("#lblMensajeCorrecto").html("<label>¡Información Almacenada Correctamenta!</label>");
                $("#lblTituloCorrecto").html("<label>Información</label>");
                $('#MsjCorrecto').modal('show');
            } else {
                $("#msjModalIncorrecto").html("<label>¡Fallo en la creación del servicio!</label>");
                $('#MsjIncorrecto').modal('show');
            }
           

        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}


function LimpiarValores() {
    $("#txtServicio").val("")
    $("#txtTiempoEstimado").val("")
    $("#txtDescripcion").val("")
    $("#TipoUnidad").val("")

}


$("#Servicios").change(function () {
    ServicioXId();
});



