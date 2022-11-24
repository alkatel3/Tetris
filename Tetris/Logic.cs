using System.Drawing;

namespace Tetris
{
    public class Logic
    {
        char[,] board;
        public int Height { get; }
        public int Weight { get; }
        public List<Point> Figure { get; private set; }
        public List<Point> Landscape { get; private set; }
        public Logic(char[,]board, int height, int weight)
        {
            this.board = board;
            Height = height;
            Weight = weight;
            Figure = new();
            Landscape = new();
            ReadFigure();
        }
        private void ReadFigure()
        {
            for (int i=0; i < Height; i++)
            {
                for(int j =0; j < Weight; j++)
                {
                    if (board[i,j] == 'p')
                    {
                        Figure.Add(new Point(j, i));
                    }
                    else if (board[i, j] == '#')
                    {
                        Landscape.Add(new Point(j, i));
                    }
                }
            }
        }
        public List<Point> Step()
        {
            var result = new List<Point>();
            foreach(var point in Figure)
            {
                result.Add(new Point(point.X, point.Y + 1));
            }
            foreach(var point1 in Landscape)
            {
                foreach(var point2 in result)
                {
                    if (point1.X.Equals(point2.X)&&point1.Y.Equals(point2.Y))
                    {
                        return Figure;
                    }
                }
            }
            return result;
        }
        public void Move()
        {
            while (true)
            {
                var step = Step();
                if (Figure[0].Equals(step[0]))
                {
                    break;
                }
                Figure = step;
            }
        }

        public List<string> MoveAndReturnAllStep()
        {
            var result = new List<string>();
            int step = 0;
            while (true)
            {
                var StateOfFigure = Step();
                var StateOfBoard = $"Step {step}\n" + PrintGameBoard();
                result.Add(StateOfBoard);
                if (Figure[0].Equals(StateOfFigure[0]))
                {
                    break;
                }
                Figure = StateOfFigure;
                step++;
            }
            return result;
        }

        public string PrintGameBoard()
        {
            var result = "";

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Weight; j++)
                {
                    if (Landscape.Any(p => p.Y == i && p.X == j))
                    {
                        result += '#';
                    }
                    else if(Figure.Any(p => p.Y == i && p.X == j))
                    {
                        result += 'p';
                    }
                    else
                    {
                        result += '.';
                    }
                }
                result += '\n';
            }
            return result;
        }
    }
}
