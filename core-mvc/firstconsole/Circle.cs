namespace firstconsole
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            double area = Math.PI * Radius * Radius;
            Console.WriteLine($"Calculating area of Circle: {area}");
            return area;
        }
    }
}