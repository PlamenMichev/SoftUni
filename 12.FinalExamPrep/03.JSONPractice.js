function name(params) {
    console.log(params)
    console.log(JSON.stringify(params))
}

name([{"firstName":"Jon","lastName":"Snow","action":"peopleIn"},{"firstName":"Jonny","lastName":"Bravo","action":"peopleIn"},{"firstName":"John","lastName":"Doe","action":"peopleOut"},{"firstName":"Jon","lastName":"Snow","action":"peopleOut"},{"firstName":"John","lastName":"Doe","action":"peopleOut"},{"firstName":"Lenny","lastName":"Kravitz","action":"blacklist"},{"firstName":"Lenny","lastName":"Kravitz","action":"peopleIn"},{"firstName":"Marwin","lastName":"Athelstein","action":"peopleIn"},{"criteria":"lastName","action":"peopleIn"}])