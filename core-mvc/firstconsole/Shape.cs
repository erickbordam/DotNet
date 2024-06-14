namespace firstconsole
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public virtual void Draw() { Console.WriteLine("Shape drawn"); }
    }
}