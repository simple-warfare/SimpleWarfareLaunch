using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SimpleWarfareLauncher.Assets.Songs;

public class Songs
{
    private static readonly ContentManager Content = Launcher.Instance.Content;
    public static Song Background = Content.Load<Song>("musics/background");
    internal static Songs Instance { get; } = new();
}