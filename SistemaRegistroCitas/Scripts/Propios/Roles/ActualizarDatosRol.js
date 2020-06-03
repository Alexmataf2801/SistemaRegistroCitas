function ActualizarDatosRol() {
    var Id = sessionStorage.getItem("IdRolEditar");
    var Rol = {
        Id: Id,
        Nombre: $("#txtNombre").val(),
        Descripcion: $("#txtDescripcionRol").val()
    };
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Roles/ActualizarRol/",
        data: { rol: Rol },
        success: function (Info) {
            if (Info) {
                $("#msjCorrectoActRol").html("<label>¡Rol Actualizado Correctamente!</label>");
                $('#ModalCorrectoActRol').modal('show');
                LimpiarCampos();
            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Algo fallo al actualizar el rol!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });

}

function ObtenerDatosRol() {
    var Id = sessionStorage.getItem("IdRolEditar");
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Roles/ObtenerRolXId/",
        data: { IdRol: Id },
        success: function (Info) {
            if (Info) {
                $("#txtNombre").val(Info.Nombre);
                $("#txtDescripcionRol").val(Info.Descripcion);

            }
        },
        error: function (Error) {
            $("#msjModalIncorrecto").html("<label>¡Error al obtener datos del rol!</label>");
            $('#MsjIncorrecto').modal('show');
        }

    });


}

function RedireccionarRoles() {
    location.href = '/Roles/ListaRoles/';
}

function LimpiarCampos() {
    $("#txtNombre").val("");
    $("#txtDescripcionRol").val("");
}

$(document).ready(function () {
    ObtenerDatosRol();
});