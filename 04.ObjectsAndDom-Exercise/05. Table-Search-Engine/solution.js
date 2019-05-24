function solve() {
   let userElements = Array.from(document.querySelectorAll('tbody tr'));
   let searchedItemElement = document.getElementById('searchField');
   let searchButtonElement = document.getElementById('searchBtn');

   searchButtonElement.addEventListener('click', () => {
      let searchedItem = searchedItemElement.value;

      for (let i = 0; i < userElements.length; i++) {
         const element = userElements[i];
            element.className = ''
      }

      for (let i = 0; i < userElements.length; i++) {
         const element = userElements[i];
         let userData = element.textContent;
         if (userData.includes(searchedItem)) {
            element.className = 'select'
         }
      }

      searchedItemElement.value = '';
   })
}