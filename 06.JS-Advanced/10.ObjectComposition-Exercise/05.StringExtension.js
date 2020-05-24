(function modifyString () {
    String.prototype.ensureStart = function solve(str) {
        if (this.indexOf(str) !== 0) {
            return str + this;
        }

        return this.toString();
    };

    String.prototype.ensureEnd = function solve(str) {
        if (this.includes(str) === false) {
            return this + str;
        }

        return this.toString();
    };

    String.prototype.isEmpty = function solve() {
        if (this.toString() === '') {
            return true;
        }

        return false;
    };

    String.prototype.truncate = function solve(num) {
        if (num < 4) {
            return '.'.repeat(num);
        }
        if (num >= this.length) {
            return this.toString();
        } 
        
        let index = this.toString()
        .substr(0, num - 2)
        .lastIndexOf(' ')

        return index === -1 ? `${this.substr(0, num - 3)}...` : `${this.substr(0, index)}...`
    };

    String.format = function solve(string) {
        let args = [...arguments].slice(1);
        for (let i = 0; i < args.length; i++) {
            string = string.replace('{' + i + '}', args[i])
        }
        
        return string;
    };
})()

let str = 'the quick brown fox jumps over the lazy dog';
str = str.truncate(6);
console.log(str)