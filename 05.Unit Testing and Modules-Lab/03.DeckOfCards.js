function solve(cards) {
    function createCard (cardFace, cardSuit) {
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
    
    let result = [];

    for (let card of cards) {
        let face;
        let suit;
        if (card.length === 3) {
             face = card[0] + card[1];
             suit = card[2];
            
        } else {
             face = card[0];
             suit = card[1];
        }

        try {
            let currentCard = createCard(face, suit);
            result.push(currentCard);
        } catch (error) {
            console.log(`Invalid card: ${face + suit}`); 
        }
    }

    console.log(result.join(' '));
}

console.log(solve(['AS', '10D', 'KH', '2C']))