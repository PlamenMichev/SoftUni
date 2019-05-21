function calculateLength(firstWord, secWord, thirdWord) {
    let result = firstWord.length + secWord.length + thirdWord.length;

    console.log(Math.floor(result));
    console.log(Math.floor(result / 3));
}

calculateLength('chocolate', 'ice cream', 'cake'); 