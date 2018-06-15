namespace WaterPipes
{
    public class Style
    {
        internal char Cursor { get; set; } = 'X' ;

        internal char Empty { get; set; } = ' ';

        internal char WaterSource { get; set; } = 'S';

        internal char WillBeFilled { get; set; } = '*';

        internal char EmptyPipe { get; set; } = 'O'; //english O

        internal char FilledPipe { get; set; } = 'О'; //Russian O

        internal char Border { get; set; } = '+';    
    }
}