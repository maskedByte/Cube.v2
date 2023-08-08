using System.Drawing;
using Engine.Driver;
using Engine.Driver.Api.Shaders;
using Engine.Driver.Input;
using Engine.OpenGL.Driver;

public class TestApp
{
    public static void Main(string[] args)
    {
        // Create simple OpenGl window
        IDriver driver = new OpenGlDriver();
        var window = driver.CreateWindow(800, 600, false);
        var api = driver.GetApi();

        var shader = api.CreateShader(ShaderSourceType.Vertex, new[]
        {
            "#version 330 core\n" +
            "layout (location = 0) in vec3 aPos;\n" +
            "void main()\n" +
            "{\n" +
            "   gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);\n" +
            "}\0"
        });

        var shaderProgram = api.CreateShaderProgram();
        shaderProgram.AddShader(shader);
        shaderProgram.Compile();


        // var bufferArrayObject = api.CreateBufferArray();
        //
        // // Vertex buffer data
        // var bufferLayout = new BufferLayout();
        // bufferLayout.AddElement(new BufferElement("a_Position", ShaderDataType.Vector4));
        // bufferLayout.AddElement(new BufferElement("a_Color", ShaderDataType.Vector4));

        // var vbo = api.CreateBuffer(bufferLayout);
        // vbo.SetData(Vertices);
        //
        // bufferArrayObject.AddBuffer(vbo, BufferType.Vertex);
        //
        // // UV Buffer - 2
        // bufferLayout = new BufferLayout();
        // bufferLayout.AddElement(new BufferElement("a_TexCoord", ShaderDataType.Vector2));
        //
        // var uvBuffer = api.CreateBuffer(bufferLayout);
        // uvBuffer.SetData(UvCoordinates);
        //
        // BufferArray.AddBuffer(uvBuffer, BufferType.Uv);
        //
        // // Normal Buffer - 3
        // bufferLayout = new BufferLayout();
        // bufferLayout.AddElement(new BufferElement("a_Normal", ShaderDataType.Vector3));
        //
        // var nbo = api.CreateBuffer(bufferLayout);
        // nbo.SetData(Normals);
        //
        // BufferArray.AddBuffer(nbo, BufferType.Normal);
        //
        // // Index Buffer
        // bufferLayout = new BufferLayout();
        // bufferLayout.AddElement(new BufferElement("indices", ShaderDataType.Int));
        //
        // var ibo = api.CreateBuffer(bufferLayout, true);
        // ibo.SetData(Indices);
        //
        // BufferArray.AddBuffer(ibo, BufferType.Index);
        //
        // BufferArray.Build();


        driver.SetClearColor(Color.Coral);

        while (!window.WindowTerminated())
        {
            driver.Clear();
            driver.HandleEvents();

            if (Keyboard.GetKey(KeyCode.Escape))
            {
                window.Terminate();
            }

            // driver.DrawIndexed(BufferArray, DrawMode.Triangles, BufferArray.Indices.lenght);

            driver.Swap();
        }

        driver.Close();
    }
}
