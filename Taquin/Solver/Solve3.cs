using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class Solve3 : ISolve
    {

        public Solution Solve(Game game, int[,] finalState)
        {
            Graph g = new Graph(new Node(game.ToGrid()));

            g.Opened.Add(new Node(game.ToGrid()));
            Node final = null;

            while (final == null && 0 < g.Opened.Count)
            {
                // "déplis" les nodes dans la liste des ouverts en trouvant touts les états suivant (enfants)
                List<Node> nexts = new List<Node>();

                // pour ce faire : on parcoure la liste des ouverts
                foreach (var node in g.Opened)
                {
                    // pour chaque états des ouverts, on récupère la liste des mouvements possibles
                    int[,] fromGrid = node.ToGrid();
                    var moves = Game.NextSteps(fromGrid);

                    // pour chaque mouvement possible, on :
                    foreach (var move in moves)
                    {
                        int[,] newState = Game.SimulMove(move[0], move[1], move[2], move[3], fromGrid);
                        Node newNode = null;

                        // vérifit si il s'agit d'un état déjà observé ou en cours d'observation
                        newNode = g.FindIfExist(newState);
                        // si ça n'est pas le cas, on l'ajout dans les états "dépliés"
                        if (newNode == null)
                        {
                            newNode = new Node(newState);
                            nexts.Add(newNode);
                            node.Attach(newNode, move);
                        }
                    }
                }

                // déplace tous les états d'ouverts dans fermés
                g.Closed.AddRange(g.Opened);
                g.Opened.Clear();

                // place tous les nouveaux états
                g.Opened.AddRange(nexts);

                // vérifis si on a trouvé un chemin vers l'état final
                final = g.FindIfExist(finalState);
            }
            g.Finish(final);

            return Solution.BuildPathFrom(g);
        }

    }
}
