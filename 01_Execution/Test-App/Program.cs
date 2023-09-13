using Engine.Assets.AssetHandling;
using Engine.Core.Driver.Input;
using Engine.Core.Math;
using Engine.Core.Math.Base;
using Engine.Core.Math.Quaternions;
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
    private static World _world;

    private static Entity _mainCamera;
    private static Entity _mainCameraOrtho;
    private const string BasePath = ".\\base\\";

    private static Random random = new();

    private static float _pitch;
    private static float _yaw;

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

        _world = new World(core);

        _mainCamera = new Entity(_world);
        _mainCamera.Tag = "Camera";
        _mainCamera.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(0, 0, 2);
        var camComponent = _mainCamera.AddComponent<CameraComponent>();
        camComponent.ClearColor = SysColor.Gray;
        camComponent.ProjectionMode = ProjectionMode.Perspective;
        camComponent.FieldOfView = 62f;

        var light = new Entity(_world);
        light.Tag = "Light";
        var dirLight = light.AddComponent<DirectionalLightComponent>().Light;
        dirLight.Color = new Color(255, 125, 5);
        dirLight.Intensity = .8f;
        light.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(_world.Context);
        light.GetComponent<TransformComponent>()!
           .Transform.Position = new Vector3(0, 10, -2);

        var cube = new Entity(_world);
        cube.Tag = "Cube";
        cube.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(_world.Context);
        cube.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_blue_material");
        cube.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(0, 0, -1f);

        var cube2 = new Entity(_world);
        cube2.Tag = "Cube2";
        cube2.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(_world.Context);
        cube2.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_yellow_material");
        cube2.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(2, 0, -1f);

        var rect = new Entity(_world);
        rect.Tag = "Rect";
        rect.AddComponent<MeshComponent>()
           .Mesh = new SphereMesh(_world.Context);
        rect.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_blue_material");
        rect.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(4, 0, 1f);

        var rotation = 0f;
        while (!Keyboard.GetKey(KeyCode.Escape) && !window.WindowTerminated())
        {
            var deltaTime = _world.Time.DeltaTime;

            rotation += 0.5f * deltaTime;
            cube.GetComponent<TransformComponent>()!.Transform.Rotation = Quaternion.FromEulerAngles(0, rotation, 0);
            cube2.GetComponent<TransformComponent>()!.Transform.Rotation = Quaternion.FromEulerAngles(rotation, 0, 0);
            rect.GetComponent<TransformComponent>()!.Transform.Rotation = Quaternion.FromEulerAngles(-rotation, 0, -rotation);

            light.GetComponent<TransformComponent>()!.Transform.LocalRotation = Quaternion.FromEulerAngles(rotation, rotation, 0);

            _world.Update();
            _world.Render();

            KeyControls(_world.Time.DeltaTime, .5f);
        }

        driver.Close();
        _world.Dispose();
    }

    private static void KeyControls(float deltaTime, float sensitivity)
    {
        var transform = _mainCamera.GetComponent<TransformComponent>()!.Transform;
        var translation = Vector3.Zero;

        if (Keyboard.GetKeyDown(KeyCode.W))
        {
            translation.Z -= 10f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.S))
        {
            translation.Z += 10f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.A))
        {
            translation.X -= 10f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.D))
        {
            translation.X += 10f * deltaTime;
        }

        transform.Translate(translation, CoordinateSpace.Local);

        if (Mouse.MouseButtonDown(MouseButtons.Right))
        {
            var yaw = Mathf.Radians(Mouse.MouseXDelta() * sensitivity);
            var pitch = Mathf.Radians(Mouse.MouseYDelta() * sensitivity);

            transform.Rotate(Quaternion.CreateFromYawPitchRoll(yaw, pitch, 0f), CoordinateSpace.Local);

            // transform.Rotate(ySpeed, xSpeed, 0f, CoordinateSpace.Local);
        }
    }
}
