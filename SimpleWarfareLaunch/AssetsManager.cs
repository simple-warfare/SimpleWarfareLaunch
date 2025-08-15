using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Graphics;

namespace SimpleWarfareLaunch;

public class AssetsManager
{
    public readonly Song BackgroundMusic;
    public readonly Texture2D Dialog;
    public readonly Texture2D LoadingScreen;

    public AssetsManager(ContentManager content)
    {
        Instance = this;
        LoadingScreen = content.Load<Texture2D>("textures/interfaces/loading_screen");
        Dialog = content.Load<Texture2D>("textures/interfaces/dialog");
        BackgroundMusic = content.Load<Song>("musics/background");

        var diglogAtlas = Texture2DAtlas.Create("dialog", Dialog, Dialog.Width, Dialog.Height);
        diglogAtlas.CreateRegion(512, 464, 209, 33, "mainMenu");
    }

    internal static AssetsManager Instance { get; private set; }
}