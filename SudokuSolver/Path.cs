/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;

namespace SudokuSolver
{

    /// <summary> <!-- {{{1 --> Sudoku solving path class
    /// </summary>
    public class Path
    {
        private readonly Sudoku puzzle;

        public Path()
        {
            this.puzzle = new Sudoku();
        }
    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
