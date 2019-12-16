let organizers;
let passwords;
let organizerId;

const checkStorage = function() {
    if(!organizerId) window.location.href = "reset_mock.html";
};

const setupView = function() {
    window.document.getElementById("mock:organizer_title").innerText = organizers[organizerId].name;
};

window.document.getElementById("add-form").onsubmit = function() {
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

    Utils.AddOrgaEvent(organizerId, name, date, description);

    let password = "";
    Object.keys(passwords).forEach(e => {
        let pw = passwords[e];
        if(pw.passwordType === "ADD" && pw.organizerId == organizerId) {
            password = e;
        }
    });

    Utils.AddPassword(password, {
        passwordType: "EDIT",
        organizerId: organizerId,
        eventId: organizers[organizerId].events.length
    });

    window.document.getElementById("error").innerText = "Veranstaltung angemeldet! Weiterleitung in 3 Sekunden ...";


    setTimeout(() => {
        window.localStorage.removeItem("organizer");
        window.location.href = "login.html";
    }, 3000);

    return false;
};

const ImportStorage = function() {
    organizers = JSON.parse(window.localStorage.getItem("organizers"));
    passwords = JSON.parse(window.localStorage.getItem("passwords"));
    organizerId = window.localStorage.getItem("organizer");
};

const ExportStorage = function() {
    window.localStorage.setItem("organizers", organizers);
    window.localStorage.setItem("passwords", passwords);
    window.localStorage.setItem("organizer", organizerId);
};

ImportStorage();
checkStorage();
setupView();