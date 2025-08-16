using MonoGameGum;

namespace SimpleWarfareLauncher.Screen;

public class MainScreen
{
    private Launcher _launcher = Launcher.Instance;
    internal static MainScreen Instance { get; } = new();

    public void Draw()
    {
        GumService.Default.Root.Children.Clear();
    }
}