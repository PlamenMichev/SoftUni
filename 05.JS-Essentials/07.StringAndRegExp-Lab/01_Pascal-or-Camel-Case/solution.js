function solve() {
  let text = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;
  let resultBox = document.getElementById('result');

  if (convention == 'Pascal Case' || convention == 'Camel Case') {
    let result = '';
    text.split(' ').forEach((w) => {
      result += w[0].toUpperCase() + w.substring(1, w.length).toLowerCase();
    });

    if (convention == 'Camel Case') {
      result = result[0].toLowerCase() + result.substring(1, result.length);
    }

    resultBox.textContent += result;
  } else {
    resultBox.textContent += 'Error!';
  }
}