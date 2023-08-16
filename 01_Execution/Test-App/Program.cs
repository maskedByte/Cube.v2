using System.Diagnostics.CodeAnalysis;
using Engine.Assets.AssetData;
using Engine.Assets.Assets.Images;
using Engine.Assets.Assets.Shaders;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Driver.Input;
using Engine.Framework.Rendering.Shapes;
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

    [SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
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
        var triangle = new TriangleMesh(context);

        var image = new ImageAsset();
        image.LoadAsset($"{BasePath}textures/grid_blue.cda");

        var texture = context.CreateTexture(TextureBufferTarget.Texture2D, image.Data);

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

        CommandGroup cmdGroup = new()
        {
            new BindShaderProgramCommand(shaderProgram),
            new BindTextureCommand(texture, TextureUnit.DiffuseColor),
            new BindBufferArrayCommand(triangle.BufferArray),
            primitiveTypeCommands[currentSetPrimitiveType],
            new SetIndexCountCommand(triangle.IndexCount),
            new RenderElementCommand()
        };

        var commandQueue = new CommandQueue();
        commandQueue.Enqueue(cmdGroup);

        var commandHandler = new CommandHandler();

        // commandHandler.AddRule(command => command is not BindTextureCommand);

        var renderer = new DefaultRenderer(context, commandQueue, commandHandler);

        while (!window.WindowTerminated())
        {
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
                cmdGroup.Replace(primitiveTypeCommands[oldSetPrimitiveType], primitiveTypeCommands[currentSetPrimitiveType]);
                oldSetPrimitiveType = currentSetPrimitiveType;
            }

            // Prepare next frame
            cmdGroup.Reset();
            commandQueue.Enqueue(cmdGroup);
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
