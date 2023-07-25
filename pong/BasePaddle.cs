using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pong;

public class BasePaddle
{   
    public Vector2 PaddlePos;
    public float PaddleSpeed = 5;

    public BasePaddle(Vector2 startPos)
    {
        PaddlePos = startPos;
    }

    public virtual void Update()
    {
        PaddlePos.Y = MathHelper.Clamp(PaddlePos.Y, 0, Game1.WindowHeight - Game1.PaddleTexture.Height);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Game1.PaddleTexture,PaddlePos,Color.White);

    }
    
}