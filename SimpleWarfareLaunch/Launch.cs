using System;
using Gum.Forms;
using Gum.Forms.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGameGum;

namespace SimpleWarfareLaunch;

public class Launch : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private AssetsManager AssetsManager;

    public Launch()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        AppState = AppState.LoadingAssets;
    }

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
        FrameworkElement.TabReverseKeyCombos.Add(
            new KeyCombo { PushedKey = Keys.Up });

        // Customize the tab UI navigation to also trigger when the keyboard
        // Down arrow key is pushed.
        FrameworkElement.TabKeyCombos.Add(
            new KeyCombo { PushedKey = Keys.Down });

        // The assets created for the UI were done so at 1/4th the size to keep the size of the
        // texture atlas small.  So we will set the default canvas size to be 1/4th the size of
        // the game's resolution then tell gum to zoom in by a factor of 4.
        GumService.Default.CanvasWidth = GraphicsDevice.PresentationParameters.BackBufferWidth / 4.0f;
        GumService.Default.CanvasHeight = GraphicsDevice.PresentationParameters.BackBufferHeight / 4.0f;
        GumService.Default.Renderer.Camera.Zoom = 4.0f;
    }


    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Content.RootDirectory = "Content/assets";
        AssetsManager = new AssetsManager(Content);
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(AssetsManager.BackgroundMusic);
        AppState = AppState.Main;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Gray);

        switch (AppState)
        {
            case AppState.LoadingAssets:
            {
                var loadingScreen = AssetsManager.LoadingScreen;
                _spriteBatch.Begin();
                _spriteBatch.Draw(loadingScreen, new Vector2(
                        Window.ClientBounds.Width,
                        Window.ClientBounds.Height) * 0.5f,
                    null,
                    Color.White,
                    0.0f,
                    new Vector2(
                        loadingScreen.Width,
                        loadingScreen.Height) * 0.5f,
                    1.0f,
                    SpriteEffects.None,
                    0.0f
                );
                _spriteBatch.End();
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
    }
}