using System.Drawing;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Input;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;
using Engine.OpenGL.Driver;

public class TestApp
{
    public static void Main(string[] args)
    {
        // Create simple OpenGl window
        IDriver driver = new OpenGlDriver();
        var window = driver.CreateWindow(1280, 1024, false);
        var api = driver.GetApi();

        driver.SetClearColor(Color.Gray);

        var vShader = api.CreateShader(
            ShaderSourceType.Vertex,
            new[]
            {
                "#version 450 core \n",
                "layout (location = 0) in vec4 a_Position; \n",
                "layout (location = 1) in vec4 a_Color; \n",
                "layout (location = 2) in vec2 a_TexCoord; \n",
                "out vec3 v_VertexColorOut; \n",
                "void main() \n",
                "{ \n",
                "   gl_Position = aPos; \n",
                "   v_VertexColorOut = a_Color; \n",
                "} \n"
            }
        );

        var fShader = api.CreateShader(
            ShaderSourceType.Fragment,
            new[]
            {
                "#version 450 core \n",
                "out vec4 FragColor; \n",
                "in vec3 ourColor; \n",
                "void main() \n",
                "{ \n",
                "   FragColor = vec4(ourColor, 1.0f); \n",
                "} \n"
            }
        );

        var shaderProgram = api.CreateShaderProgram();
        shaderProgram.AddShader(vShader);
        shaderProgram.AddShader(fShader);
        shaderProgram.Compile();

        var triangle = CreateTriangle(api);

        while (!window.WindowTerminated())
        {
            driver.Clear();
            driver.HandleEvents();

            if (Keyboard.GetKey(KeyCode.Escape))
            {
                window.Terminate();
            }

            shaderProgram.Bind();
            driver.DrawIndexed(triangle, DrawMode.Triangles, 6);

            driver.Swap();
        }

        driver.Close();
    }

    private static IBufferArray CreateTriangle(IGraphicsApi api)
    {
        var vertices = new[]
        {
            new Vertex(new Vector3(0f, 0f, 0f), Color.White),
            new Vertex(new Vector3(0.5f, 0f, 0f), Color.White),
            new Vertex(new Vector3(0.5f, 0.5f, 0f), Color.White),
            new Vertex(new Vector3(0f, 0.5f, 0f), Color.White)
        };

        var uvCoordinates = new[]
        {
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f)
        };

        var indices = new[]
        {
            0,
            1,
            2,
            0,
            2,
            3
        };

        var bufferArrayObject = api.CreateBufferArray();

        // Vertex buffer data
        var bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement(0, "a_Position", ShaderDataType.Vector4));
        bufferLayout.AddElement(new BufferElement(1, "a_Color", ShaderDataType.Vector4));

        var vbo = api.CreateBuffer(bufferLayout);
        vbo.SetData(vertices);

        bufferArrayObject.AddBuffer(vbo, BufferType.Vertex);

        // UV Buffer - 2
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement(2, "a_TexCoord", ShaderDataType.Vector2));

        var uvBuffer = api.CreateBuffer(bufferLayout);
        uvBuffer.SetData(uvCoordinates);

        bufferArrayObject.AddBuffer(uvBuffer, BufferType.Uv);

        // Index Buffer
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement(3, "a_indices", ShaderDataType.Int));

        var ibo = api.CreateIndexBuffer(bufferLayout);
        ibo.SetData(indices);

        bufferArrayObject.AddBuffer(ibo, BufferType.Index);

        bufferArrayObject.Build();
        return bufferArrayObject;
    }
}
