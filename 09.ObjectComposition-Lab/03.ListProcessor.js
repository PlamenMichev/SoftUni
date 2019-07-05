function solve(params) {
    function listProcessor() {
        let arr = [];
        return {
            add(element) { arr.push(element); },
            remove(element) { arr = arr.filter((a) => { return a!== element }); },
            print() { console.log(arr.join(',')); }
        }
    }

    let currentProcessor = listProcessor();
    for (let commandArgs of params) {
        let command = commandArgs.split(' ')[0];
        if (command === 'print') {
            currentProcessor[command]();
        } else {
            currentProcessor[command](commandArgs.split(' ')[1])
        }
    }
}

solve(['add pesho', 'add george', 'add peter', 'remove peter','print'])