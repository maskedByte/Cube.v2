using Engine.Driver.Input;
using Engine.Math.Vector;
using Engine.OpenGL.Vendor.SFML.Window;

namespace Engine.OpenGL.Driver;

/// <summary>
/// Implementation of <see cref="IInput" /> for OpenGL
/// </summary>
public sealed class Input : IInput
{
    private readonly bool[] _keyStates = new bool[(int)Key.KeyCount];
    private readonly bool[] _keyDownStates = new bool[(int)Key.KeyCount];
    private readonly bool[] _keyUpStates = new bool[(int)Key.KeyCount];
    private readonly bool[] _mouseButtonStates = new bool[(int)MouseButton.ButtonCount];
    private readonly bool[] _mouseButtonDownStates = new bool[(int)MouseButton.ButtonCount];
    private readonly bool[] _mouseButtonUpStates = new bool[(int)MouseButton.ButtonCount];
    private Vector3 _mouseLocation = Vector3.Zero;
    private Vector2 _mouseDelta = Vector2.Zero;

    /// <inheritdoc />
    public Vector3 MouseLocation
    {
        get { return _mouseLocation; }
    }

    /// <inheritdoc />
    public Vector2 MouseDelta
    {
        get { return _mouseDelta; }
    }

    /// <inheritdoc />
    public bool GetKey(Key key)
    {
        return _keyStates[(int)key];
    }

    /// <inheritdoc />
    public bool GetKeyDown(Key key)
    {
        return _keyDownStates[(int)key];
    }

    /// <inheritdoc />
    public bool GetKeyUp(Key key)
    {
        var state = _keyUpStates[(int)key];
        _keyUpStates[(int)key] = false;

        return state;
    }

    /// <inheritdoc />
    public bool GetMouseButton(MouseButton button)
    {
        return _mouseButtonStates[(int)button];
    }

    /// <inheritdoc />
    public bool GetMouseButtonDown(MouseButton button)
    {
        return _mouseButtonDownStates[(int)button];
    }

    /// <inheritdoc />
    public bool GetMouseButtonUp(MouseButton button)
    {
        var state = _mouseButtonUpStates[(int)button];
        _mouseButtonUpStates[(int)button] = false;

        return state;
    }

    /// <inheritdoc />
    public void Reset()
    {
        var length = _keyStates.Length;
        Array.Clear(_keyStates, 0, length);
        Array.Clear(_keyUpStates, 0, length);

        length = _mouseButtonStates.Length;
        Array.Clear(_mouseButtonStates, 0, length);
        Array.Clear(_mouseButtonUpStates, 0, length);

        _mouseLocation.Z = 0f;
        _mouseDelta = Vector2.Zero;
    }

    internal void Handle(Event e)
    {
        switch (e.Type)
        {
            #region Joystick Events

            case EventType.JoystickButtonPressed:
                //    if (JoystickButtonPressed != null)
                //    {
                //        JoystickButtonPressed(this, new JoystickButtonEventArgs(e.JoystickButton));
                //    }

                break;

            case EventType.JoystickButtonReleased:
                //    if (JoystickButtonReleased != null)
                //    {
                //        JoystickButtonReleased(this, new JoystickButtonEventArgs(e.JoystickButton));
                //    }

                break;

            case EventType.JoystickMoved:
                //    if (JoystickMoved != null)
                //    {
                //        JoystickMoved(this, new JoystickMoveEventArgs(e.JoystickMove));
                //    }

                break;

            case EventType.JoystickConnected:
                //    if (JoystickConnected != null)
                //    {
                //        JoystickConnected(this, new JoystickConnectEventArgs(e.JoystickConnect));
                //    }

                break;

            case EventType.JoystickDisconnected:
                //    if (JoystickDisconnected != null)
                //    {
                //        JoystickDisconnected(this, new JoystickConnectEventArgs(e.JoystickConnect));
                //    }

                break;

            #endregion

            #region Keyboard Events

            case EventType.KeyPressed:
                if (e.Key.Code != Keyboard.Key.Unknown)
                {
                    var mapCode = (int)e.Key.Code;
                    _keyStates[mapCode] = true;
                    _keyDownStates[mapCode] = true;

                    // // Fire event
                    // var keyAction = _keyBindingResolver.Get((Key)e.Key.Code);
                    // if (keyAction != null!)
                    // {
                    //     keyAction.State = true;
                    //     InputEvent?.Invoke(this, new InputEventArgs(keyAction));
                    // }
                }

                break;

            case EventType.KeyReleased:
                if (e.Key.Code != Keyboard.Key.Unknown)
                {
                    var mapCode = (int)e.Key.Code;
                    _keyStates[mapCode] = false;
                    _keyDownStates[mapCode] = false;
                    _keyUpStates[mapCode] = true;

                    // // Fire event
                    // var keyAction = _keyBindingResolver.Get((Key)e.Key.Code);
                    // if (keyAction != null!)
                    // {
                    //     keyAction.State = false;
                    //     InputEvent?.Invoke(this, new InputEventArgs(keyAction));
                    // }
                }

                break;

            #endregion

            #region Mouse Events

            case EventType.MouseButtonPressed:
                _mouseButtonStates[(int)e.MouseButton.Button] = true;
                _mouseButtonDownStates[(int)e.MouseButton.Button] = true;

                break;

            case EventType.MouseButtonReleased:
                _mouseButtonStates[(int)e.MouseButton.Button] = false;
                _mouseButtonUpStates[(int)e.MouseButton.Button] = true;
                _mouseButtonDownStates[(int)e.MouseButton.Button] = false;

                break;

            case EventType.MouseWheelScrolled:
                _mouseLocation.Z = e.MouseWheelScroll.Delta;
                break;
            //case EventType.MouseEntered:
            //    if (MouseEntered != null)
            //    {
            //        MouseEntered(this, EventArgs.Empty);
            //    }

            //    break;

            //case EventType.MouseLeft:
            //    if (MouseLeft != null)
            //    {
            //        MouseLeft(this, EventArgs.Empty);
            //    }

            //    break;

            case EventType.MouseMoved:

                _mouseDelta.X = _mouseLocation.X - e.MouseMove.X;
                _mouseDelta.Y = _mouseLocation.Y - e.MouseMove.Y;

                _mouseLocation.X = e.MouseMove.X;
                _mouseLocation.Y = e.MouseMove.Y;

                break;

            #endregion

            #region Touch Events

            //case EventType.TouchBegan:
            //    if (TouchBegan != null)
            //    {
            //        TouchBegan(this, new TouchEventArgs(e.Touch));
            //    }

            //    break;

            //case EventType.TouchMoved:
            //    if (TouchMoved != null)
            //    {
            //        TouchMoved(this, new TouchEventArgs(e.Touch));
            //    }

            //    break;

            //case EventType.TouchEnded:
            //    if (TouchEnded != null)
            //    {
            //        TouchEnded(this, new TouchEventArgs(e.Touch));
            //    }

            //    break;

            #endregion
        }
    }
}
