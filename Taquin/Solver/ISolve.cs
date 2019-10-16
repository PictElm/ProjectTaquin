using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public interface ISolve
    {

        Solution Solve(Game game, int[,] finalState);

    }

    public class Solution
    {

        public List<int[,]> Stages { get; private set; }
        public List<int[]> Moves { get; private set; }

        private Solution()
        {
            this.Stages = new List<int[,]>();
            this.Moves = new List<int[]>();
        }

        public static Solution BuildPathFrom(Graph g)
        {
            Solution r = new Solution();
            Node current = g.GetFinal();

            while (current != null)
            {
                r.Stages.Add(current.ToGrid());
                r.Moves.Add(current.MoveFromParent);

                current = current.Parent;
            }

            r.Stages.Reverse();
            r.Moves.Reverse();

            return r;
        }

    }
}
