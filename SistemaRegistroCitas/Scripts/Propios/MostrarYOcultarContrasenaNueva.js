document.getElementById("OjoNueva").addEventListener("click", () => {
    if (document.getElementById("txtNuevaContrasena").type == "password") {
        document.getElementById("txtNuevaContrasena").type = "text";
        document.getElementById("OjoNueva").classList.remove("fa-eye");
        document.getElementById("OjoNueva").classList.add("fa-eye-slash");
    } else {
        document.getElementById("txtNuevaContrasena").type = "password";
        document.getElementById("OjoNueva").classList.remove("fa-eye-slash");
        document.getElementById("OjoNueva").classList.add("fa-eye");
    }

});