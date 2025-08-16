using System;
using Gum.Forms;
using Gum.Forms.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGameGum;
using SimpleWarfareLauncher.Assets.Songs;
using SimpleWarfareLauncher.Screen;

namespace SimpleWarfareLauncher;

public class Launcher : Game
{
    private GraphicsDeviceManager _graphics;

    public Launcher()
    {
        Instance = this;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content/assets";
        IsMouseVisible = true;
        AppState = AppState.Loading;
    }

    internal SpriteBatch SpriteBatch { get; private set; }

    internal static Launcher Instance { get; private set; }

    private AppState AppState { get; set; }

    protected override void Initialize()
    {
        base.Initialize();
        InitializeGum();
    }

    private void InitializeGum()
    {
        // Initialize the Gum service. The second parameter specifies
        // the version of the default visuals to use. V2 is the latest
        // version.
        GumService.Default.Initialize(this, DefaultVisualsVersion.V2);

        // Tell the Gum service which content manager to use.  We will tell it to
        // use the global content manager from our Core.
        if (GumService.Default.ContentLoader != null) GumService.Default.ContentLoader.XnaContentManager = Content;

        // Register keyboard input for UI control.
        FrameworkElement.KeyboardsForUiControl.Add(GumService.Default.Keyboard);

        // Register gamepad input for Ui control.
        FrameworkElement.GamePadsForUiControl.AddRange(GumService.Default.Gamepads);

        // Customize the tab reverse UI navigation to also trigger when the keyboard
        // Up arrow key is pushed.
        FrameworkElement.TabReverseKeyCombos.Add(new KeyCombo { PushedKey = Keys.Up });

        // Customize the tab UI navigation to also trigger when the keyboard
        // Down arrow key is pushed.
        FrameworkElement.TabKeyCombos.Add(new KeyCombo { PushedKey = Keys.Down });

        // The assets created for the UI were done so at 1/4th the size to keep the size of the
        // texture atlas small.  So we will set the default canvas size to be 1/4th the size of
        // the game's resolution then tell gum to zoom in by a factor of 4.
        GumService.Default.CanvasWidth = GraphicsDevice.PresentationParameters.BackBufferWidth / 4.0f;
        GumService.Default.CanvasHeight = GraphicsDevice.PresentationParameters.BackBufferHeight / 4.0f;
        GumService.Default.Renderer.Camera.Zoom = 4.0f;
    }


    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(Songs.Background);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (gameTime.TotalGameTime.Seconds >= 1) AppState = AppState.Main;


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Gray);

        switch (AppState)
        {
            case AppState.Loading:
            {
                LoadingScreen.Instance.Draw();
                break;
            }
            case AppState.Main:
            {
            }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


        base.Draw(gameTime);
        GumService.Default.Draw();
    }
}