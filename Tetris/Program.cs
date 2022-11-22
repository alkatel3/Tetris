namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bl = new BL(new Parser());

            bl.ReadFigure();
            bl.Move();
            bl.Show();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}