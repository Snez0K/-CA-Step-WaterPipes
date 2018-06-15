namespace WaterPipes
{
    public class UpdateGameRules
    {
        private Style style = new Style();

        internal bool Working { get; set; } = false;

        public char[,] PreUpdate(char[,] map, int yLine, int xLine)
        {
            Working = false;
            for (int i = 1; i < yLine - 1; i++)
            {
                for (int j = 1; j < xLine - 1; j++)
                {
                    if (map[i, j] == style.WaterSource || map[i, j] == style.FilledPipe)
                    {
                        if (i - 1 > 1 && j > 1)
                        {
                            if (map[i - 1, j] == style.EmptyPipe)
                            {
                                map[i - 1, j] = style.WillBeFilled;
                                Working = true;
                            }
                        }
                        if (i + 1 < yLine && j < xLine)
                        {
                            if (map[i + 1, j] == style.EmptyPipe)
                            {
                                map[i + 1, j] = style.WillBeFilled;
                                Working = true;
                            }
                        }
                        if (i > 1 && j - 1 > 1)
                        {
                            if (map[i, j - 1] == style.EmptyPipe)
                            {
                                map[i, j - 1] = style.WillBeFilled;
                                Working = true;
                            }
                        }
                        if (i < yLine && j + 1 < xLine)
                        {
                            if (map[i, j + 1] == style.EmptyPipe)
                            {
                                map[i, j + 1] = style.WillBeFilled;
                                Working = true;
                            }
                        }
                    }
                }
            }
            return FinalUpdate(map, yLine, xLine);
        }

        public char[,] FinalUpdate(char[,] map, int yLine, int xLine)
        {
            for (int i = 0; i < yLine; i++)
            {
                for (int j = 0; j < xLine; j++)
                {
                    if (map[i, j] == style.WillBeFilled)
                    {
                        map[i, j] = style.FilledPipe;
                    }
                }
            }
            return map;
        }
    }
}