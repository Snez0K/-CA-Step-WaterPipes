﻿using System;

namespace WaterPipes.Command
{
    internal class SpaceCommand : ICommand
    {
        private Map map = new Map();

        public SpaceCommand(Map map)
        {
            this.map = map;
        }

        public bool CanExecute(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.Spacebar;
        }

        public void Execute()
        {
            map.Start = true;
        }
    }
}