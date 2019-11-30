using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2
{
    public abstract class AGame<T_Move>
    {

        public abstract Graph.INode<T_Move> State { get; set; }

        public abstract List<Graph.INode<T_Move>> NextNodes(Graph.INode<T_Move> from, Func<Graph.INode<T_Move>, bool> filter = null);

        public abstract bool MakeMove(T_Move move);

        public int MakeMoves(params T_Move[] moves)
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
