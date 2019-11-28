namespace Solver
{
    public class SolveEtapesTest : ASolveEtapes
    {

        protected override int[] StepSizeSlices(int gameSize)
        {
            int[] r = new int[gameSize * (gameSize - 2) + 1];
            for (int k = 0; k < r.Length; r[k++] = 1)
                ;
            r[r.Length - 1] = 2 * gameSize;
            return r;
        }

    }
}
