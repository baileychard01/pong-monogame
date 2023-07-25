using Microsoft.Xna.Framework;

namespace pong;

public class EnemyPaddle:BasePaddle
{

    public EnemyPaddle(Vector2 startPos) : base(startPos)
    {
    }

    public override void Update()
    {
        PaddlePos.Y = Game1.Ball._ballPos.Y - Game1.PaddleTexture.Height / 2f;
        base.Update();


    }
}