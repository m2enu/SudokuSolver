/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using NUnit.Framework;
using SudokuSolver;
using System.Linq;

namespace SudokuSolverTest
{

    /// <summary> <!-- {{{1 --> Test for SolverFullHouse class
    /// </summary>
    public class TestSolverFullHouse
    {

        private SolverFullHouse tgt;

        /// <summary> <!-- {{{1 --> setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            tgt = new SolverFullHouse();
        }

        /// <summary> <!-- {{{1 --> teardown
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            tgt = null;
        }

        /// <summary> <!-- {{{1 --> Candidate in only one house
        /// </summary>
        [Test]
        public void TestOnlyInOneHouse()
        {
            var pat = string.Join("",
                "2.7......",
                ".8..9....",
                ".3.6..8..",
                "..8.649..",
                "6927853.4",
                "..132.5..",
                "..9..1.2.",
                "....4..9.",
                "......4.8"
            );
            var puzzle = new Sudoku();
            puzzle.LoadFromStr(pat);
            Assert.AreEqual(pat, puzzle.ToString());

            var result = tgt.Solve(puzzle);
            Assert.AreEqual(SolvingTechnique.FullHouse, result.Technique);
        }
    }
}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
