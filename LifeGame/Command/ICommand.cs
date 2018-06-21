using System;

namespace WaterPipes.Command
{
    internal interface ICommand
    {
        bool CanExecute(ConsoleKeyInfo key);

        void Execute();
    }
}