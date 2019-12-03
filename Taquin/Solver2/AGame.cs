using System;
using System.Collections.Generic;
using Solver2.Graph;

namespace Solver2
{
    public abstract class AGame<TMove>
    {

        public abstract ANode<TMove> State { get; set; }

        public abstract List<ANode<TMove>> NextNodes(ANode<TMove> from, Func<ANode<TMove>, bool> filter = null);

        public abstract bool MakeMove(TMove move);

        public int MakeMoves(params TMove[] moves)
        {
            if (moves == null || moves.Length < 0)
                return -1;

            int k = 0;
            while (k < moves.Length && moves[k] != null && this.MakeMove(moves[k++]))
                ;

            return k;
        }

    }
}
