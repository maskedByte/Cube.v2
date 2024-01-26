using Engine.Assets.AssetHandling;
using Engine.Core.Driver.Input;
using Engine.Core.Driver.Window.Configurations;
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
    private static World _world;

    private static Entity _mainCamera;
    private static Entity _mainCameraOrtho;
    private const string BasePath = @".\base\";

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
        var window = driver.CreateWindow(
            $"Cube.Engine v2 - Testing - {core.ActiveDriver.GetType().Name}",
            new WindowCreationConfiguration
            {
                CanvasSize = new Size(1280, 1024),
                ShowCursor = true,
                WindowStyle = new WindowStyleConfiguration
                {
                    ResizeAble = true
                },
                WindowContext = new WindowContextConfiguration
                {
                    MajorVersion = 4
                }
            }
        );

        _world = new World(core);

        _mainCamera = new Entity(_world);
        _mainCamera.Tag = "Camera";
        var camComponent = _mainCamera.AddComponent<CameraComponent>();
        camComponent.ClearColor = SysColor.Gray;
        camComponent.ProjectionMode = ProjectionMode.Orthographic;
        camComponent.FieldOfView = 62f;

        var light = new Entity(_world);
        light.AddComponent<DirectionalLightComponent>();

        var rect = new Entity(_world);
        rect.Tag = "Rect";
        rect.AddComponent<MeshComponent>()
           .Mesh = new QuadMesh(_world.Context);
        rect.AddComponent<MaterialComponent>()
           .Material = new Material("\\materials\\grid_blue_material");
        var transform = rect.GetComponent<TransformComponent>()
           .Transform;

        transform.Scale = new Vector3(256, 256, 1);
        transform.Position = new Vector3(128, -128, 0);

        var rotation = 0f;
        while (!Keyboard.GetKey(KeyCode.Escape) && !window.WindowTerminated())
        {
            var deltaTime = _world.Time.DeltaTime;

            //transform.Rotate(new Vector3(0, 0, 1f * deltaTime));

            _world.Update();
            _world.Render();

            KeyControls(deltaTime, .5f);
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
            translation.Y -= 100f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.S))
        {
            translation.Y += 100f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.A))
        {
            translation.X += 100f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.D))
        {
            translation.X -= 100f * deltaTime;
        }

        // if (Mouse.MouseButtonDown(MouseButtons.Right))
        // {
        //     var yaw = Mathf.Radians(Mouse.MouseXDelta() * sensitivity);
        //     var pitch = Mathf.Radians(Mouse.MouseYDelta() * sensitivity);
        //
        //     transform.Rotate(Quaternion.CreateFromYawPitchRoll(yaw, pitch, 0f), CoordinateSpace.Local);
        // }

        transform.Translate(translation, CoordinateSpace.Local);
    }
}
