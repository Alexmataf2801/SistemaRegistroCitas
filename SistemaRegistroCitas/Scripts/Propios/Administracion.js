function ObtenerMenuGeneral() {
    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Administracion/ObtenerMenuGeneral/",
        success: function (Info) {
            $("#DivArbol").html(Info);
        },
        error: function () {
            console.log('error');
        }

    });
}

function ObtenerCombosCheckeados() {
    var selected = [];
    $('#DivArbol input:checked').each(function () {
        selected.push($(this).attr('id'));
    });
    return selected;
}

function GuardarCombosMarcados() {

    var Marcados = ObtenerCombosCheckeados();

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdUsuario: $("#ddlUsuarios").val(), ListaPermisos: Marcados },
        url: "/Administracion/InsertarPermisosXUsuario/",
        success: function (Info) {
            $("#lblMensajeCorrecto").html("<label>¡Información Almacenada Correctamenta!</label>");
            $("#lblTituloCorrecto").html("<label>Información</label>");
            $('#MsjCorrecto').modal('show');
        },
        error: function () {
            console.log('error');
        }

    });

}


function ObtenerTodosUsuarios() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Usuario/ObtenerTodosUsuarios/",
        success: function (Info) {
            var Usuarios = $("#ddlUsuarios");

            $(Info).each(function (i, v) {
                Usuarios.append('<option value="' + v.Id + '">' + v.NombreCompleto + '</option>');


            });
        },
        error: function () {
            console.log('error');
        }

    });

}


$(document).ready(function () {
    ObtenerMenuGeneral();
    ObtenerTodosUsuarios();
});
