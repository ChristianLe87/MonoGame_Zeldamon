﻿using System;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IScene
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
