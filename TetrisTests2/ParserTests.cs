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
    public class ParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            var Parser = new Parser();
            char[,] Expected = { { '.', '.', 'p', 'p', 'p', '.', '.', '.', '.' },
                                 { '.', '.', 'p', '.', 'p', '.', '.', '.', '.' },
                                 { '.', '.', 'p', 'p', 'p', '.', '.', '.', '.' },
                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                 { '#', '#', '.', '.', '.', '#', '#', '#', '#' },
                                 { '#', '#', '.', '.', '.', '#', '#', '#', '#' },
                                 { '#', '#', '.', '#', '.', '#', '#', '#', '#' } 
            };

            var Actual = Parser.Parse("7 9\n" +
                                      "..ppp....\n" +
                                      "..p.p....\n" +
                                      "..ppp....\n" +
                                      ".........\n" +
                                      "##...####\n" +
                                      "##...####\n" +
                                      "##.#.####");

            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(Expected[i,j], Actual[i,j]);
                }
            }
        }
    }
}