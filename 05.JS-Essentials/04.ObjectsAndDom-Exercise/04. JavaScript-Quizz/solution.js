function solve() {
  let sectionElements = document.getElementsByTagName('section');
  let firstWholeSection = sectionElements[0];
  let firstSectionElement = sectionElements[0].querySelectorAll('p');
  let secSectionElement = sectionElements[1];
  let thirdSectionElement = sectionElements[2];
  let resultElement = document.getElementById('results');
  let rightAnswers = 0;
  for (let i = 0; i < firstSectionElement.length; i++) {
    const element = firstSectionElement[i];
    element.addEventListener('click', () => {
      if (i == 0) {
        rightAnswers++;
      }

      firstWholeSection.style.display = 'none';
      secSectionElement.style.display = 'block';
      let secSectionElements = sectionElements[1].querySelectorAll('p');
      console.log(sectionElements[1]);
      console.log(secSectionElements);
      for (let i = 0; i < secSectionElements.length; i++) {
        const element = secSectionElements[i];
        element.addEventListener('click', () => {
            if (i == 1) {
              rightAnswers++;
            } 
            console.log(rightAnswers);

            secSectionElement.style.display = 'none';
            thirdSectionElement.style.display = 'block';

            let thirdSectionElements = sectionElements[2].querySelectorAll('p');

            for (let i = 0; i < thirdSectionElements.length; i++) {
              const element = thirdSectionElements[i];
              element.addEventListener('click', () => {
                if (i == 0) {
                  rightAnswers++;
                }

                console.log(resultElement);
                let outputElement = resultElement.querySelector('h1');
                thirdSectionElement.style.display = 'none';
                if (rightAnswers == 3) {
                  outputElement.textContent = "You are recognized as top JavaScript fan!";
                } else {
                  outputElement.textContent = `You have ${rightAnswers} right answers`
                }
                resultElement.style.display = 'block';
              })
            }
        })    
      }
    })
  }

}
