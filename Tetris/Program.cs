using Tetris.FileSystem;
using Tetris.Interfaces;
using Tetris.OutPut;

namespace Tetris
{
    public class Program
    {
        static void Main(string[] args)
        {
            Handler.MainHandler(args, new MainOutPut(), new MainFileSystem());
            Console.WriteLine();
            Console.WriteLine(args[0]);
        }
    }
}
