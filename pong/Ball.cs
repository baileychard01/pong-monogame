using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pong;

public class Ball
{
    private readonly BasePaddle _playerPaddle;
    private readonly BasePaddle _enemyPaddle;
    public static Vector2 velocity;

    public Vector2 _ballPos;
    public int playerScore;
    public int enemyScore;
    Random random = new Random();

    private float _ballSpeed = 3.0f;

    public Ball(BasePaddle playerPaddle, BasePaddle enemyPaddle)
    {
        _playerPaddle = playerPaddle;
        _enemyPaddle = enemyPaddle;
        _ballPos = new Vector2(Game1.WindowWidth / 2, Game1.WindowHeight / 2 - Game1.BallTexture.Width / 2);
    }

    public void Update()
    {
        var newPosition = _ballPos + velocity;
        _ballPos.X = _ballPos.X + (int)velocity.X;
        _ballPos.Y = _ballPos.Y + (int)velocity.Y;

        if (_ballPos.X <= 0)
        {
            velocity.X = -velocity.X;
            enemyScore += 1;
            resetBall();
        }


        if (_ballPos.X + Game1.BallTexture.Width >= Game1.WindowWidth)
        {
            velocity.X = -velocity.X;
            playerScore += 1;
            resetBall();
        }


        if (_ballPos.Y <= 0)
            velocity.Y = -velocity.Y;
        if (_ballPos.Y + Game1.BallTexture.Height >= Game1.WindowHeight)
            velocity.Y = -velocity.Y;


        //if (paddleRect.Bottom.Intersects)
        testCollsion(_playerPaddle);
        testCollsion(_enemyPaddle);

    }

    public void testCollsion(BasePaddle paddle)
    {
        var paddleRect = new Rectangle((int)paddle.PaddlePos.X, (int)paddle.PaddlePos.Y,
            Game1.PaddleTexture.Width, Game1.PaddleTexture.Height);

        var ballRect = new Rectangle((int)_ballPos.X, (int)_ballPos.Y, Game1.BallTexture.Width,
            Game1.BallTexture.Height);


        if (ballRect.Intersects(paddleRect))
        {
            var test = random.Next(1, 3);

            velocity.X *= -1.1f;

            if (test == 1)
            {
                velocity.Y = -_ballSpeed;
            }
            else if (test == 2)
            {
                velocity.Y = _ballSpeed;
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Game1.BallTexture, _ballPos, Color.White);
    }

    /// <summary>
    /// Sets the speed of the ball
    /// </summary>
    /// <param name="speed">The new base speed of the balls</param>
    public void SetSpeed(float speed)
    {
        velocity.X = speed;
        velocity.Y = speed;
        _ballSpeed = speed;
    }

    public void resetBall()
    {
        _ballPos = new Vector2(Game1.WindowWidth / 2.0f, Game1.WindowHeight / 2.0f - Game1.BallTexture.Width / 2.0f);

        velocity.X = _ballSpeed * Math.Sign(velocity.X);
        velocity.Y = _ballSpeed;
    }

    public float getSpeed()
    {
        return 0.0f;
    }
}