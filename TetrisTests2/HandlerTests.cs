using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tetris.Tests
{
    [TestClass()]
    public class HandlerTests
    {
        Mock<MainOutPut> main = null!;
        Mock<MainFileSystem> fs = null!;
        List<string> messages=null!;

        [TestInitialize]
        public void SetUp()
        {
            main = new();
            fs = new();
            messages = new List<string>();
        }

        [TestMethod()]
        public void ItShouldShowHowToUseInstractionIfThereIsNoInputFileParam()
        {
            main.Setup(m=>m.printLine(Messages.NoArgs)).Callback(() => messages.Add(Messages.NoArgs));

            Handler.MainHandler(Array.Empty<string>(), main.Object, fs.Object);

            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual(Messages.NoArgs,messages[0]);
        }

        [TestMethod()]
        public void ItShouldCheckIfInputFileExistsAndItNotThanShowAnMessage()
        {
            var input = new string[] { "input.txt" };
            main.Setup(m => m.printLine(Messages.InputFileDoesNotExist)).Callback(() => messages.Add(Messages.InputFileDoesNotExist));
            fs.Setup(m => m.IfFileExist(input[0])).Returns(false);

            Handler.MainHandler(input, main.Object, fs.Object);

            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual(Messages.InputFileDoesNotExist, messages[0]);
        }

        [TestMethod()]
        public void ItShouldParseInputFileAndThrowAnErrorIfIsWrong()
        {
            var input = new string[] { "input.txt" };
            main.Setup(m => m.printLine(Messages.InputFileContainsSmthWrong)).Callback(() => messages.Add(Messages.InputFileContainsSmthWrong));
            fs.Setup(m => m.IfFileExist(input[0])).Returns(true);
            fs.Setup(m => m.ReadFileAsString(input[0])).Returns("Wrong input file body");

            Handler.MainHandler(input, main.Object, fs.Object);

            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual(Messages.InputFileContainsSmthWrong, messages[0]);
        }
        [TestMethod()]
        public void ItShouldPrintFinalBoardState()
        {
            var inputBoard = "7 9\n" +
                             "..ppp....\n" +
                             "..p.p....\n" +
                             "..ppp....\n" +
                             ".........\n" +
                             "##...####\n" +
                             "##...####\n" +
                             "##.#.####";
            var expected = ".........\n" +
                           ".........\n" +
                           ".........\n" +
                           "..ppp....\n" +
                           "##p.p####\n" +
                           "##ppp####\n" +
                           "##.#.####\n";
            var input = new string[] { "input.txt" };
            main.Setup(m => m.printLine(expected)).Callback(() => messages.Add(expected));
            fs.Setup(m => m.IfFileExist(input[0])).Returns(true);
            fs.Setup(m => m.ReadFileAsString(input[0])).Returns(inputBoard);

            Handler.MainHandler(input, main.Object, fs.Object);

            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual(expected, messages[0]);
        }

        [TestMethod()]
        public void ItShouldPrintAllBoardState()
        {
            var inputBoard = "7 9\n" +
                             ".........\n" +
                             "..ppp....\n" +
                             "..p.p....\n" +
                             "..ppp....\n" +
                             "##...####\n" +
                             "##...####\n" +
                             "##.#.####";
            var expected0 = "Step 0\n" +
                            ".........\n" +
                            "..ppp....\n" +
                            "..p.p....\n" +
                            "..ppp....\n" +
                            "##...####\n" +
                            "##...####\n" +
                            "##.#.####\n";
            var expected1 = "Step 1\n" +
                            ".........\n" +
                            ".........\n" +
                            "..ppp....\n" +
                            "..p.p....\n" +
                            "##ppp####\n" +
                            "##...####\n" +
                            "##.#.####\n";
            var expected2 = "Step 2\n" +
                            ".........\n" +
                            ".........\n" +
                            ".........\n" +
                            "..ppp....\n" +
                            "##p.p####\n" +
                            "##ppp####\n" +
                            "##.#.####\n";
            var input = new string[] { "input.txt", "-printEachGeneration" };
            main.Setup(m => m.printLine(expected0+'\n')).Callback(() => messages.Add(expected0));
            main.Setup(m => m.printLine(expected1+'\n')).Callback(() => messages.Add(expected1));
            main.Setup(m => m.printLine(expected2+'\n')).Callback(() => messages.Add(expected2));
            fs.Setup(m => m.IfFileExist(input[0])).Returns(true);
            fs.Setup(m => m.ReadFileAsString(input[0])).Returns(inputBoard);

            Handler.MainHandler(input, main.Object, fs.Object);

            Assert.AreEqual(3, messages.Count);
            Assert.AreEqual(expected0, messages[0]);
            Assert.AreEqual(expected1, messages[1]);
            Assert.AreEqual(expected2, messages[2]);
        }
    }
}