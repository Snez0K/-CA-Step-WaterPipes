namespace WaterPipes
{
    public class Map
    {
        internal const int Yline = 15;

        internal const int Xline = 30;

        internal char[,] Field { get; set; } = new char[Yline, Xline];

        internal bool Start = false;
    }
}