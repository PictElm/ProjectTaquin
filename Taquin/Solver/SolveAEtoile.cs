using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class SolveAEtoile : ISolve
    {

        private Graph g;

        public Solution Solve(Game game, int[,] finalState, Action<int[,]> reportProgress)
        {
            this.g = new Graph(new Node(game.ToGrid()));

            String finalNodeTestString = new Node(finalState).ToString();

            // Le noeud passé en paramètre est supposé être le noeud initial
            Node N = new Node(game.ToGrid());
            this.g.Opened.Add(N);

            int k = 0;
            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (this.g.Opened.Count != 0 && N.ToString() != finalNodeTestString)
            {
                //if (k++ % 100 == 0)
                    reportProgress.Invoke(N.ToGrid());

                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                this.g.Opened.Remove(N);
                this.g.Closed.Add(N);

                // Il faut trouver les noeuds successeurs de N
                this.UpdateSuccessors(N, finalState);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (this.g.Opened.Count > 0)
                {
                    N = this.g.Opened[0];
                }
                else
                {
                    N = null;
                }
            }

            g.Finish(N);
            return Solution.BuildPathFrom(this.g);
        }

        public void UpdateSuccessors(Node N, int[,] finalState)
        {
            // On fait appel à GetListSucc, méthode abstraite qu'on doit réécrire pour chaque
            // problème. Elle doit retourner la liste complète des noeuds successeurs de N.
            List<int[]> listsucc = Game.NextSteps(N.ToGrid());
            foreach (int[] move in listsucc)
            {
                Node N2 = new Node(Game.SimulMove(move[0], move[1], move[2], move[3], N.ToGrid()));
                // N2 est-il une copie d'un nœud déjà vu et placé dans la liste des fermés ?
                Node N2bis = g.FindIfExistInClosed(N2);
                if (N2bis == null)
                {
                    // Rien dans les fermés. Est-il dans les ouverts ?
                    N2bis = g.FindIfExistInOpened(N2);
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
                            N.Attach(N2bis, move);

                            // Mise à jour des ouverts
                            g.Opened.Remove(N2bis);
                            this.InsertNewNodeInOpenList(N2bis);
                        }
                        // else on ne fait rien, car le nouveau chemin est moins bon
                    }
                    else
                    {
                        // N2 est nouveau, MAJ et insertion dans les ouverts
                        //N2.Parent = N;
                        N.Attach(N2, move);

                        N2.GCost = N.GCost + 1;
                        N2.HCost = Game.Heuristics(N2.ToGrid(), finalState);

                        //TODO[?]: mettre HCost à jour ici
                        this.InsertNewNodeInOpenList(N2);
                    }
                    
                    // Insertion pour respecter l'ordre du cout total le plus petit au plus grand
                }
                // else il est dans les fermés donc on ne fait rien,
                // car on a déjà trouvé le plus court chemin pour aller en N2
            }
        }

        public void InsertNewNodeInOpenList(Node newNode)
        {
            // Insertion pour respecter l'ordre du cout total le plus petit au plus grand
            if (this.g.Opened.Count == 0)
            {
                this.g.Opened.Add(newNode);
            }
            else
            {
                Node N = this.g.Opened[0];
                bool trouve = false;
                int i = 0;
                do
                {
                    if (newNode.TotalCost < N.TotalCost)
                    {
                        this.g.Opened.Insert(i, newNode);
                        trouve = true;
                    }
                    else
                    {
                        i++;
                        if (this.g.Opened.Count == i)
                        {
                            N = null;
                            this.g.Opened.Insert(i, newNode);
                        }
                        else
                        {
                            N = this.g.Opened[i];
                        }
                    }
                } while ((N != null) && (trouve == false));
            }
        }


    }
}
