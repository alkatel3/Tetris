using Tetris.Interfaces;

namespace Tetris
{
    public class MainFileSystem : IFileSystem
    {
        public virtual bool IfFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public virtual string ReadFileAsString(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
