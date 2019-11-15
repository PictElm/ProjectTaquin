using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public interface ISolve
    {

        Solution Solve(Game game, int[,] finalState, Action<Solution.ProgressReportObject> reportProgress=null);

    }

    public class Solution
    {

        public class ProgressReportObject
        {

            public int[,] state;
            public int nbOpened;
            public int nbClosed;

            public ProgressReportObject(int[,] state, int nbOpened, int nbClosed)
            {
                this.state = state;
                this.nbOpened = nbOpened;
                this.nbClosed = nbClosed;
            }

        }

        public struct Step
        {

            public int[,] grid;
            public int[] move;

            public Step(int[,] grid, int[] move)
            {
                this.grid = grid;
                this.move = move;
            }

            public override String ToString()
            {
                if (this.move == null)
                    return "Etat initial";
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

        private Solution(params List<Step>[] manySteps) : this()
        {
            this.Steps.Add(manySteps[0][0]); // TODO: FIXME: le premier état avec SolveEtapes n'a pas la bonne grille..?

            foreach (var steps in manySteps)
                foreach (var step in steps)
                    if (step.move != null)
                        this.Steps.Add(step);
        }

        public void Reverse()
        {
            this.Steps.Reverse();
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

        public static Solution operator+(Solution a, Solution b)
        {
            if (a == null)
                return new Solution(b.Steps);
            if (b == null)
                return new Solution(a.Steps);
            return new Solution(a.Steps, b.Steps);
        }

    }
}
