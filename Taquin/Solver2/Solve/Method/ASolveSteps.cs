using Solver2.Graph;

namespace Solver2.Solve.Method
{
    public abstract class ASolveSteps<TMove> : SolveAstar<TMove>
    {

        public override Solution<TMove> Solve(AGame<TMove> game, ANode<TMove> finalState)
        {
            Solution<TMove> r = null;

            int count = this.GetStepCount(game);
            for (int k = 0; k < count; k++)
            {
                var partFinalState = this.BuildSolutionStep(game, finalState, k + 1);

                // TMP
                var g = game as Taquin.TaquinGame;
                var n = partFinalState as Taquin.TaquinNode;
                for (int i = 0; i < g.Size; i++)
                    for (int j = 0; j < g.Size; j++)
                        g.Grid[i, j] = n.Grid[i, j];
                return null;
                
                base.FilterNode = this.BuildFilterNode(game, finalState, k + 1, partFinalState);
                Solution<TMove> partial = base.Solve(game, partFinalState);

                System.Diagnostics.Debug.WriteLine($"Finished step {k + 1} of {count}");
                game.State = partial.Last;

                r += partial;
            }

            return r;
        }

        /// <summary>
        /// Nombre d'étapes soit le plus grand nombre qu'acceptera la fonction <see cref="BuildSolutionStep(ANode{TMove}, int)"/>
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        protected abstract int GetStepCount(AGame<TMove> game);

        /// <summary>
        /// Génère la grille de l'étape <paramref name="n"/>.
        /// </summary>
        /// <param name="targetState">Etat final ciblé.</param>
        /// <param name="n">Numéro de l'étape.</param>
        /// <returns></returns>
        protected abstract ANode<TMove> BuildSolutionStep(AGame<TMove> gameRef, ANode<TMove> targetState, int n);

        protected virtual ANode<TMove> BuildFilterNode(AGame<TMove> gameRef, ANode<TMove> targetState, int n, ANode<TMove> currentSolutionStep) { return null; }

    }
}
