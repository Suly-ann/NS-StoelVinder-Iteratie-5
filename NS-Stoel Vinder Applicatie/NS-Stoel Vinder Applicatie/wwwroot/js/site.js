
function myFunction(form) {
    var txt;
    if (!confirm("Wil u uw account zeker verwijderen?")) {
        return false;
    }
    else {
        txt = "";
        return true;
    }
    document.getElementById("demo").innerHTML = txt;
}

