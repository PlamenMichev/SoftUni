function solve() {
   let productElemets = Array.from(document.getElementsByClassName('product'));
   let buttonsElements = Array.from(document.getElementsByTagName('button'));
   let outputBoxElement = document.getElementsByTagName('textarea')[0];
   console.log(buttonsElements);
   let totalMoney = 0;
   let products = {};
   let count = 0;
   for (let i = 0; i < buttonsElements.length; i++) {
      const element = buttonsElements[i];
      element.addEventListener('click', () => {
         switch(i) {
            case 0: {
               if (!products['Bread']) {
                  
                  products['Bread'] = 1;
                  count++;
               }
               
               outputBoxElement.textContent += "Added Bread for 0.80 to the cart.\n";
               totalMoney += 0.80;
               break;
            }
            case 1: {
               if (!products['Milk']) {
                 
                  products['Milk'] = 1;
                  count++;

               }
               outputBoxElement.textContent += "Added Milk for 1.09 to the cart.\n";
               totalMoney += 1.09;
               break;
            }
            case 2: {
               if (!products['Tomatoes']) {
                  
                  products['Tomatoes'] = 1;
                  count++;
               }
               outputBoxElement.textContent += "Added Tomatoes for 0.99 to the cart.\n";
                  totalMoney += 0.99;
               break;
            }
            case 3: {
               let list = '';
               let keys = Object.keys(products);
               for (let i = 0; i < keys.length; i++) {
                  const element = keys[i];
                  if (i == keys.length - 1) {
                     list += element;
                     
                  } else {
                     list += element + ', ';
                  }
               }
               
               outputBoxElement.textContent += `You bought ${list} for ${totalMoney.toFixed(2)}.`;

               for (let i = 0; i < buttonsElements.length; i++) {
                  const element = buttonsElements[i];
                  element.disabled = true;
               }
            }
         }
      })
   }
}