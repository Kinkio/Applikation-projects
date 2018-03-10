$(document).ready(function () {
    $(".nav li a, .navbar-brand").click(function (event) {
        event.preventDefault();
        var href = this.href;
        $(".bgArrowLeft, .page").animate({
            left: '2000pt'
        }, 1200,
            function () {
                window.location = href;
            });

    });
});

