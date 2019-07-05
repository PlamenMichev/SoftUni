let result = (function(){
    let Suits = {
        SPADES: 'SPADES', 
        HEARTS: 'HEARTS',
        DIAMONDS: 'DIAMONDS',
        CLUBS: 'CLUBS'
    };

    let validFaces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        set face(value) {
            if (validFaces.includes(value) === false) {
                throw Error();
            }

            this._face = value;
        }

        get face() {
            return this._face;
        }

        set suit(value) {
            if (Object.keys(Suits).includes(value) === false) {
                throw Error();
            }

            this._suit = value;
        }

        get suit() {
            return this._suit;
        }
    }

    return {
        Suits:Suits,
        Card:Card
    }
}());

let Card = result.Card;
let Suits = result.Suits;

let card = new Card('Q', Suits.CLUBS);
console.log(card)