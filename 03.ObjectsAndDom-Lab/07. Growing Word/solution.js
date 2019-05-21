function growingWord() {
  let colors = ['red', 'blue', 'green',];
  let growingWordElement = document.querySelector('#exercise p');
  growingWordElement.clicks = growingWordElement.clicks + 1 || 1;
  growingWordElement.style.color =  colors[growingWordElement.clicks % 3];
  growingWordElement.style.fontSize = `${2 ** growingWordElement.clicks}px`;
}