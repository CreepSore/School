let organizers = JSON.parse(window.localStorage.getItem("organizers"));
let passwords = JSON.parse(window.localStorage.getItem("passwords"));
let event;

let editData;

window.addEventListener("load", () => {
    editData = window.localStorage.getItem("edit");
    if(!editData) {
        window.location.href = "login.html";
    }
    editData = JSON.parse(editData);

    event = organizers[editData.organizerId].events[editData.eventId];

    window.document.getElementById("name-input").value = event.name;
    window.document.getElementById("date-input").valueAsNumber = event.date;
    window.document.getElementById("description-input").value = event.description;
});

window.document.getElementById("edit-form").onsubmit = function() {
    let date = window.document.getElementById("date-input").valueAsNumber;
    let name = window.document.getElementById("name-input").value;
    let description = window.document.getElementById("description-input").value;

    if(!date || !name || !description) {
        window.document.getElementById("error").innerText = "Ungültige Daten!";
        return false;
    } else {
        window.document.getElementById("error").innerText = "";
    }

    if(Date.now() - date >= 0) {
        window.document.getElementById("error").innerText = "Ungültiges Datum!";
        return false;
    }

    event.date = date;
    event.name = name;
    event.description = description;

    window.localStorage.setItem("organizers", JSON.stringify(organizers));

    window.document.getElementById("error").innerText = "Veranstaltung editiert! Weiterleitung in 3 Sekunden ...";

    setTimeout(() => {
        window.localStorage.removeItem("edit");
        window.location.href = "login.html";
    }, 3000);

    return false;
};