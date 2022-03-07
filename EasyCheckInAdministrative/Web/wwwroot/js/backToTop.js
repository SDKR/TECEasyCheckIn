/* REQUIRES JQUERY NON SLIM VERSION */
$(document).scroll(function () {
    var y = $(this).scrollTop();
    if (y > 80) {
        $('.toTopDiv').fadeIn();
    } else {
        $('.toTopDiv').fadeOut();
    }
});

function toTop() {
    document.querySelector('#mainNavbar').scrollIntoView({
        behavior: 'smooth'
    });
}