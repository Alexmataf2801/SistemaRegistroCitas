document.getElementById("Ojo").addEventListener("click", () => {
    if (document.getElementById("txtPassword").type == "password") {
        document.getElementById("txtPassword").type = "text";
        document.getElementById("Ojo").classList.remove("fa-eye");
        document.getElementById("Ojo").classList.add("fa-eye-slash");
    } else {
        document.getElementById("txtPassword").type = "password";
        document.getElementById("Ojo").classList.remove("fa-eye-slash");
        document.getElementById("Ojo").classList.add("fa-eye");
    }

});


