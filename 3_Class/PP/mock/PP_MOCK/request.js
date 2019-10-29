window.document.getElementById("request-form").onsubmit = function() {
    let errorTextElement = window.document.getElementById("request-message");
    let name = window.document.getElementById("name-input").value;

    if(!name) {
        errorTextElement.innerText = "Bitte gib einen gültigen Namen an!";
        return false;
    }

    let password = Utils.RandomString(PASSWORD_LENGTH, PASSWORD_LOWERCASE);
    errorTextElement.innerText = `Dein Einmalpasswort lautet '${password}'!`;

    let id = Utils.AddOrganizer(password, name);
    Utils.AddPassword(password, {
        passwordType: "ADD",
        organizerId: id
    });

    window.document.getElementById("request-button").setAttribute("disabled", "");
    return false;
};