using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace SimpleWarfareLauncher.Assets.Textures.Regions;

public class DialogRegion
{
    private static readonly ContentManager Content = Launcher.Instance.Content;
    private readonly Launcher _launcher = Launcher.Instance;
    private static Texture2D Texture { get; } = Content.Load<Texture2D>("textures/interfaces/dialog");
    public Texture2DRegion MainMenu { get; } = new(Texture, 512, 464, 209, 33);
    internal static DialogRegion Instance { get; } = new();
}