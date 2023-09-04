using Engine.Assets.AssetHandling;
using Engine.Core.Driver.Input;
using Engine.Core.Math.Base;
using Engine.Core.Math.Quaternions;
using Engine.Core.Math.Vectors;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Framework.Rendering;
using Engine.Framework.Rendering.Cameras;
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
        mainCamera.Tag = "Camera";
        var camComponent = mainCamera.AddComponent<CameraComponent>();
        camComponent.ClearColor = SysColor.Gray;
        camComponent.ProjectionMode = ProjectionMode.Perspective;
        camComponent.FieldOfView = 62f;

        var cube = new Entity(world);
        cube.Tag = "Cube";
        cube.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(world.Context);
        cube.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_blue_material");
        cube.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(-1, 0, -5f);

        var cube2 = new Entity(world);
        cube2.Tag = "Cube2";
        cube2.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(world.Context);
        cube2.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_blue_material1");
        cube2.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(1, 0, -5f);

        // Main loop
        var rotation = 0f;
        while (!Keyboard.GetKey(KeyCode.Escape) && !window.WindowTerminated())
        {
            rotation += 0.5f * world.Time.DeltaTime;
            cube.GetComponent<TransformComponent>()!.Transform.Rotation = Quaternion.FromEulerAngles(rotation, rotation, 0);
            cube2.GetComponent<TransformComponent>()!.Transform.Rotation = Quaternion.FromEulerAngles(-rotation, -rotation, 0);

            world.Update();
            world.Render();
        }

        driver.Close();
        world.Dispose();
    }
}
