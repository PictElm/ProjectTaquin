using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2.Solve.Method
{
    public class SolveAEtoile<T_Move> : ISolve<T_Move>
    {

        private Graph.Graph<T_Move> graph;
        private AGame<T_Move> game;

        public Solution<T_Move> Solve(AGame<T_Move> game, Graph.INode<T_Move> finalState)
        {
            this.graph = new Graph.Graph<T_Move>(game.State);
            this.game = game; //as AGame<Graph.INode<T_Move>, T_Move>;

            // Le noeud passé en paramètre est supposé être le noeud initial
            var N = game.State;
            this.graph.Opened.Add(N);
            
            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (this.graph.Opened.Count != 0 && !finalState.SameAs(N))
            {
                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                this.graph.Opened.Remove(N);
                this.graph.Closed.Add(N);

                // Il faut trouver les noeuds successeurs de N
                this.UpdateSuccessors(N, finalState);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (this.graph.Opened.Count > 0)
                {
                    N = this.graph.Opened[0];
                }
                else
                {
                    N = null;
                }
            }

            this.graph.Finish(N);
            return Solution<T_Move>.BuildPathFrom(this.graph);
        }


        public void UpdateSuccessors(Graph.INode<T_Move> N, Graph.INode<T_Move> finalState)
        {
            // On fait appel à GetListSucc, méthode abstraite qu'on doit réécrire pour chaque
            // problème. Elle doit retourner la liste complète des noeuds successeurs de N.
            //List<int[]> listsucc = Game.NextSteps(N.ToGrid());
            foreach (var N2 in this.game.NextNodes(N))
            {
                //INode<T_Move> N2 = new INode<T_Move>(Game.SimulMove(move[0], move[1], move[2], move[3], N.ToGrid()));
                //INode<T_Move> N2 = N.Next(move);

                // N2 est-il une copie d'un nœud déjà vu et placé dans la liste des fermés ?
                var N2bis = graph.FindIfExistInClosed(N2);
                if (N2bis == null)
                {
                    // Rien dans les fermés. Est-il dans les ouverts ?
                    N2bis = graph.FindIfExistInOpened(N2);
                    if (N2bis != null)
                    {
                        // Il existe, donc on l'a déjà vu, N2 n'est qu'une copie de N2Bis
                        // Le nouveau chemin passant par N est-il meilleur ?
                        if (N.GCost + 1 < N2bis.GCost)
                        {
                            // Mise à jour de N2bis
                            N2bis.GCost = N.GCost + 1;
                            // HCost pas recalculé car toujours bon

                            // Mise à jour de la famille ....
                            //N2bis.Parent = N;
                            N.Attach(N2bis, N2.MoveFromParent);

                            // Mise à jour des ouverts
                            graph.Opened.Remove(N2bis);
                            this.InsertNewNodeInOpenList(N2bis);
                        }
                        // else on ne fait rien, car le nouveau chemin est moins bon
                    }
                    else
                    {
                        // N2 est nouveau, MAJ et insertion dans les ouverts
                        //N2.Parent = N;
                        N.Attach(N2, N2.MoveFromParent);

                        N2.GCost = N.GCost + 1;
                        N2.HCost = N2.Heuristics(finalState);

                        //TODO[?]: mettre HCost à jour ici
                        this.InsertNewNodeInOpenList(N2);
                    }

                    // Insertion pour respecter l'ordre du cout total le plus petit au plus grand
                }
                // else il est dans les fermés donc on ne fait rien,
                // car on a déjà trouvé le plus court chemin pour aller en N2
            }
        }

        public void InsertNewNodeInOpenList(Graph.INode<T_Move> newNode)
        {
            // Insertion pour respecter l'ordre du cout total le plus petit au plus grand
            if (this.graph.Opened.Count == 0)
            {
                this.graph.Opened.Add(newNode);
            }
            else
            {
                var N = this.graph.Opened[0];
                bool trouve = false;
                int i = 0;
                do
                {
                    if (newNode.TotalCost < N.TotalCost)
                    {
                        this.graph.Opened.Insert(i, newNode);
                        trouve = true;
                    }
                    else
                    {
                        i++;
                        if (this.graph.Opened.Count == i)
                        {
                            N = null;
                            this.graph.Opened.Insert(i, newNode);
                        }
                        else
                        {
                            N = this.graph.Opened[i];
                        }
                    }
                } while ((N != null) && (trouve == false));
            }
        }

    }
}
