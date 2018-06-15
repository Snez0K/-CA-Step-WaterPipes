using System;

namespace WaterPipes.Command
{
    internal class SCommand : ICommand
    {
        private Style style = new Style();
        private Map map;
        private Cursor cursor;

        public SCommand(Cursor cursor, Map map)
        {
            this.cursor = cursor;
            this.map = map;
        }

        public bool CanExecute(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.S;
        }

        public void Execute()
        {
            if (map.Field[cursor.Y - 1, cursor.X - 1] == style.Empty || map.Field[cursor.Y - 1, cursor.X - 1] == style.EmptyPipe)
            {
                map.Field[cursor.Y - 1, cursor.X - 1] = style.WaterSource;
            }
            else
            {
                map.Field[cursor.Y - 1, cursor.X - 1] = style.Empty;
            }
        }
    }
}