namespace P01.ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double SurfaceArea(double length, double width, double height)
        {
            double area = 2 * length * width + 2 * width * height + 2 * length* height;
            return area;
        }

        public double LiteralSurfaceArea(double length, double width, double height)
        {
            double area = 2 * length * height + 2 * width * height;
            return area;
        }

        public double Volume(double length, double width, double height)
        {
            double volume = length * width * height;
            return volume;
        }
    }
}
