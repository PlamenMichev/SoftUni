function create(words) {
   let divToAppend = document.getElementById('content');

   for (let word of words) {
      let currentDiv = document.createElement('div');
      let curreptP = document.createElement('p');
      curreptP.innerHTML = word;
      curreptP.style.display = 'none';
      currentDiv.appendChild(curreptP);
      divToAppend.appendChild(currentDiv);
   }

   for (let div of Array.from(divToAppend.children)) {
      div.addEventListener('click', function() {
         div.firstElementChild.style.display = 'block';
      });
   }
}