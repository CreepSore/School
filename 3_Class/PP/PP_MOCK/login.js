const loginForm = window.document.getElementById("login-form");
const loginButton = window.document.getElementById("login");
const passwordInput = window.document.getElementById("password");

let organizers = JSON.parse(window.localStorage.getItem("organizers"));
let passwords = JSON.parse(window.localStorage.getItem("passwords"));

const handlePassword = function (password) {
    let pw = passwords[password];
    if (!pw) {
        return false;
    }

    if (pw.passwordType === "ADD") {
        let organizer = organizers[passwords[passwordInput.value]["organizerId"]];

        // Reload Page if the Password is invalid
        if (!organizer) {
            return true;
        }

        window.localStorage.setItem("mockstep", String(1));
        window.localStorage.setItem("organizer", passwords[passwordInput.value]["organizerId"]);
        window.location.href = "add.html";
    } else if (pw.passwordType === "EDIT") {
        window.localStorage.setItem("edit", JSON.stringify(pw));
        window.location.href = "edit.html";
    }
    
    return false;
};

loginForm.onsubmit = function () {
    console.debug(`Logging in with Password '${passwordInput.value}'`);

    return handlePassword(passwordInput.value);
};

window.localStorage.setItem("mockstep", String(0));
