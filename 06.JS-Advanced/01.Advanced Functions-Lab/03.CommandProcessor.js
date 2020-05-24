function solution() {
    let currentString = '';
    function append(str) {
        currentString += str;
    };

    function removeStart(length) {
        currentString = currentString.substr(length);
    };

    function removeEnd(length) {
        currentString = currentString.split('').reverse().join('');
        currentString = currentString.substr(length);
        currentString = currentString.split('').reverse().join('');
    };

    function print() {
        console.log(currentString);
    };

    return {
        append,
        removeStart,
        removeEnd,
        print
    };
};
    
const myMan = solution();
myMan.append('123');
myMan.print();