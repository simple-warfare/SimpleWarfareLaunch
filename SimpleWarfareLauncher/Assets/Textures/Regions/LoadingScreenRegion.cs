using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace SimpleWarfareLauncher.Assets.Textures.Regions;

public class LoadingScreenRegion
{
    private static readonly ContentManager Content = Launcher.Instance.Content;
    public static Texture2D Texture { get; } = Content.Load<Texture2D>("textures/interfaces/loading_screen");
    public Texture2DRegion Main { get; } = new(Texture);
    internal static LoadingScreenRegion Instance { get; } = new();
}