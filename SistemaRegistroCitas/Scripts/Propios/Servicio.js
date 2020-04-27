function ObtenerServicios() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Servicio/ObtenerServicios/",

        success: function (InfoServicios) {

                                   
            var clasificacion = $("#Servicios");

            $(InfoServicios).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');
                                          
            
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

function InsertarServicios() {
    var servicios = {
        Nombre: $("#txtServicio").val(),
        TiempoEstimado: $("#txtTiempoEstimado").val(),
        Descripcion: $("#txtDescripcion").val(),
        Identificacion: $("#txtDescripcion").val(),
        TipoUnidad: $("#TipoUnidad").val(),
        Telefono: $("#txtTelefono").val(),
        Genero: $("#IdPerfil").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Servicio/InsertarServicios/",
        data: { servicios },
        //success: function (Info) {
        //    switch (Info) {
        //        case 0:
        //            $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
        //            $('#MsjIncorrecto').modal('show');
        //            break;
        //        case 1:
        //            LimpiarValores();
        //            $('#fm-modal').modal('hide');
        //            $('#MsjCorreo').modal('show');
        //            break;
        //        case 2:
        //            $("#msjModal").html("<label>¡La Identificación ingresada ya existe!</label>");
        //            $('#MsjIncorrecto').modal('show');
        //            break;
        //        default:
        //            $("#msjModal").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
        //            $('#MsjIncorrecto').modal('show');
        //    }

        //},
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}






















$("#Servicios").change(function () {
    ServicioXId();
})


$(document).ready(function () {
    ObtenerServicios();
});

