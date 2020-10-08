using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;


namespace P2
{
    public class MatrixSumCommand : CommandBase
    {
        #region Variables

        private const string AdaptyProgramName = "P1.exe";

        private const string AdaptyMatrixAKey = "-fa";
        private const string AdaptyMatrixBKey = "-fb";
        private const string AdaptyResultMatrixKey = "-fr";
        
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
        }

        #endregion



        #region Methods

        public override void Run()
        {
            string matrixAPath = "matrixA.txt";
            string matrixBPath = "matrixB.txt";

            string matrixResultPath = "result.txt";

            new MatrixWriterTextFile(matrixAPath).Write(matrixA);
            new MatrixWriterTextFile(matrixBPath).Write(matrixB);

            string args = $"{AdaptyMatrixAKey} {matrixAPath} {AdaptyMatrixBKey} {matrixBPath} {AdaptyResultMatrixKey} {matrixResultPath}";

            int error = -1;

            try
            {
                error = RunProcessAsync(AdaptyProgramName, args).GetAwaiter().GetResult();
            }catch
            { }

            File.Delete(matrixAPath);
            File.Delete(matrixBPath);

            if (error == 0)
            {
                Matrix result = new MatrixReaderTextFile(matrixResultPath).Read();
                callback?.Invoke(true, result);
            }
            else
            {
                callback?.Invoke(false, null);
            }
            
            File.Delete(matrixResultPath);
        }


        Task<int> RunProcessAsync(string fileName, string arguments)
        {
            var tcs = new TaskCompletionSource<int>();

            var process = new Process
            {
                StartInfo = {
                    FileName = fileName,
                    Arguments = arguments},
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                process.Dispose();
            };

            process.Start();

            return tcs.Task;
        }

        #endregion

    }
}
