using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2.Solve
{
    public interface ISolve<T_Node, T_Move> where T_Node : class, Graph.INode<T_Move>
    {

        /// <summary>
        /// Résout le jeu (<paramref name="game"/>) depuis son état actuel jusqu'à l'état final
        /// (<paramref name="finalState"/>).
        /// </summary>
        /// <param name="game">Jeu à résoudre, dans son état initial (e.g. mélangé).</param>
        /// <param name="finalState">Etat final à atteindre.</param>
        /// en paramètre, tennant à jours de l'avencement de la résolution.</param>
        /// <returns></returns>
        Solution<T_Node, T_Move> Solve(AGame<T_Node, T_Move> game, T_Node finalState);

    }

    public class Solution<T_Node, T_Move> where T_Node : class, Graph.INode<T_Move>
    {

        /// <summary>
        /// Liste des étapes à suivre pour suivre la solution. Voir aussi : <seealso cref="Solution.Step"/>.
        /// </summary>
        public List<T_Node> Steps { get; private set; }

        private Solution()
        {
            this.Steps = new List<T_Node>();
        }

        private Solution(params List<T_Node>[] manySteps) : this()
        {
            this.Steps.Add(manySteps[0][0]); // TODO: FIXME: le premier état avec SolveEtapes n'a pas la bonne grille.?

            foreach (var steps in manySteps)
                foreach (var step in steps)
                    if (step.MoveFromParent != null)
                        this.Steps.Add(step);
        }

        /// <summary>
        /// Retourne la liste des étapes (<see cref="Solution.Steps"/>) de résolution de cette solution.
        /// </summary>
        public void Reverse()
        {
            this.Steps.Reverse();
        }

        /// <summary>
        /// Construit le chemin menant à <code>g.GetFinal</code> en remontant la génialogie
        /// (en faisant <code>current = current.Parent</code>). <paramref name="reversed"/> permet
        /// de préciser si le résultat devrait être inversé.
        /// </summary>
        /// <param name="g"><see cref="Graph"/> des neuds.</param>
        /// <param name="reversed"><code>true</code> si le résultat devrait être inversé (par
        /// exemple resolution depuis la fin).</param>
        /// <returns></returns>
        public static Solution<T_Node, T_Move> BuildPathFrom(Graph.Graph<T_Node, T_Move> g, bool reversed = false)
        {
            var r = new Solution<T_Node, T_Move>();
            T_Node current = g.GetFinal();

            while (current != null)
            {
                r.Steps.Add(current);
                current = current.Parent as T_Node;
            }

            if (!reversed)
                r.Steps.Reverse();

            return r;
        }

        /// <summary>
        /// Ajoute les étapes de la solution <paramref name="b"/> à la suite des étapes de la solution
        /// <paramref name="a"/>. Retourn un nouvel élément.
        /// L'élément nul par l'addition est la solution <code>null</code>.
        /// </summary>
        /// <param name="a">Premières étapes.</param>
        /// <param name="b">Dernières étapes.</param>
        /// <returns></returns>
        public static Solution<T_Node, T_Move> operator +(Solution<T_Node, T_Move> a, Solution<T_Node, T_Move> b)
        {
            if (a == null)
                return b.Steps.Count == 0 ? null : new Solution<T_Node, T_Move>(b.Steps);
            if (b == null)
                return a.Steps.Count == 0 ? null : new Solution<T_Node, T_Move>(a.Steps);
            return new Solution<T_Node, T_Move>(a.Steps, b.Steps);
        }

    }
}
