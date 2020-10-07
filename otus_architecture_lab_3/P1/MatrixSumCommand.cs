using System;


namespace P1
{
    class MatrixSumCommand : CommandBase
    {
        #region Variables

        Matrix result = null;
        Matrix matrixA = null;
        Matrix matrixB = null;

        #endregion



        #region Class lifecycle

        public MatrixSumCommand(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.Columns != matrixB.Columns ||
                matrixA.Rows != matrixB.Rows)
            {
                throw new Exception("Can't sum matrix");
            }

            this.matrixA = matrixA;
            this.matrixB = matrixB;

            result = new Matrix(matrixA.Rows, matrixA.Columns);
        }

        #endregion



        #region Methods

        public override void Run()
        {
            for (int row = 0; row < result.Rows; row++)
            {
                for (int column = 0; column < result.Columns; column++)
                {
                    result[row, column] = matrixA[row, column] + matrixB[row, column];
                }
            }

            callback?.Invoke(true, result);
        }

        #endregion
    }
}
