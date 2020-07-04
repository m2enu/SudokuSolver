/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Threading;

namespace SudokuSolver
{

    /// <summary> <!-- {{{1 --> Sudoku value enumeration
    /// </summary>
    public enum SudokuValue
    {
        NA = 0,
        _1 = 1,
        _2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9
    }

    /// <summary> <!-- {{{1 --> Enum extension for SudokuValue
    /// </summary>
    public static class SudokuValueExtension
    {

        /// <summary> <!-- {{{1 --> Return true if the value is not available.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsNA(this SudokuValue self)
        {
            return (SudokuValue.NA == self);
        }

        /// <summary> <!-- {{{1 --> Return true if the value is invalid.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsInvalid(this SudokuValue self)
        {
            return (SudokuValue._1 > self) || (SudokuValue._9 < self);
        }

        /// <summary> <!-- {{{1 --> Return true if the value is valid.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsValid(this SudokuValue self)
        {
            return !self.IsInvalid();
        }

        /// <summary> <!-- {{{1 --> Convert SudokuValue to Integer
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int ToInt(this SudokuValue self)
        {
            return (int)self;
        }

        /// <summary> <!-- {{{1 --> Convert SudokuValue to String
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToStr(this SudokuValue self)
        {
            if (self.IsInvalid()) return ".";
            return self.ToInt().ToString();
        }
    }

    /// <summary> <!-- {{{1 --> Sudoku value class
    /// </summary>
    public class Value
    {

        /// <summary> <!-- {{{1 --> Placed cell value and 0 means not placed.
        /// </summary>
        private SudokuValue v;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        /// <param name="initial"></param>
        public Value(SudokuValue initial)
        {
            if (!initial.IsNA() && initial.IsInvalid())
            {
                var msg = string.Format("Invalid value: {0}", initial.ToStr());
                throw new ArgumentOutOfRangeException(msg);
            }
            this.v = initial;
        }

        /// <summary> <!-- {{{1 --> Return true if this cell is placed.
        /// </summary>
        public bool IsPlaced
        {
            get
            {
                return this.v.IsValid();
            }
        }

        /// <summary> <!-- {{{1 --> ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.v.ToStr();
        }

        /// <summary> <!-- {{{1 --> Copy members from specified Value instance.
        /// </summary>
        /// <param name="src"></param>
        public void CopyFrom(Value src)
        {
            this.v = src.v;
        }

        /// <summary> <!-- {{{1 --> Return true if the value is same with specified instance.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public bool Equals(Value src)
        {
            return (src.v == this.v);
        }
    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
