using System;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Key : Entity
    {
        public Key(Texture2D texture, Vector2 centerPosition) : base(texture, centerPosition)
        {
            base.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => UpdateSystem();
        }

        private void UpdateSystem()
        {
            if (isActive)
            {
                Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

                if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
                {
                    isActive = false;

                    ChristianGame.gameData.key1_entity_isVisible = false;
                    ChristianGame.gameData.key1_ui_isVisible = true;

                    ChristianGame.GetScene.UIs.Add(new Image(texture: WK.Textures.Other.key, new Vector2(40, 20), "key1"));
                }
            }
        }
    }
}