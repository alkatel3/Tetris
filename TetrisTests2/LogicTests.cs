using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tests
{
    [TestClass()]
    public class LogicTests
    {
        int height = 7;
        int weight = 9;
        char[,] InputArray = { { '.', '.', 'p', 'p', 'p', '.', '.', '.', '.' },
                               { '.', '.', 'p', '.', 'p', '.', '.', '.', '.' },
                               { '.', '.', 'p', 'p', 'p', '.', '.', '.', '.' },
                               { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                               { '#', '#', '.', '.', '.', '#', '#', '#', '#' },
                               { '#', '#', '.', '.', '.', '#', '#', '#', '#' },
                               { '#', '#', '.', '#', '.', '#', '#', '#', '#' }
        };

        [TestMethod()]
        public void LogicTest_CreatedStartBoard_WithSizeOfInputArrayAndWithListsOfFigurePointsAndLanshftPoints()
        {
            var Board = new Logic(InputArray, height, weight);

            Assert.AreEqual(height, Board.Height);
            Assert.AreEqual(weight, Board.Weight);
            Assert.AreEqual(8, Board.Figure.Count);
            Assert.AreEqual(19, Board.Landscape.Count);
        }

        [TestMethod()]
        public void Step_CreatBoardAndCallMethodStep_AllPointsOfFigureStepDownIfThereIsNotLandscape()
        {
            var Board = new Logic(InputArray, height, weight);

            var actual=Board.Step();

            Assert.IsTrue(actual.Any(p => p.X == 2 && p.Y == 3));
            Assert.IsTrue(actual.Any(p => p.X == 3 && p.Y == 3));
            Assert.IsTrue(actual.Any(p => p.X == 4 && p.Y == 3));
            Assert.IsFalse(actual.Any(p => p.X == 2 && p.Y == 0));
            Assert.IsFalse(actual.Any(p => p.X == 3 && p.Y == 0));
        }

        [TestMethod()]
        public void Move_CreatBoardAndCallMethodMove_AllPointsOfFigureMoveDownWhileNoPointStepsOnTheLandscape()
        {
            var Board = new Logic(InputArray, height, weight);

            Board.Move();

            Assert.IsTrue(Board.Figure.Any(p => p.X == 2 && p.Y == 5));
            Assert.IsTrue(Board.Figure.Any(p => p.X == 3 && p.Y == 5));
            Assert.IsTrue(Board.Figure.Any(p => p.X == 4 && p.Y == 5));
            Assert.IsFalse(Board.Figure.Any(p => p.X == 2 && p.Y == 6));
            Assert.IsFalse(Board.Figure.Any(p => p.X == 3 && p.Y == 6));
        }

        [TestMethod()]
        public void PrintGameBoardTest()
        {
            var Board = new Logic(InputArray, height, weight);
            var expected="..ppp....\n" +
                         "..p.p....\n" +
                         "..ppp....\n" +
                         ".........\n" +
                         "##...####\n" +
                         "##...####\n" +
                         "##.#.####\n";
            var actual = Board.PrintGameBoard();

            Assert.AreEqual(expected, actual);
        }
    }
}