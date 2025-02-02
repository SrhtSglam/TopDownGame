using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework.Storage; //Extra Extension
using Microsoft.Xna.Framework.Input;

namespace project;

public class Game1 : Game
{
    #region Texture2D Variables 
        Texture2D ballTexture;
        Texture2D backgroundTexture;

    #endregion

    #region Vector2D Variables
        Vector2 ballPosition;
        Vector2 backgroundPosition;

    #endregion

    float ballSpeed;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = 1280; // Genişlik
        _graphics.PreferredBackBufferHeight = 720; // Yükseklik
        _graphics.IsFullScreen = false; // Tam ekran yapma, sadece pencere modunda olacak
        Window.AllowUserResizing = false; // Pencerenin boyutunu değiştirmeyi aktif et

    }

    protected override void Initialize()
    {
        backgroundPosition = new Vector2(0, 0);

        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                                   _graphics.PreferredBackBufferHeight / 2);
        ballSpeed = 100f;
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        ballTexture = Content.Load<Texture2D>("ball");
        backgroundTexture = Content.Load<Texture2D>("background");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float updatedBallSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        var kstate = Keyboard.GetState();
        
        if (kstate.IsKeyDown(Keys.Up))
        {
            ballPosition.Y -= updatedBallSpeed;
        }
        
        if (kstate.IsKeyDown(Keys.Down))
        {
            ballPosition.Y += updatedBallSpeed;
        }
        
        if (kstate.IsKeyDown(Keys.Left))
        {
            ballPosition.X -= updatedBallSpeed;
        }
        
        if (kstate.IsKeyDown(Keys.Right))
        {
            ballPosition.X += updatedBallSpeed;
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
    
        _spriteBatch.Begin();
        // _spriteBatch.Draw(ballTexture, new Vector2(0, 0), Color.White);
        _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1280, 720), Color.White);
        _spriteBatch.Draw(ballTexture, ballPosition, Color.White);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
