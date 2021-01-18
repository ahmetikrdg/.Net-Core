function playSong(song) {
    var player = document.getElementById("player_youtube");
    player.innerHTML = "";
    player.innerHTML = '<iframe id="iframe' + song + '" src="https://www.youtube.com/embed/' + song + '" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>';
}