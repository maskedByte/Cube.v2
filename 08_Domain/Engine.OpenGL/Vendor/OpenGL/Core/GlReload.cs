using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Engine.OpenGL.Vendor.OpenGL.Core;

internal partial class Gl
{
    #region Constructor

    static Gl()
    {
        DelegatesClass = typeof(global::OpenGL.Gl.Delegates);
        CoreClass = typeof(NativeMethods);
        // 'Touch' Imports class to force initialization. We don't want anything yet, just to have
        // this class ready.
        if (Core.FunctionMap != null)
        {
        }

        ReloadFunctions();
    }

    #endregion

    #region public static void ReloadFunctions()

    /// <summary>
    /// Loads all OpenGL functions (core and extensions).
    /// </summary>
    /// <remarks>
    ///     <para>
    /// This function will be automatically called the first time you use any opengl function.
    ///     </para>
    ///     <para>
    /// Call this function manually whenever you need to update OpenGL entry points.
    /// This need may arise if you change the pixelformat/visual, or in case you cannot
    /// (or do not want) to use the automatic initialization of the GL class.
    ///     </para>
    /// </remarks>
    public static void ReloadFunctions()
    {
        // Using reflection is more than 3 times faster than directly loading delegates on the first
        // run, probably due to code generation overhead. Subsequent runs are faster with direct loading
        // than with reflection, but the first time is more significant.
        delegates ??= DelegatesClass
            .GetTypeInfo()
            .DeclaredFields
            .Where(field => field.IsStatic)
            .ToArray();

        foreach (var f in delegates) f.SetValue(null, GetDelegate(f.Name, f.FieldType));
    }

    #endregion

    #region public static bool ReloadFunction(string function)

    /// <summary>
    /// Tries to reload the given OpenGL function (core or extension).
    /// </summary>
    /// <param name="function">The name of the OpenGL function (i.e. glShaderSource)</param>
    /// <returns>True if the function was found and reloaded, false otherwise.</returns>
    /// <remarks>
    ///     <para>
    /// Use this function if you require greater granularity when loading OpenGL entry points.
    ///     </para>
    ///     <para>
    /// While the automatic initialisation will load all OpenGL entry points, in some cases
    /// the initialisation can take place before an OpenGL Context has been established.
    /// In this case, use this function to load the entry points for the OpenGL functions
    /// you will need, or use ReloadFunctions() to load all available entry points.
    ///     </para>
    ///     <para>
    /// This function returns true if the given OpenGL function is supported, false otherwise.
    ///     </para>
    ///     <para>
    /// To query for supported extensions use the IsExtensionSupported() function instead.
    ///     </para>
    /// </remarks>
    public static bool Load(string function)
    {
        //FieldInfo f = delegatesClass.GetField(function, BindingFlags.Static | BindingFlags.NonPublic);
        var f = DelegatesClass
            .GetTypeInfo()
            .DeclaredFields
            .FirstOrDefault(field => field.Name == function);

        if (f == null)
            return false;

        var old = f.GetValue(null) as Delegate;
        var @new = GetDelegate(f.Name, f.FieldType);
        if (old?.Target != @new?.Target) f.SetValue(null, @new);

        return @new != null;
    }

    #endregion

    #region public static Delegate GetDelegate(string name, Type signature)

    /// <summary>
    /// Creates a System.Delegate that can be used to call an OpenGL function, core or extension.
    /// </summary>
    /// <param name="name">The name of the OpenGL function (eg. "glNewList")</param>
    /// <param name="signature">The signature of the OpenGL function.</param>
    /// <returns>
    /// A System.Delegate that can be used to call this OpenGL function, or null if the specified
    /// function name did not correspond to an OpenGL function.
    /// </returns>
    public static Delegate? GetDelegate(string name, Type signature)
    {
        if (Core.FunctionMap == null)
            return null;

        return GetExtensionDelegate(name, signature) ??
               (Core.FunctionMap.TryGetValue(name.Substring(2), out var m)
                   ? m.CreateDelegate(signature)
                   : null);
    }

    #endregion

    #region internal static Delegate GetExtensionDelegate(string name, Type signature)

    /// <summary>
    /// Creates a System.Delegate that can be used to call a dynamically exported OpenGL function.
    /// </summary>
    /// <param name="name">The name of the OpenGL function (eg. "glNewList")</param>
    /// <param name="signature">The signature of the OpenGL function.</param>
    /// <returns>
    /// A System.Delegate that can be used to call this OpenGL function or null
    /// if the function is not available in the current OpenGL context.
    /// </returns>
    internal static Delegate? GetExtensionDelegate(string name, Type signature)
    {
        var address = GetAddress(name);

        if (address == IntPtr.Zero ||
            address == new IntPtr(1) || // Workaround for buggy nvidia drivers which return
            address == new IntPtr(2)) // 1 or 2 instead of IntPtr.Zero for some extensions.
            return null;
#pragma warning disable 0618
        return Marshal.GetDelegateForFunctionPointer(address, signature);
#pragma warning restore 0618
    }

    #endregion

    #region internal static partial class Core

    /// <summary>
    /// Contains DllImports for the core OpenGL functions.
    /// </summary>
    internal static class Core
    {
        /// <summary>
        /// Build a string->MethodInfo map to speed up extension loading.
        /// </summary>
        internal static readonly SortedList<string, MethodInfo>?
            FunctionMap; // This is faster than either Dictionary or SortedDictionary

        static Core()
        {
            FunctionMap = new SortedList<string, MethodInfo>();

            foreach (var method in CoreClass.GetTypeInfo().DeclaredMethods)
                if (method.IsStatic)
                    FunctionMap.Add(method.Name, method);
        }
    }

    #endregion

    #region Fields

    //internal const string Library = "libGL.so.1";	// linux
    internal const string Library = "opengl32.dll"; // mac os x and windows

    private static readonly Type DelegatesClass;
    private static readonly Type CoreClass;
    private static FieldInfo[]? delegates;

    #endregion

    #region private static IntPtr GetAddress(string function)

    internal partial class NativeMethods
    {
        [DllImport(Library, EntryPoint = "wglGetProcAddress", ExactSpelling = true)]
        internal static extern IntPtr wglGetProcAddress(string lpszProc);

        [DllImport(Library, EntryPoint = "glXGetProcAddress")]
        internal static extern IntPtr glxGetProcAddress([MarshalAs(UnmanagedType.LPTStr)] string procName);

        [DllImport("libdl.dylib", EntryPoint = "NSIsSymbolNameDefined")]
        internal static extern bool NSIsSymbolNameDefined(string s);

        [DllImport("libdl.dylib", EntryPoint = "NSLookupAndBindSymbol")]
        internal static extern IntPtr NSLookupAndBindSymbol(string s);

        [DllImport("libdl.dylib", EntryPoint = "NSAddressOfSymbol")]
        internal static extern IntPtr NSAddressOfSymbol(IntPtr symbol);
    }

    private static IGetProcAddress? getProcAddress;

    internal interface IGetProcAddress
    {
        IntPtr GetProcAddress(string function);
    }

    internal class GetProcAddressWindows : IGetProcAddress
    {
        public IntPtr GetProcAddress(string function)
        {
            return NativeMethods.wglGetProcAddress(function);
        }
    }

    internal class GetProcAddressX11 : IGetProcAddress
    {
        public IntPtr GetProcAddress(string function)
        {
            return NativeMethods.glxGetProcAddress(function);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class GetProcAddressOSX : IGetProcAddress
    {
        public IntPtr GetProcAddress(string function)
        {
            var functionName = "_" + function;
            if (!NativeMethods.NSIsSymbolNameDefined(functionName))
                return IntPtr.Zero;

            var symbol = NativeMethods.NSLookupAndBindSymbol(functionName);
            if (symbol != IntPtr.Zero)
                symbol = NativeMethods.NSAddressOfSymbol(symbol);

            return symbol;
        }
    }

    /// <summary>
    /// Retrieves the entry point for a dynamically exported OpenGL function.
    /// </summary>
    /// <param name="function">The function string for the OpenGL function (eg. "glNewList")</param>
    /// <returns>
    /// An IntPtr contaning the address for the entry point, or IntPtr.Zero if the specified
    /// OpenGL function is not dynamically exported.
    /// </returns>
    /// <remarks>
    ///     <para>
    /// The Marshal.GetDelegateForFunctionPointer method can be used to turn the return value
    /// into a call-able delegate.
    ///     </para>
    ///     <para>
    /// This function is cross-platform. It determines the underlying platform and uses the
    /// correct wgl, glx or agl GetAddress function to retrieve the function pointer.
    ///     </para>
    ///     <see cref="Marshal.GetDelegateForFunctionPointer" />
    /// </remarks>
    public static IntPtr GetAddress(string function)
    {
        if (getProcAddress == null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                getProcAddress = new GetProcAddressWindows();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                getProcAddress = new GetProcAddressX11();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                getProcAddress = new GetProcAddressOSX();
            else
                throw new PlatformNotSupportedException(
                    "Extension loading is only supported under Mac OS X, Unix/X11 and Windows. We are sorry for the inconvience.");
        }

        return getProcAddress.GetProcAddress(function);
    }

    #endregion
}
