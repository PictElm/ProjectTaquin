using System;
using System.Collections.Generic;
using Solver2.Graph;

namespace Solver2.Taquin
{
    public class TaquinNode : ANode<TaquinGame.Move>
    {

        public int[,] Grid { get; private set; }

        public TaquinNode(int[,] grid = null)
        {
            this.Grid = grid;
            this.Parent = null;
            this.Children = new List<ANode<TaquinGame.Move>>();
        }

        public TaquinNode(int[,] grid, TaquinGame.Move moveFromParent) : this(grid)
        {
            this.MoveFromParent = moveFromParent;
        }

        #region Heuristics
        public override int Heuristics(ANode<TaquinGame.Move> final)
        {
            return Heuristics_DistanceManhattan(this.Grid, (final as TaquinNode).Grid);
        }

        /// <summary>
        /// Nombre de différences entre les deux états.
        /// </summary>
        internal static int Heuristics_CountDifferences(int[,] fromState, int[,] toState)
        {
            int r = 0;

            for (int i = 0; i < fromState.GetLength(0); i++)
                for (int j = 0; j < fromState.GetLength(1); j++)
                    if (fromState[i, j] != toState[i, j])
                        r++;

            return r;
        }

        /// <summary>
        /// Somme des distances de Manhattan de chaque case à sa destination.
        /// </summary>
        internal static int Heuristics_DistanceManhattan(int[,] fromState, int[,] toState)
        {
            int r = 0;
            relatedSize = fromState.GetLength(0);

            // calcule la distance de Manhattan pour chaque
            for (int i = 0; i < fromState.GetLength(0); i++)
                for (int j = 0; j < fromState.GetLength(1); j++)
                {
                    int here = fromState[i, j];
                    int[] pos = Supposed[0 < here ? here - 1 : Supposed.Length - 1];
                    r += Math.Abs(pos[0] - i) + Math.Abs(pos[1] - j);
                }

            return r;
        }
        private static int[][] _supposed;
        private static int relatedSize;
        private static int[][] Supposed
        {
            get
            {
                if (_supposed == null)
                {
                    // détermine là où les cases deveraient être
                    _supposed = new int[relatedSize * relatedSize][];
                    for (int k = 0; k < _supposed.Length; k++)
                        _supposed[k] = new int[2] { k / relatedSize, k % relatedSize };
                }
                return _supposed;
            }
        }
        #endregion

        #region Overrides
        private String _hash;
        public override String Hash
        {
            get
            {
                if (this._hash == null)
                {
                    this._hash = "";
                    foreach (var v in this.Grid)
                        this._hash += v.ToString() + ",";
                }
                return this._hash;
            }
        }

        public override bool SameAs(ANode<TaquinGame.Move> mate)
        {
            int[,] ga = this.Grid, gb = (mate as TaquinNode).Grid;
            for (int i = 0; i < ga.GetLength(0); i++)
                for (int j = 0; j < ga.GetLength(1); j++)
                    if (ga[i, j] != gb[i, j] && ga[i, j] != -1 && gb[i, j] != -1)
                        return false;

            return true;
        }

        public override string ToString()
        {
            if (this.Parent == null)
                return "Etat initial";
            return $"({this.MoveFromParent.i1}, {this.MoveFromParent.j1}) -> ({this.MoveFromParent.i2}, {this.MoveFromParent.j2})";
        }
        #endregion

    }
}
