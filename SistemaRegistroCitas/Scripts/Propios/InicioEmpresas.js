function ObtenerEmpresasXId() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/InicioEmpresas/ObtenerEmpresasXId/",

        success: function (InfoEmpresas) {

            console.log(InfoEmpresas);

            $("#txtNombreEmpresa").val(InfoEmpresas.Nombre);
            $("#txtContactoEmpresa").val(InfoEmpresas.Telefono);

            
          

        },

        error: function () {
            console.log('error')
        },

    });
}

//$(document).ready(function () {
//    //ObtenerEmpresasXId();
//});



//function ObtenerHorarioEmpresa() {
//    $.ajax({
//        type: "GET",
//        dataType: "JSON",
//        url: "/Empresa/ObtenerHorarioEmpresa/",

//        success: function (InfoEmpresas) {
                       
//            document.getElementById('InicioLunes').innerHTML = InfoEmpresas.InicioLunes.Hours
//            document.getElementById('FinalLunes').innerHTML = InfoEmpresas.FinalLunes.Hours






//        },

//        error: function () {
//            console.log('error')
//        },

//    });
//}


function InsertarHorarioEmpresa() {
    var EstadoLunes = $("#EstadoLunes").is(':checked')
    var EstadoMartes = $("#EstadoMartes").is(':checked')
    var EstadoMiercoles = $("#EstadoMiercoles").is(':checked')
    var EstadoJueves = $("#EstadoJueves").is(':checked')
    var EstadoViernes = $("#EstadoViernes").is(':checked')
    var EstadoSabado = $("#EstadoSabado").is(':checked')
    var EstadoDomingo = $("#EstadoDomingo").is(':checked')
    var horarioEmpresa = {
        InicioLunes: $("#InicioLunes").val(),
        FinalLunes: $("#FinalLunes").val(),     
        InicioMartes: $("#InicioMartes").val(),
        FinalMartes: $("#FinalMartes").val(),
        InicioMiercoles: $("#InicioMiercoles").val(),
        FinalMiercoles: $("#FinalMiercoles").val(),
        InicioJueves: $("#InicioJueves").val(),
        FinalJueves: $("#FinalJueves").val(),
        InicioViernes: $("#InicioViernes").val(),
        FinalViernes: $("#FinalViernes").val(),
        InicioSabado: $("#InicioSabado").val(),
        FinalSabado: $("#FinalSabado").val(),
        InicioDomingo: $("#InicioDomingo").val(),
        FinalDomingo: $("#FinalDomingo").val(),       

    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/InicioEmpresas/InsertarHorarioEmpresa/",
        data: { horarioEmpresa, EstadoLunes, EstadoMartes, EstadoMiercoles, EstadoJueves, EstadoViernes, EstadoSabado, EstadoDomingo },
        success: function (Info) {

            switch (Info) {
                case 1:
                    LimpiarValores();
                    $("#lblMensajeCorrecto").html("<label>¡Horario asignado Correctamenta!</label>");
                    $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    break;
                case 2:
                    $("#msjModalIncorrecto").html("<label>¡Ya existe un horario asignado!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                default:
                    $("#msjModalIncorrecto").html("<label>¡Hubo un error, vuelva a intentarlo!</label>");
                    $('#MsjIncorrecto').modal('show');
            }



            //if (Info) {
            //    $("#lblMensajeCorrecto").html("<label>¡Horarios Insertados Correctamente!</label>");
            //    $("#lblTituloCorrecto").html("<label>Información</label>");
            //    $('#MsjCorrecto').modal('show');
            //} else {
            //    $("#msjModalIncorrecto").html("<label>¡Fallo el Insertar Horario!</label>");
            //    $('#MsjIncorrecto').modal('show');
            //}


        },
        error: function (Error) {
            alert("Se Cayo");
        }

    });


}

function LimpiarValores() {
    $("#txtNombre").val('');

    $("#InicioLunes").val('');
    $("#FinalLunes").val('');
    $("#InicioMartes").val('');
    $("#FinalMartes").val('');
    $("#InicioMiercoles").val('');
    $("#FinalMiercoles").val('');
    $("#InicioJueves").val('');
    $("#FinalJueves").val('');
    $("#InicioViernes").val('');
    $("#FinalViernes").val('');
    $("#InicioSabado").val('');
    $("#FinalSabado").val('');
    $("#InicioDomingo").val('');
    $("#FinalDomingo").val('');
   
}




$(document).ready(function () {
    ObtenerEmpresasXId();
    //ObtenerHorarioEmpresa();
});