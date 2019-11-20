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
                var partFinalState = this.BuildSolutionStep(finalState, k + 1);
                Solution partial = base.Solve(game, partFinalState, reportProgress);

                foreach (var step in partial.Steps)
                    if (step.move != null)
                        game.MakeMove(step.move[0], step.move[1], step.move[2], step.move[3]);

                r += partial;
            }

            return r;
        }

        /// <summary>
        /// Génère la grille de l'étape <paramref name="n"/>.
        /// </summary>
        /// <param name="targetState">Etat final ciblé.</param>
        /// <param name="n">Numéro de l'étape.</param>
        /// <returns></returns>
        internal int[,] BuildSolutionStep(int[,] targetState, int n)
        {
            int[,] r = new int[targetState.GetLength(0), targetState.GetLength(1)];

            for (int k = 0, i = 0; i < targetState.GetLength(0); i++)
                for (int j = 0; j < targetState.GetLength(1); j++)
                    r[i, j] = k++ < n ? targetState[i, j] : -1;

            var da = new Node(r);

            return r;
        }

    }
}
