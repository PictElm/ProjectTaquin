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

        public bool AreIn(params int[] list)
        {
            foreach (int k in list)
                if (k < 0 || this.size - 1 < k)
                    return false;
            return true;
        }

        public bool MakeMove(int i1, int j1, int i2, int j2)
        {
            if (!this.AreIn(i1, j1, i2, j2) || this.grid[i2, j2] != 0 || this.grid[i1, j1] == 0 || Math.Abs(i1 - i2) + Math.Abs(j1 - j2) != 1)
                return false;
            
            this.grid[i2, j2] = this.grid[i1, j1];
            this.grid[i1, j1] = 0;
            return true;
        }
        
        public void Shuffle(Random rng, int moveCount)
        {
            // liste les coordonées des espaces vides
            int[][] zeros = new int[this.gapCount][];
            int k = 0;
            for (int i = 0; i < this.grid.GetLength(0); i++)
                for (int j = 0; j < this.grid.GetLength(1); j++)
                    if (this.grid[i, j] == 0)
                        zeros[k++] = new int[2] { i, j };

            // mouvements possibles depuis une case donnée
            int[][] moves = new int[4][]
            {
                new int [2] { -1, 0 },
                new int [2] { 0, 1 },
                new int [2] { 1, 0 },
                new int [2] { 0, -1 }
            };

            while (0 < moveCount--)
            {
                int random = rng.Next(this.gapCount);
                int[] gap = zeros[random];

                int i1 = 0, j1 = 0;
                int i2 = gap[0], j2 = gap[1];

                // trouve une direction depuis laquel déplacer une case non vide
                do {
                    int direction = rng.Next(0, 4);
                    i1 = i2 - moves[direction][0];
                    j1 = j2 - moves[direction][1];
                } while (!this.MakeMove(i1, j1, i2, j2));

                // maj du nouvel emplacement de l'espace vide
                zeros[random] = new int[2] { i1, j1 };
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
        
        internal static List<int[]> NextSteps(int[,] grid)
        {
            var r = new List<int[]>();

            // liste les coordonées des espaces vides
            List<int[]> zeros = new List<int[]>();
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[i, j] == 0)
                        zeros.Add(new int[2] { i, j });

            int[][] adjacents = {
                new int[2] { 1, 0 },
                new int[2] { 0, -1 },
                new int[2] { -1, 0 },
                new int[2] { 0, 1 }
            };
            // pour chaque case, on regarde tout ses voisins
            foreach (var p in zeros)
            {
                int i1 = p[0], j1 = p[1];

                foreach (var d in adjacents)
                {
                    int i2 = i1 + d[0], j2 = j1 + d[1];
                    // on garde tous les mouvement valides
                    if (grid[i2, j2] == 0 && grid[i1, j1] != 0 && Math.Abs(i1 - i2) + Math.Abs(j1 - j2) == 1)
                        r.Add(new int[4] { i1, j1, i2, j2 });
                }
            }

            return r;
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
