using MonoGameGum;

namespace SimpleWarfareLauncher.Screen;

public class MainScreen
{
    private AssetsManager _assetsManager;

    public void Draw()
    {
        GumService.Default.Root.Children.Clear();
    }
}