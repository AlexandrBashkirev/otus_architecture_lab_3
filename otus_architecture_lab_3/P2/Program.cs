using System;


namespace P2
{
    class Program
    {
        static void Main(string[] args)
        {
            IMatrixGenerator matrixGenerator = new RandomMatrixGenerator();

            Matrix matrixA = matrixGenerator.Generate(3, 3);
            Matrix matrixB = matrixGenerator.Generate(3, 3);


            MatrixSumCommand matrixMult = new MatrixSumCommand(matrixA, matrixB);
            matrixMult.SetResultCallback((isSuccess, _result) =>
            {
                Matrix result = _result as Matrix;

                for (int row = 0; row < result.Rows; row++)
                {
                    string line = "";
                    for (int column = 0; column < result.Columns; column++)
                    {
                        line += result[row, column].ToString("f1");
                        if(column < result.Columns - 1)
                        {
                            line += ", ";
                        }
                    }

                    Console.WriteLine(line);
                }
            });
            matrixMult.Run();
        }
    }
}
