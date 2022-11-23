using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.OutPut;
using Tetris.FileSystem;

namespace Tetris.Tests
{
    [TestClass()]
    public class HandlerTests
    {
        MockOutPut main = null!;
        MockFileSystem fs = null!;

        [TestInitialize]
        public void SetUp()
        {
            main = new MockOutPut();
            fs = new MockFileSystem();
        }

        [TestMethod()]
        public void ItShouldShowHowToUseInstractionIfThereIsNoInputFileParam()
        {
            Handler.MainHandler(Array.Empty<string>(), main, fs);

            Assert.AreEqual(1, main.messages.Count);
            Assert.AreEqual(Messages.NoArgs, main.messages[0]);
        }

        [TestMethod()]
        public void ItShouldCheckIfInputFileExistsAndItNotThanShowAnMessage()
        {
            var input = new string[] { "input.txt" };

            Handler.MainHandler(input, main, fs);

            Assert.AreEqual(1, main.messages.Count);
            Assert.AreEqual(Messages.InputFileDoesNotExist, main.messages[0]);
        }

        [TestMethod()]
        public void ItShouldParseInputFileAndThrowAnErrorIfIsWrong()
        {
            var input = new string[] { "input.txt" };
            fs.FileIsExist = true;
            Handler.MainHandler(input, main, fs);

            Assert.AreEqual(1, main.messages.Count);
            Assert.AreEqual(Messages.InputFileContainsSmthWrong, main.messages[0]);
        }
        [TestMethod()]
        public void ItShouldPrintFinalBoardState()
        {
            var input = new string[] { "input.txt" };
            fs.FileIsExist = true;
            fs.FileIsCorrect = true;
            Handler.MainHandler(input, main, fs);
            var expected =".........\n" +
                          ".........\n" +
                          ".........\n" +
                          "..ppp....\n" +
                          "##p.p####\n" +
                          "##ppp####\n" +
                          "##.#.####\n";

            Assert.AreEqual(1, main.messages.Count);
            Assert.AreEqual(expected, main.messages[0]);
        }
    }
}