using System;
using System.Collections.Generic;
using Solver2.Graph;

namespace Solver2.Taquin
{
    public class TaquinGame : AGame<TaquinGame.Move>
    {

        public struct Move
        {

            public int i1, j1;
            public int i2, j2;

            public int[] From
            {
                get { return new int[2] { this.i1, this.j1 }; }
                set
                {
                    this.i1 = value[0];
                    this.j1 = value[1];
                }
            }

            public int[] To
            {
                get { return new int[2] { this.i1, this.j1 }; }
                set
                {
                    this.i1 = value[0];
                    this.j1 = value[1];
                }
            }

            public Move(params int[] ij1_ij2)
            {
                this.i1 = ij1_ij2[0];
                this.j1 = ij1_ij2[1];
                this.i2 = ij1_ij2[2];
                this.j2 = ij1_ij2[3];
            }

        }

        public override ANode<Move> State
        {
            get { return new TaquinNode(this.Grid); }
            set { this.Grid = (value as TaquinNode).Grid; }
        }

        private int[,] _grid;
        public int[,] Grid
        {
            get { return this._grid; }
            set
            {
                this._grid = new int[this.Size, this.Size];
                for (int i = 0; i < this.Size; i++)
                    for (int j = 0; j < this.Size; j++)
                        this._grid[i, j] = value[i, j];
            }
        }
        
        private int _size;
        public int Size
        {
            get { return this._size; }
            set
            {
                this._size = value;
                this.Grid = SortedGrid(value, this.Gaps);
            }
        }
        public int Gaps { get; set; }

        public TaquinGame(int size, int gaps)
        {
            this.Gaps = gaps;
            this.Size = size;
        }

        public static int[,] SortedGrid(int size, int gaps)
        {
            int[,] r = new int[size, size];

            for (int i = 0, k = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    r[i, j] = k < size * size - gaps ? ++k : 0;

            return r;
        }

        public override List<ANode<Move>> NextNodes(ANode<Move> from, Func<ANode<Move>, bool> filter = null)
        {
            var r = new List<ANode<Move>>();
            var grid = (from as TaquinNode).Grid;

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
            // pour chaque espace vide, on regarde tout ses voisins
            foreach (var p in zeros)
            {
                int i2 = p[0], j2 = p[1];

                foreach (var d in adjacents)
                {
                    int i1 = i2 - d[0], j1 = j2 - d[1];
                    // on garde tous les mouvement valides
                    if (-1 < i1 && i1 < this.Size && -1 < j1 && j1 < this.Size
                        && -1 < i2 && i2 < this.Size && -1 < j2 && j2 < this.Size
                        && grid[i1, j1] != 0)
                    {
                        var newGrid = new int[grid.GetLength(0), grid.GetLength(1)];
                        for (int i = 0; i < grid.GetLength(0); i++)
                            for (int j = 0; j < grid.GetLength(1); j++)
                                newGrid[i, j] = grid[i, j];

                        newGrid[i2, j2] = newGrid[i1, j1];
                        newGrid[i1, j1] = 0;

                        TaquinNode n = new TaquinNode(newGrid, new TaquinGame.Move(i1, j1, i2, j2));
                        if (filter == null || filter(n))
                            r.Add(n);
                    }
                }
            }
            
            return r;
        }

        public void Shuffle(Random rng, int moveCount)
        {
            // liste les coordonées des espaces vides
            int[][] zeros = new int[this.Gaps][];
            int k = 0;
            for (int i = 0; i < this.Size; i++)
                for (int j = 0; j < this.Size; j++)
                    if (this.Grid[i, j] == 0)
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
                int random = rng.Next(this.Gaps);
                int[] gap = zeros[random];

                int i1, j1, i2 = gap[0], j2 = gap[1];
                // trouve une direction depuis laquel déplacer une case non vide
                do
                {
                    int direction = rng.Next(0, 4);
                    i1 = i2 - moves[direction][0];
                    j1 = j2 - moves[direction][1];
                } while (!this.MakeMove(new TaquinGame.Move(i1, j1, i2, j2)));

                // maj du nouvel emplacement de l'espace vide
                zeros[random] = new int[2] { i1, j1 };
            }
        }

        public override bool MakeMove(Move move)
        {
            int i1 = move.i1, j1 = move.j1, i2 = move.i2, j2 = move.j2;

            if (-1 < i1 && i1 < this.Size && -1 < j1 && j1 < this.Size
                && -1 < i2 && i2 < this.Size && -1 < j2 && j2 < this.Size
                && this.Grid[i1, j1] != 0 && this.Grid[i2, j2] == 0
                && Math.Abs(i1 - i2) + Math.Abs(j1 - j2) == 1)
            {
                this.Grid[i2, j2] = this.Grid[i1, j1];
                this.Grid[i1, j1] = 0;
                return true;
            }
            return false;
        }

    }
}
