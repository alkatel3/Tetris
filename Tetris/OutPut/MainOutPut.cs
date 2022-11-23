using Tetris.Interfaces;

namespace Tetris.OutPut
{
    public class MainOutPut:IOutPut
    {
        public void printLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
