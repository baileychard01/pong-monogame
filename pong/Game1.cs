using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace pong;

public class Game1 : Game
{
    public static readonly int WindowWidth = 1280;
    public static readonly int WindowHeight = 720;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background;
    public static Texture2D PaddleTexture;
    public static Texture2D BallTexture;
    private BasePaddle _player;
    private BasePaddle _enemy;
    public static Ball Ball;
    private Song backMusic;
    public SpriteFont ScoreFont; 


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = WindowWidth;
        _graphics.PreferredBackBufferHeight = WindowHeight;
        _graphics.ApplyChanges();
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        //loads the background image into _background
        _background = Content.Load<Texture2D>("background");
        
        //loads the paddle image into PaddleTexture
        PaddleTexture = Content.Load<Texture2D>("paddle");
        
        //loads the ball image into BallTexture
        BallTexture = Content.Load<Texture2D>("ball");

        ScoreFont = Content.Load<SpriteFont>("Font");
        
        //initialises the PlayerPaddle class
        var playerpos = new Vector2(20, Game1.WindowHeight / 2f - Game1.PaddleTexture.Height / 2f);

        var enemypos = new Vector2(WindowWidth-20-PaddleTexture.Width, Game1.WindowHeight / 2f - Game1.PaddleTexture.Height / 2f);

        _player = new PlayerPaddle(playerpos);
        _enemy = new EnemyPaddle(enemypos);
        
        //initialises the Ball class
        Ball = new Ball(_player,_enemy);
        
        
        
        // loads the song into backmusic
        backMusic = Content.Load<Song>("backgroundMusic");
        
        //starts playing backMusic
        MediaPlayer.Play(backMusic);
        
        //sets the mediaPlayer function to repeats 
        MediaPlayer.IsRepeating = true;
        
        //changing the velocity veceter which is in the Ball class
        Ball.SetSpeed(5f);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        
        //calling the update methods in the classes
        _player.Update();
        _enemy.Update();
        Ball.Update();
        
        

        // TODO: Add your update logic here

        base.Update(gameTime);
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        //starts the sprite batch
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
        var destinationRectangle = new Rectangle(0, 0, WindowWidth, WindowHeight);
        _spriteBatch.Draw(_background, destinationRectangle,Color.White);
        _player.Draw(_spriteBatch);
        _enemy.Draw(_spriteBatch);
        Ball.Draw(_spriteBatch);
        _spriteBatch.DrawString(ScoreFont,"your score:"+Ball.playerScore + "",new Vector2(Game1.WindowWidth/2f - 300f,0),Color.White);
        _spriteBatch.DrawString(ScoreFont,"opponent score:"+Ball.enemyScore + "",new Vector2(Game1.WindowWidth/2f,0),Color.White);

        //ends the sprite batch
        _spriteBatch.End();

        // TODO: Add your drawing code here
        

        base.Draw(gameTime);
    }
}