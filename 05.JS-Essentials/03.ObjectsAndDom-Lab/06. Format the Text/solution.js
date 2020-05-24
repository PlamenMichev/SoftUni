function solve() {
  function solve() {
    let createTextElement = document.getElementById('input');
    let text = createTextElement.innerHTML;
    let textSentences = text.split('.');
    let numberOfSentences = textSentences.length;
    
    if(numberOfSentences <= 3) {
      let paragraphElement = document.createElement('p');
      paragraphElement.textContent = text;
      paragraphElement.setAttribute('id', 'output');
  
      let paragraphs = document.getElementById('output');
  
      paragraphs.appendChild(paragraphElement);
    }
    else {
      let currentSentences = [];
      
      for(let i = 0; i < numberOfSentences; i++) {
          let currentSentence = textSentences[i];
          currentSentences.push(currentSentence);
  
          if((i + 1) % 3 == 0 || i == numberOfSentences - 1) {
            let paragraph = document.createElement('p');
            for(let sentence of currentSentences) {
              if(sentence != '') {
                paragraph.textContent += sentence + '.';
              }
              
            }
            paragraph.setAttribute('id', 'output');
  
            let paragraphs = document.getElementById('output');
  
            paragraphs.appendChild(paragraph);
            currentSentences = new Array();
          }
      }
    }
  }
}