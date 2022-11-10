$(document).on('ready', function () {

    $(".landing_hamburger").click(function () {
        $(".login_section").toggle();
    });

});

//Fixed header
$(window).bind('scroll load', function () {
    var scroll = $(window).scrollTop();
    $('.landing_header').css("background-color", "transparent");
    if (scroll >= 1) {
        $(".landing_header").addClass("header-change");
        $('.landing_header').css("background-color", "rgba(62,210,253,0.9)");
    } else {
        $(".landing_header").removeClass("header-change");
        $('.landing_header').css("background-color", "transparent");
    }
});


$(".menu-toggle").click(function (e) {
    e.preventDefault();
    $(".page_wrapper").toggleClass("active");
});



$(window).bind("load resize", function () {
    var width = $(window).width();
    if (width <= 992) {
        $(".page_wrapper").removeClass("active");
    } else {
        $(".page_wrapper").addClass("active");
    }
});
 
