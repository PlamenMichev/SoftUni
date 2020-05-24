(function vectorMath() {
    let functions = {};

    function add(vec1, vec2) {
        let result = [];
        let firstSum = vec1[0] + vec2[0];
        let secSum = vec1[1] + vec2[1];
        result[0] = firstSum;
        result[1] = secSum;

        return result;
    }

    function multiply(vec1, scalar) {
        let result = [];
        let firstSum = vec1[0] * scalar;
        let secSum = vec1[1] * scalar;
        result[0] = firstSum;
        result[1] = secSum;

        return result;
    }

    function length(vec1) {
        let result = Math.sqrt((vec1[0] * vec1[0]) + (vec1[1] * vec1[1]))

        return result;
    }

    function dot(vec1, vec2) {
        let result = (vec1[0] * vec2[0]) + (vec1[1] * vec2[1]);

        return result;
    }

    function cross(vec1, vec2) {
        let result = (vec1[0] * vec2[1]) - (vec1[1] * vec2[0]);

        return result;
    }

    functions.add = add;
    functions.cross = cross;
    functions.dot = dot;
    functions.length = length;
    functions.multiply = multiply;
    return functions;
})();

let add = solution.cross([3, 7], [1, 0]);
console.log(add);
