using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IScene
    {
        public List<IEntity> entities { get; set; }
        public void Initialize(Point startPlayerPosition);
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
