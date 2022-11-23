namespace Tetris
{
    public class Parser
    {
        public int Weight;
        public int Height;
        public char[,] Parse(string input)
        {
            var result = input.Split("\n");
            Weight = result[1].Length;
            Height = result.Length - 1;

            char[,] p = new char[Height, Weight];

            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Weight; j++)
                {
                    p[i, j] = result[i + 1][j];
                }
            }
            return p;
        }
    }
}
