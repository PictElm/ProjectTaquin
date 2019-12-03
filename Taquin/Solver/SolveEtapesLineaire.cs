namespace Solver
{
    public class SolveEtapesLineaire : ASolveEtapes
    {

        protected override int[] StepSizeSlices(int gameSize)
        {
            int[] r = new int[gameSize * gameSize];
            for (int k = 0; k < gameSize * gameSize; r[k++] = 1)
                ;
            return r;
        }

    }
}
