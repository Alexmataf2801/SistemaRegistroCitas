function SolicitarPeticion() {
     
    var NombreCliente = $("#NombreCliente").val();      
    var CorreoCliente = $("#CorreoCliente").val();
    var NombrePlan = $("#NombrePlan").val();     
    var MensajeCliente = $("#MensajeCliente").val();
   
    var ValidarCorreo = /^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;

    if (!ValidarCorreo.test($("#CorreoCliente").val())) {      
        $("#msjModal").html("<label>¡El CorreoElectronico no es valido!</label>");
        $('#MsjIncorrecto').modal('show');
    }
    else { 
        
        if ($("#NombreCliente").val() == '' || $("#CorreoCliente").val() == '' || $("#NombrePlan").val() == '' || $("#MensajeCliente").val() == '') {
            
            $("#msjModal").html("<label>¡Faltan datos, vuelva a intentarlo!</label>");
            $('#MsjIncorrecto').modal('show');

        } else {

            $.ajax({
                type: "POST",
                dataType: "JSON",
                url: "/Usuario/PeticionRegistro/",
                data: { NombreCliente, CorreoCliente, NombrePlan, MensajeCliente },
                success: function (Info) {

                    switch (Info) {

                        case 0:                          
                            $("#msjModal").html("<label>¡No se puedo enviar el correo, vuelva a intentarlo!</label>");
                            $('#MsjIncorrecto').modal('show');
                            break;
                        case 1:                           
                            $("#lblTituloCorrecto").html("<label>Correcto</label>");
                            $("#lblMensajeCorrecto").html("<label>¡Se envio el correo de su solicitud!</label>");
                            $('#MsjCorrecto').modal('show');
                            LimpiarValores();
                            break;                        

                        default:
                            alert("no se envio");
                    }

                },
                error: function (Error) {
                    alert("Se Cayo");
                }

            });

           

        }

    }
}

function LimpiarValores() {
    $("#NombreCliente").val('');
    $("#CorreoCliente").val('');
    $("#NombrePlan").val('');
    $("#MensajeCliente").val('');  
}