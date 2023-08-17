using Engine.Assets.AssetData;
using Engine.Assets.Assets.Images;
using Engine.Assets.Assets.Shaders;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Driver.Input;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;
using Engine.Framework.Rendering.Shapes;
using Engine.Framework.Systems.Cameras;
using Engine.OpenGL.Driver;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.RenderCommands;
using Engine.Rendering.Commands.ShaderCommands;
using Engine.Rendering.Commands.TextureCommands;
using Engine.Rendering.Renderers;
using SysColor = System.Drawing.Color;

namespace Test_App;

public class TestApp
{
    private const string BasePath = "./base/";

    public static void Main()
    {
        // Asset compilation
        var assetCompiler = new AssetDataCompiler();
        assetCompiler.RegisterFileConverter(new ImageAssetConverter());
        assetCompiler.RegisterFileConverter(new ShaderAssetConverter());
        assetCompiler.Compile(BasePath, null, true);

        // Create simple OpenGl window
        IDriver driver = new OpenGlDriver();
        var window = driver.CreateWindow(1280, 1024, false);
        var context = driver.GetContext() ?? throw new ArgumentNullException(nameof(IContext));

        context.SetClearColor(SysColor.Gray);

        var shaderProgram = LoadShader(context);
        var triangle = new QuadMesh(context);
        var triangleTransform = new Transform();
        triangleTransform.Scale = new Vector3(512, 512, 1);
        triangleTransform.Position = new Vector3(0, 0, 0);

        var image = new ImageAsset();
        image.LoadAsset($"{BasePath}textures/grid_blue.cda");

        var texture = context.CreateTexture(TextureBufferTarget.Texture2D, image.Data);

        var camera = new Camera(driver.GetWindow());
        camera.SetClipPlane(0.001f, 1000);

        var cameraUniformBuffer = context.CreateUniformBuffer(
            "Matrices",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "m_ViewMatrix", ShaderDataType.Matrix4),
                    new BufferElement(1, "m_ProjectionMatrix", ShaderDataType.Matrix4)
                }
            ),
            0
        );
        cameraUniformBuffer.Attach(shaderProgram);

        var modelUniformBuffer = context.CreateUniformBuffer(
            "Model",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "m_ModelMatrix", ShaderDataType.Matrix4)

                    // new BufferElement(1,"v_MaterialColor", ShaderDataType.Vector4),
                    // new BufferElement(2,"v_DefaultColor", ShaderDataType.Vector4)
                }
            ),
            1
        );
        modelUniformBuffer.Attach(shaderProgram);

        var oldSetPrimitiveType = 0;
        var currentSetPrimitiveType = 0;

        var primitiveTypeCommands = new ICommand[]
        {
            new SetPrimitiveTypeCommand(PrimitiveType.Triangles),
            new SetPrimitiveTypeCommand(PrimitiveType.TriangleStrip),
            new SetPrimitiveTypeCommand(PrimitiveType.TriangleFan),
            new SetPrimitiveTypeCommand(PrimitiveType.Lines),
            new SetPrimitiveTypeCommand(PrimitiveType.LineStrip),
            new SetPrimitiveTypeCommand(PrimitiveType.LineLoop),
            new SetPrimitiveTypeCommand(PrimitiveType.Points)
        };

        var triangleCommands = new CommandGroup
        {
            new BindShaderProgramCommand(shaderProgram),
            new BindUniformBufferCommand(modelUniformBuffer),
            new SetUniformBufferValueCommand<Matrix4>("m_ModelMatrix", triangleTransform.Transformation),
            new BindTextureCommand(texture, TextureUnit.DiffuseColor),
            new BindBufferArrayCommand(triangle.BufferArray),
            primitiveTypeCommands[currentSetPrimitiveType],
            new SetIndexCountCommand(triangle.IndexCount),
            new RenderElementCommand()
        };

        var perspectiveUpdateCommands = new CommandGroup
        {
            new SetUniformValueCommand<Matrix4>("m_ViewMatrix", camera.ViewMatrix),
            new SetUniformValueCommand<Matrix4>("m_ProjectionMatrix", camera.GetProjection(ProjectionMode.Perspective))
        };

        var commandQueue = new CommandQueue();
        commandQueue.Enqueue(triangleCommands);

        var commandHandler = new CommandHandler();

        var renderer = new DefaultRenderer(context, commandQueue, commandHandler);

        while (!window.WindowTerminated())
        {
            // Prepare frame
            cameraUniformBuffer.SetUniformData("m_ViewMatrix", camera.Transform.Transformation);
            cameraUniformBuffer.SetUniformData("m_ProjectionMatrix", camera.GetProjection(ProjectionMode.Orthographic));

            // Render frame
            driver.Clear();
            driver.HandleEvents();

            renderer.Render();
            driver.Swap();

            // Keyboard input
            if (Keyboard.GetKey(KeyCode.Escape))
            {
                window.Terminate();
            }

            if (Keyboard.GetKey(KeyCode.Q))
            {
                currentSetPrimitiveType++;
                currentSetPrimitiveType %= primitiveTypeCommands.Length - 1;
                triangleCommands.Replace(primitiveTypeCommands[oldSetPrimitiveType], primitiveTypeCommands[currentSetPrimitiveType]);
                oldSetPrimitiveType = currentSetPrimitiveType;
            }

            // Prepare next frame
            triangleCommands.Reset();
            commandQueue.Enqueue(triangleCommands);
        }

        shaderProgram.Dispose();
        triangle.BufferArray.Dispose();

        driver.Close();
    }

    private static IShaderProgram LoadShader(IContext context)
    {
        var shaderAsset = new ShaderAsset();
        shaderAsset.LoadAsset($"{BasePath}shader/default.cda");

        var vShader = context.CreateShader(
            ShaderSourceType.Vertex,
            shaderAsset.Data[ShaderAssetType.Vertex]
        );

        var fShader = context.CreateShader(
            ShaderSourceType.Fragment,
            shaderAsset.Data[ShaderAssetType.Fragment]
        );

        var shaderProgram = context.CreateShaderProgram();
        shaderProgram.AddShader(vShader);
        shaderProgram.AddShader(fShader);
        shaderProgram.Compile();

        return shaderProgram;
    }
}
