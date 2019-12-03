namespace Solver2.Solve
{
    public interface ISolve<TMove>
    {

        /// <summary>
        /// Résout le jeu (<paramref name="game"/>) depuis son état actuel jusqu'à l'état final
        /// (<paramref name="finalState"/>).
        /// </summary>
        /// <param name="game">Jeu à résoudre, dans son état initial (e.g. mélangé).</param>
        /// <param name="finalState">Etat final à atteindre.</param>
        /// en paramètre, tennant à jours de l'avencement de la résolution.</param>
        /// <returns></returns>
        Solution<TMove> Solve(AGame<TMove> game, Graph.ANode<TMove> finalState);

    }
}
