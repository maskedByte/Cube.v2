using Engine.Core.Logging;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Core.Driver.Input;

/// <summary>
/// Static Keyboard input class
/// </summary>
public static class Keyboard
{
    private static IInput? input;

    /// <summary>
    /// Check if a key was pressed once
    /// </summary>
    /// <param name="keyCode">
    ///     <see cref="KeyCode" />
    /// </param>
    /// <returns>true if the key was pressed false if not.</returns>
    public static bool GetKey(KeyCode keyCode)
    {
        if (input != null)
        {
            return input.GetKey(keyCode);
        }

        Log.LogMessageAsync("Keyboard input not set", LogLevel.Error, typeof(Keyboard));
        return default;
    }

    /// <summary>
    /// Check if a <see cref="keyCode" /> is pressed and hold down.
    /// </summary>
    /// <param name="keyCode">
    ///     <see cref="KeyCode" />
    /// </param>
    /// <returns>true as long the <see cref="keyCode" /> is hold down</returns>
    public static bool GetKeyDown(KeyCode keyCode)
    {
        if (input != null)
        {
            return input.GetKeyDown(keyCode);
        }

        Log.LogMessageAsync("Keyboard input not set", LogLevel.Error, typeof(Keyboard));
        return default;
    }

    /// <summary>
    /// Check if a key was released.
    /// </summary>
    /// <param name="keyCode">
    ///     <see cref="KeyCode" />
    /// </param>
    /// <returns>true during the frame the user releases the key</returns>
    public static bool GetKeyUp(KeyCode keyCode)
    {
        if (input != null)
        {
            return input.GetKeyUp(keyCode);
        }

        Log.LogMessageAsync("Keyboard input not set", LogLevel.Error, typeof(Keyboard));
        return default;
    }

    /// <summary>
    /// Set the active input system
    /// </summary>
    /// <param name="inputHandler">The input system to use</param>
    public static void SetInput(IInput inputHandler)
    {
        input = inputHandler;
    }
}
