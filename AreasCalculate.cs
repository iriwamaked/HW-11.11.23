namespace MyFirstDll
{
    public class AreasCalculate
    {
        public static Double SquareArea(Double x) { return x * x; }
        public static Double RectangleArea(Double x, Double y) { return x * x; }
        public static Double TriangleArea(Double lenght, Double height)
        { return 0.5*lenght * height; }
    }
}