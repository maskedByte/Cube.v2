namespace Engine.Core.Driver.Api.Shaders;

/// <summary>
/// Enumeration of different types of shaders.
/// </summary>
public enum ShaderSourceType
{
    /// <summary>
    /// Fragment (pixel) shader. Responsible for determining the color of each pixel on the screen.
    /// </summary>
    Fragment = 0,

    /// <summary>
    /// Vertex shader. Responsible for transforming the 3D vertices of a model into the 2D space of the screen.
    /// </summary>
    Vertex,

    /// <summary>
    /// Geometry shader. Responsible for generating new geometry from the input vertices.
    /// This can be used for creating effects such as billboarding, particle systems, and more.
    /// </summary>
    Geometry,

    /// <summary>
    /// Tesselation control shader. Responsible for controlling the level of detail of a mesh by
    /// dividing the surface into smaller sub-triangles.
    /// </summary>
    TessControl,

    /// <summary>
    /// Tesselation evaluation shader. Responsible for evaluating the position of the vertices created
    /// by the tesselation control shader.
    /// </summary>
    TessEvaluation,

    /// <summary>
    /// Compute shader. Responsible for performing general purpose calculations on the GPU.
    /// This can be used for tasks such as physics simulations, image processing, and more.
    /// </summary>
    Compute
}
