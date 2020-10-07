using System;


namespace P2
{
    public interface ICommand
    {
        void SetResultCallback(Action<bool, object> callback);
        void Run();
    }
}
