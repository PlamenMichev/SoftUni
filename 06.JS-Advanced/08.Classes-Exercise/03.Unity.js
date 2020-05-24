class Rat {
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }

    unite(otherRat) {
        if (otherRat.constructor.name === 'Rat') {
            this.unitedRats.push(otherRat);
        }
    }

    toString() {
        let result = '';
        result += this.name + '\n';
        for (let rat of this.unitedRats) {
            result += '##' + rat.name + '\n';
        }

        return result.trim();
    }

    getRats() {
        return this.unitedRats;
    }
}

let firstRat = new Rat("Peter");
console.log(firstRat.toString()); // Peter
 
console.log(firstRat.getRats()); // []

firstRat.unite(new Rat("George"));
firstRat.unite(new Rat("Alex"));
console.log(firstRat.getRats());
// [ Rat { name: 'George', unitedRats: [] },
//  Rat { name: 'Alex', unitedRats: [] } ]

// console.log(test.toString());
// // Peter
// // ##George
// // ##Alex
