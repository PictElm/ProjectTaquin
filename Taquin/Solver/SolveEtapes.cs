using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class SolveEtapes : SolveAEtoile, ISolve
    {

        public override Solution Solve(Game game, int[,] finalState, Action<Solution.ProgressReportObject> reportProgress)
        {
            Solution r = null;

            for (int k = 0; k < game.GetSize() * game.GetSize(); k++)
            {
                var partFinalState = this.BuildSolutionStep(game.GetSize(), k);
                Solution partial = base.Solve(game, partFinalState, reportProgress);

                foreach (var step in partial.Steps)
                    game.MakeMove(step.move[0], step.move[1], step.move[2], step.move[3]);

                r += partial;
            }

            return r;
        }

        internal int[,] BuildSolutionStep(int size, int n)
        {
            int[,] r = new int[size, size];

            for (int k = 1, i = 0; i < size; i++)
                for (int j = 0; j < size; r[i, j++] = k < n ? k++ : -1)
                    ;

            return r;
        }

    }
}
