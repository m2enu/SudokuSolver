/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SudokuSolver
{

    /// <summary> <!-- {{{1 --> Index of Sudoku House
    /// </summary>
    public enum SudokuHouseIndex
    {
        _1 = 0,
        _2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9,
    }

    /// <summary> <!-- {{{1 --> Enum extension for SudokuHouseIndex
    /// </summary>
    public static class SudokuHouseIndexExtension
    {

        /// <summary> <!-- {{{1 --> Return true if the index is invalid.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsInvalid(this SudokuHouseIndex self)
        {
            return (SudokuHouseIndex._1 > self) || (SudokuHouseIndex._9 < self);
        }

        /// <summary> <!-- {{{1 --> Convert the house index to Integer
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int ToInt(this SudokuHouseIndex self)
        {
            return (int)self;
        }

        /// <summary> <!-- {{{1 --> Convert house index to cell indexes in row.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<SudokuCellIndex> ToCellsIndexInRow(this SudokuHouseIndex self)
        {
            return SudokuCellIndexExtension.IndexList()
                .Skip(self.ToInt() * 9).Take(9);
        }

        /// <summary> <!-- {{{1 --> Convert house index to cell indexes in column.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<SudokuCellIndex> ToCellsIndexInCol(this SudokuHouseIndex self)
        {
            return Enumerable.Range(0, 9)
                .Select(x => (SudokuCellIndex)(9 * x + self.ToInt()));
        }

        /// <summary> <!-- {{{1 --> Convert house index to cell indexes in box.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<SudokuCellIndex> ToCellsIndexInBox(this SudokuHouseIndex self)
        {
            // calculate Top Left index in target Box
            var idx = self.ToInt();
            int topleft = (27 * (idx / 3)) + (3 * (idx % 3));
            return Enumerable.Range(0, 3)
                .SelectMany(y => Enumerable.Range(0, 3)
                    .Select(x => (SudokuCellIndex)(topleft + x + 9 * y)));
        }
    }

    /// <summary> <!-- {{{1 --> Sudoku puzzle class
    /// </summary>
    public class Sudoku
    {

        /// <summary> <!-- {{{1 --> Sudoku cell list
        /// </summary>
        protected readonly Cell[] board;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        public Sudoku()
        {
            this.board = SudokuCellIndexExtension.IndexList()
                .Select(x => new Cell(x)).ToArray();
        }

        /// <summary> <!-- {{{1 --> ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.board
                .Select(x => x.ToString())
                .Aggregate((a, b) => a + b);
        }

        /// <summary> <!-- {{{1 --> Get cells from row index
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IEnumerable<Cell> CellsFromRow(SudokuHouseIndex idx)
        {
            if (idx.IsInvalid())
            {
                // FIXME: add exception message
                throw new ArgumentOutOfRangeException();
            }
            return idx.ToCellsIndexInRow().Select(x => this.board.ElementAt(x.ToInt()));
        }

        /// <summary> <!-- {{{1 --> Get cells from column index
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IEnumerable<Cell> CellsFromCol(SudokuHouseIndex idx)
        {
            if (idx.IsInvalid())
            {
                // FIXME: add exception message
                throw new ArgumentOutOfRangeException();
            }
            return idx.ToCellsIndexInCol().Select(x => this.board.ElementAt(x.ToInt()));
        }

        /// <summary> <!-- {{{1 --> Get cells from box index
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IEnumerable<Cell> CellsFromBox(SudokuHouseIndex idx)
        {
            if (idx.IsInvalid())
            {
                // FIXME: add exception message
                throw new ArgumentOutOfRangeException();
            }
            return idx.ToCellsIndexInBox().Select(x => this.board.ElementAt(x.ToInt()));
        }

    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
