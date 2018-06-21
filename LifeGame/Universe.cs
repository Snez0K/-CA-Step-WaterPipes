using System;
using System.Collections.Generic;
using WaterPipes.Command;

namespace WaterPipes
{
    public class Universe
    {
        internal int Timer { get; set; } = 0;
        private Map map = new Map();
        private Cursor cursor = new Cursor();
        private Style style = new Style();
        private List<char[,]> turns = new List<char[,]>();
        private UpdateGameRules сheckUpdate = new UpdateGameRules();
        public bool end = false;

        public void EmptyMapGenerate()
        {
            for (int i = 0; i < Map.Yline; i++)
            {
                for (int j = 0; j < Map.Xline; j++)
                {
                    map.Field[i, j] = style.Empty;
                }
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Map.Yline; i++)
            {
                Console.Write(style.Border);
                for (int j = 0; j < Map.Xline; j++)
                {
                    if (i == 0 || i == Map.Yline - 1)
                    {
                        Console.Write(style.Border);
                    }
                    else
                    {
                        if (map.Field[i, j] == style.EmptyPipe)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (map.Field[i, j] == style.WaterSource)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (map.Field[i, j] == style.FilledPipe)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write("{0}", map.Field[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.Write(style.Border);
                Console.WriteLine();
            }
        }

        public void Pregame()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            CommandFactory factory = new CommandFactory(cursor, map);
            IEnumerable<ICommand> commandList = factory.CommandFiller() ;        
            do
            {  
                Console.Write("Step: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Timer);
                Console.ForegroundColor = ConsoleColor.Gray;
                Show();
                Console.SetCursorPosition(cursor.X, cursor.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(style.Cursor);
                Console.ForegroundColor = ConsoleColor.Gray;
                key = Console.ReadKey(true);
                foreach (ICommand command in commandList)
                {
                    if (command.CanExecute(key))
                    {
                        command.Execute();
                    }
                }
                Console.Clear();
            } while (!map.start);
        }

        public void Update()
        {
            map.Field = сheckUpdate.PreUpdate(map.Field, Map.Yline, Map.Xline);
            char[,] cloneMap = new char[Map.Yline, Map.Xline];
            for (int i = 0; i < Map.Yline; i++)
            {
                for (int j = 0; j < Map.Xline; j++)
                {
                    cloneMap[i, j] = map.Field[i, j];
                }
            }
            if (!сheckUpdate.Working)
            {
                end = true;
                Timer--;
            }
            Timer++;
            turns.Add(cloneMap);
        }
    } 
}