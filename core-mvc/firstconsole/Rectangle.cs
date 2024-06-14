namespace firstconsole
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            double area = Width * Height;
            Console.WriteLine($"Calculating area of Rectangle: {area}");
            return area;
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Rectangle drawn");
        }
    }
}