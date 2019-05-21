function toUpper(input) {
    let regex = /[A-Za-z1-9]+/g;
    let matches = input.match(regex);
    let result = matches.map(x => x.toUpperCase()).join(', ');

    console.log(result);
}