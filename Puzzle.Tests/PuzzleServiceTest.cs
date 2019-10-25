using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.Service;
using System.Collections.Generic;

namespace Puzzle.Tests
{
    [TestClass]
    public class PuzzleServiceTest
    {
        private Calculator _calculator = new Calculator();
        [TestMethod]
        public void TestPuzzleServiceFromTestCases()
        {
            List<string> testInput = new List<string>();
            List<int> result = new List<int>() {1,6,5,16,1,9,9,3};
            testInput.Add("{}");
            testInput.Add("{{{}}}");
            testInput.Add("{{}{}}");
            testInput.Add("{{{},{},{{}}}}");
            testInput.Add("{<a>,<a>,<a>,<a>}");
            testInput.Add("{{<ab>},{<ab>},{<ab>},{<ab>}}");
            testInput.Add("{{<!!>},{<!!>},{<!!>},{<!!>}}");
            testInput.Add("{{<a!>},{<a!>},{<a!>},{<ab>}}");
            
            for(int i=0;i<testInput.Count;i++)
            {
                Assert.AreEqual(result[i], _calculator.run(testInput[i]));
            }
        }
    }
}
