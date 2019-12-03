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
        private readonly int size;
        private int gapCount;

        /// <summary>
        /// Créé un jeu de taquin (carré) dans son état initialement trié, avec le nombre de case(s) vide(s) précisé.
        /// </summary>
        /// <param name="size">Taille du jeu de taquin.</param>
        /// <param name="gapCount"></param>
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

        public Game(int[,] gridFrom)
        {
            this.size = gridFrom.GetLength(0);
            this.grid = new int[this.size, this.size];

            this.LoadGrid(gridFrom);
        }

        public Game(Game copy) : this(copy.grid)
        {
        }

        /// <summary>
        /// Retourne la valeur sur la case dans la grille du jeu.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int this[int i, int j]
        {
            get { return this.grid[i, j]; }
        }
        
        /// <summary>
        /// Retourne <code>true</code> si toutes les valeures dans <paramref name="list"/>
        /// sont comprises entre 0 (inclusif) et la taille du jeu (exclusif).
        /// </summary>
        /// <param name="size">Taille du jeu.</param>
        /// <param name="list">Lise des valeurs à tester.</param>
        /// <returns></returns>
        public static bool AreIn(int size, params int[] list)
        {
            foreach (int k in list)
                if (k < 0 || size - 1 < k)
                    return false;
            return true;
        }

        /// <summary>
        /// Applique le mouvement, s'il est valide, déplaçant la case de (<paramref name="i1"/>, <paramref name="j1"/>)
        /// en (<paramref name="i2"/>, <paramref name="j2"/>). Le coup est valide si toutes les coordonnées en paramètre
        /// sont dans le jeu (<see cref="Game.AreIn(int, int[])"/>), la case déplacée est non vide (non nulle),
        /// la case d'arrivée lui est adjacente et cette case d'arrivée est vide (contient un 0). Retourne <code>true</code>
        /// si le coup à été joué, <code>false</code> sinon.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="j1"></param>
        /// <param name="i2"></param>
        /// <param name="j2"></param>
        /// <returns></returns>
        public bool MakeMove(int i1, int j1, int i2, int j2)
        {
            if (!Game.AreIn(this.size, i1, j1, i2, j2) || this.grid[i2, j2] != 0 || this.grid[i1, j1] == 0 || Math.Abs(i1 - i2) + Math.Abs(j1 - j2) != 1)
                return false;
            
            this.grid[i2, j2] = this.grid[i1, j1];
            this.grid[i1, j1] = 0;
            return true;
        }

        /// <summary>
        /// Applique la suite de mouvements en utilisant <see cref="Game.MakeMove(int, int, int, int)"/> pour chaque
        /// élements de <paramref name="moves"/>. Retourn le nombre de mouvements qui on pus être effectué.
        /// </summary>
        /// <param name="moves">int[nb de mouvements][4]</param>
        /// <returns></returns>
        public int MakeMoves(int[][] moves)
        {
            if (moves.Length == 0) return 0;

            int k = 0;
            while ((moves[k] == null || this.MakeMove(moves[k][0], moves[k][1], moves[k][2], moves[k][3])) && k++ < moves.Length - 1)
                ;
            return k;
        }

        /// <summary>
        /// Réinitialise le jeu dans son état initial (trié).
        /// </summary>
        public void Reset()
        {
            int k = 1;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    this.grid[i, j] = k <= size * size - gapCount ? k++ : 0;
        }
        
        /// <summary>
        /// Mélange le jeu en effectuant <paramref name="moveCount"/> mouvements aléatoire.
        /// Tous les nombre aléatoires nécessaires sont tiré depuis <paramref name="rng"/>.
        /// </summary>
        /// <param name="rng">Générateur de nombre aléatoires.</param>
        /// <param name="moveCount">Nombre de coups à effectuer.</param>
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

        /// <summary>
        /// Place instantanément le jeu dans l'état donné. Met a jours le nombre de cases vides.
        /// </summary>
        /// <param name="grid"></param>
        public void LoadGrid(int[,] grid)
        {
            if (this.grid.GetLength(0) != grid.GetLength(0) || this.grid.GetLength(1) != grid.GetLength(1))
                return;

            this.grid = Game.CopyGrid(grid);

            this.gapCount = 0;
            for (int i = 0; i < this.grid.GetLength(0); i++)
                for (int j = 0; j < this.grid.GetLength(1); j++)
                    if (this.grid[0, 0] == 0)
                        this.gapCount++;
        }

        /// <summary>
        /// Retourn le jeu sous form de <see cref="int[,]"/>.
        /// </summary>
        /// <returns></returns>
        public int[,] ToGrid()
        {
            //return this.grid;
            return Game.CopyGrid(this.grid);
        }
        
        public int GetSize()
        {
            return this.size;
        }

        /// <summary>
        /// Retourn le nombre de cases vides.
        /// </summary>
        /// <returns></returns>
        public int CountGaps()
        {
            return this.gapCount;
        }

        /// <summary>
        /// Retourn l'état du jeu après simulation du mouvement précisé depuis la grille actuelle.
        /// La simulation n'applique pas les tests de <see cref="Game.MakeMove(int, int, int, int)"/> pour des raisons d'efficacité.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="j1"></param>
        /// <param name="i2"></param>
        /// <param name="j2"></param>
        /// <returns></returns>
        internal int[,] SimulMove(int i1, int j1, int i2, int j2)
        {
            return Game.SimulMove(i1, j1, i2, j2, this.grid);
        }

        /// <summary>
        /// Retourn l'état du jeu après simulation du mouvement précisé depuis la grille donnée.
        /// La simulation n'applique pas les tests de <see cref="Game.MakeMove(int, int, int, int)"/> pour des raisons d'efficacité.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="j1"></param>
        /// <param name="i2"></param>
        /// <param name="j2"></param>
        /// <param name="fromGrid"></param>
        /// <returns></returns>
        internal static int[,] SimulMove(int i1, int j1, int i2, int j2, int[,] fromGrid)
        {
            int[,] r = Game.CopyGrid(fromGrid);

            r[i2, j2] = r[i1, j1];
            r[i1, j1] = 0;

            return r;
        }
        
        /// <summary>
        /// Retourn une <see cref="List{T}"/> conteannt les mouvements possible depuis l'état de jeu donné.
        /// Chaque mouvement est une lise de 4 entier indiquant la case de départ et la case d'arrivée.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
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
                int i2 = p[0], j2 = p[1];

                foreach (var d in adjacents)
                {
                    int i1 = i2 - d[0], j1 = j2 - d[1];
                    // on garde tous les mouvement valides
                    if (Game.AreIn(grid.GetLength(0), i1, j1) && grid[i1, j1] != 0)
                        r.Add(new int[4] { i1, j1, i2, j2 });
                }
            }

            return r;
        }

        /// <summary>
        /// Retourn une heuristique approprié pour évaluer le nombre de mouvement restant depuis l'état
        /// <paramref name="fromState"/> jusqu'a l'état <paramref name="toState"/>.
        /// </summary>
        /// <param name="fromState"></param>
        /// <param name="toState"></param>
        /// <returns></returns>
        internal static int Heuristics(int[,] fromState, int[,] toState)
        {
            return Game.Heuristics_CountDifferences(fromState, toState);
        }

        /// <summary>
        /// Nombre de différences entre les deux états.
        /// </summary>
        internal static int Heuristics_CountDifferences(int[,] fromState, int[,] toState)
        {
            int r = 0;

            for (int i = 0; i < fromState.GetLength(0); i++)
                for (int j = 0; j < fromState.GetLength(1); j++)
                    if (fromState[i, j] != toState[i, j])
                        r++;

            return r;
        }

        /// <summary>
        /// Somme des distances de Manhattan de chaque case à sa destination.
        /// </summary>
        internal static int Heuristics_DistanceManhattan(int[,] fromState, int[,] toState)
        {
            int r = 0;

            // détermine là où les cases deveraient être
            int[][] supposed = new int[fromState.GetLength(0) * fromState.GetLength(1)][];
            for (int k = 0; k < supposed.Length; k++)
                supposed[k] = new int[2] { k % fromState.GetLength(0), k / fromState.GetLength(1) };

            // calcule la distance de Manhattan pour chaque
            for (int i = 0; i < fromState.GetLength(0); i++)
                for (int j = 0; j < fromState.GetLength(1); j++)
                {
                    int here = fromState[i, j];
                    int[] pos = supposed[here];
                    r += Math.Abs(pos[0] - i) + Math.Abs(pos[1] - j);
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
