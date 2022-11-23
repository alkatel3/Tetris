using Tetris.Interfaces;

namespace Tetris.FileSystem
{
    public class MockFileSystem : IFileSystem
    {
        public bool FileIsExist;
        public bool FileIsCorrect;
        public bool IfFileExist(string filePath) => FileIsExist;

        public string ReadFileAsString(string filePath)
        {
            if (FileIsCorrect)
            {
                return "7 9\n" +
                    "..ppp....\n" +
                    "..p.p....\n" +
                    "..ppp....\n" +
                    ".........\n" +
                    "##...####\n" +
                    "##...####\n" +
                    "##.#.####";
            }
            return "Wrong input file body";
        }
    }
}
