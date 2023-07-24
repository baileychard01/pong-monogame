using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong;

public class PlayerPaddle
{
    private Vector2 _paddlePos;
    private float paddleSpeed = 5;

    public PlayerPaddle()
    {
        _paddlePos = new Vector2(20, Game1.WindowHeight / 2f - Game1.PaddleTexture.Height / 2f);
    }
        
    public void Update()
    {
        var keystate = Keyboard.GetState();
        if (keystate.IsKeyDown(Keys.W))
        {
            _paddlePos.Y -= paddleSpeed;
        }
        
        if (keystate.IsKeyDown(Keys.S))
        {
            _paddlePos.Y += paddleSpeed;
        } 
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Game1.PaddleTexture,_paddlePos,Color.White);

    }
}