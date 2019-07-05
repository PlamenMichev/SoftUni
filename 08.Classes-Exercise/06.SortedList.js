class List {
    constructor() {
        this.size = 0;
        this.list = [];
    }

    add(element) {
        this.list.push(element);
        this.size++;
        this.list = this.list.sort((a, b) => {
            return a - b;
        });
    }

    remove(index) {
        if (index >= 0 && index < this.list.length) {
            this.list.splice(index, 1);
            this.size--;
            this.list = this.list.sort((a, b) => {
                return a - b;
            });
        }
    }

    get(index) {
        if (index >= 0 && index < this.list.length) {
            return this.list[index];
        }
    }
}

let list = new List();
list.add(5);
console.log(list.get(0));