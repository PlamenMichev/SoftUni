function orderRectangles(rectanglesArgs) {
    class Rectangle {
        constructor(width, height) {
            this.width = width;
            this.height = height;
        }

        area() {
            return this.width * this.height;
        }

        compareTo(otherRectangle) {
            return otherRectangle.area() - this.area() || (otherRectangle.width - this.width);
        }
    }

    let rectangles = [];
    for (arg of rectanglesArgs) {
        let currentRectangle = new Rectangle(+arg[0], +arg[1]);
        rectangles.push(currentRectangle);
    }

    rectangles = rectangles.sort((a, b) => {
        return a.compareTo(b);
    });

    return rectangles;
}

orderRectangles([[1,20],[20,1],[5,3],[5,3]])