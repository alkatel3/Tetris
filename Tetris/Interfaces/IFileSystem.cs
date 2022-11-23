namespace Tetris.Interfaces
{
    public interface IFileSystem
    {
        bool IfFileExist(string filePath);
        string ReadFileAsString(string filePath);
    }
}
