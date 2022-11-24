using Tetris.Interfaces;

namespace Tetris
{
    public class MainOutPut : IOutPut
    {
        public virtual void printLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
