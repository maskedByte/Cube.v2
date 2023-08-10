using Engine.Core.Driver;
using SFML.System;

namespace Engine.OpenGL.Driver;

public sealed class Time : ITime
{
    private static readonly Clock Clock = new();
    private static float oldTimeSinceStart;
    private static int nextFps;
    private static float fpsTimer;
    private static int fps;

    public static Time Instance { get; } = new();

    /// <summary>
    ///     Return DeltaTime
    /// </summary>
    public float DeltaTime { get; private set; }

    /// <summary>
    ///     Return actual FPS
    /// </summary>
    public float FramesPerSecond => fps;

    /// <summary>
    ///     Return time since start
    /// </summary>
    public float Millisecs { get; private set; } = Clock.ElapsedTime.AsMilliseconds();

    static Time()
    {
    }

    private Time()
    {
    }

    /// <summary>
    ///     Update Time
    /// </summary>
    public void Update()
    {
        Millisecs = Clock.ElapsedTime.AsMilliseconds();
        DeltaTime = (Millisecs - oldTimeSinceStart) / 1000f;
        oldTimeSinceStart = Millisecs;
        nextFps++;

        if (Millisecs - fpsTimer > 1000f)
        {
            fps = nextFps;
            fpsTimer = Millisecs;
            nextFps = 0;
        }
    }
}
