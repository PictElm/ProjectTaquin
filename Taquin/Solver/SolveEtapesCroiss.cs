namespace Solver
{
    public class SolveEtapesCroiss : ASolveEtapes
    {

        protected override int[] StepSizeSlices(int gameSize)
        {
            int[] r = new int[gameSize / 2 + 1];
            for (int k = 0; k < r.Length; k++)
                r[k] = k == 0 ? gameSize : (k * gameSize);
            return r;
        }

    }
}
