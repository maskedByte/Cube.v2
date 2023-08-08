using System.Drawing;
using Engine.Driver;
using Engine.Driver.Api.Buffers;
using Engine.Driver.Api.Shader;
using Engine.Driver.Input;
using Engine.OpenGL.Driver;

public class TestApp
{
    public static void Main(string[] args)
    {
        // Create simple OpenGl window
        IDriver driver = new OpenGlDriver();
        var window = driver.CreateWindow(800, 600, false, true);
        var input = driver.GetInput();
        var api = driver.GetApi();

        var bufferArrayObject = api.CreateBufferArray();

        // Vertex buffer data
        var bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement("a_Position", ShaderDataType.Vector4));
        bufferLayout.AddElement(new BufferElement("a_Color", ShaderDataType.Vector4));

        var vbo = new Buffer(bufferLayout);
        vbo.SetData(Vertices);

        bufferArrayObject.AddBuffer(vbo, BufferType.Vertex);

        // UV Buffer - 2
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement("a_TexCoord", ShaderDataType.Vector2));

        var uvBuffer = new Buffer(bufferLayout);
        uvBuffer.SetData(UvCoordinates);

        BufferArray.AddBuffer(uvBuffer, BufferType.Uv);

        // Normal Buffer - 3
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement("a_Normal", ShaderDataType.Vector3));

        var nbo = new Buffer(bufferLayout);
        nbo.SetData(Normals);

        BufferArray.AddBuffer(nbo, BufferType.Normal);

        // Index Buffer
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement("indices", ShaderDataType.Int));

        var ibo = new Buffer(bufferLayout, true);
        ibo.SetData(Indices);

        BufferArray.AddBuffer(ibo, BufferType.Index);

        BufferArray.Build();


        driver.SetClearColor(Color.Coral);

        while (!window.WindowTerminated())
        {
            driver.Clear();
            driver.HandleEvents();

            if (input.GetKey(Key.Escape))
            {
                window.Terminate();
            }

            driver.DrawIndexed(BufferArray, DrawMode.Triangles, BufferArray.Indices.lenght);

            driver.Swap();
        }

        driver.Close();
    }
}
