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

        private int x = 0;
        private int y = 0;
        private int w = 0;
        private int h = 0;

        private TaquinNode saved = null;
        private TaquinNode filter = null;

        private int[,] Select(int[,] grid, int x, int y, int w, int h)
        {
            int[,] r = new int[w, h];

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    r[i, j] = grid[x + i, y + j];

            return r;
        }

        private bool IsGapIn(int[,] grid, int k, int dimStable)
        {
            if (dimStable == 1)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                    if (grid[i, k] == 0)
                        return true;
            }
            else
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[k, j] == 0)
                        return true;
            }
            return false;
        }

        protected TaquinNode Build(TaquinGame gameRef, TaquinNode targetState, int n)
        {
            int sz = gameRef.Size;

            if (this.w < 1 || this.h < 1)
            {
                this.x = this.y = 0;
                this.w = this.h = sz;
            }

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
                int[,] r1 = this.saved?.Grid ?? this.Build(gameRef, targetState, n - 1).Grid;

                if (!this.IsGapIn(targetState.Grid, x, 0))
                {
                    for (int k = y; k < y + h; k++)
                        r1[x, k] = targetState.Grid[x, k];
                    x++;
                }
                else
                {
                    for (int k = y; k < y + h; k++)
                        r1[x + w - 1, k] = targetState.Grid[x + w - 1, k];
                }
                w--;

                return new TaquinNode(r1);
            }
            else
            {
                int[,] r2 = this.saved?.Grid ?? this.Build(gameRef, targetState, n - 1).Grid;

                if (!this.IsGapIn(targetState.Grid, y, 1))
                {
                    for (int k = x; k < x + w; k++)
                        r2[k, y] = targetState.Grid[k, y];
                    y++;
                }
                else
                {
                    for (int k = x; k < x + w; k++)
                        r2[k, y + h - 1] = targetState.Grid[k, y + h - 1];
                }
                h--;

                return new TaquinNode(r2);
            }
        }

        protected override ANode<TaquinGame.Move> BuildSolutionStep(AGame<TaquinGame.Move> gameRef, ANode<TaquinGame.Move> targetState, int n)
        {
            //this.filter = this.saved ?? this.Build(gameRef as TaquinGame, targetState as TaquinNode, 0);
            this.saved = this.Build(gameRef as TaquinGame, targetState as TaquinNode, n);
            return this.saved;
        }

        protected override ANode<TaquinGame.Move> BuildFilterNode(AGame<TaquinGame.Move> gameRef, ANode<TaquinGame.Move> targetState, int n, ANode<TaquinGame.Move> currentSolutionStep)
        {
            return this.filter;
        }

        protected override int GetStepCount(AGame<TaquinGame.Move> game)
        {
            int gameSize = (game as TaquinGame).Size;
            return 2 * gameSize - 3;
        }

    }
}
