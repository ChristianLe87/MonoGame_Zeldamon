using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class PointsFeedbackHelper
    {
        public static void Update(PointsFeedback pointsFeedback)
        {
            if (pointsFeedback.isAlive == true)
            {
                pointsFeedback.text.position.Y = pointsFeedback.text.position.Y - 0.5f;
                pointsFeedback.actualTime++;
                if (pointsFeedback.actualTime > pointsFeedback.timeToDestroy) pointsFeedback.isAlive = false;
            }
        }

        public static void Draw(SpriteBatch spriteBatch, PointsFeedback pointsFeedback)
        {
            if (pointsFeedback.isAlive == true)
            {
                TextHelper.Draw(spriteBatch, pointsFeedback.text);
            }
        }
    }
}
