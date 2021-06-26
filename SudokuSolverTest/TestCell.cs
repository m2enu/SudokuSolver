/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Linq;
using Xunit;
using SudokuSolver;

namespace SudokuSolverTest
{

    /// <summary> <!-- {{{1 --> Sudoku cell test
    /// </summary>
    public class TestCell: IDisposable
    {

        /// <summary> <!-- {{{1 --> setup
        /// </summary>
        public TestCell()
        {
        }

        /// <summary> <!-- {{{1 --> teardown
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary> <!-- {{{1 --> example unittest
        /// </summary>
        [Fact]
        public void Test1()
        {
        }
    }

    /// <summary> <!-- {{{1 --> Test for SudokuCellExtension class
    /// </summary>
    public class TestCellExtension: IDisposable
    {

        /// <summary> <!-- {{{1 --> Test target
        /// </summary>
        private SudokuCellIndex tgt;

        /// <summary> <!-- {{{1 --> Setup
        /// </summary>
        public TestCellExtension()
        {
            tgt = SudokuCellIndex.MIN;
        }

        /// <summary> <!-- {{{1 --> teardown
        /// </summary>
        public void Dispose()
        {
            tgt = SudokuCellIndex.MIN;
        }

        /// <summary> <!-- {{{1 --> Test for ToHouseIndex
        /// </summary>
        [Fact]
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
                Assert.Equal(exp, ans);
            }
        }

    }
}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
