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

        public struct Step
        {

            public int[,] grid;
            public int[] move;

            public Step(int[,] grid, int[] move)
            {
                this.grid = grid;
                this.move = move;
            }

            public override string ToString()
            {
                int i1 = this.move[0], j1 = this.move[1];
                int i2 = this.move[2], j2 = this.move[3];
                return $"({i1}, {j1}) -> ({i2}, {j2})";
            }

        }

        public List<Step> Steps { get; private set; }

        private Solution()
        {
            this.Steps = new List<Step>();
        }

        public static Solution BuildPathFrom(Graph g)
        {
            Solution r = new Solution();
            Node current = g.GetFinal();

            while (current != null)
            {
                r.Steps.Add(new Step(current.ToGrid(), current.MoveFromParent));
                current = current.Parent;
            }

            r.Steps.Reverse();

            return r;
        }

    }
}
