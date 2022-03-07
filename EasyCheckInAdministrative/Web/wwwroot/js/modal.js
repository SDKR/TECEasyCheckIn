////////////////// DELETE MODAL //////////////////
window.loadModal = function () {
    var modal = document.getElementById("modal");

    var btns = document.querySelectorAll(".modalBtn");

    // Når en bruger trykker på Slet, åben modal
    btns.forEach(btn => btn.onclick = function () {
        modal.style.display = "block";
    })

    // Når en bruger annullere, skjul modal
    window.hideModal = function() {
        modal.style.display = "none";
    }
};