class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(firstPoint, secPoint) {
        return Math.sqrt(((secPoint.x - firstPoint.x) * (secPoint.x - firstPoint.x)) + ((secPoint.y - firstPoint.y) * (secPoint.y - firstPoint.y)));
    }
}