using System.Drawing;
using Engine.OpenGL.Driver;

public class TestApp
{
    public static void Main(string[] args)
    {
        // Create simple OpenGl window
        var driver = new OpenGlDriver();
        var window = driver.CreateWindow(800, 600, false, false);

        driver.SetClearColor(Color.Coral);

        while (!window.WindowTerminated())
        {
            driver.Clear();

            driver.HandleEvents();
            driver.Swap();
        }

        driver.Close();
    }
}
