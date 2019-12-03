namespace Solver
{
    public class SolveEtapesTest2 : ASolveEtapes
    {
        
        protected override int[] StepSizeSlices(int gameSize)
        {
            int[] r = new int[2 * (gameSize - 1)];
            for (int k = 0; k < r.Length; k++)
                r[k] = 1;
            return r;
        }

        protected override int[,] BuildSolutionStep(int[,] targetState, int n)
        {
            int sz = targetState.GetLength(0);
            if (n >= 2 * sz - 3) return targetState;

            if (n % 2 == 1)
            {
                n /= 2;
                int[,] r2 = this.BuildSolutionStep(targetState, 2 * n);

                r2[n, n] = targetState[n, n];
                return r2;
            }

            n /= 2;
            int[,] r = new int[sz, sz];

            for (int i = 0; i < sz; i++)
                for (int j = 0; j < sz; j++)
                {
                    if (i < n || j < n || n == sz - 1)
                        r[i, j] = targetState[i, j];
                    else
                        r[i, j] = -1;
                }

            return r;
        }

    }
}
