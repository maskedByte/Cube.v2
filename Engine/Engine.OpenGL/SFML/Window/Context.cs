using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using SFML.System;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Engine.OpenGL.SFML.Window;

//////////////////////////////////////////////////////////////////
/// <summary>
/// This class defines a .NET interface to an SFML OpenGL Context
/// </summary>
//////////////////////////////////////////////////////////////////
[SuppressMessage("Interoperability", "SYSLIB1054:Verwenden Sie \\\"LibraryImportAttribute\\\" anstelle von \\\"DllImportAttribute\\\", um P/Invoke-Marshallingcode zur Kompilierzeit zu generieren.")]
public class Context : CriticalFinalizerObject
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default constructor
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Context()
    {
        _myThis = sfContext_create();
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Finalizer
    /// </summary>
    ////////////////////////////////////////////////////////////
    ~Context()
    {
        sfContext_destroy(_myThis);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Activate or deactivate the context
    /// </summary>
    /// <param name="active">True to activate, false to deactivate</param>
    /// <returns>true on success, false on failure</returns>
    ////////////////////////////////////////////////////////////
    public bool SetActive(bool active)
    {
        return sfContext_setActive(_myThis, active);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the settings of the context.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public ContextSettings Settings
    {
        get { return sfContext_getSettings(_myThis); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Global helper context
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static Context Global
    {
        get { return ourGlobalContext ??= new Context(); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Provide a string describing the object
    /// </summary>
    /// <returns>String description of the object</returns>
    ////////////////////////////////////////////////////////////
    public override string ToString()
    {
        return "[Context]";
    }

    private static Context? ourGlobalContext;

    private readonly IntPtr _myThis;

    #region Imports
    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    static extern IntPtr sfContext_create();

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    static extern void sfContext_destroy(IntPtr view);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    static extern bool sfContext_setActive(IntPtr view, bool active);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    static extern ContextSettings sfContext_getSettings(IntPtr view);
    #endregion
}
