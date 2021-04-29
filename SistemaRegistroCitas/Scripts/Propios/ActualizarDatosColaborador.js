function ActualizarDatosColaborador() {
    var Id = sessionStorage.getItem("IdColaboradorEditar");
    var ValidarCorreo = /^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
    var Usuario = {
        Id: Id,
        Identificacion: $("#txtIdentificacionColaborador").val(),
        Nombre: $("#txtNombreColaborador").val(),
        PrimerApellido: $("#txtPrimerApellidoColaborador").val(),
        SegundoApellido: $("#txtSegundoApellidoColaborador").val(),
        CorreoElectronico: $("#txtCorreoElectronicoColaborador").val(),
        Telefono: $("#txtTelefonoColaborador").val(),
        Genero: $("#ddlGenero").val(),
        IdRol: $("#ddlRol").val()

    };

    if ($("#txtCorreoElectronicoColaborador").val() === "" ||
        $("#txtNombreColaborador").val() === "" ||
        $("#txtPrimerApellidoColaborador").val() === "" ||
        ValidarCorreo.test($("#txtCorreoElectronicoColaborador").val()) === false) {
        $("#msjModalIncorrecto").html("<label>¡Falta complementar datos importantes o el Correo Electronico no es valido!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else {
   
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Usuario/ActualizarColaboradores/",
        data: { usuarios: Usuario },
        success: function (Info) {


            switch (Info) {

                case 0:
                    $("#msjModalIncorrecto").html("<label>¡No se puede actualizar el Correo ingresado ya existe!</label>");
                    $('#MsjIncorrecto').modal('show');
                    break;
                case 1:
                     $("#msjCorrectoActColaborador").html("<label>¡Colaborador Actualizado Correctamente!</label>");
                     $('#ModalCorrectoActColaborador').modal('show');
                     LimpiarCampos();
                    break;
                case 2:
                    $("#msjModalIncorrecto").html("<label>¡Su plan no permite mas colaboradores con ese tipo de rol!</label>");
                    $('#MsjIncorrecto').modal('show');                 
                    break;
                default:
                    $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Colaborador!</label>");
                    $('#MsjIncorrecto').modal('show');
            }           
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el Colaborador!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });

    }
}


function ObtenerDatosColaborador() {
    var Id = sessionStorage.getItem("IdColaboradorEditar");
    ObtenerTodoLosRoles();
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Usuario/ObtenerColaboradoresXId/",
        data: { Id: Id },
        success: function (Info) {
            if (Info) {
                $("#txtIdentificacionColaborador").val(Info.Identificacion);
                $("#txtNombreColaborador").val(Info.Nombre);
                $("#txtPrimerApellidoColaborador").val(Info.PrimerApellido);
                $("#txtSegundoApellidoColaborador").val(Info.SegundoApellido);
                $("#txtCorreoElectronicoColaborador").val(Info.CorreoElectronico);
                $("#txtTelefonoColaborador").val(Info.Telefono);
                if (Info.Genero) {
                    $("#ddlGenero").val(1);
                } else {
                    $("#ddlGenero").val(0);
                }
                
                $("#ddlRol").val(Info.IdRol);


            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Error al obtener datos del Colaborador!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });


}

function RedireccionarColaboradores() {
    location.href = '/Usuario/ListaColaboradores/';
}

    function LimpiarCampos() {
        $("#txtIdentificacionColaborador").val("");
        $("#txtNombreColaborador").val("");
        $("#txtPrimerApellidoColaborador").val("");
        $("#txtSegundoApellidoColaborador").val("");
        $("#txtCorreoElectronicoColaborador").val("");
        $("#txtTelefonoColaborador").val("");
        $("#ddlGenero").val("");
        $("#ddlRol").val("");
    }


$(document).ready(function () {
    ObtenerDatosColaborador();
});



function ObtenerTodoLosRoles() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Roles/ObtenerTodoLosRoles/",

        success: function (InfoServicios) {


            var clasificacion = $("#ddlRol");

            $(InfoServicios).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');


            });


        },

        error: function () {
            console.log('error')
        },

    });
}

