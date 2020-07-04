/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{

    /// <summary> <!-- {{{1 --> Index of Sudoku cell
    /// </summary>
    public enum SudokuCellIndex
    {
        MIN = 0,
        MAX = 80,
        COUNT = MAX - MIN + 1,
    }

    /// <summary> <!-- {{{1 --> Enum extension for SudokuCellIndex
    /// </summary>
    public static class SudokuCellIndexExtension
    {

        /// <summary> <!-- {{{1 --> Return true if the index is invalid.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsInvalid(this SudokuCellIndex self)
        {
            return (SudokuCellIndex.MIN > self) || (SudokuCellIndex.MAX < self);
        }

        /// <summary> <!-- {{{1 --> Convert the index to Integer
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int ToInt(this SudokuCellIndex self)
        {
            return (int)self;
        }

        /// <summary> <!-- {{{1 --> Convert the index to String
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToStr(this SudokuCellIndex self)
        {
            return self.ToInt().ToString();
        }

        /// <summary> <!-- {{{1 --> Get all cell index in Sudoku board.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SudokuCellIndex> IndexList()
        {
            return Enumerable.Range((int)SudokuCellIndex.MIN, (int)SudokuCellIndex.COUNT)
                .Select(x => (SudokuCellIndex)x);
        }
    }

    /// <summary> <!-- {{{1 --> Sudoku cell class
    /// </summary>
    public class Cell
    {

        /// <summary> <!-- {{{1 --> Index of this cell
        /// </summary>
        private readonly SudokuCellIndex index;

        /// <summary> <!-- {{{1 --> Candidates of this cell
        /// </summary>
        private readonly Candidates candidate;

        /// <summary> <!-- {{{1 --> Value of this cell
        /// </summary>
        private readonly Value value;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        /// <param name="idx"></param>
        public Cell(SudokuCellIndex idx)
        {
            if (idx.IsInvalid())
            {
                var msg = string.Format("Invalid cell index: {0}", idx.ToStr());
                throw new ArgumentOutOfRangeException(msg);
            }
            this.index = idx;
            this.candidate = new Candidates();
            this.value = new Value(SudokuValue.NA);
        }

        /// <summary> <!-- {{{1 --> ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.value.ToString();
        }

        /// <summary> <!-- {{{1 --> Copy members from specified Cell instance.
        /// </summary>
        /// <param name="src"></param>
        public void CopyFrom(Cell src)
        {
            if (src.index != this.index)
            {
                return;
            }
            this.candidate.CopyFrom(src.candidate);
            this.value.CopyFrom(src.value);
        }

        /// <summary> <!-- {{{1 --> Return true if the value is same with specified instance.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public bool Equals(Cell src)
        {
            return this.value.Equals(src.value);
        }
    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
