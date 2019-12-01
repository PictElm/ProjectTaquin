using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2.Solve.Method
{
    public abstract class ASolveEtapes<TMove> : SolveAEtoile<TMove>
    {

        public override Solution<TMove> Solve(AGame<TMove> game, Graph.ANode<TMove> finalState)
        {
            Solution<TMove> r = null;

            int count = this.GetStepCount(game);
            for (int k = 0; k < count; k++)
            {
                var partFinalState = this.BuildSolutionStep(finalState, k);

                Solution<TMove> partial = base.Solve(game, partFinalState);
                game.MakeMoves(partial.Moves.ToArray());

                r += partial;
            }

            return r;
        }

        /// <summary>
        /// Nombre d'étapes soit le plus grand nombre qu'acceptera la fonction <see cref="BuildSolutionStep(Graph.ANode{TMove}, int)"/>
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
        protected abstract Graph.ANode<TMove> BuildSolutionStep(Graph.ANode<TMove> targetState, int n);

    }
}
