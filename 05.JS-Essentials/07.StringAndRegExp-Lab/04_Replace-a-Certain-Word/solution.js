function solve() {
    let wordForReplace = document.getElementById('word').value;
    let text = document.getElementById('text').value;
    let strings = JSON.parse(text);
    let answerBox = document.getElementById('result');
    let wordToReplace = strings[0].split(' ')[2];
    let regex = new RegExp(wordToReplace, 'gi');

    strings = strings.map(string => {
        return string.replace(regex, wordForReplace);
    });
    console.log(strings);
    
}