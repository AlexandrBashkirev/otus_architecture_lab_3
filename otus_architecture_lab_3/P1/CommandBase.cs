﻿using System;


namespace P1
{
    public abstract class CommandBase : ICommand
    {
        #region Variables

        protected Action<bool, object> callback = null;

        #endregion


        #region Methods

        public abstract void Run();


        public void SetResultCallback(Action<bool, object> callback)
        {
            this.callback = callback;
        }

        #endregion
    }
}
