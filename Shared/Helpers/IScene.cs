using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IScene
    {
        public void Initialize(Point startPlayerPosition);
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
