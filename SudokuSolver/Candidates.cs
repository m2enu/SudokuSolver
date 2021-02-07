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

        /// <summary> <!-- {{{1 --> Internal candidates
        /// </summary>
        private readonly HashSet<SudokuValue> values;

        /// <summary> <!-- {{{1 --> Constructor
        /// </summary>
        public Candidates()
        {
            this.values = new HashSet<SudokuValue>();
        }

        /// <summary> <!-- {{{1 --> Show current candidates
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("-", values.Select(x => x.ToStr()));
        }

        /// <summary> <!-- {{{1 --> Copy members from specified Candidates instance.
        /// </summary>
        /// <param name="src"></param>
        public void CopyFrom(Candidates src)
        {
            this.values.Clear();
            foreach (var v in src.values)
            {
                this.Add(v);
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
        public bool Add(SudokuValue v)
        {
            return !values.Add(v);
        }

        /// <summary> <!-- {{{1 --> Add specified candidate list
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Add(IEnumerable<SudokuValue> values)
        {
            bool ret = false;
            foreach (var v in values)
            {
                ret |= Add(v);
            }
            return ret;
        }

        /// <summary> <!-- {{{1 --> Remove specified candidate
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool Remove(SudokuValue v)
        {
            return !values.Remove(v);
        }

        /// <summary> <!-- {{{1 --> Aquire current count of candidates
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return values.Count();
        }

        /// <summary> <!-- {{{1 --> Convert values to candidates
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Candidates ToCandidates(IEnumerable<SudokuValue> values)
        {
            var candidates = SudokuValueExtension.ValueList().Except(values);
            var ret = new Candidates();
            ret.Add(candidates);
            return ret;
        }

    }

}

// end of file <!-- {{{1 -->
// vi:ft=cs:et:ts=4:nowrap:fdm=marker
