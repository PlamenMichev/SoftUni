function solve() {
    let word = document.getElementById('text').value;
    let parts = Number(document.getElementById('number').value);
    let result = document.getElementById('result');
    let resultString = '';
    if (word.length % parts != 0) {
        word += word.substr(0, parts - word.length % parts);
        console.log(word);
    }

    for (let i = 0; i < word.length; i+=parts) {
        const element = word[i];
        resultString += word.substr(i, parts) + ' ';
    }

    result.textContent = resultString.trim();
}