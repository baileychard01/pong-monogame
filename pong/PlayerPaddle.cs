using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong;

public class PlayerPaddle : BasePaddle
{

    
        
    public override void Update()
    {
        var keystate = Keyboard.GetState();
        if (keystate.IsKeyDown(Keys.W))
        {
            PaddlePos.Y -= PaddleSpeed;
        }
        
        if (keystate.IsKeyDown(Keys.S))
        {
            PaddlePos.Y += PaddleSpeed;
        } 
        
        base.Update();

    }
    


    public PlayerPaddle(Vector2 startPos) : base(startPos)
    {
    }
}