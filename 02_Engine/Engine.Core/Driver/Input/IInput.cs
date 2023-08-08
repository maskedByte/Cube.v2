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
    /// Returns true if the user has pressed the <see cref="KeyCode" /> identified by key.
    /// </summary>
    /// <param name="keyCode"><see cref="KeyCode" /> key to check</param>
    /// <returns>True if pressed, false if released</returns>
    bool GetKey(KeyCode keyCode);

    /// <summary>
    /// Returns true while the user holds down the <see cref="KeyCode" /> identified by key.
    /// </summary>
    /// <param name="keyCode"><see cref="KeyCode" /> key to check</param>
    /// <returns>True if pressed, false if released</returns>
    bool GetKeyDown(KeyCode keyCode);

    /// <summary>
    /// Returns true the first frame the user releases the <see cref="KeyCode" /> identified by key.
    /// </summary>
    /// <param name="keyCode"><see cref="KeyCode" /> key to check</param>
    /// <returns>True if pressed, false if released</returns>
    bool GetKeyUp(KeyCode keyCode);

    /// <summary>
    /// Returns whether the given <see cref="MouseButtons" /> is pressed.
    /// </summary>
    /// <param name="buttons"></param>
    /// <returns></returns>
    bool GetMouseButton(MouseButtons buttons);

    /// <summary>
    /// Returns whether the given <see cref="MouseButtons" /> is held down.
    /// </summary>
    /// <param name="buttons"></param>
    /// <returns></returns>
    bool GetMouseButtonDown(MouseButtons buttons);

    /// <summary>
    /// Returns true during the frame the user releases the given <see cref="MouseButtons" />.
    /// </summary>
    /// <param name="buttons"></param>
    /// <returns></returns>
    bool GetMouseButtonUp(MouseButtons buttons);

    /// <summary>
    /// Reset all key states
    /// </summary>
    void Reset();
}
