class Rectangle {
    constructor(width, height, color) {
        this.width = +width;
        this.height = +height;
        this.color = color;
    }

    calcArea() {
        return Number(this.width * this.height);
    }
}