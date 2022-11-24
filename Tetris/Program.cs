namespace Tetris
{
    public class Program
    {
        static void Main(string[] args)
        {
            Handler.MainHandler(args, new MainOutPut(), new MainFileSystem());
        }
    }
}
