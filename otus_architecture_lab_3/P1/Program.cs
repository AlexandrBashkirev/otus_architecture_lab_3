
namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdParser cmds = new CmdParser().Init(args);

            string aPath = cmds.GetValue("-fa");
            string bPath = cmds.GetValue("-fb");
            string resultPath = cmds.GetValue("-fr");

            RunApp(aPath, bPath, resultPath);
        }


        static void RunApp(string aPath, string bPath, string resultPath)
        {
            Matrix matrixA = new MatrixReaderTextFile(aPath).Read();
            Matrix matrixB = new MatrixReaderTextFile(bPath).Read();

            MatrixSumCommand matrixMult = new MatrixSumCommand(matrixA, matrixB);
            matrixMult.SetResultCallback((isSuccess, result) =>
            {
                new MatrixWriterTextFile(resultPath).Write(result as Matrix);
            });
            matrixMult.Run();
        }
    }
}
