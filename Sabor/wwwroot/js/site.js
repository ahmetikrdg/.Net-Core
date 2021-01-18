$('.play-icon').click(function () {
	var video = '<iframe allowfullscreen src="' + $(this).attr('data-video') + '"></iframe>';
	$(this).replaceWith(video);
});

$('.play-icon').mousemove(function (e) {
	var parentOffset = $(this).offset();
	var relX = e.pageX - parentOffset.left;
	var relY = e.pageY - parentOffset.top;
	$(".play-button").css({ left: relX, top: relY });
});
$('.play-icon').mouseout(function () {
	$(".play-button").css({ left: '50%', top: '50%' });
});