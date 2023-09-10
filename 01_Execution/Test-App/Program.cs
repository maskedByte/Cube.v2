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
        _world.AmbientLight.Color = new Color(236, 241, 243);

        // var light = new Entity(_world);
        // light.Tag = "Light";
        // light.AddComponent<DirectionalLightComponent>().Light.Color = SysColor.Peru;
        // light.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(0, 0, -2);

        _mainCamera = new Entity(_world);
        _mainCamera.Tag = "Camera";
        _mainCamera.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(0, 2, 0);

        var camComponent = _mainCamera.AddComponent<CameraComponent>();
        camComponent.ClearColor = SysColor.Gray;
        camComponent.ProjectionMode = ProjectionMode.Perspective;
        camComponent.FieldOfView = 62f;

        var cube = new Entity(_world);
        cube.Tag = "Cube";
        cube.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(_world.Context);
        cube.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_blue_material");
        cube.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(0, 0, -5f);

        var cube2 = new Entity(_world);
        cube2.Tag = "Cube2";
        cube2.AddComponent<MeshComponent>()
           .Mesh = new CubeMesh(_world.Context);
        cube2.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_yellow_material");
        cube2.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(0, 0, 3f);

        var rect = new Entity(_world, cube2);
        rect.Tag = "Rect";
        rect.AddComponent<MeshComponent>()
           .Mesh = new SphereMesh(_world.Context);
        rect.AddComponent<MaterialComponent>()
           .Material = new Material("materials\\grid_blue_material");
        rect.GetComponent<TransformComponent>()!.Transform.Position = new Vector3(0, 0, 4f);
        rect.GetComponent<TransformComponent>()!.Transform.Scale = new Vector3(.7f, .7f, .7f);

        // Main loop
        const float mouseSensitivity = 50f;
        const float clampAngle = 80.0f;

        var camTransform = _mainCamera.GetComponent<TransformComponent>()!.Transform;
        var rot = camTransform.LocalRotation.ToEulerAngles();
        var rotY = rot.Y; // rotation around the up/y axis
        var rotX = rot.X; // rotation around the right/x axis

        var rotation = 0f;
        while (!Keyboard.GetKey(KeyCode.Escape) && !window.WindowTerminated())
        {
            var deltaTime = _world.Time.DeltaTime;

            rotation += 0.5f * deltaTime;
            cube2.GetComponent<TransformComponent>()!.Transform.Rotation = Quaternion.FromEulerAngles(rotation, 0, 0);
            rect.GetComponent<TransformComponent>()!.Transform.Rotation = Quaternion.FromEulerAngles(-rotation, -rotation, -rotation);

            _world.Update();
            _world.Render();

            // Mouse look
            if (Mouse.MouseButtonDown(MouseButtons.Right))
            {
                var mouseX = Mouse.MouseXDelta() * mouseSensitivity * deltaTime;
                var mouseY = Mouse.MouseYDelta() * mouseSensitivity * deltaTime;

                rotY += mouseX;
                rotX += mouseY;

                rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

                camTransform.LocalRotation = Quaternion.FromEulerAngles(rotX, rotY, 0.0f);
            }

            KeyControls(_world.Time.DeltaTime);
        }

        driver.Close();
        _world.Dispose();
    }

    private static void KeyControls(float deltaTime)
    {
        if (Keyboard.GetKeyDown(KeyCode.W))
        {
            _mainCamera.GetComponent<TransformComponent>()!.Transform.Position +=
                _mainCamera.GetComponent<CameraComponent>()!.Forward * 10f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.S))
        {
            _mainCamera.GetComponent<TransformComponent>()!.Transform.Position -=
                _mainCamera.GetComponent<CameraComponent>()!.Forward * 10f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.A))
        {
            _mainCamera.GetComponent<TransformComponent>()!.Transform.Position -=
                _mainCamera.GetComponent<CameraComponent>()!.Right * 10f * deltaTime;
        }

        if (Keyboard.GetKeyDown(KeyCode.D))
        {
            _mainCamera.GetComponent<TransformComponent>()!.Transform.Position +=
                _mainCamera.GetComponent<CameraComponent>()!.Right * 10f * deltaTime;
        }
    }
}
