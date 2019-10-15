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

        public List<int[,]> Stages;

        internal Solution(Graph g, Node final)
        {
            this.Stages = new List<int[,]>();
            this.BuildPathFrom(final);
        }

        private void BuildPathFrom(Node final)
        {
            Node current = final;

            while (current != null)
            {
                this.Stages.Add(current.ToGrid());
                current = current.Parent;
            }

            this.Stages.Reverse();
        }

    }
}
