using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2.Solve
{
    public interface ISolve<T_Move>
    {

        /// <summary>
        /// Résout le jeu (<paramref name="game"/>) depuis son état actuel jusqu'à l'état final
        /// (<paramref name="finalState"/>).
        /// </summary>
        /// <param name="game">Jeu à résoudre, dans son état initial (e.g. mélangé).</param>
        /// <param name="finalState">Etat final à atteindre.</param>
        /// en paramètre, tennant à jours de l'avencement de la résolution.</param>
        /// <returns></returns>
        Solution<T_Move> Solve(AGame<T_Move> game, Graph.INode<T_Move> finalState);

    }
}
