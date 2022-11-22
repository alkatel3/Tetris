using System.Drawing;

namespace Tetris
{
    public class BL
    {
        Parser parser;
        public List<Point> figure=new();
        public List<Point> Lanshft=new();
        public BL(Parser p)
        {
            parser = p;
        }
        public void ReadFigure()
        {
            var pole=parser.Parse("7 9\n" +
                                  "..ppp....\n" +
                                  "..p.p....\n" +
                                  "..ppp....\n" +
                                  ".........\n" +
                                  "##...####\n" +
                                  "##...####\n" +
                                  "##.#.####");
            for (int i=0; i < parser.Height; i++)
            {
                for(int j =0; j < parser.Weight; j++)
                {
                    if (pole[i,j] == 'p')
                    {
                        figure.Add(new Point(j, i));
                    }
                    else if (pole[i, j] == '#')
                    {
                        Lanshft.Add(new Point(j, i));
                    }
                }
            }
        }
        public List<Point> Step()
        {
            var result = new List<Point>();
            foreach(var point in figure)
            {
                result.Add(new Point(point.X, point.Y + 1));
            }
            foreach(var point1 in Lanshft)
            {
                foreach(var point2 in result)
                {
                    if (point1.X.Equals(point2.X)&&point1.Y.Equals(point2.Y))
                    {
                        return figure;
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
                if (figure[0].Equals(step[0]))
                {
                    break;
                }
                figure = step;
            }
        }
        public void Show()
        {
            for(int i = 0; i < parser.Height; i++)
            {
                for(int j = 0; j < parser.Weight; j++)
                {
                    Console.Write('.');
                }
                Console.WriteLine();
            }
            foreach(var p in Lanshft)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write("#");
            }
            foreach (var p in figure)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write("p");
            }
        }
    }
}
