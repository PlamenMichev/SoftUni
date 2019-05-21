function solve() {
  let siteElements = Array.from(document.getElementsByClassName('link-1'));
  for (let siteElement of siteElements) {
    siteElement.addEventListener('click', (e) => {
      let currentTarget = e.currentTarget;
      let textElement = currentTarget.getElementsByTagName('p')[0];
      let text = (textElement.textContent).split(' ');
      text[1] = Number(text[1]) + 1;
      textElement.textContent = text.join(' ');
    });
  }
  
}