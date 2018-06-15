using System;

namespace WaterPipes.Command
{
    internal class EnterCommand : ICommand
    {
        private Style style = new Style();
        private Map map;
        private Cursor cursor;

        public EnterCommand(Cursor cursor, Map map)
        {
            this.cursor = cursor;
            this.map = map;
        }

        public bool CanExecute(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.Enter;
        }

        public void Execute()
        {
            if (map.Field[cursor.Y - 1, cursor.X - 1] == style.Empty || map.Field[cursor.Y - 1, cursor.X - 1] == style.WaterSource)
            {
                map.Field[cursor.Y - 1, cursor.X - 1] = style.EmptyPipe;
            }
            else
            {
                map.Field[cursor.Y - 1, cursor.X - 1] = style.Empty;
            }
        }
    }
}