using System;


namespace P2
{
    class MatrixGenerator : IMatrixGenerator
    {
        public Matrix Generate(int rows, int columns)
        {
            Random rnd = new Random();

            Matrix result = new Matrix(rows, columns);

            for(int i = 0; i < rows; i ++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = rnd.Next(-20, 20);
                }
            }

            return result;
        }
    }
}
