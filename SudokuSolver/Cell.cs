/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SudokuSolver
{

    /// <summary> <!-- {{{1 --> Index of Sudoku cell
    /// </summary>
    public enum SudokuCellIndex
    {
        MIN = 0,
        MAX = 80,
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

        /// <summary> <!-- {{{1 --> Return true if the cells have same index.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="tgt"></param>
        /// <returns></returns>
        public static bool IsEquals(this SudokuCellIndex self, SudokuCellIndex tgt)
        {
            return self == tgt;
        }

        /// <summary> <!-- {{{1 --> Throw exception when specified index is invalid.
        /// </summary>
        /// <param name="self"></param>
        public static void AssertWhenInvalid(this SudokuCellIndex self)
        {
            if (self.IsInvalid())
            {
                var msg = string.Format("Invalid cell index: {0}", self.ToStr());
                throw new ArgumentOutOfRangeException(msg);
            }
        }

        /// <summary> <!-- {{{1 --> Throw exception when specified different cell index.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="tgt"></param>
        public static void AssertWhenIndexNotEquals(this SudokuCellIndex self, SudokuCellIndex tgt)
        {
            if (!self.IsEquals(tgt))
            {
                var msg = string.Format("Different cell index: {0} != {1}", self.ToStr(), tgt.ToStr());
                throw new InvalidEnumArgumentException(msg);
            }
        }

        /// <summary> <!-- {{{1 --> Convert from cell index to house index
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static SudokuHouseIndex ToHouseIndex(this SudokuCellIndex self)
        {
            var row = (int)self / 9;
            var col = (int)self % 9;
            var houserow = row / 3;
            var housecol = col / 3;
            return (SudokuHouseIndex)(houserow * 3 + housecol);
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
            var n = SudokuCellIndex.MAX - SudokuCellIndex.MIN + 1;
            return Enumerable.Range((int)SudokuCellIndex.MIN, n)
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
        private SudokuValue value;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        /// <param name="idx"></param>
        public Cell(SudokuCellIndex idx)
        {
            idx.AssertWhenInvalid();
            this.index = idx;
            this.candidate = new Candidates();
            this.value = SudokuValue.NA;
        }

        /// <summary> <!-- {{{1 --> ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.value.ToStr();
        }

        /// <summary> <!-- {{{1 --> Copy members from specified Cell instance.
        /// </summary>
        /// <param name="src"></param>
        public void CopyFrom(Cell src)
        {
            src.index.AssertWhenIndexNotEquals(this.index);
            this.candidate.CopyFrom(src.candidate);
            this.CopyFrom(src.value);
        }

        /// <summary> <!-- {{{1 --> Copy value from specified cell value.
        /// </summary>
        /// <param name="val"></param>
        public void CopyFrom(SudokuValue val)
        {
            val.AssertWhenInvalidOrNA();
            this.value = val;
        }

        /// <summary> <!-- {{{1 --> Return true if the value is same with specified instance.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public bool Equals(Cell src)
        {
            return src.value == this.value;
        }

        /// <summary> <!-- {{{1 --> Return true if the value is same with specified Value instance.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Equals(SudokuValue val)
        {
            return val == this.value;
        }

        /// <summary> <!-- {{{1 --> Convert cells to updated cells
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        public Cell ToUpdatedCell(IEnumerable<Cell> cells)
        {
            var ret = new Cell(this.index)
            {
                value = this.value
            };

            var vals = ToValues(cells);
            var candidates = Candidates.ToCandidates(vals);
            ret.candidate.CopyFrom(candidates);

            return ret;
        }

        /// <summary> <!-- {{{1 --> Convert cells to values
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        public static IEnumerable<SudokuValue> ToValues(IEnumerable<Cell> cells)
        {
            return cells.Select(x => x.value).Distinct();
        }

    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
