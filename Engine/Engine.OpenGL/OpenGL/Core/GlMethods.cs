using System.Runtime.InteropServices;
using System.Text;

namespace Engine.OpenGL.OpenGL.Core;

/// <summary>
/// Bindings to OpenGL 4.5 methods as well as some helper shortcuts.
/// </summary>
partial class Gl
{
    #region Preallocated Memory
    // pre-allocate the float[] for matrix and array data
    private static readonly float[] Float1 = new float[1];
    private static readonly double[] Double1 = new double[1];
    private static readonly uint[] Uint1 = new uint[1];
    private static readonly int[] Int1 = new int[1];
    private static readonly bool[] Bool1 = new bool[1];
    #endregion

    #region Private Fields
    private static int _version = 0;
    private static int _versionMinor = 0;

    private static StringBuilder _errorBuffer = new StringBuilder();

    #endregion

    #region Public Properties
    /// <summary>
    /// Gets the program ID of the currently active shader program.
    /// </summary>
    public static uint CurrentProgram { get; private set; } = 0;

    #endregion

    #region OpenGL Helpers (Type Safe Equivalents or Shortcuts)
    /// <summary>
    /// Return all OpenGl error for the last call to api
    /// </summary>
    /// <returns>String containing the error informations</returns>
    public static string GetErrors()
    {
        ErrorCode error = GetError();
        return error != ErrorCode.NoError ? error.ToString() : string.Empty;
    }

    /// <summary>
    /// Return all OpenGl error for the last call to api
    /// </summary>
    /// <param name="sb"><see cref="StringBuilder"/> to write errors to</param>
    public static bool GetErrors(StringBuilder sb)
    {
        ErrorCode error = GetError();
        if (error == ErrorCode.NoError)
        {
            return false;
        }

        sb.Append("\t");
        sb.Append(error.ToString());
        sb.Append("\n");

        return true;
    }

    public static void CheckError(string command)
    {
        _errorBuffer.Clear();

        if (GetErrors(_errorBuffer))
        {
            Console.WriteLine(command + "\n" + _errorBuffer);
        }
    }

    /// <summary>
    /// Select active texture unit.
    /// <para>
    /// glActiveTexture selects which texture unit subsequent texture state calls will affect. The number of
    /// texture units an implementation supports is implementation dependent, but must be at least 80.
    /// </para>
    /// </summary>
    /// <param name="texture">
    /// Specifies which texture unit to make active. The number of texture units is implementation
    /// dependent, but must be at least 80. texture must be a value between 0 and
    /// GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS minus one. The initial value is 0.
    /// </param>
    public static void ActiveTexture(int texture)
    {
#pragma warning disable CS0618
        global::OpenGL.Gl.Delegates.glActiveTexture((int)TextureUnit.Texture0 + texture);
#pragma warning restore
    }

    /// <summary>
    /// Returns the boolean value of a selected parameter.
    /// </summary>
    /// <param name="pname">A parameter that returns a single boolean.</param>
    public static bool GetBoolean(GetPName pname)
    {
        GetBooleanv(pname, Bool1);
        return Bool1[0];
    }

    /// <summary>
    /// Returns the float value of a selected parameter.
    /// </summary>
    /// <param name="pname">A parameter that returns a single float.</param>
    public static float GetFloat(GetPName pname)
    {
        GetFloatv(pname, Float1);
        return Float1[0];
    }

    /// <summary>
    /// Returns the double value of a selected parameter.
    /// </summary>
    /// <param name="pname">A parameter that returns a single double.</param>
    public static double GetDouble(GetPName pname)
    {
        GetDoublev(pname, Double1);
        return Double1[0];
    }

    /// <summary>
    /// Returns the integer value of a selected parameter.
    /// </summary>
    /// <param name="name">A parameter that returns a single integer.</param>
    public static int GetInteger(GetPName name)
    {
        GetIntegerv(name, Int1);
        return Int1[0];
    }

    /// <summary>
    /// Set a scalar texture parameter.
    /// </summary>
    /// <param name="target">Specificies the target for which the texture is bound.</param>
    /// <param name="pname">Specifies the name of a single-values texture parameter.</param>
    /// <param name="param">Specifies the value of pname.</param>
    public static void TexParameteri(TextureTarget target, TextureParameterName pname, TextureParameter param)
    {
        global::OpenGL.Gl.Delegates.glTexParameteri(target, pname, (int)param);
    }

    /// <summary>
    /// Set a vector texture parameter.
    /// </summary>
    /// <param name="target">Specificies the target for which the texture is bound.</param>
    /// <param name="pname">Specifies the name of a single-values texture parameter.</param>
    /// <param name="params"></param>
    public static void TexParameteriv(TextureTarget target, TextureParameterName pname, TextureParameter[] @params)
    {
        var iparams = new int[@params.Length];
        for (var i = 0; i < iparams.Length; i++)
        {
            iparams[i] = (int)@params[i];
        }

        global::OpenGL.Gl.Delegates.glTexParameteriv(target, pname, iparams);
    }

    /// <summary>
    /// Shortcut for quickly generating a single buffer id without creating an array to
    /// pass to the gl function.  Calls Gl.GenBuffers(1, id).
    /// </summary>
    /// <returns>The ID of the generated buffer.  0 on failure.</returns>
    public static uint GenBuffer()
    {
        Uint1[0] = 0;
        GenBuffers(1, Uint1);
        return Uint1[0];
    }

    /// <summary>
    /// Shortcut for quickly generating a single texture id without creating an array to
    /// pass to the gl function.  Calls Gl.GenTexture(1, id).
    /// </summary>
    /// <returns>The ID of the generated texture.  0 on failure.</returns>
    public static uint GenTexture()
    {
        Uint1[0] = 0;
        GenTextures(1, Uint1);
        return Uint1[0];
    }

    /// <summary>
    /// Shortcut for deleting a single texture without created an array to pass to the gl function.
    /// Calls Gl.DeleteTextures(1, id).
    /// </summary>
    /// <param name="texture">The ID of the texture to delete.</param>
    public static void DeleteTexture(uint texture)
    {
        Uint1[0] = texture;
        DeleteTextures(1, Uint1);
    }

    /// <summary>
    /// Shortcut for quickly generating a single vertex array id without creating an array to
    /// pass to the gl function.  Calls Gl.GenVertexArrays(1, id).
    /// </summary>
    /// <returns>The ID of the generated vertex array.  0 on failure.</returns>
    public static uint GenVertexArray()
    {
        Uint1[0] = 0;
        GenVertexArrays(1, Uint1);
        return Uint1[0];
    }

    /// <summary>
    /// Shortcut for deleting a single texture without created an array to pass to the gl function.
    /// Calls Gl.DeleteVertexArrays(1, id).
    /// </summary>
    /// <param name="vao">The ID of the vertex array to delete.</param>
    public static void DeleteVertexArray(uint vao)
    {
        Uint1[0] = vao;
        DeleteVertexArrays(1, Uint1);
    }

    /// <summary>
    /// Shortcut for quickly generating a single framebuffer object without creating an array
    /// to pass to the gl function.  Calls Gl.GenFramebuffers(1, id).
    /// </summary>
    /// <returns>The ID of the generated framebuffer.  0 on failure.</returns>
    public static uint GenFramebuffer()
    {
        Uint1[0] = 0;
        GenFramebuffers(1, Uint1);
        return Uint1[0];
    }

    /// <summary>
    /// Shortcut for deleting a framebuffer without created an array to pass to the gl function.
    /// Calls Gl.DeleteFramebuffers(1, id).
    /// </summary>
    /// <param name="framebuffer">The ID of the vertex array to delete.</param>
    public static void DeleteFramebuffer(uint framebuffer)
    {
        Uint1[0] = framebuffer;
        DeleteFramebuffers(1, Uint1);
    }

    /// <summary>
    /// Shortcut for quickly generating a single renderbuffer object without creating an array
    /// to pass to the gl function.  Calls Gl.GenRenderbuffers(1, id).
    /// </summary>
    /// <returns>The ID of the generated framebuffer.  0 on failure.</returns>
    public static uint GenRenderbuffer()
    {
        Uint1[0] = 0;
        GenRenderbuffers(1, Uint1);
        return Uint1[0];
    }

    /// <summary>
    /// Gets whether the shader compiled successfully.
    /// </summary>
    /// <param name="shader">The ID of the shader program.</param>
    /// <returns></returns>
    public static bool GetShaderCompileStatus(uint shader)
    {
        const int SUCCESS = 1;
        GetShaderiv(shader, ShaderParameter.CompileStatus, Int1);
        return Int1[0] == SUCCESS;
    }

    /// <summary>
    /// Get whether program linking was performed successfully.
    /// </summary>
    /// <param name="program"></param>
    /// <returns></returns>
    public static bool GetProgramLinkStatus(uint program)
    {
        const int SUCCESS = 1;
        GetProgramiv(program, ProgramParameter.LinkStatus, Int1);
        return Int1[0] == SUCCESS;
    }

    /// <summary>
    /// Gets the program info from a shader program.
    /// </summary>
    /// <param name="program">The ID of the shader program.</param>
    public static string GetProgramInfoLog(uint program)
    {
        GetProgramiv(program, ProgramParameter.InfoLogLength, Int1);
        if (Int1[0] == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder(Int1[0]);
        GetProgramInfoLog(program, sb.Capacity, Int1, sb);
        return sb.ToString();
    }

    /// <summary>
    /// Gets the program info from a shader program.
    /// </summary>
    /// <param name="shader">The ID of the shader program.</param>
    public static string GetShaderInfoLog(uint shader)
    {
        GetShaderiv(shader, ShaderParameter.InfoLogLength, Int1);
        if (Int1[0] == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder(Int1[0]);
        GetShaderInfoLog(shader, sb.Capacity, Int1, sb);
        return sb.ToString();
    }

    /// <summary>
    /// Replaces the source code in a shader object.
    /// </summary>
    /// <param name="shader">Specifies the handle of the shader object whose source code is to be replaced.</param>
    /// <param name="source">Specifies a string containing the source code to be loaded into the shader.</param>
    public static void ShaderSource(uint shader, string[] source)
    {
        Int1[0] = source[0].Length;
        ShaderSource(shader, 1, source, Int1);
    }

    /// <summary>
    /// Creates and initializes a buffer object's data store.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">Specifies the target buffer object.</param>
    /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
    /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
    /// <param name="usage">Specifies expected usage pattern of the data store.</param>
    public static void BufferData<T>(BufferTarget target, int size, [In][Out] T[] data, BufferUsageHint usage)
        where T : struct
    {
        var data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            global::OpenGL.Gl.Delegates.glBufferData(target, new IntPtr(size), data_ptr.AddrOfPinnedObject(), usage);
        }
        finally
        {
            data_ptr.Free();
            GC.Collect();
        }
    }

    /// <summary>
    /// Creates and initializes an empty buffer object's data store.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">Specifies the target buffer object.</param>
    /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
    /// <param name="usage">Specifies expected usage pattern of the data store.</param>
    public static void BufferData<T>(BufferTarget target, int size, BufferUsageHint usage)
        where T : struct
    {
        global::OpenGL.Gl.Delegates.glBufferData(target, new IntPtr(size), IntPtr.Zero, usage);
    }

    /// <summary>
    /// Creates and initializes a buffer object's data store.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">Specifies the target buffer object.</param>
    /// <param name="position">Offset into the data from which to start copying to the buffer.</param>
    /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
    /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
    /// <param name="usage">Specifies expected usage pattern of the data store.</param>
    public static void BufferData<T>(BufferTarget target, int position, int size, [In][Out] T[] data, BufferUsageHint usage)
        where T : struct
    {
        var data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            global::OpenGL.Gl.Delegates.glBufferData(target, new IntPtr(size), (IntPtr)((int)data_ptr.AddrOfPinnedObject() + position), usage);
        }
        finally
        {
            data_ptr.Free();
            GC.Collect();
        }
    }

    /// <summary>
    /// Creates a standard VBO of type T.
    /// </summary>
    /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
    /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
    /// <param name="data">The data to store in the VBO.</param>
    /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
    /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
    public static uint CreateVBO<T>(BufferTarget target, [In][Out] T[] data, BufferUsageHint hint)
        where T : struct
    {
        var vboHandle = GenBuffer();
        if (vboHandle == 0)
        {
            return 0;
        }

        var size = data.Length * Marshal.SizeOf<T>();

        BindBuffer(target, vboHandle);
        BufferData<T>(target, size, data, hint);
        BindBuffer(target, 0);
        return vboHandle;
    }

    /// <summary>
    /// Creates a standard VBO of type T where the length of the VBO is less than or equal to the length of the data.
    /// </summary>
    /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
    /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
    /// <param name="data">The data to store in the VBO.</param>
    /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
    /// <param name="length">The length of the VBO (will take the first 'length' elements from data).</param>
    /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
    public static uint CreateVBO<T>(BufferTarget target, [In][Out] T[] data, BufferUsageHint hint, int length)
        where T : struct
    {
        var vboHandle = GenBuffer();
        if (vboHandle == 0)
        {
            return 0;
        }

        var size = length * Marshal.SizeOf<T>();

        BindBuffer(target, vboHandle);
        BufferData<T>(target, size, data, hint);
        BindBuffer(target, 0);
        return vboHandle;
    }

    /// <summary>
    /// Creates a standard VBO of type T where the length of the VBO is less than or equal to the length of the data.
    /// </summary>
    /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
    /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
    /// <param name="data">The data to store in the VBO.</param>
    /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
    /// <param name="position">Starting element of the data that will be copied into the VBO.</param>
    /// <param name="length">The length of the VBO (will take the first 'length' elements from data).</param>
    /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
    public static uint CreateVBO<T>(BufferTarget target, [In][Out] T[] data, BufferUsageHint hint, int position, int length)
        where T : struct
    {
        var vboHandle = GenBuffer();
        if (vboHandle == 0)
        {
            return 0;
        }

        var offset = position * Marshal.SizeOf<T>();
        var size = length * Marshal.SizeOf<T>();

        BindBuffer(target, vboHandle);
        BufferData<T>(target, offset, size, data, hint);
        BindBuffer(target, 0);
        return vboHandle;
    }

    /// <summary>
    /// Creates a standard VBO of type T with a specified length.
    /// </summary>
    /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
    /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
    /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
    /// <param name="length">The length of the VBO.</param>
    /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
    public static uint CreateVBO<T>(BufferTarget target, BufferUsageHint hint, int length)
        where T : struct
    {
        var vboHandle = GenBuffer();
        if (vboHandle == 0)
        {
            return 0;
        }

        var size = length * Marshal.SizeOf<T>();

        BindBuffer(target, vboHandle);
        BufferData<T>(target, size, hint);
        BindBuffer(target, 0);
        return vboHandle;
    }

    /// <summary>
    /// Gets the current major OpenGL version (returns a cached result on subsequent calls).
    /// </summary>
    /// <returns>The current major OpenGL version, or 0 on an error.</returns>
    public static int Version()
    {
        if (_version != 0)
        {
            return _version; // cache the version information
        }

        try
        {
            var versionString = GetString(StringName.Version);

            _version = int.Parse(versionString.Substring(0, versionString.IndexOf('.')));
            return _version;
        }
        catch (Exception)
        {
            Console.WriteLine("Error while retrieving the OpenGL version.");
            return 0;
        }
    }

    /// <summary>
    /// Gets the current minor OpenGL version (returns a cached result on subsequent calls).
    /// </summary>
    /// <returns>The current minor OpenGL version, or -1 on an error.</returns>
    public static int VersionMinor()
    {
        if (_versionMinor != 0)
        {
            return _versionMinor; // cache the version information
        }

        try
        {
            var versionString = GetString(StringName.Version);

            _versionMinor = int.Parse(versionString.Split('.')[1]);
            return _versionMinor;
        }
        catch (Exception)
        {
            Console.WriteLine("Error while retrieving the OpenGL minor version.");
            return -1;
        }
    }

    /// <summary>
    /// Delete a single OpenGL buffer.
    /// </summary>
    /// <param name="buffer">The OpenGL buffer to delete.</param>
    public static void DeleteBuffer(uint buffer)
    {
        Uint1[0] = buffer;
        DeleteBuffers(1, Uint1);
        Uint1[0] = 0;
    }

    /// <summary>
    /// Updates a subset of the buffer object's data store.
    /// </summary>
    /// <typeparam name="T">The type of data in the data array.</typeparam>
    /// <param name="vboID">The VBO whose buffer will be updated.</param>
    /// <param name="target">Specifies the target buffer object.  Must be ArrayBuffer, ElementArrayBuffer, PixelPackBuffer or PixelUnpackBuffer.</param>
    /// <param name="data">The new data that will be copied to the data store.</param>
    /// <param name="length">The size in bytes of the data store region being replaced.</param>
    public static void BufferSubData<T>(uint vboID, BufferTarget target, T[] data, int length)
        where T : struct
    {
        var handle = GCHandle.Alloc(data, GCHandleType.Pinned);

        try
        {
            BindBuffer(target, vboID);
            BufferSubData(target, IntPtr.Zero, (IntPtr)(Marshal.SizeOf(data[0]) * length), handle.AddrOfPinnedObject());
        }
        finally
        {
            handle.Free();
            GC.Collect();
        }
    }
    #endregion
}
