namespace Solver
{
    public class SolveEtapesTest3 : ASolveEtapes
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

            if (n == 0)
            {
                int[,] r = new int[sz, sz];
                for (int i = 0; i < sz; i++)
                    for (int j = 0; j < sz; j++)
                        r[i, j] = -1;
                return r;
            }
            else if (n == 2 * sz - 3) return targetState;

            if (n % 2 == 1)
            {
                int[,] r1 = this.BuildSolutionStep(targetState, n - 1);
                n /= 2;

                for (int k = 0; k < sz; k++)
                    r1[n, k] = targetState[n, k];

                return r1;
            }

            int[,] r2 = this.BuildSolutionStep(targetState, n - 1);
            n /= 2;

            for (int k = 0; k < sz; k++)
                r2[k, n - 1] = targetState[k, n - 1];

            return r2;
        }

    }
}
