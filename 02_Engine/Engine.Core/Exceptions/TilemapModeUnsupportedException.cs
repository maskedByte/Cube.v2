namespace Engine.Core.Exceptions;

public class TilemapModeUnsupportedException : Exception
{
    public TilemapModeUnsupportedException(string s)
        : base(s)
    {
    }
}
