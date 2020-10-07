using System;


namespace P1
{
    public interface ICommand
    {
        void SetResultCallback(Action<bool, object> callback);
        void Run();
    }
}
