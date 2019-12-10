using System;
using System.Collections.Generic;
using Solver2.Graph;

namespace Solver2
{
    public abstract class AGame<TMove>
    {

        public abstract ANode<TMove> State { get; set; }
        protected abstract List<ANode<TMove>> BuildNextNodes(ANode<TMove> from);

        public List<ANode<TMove>> NextNodes(ANode<TMove> from, Predicate<ANode<TMove>> filter = null)
        {
            var all = this.BuildNextNodes(from);
            
            if (filter != null)
            {
                var filtered = all.FindAll(filter);
                return filtered.Count == 0 ? all : filtered;
            }
            return all;
        }

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
