using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public interface ISolve
    {

        /// <summary>
        /// Résout le jeu (<paramref name="game"/>) depuis son état actuel jusqu'à l'état final
        /// (<paramref name="finalState"/>).
        /// </summary>
        /// <param name="game">Jeu à résoudre, dans son état initial (e.g. mélangé).</param>
        /// <param name="finalState">Etat final à atteindre.</param>
        /// <param name="reportProgress">Action optionnelle prennant un <see cref="Solution.ProgressReportObject"/>
        /// en paramètre, tennant à jours de l'avencement de la résolution.</param>
        /// <returns></returns>
        Solution Solve(Game game, int[,] finalState, Action<Solution.ProgressReportObject> reportProgress=null);

    }

    public class Solution
    {

        /// <summary>
        /// "Structure" comprenant un compte rendu de l'état de la résolution avec : une grille
        /// représentant l'état de jeu (à voir selon l'algorithme), le nombre d'états visité et le nombre d'état
        /// prévus d'être visité.
        /// </summary>
        public class ProgressReportObject
        {

            public int[,] state;
            public int nbOpened;
            public int nbClosed;

            public ProgressReportObject(int[,] state, int nbOpened, int nbClosed)
            {
                this.state = state;
                this.nbOpened = nbOpened;
                this.nbClosed = nbClosed;
            }

        }

        /// <summary>
        /// Structure comprenant l'état du jeux ainsi que le mouvement y mennant
        /// (depuis l'état précedent dans <see cref="Solution.Steps"/>).
        /// </summary>
        public struct Step
        {

            public int[,] grid;
            public int[] move;

            public Step(int[,] grid, int[] move)
            {
                this.grid = grid;
                this.move = move;
            }

            public override String ToString()
            {
                if (this.move == null)
                    return "Etat initial";
                int i1 = this.move[0], j1 = this.move[1];
                int i2 = this.move[2], j2 = this.move[3];
                return $"({i1}, {j1}) -> ({i2}, {j2})";
            }

        }

        /// <summary>
        /// Liste des étapes à suivre pour suivre la solution. Voir aussi : <seealso cref="Solution.Step"/>.
        /// </summary>
        public List<Step> Steps { get; private set; }

        private Solution()
        {
            this.Steps = new List<Step>();
        }

        private Solution(params List<Step>[] manySteps) : this()
        {
            this.Steps.Add(manySteps[0][0]); // TODO: FIXME: le premier état avec SolveEtapes n'a pas la bonne grille.?

            foreach (var steps in manySteps)
                foreach (var step in steps)
                    if (step.move != null)
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
        /// Retourne les mouvements sous un format utilisable par <see cref="Game.MakeMoves(int[][])"/>.
        /// </summary>
        /// <returns>int[nb de mouvements][4]</returns>
        public int[][] GetMoves()
        {
            int[][] r = new int[this.Steps.Count][];

            for (int k = 0; k < r.Length; k++)
                r[k] = this.Steps[k].move;

            return r;
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
        public static Solution BuildPathFrom(Graph g, bool reversed=false)
        {
            Solution r = new Solution();
            Node current = g.GetFinal();

            while (current != null)
            {
                r.Steps.Add(new Step(current.ToGrid(), current.MoveFromParent));
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
        public static Solution operator+(Solution a, Solution b)
        {
            if (a == null)
                return b.Steps.Count == 0 ? null : new Solution(b.Steps);
            if (b == null)
                return a.Steps.Count == 0 ? null : new Solution(a.Steps);
            return new Solution(a.Steps, b.Steps);
        }

    }
}
