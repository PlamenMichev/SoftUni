function makeSum(num) {
    let sum = num;

    function add(number) {
        sum += number;
        return add;
    }    

    add.toString = function() {
        return sum;
    };

    return add;
};
console.log(makeSum(1)(12));