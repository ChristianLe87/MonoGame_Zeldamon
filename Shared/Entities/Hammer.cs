using System;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Hammer : Entity
    {
        public Hammer(Texture2D texture, Vector2 centerPosition) : base(texture, centerPosition)
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
                    ChristianGame.gameData.hammer_entity_isVisible = false;
                    ChristianGame.gameData.hammer_ui_isVisible = true;

                    ChristianGame.GetScene.UIs.Add(new Image(texture: WK.Textures.Other.hammer, new Vector2(20, 20), "hammer"));
                }
            }
        }
    }
}