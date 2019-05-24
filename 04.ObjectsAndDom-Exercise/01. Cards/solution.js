function solve() {
   let firstPlayerElements = Array.from(document.getElementById('player1Div').querySelectorAll('*'));
   let secPlayerElements = Array.from(document.getElementById('player2Div').querySelectorAll('*'));
   let elements = document.images;
   let historyDiv = document.getElementById('history');

   let firstSpan = document.querySelector('#result :first-child');
   let secSpan = document.querySelector('#result :last-child');
   let firstNum = 0;
   let secNum = 0;
   let firstTarget;
   let secTarget;
   let firstCard = false;
   let secCard = false;
  for (let i = 0; i < elements.length; i++) {
     const element = elements[i];
     element.addEventListener('click', (e) => {
      let currentTarget = e.currentTarget;
      if (i < 8) {
            currentTarget.src = 'images/whiteCard.jpg';
            firstCard = true;
            firstSpan.innerHTML = currentTarget.name;
            firstTarget = currentTarget;
            firstNum = Number(currentTarget.name);
      } else {
         currentTarget.src = 'images/whiteCard.jpg';
         secSpan.innerHTML = currentTarget.name;
            secNum = Number(currentTarget.name);
            secTarget = currentTarget;
            secCard = true;
      }
      if (firstCard && secCard) {
         if (firstNum > secNum) {
            firstTarget.style.border = '2px solid green';
            secTarget.style.border = '2px solid red';
         } else {
            firstTarget.style.border = '2px solid red';
            secTarget.style.border = '2px solid green';
         }
   
         firstSpan.innerHTML = '';
         secSpan.innerHTML = '';
   
         historyDiv.textContent += `[${firstNum} vs ${secNum}] `;
         firstCard = false;
         secCard = false;
      }
      
   })
  }
   }

