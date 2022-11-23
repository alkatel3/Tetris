using Tetris.Interfaces;

namespace Tetris.FileSystem
{
    public class MainFileSystem : IFileSystem
    {
        public bool IfFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public string ReadFileAsString(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
