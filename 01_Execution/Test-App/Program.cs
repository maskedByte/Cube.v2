using System.Drawing;
using Engine.Assets.AssetData;
using Engine.Assets.AssetData.ImageAsset;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Driver.Input;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;
using Engine.OpenGL.Driver;

namespace Test_App;

public class TestApp
{
    public static string BasePath = "./base/";

    public static void Main()
    {
        // Create simple OpenGl window
        IDriver driver = new OpenGlDriver();
        var window = driver.CreateWindow(1280, 1024, false);
        var api = driver.GetApi();

        driver.SetClearColor(Color.Gray);

        var shaderProgram = LoadShader(api);
        var triangle = CreateTriangle(api);

        var assetCompiler = new AssetDataCompiler();
        assetCompiler.RegisterFileConverter(new ImageAssetConverter());
        assetCompiler.CompileAsync(BasePath, null, true);

        var image = new ImageAsset();
        image.LoadAsset($"{BasePath}textures/grid_blue.cda");

        var texture = api.CreateTexture(TextureBufferTarget.Texture2D, image.Data);

        while (!window.WindowTerminated())
        {
            driver.Clear();
            driver.HandleEvents();

            if (Keyboard.GetKey(KeyCode.Escape))
            {
                window.Terminate();
            }

            texture.Bind(0);
            shaderProgram.Bind();
            driver.DrawIndexed(triangle, DrawMode.Triangles, 6);

            driver.Swap();
        }

        shaderProgram.Dispose();
        triangle.Dispose();

        driver.Close();
    }

    private static IShaderProgram LoadShader(IGraphicsApi api)
    {
        var vShader = api.CreateShader(
            ShaderSourceType.Vertex,
            File.ReadAllText("vertex.glsl")
        );

        var fShader = api.CreateShader(
            ShaderSourceType.Fragment,
            File.ReadAllText("fragment.glsl")
        );

        var shaderProgram = api.CreateShaderProgram();
        shaderProgram.AddShader(vShader);
        shaderProgram.AddShader(fShader);
        shaderProgram.Compile();

        return shaderProgram;
    }

    private static IBufferArray CreateTriangle(IGraphicsApi api)
    {
        var vertices = new[]
        {
            new Vertex(new Vector3(0f, 0f, 0f), Color.White),
            new Vertex(new Vector3(1f, 0f, 0f), Color.White),
            new Vertex(new Vector3(1f, 1f, 0f), Color.White),
            new Vertex(new Vector3(0f, 1f, 0f), Color.White)
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
