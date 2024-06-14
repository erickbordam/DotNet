namespace firstconsole
{
    public class MultiFunctionDevice : IPrintable, IScannable
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public void Scan() { Console.WriteLine("Scanning..."); }
    }
}