$(document).ready(function () {

    var randomStars = ((Math.random() * 40) + 35);
    for (i = 0; i < randomStars; i++) {
        var placeStarTop = ((Math.random() * 300) + -20);
        var placeStarleft = ((Math.random() * 500) -50);

        $('#starSpace').append('<div class="star" style="top:' + placeStarTop + 'pt; left:' + placeStarleft + 'pt;"></div>');
    }
});

