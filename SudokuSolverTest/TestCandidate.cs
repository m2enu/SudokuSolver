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

    /// <summary> <!-- {{{1 --> Candidate class test
    /// </summary>
    public class TestCandidate : IDisposable
    {

        /// <summary> <!-- {{{1 --> test target
        /// </summary>
        public Candidates tgt = null;

        /// <summary> <!-- {{{1 --> setup
        /// </summary>
        public TestCandidate()
        {
            tgt = new Candidates();
        }

        /// <summary> <!-- {{{1 --> teardown
        /// </summary>
        public void Dispose()
        {
            tgt = null;
        }

        /// <summary> test at new creation
        /// </summary>
        [Fact(Skip = "Disabled tentatively")]
        public void TestNew()
        {
            Assert.Equal(9, tgt.Count());
            Assert.Equal("1-2-3-4-5-6-7-8-9", tgt.ToString());
        }

        /// <summary> <!-- {{{1 --> clear function
        /// </summary>
        [Fact]
        public void TestClear()
        {
            tgt.Clear();
            Assert.Equal(0, tgt.Count());
            Assert.Equal("", tgt.ToString());
        }

        /// <summary> <!-- {{{1 --> add function
        /// </summary>
        [Fact(Skip = "Disabled tentatively")]
        public void TestAdd()
        {
            // invalid case: add not contained value
            Assert.True(tgt.Add(SudokuValue._1)); Assert.Equal(9, tgt.Count());
            Assert.True(tgt.Add(SudokuValue._2)); Assert.Equal(9, tgt.Count());
            Assert.True(tgt.Add(SudokuValue._9)); Assert.Equal(9, tgt.Count());

            // valid case: add already contained value
            tgt.Clear();
            Assert.False(tgt.Add(SudokuValue._1)); Assert.Equal(1, tgt.Count());
            Assert.False(tgt.Add(SudokuValue._2)); Assert.Equal(2, tgt.Count());
            Assert.False(tgt.Add(SudokuValue._9)); Assert.Equal(3, tgt.Count());
        }

        /// <summary> <!-- {{{1 --> remove function
        /// </summary>
        [Fact(Skip = "Disabled tentatively")]
        public void TestRemove()
        {
            // valid case: remove already contained value
            Assert.False(tgt.Remove(SudokuValue._1)); Assert.Equal(8, tgt.Count());
            Assert.False(tgt.Remove(SudokuValue._2)); Assert.Equal(7, tgt.Count());
            Assert.False(tgt.Remove(SudokuValue._3)); Assert.Equal(6, tgt.Count());

            // invalid case: remove not contained value
            Assert.True(tgt.Remove(SudokuValue._1)); Assert.Equal(6, tgt.Count());
            Assert.True(tgt.Remove(SudokuValue._2)); Assert.Equal(6, tgt.Count());
            Assert.True(tgt.Remove(SudokuValue._3)); Assert.Equal(6, tgt.Count());
        }
    }
}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
