using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class Solve3 : ISolve
    {

        public void Solve(Game game, int[,] finalState)
        {
            Graph g = new Graph(new Node(game.ToGrid()));
            Node final = null;

            while (final == null)
            {
                List<Node> nexts = new List<Node>();
                foreach (var node in g.Opened)
                {

                }
            }
        }

    }
}
