using Engine.Assets.AssetHandling;
using Engine.Assets.Assets.Shaders;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Input;
using Engine.Core.Math.Base;
using Engine.Core.Math.Vectors;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Framework.Rendering;
using Engine.Framework.Rendering.DataStructures;
using Engine.Framework.Rendering.Shapes;
using Engine.Framework.Rendering.Worlds;
using SysColor = System.Drawing.Color;

namespace Test_App;

public class TestApp
{
    private const string BasePath = ".\\base\\";

    public static void Main()
    {
        var core = new EngineCore(BasePath);
        core.CompileAssets(
            new AssetCompilerConfiguration
            {
                CompileExtensions = null,
                DeleteCompiledFiles = true
            }
        );

        var driver = core.CreateDriver(DriverType.OpenGl);
        var window = driver.CreateWindow($"Cube.Engine v2 - Testing - {core.ActiveDriver.GetType().Name}", 1280, 1024, false);

        var world = new World(core);
        world.AmbientLight = Color.Black;

        var mainCamera = new Entity(world);
        mainCamera.AddComponent<CameraComponent>()
           .ClearColor = SysColor.Gray;

        var cube = new Entity(world);
        cube.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(world.Context);

        cube.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_blue_material");
        cube.Transform.Scale = new Vector3(2, 2, 2);
        cube.Transform.Position = Vector3.Forward * 5f;

        // Main loop
        while (!Keyboard.GetKey(KeyCode.Escape) && !window.WindowTerminated())
        {
            world.Update();
            world.Render();
        }

        window.Close();
        driver.Close();
        world.Dispose();

        // var shaderProgram = LoadShader(context);
        // var triangle = new CubeMesh(context);
        // var triangleTransform = new Transform();
        //
        // //triangleTransform.Scale = new Vector3(512, 512, 1);
        // triangleTransform.Position = new Vector3(0, 0, -5);
        //
        // var image = new ImageAsset();
        // image.LoadAsset($"{BasePath}textures/grid_blue.cda");
        //
        // var texture = context.CreateTexture(TextureBufferTarget.Texture2D, image.Data);
        //
        // var camera = new Camera(driver);
        // camera.SetClipPlane(0.001f, 1000);
        // camera.ClearColor = SysColor.Gray;
        //
        // var cameraUniformBuffer = context.CreateUniformBuffer(
        //     "Matrices",
        //     new BufferLayout(
        //         new[]
        //         {
        //             new BufferElement(0, "m_ViewMatrix", ShaderDataType.Matrix4),
        //             new BufferElement(1, "m_ProjectionMatrix", ShaderDataType.Matrix4)
        //         }
        //     ),
        //     0
        // );
        // cameraUniformBuffer.Attach(shaderProgram);
        //
        // var modelUniformBuffer = context.CreateUniformBuffer(
        //     "Model",
        //     new BufferLayout(
        //         new[]
        //         {
        //             new BufferElement(0, "m_ModelMatrix", ShaderDataType.Matrix4)
        //
        //             // new BufferElement(1,"v_MaterialColor", ShaderDataType.Vector4),
        //             // new BufferElement(2,"v_DefaultColor", ShaderDataType.Vector4)
        //         }
        //     ),
        //     1
        // );
        // modelUniformBuffer.Attach(shaderProgram);
        //
        // var oldSetPrimitiveType = 0;
        // var currentSetPrimitiveType = 0;
        //
        // var primitiveTypeCommands = new ICommand[]
        // {
        //     new SetPrimitiveTypeCommand(PrimitiveType.Triangles),
        //     new SetPrimitiveTypeCommand(PrimitiveType.TriangleStrip),
        //     new SetPrimitiveTypeCommand(PrimitiveType.TriangleFan),
        //     new SetPrimitiveTypeCommand(PrimitiveType.Lines),
        //     new SetPrimitiveTypeCommand(PrimitiveType.LineStrip),
        //     new SetPrimitiveTypeCommand(PrimitiveType.LineLoop),
        //     new SetPrimitiveTypeCommand(PrimitiveType.Points)
        // };
        //
        // // Commands sollten mit einem call von Begin() als aktiv gesetzt werden und erst mit dem call von End() committed werden
        // // bspw.:
        // // commandQueue.Begin();
        //
        // // Color stage
        // // commandQueue.Enqueue<BindShaderProgramCommand>(triangleCommands);
        // // commandQueue.Enqueue<BindUniformBufferCommand>(triangleCommands);
        // // commandQueue.Enqueue<BindTextureCommand>(triangleCommands);
        // // commandQueue.Enqueue<BindBufferArrayCommand>(triangle.BufferArray);
        //
        // // Depth stage
        // // ...
        //
        // // commandQueue.End();
        //
        // var triangleCommands = new CommandGroup
        // {
        //     new BindShaderProgramCommand(shaderProgram),
        //     new BindUniformBufferCommand(modelUniformBuffer),
        //     new ProcessCommand(_ => new SetUniformBufferValueCommand<Matrix4>("m_ModelMatrix", triangleTransform.Transformation)),
        //     new BindTextureCommand(texture, TextureUnit.DiffuseColor),
        //     new BindBufferArrayCommand(triangle.BufferArray),
        //     primitiveTypeCommands[currentSetPrimitiveType],
        //     new SetIndexCountCommand(triangle.IndexCount),
        //     new DrawElementsCommand()
        // };
        //
        // var perspectiveUpdateCommands = new CommandGroup
        // {
        //     new SetUniformValueCommand<Matrix4>("m_ViewMatrix", camera.ViewMatrix), // For Perspective
        //     new SetUniformValueCommand<Matrix4>("m_ProjectionMatrix", camera.GetProjection(ProjectionMode.Perspective))
        // };
        //
        // var commandQueue = new CommandQueue();
        // commandQueue.Enqueue(triangleCommands);
        //
        // var commandHandler = new CommandHandler();
        //
        // var renderer = new ForwardRenderer(context, commandQueue, commandHandler);
        // const float speed = 5f;
        // while (!window.WindowTerminated())
        // {
        //     // Prepare frame
        //     //cameraUniformBuffer.SetUniformData("m_ViewMatrix", camera.Transform.Transformation); // For Orthographic
        //     cameraUniformBuffer.SetUniformData("m_ViewMatrix", camera.ViewMatrix);
        //     cameraUniformBuffer.SetUniformData("m_ProjectionMatrix", camera.GetProjection(ProjectionMode.Perspective));
        //
        //     // Render frame
        //     driver.Clear();
        //     driver.HandleEvents();
        //
        //     renderer.Render();
        //     driver.Swap();
        //
        //     // Keyboard input
        //     if (Keyboard.GetKey(KeyCode.Escape))
        //     {
        //         window.Terminate();
        //     }
        //
        //     if (Keyboard.GetKey(KeyCode.W))
        //     {
        //         currentSetPrimitiveType++;
        //         currentSetPrimitiveType %= primitiveTypeCommands.Length - 1;
        //         triangleCommands.Replace(primitiveTypeCommands[oldSetPrimitiveType], primitiveTypeCommands[currentSetPrimitiveType]);
        //         oldSetPrimitiveType = currentSetPrimitiveType;
        //     }
        //
        //     if (Keyboard.GetKeyDown(KeyCode.Left))
        //     {
        //         camera.Transform.Translate(-Vector3.Right * speed * Time.Instance.DeltaTime, CoordinateSpace.Local);
        //     }
        //
        //     if (Keyboard.GetKeyDown(KeyCode.Right))
        //     {
        //         camera.Transform.Translate(Vector3.Right * speed * Time.Instance.DeltaTime, CoordinateSpace.Local);
        //     }
        //
        //     if (Keyboard.GetKeyDown(KeyCode.Up))
        //     {
        //         camera.Transform.Translate(Vector3.Up * speed * Time.Instance.DeltaTime, CoordinateSpace.Local);
        //     }
        //
        //     if (Keyboard.GetKeyDown(KeyCode.Down))
        //     {
        //         camera.Transform.Translate(-Vector3.Up * speed * Time.Instance.DeltaTime, CoordinateSpace.Local);
        //     }
        //
        //     if (Keyboard.GetKeyDown(KeyCode.Q))
        //     {
        //         camera.Transform.Translate(-Vector3.Forward * speed * Time.Instance.DeltaTime, CoordinateSpace.Local);
        //     }
        //
        //     if (Keyboard.GetKeyDown(KeyCode.E))
        //     {
        //         camera.Transform.Translate(Vector3.Forward * speed * Time.Instance.DeltaTime, CoordinateSpace.Local);
        //     }
        //
        //     // Prepare next frame
        //     triangleCommands.Reset();
        //     commandQueue.Enqueue(triangleCommands);
        // }
        //
        // modelUniformBuffer.Dispose();
        // cameraUniformBuffer.Dispose();
        // shaderProgram.Dispose();
        // triangle.BufferArray.Dispose();
        //
        // driver.Close();
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
