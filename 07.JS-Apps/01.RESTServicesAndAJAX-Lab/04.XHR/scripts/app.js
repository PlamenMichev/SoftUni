function loadRepos() {
   const xhr = new XMLHttpRequest();

   xhr.onreadystatechange = function() {
      if (this.readyState === 4 && this.status === 200) {
         const element = document.getElementById("res");
         element.textContent = this.response;
      }
   };

   xhr.open("GET", "https://api.github.com/users/testnakov/repos", true);
   xhr.send();
}