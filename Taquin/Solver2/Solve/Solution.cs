using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2.Solve
{
    public class Solution<T_Move>
    {

        /// <summary>
        /// Liste des étapes à suivre pour suivre la solution. Voir aussi : <seealso cref="Solution.Step"/>.
        /// </summary>
        public List<Graph.INode<T_Move>> Steps { get; private set; }

        private Solution()
        {
            this.Steps = new List<Graph.INode<T_Move>>();
        }

        private Solution(params List<Graph.INode<T_Move>>[] manySteps) : this()
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
        public static Solution<T_Move> BuildPathFrom(Graph.Graph<T_Move> g, bool reversed = false)
        {
            var r = new Solution<T_Move>();
            Graph.INode<T_Move> current = g.GetFinal();

            while (current != null)
            {
                r.Steps.Add(current);
                current = current.Parent;
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
        public static Solution<T_Move> operator +(Solution<T_Move> a, Solution<T_Move> b)
        {
            if (a == null)
                return b.Steps.Count == 0 ? null : new Solution<T_Move>(b.Steps);
            if (b == null)
                return a.Steps.Count == 0 ? null : new Solution<T_Move>(a.Steps);
            return new Solution<T_Move>(a.Steps, b.Steps);
        }

    }
}
