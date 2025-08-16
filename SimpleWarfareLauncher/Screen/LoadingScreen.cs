using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameGum;
using SimpleWarfareLauncher.Assets.Textures.Regions;

namespace SimpleWarfareLauncher.Screen;

public class LoadingScreen
{
    private readonly Launcher _launcher = Launcher.Instance;
    internal static LoadingScreen Instance { get; } = new();

    public void Draw()
    {
        var spriteBatch = _launcher.SpriteBatch;
        var window = _launcher.Window;
        var loadingScreen = LoadingScreenRegion.Texture;

        spriteBatch.Begin();
        spriteBatch.Draw(loadingScreen, new Vector2(window.ClientBounds.Width, window.ClientBounds.Height) * 0.5f, null,
            Color.White, 0.0f, new Vector2(loadingScreen.Width, loadingScreen.Height) * 0.5f, 1.0f, SpriteEffects.None,
            0.0f);
        spriteBatch.End();
        GumService.Default.Root.Children.Clear();
    }
}