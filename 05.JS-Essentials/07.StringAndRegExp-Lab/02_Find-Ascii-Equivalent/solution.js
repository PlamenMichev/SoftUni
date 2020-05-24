function solve() {
  let symbols = document.getElementById('text').value;
  let outputBox = document.getElementById('result');
  let finalWord = document.createElement('p');
  symbols.split(' ').forEach(element => {
    if (Number.isNaN(Number(element))) {
      let asciiCodes = '';

      for (let i = 0; i < element.length; i++) {
        const letter = element[i];
        asciiCodes += `${letter.charCodeAt(0)} `;
      }
      let line = document.createElement('p');
      line.textContent = asciiCodes.trim();
      outputBox.appendChild(line);
    } else {
      finalWord.textContent += String.fromCharCode(Number(element));
    }
  });

  outputBox.appendChild(finalWord);
}