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

    /// <summary> <!-- {{{1 --> Sudoku solving path class
    /// </summary>
    public class Path
    {

        /// <summary> <!-- {{{1 --> Remaining cell to be updated
        /// </summary>
        public readonly ReadOnlyCollection<Cell> CellsToBeUpdate;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        /// <param name="cells"></param>
        public Path(IEnumerable<Cell> cells)
        {
            this.CellsToBeUpdate = new ReadOnlyCollection<Cell>(cells.ToList());
        }

    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
