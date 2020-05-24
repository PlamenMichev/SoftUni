function solve() {
   let buttonElement = document.getElementsByTagName('button')[0];
   let inputElements = Array.from(document.getElementsByTagName('input'));
   let outputBox = document.querySelector('#myCourses .courseBody ul');
   let courses = [];
   let totalPrice = 0;
   let priceBox = document.querySelector('#myCourses .courseFoot p');
   buttonElement.addEventListener('click', () => {

      let checkboxes = [];
      let formsOfEducation = [];
      for (let i = 4; i < 6; i++) {
         formsOfEducation.push(inputElements[i]);
      }
      for (let i = 0; i < 4; i++) {
         checkboxes.push(inputElements[i]);
      }

      for (let i = 0; i < 4; i++) {
         if (checkboxes[i].checked) {
            let paragraph = document.createElement('li');
            switch(i) {
               case 0: {
                  paragraph.textContent = 'JS-Fundamentals';
                  courses.push('JS-Fundamentals');
                  totalPrice += 170;
                  break;
               }
               case 1: {
                  paragraph.textContent = 'JS-Advanced';
                  courses.push('JS-Advanced');
                  totalPrice += 180;
                  break;
               }
               case 2: {
                  paragraph.textContent = 'JS-Applications';
                  courses.push('JS-Applications');
                  totalPrice += 190;
                  break;
               }
               case 3: {
                  paragraph.textContent = 'JS-Web';
                  courses.push('JS-Web');
                  totalPrice += 490;
                  break;
               }
            }

            outputBox.appendChild(paragraph);
         }

      }

      let formOfEducation = '';
      for (let i = 0; i < 2; i++) {
         if (formsOfEducation[i].checked === true) { 
            if (i == 0) {
               formOfEducation = 'onside';
            }
             if (i == 1){
               formOfEducation = 'online';
            }
         }
      }
      

      if (courses.includes('JS-Advanced') && courses.includes('JS-Fundamentals')) {
         let discount = 0.1 * 180;
         totalPrice -= discount;
      }

      if (courses.includes('JS-Advanced') && courses.includes('JS-Fundamentals') && courses.includes('JS-Applications')) {
         let discount = 0.06 * 540;
         totalPrice -= discount;
      }

      if (courses.includes('JS-Advanced') 
      && courses.includes('JS-Fundamentals') 
      && courses.includes('JS-Applications') 
      && courses.includes('JS-Web')) {
         let bonusCourseElement = document.createElement('li');
         bonusCourseElement.textContent = 'HTML and CSS';
         outputBox.appendChild(bonusCourseElement);
      }

      if (formOfEducation == 'online') {
         totalPrice -= 0.06 * totalPrice;
      }

      priceBox.textContent = `Cost: ${Math.floor(totalPrice)}.00 BGN`;
   });
}

solve();