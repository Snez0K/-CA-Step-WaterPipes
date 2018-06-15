using System;

namespace WaterPipes.Command
{
    internal interface ICommand
    {
        void Execute();

        bool CanExecute(ConsoleKeyInfo key);
    }
}