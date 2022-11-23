using Tetris.Interfaces;

namespace Tetris.OutPut
{
    public class MockOutPut:IOutPut
    {
        public List<string> messages = new List<string>();
        public void printLine(string msg)
        {
            messages.Add(msg);
        }
    }
}
