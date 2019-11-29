using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2.Taquin
{
    public class TaquinGame : AGame<TaquinNode, TaquinGame.Move>
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

        protected int[,] _grid;
        public int[,] Grid
        {
            get { return this._grid; }
            set
            {
                this._grid = value;
            }
        }

        protected int _size;
        public int Size
        {
            get { return this._size; }
            set
            {
                this._size = value;
                this.Grid = TaquinGame.SortedGrid(value);
            }
        }

        public static int[,] SortedGrid(int size)
        {
            int[,] r = new int[size, size];
            for (int k = 0; k < r.Length; k++)
                r.SetValue(k, k);
            return r;
        }

    }
}
