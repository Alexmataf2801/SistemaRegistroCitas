function OlvidarContrasena() {
  
    var CorreoElectronico = $("#txtCorreo_Olvidado").val();

    //var ValidarCorreo = /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
    //if (!ValidarCorreo.test($("#txtCorreo_Olvidado").val())) {
    //    $("#msjModalIncorrecto").html("<label>¡El CorreoElectronico no es valido!</label>");
    //    $('#MsjIncorrecto').modal('show');
    //}
    //else {

        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Usuario/OlvidoContrasena/",
            data: { CorreoElectronico },
            success: function (Info) {


                if (Info) {
                    $("#lblMensajeCorrecto").html("<label>¡Contraseña enviada Correctamenta!</label>");
                        $("#lblTituloCorrecto").html("<label>Información</label>");
                    $('#MsjCorrecto').modal('show');
                    $('#OlvidarContrasena').modal('hide');
                }
                else {
                    $("#msjModal").html("<label>¡No se pudo realizar su solicitud!</label>");
                    $('#MsjIncorrecto').modal('show');
                }

             
                
            },
            error: function (Error) {
                console.log(Error)
                alert("Se Cayo");
            }

        });
    //}

}