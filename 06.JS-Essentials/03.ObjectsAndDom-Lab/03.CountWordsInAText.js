function countWords(params) {
    let regex = /\w+/g;
    let result = {};
    let args = params + '';
    let words = args.match(regex);

    for (let i = 0; i < words.length; i++) {
        const word = words[i];
        if (!result[word]) {
            result[word] = 0;
        }

        result[word]++;
    }

    console.log(JSON.stringify(result));
}

countWords(["JS devs use Node.js for server-side JS.-- JS for devs"])