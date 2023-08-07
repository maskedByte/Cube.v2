namespace Engine.Exceptions;

public class TilemapModeUnsupportedException : Exception
{
    public TilemapModeUnsupportedException(string s)
        : base(s)
    {
    }
}
