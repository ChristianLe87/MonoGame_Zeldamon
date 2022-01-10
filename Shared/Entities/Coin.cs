using System;
using System.Linq;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Coin : Entity
    {
        public Coin(Texture2D texture, Vector2 centerPosition) : base(texture, centerPosition)
        {
            base.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Update();
        }

        private void Update()
        {
            if (isActive)
            {
                Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

                if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
                {
                    isActive = false;
                }
            }
        }
    }
}