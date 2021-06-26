/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using SudokuSolver;

namespace SudokuSolverTest
{

    /// <summary> <!-- {{{1 --> Sudoku class test
    /// </summary>
    public class TestSudoku: IDisposable
    {

        /// <summary> <!-- {{{1 --> test target
        /// </summary>
        public Sudoku tgt = null;

        /// <summary> <!-- {{{1 --> setup
        /// </summary>
        public TestSudoku()
        {
            tgt = new Sudoku();
        }

        /// <summary> <!-- {{{1 --> teardown
        /// </summary>
        public void Dispose()
        {
            tgt = null;
        }

        /// <summary> <!-- {{{1 --> Verify ToString
        /// </summary>
        [Fact]
        public void TestToString()
        {
            var exp = string.Join("",
                ".........",
                ".........",
                ".........",
                ".........",
                ".........",
                ".........",
                ".........",
                ".........",
                ".........");
            Assert.Equal(exp, tgt.ToString());
        }

    }

    /// <summary> <!-- {{{1 --> Test internal members/functions of Sudoku class
    /// </summary>
    public class TestSudokuInternal: Sudoku, IDisposable
    {

        /// <summary> <!-- {{{1 --> SetUp
        /// </summary>
        public TestSudokuInternal()
        {
        }

        /// <summary> <!-- {{{1 --> TearDown
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary> <!-- {{{1 --> Verify for board instance
        /// </summary>
        [Fact]
        public void TestBoard()
        {
            Assert.Equal(81, this.board.Length);
        }

        /// <summary> <!-- {{{1 --> Verify for row
        /// </summary>
        [Fact]
        public void TestHouseRow()
        {
            var index_list = new int[][]
            {
                new int[] {  0,  1,  2,  3,  4,  5,  6,  7,  8 },
                new int[] {  9, 10, 11, 12, 13, 14, 15, 16, 17 },
                new int[] { 18, 19, 20, 21, 22, 23, 24, 25, 26 },
                new int[] { 27, 28, 29, 30, 31, 32, 33, 34, 35 },
                new int[] { 36, 37, 38, 39, 40, 41, 42, 43, 44 },
                new int[] { 45, 46, 47, 48, 49, 50, 51, 52, 53 },
                new int[] { 54, 55, 56, 57, 58, 59, 60, 61, 62 },
                new int[] { 63, 64, 65, 66, 67, 68, 69, 70, 71 },
                new int[] { 72, 73, 74, 75, 76, 77, 78, 79, 80 },
            };
            for (var x = 0; x < 9; x++)
            {
                var cells = this.CellsFromRow((SudokuHouseIndex)x);
                for (var y = 0; y < 9; y++)
                {
                    var idx = index_list[x][y];
                    var exp = this.board[idx];
                    var ans = cells.ElementAt(y);
                    Assert.True(exp.Equals(ans));
                }
            }
        }

        /// <summary> <!-- {{{1 --> Verify for column
        /// </summary>
        [Fact]
        public void TestHouseCol()
        {
            var index_list = new int[][]
            {
                new int[] {  0,  9, 18, 27, 36, 45, 54, 63, 72 },
                new int[] {  1, 10, 19, 28, 37, 46, 55, 64, 73 },
                new int[] {  2, 11, 20, 29, 38, 47, 56, 65, 74 },
                new int[] {  3, 12, 21, 30, 39, 48, 57, 66, 75 },
                new int[] {  4, 13, 22, 31, 40, 49, 58, 67, 76 },
                new int[] {  5, 14, 23, 32, 41, 50, 59, 68, 77 },
                new int[] {  6, 15, 24, 33, 42, 51, 60, 69, 78 },
                new int[] {  7, 16, 25, 34, 43, 52, 61, 70, 79 },
                new int[] {  8, 17, 26, 35, 44, 53, 62, 71, 80 },
            };
            for (var x = 0; x < 9; x++)
            {
                var cells = this.CellsFromCol((SudokuHouseIndex)x);
                for (var y = 0; y < 9; y++)
                {
                    var idx = index_list[x][y];
                    var exp = this.board[idx];
                    var ans = cells.ElementAt(y);
                    Assert.True(exp.Equals(ans));
                }
            }
        }

        /// <summary> <!-- {{{1 --> Verify for box
        /// </summary>
        [Fact]
        public void TestHouseBox()
        {
            var index_list = new int[][]
            {
                new int[] {  0,  1,  2,  9, 10, 11, 18, 19, 20 },
                new int[] {  3,  4,  5, 12, 13, 14, 21, 22, 23 },
                new int[] {  6,  7,  8, 15, 16, 17, 24, 25, 26 },
                new int[] { 27, 28, 29, 36, 37, 38, 45, 46, 47 },
                new int[] { 30, 31, 32, 39, 40, 41, 48, 49, 50 },
                new int[] { 33, 34, 35, 42, 43, 44, 51, 52, 53 },
                new int[] { 54, 55, 56, 63, 64, 65, 72, 73, 74 },
                new int[] { 57, 58, 59, 66, 67, 68, 75, 76, 77 },
                new int[] { 60, 61, 62, 69, 70, 71, 78, 79, 80 },
            };
            for (var x = 0; x < 9; x++)
            {
                var cells = this.CellsFromBox((SudokuHouseIndex)x);
                for (var y = 0; y < 9; y++)
                {
                    var idx = index_list[x][y];
                    var exp = this.board[idx];
                    var ans = cells.ElementAt(y);
                    Assert.True(exp.Equals(ans));
                }
            }
        }

    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
