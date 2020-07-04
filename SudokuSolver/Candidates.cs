/*******************************************************************************
 * Copyright (c) 2020 m2enu
 * Released under the MIT License
 * https://github.com/m2enu/SudokuSolver/blob/master/LICENSE.txt
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{

    /// <summary> <!-- {{{1 --> Sudoku candidates class
    /// </summary>
    public class Candidates
    {

        /// <summary> <!-- {{{1 --> All available values
        /// </summary>
        private static readonly SudokuValue[] CELL_VALUES = new int[] {
            1, 2, 3, 4, 5, 6, 7, 8, 9}.Select(x => (SudokuValue)x).ToArray();

        /// <summary> <!-- {{{1 --> Internal candidates
        /// </summary>
        private readonly HashSet<Value> values;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        public Candidates()
        {
            this.values = new HashSet<Value>(
                CELL_VALUES.Select(x => new Value(x)) );
        }

        /// <summary> <!-- {{{1 --> Show current candidates
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("-", values.Select(x => x.ToString()));
        }

        /// <summary> <!-- {{{1 --> Copy members from specified Candidates instance.
        /// </summary>
        /// <param name="src"></param>
        public void CopyFrom(Candidates src)
        {
            this.values.Clear();
            foreach (var i in src.values)
            {
                var v = new Value(SudokuValue.NA);
                v.CopyFrom(i);
                this.values.Add(v);
            }
        }

        /// <summary> <!-- {{{1 --> Clear all candidates
        /// </summary>
        public void Clear()
        {
            values.Clear();
        }

        /// <summary> <!-- {{{1 --> Add specified candidate
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool Add(Value v)
        {
            if (values.Any(x => x.Equals(v)))
            {
                return true;
            }
            values.Add(v);
            return false;
        }

        /// <summary> <!-- {{{1 --> Remove specified candidate
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool Remove(Value v)
        {
            if (!values.Any(x => x.Equals(v)))
            {
                return true;
            }
            values.RemoveWhere(x => x.Equals(v));
            return false;
        }

        /// <summary> <!-- {{{1 --> Aquire current count of candidates
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return values.Count();
        }

    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
