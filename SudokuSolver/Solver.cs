/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SudokuSolver
{

    /// <summary> <!-- {{{1 --> Solve result
    /// </summary>
    public class SolveResult
    {

        /// <summary> <!-- {{{1 --> Solving technique
        /// </summary>
        public readonly SolvingTechnique Technique;

        /// <summary> <!-- {{{1 --> Cells
        /// </summary>
        public readonly IEnumerable<Cell> Cells;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        /// <param name="tech"></param>
        /// <param name="cells"></param>
        public SolveResult(SolvingTechnique tech, IEnumerable<Cell> cells)
        {
            this.Technique = tech;
            this.Cells = cells;
        }

    }

    /// <summary> <!-- {{{1 --> Solving technique enumeration
    /// </summary>
    public enum SolvingTechnique
    {
        Invalid,
        FullHouse,
    }

    /// <summary> <!-- {{{1 --> Enum extension for SolvingTechnique
    /// </summary>
    public static class SolvingTechniqueExtention
    {

        /// <summary> <!-- {{{1 --> Return true if solved
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsSolved(this SolvingTechnique self)
        {
            return SolvingTechnique.Invalid != self;
        }

    }

    /// <summary> <!-- {{{1 --> Sudoku solver interface
    /// </summary>
    public interface ISudokuSolver
    {

        /// <summary> <!-- {{{1 --> Solving technique
        /// </summary>
        public SolvingTechnique Technique { get; }

        /// <summary> <!-- {{{1 --> Try solve
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns></returns>
        public SolveResult Solve(Sudoku puzzle);

    }

    /// <summary> <!-- {{{1 --> The last digit in House (Row / Column / Box)
    /// </summary>
    public class SolverFullHouse : ISudokuSolver
    {

        /// <summary> <!-- {{{1 --> Technique enum
        /// </summary>
        public SolvingTechnique Technique
        {
            get { return SolvingTechnique.FullHouse; }
        }

        /// <summary> <!-- {{{1 --> Try solve by Full House
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns></returns>
        public SolveResult Solve(Sudoku puzzle)
        {
            var cells = new List<Cell>();
            foreach (var idx_c in SudokuCellIndexExtension.IndexList())
            {
                var idx_h = idx_c.ToHouseIndex();
                var rows = puzzle.CellsFromRow(idx_h);
                var cols = puzzle.CellsFromCol(idx_h);
                var boxs = puzzle.CellsFromBox(idx_h);
                var house = rows.Concat(cols).Concat(boxs);
                OnlyInOneHouse(rows, cells);
                OnlyInOneHouse(cols, cells);
                OnlyInOneHouse(boxs, cells);
            }
            if (cells.Count() != 0)
            {
                return new SolveResult(SolvingTechnique.FullHouse, cells);
            }
            return new SolveResult(SolvingTechnique.Invalid, null);
        }

        private void OnlyInOneHouse(IEnumerable<Cell> cells, List<Cell> dst)
        {
            foreach (var tgt in SudokuValueExtension.ValueList())
            {
                var n = cells.Count(x => x.Equals(tgt) == true);
                if (n == 1)
                {
                    var cell = cells.First(x => x.Equals(tgt) == true);
                    dst.Add(cell);
                }
            }
        }

    }
}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
