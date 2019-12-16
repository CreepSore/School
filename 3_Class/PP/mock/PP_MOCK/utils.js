class Utils {
    static RandomString(length, useLowercase = false) {
        let usedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if(useLowercase) {
            usedChars += usedChars.toLowerCase();
        }
        usedChars += "1234567890";

        let result = "";
        for(let i = 0; i < length; i++) {
            result += usedChars[Math.floor(Math.random()*usedChars.length)];
        }
        return result;
    }

    static AddOrganizer(password, name) {
        let organizers = JSON.parse(window.localStorage.getItem("organizers"));

        organizers.push({
            id: password,
            name: name,
            events: []
        });

        window.localStorage.setItem("organizers", JSON.stringify(organizers));

        return organizers.length - 1;
    }

    static AddOrgaEvent(organizerId, name, date, description) {
        let organizers = JSON.parse(window.localStorage.getItem("organizers"));

        let organizer = organizers[organizerId];

        if(!organizer) {
            return false;
        }

        organizer.events.push({
            organizerId: organizerId,
            name: name,
            addDate: Date.now(),
            date: date,
            description: description
        });

        window.localStorage.setItem("organizers", JSON.stringify(organizers));
        return true;
    }

    static AddPassword(password, object) {
        let passwords = JSON.parse(window.localStorage.getItem("passwords"));

        passwords[password] = object;

        window.localStorage.setItem("passwords", JSON.stringify(passwords));
    }
}

window.onerror = function(message, source, lineno, colno, error) {
    window.location.href = "reset_mock.html";
	return false;
};