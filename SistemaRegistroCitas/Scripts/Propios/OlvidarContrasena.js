function OlvidarContrasena()
{  
         var CorreoElectronico = $("#txtCorreo_Olvidado").val();  

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

}