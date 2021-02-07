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

    /// <summary> <!-- {{{1 --> Sudoku cell test
    /// </summary>
    public class TestCell
    {

        /// <summary> <!-- {{{1 --> setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary> <!-- {{{1 --> example unittest
        /// </summary>
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }

    /// <summary> <!-- {{{1 --> Test for SudokuCellExtension class
    /// </summary>
    public class TestCellExtension
    {

        /// <summary> <!-- {{{1 --> Test target
        /// </summary>
        private SudokuCellIndex tgt;

        /// <summary> <!-- {{{1 --> Setup
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            tgt = SudokuCellIndex.MIN;
        }

        /// <summary> <!-- {{{1 --> Test for ToHouseIndex
        /// </summary>
        [Test]
        public void TestToHouseIndex()
        {
            var exps = new int[] {
                 0, 0, 0, 1, 1, 1, 2, 2, 2,
                 0, 0, 0, 1, 1, 1, 2, 2, 2,
                 0, 0, 0, 1, 1, 1, 2, 2, 2,
                 3, 3, 3, 4, 4, 4, 5, 5, 5,
                 3, 3, 3, 4, 4, 4, 5, 5, 5,
                 3, 3, 3, 4, 4, 4, 5, 5, 5,
                 6, 6, 6, 7, 7, 7, 8, 8, 8,
                 6, 6, 6, 7, 7, 7, 8, 8, 8,
                 6, 6, 6, 7, 7, 7, 8, 8, 8
            }.Select(x => (SudokuHouseIndex)x);
            for (var i = 0; i < 81; i++)
            {
                tgt = (SudokuCellIndex)i;
                var ans = tgt.ToHouseIndex();
                var exp = exps.ElementAt(i);
                Assert.AreEqual(exp, ans, "{0}: {1} != {2}", i, exp.ToStr(), ans.ToStr());
            }
        }

    }
}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
