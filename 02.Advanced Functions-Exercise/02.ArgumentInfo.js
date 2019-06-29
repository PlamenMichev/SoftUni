function solve() {
    let args = {};
    for (let arg of arguments) {
        let type = typeof arg;
        console.log(type + ': ' + arg);
        if (!args[type]) {
            args[type] = 0;
        }

        args[type]++;
    }

    let objInArr = Object.keys(args).sort((a, b) => args[b] - args[a]);

    for (let arg of objInArr) {
        console.log(arg + ' = ' + args[arg]);
    }
}

solve({ name: 'bob'}, 3.333, 9.999)