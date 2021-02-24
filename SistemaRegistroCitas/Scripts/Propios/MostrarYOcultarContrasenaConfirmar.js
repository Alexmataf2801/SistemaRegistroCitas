document.getElementById("OjoConfirmar").addEventListener("click", () => {
    if (document.getElementById("txtConfirmaContrasena").type == "password") {
        document.getElementById("txtConfirmaContrasena").type = "text";
        document.getElementById("OjoConfirmar").classList.remove("fa-eye");
        document.getElementById("OjoConfirmar").classList.add("fa-eye-slash");
    } else {
        document.getElementById("txtConfirmaContrasena").type = "password";
        document.getElementById("OjoConfirmar").classList.remove("fa-eye-slash");
        document.getElementById("OjoConfirmar").classList.add("fa-eye");
    }

});
