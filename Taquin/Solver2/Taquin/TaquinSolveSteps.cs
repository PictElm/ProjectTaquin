using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver2.Graph;

namespace Solver2.Taquin
{
    public class TaquinSolveSteps : Solve.Method.ASolveSteps<TaquinGame.Move>
    {

        protected override ANode<TaquinGame.Move> BuildSolutionStep(AGame<TaquinGame.Move> gameRef, ANode<TaquinGame.Move> targetState, int n)
        {
            int sz = (gameRef as TaquinGame).Size;

            if (n == 0)
            {
                int[,] r = new int[sz, sz];
                for (int i = 0; i < sz; i++)
                    for (int j = 0; j < sz; j++)
                        r[i, j] = -1;
                return new TaquinNode(r);
            }
            else if (n == 2 * sz - 3) return targetState;

            if (n % 2 == 1)
            {
                int[,] r1 = (this.BuildSolutionStep(gameRef, targetState, n - 1) as TaquinNode).Grid;
                n /= 2;

                for (int k = 0; k < sz; k++)
                    r1[n, k] = (targetState as TaquinNode).Grid[n, k];

                return new TaquinNode(r1);
            }

            int[,] r2 = (this.BuildSolutionStep(gameRef, targetState, n - 1) as TaquinNode).Grid;
            n /= 2;

            for (int k = 0; k < sz; k++)
                r2[k, n - 1] = (targetState as TaquinNode).Grid[k, n - 1];

            return new TaquinNode(r2);
        }

        protected override ANode<TaquinGame.Move> BuildFilterNode(AGame<TaquinGame.Move> gameRef, ANode<TaquinGame.Move> targetState, int n, ANode<TaquinGame.Move> currentSolutionStep)
        {
            return this.BuildSolutionStep(gameRef, targetState, n - 1);
        }

        protected override int GetStepCount(AGame<TaquinGame.Move> game)
        {
            int gameSize = (game as TaquinGame).Size;
            return 2 * gameSize - 3;
        }

    }
}
