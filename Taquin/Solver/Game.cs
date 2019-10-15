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
            for (int j = 0; j < size; j++)
                for (int i = 0; i < size; i++)
                    this.grid[i, j] = k <= size * size - gapCount ? k++ : 0;
        }

        public int this[int i, int j]
        {
            get { return this.grid[i, j]; }
        }

        public bool MakeMove(int i1, int j1, int i2, int j2)
        {
            if (this.grid[i2, j2] != 0 || this.grid[i1, j1] == 0)
                return false;

            this.grid[i2, j2] = this.grid[i1, j1];
            this.grid[i1, j1] = 0;
            return true;
        }

    }
}
