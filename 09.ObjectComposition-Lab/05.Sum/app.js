function solve() {
    let sumButton = document.querySelector('#sumButton');
    let subtractButton = document.querySelector('#subtractButton');
    let result = {
        init(selector1, selector2, resultSelector) {
            this.firstField = document.querySelector(selector1);
            this.secField = document.querySelector(selector2);
            this.resultField = document.querySelector(resultSelector);
        },

        add() {
            let result = +this.firstField.value + +this.secField.value;
            this.resultField.value = result;
        },

        subtract() {
            let result = +this.firstField.value - +this.secField.value;
            this.resultField.value = result;
        }
    }

    return result;
}
console.log(sumButton, subtractButton);