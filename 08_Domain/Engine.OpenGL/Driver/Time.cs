using Engine.Core.Driver;
using SFML.System;

namespace Engine.OpenGL.Driver;

public sealed class Time : ITime
{
    private readonly Clock _clock;
    private float _oldTimeSinceStart;
    private int _nextFps;
    private float _fpsTimer;
    private int _fps;
    private float _millisecs;

    /// <summary>
    ///     Return DeltaTime
    /// </summary>
    public float DeltaTime { get; private set; }

    /// <summary>
    ///     Return actual FPS
    /// </summary>
    public float FramesPerSecond => _fps;

    /// <summary>
    ///     Return time since start
    /// </summary>
    public float Millisecs
    {
        get => _clock.ElapsedTime.AsMilliseconds();
        private set => _millisecs = value;
    }

    /// <summary>
    ///     Default parameterless constructor.
    /// </summary>
    public Time()
    {
        _clock = new Clock();
    }

    /// <summary>
    ///     Update Time
    /// </summary>
    public void Update()
    {
        DeltaTime = (Millisecs - _oldTimeSinceStart) / 1000f;
        _oldTimeSinceStart = Millisecs;
        _nextFps++;

        if (Millisecs - _fpsTimer > 1000f)
        {
            _fps = _nextFps;
            _fpsTimer = Millisecs;
            _nextFps = 0;
        }
    }
}
