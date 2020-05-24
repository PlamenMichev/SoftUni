function solve(cardFace, cardSuit) {
    let faces = ['A', '2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K'];
    let suits = ['S', 'H', 'D', 'C'];

    if (faces.includes(cardFace) === false) {
        throw Error('Error');
    }

    if (suits.includes(cardSuit) === false) {
        throw Error('Error');
    }

    let suit = '';
    switch (cardSuit) {
        case 'S':
            suit = '\u2660';
            break;
        case 'H':
            suit = '\u2665';
            break;
        case 'D':
            suit = '\u2666';
            break;
        case 'C':
            suit = '\u2663';
            break;
    }

    return cardFace + suit;
}

console.log(solve('A', 'S'));