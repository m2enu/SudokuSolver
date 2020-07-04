/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SudokuSolver;

namespace SudokuSolverTest
{

    /// <summary> <!-- {{{1 --> Candidate class test
    /// </summary>
    public class TestCandidate
    {

        /// <summary> <!-- {{{1 --> test target
        /// </summary>
        public Candidates tgt = null;

        /// <summary> <!-- {{{1 --> setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            tgt = new Candidates();
        }

        /// <summary> <!-- {{{1 --> teardown
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            tgt = null;
        }

        /// <summary> test at new creation
        /// </summary>
        [Test]
        public void TestNew()
        {
            Assert.AreEqual(9, tgt.Count());
            Assert.AreEqual("1-2-3-4-5-6-7-8-9", tgt.ToString());
        }

        /// <summary> <!-- {{{1 --> clear function
        /// </summary>
        [Test]
        public void TestClear()
        {
            tgt.Clear();
            Assert.AreEqual(0, tgt.Count());
            Assert.AreEqual("", tgt.ToString());
        }

        /// <summary> <!-- {{{1 --> add function
        /// </summary>
        [Test]
        public void TestAdd()
        {
            // invalid case: add not contained value
            Assert.IsTrue(tgt.Add(new Value(SudokuValue._1)));
            Assert.AreEqual(9, tgt.Count());
            Assert.IsTrue(tgt.Add(new Value(SudokuValue._2)));
            Assert.AreEqual(9, tgt.Count());
            Assert.IsTrue(tgt.Add(new Value(SudokuValue._9)));
            Assert.AreEqual(9, tgt.Count());

            // valid case: add already contained value
            tgt.Clear();
            Assert.IsFalse(tgt.Add(new Value(SudokuValue._1)));
            Assert.AreEqual(1, tgt.Count());
            Assert.IsFalse(tgt.Add(new Value(SudokuValue._2)));
            Assert.AreEqual(2, tgt.Count());
            Assert.IsFalse(tgt.Add(new Value(SudokuValue._9)));
            Assert.AreEqual(3, tgt.Count());
        }

        /// <summary> <!-- {{{1 --> remove function
        /// </summary>
        [Test]
        public void TestRemove()
        {
            // valid case: remove already contained value
            Assert.IsFalse(tgt.Remove(new Value(SudokuValue._1)));
            Assert.AreEqual(8, tgt.Count());
            Assert.IsFalse(tgt.Remove(new Value(SudokuValue._2)));
            Assert.AreEqual(7, tgt.Count());
            Assert.IsFalse(tgt.Remove(new Value(SudokuValue._3)));
            Assert.AreEqual(6, tgt.Count());

            // invalid case: remove not contained value
            Assert.IsTrue(tgt.Remove(new Value(SudokuValue._1)));
            Assert.AreEqual(6, tgt.Count());
            Assert.IsTrue(tgt.Remove(new Value(SudokuValue._2)));
            Assert.AreEqual(6, tgt.Count());
            Assert.IsTrue(tgt.Remove(new Value(SudokuValue._3)));
            Assert.AreEqual(6, tgt.Count());
        }
    }
}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
