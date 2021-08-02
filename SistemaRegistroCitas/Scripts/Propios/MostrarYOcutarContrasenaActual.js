document.getElementById("OjoActual").addEventListener("click", () => {
    if (document.getElementById("txtContrasenaActual").type == "password") {
        document.getElementById("txtContrasenaActual").type = "text";
        document.getElementById("OjoActual").classList.remove("fa-eye");
        document.getElementById("OjoActual").classList.add("fa-eye-slash");
    } else {
        document.getElementById("txtContrasenaActual").type = "password";
        document.getElementById("OjoActual").classList.remove("fa-eye-slash");
        document.getElementById("OjoActual").classList.add("fa-eye");
    }

});