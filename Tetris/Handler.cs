using Tetris.Interfaces;

namespace Tetris
{
    public static class Handler
    {
        public static void MainHandler(string[] args, IOutPut output, IFileSystem fs)
        {
            if (args.Length==0)
            {
                output.printLine(Messages.NoArgs);
                return;
            }

            var inputFilePath = args[0];
            if (!fs.IfFileExist(inputFilePath))
            {
                output.printLine(Messages.InputFileDoesNotExist);
                return;
            }
            var printEachGeneration = args.Length > 1 && args[1] == "-printEachGeneration";
            var Parser = new Parser();
            char[,]? board;
            try
            {
                board = Parser.Parse(fs.ReadFileAsString(inputFilePath));
            }
            catch
            {
                board = null;
            }

            if (board == null)
            {
                output.printLine(Messages.InputFileContainsSmthWrong);
                return;
            }
            else
            {
                var Board = new Logic(board, Parser.Height, Parser.Weight);
                if (printEachGeneration)
                {
                    var game=Board.MoveAndReturnAllStep();
                    foreach(var generation in game)
                    {
                        output.printLine(generation +'\n');
                    }
                }
                else
                {
                    Board.Move();
                    output.printLine(Board.PrintGameBoard());
                }
            }
        }
    }
}
