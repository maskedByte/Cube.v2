using Engine.OpenGL.Driver;

public class TestApp
{
    public static void Main(string[] args)
    {
        // Create simple OpenGl window
        var driver = new OpenGl();
        var Window = driver.CreateWindow(800, 600, false, true);


        while (!Window.WindowTerminated())
        {
            driver.Clear();

            driver.HandleEvents();
            driver.Swap();
        }

        driver.Close();
    }
}
