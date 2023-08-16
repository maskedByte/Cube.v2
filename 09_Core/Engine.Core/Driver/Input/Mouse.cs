using Engine.Core.Logging;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Core.Driver.Input;

/// <summary>
///     Static Mouse input class
/// </summary>
public static class Mouse
{
    private static IInput? input;

    /// <summary>
    ///     Gets the mouse current x position on screen
    /// </summary>
    public static int MouseX()
    {
        if (input != null)
        {
            return (int)input.MouseLocation.X;
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Gets the mouse current y position on screen
    /// </summary>
    public static int MouseY()
    {
        if (input != null)
        {
            return (int)input.MouseLocation.Y;
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Gets the mouse scroll wheel delta changes
    /// </summary>
    public static int MouseZ()
    {
        if (input != null)
        {
            return (int)input.MouseLocation.Z;
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Get the movement delta for the mouse x axis
    /// </summary>
    public static int MouseXDelta()
    {
        if (input != null)
        {
            return (int)input.MouseDelta.X;
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Get the movement delta for the mouse y axis
    /// </summary>
    public static int MouseYDelta()
    {
        if (input != null)
        {
            return (int)input.MouseDelta.Y;
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Checks if a mouse button was hit
    /// </summary>
    /// <param name="buttons">
    ///     <see cref="MouseButtonHit" />
    /// </param>
    /// <returns>True if the button was hit, false if not</returns>
    public static bool MouseButtonHit(MouseButtons buttons)
    {
        if (input != null)
        {
            return input.GetMouseButton(buttons);
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Checks if a mouse button was hit
    /// </summary>
    /// <param name="buttons">
    ///     <see cref="MouseButtonDown" />
    /// </param>
    /// <returns>True if the button was hit, false if not</returns>
    public static bool MouseButtonDown(MouseButtons buttons)
    {
        if (input != null)
        {
            return input.GetMouseButtonDown(buttons);
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Checks if a mouse button was released
    /// </summary>
    /// <param name="buttons">
    ///     <see cref="MouseButtonDown" />
    /// </param>
    /// <returns>True if the button was released, false if not</returns>
    public static bool MouseButtonUp(MouseButtons buttons)
    {
        if (input != null)
        {
            return input.GetMouseButtonUp(buttons);
        }

        Log.LogMessageAsync("Mouse input not set", LogLevel.Error, typeof(Mouse));
        return default;
    }

    /// <summary>
    ///     Set the active input system
    /// </summary>
    /// <param name="inputHandler">The input system to use</param>
    public static void SetInput(IInput inputHandler) => input = inputHandler;
}
