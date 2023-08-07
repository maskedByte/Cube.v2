using Engine.Math.Vector;

namespace Engine.Driver.Input;

/// <summary>
/// Interface for handling user input
/// </summary>
public interface IInput
{
    /// <summary>
    /// The current mouse position in pixel coordinates.
    /// </summary>
    /// <remarks>Z field of the <see cref="Vector3" /> contains the scroll wheel delta value</remarks>
    Vector3 MouseLocation { get; }

    /// <summary>
    /// The current mouse delta positions for X & Y axis
    /// </summary>
    Vector2 MouseDelta { get; }

    /// <summary>
    /// Returns true if the user has pressed the <see cref="Key" /> identified by key.
    /// </summary>
    /// <param name="key"><see cref="Key" /> key to check</param>
    /// <returns>True if pressed, false if released</returns>
    bool GetKey(Key key);

    /// <summary>
    /// Returns true while the user holds down the <see cref="Key" /> identified by key.
    /// </summary>
    /// <param name="key"><see cref="Key" /> key to check</param>
    /// <returns>True if pressed, false if released</returns>
    bool GetKeyDown(Key key);

    /// <summary>
    /// Returns true the first frame the user releases the <see cref="Key" /> identified by key.
    /// </summary>
    /// <param name="key"><see cref="Key" /> key to check</param>
    /// <returns>True if pressed, false if released</returns>
    bool GetKeyUp(Key key);

    /// <summary>
    /// Returns whether the given <see cref="MouseButton" /> is pressed.
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    bool GetMouseButton(MouseButton button);

    /// <summary>
    /// Returns whether the given <see cref="MouseButton" /> is held down.
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    bool GetMouseButtonDown(MouseButton button);

    /// <summary>
    /// Returns true during the frame the user releases the given <see cref="MouseButton" />.
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    bool GetMouseButtonUp(MouseButton button);

    /// <summary>
    /// Reset all key states
    /// </summary>
    void Reset();
}
