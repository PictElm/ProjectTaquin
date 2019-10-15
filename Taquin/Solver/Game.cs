using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class Game
    {

        private int[,] grid;
        private int size;
        private int gapCount;

        public Game(int size, int gapCount)
        {
            this.grid = new int[size, size];
            this.size = size;
            this.gapCount = gapCount;

            int k = 1;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    this.grid[i, j] = k <= size * size - gapCount ? k++ : 0;
        }

        public int this[int i, int j]
        {
            get { return this.grid[i, j]; }
        }

        public bool MakeMove(int i1, int j1, int i2, int j2)
        {
            if (this.grid[i2, j2] != 0 || this.grid[i1, j1] == 0 || 1 < Math.Abs(i1 - i2) + Math.Abs(j1 - j2))
                return false;

            this.grid[i2, j2] = this.grid[i1, j1];
            this.grid[i1, j1] = 0;
            return true;
        }

        // FIXME: out of ranges
        public void Shuffle(Random rng, int moveCount)
        {
            while (0 < --moveCount)
            {
                int i1 = rng.Next(0, this.size);
                int j1 = rng.Next(0, this.size);

                int i2 = 0, j2 = 0;
                switch (rng.Next(0, 4))
                {
                    case 0:
                        i2 = -1;
                        j2 = 0;
                        break;
                    case 1:
                        i2 = 0;
                        j2 = 1;
                        break;
                    case 2:
                        i2 = 1;
                        j2 = 0;
                        break;
                    case 3:
                        i2 = 0;
                        j2 = -1;
                        break;
                }

                this.MakeMove(i1, j1, i2, j2);
            }
        }

        internal int[,] ToGrid()
        {
            return this.grid;
        }

        internal int[,] SimulMove(int i1, int j1, int i2, int j2)
        {
            int[,] r = Game.CopyGrid(this.grid);

            r[i2, j2] = r[i1, j1];
            r[i1, j1] = 0;

            return r;
        }

        internal static int[,] SimulMove(int i1, int j1, int i2, int j2, int[,] fromGrid)
        {
            int[,] r = Game.CopyGrid(fromGrid);

            r[i2, j2] = r[i1, j1];
            r[i1, j1] = 0;

            return r;
        }

        // TODO: yep
        internal static List<int[]> NextSteps(int[,] grid)
        {
            return new List<int[]>();
        }

        internal static int[,] CopyGrid(int[,] grid)
        {
            int[,] r = new int[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    r[i, j] = grid[i, j];

            return r;
        }

    }
}
