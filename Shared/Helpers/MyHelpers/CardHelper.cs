using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class CardHelper
    {
        public static void Update()
        {
        }

        public static void Draw(SpriteBatch spriteBatch, ICard card)
        {
            spriteBatch.Draw(card.texture2D, card.rectangle, Color.White);
        }
    }
}
