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

        private int[] _centerPos;
        private int[] GetCenterPos(int[,] destGrid)
        {
            if (this._centerPos == null)
            {
                for (int i = 0; i < destGrid.GetLength(0); i++)
                    for (int j = 0; j < destGrid.GetLength(1); j++)
                        if (destGrid[i, j] == 0)
                        {
                            this._centerPos = new int[2] { i, j };
                            return this._centerPos;
                        }
            }
            return this._centerPos;
        }

        private void Set(ref int[,] grid, int i, int j, int[,] src)
        {
            int[] cPos = this.GetCenterPos(src);
            i = (i - 1 + cPos[0]) % grid.GetLength(0);
            j = (j - 1 + cPos[1]) % grid.GetLength(1);
            grid[i, j] = src[i, j];
        }

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
                    this.Set(ref r1, n, k, (targetState as TaquinNode).Grid); //r1[n, k] = (targetState as TaquinNode).Grid[n, k];

                return new TaquinNode(r1);
            }

            int[,] r2 = (this.BuildSolutionStep(gameRef, targetState, n - 1) as TaquinNode).Grid;
            n /= 2;

            for (int k = 0; k < sz; k++)
                this.Set(ref r2, k, n - 1, (targetState as TaquinNode).Grid); //r2[k, n - 1] = (targetState as TaquinNode).Grid[k, n - 1];

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
