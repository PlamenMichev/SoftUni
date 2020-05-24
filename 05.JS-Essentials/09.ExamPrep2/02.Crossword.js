function solve(matrix) {
    let result = '';
    for (let commandArgs of matrix) {
        let command = commandArgs[0];
        if (command == 'filter') {
            let filteredWord = '';
            let secondaryCommand = commandArgs[1];
            let word = commandArgs[3];
            let position = +commandArgs[2];
            if (secondaryCommand === 'UPPERCASE') {
                for (let i = 0; i < word.length; i++) {
                    const element = word[i];
                    if (element === element.toUpperCase()) {
                        filteredWord += element;
                    }
                }
            } else if (secondaryCommand === 'LOWERCASE') {
                for (let i = 0; i < word.length; i++) {
                    const element = word[i];
                    if (element === element.toLowerCase()) {
                        filteredWord += element;
                    }
                }
            } else if (secondaryCommand === 'NUMS') {
                for (let i = 0; i < word.length; i++) {
                    const element = word[i];
                    if (!isNaN(element)) {
                        filteredWord += element;
                    }
                }
            }

            result += filteredWord[position - 1];
        } else if (command === 'sort') {
            let order = commandArgs[1];
            let position = +commandArgs[2];
            let word = commandArgs[3];

            let arrayChars = word.split('');
            if (order === 'A') {
                arrayChars = arrayChars.sort((a, b) => 
                    a.localeCompare(b)
                )
            } else {
                arrayChars = arrayChars.sort((a, b) => 
                     b.localeCompare(a)
                )
            }

            result += arrayChars[position - 1];
        } else if (command === 'rotate') {
            let rotations = +commandArgs[1];
            let position = +commandArgs[2];
            let word = commandArgs[3];

            let arrayChars = word.split('');

            for (let i = 0; i < rotations; i++) {
                let temp = arrayChars.pop();
                arrayChars.unshift(temp);  
            }

            result += arrayChars[position - 1];
        } else if (command === 'get') {
            let position = +commandArgs[1];
            let word = commandArgs[2];

            result += word[position - 1];
        }
    }
    console.log(result);
}

solve([["filter", "UPPERCASE", 4, "AkIoRpSwOzFdT"],
["sort", "A", 3, "AOB"],
["sort", "A", 3, "FAILCL"],
[],
[],
["rotate", 2, 2, "DAN"],
["get", 2, "PING"],
["get", 3, "?- 654"]]

);