function solve() {
  let textareaInputElement = document.getElementsByTagName('textarea')[0];
  let textareaOutputElement = document.getElementsByTagName('textarea')[1];
  let generateButtonElement = document.getElementsByTagName('button')[0];
  let buyButtonElement = document.getElementsByTagName('button')[1];
  let tableElement = document.getElementsByTagName('tbody')[0];
  let products = {};

  generateButtonElement.addEventListener('click', () => {
    let newFurnitureJson = textareaInputElement.value;
    let newFurnitureObj = Array.from(JSON.parse(newFurnitureJson));
    console.log(newFurnitureObj);
    for (let currentFunriture of newFurnitureObj) {
      products[currentFunriture.name] = currentFunriture;
    let trElement = document.createElement('tr');
    for (let i = 0; i < 5; i++) {
    let tdElement = document.createElement('td');
      switch(i) {
        case 0: {
          let element = document.createElement('img');
          let src = "";
          src += currentFunriture.img;
          element.src = src;
          tdElement.appendChild(element);
          break;
        }
        case 1: {
          let element = document.createElement('p');
          element.textContent = currentFunriture.name;
          tdElement.appendChild(element);
          break;
        }
        case 2: {
          let element = document.createElement('p');
          element.textContent = currentFunriture.price;
          tdElement.appendChild(element);
          break;
        }  
        case 3: {
          let element = document.createElement('p');
          element.textContent = currentFunriture.decFactor;
          tdElement.appendChild(element);
          break;
        }  
        case 4: {
          let element = document.createElement('input');
          products[currentFunriture.name].checkbox = element; 
          element.type = 'checkbox';
          tdElement.appendChild(element);
          break;
        }        
      }
      
      trElement.appendChild(tdElement);
    }
    tableElement.appendChild(trElement);
    }
    
  })

  buyButtonElement.addEventListener('click', () => {
    let boughtProducts = {};
    let keys = Object.keys(products);
    for (let i = 0; i < keys.length; i++) {
      const element = products[keys[i]];
      if (element.checkbox.checked) {
        boughtProducts[element.name] = element;
      }
    }

    let list = '';
    let boughtKeys = Object.keys(boughtProducts);
    let totalPrice = 0;
    let decFactors = 0;
    for (let i = 0; i < boughtKeys.length; i++) {
      const element = boughtProducts[boughtKeys[i]];
      if (i == boughtKeys.length - 1) {
        list += element.name;
      } else {
        list += element.name + ', ';
      }

      totalPrice += Number(element.price);
      decFactors += Number(element.decFactor);
    }

    textareaOutputElement.textContent += `Bought furniture: ${list}\n`;
    textareaOutputElement.textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
    textareaOutputElement.textContent += `Average decoration factor: ${decFactors / boughtKeys.length}`;

  })
}