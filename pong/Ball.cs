using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pong;

public class Ball
{
    
    public void Update()
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Game1.BallTexture,new Vector2(Game1.WindowWidth / 2,Game1.WindowHeight/2),Color.White);

    }

    public float getSpeed()
    {
        return 0.0f;
    }
}