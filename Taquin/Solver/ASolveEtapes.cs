using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public abstract class ASolveEtapes : SolveAEtoile/*SolveBrutForce*/, ISolve
    {

        public override Solution Solve(Game game, int[,] finalState, Action<Solution.ProgressReportObject> reportProgress=null)
        {
            Game testGame = new Game(game);
            Solution r = null;

            int finalProgress = testGame.GetSize() * testGame.GetSize();

            int progress = 0;
            foreach (var stepSize in this.StepSizeSlices(testGame.GetSize()))
            {
                progress += stepSize;

                var partFinalState = this.BuildSolutionStep(finalState, progress);

                Solution partial = base.Solve(testGame, partFinalState);
                testGame.MakeMoves(partial.GetMoves());

                r += partial;
                reportProgress(new Solution.ProgressReportObject(testGame.ToGrid(), 0, 0));
            }

            if (progress < testGame.GetSize() * testGame.GetSize())
                r += base.Solve(testGame, this.BuildSolutionStep(finalState, finalProgress));

            return r;
        }

        /// <summary>
        /// Retourne la taille de chaque étapes, i.e. le nombre de cases qu'on veut avoir placées correctement.
        /// </summary>
        /// <param name="gameSize"></param>
        /// <returns></returns>
        protected abstract int[] StepSizeSlices(int gameSize);

        /// <summary>
        /// Génère la grille de l'étape <paramref name="n"/>.
        /// </summary>
        /// <param name="targetState">Etat final ciblé.</param>
        /// <param name="n">Numéro de l'étape.</param>
        /// <returns></returns>
        protected virtual int[,] BuildSolutionStep(int[,] targetState, int n)
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
