using System.Collections.Generic;
using Solver2.Graph;

namespace Solver2.Solve
{
    public class Solution<TMove>
    {

        /// <summary>
        /// Liste des étapes à suivre pour suivre la solution. Voir aussi : <seealso cref="Solution.Step"/>.
        /// </summary>
        public List<ANode<TMove>> Steps { get; private set; }
        public List<TMove> Moves { get { return this.Steps.ConvertAll(node => node.MoveFromParent); } }

        public ANode<TMove> Last { get { return this.Steps.Count == 0 ? null : this.Steps[this.Steps.Count - 1]; } }

        public int ExploredStates { get; private set; }

        private Solution(int splored = 0)
        {
            this.Steps = new List<ANode<TMove>>();

            this.ExploredStates = splored;
        }

        private Solution(int splored, params List<ANode<TMove>>[] manySteps) : this(splored)
        {
            this.Steps.Add(manySteps[0][0]); // TODO: FIXME: le premier état avec SolveEtapes n'a pas la bonne grille.?

            foreach (var steps in manySteps)
                foreach (var step in steps)
                    if (step.Parent != null)
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
        public static Solution<TMove> BuildPathFrom(Graph<TMove> g, bool reversed = false)
        {
            var r = new Solution<TMove>(g.Opened.Count + g.Closed.Count);
            ANode<TMove> current = g.Last;

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
        public static Solution<TMove> operator +(Solution<TMove> a, Solution<TMove> b)
        {
            if (a == null) return b.Steps.Count == 0 ? null : new Solution<TMove>(b.ExploredStates, b.Steps);
            if (b == null) return a.Steps.Count == 0 ? null : new Solution<TMove>(a.ExploredStates, a.Steps);

            return new Solution<TMove>(a.ExploredStates + b.ExploredStates, a.Steps, b.Steps);
        }

    }
}
